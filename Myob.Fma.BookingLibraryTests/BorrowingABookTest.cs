using System;
using System.Collections.Generic;
using Myob.Fma.BookingLibrary;
using Myob.Fma.BookingLibrary.Resources;
using Xunit;

namespace Myob.Fma.BookingLibraryTests
{
    public class BorrowingABookTest
    {
        public BorrowingABookTest()
        {
            
        }
        [Fact]
        public void Should_Check_If_A_Book_Is_Available()
        {
            // Arrange
            var library = new Library(new List<IResource>());

            //Act
            var id = 1;
            var bookIsAvailable = library.IsResourceAvailable(id);
            
            // Assert
            Assert.True(bookIsAvailable);
        }
    }
}