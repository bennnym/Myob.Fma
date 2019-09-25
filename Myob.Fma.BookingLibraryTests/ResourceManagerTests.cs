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
        public void Should_Return_False_When_No_Resources_Are_In_The_Inventory()
        {
            // Arrange
            var id = 1;

            //Act
            var bookIsAvailable = _resourceManager.IsResourceAvailable(id);

            // Assert
            Assert.False(bookIsAvailable);
        }

        [Fact]
        public void Should_Return_True_When_A_Resource_Is_Added_To_The_Inventory()
        {
            // Arrange
            var id = 1;

            
            //Act
            _resourceManager.AddResourceToInventory(_book);
            var bookIsAvailable = _resourceManager.IsResourceAvailable(id);

            // Assert
            Assert.True(bookIsAvailable);
        }
    }
}