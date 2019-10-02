using System.Linq;
using Myob.Fma.BookingLibrary;
using Myob.Fma.BookingLibrary.BorrowedItemsManagement;
using Myob.Fma.BookingLibrary.Exceptions;
using Myob.Fma.BookingLibrary.MembershipManagement;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.MembershipStatus;
using Myob.Fma.BookingLibrary.ResourceManagement;
using Myob.Fma.BookingLibrary.Resources;
using Xunit;

namespace Myob.Fma.BookingLibraryTests
{
    public class LibraryBorrowingTests
    {
        private readonly ResourceManager _resourceManager = new ResourceManager();
        private readonly BorrowingManager _borrowingManager = new BorrowingManager();
        private readonly MembershipManager _membershipManager = new MembershipManager();


        private readonly Book _book = new Book()
        {
            Id = 1,
            IsAvailable = true
        };

        private readonly BoardGame _boardGame = new BoardGame()
        {
            Id = 2,
            IsAvailable = true
        };

        private readonly Membership _memberWithBronzeBorrowingLimit = new Membership()
        {
            IsActive = true,
            Id = 1,
            MembershipStatus = new BronzeMembership()
        };

        private readonly Membership _normalMember = new Membership()
        {
            IsActive = true,
            Id = 2,
            MembershipStatus = new GoldMembership()
        };

        private const int NormalMember = 2;
        private const int BronzeBorrowingLimitMember = 1;

        private const int Book = 1;
        private const int BoardGame = 2;
        private const int NonExistentResource = 99;
        private readonly Library _library;

        public LibraryBorrowingTests()
        {
            _library = new Library(
                _resourceManager,
                _membershipManager,
                _borrowingManager
                );
        }

        [Fact]
        public void Should_Throw_Exception_If_Resource_Is_Not_Available_To_Borrow()
        {
            // Arrange
            const int resourceId = NonExistentResource;
            const int membershipId = BronzeBorrowingLimitMember;

            // Assert
            var exception =
                Assert.Throws<ResourceNotAvailableToBorrowException>(
                    () => _library.BorrowItem(resourceId, membershipId));
            Assert.Same("Resource is not available", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_If_Membership_Id_Is_Not_Active_To_Borrow()
        {
            // Arrange
            const int resourceId = Book;
            const int membershipId = BronzeBorrowingLimitMember;

            // Act
            _resourceManager.AddResourceToInventory(_book);

            // Assert
            var exception =
                Assert.Throws<MembershipNotActiveException>(() => _library.BorrowItem(resourceId, membershipId));
            Assert.Same("Membership is not active", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_If_Membership_Id_Borrowing_Limit_Is_Exceeded()
        {
            // Arrange
            const int resourceId = Book;
            const int membershipId = BronzeBorrowingLimitMember;

            // Act
            _resourceManager.AddResourceToInventory(_book);
            _resourceManager.AddResourceToInventory(_boardGame);
            _membershipManager.AddMembership(_memberWithBronzeBorrowingLimit);
            _library.BorrowItem(BoardGame, membershipId);

            // Assert
            var exception =
                Assert.Throws<MembersBorrowingLimitExceededException>(
                    () => _library.BorrowItem(resourceId, membershipId));

            Assert.Same("Members borrowing limit exceeded", exception.Message);
        }

        [Fact]
        public void Should_Throw_An_Exception_When_Resource_Becomes_Unavailable_After_It_Is_Borrowed()
        {
            // Arrange
            const int resourceId = Book;
            const int membershipId = NormalMember;

            // Act
            _resourceManager.AddResourceToInventory(_book);
            _membershipManager.AddMembership(_normalMember);

            _library.BorrowItem(resourceId, membershipId);
                Assert.Throws<ResourceNotAvailableToBorrowException>(
                    () => _library.BorrowItem(resourceId, membershipId));
        }

        [Fact]
        public void Should_Have_A_Borrowed_Item_When_Borrowing_A_Resource()
        {
            // Arrange
            var resourceId = Book;
            var membershipId = NormalMember;

            // Act
            _resourceManager.AddResourceToInventory(_book);
            _membershipManager.AddMembership(_normalMember);

            _library.BorrowItem(resourceId, membershipId);
            var borrowedItem = _borrowingManager.GetItemBorrowingHistoryForMember(resourceId, membershipId);
            var itemIsBorrowed = borrowedItem.FirstOrDefault(x => !x.IsReturned && !x.ReturnedDate.HasValue);

            // Assert
            Assert.NotNull(itemIsBorrowed);
        }
    }
}