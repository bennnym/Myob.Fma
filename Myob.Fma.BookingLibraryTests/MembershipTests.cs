using System;
using Myob.Fma.BookingLibrary;
using Myob.Fma.BookingLibrary.BorrowingItems;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.Memberships.MembershipStatus;
using Myob.Fma.BookingLibrary.Memberships.MembershipStatus.Enums;
using Myob.Fma.BookingLibrary.Resources;
using Xunit;
using Xunit.Sdk;

namespace Myob.Fma.BookingLibraryTests
{
    public class MembershipTests
    {
        private readonly Membership _member;
        private IBorrowingManager _borrowingManager;
        private IMembershipManager _membershipManager;
        private IResourceManager _resourceManager;

        public MembershipTests()
        {
            _member = new Membership()
            {
                MembershipStatus = new SilverMembership()
            };
            
            _resourceManager = new ResourceManager();
            _membershipManager = new MembershipManager();
            _borrowingManager = new BorrowingManager();
        }

        [Fact]
        public void Should_Return_DateTime_Adjusted_For_Membership_Status()
        {
            // Act
            var dueDate = _member.GetMembersDueDateFromNow().ToString("dd/mm/yyyy");
            var timeSevenDaysFromNow = DateTime.UtcNow.AddDays(7).ToString("dd/mm/yyyy");

            // Assert
            Assert.Equal(timeSevenDaysFromNow, dueDate);
        }

        [Fact]
        public void Should_Upgrade_Members_Status()
        {
            // Act
            _member.UpgradeMembershipStatus();

            // Assert
            Assert.Equal(Status.Gold, _member.MembershipStatus.Status);
        }

        [Fact]
        public void Should_Remove_Member_From_Members_List()
        {
            // Arrange
            var library = Library.CreateLibraryWithPreExistingManagers(_resourceManager, _membershipManager, _borrowingManager);
            // Act
            _membershipManager.AddMembership(_member);
            library.CancelMembership(_member);

            // Assert
            Assert.Null(_membershipManager.GetMembership(_member.Id));
        }
    }
}