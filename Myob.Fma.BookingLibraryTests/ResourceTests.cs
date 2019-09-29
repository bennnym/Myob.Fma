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
        private readonly Book _book;
        private readonly ResourceManager _resourceManager;
        private readonly MembershipManager _membershipManager;
        private readonly BorrowingManager _borrowingManager;
        private Library _library;

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
            
            _library = new Library(
                _resourceManager,
                _membershipManager,
                _borrowingManager
            );
        }
        [Fact]
        public void Should_Add_A_Resource_To_Inventory()
        {

            // Act
            _library.ResourceManager.AddResourceToInventory(_book);
            var isBookInInventory =_resourceManager.GetResource(_book.Id);
            
            // Assert
            Assert.NotNull(isBookInInventory);
        }
        
        [Fact]
        public void Should_Remove_A_Resource_In_Inventory()
        {

            // Act
            _library.ResourceManager.AddResourceToInventory(_book);
            _library.ResourceManager.RemoveResourceFromInventory(_book);
            var isBookInInventory =_resourceManager.GetResource(_book.Id);
            
            // Assert
            Assert.Null(isBookInInventory);
        }
    }
}