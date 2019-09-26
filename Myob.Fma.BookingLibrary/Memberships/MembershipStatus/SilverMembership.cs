using Myob.Fma.BookingLibrary.Constants;
using Myob.Fma.BookingLibrary.Memberships.MembershipStatus.Enums;

namespace Myob.Fma.BookingLibrary.Memberships.MembershipStatus
{
    public class SilverMembership : IMembershipStatus
    {
        public SilverMembership()
        {
            Status = Status.Silver;
            BorrowingLimit = Constant.SilverBorrowingLimit;
            BorrowingTimeLimitInDays = Constant.SilverBorrowingTimeLimitInDays;
        }

        public Status Status { get; }
        public int BorrowingLimit { get; }
        public int BorrowingTimeLimitInDays { get; }
    }
}