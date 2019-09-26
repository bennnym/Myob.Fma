using System;
using Myob.Fma.BookingLibrary.Memberships.MembershipStatus.Enums;

namespace Myob.Fma.BookingLibrary.Memberships.MembershipStatus
{
    public interface IMembershipStatus
    {
        Status Status { get; }
        int BorrowingLimit { get; }
        int BorrowingTimeLimitInDays { get; }
    }
}