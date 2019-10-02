using Myob.Fma.BookingLibrary.Exceptions;
using Myob.Fma.BookingLibrary.ResourceManagement;
using Myob.Fma.BookingLibrary.Resources;
using Xunit;

namespace Myob.Fma.BookingLibraryTests
{
    public class ResourceManagerTests
    {
        private readonly IResource _book;
        private readonly ResourceManager _resourceManager;
        public ResourceManagerTests()
        {
             _book = new Book()
            {
                Id = 1,
                IsAvailable = true,
                ResourceType = ResourceType.Book
            };

            _resourceManager = new ResourceManager();
        }
        
        [Fact]
        public void Should_Throw_CheckResourceIsAvailableToBorrow_Exception_When_Resource_Is_Not_In_Inventory()
        {
            // Arrange
            var id = 1;
            
            // Assert
            Assert.Throws<ResourceNotAvailableToBorrowException>(() =>
                _resourceManager.CheckResourceIsAvailableToBorrow(id));
        }
    }
}