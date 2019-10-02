using System;

namespace Myob.Fma.BookingLibrary.Exceptions
{
    public class MembersBorrowingLimitExceededException : Exception
    {
        public MembersBorrowingLimitExceededException(string message)
            : base(message)
        {
            
        }
    }
}