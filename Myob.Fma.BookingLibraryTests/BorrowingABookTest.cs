using System;
using System.Collections.Generic;
using Myob.Fma.BookingLibrary;
using Myob.Fma.BookingLibrary.BorrowingItems;
using Myob.Fma.BookingLibrary.Core;
using Myob.Fma.BookingLibrary.Exceptions;
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
            var library = new Library(_resources, _memberships, _borrowedItems);

            //Act
            var id = 1;
            var bookIsAvailable = library.IsResourceAvailable(id);

            // Assert
            Assert.True(bookIsAvailable);
        }
        
        [Fact]
        public void Should_Check_If_A_Book_Is_Not_Available()
        {
            // Arrange
            var library = new Library(_resources, _memberships, _borrowedItems);

            //Act
            var id = 3;
            var bookIsAvailable = library.IsResourceAvailable(id);

            // Assert
            Assert.False(bookIsAvailable);
        }

        [Fact]
        public void Should_Check_If_A_Membership_Id_is_Active()
        {
            // Arrange
            var library = new Library(_resources, _memberships, _borrowedItems);
            
            //Act
            var id = 1;
            var isActiveMembership = library.IsMemberActive(id);
            
            //Assert
            Assert.True(isActiveMembership);
        }
        
        [Fact]
        public void Should_Check_If_A_Membership_Id_is_Not_Active()
        {
            // Arrange
            var library = new Library(_resources, _memberships, _borrowedItems);
            
            //Act
            var id = 2;
            var isActiveMembership = library.IsMemberActive(id);
            
            //Assert
            Assert.False(isActiveMembership);
        }

        [Fact]
        public void Should_Check_If_A_Resource_Becomes_Unavailable_After_It_Is_Borrowed()
        {
            // Arrange
            var library = new Library(_resources, _memberships, _borrowedItems);
            const int resourceId = 1;
            const int membershipId = 1;

            // Act
            library.Borrow(resourceId, membershipId);
            var resourceIsAvailable = library.IsResourceAvailable(resourceId);

            // Assert
            Assert.False(resourceIsAvailable);
        }
        
        [Fact(Skip = "refactoring")]
        public void Should_Reduce_Members_Borrowing_Limit_After_Borrowing_A_Resource()
        {
            // Arrange
            var library = new Library(_resources, _memberships, _borrowedItems);
            const int resourceId = 1;
            const int membershipId = 1;
            
            // Act
            library.Borrow(resourceId, membershipId);
//            var borrowingLimit = library.GetMembersBorrowingLimit(membershipId);

            // Assert
//            Assert.Equal(9,borrowingLimit);
        }
        
        [Fact]
        public void Should_Throw_Exception_If_Resource_Is_Not_Available_To_Borrow()
        {
            // Arrange
            var library = new Library(_resources, _memberships, _borrowedItems);
            const int resourceId = 3;
            const int membershipId = 1;

            // Assert
            var exception = Assert.Throws<ResourceNotAvailableException>(() => library.Borrow(resourceId, membershipId));
            Assert.Same("Resource is not available",exception.Message);
        }

        
        [Fact]
        public void Should_Throw_Exception_If_Membership_Id_Is_Not_Active_To_Borrow()
        {
            // Arrange
            var library = new Library(_resources, _memberships, _borrowedItems);
            const int resourceId = 1;
            const int membershipId = 2;

            // Assert
            var exception = Assert.Throws<MembershipNotActiveException>(() => library.Borrow(resourceId, membershipId));
            Assert.Same("Membership is not active",exception.Message);
        }
        
        [Fact]
        public void Should_Throw_Exception_If_Membership_Id_Borrowing_Limit_Is_Exceeded()
        {
            // Arrange
            var library = new Library(_resources, _memberships, _borrowedItems);
            const int resourceId = 1;
            const int membershipId = 3;

            // Assert
            var exception = Assert.Throws<MembersBorrowingLimitExceededException>(() => library.Borrow(resourceId, membershipId));
            Assert.Same("Members borrowing limit exceeded",exception.Message);
        }

        [Fact]
        public void Should_Return_False_When_Member_Is_Over_Limit()
        {
            var library = new Library(_resources, _memberships, _borrowedItems);

            var borrowingLimitIsValid = library.IsMemberUnderBorrowingLimit(1);
            
            // Assert
            Assert.False(borrowingLimitIsValid);
        }

        [Fact]
        public void Should_Have_A_Borrowed_Item_When_Borrowing_A_Resource()
        {
            // Arrange
            var library = new Library(_resources, _memberships, _borrowedItems);

            // Act
            var borrowedItem = library.GetBorrowedItemForMember(membershipId, resourceId);
            
            // Assert
            Assert.NotNull(borrowedItem);
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
            new Membership(){ BorrowingLimit = 2, IsActive = true, MembershipId = 1},
            new Membership(){ BorrowingLimit = 6, IsActive = false, MembershipId = 2},
            new Membership(){ BorrowingLimit = 0, IsActive = true, MembershipId = 3},
        };
        
        private readonly List<IBorrowedItem> _borrowedItems = new List<IBorrowedItem>()
        {
            new BorrowedItem(){ Resource = new Book(), Member = new Membership(){MembershipId = 1}},
            new BorrowedItem(){ Resource = new Book(), Member = new Membership(){MembershipId = 1}},
            new BorrowedItem(){ Resource = new Book(), Member = new Membership(){MembershipId = 1}},
        };
    }
}