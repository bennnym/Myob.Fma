using Myob.Fma.BookingLibrary.MembershipStatus.Enums;

namespace Myob.Fma.BookingLibrary.MembershipStatus
{
    public interface IMembershipStatus
    {
        Status Status { get; }
        int BorrowingLimit { get; }
        int BorrowingTimeLimitInDays { get; }
    }
}