using System;
using Myob.Fma.BookingLibrary.Memberships.MembershipStatus;

namespace Myob.Fma.BookingLibrary.Memberships
{
    public interface IMembership
    {
        int Id { get; set; }
        bool IsActive { get; set; }
        IMembershipStatus MembershipStatus { get; }
        DateTime GetDateMemberCanBorrowTill();
        int GetMembersResourceBorrowingLimit();
        void UpgradeMembershipStatus();
    }
}