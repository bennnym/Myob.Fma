using System;
using Myob.Fma.BookingLibrary;
using Myob.Fma.BookingLibrary.BorrowedItemsManagement;
using Myob.Fma.BookingLibrary.MembershipManagement;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.ResourceManagement;
using Myob.Fma.BookingLibrary.Resources;
using Xunit;

namespace Myob.Fma.BookingLibraryTests
{
    public class ResourceTests
    {
        private Book _book;
        private ResourceManager _resourceManager;
        private MembershipManager _membershipManager;
        private BorrowingManager _borrowingManager;

        public ResourceTests()
        {
            _book = new Book()
            {
                Id = 1,
                IsAvailable = true
            };

            _resourceManager = new ResourceManager();
            _membershipManager = new MembershipManager();
            _borrowingManager = new BorrowingManager();
        }
        [Fact]
        public void Should_Add_A_Resource_To_Inventory()
        {
            // Arrange
            var library =
                Library.CreateLibraryWithPreExistingManagers(_resourceManager, _membershipManager, _borrowingManager);
            
            // Act
            library.AddResourceToLibrary(_book);
            var isBookInInventory =_resourceManager.GetResource(_book.Id);
            
            // Assert
            Assert.NotNull(isBookInInventory);
        }
        
        [Fact]
        public void Should_Remove_A_Resource_In_Inventory()
        {
            // Arrange
            var library =
                Library.CreateLibraryWithPreExistingManagers(_resourceManager, _membershipManager, _borrowingManager);
            
            // Act
            library.AddResourceToLibrary(_book);
            library.RemoveResourceFromLibrary(_book);
            var isBookInInventory =_resourceManager.GetResource(_book.Id);
            
            // Assert
            Assert.Null(isBookInInventory);
        }
    }
}