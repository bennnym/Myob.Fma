using System;
using Myob.Fma.BookingLibrary;
using Myob.Fma.BookingLibrary.BorrowedItemsManagement;
using Myob.Fma.BookingLibrary.MembershipManagement;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.MembershipStatus;
using Myob.Fma.BookingLibrary.MembershipStatus.Enums;
using Myob.Fma.BookingLibrary.ResourceManagement;
using Xunit;

namespace Myob.Fma.BookingLibraryTests
{
    public class MembershipTests
    {
        private readonly Membership _member;
        private readonly IBorrowingManager _borrowingManager;
        private readonly IMembershipManager _membershipManager;
        private readonly IResourceManager _resourceManager;

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
            var dueDate = _member.GetDateMemberCanBorrowTill().ToString("dd/mm/yyyy");
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
            var library = new Library(
                _resourceManager,
                _membershipManager,
                _borrowingManager
            );
            // Act
            library.MembershipManager.AddMembership(_member);
            library.MembershipManager.RemoveMembership(_member);

            // Assert
            Assert.Null(_membershipManager.GetMembership(_member.Id));
        }
    }
}