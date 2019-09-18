using System;
using System.Collections.Generic;
using Myob.Fma.BookingLibrary;
using Myob.Fma.BookingLibrary.Memberships;
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
        public void Should_Check_If_A_Book_Is_Not_Available()
        {
            // Arrange
            var library = new Library(new List<IResource>(), new List<IMembership>());

            //Act
            var id = 1;
            var bookIsAvailable = library.IsResourceAvailable(id);

            // Assert
            Assert.False(bookIsAvailable);
        }

        [Fact]
        public void Should_Check_If_A_User_Has_A_Active_Membership()
        {
            // Arrange
            var library = new Library(new List<IResource>(), new List<IMembership>());

            //Act
            var id = 1;
            var isActiveMembership = library.IsMemberActive(id);
            
            //Assert
            Assert.False(isActiveMembership);
        }
    }
}