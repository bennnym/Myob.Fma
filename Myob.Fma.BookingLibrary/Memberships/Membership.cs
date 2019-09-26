using System;
using Myob.Fma.BookingLibrary.Memberships.MembershipStatus;
using Myob.Fma.BookingLibrary.Memberships.MembershipStatus.Enums;

namespace Myob.Fma.BookingLibrary.Memberships
{
    public class Membership : IMembership
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public IMembershipStatus MembershipStatus { get; set; }

        public DateTime GetMembersDueDateFromNow()
        {
            return DateTime.UtcNow.AddDays(MembershipStatus.BorrowingTimeLimitInDays);
        }

        public int GetMembersResourceBorrowingLimit()
        {
            return MembershipStatus.BorrowingLimit;
        }

        public void UpgradeMembershipStatus()
        {
            MembershipStatus = GetMembershipStatusUpgrade();
        }

        private IMembershipStatus GetMembershipStatusUpgrade()
        {
            switch (MembershipStatus.Status)
            {
                case Status.Bronze:
                    return new SilverMembership();
                case Status.Silver:
                    return new GoldMembership();
                default:
                    return new GoldMembership();
            }
        }
    }
}