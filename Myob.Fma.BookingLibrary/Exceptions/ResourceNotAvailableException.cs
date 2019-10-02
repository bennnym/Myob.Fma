using System;

namespace Myob.Fma.BookingLibrary.Exceptions
{
    public class ResourceNotAvailableToBorrowException : Exception
    {
        public ResourceNotAvailableToBorrowException(string message)
            : base(message)
        {
            
        }
    }
}