using Myob.Fma.BookingLibrary.Constants;
using Myob.Fma.BookingLibrary.Memberships.MembershipStatus.Enums;

namespace Myob.Fma.BookingLibrary.Memberships.MembershipStatus
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