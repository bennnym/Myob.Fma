using System.Linq;
using Myob.Fma.BookingLibrary;
using Myob.Fma.BookingLibrary.BorrowingItems;
using Myob.Fma.BookingLibrary.Exceptions;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.Resources;
using Xunit;

namespace Myob.Fma.BookingLibraryTests
{
    public class LibraryTests
    {
        public LibraryTests()
        {
            _library = Library.CreateLibraryWithAllManagers(_resourceManager, _membershipManager,
                _borrowingManager);
        }
        
        [Fact]
        public void Should_Throw_Exception_If_Resource_Is_Not_Available_To_Borrow()
        {
            // Arrange
            const int resourceId = 3;
            const int membershipId = ZeroBorrowingLimitMember;

            // Assert
            var exception =
                Assert.Throws<ResourceNotAvailableException>(() => _library.BorrowItem(resourceId, membershipId));
            Assert.Same("Resource is not available", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_If_Membership_Id_Is_Not_Active_To_Borrow()
        {
            // Arrange
            const int resourceId = 1;
            const int membershipId = ZeroBorrowingLimitMember;

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
            const int resourceId = 1;
            const int membershipId = ZeroBorrowingLimitMember;

            // Act
            _resourceManager.AddResourceToInventory(_book);
            _membershipManager.AddMembership(_memberWithZeroBorrowingLimit);

            // Assert
            var exception =
                Assert.Throws<MembersBorrowingLimitExceededException>(
                    () => _library.BorrowItem(resourceId, membershipId));

            Assert.Same("Members borrowing limit exceeded", exception.Message);
        }
        
        [Fact]
        public void Should_Check_If_A_Resource_Becomes_Unavailable_After_It_Is_Borrowed()
        {
            // Arrange
            const int resourceId = 1;
            const int membershipId = NormalMember;

            // Act
            _resourceManager.AddResourceToInventory(_book);
            _membershipManager.AddMembership(_normalMember);
            
            _library.BorrowItem(resourceId, membershipId);
            var resourceIsAvailable = _resourceManager.IsResourceAvailable(resourceId);

            // Assert
            Assert.False(resourceIsAvailable);
        }
        
        [Fact]
        public void Should_Have_A_Borrowed_Item_When_Borrowing_A_Resource()
        {
            // Arrange
            var resourceId = 1;
            var membershipId = NormalMember;

            // Act
            _resourceManager.AddResourceToInventory(_book);
            _membershipManager.AddMembership(_normalMember);
            
            _library.BorrowItem(resourceId,membershipId);
            var borrowedItem = _borrowingManager.GetBorrowedItemHistoryForMember(resourceId, membershipId);
            var itemIsBorrowed = borrowedItem.FirstOrDefault(x => !x.IsReturned && !x.ReturnedDate.HasValue);
            
            // Assert
            Assert.NotNull(itemIsBorrowed);
        }
        
        
        
             
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
            IsAvailable = false
        };

        private readonly Membership _memberWithZeroBorrowingLimit = new Membership()
        {
            IsActive = true,
            MembershipId = 1,
            BorrowingLimit = 0
        };
        
        private readonly Membership _normalMember = new Membership()
        {
            IsActive = true,
            MembershipId = 2,
            BorrowingLimit = 5
        };

        private const int NormalMember = 2;
        private const int ZeroBorrowingLimitMember = 1;
        private readonly Library _library;
        
    }
}