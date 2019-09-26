using Myob.Fma.BookingLibrary.Constants;
using Myob.Fma.BookingLibrary.MembershipStatus.Enums;

namespace Myob.Fma.BookingLibrary.MembershipStatus
{
    public class GoldMembership : IMembershipStatus
    {
        public GoldMembership()
        {
            Status = Status.Gold;
            BorrowingLimit = Constant.GoldBorrowingLimit;
            BorrowingTimeLimitInDays = Constant.GoldBorrowingTimeLimitInDays;
        }

        public Status Status { get; }
        public int BorrowingLimit { get; }
        public int BorrowingTimeLimitInDays { get; }
    }
}