using System;
using System.Collections.Generic;
using Myob.Fma.BookingLibrary;
using Myob.Fma.BookingLibrary.Core;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.Resources;
using Xunit;

namespace Myob.Fma.BookingLibraryTests
{
    public class BorrowingABookTest
    {
        [Fact]
        public void Should_Check_If_A_Book_Is_Available()
        {
            // Arrange
            var library = new Library(_resources, _memberships);

            //Act
            var id = 1;
            var bookIsAvailable = library.IsResourceAvailable(id);

            // Assert
            Assert.True(bookIsAvailable);
        }

        [Fact]
        public void Should_Check_If_A_User_Has_A_Active_Membership()
        {
            // Arrange
            var library = new Library(_resources, _memberships);
            
            //Act
            var id = 1;
            var isActiveMembership = library.IsMemberActive(id);
            
            //Assert
            Assert.True(isActiveMembership);
        }

        private readonly List<IResource> _resources = new List<IResource>()
        {
            new Book() {Name = "Harry Potter", Id = 1, ResourceType = ResourceType.Book, IsAvailable = true, Isbn = 1},
            new Book() {Name = "Shakespeare", Id = 2, ResourceType = ResourceType.Book, IsAvailable = true, Isbn = 2},
            new BoardGame() {Name = "Monopoly", Id = 3, ResourceType = ResourceType.BoardGame, IsAvailable = false},
            new BoardGame() {Name = "Snakes and Ladders", Id = 4, ResourceType = ResourceType.BoardGame, IsAvailable = false},
            new Book() {Name = "Clean Code", Id = 5, ResourceType = ResourceType.Book, IsAvailable = false, Isbn = 3},
        };
        
        private readonly List<IMembership> _memberships = new List<IMembership>()
        {
            new Membership(){ BorrowingLimit = 10, IsActive = true, MembershipId = 1, Member = new Person("Ben", "Muller")},
            new Membership(){ BorrowingLimit = 10, IsActive = false, MembershipId = 1, Member = new Person("Sam", "Grunel")},
            new Membership(){ BorrowingLimit = 10, IsActive = false, MembershipId = 1, Member = new Person("Amr", "Reda")},
        };
    }
}