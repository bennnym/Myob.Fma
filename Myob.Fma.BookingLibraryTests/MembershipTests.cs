using System;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.Memberships.MembershipStatus;
using Myob.Fma.BookingLibrary.Memberships.MembershipStatus.Enums;
using Xunit;

namespace Myob.Fma.BookingLibraryTests
{
    public class MembershipTests
    {
        private readonly Membership _member;

        public MembershipTests()
        {
            _member = new Membership()
            {
                MembershipStatus = new SilverMembership()
            };
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
            Assert.Equal(Status.Gold,_member.MembershipStatus.Status);
            
        }
    }
}