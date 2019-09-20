using System;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.Resources;

namespace Myob.Fma.BookingLibrary.BorrowingItems
{
    public class BorrowedItem : IBorrowedItem
    {
        public IResource Resource { get; set; }
        public IMembership Member { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public bool IsReturned { get; set; }
    }
}