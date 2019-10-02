using Myob.Fma.BookingLibrary.Constants;
using Myob.Fma.BookingLibrary.MembershipStatus.Enums;

namespace Myob.Fma.BookingLibrary.MembershipStatus
{
    public class BronzeMembership : IMembershipStatus
    {
        public BronzeMembership()
        {
            Status = Status.Bronze;
            BorrowingLimit = Constant.BronzeBorrowingLimit;
            BorrowingTimeLimitInDays = Constant.BronzeBorrowingTimeLimitInDays;
        }
        public Status Status { get; }
        public int BorrowingLimit { get; }
        public int BorrowingTimeLimitInDays { get; }
    }
}