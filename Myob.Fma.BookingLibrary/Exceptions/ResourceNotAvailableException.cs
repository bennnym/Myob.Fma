using System;

namespace Myob.Fma.BookingLibrary.Exceptions
{
    public class ResourceNotAvailableException : Exception
    {
        public ResourceNotAvailableException(string message)
            : base(message)
        {
            
        }
    }
}