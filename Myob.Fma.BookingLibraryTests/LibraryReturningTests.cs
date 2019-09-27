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
    public class LibraryReturningTests
    {
        private readonly ResourceManager _resourceManager = new ResourceManager();
        private readonly BorrowingManager _borrowingManager = new BorrowingManager();
        private readonly MembershipManager _membershipManager = new MembershipManager();
        private Library _library;

        private readonly Membership _normalMember = new Membership() //TODO: look into test fixture
        {
            IsActive = true,
            Id = 1,
            MembershipStatus = new GoldMembership()
        };

        private readonly Book _book = new Book()
        {
            Id = 1,
            IsAvailable = false
        };

        public LibraryReturningTests()
        {
            _library = Library.CreateLibraryWithPreExistingManagers(_resourceManager, _membershipManager,
                _borrowingManager);
        }

        [Fact]
        public void Should_Throw_ResourceNotInInventoryException_When_Resource_Not_In_Inventory()
        {
            // Arrange
            var resourceOfNonExistentResource = 999;
            var membershipId = _normalMember.Id;

            // Assert
            var exception = Assert.Throws<ResourceNotInInventoryException>(() =>
                _library.ReturnItem(resourceOfNonExistentResource,
                    membershipId));

            Assert.Equal("Resource is not in library inventory", exception.Message);
        }

        [Fact]
        public void Should_Throw_MembershipNotActiveException_When_Member_Does_Not_Exist()
        {
            // Arrange
            var nonExistentMemberId = 999;
            var resourceId = _book.Id;

            // Act
            _resourceManager.AddResourceToInventory(_book);

            // Assert
            var exception =
                Assert.Throws<MembershipNotActiveException>(() => _library.ReturnItem(resourceId, nonExistentMemberId));
            Assert.Equal("Membership is not active", exception.Message);
        }

        [Fact]
        public void Should_Change_State_Of_Resource_To_IsAvailable_After_Being_Returned()
        {
            // Arrange
            var membershipId = _normalMember.Id;
            var resourceId = _book.Id;
            _resourceManager.AddResourceToInventory(_book);
            _membershipManager.AddMembership(_normalMember);
            _borrowingManager.AddEntryToBorrowedItemsHistory(_book, _normalMember);

            // Act
            _library.ReturnItem(resourceId,membershipId);
            var isReturned = _book.IsAvailable;
            
            // Assert
            Assert.True(isReturned);
        }

        [Fact]
        public void Should_Change_State_Of_Borrowed_Item_To_IsReturned()
        {
            // Arrange
            _borrowingManager.AddEntryToBorrowedItemsHistory(_book, _normalMember);
            _resourceManager.AddResourceToInventory(_book);
            _membershipManager.AddMembership(_normalMember);
            
            // Act 
            var borrowingHistory = _borrowingManager.GetItemBorrowingHistoryForMember(_book.Id, _normalMember.Id);
            var borrowedItem = borrowingHistory.Last();
            _library.ReturnItem(_book.Id, _normalMember.Id);
            
            // Assert
            Assert.True(borrowedItem.IsReturned);

        }
    }
}