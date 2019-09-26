using System;

namespace Myob.Fma.BookingLibrary.Exceptions
{
    public class ResourceNotInInventoryException : Exception
    {
        public ResourceNotInInventoryException(string message)
            : base(message)
        {
        }
    }
}