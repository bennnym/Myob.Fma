using System;

namespace Myob.Fma.BookingLibrary.Exceptions
{
    public class MembershipNotActiveException : Exception
    {
        public MembershipNotActiveException(string message)
            : base(message)
        {
            
        }
    }
}