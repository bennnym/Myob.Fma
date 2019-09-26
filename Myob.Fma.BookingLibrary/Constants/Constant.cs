namespace Myob.Fma.BookingLibrary.Constants
{
    public static class Constant
    {
        public const string MembershipNotActive = "Membership is not active";
        public const string ResourceNotAvailable = "Resource is not available";
        public const string ResourceNotInInventory = "Resource is not in library inventory";
        public const string MembersBorrowingLimitExceeded = "Members borrowing limit exceeded";

        public const int GoldBorrowingLimit = 3;
        public const int GoldBorrowingTimeLimitInDays = 10;

        public const int SilverBorrowingLimit = 2;
        public const int SilverBorrowingTimeLimitInDays = 7;

        public const int BronzeBorrowingLimit = 1;
        public const int BronzeBorrowingTimeLimitInDays = 5;
    }
}