using System;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.Resources;

namespace Myob.Fma.BookingLibrary.BorrowedItems
{
    public interface IBorrowedItem
    {
        IResource Resource { get; set; }
        IMembership Member { get; set; }
        DateTime DueDate { get; set; }
        DateTime BorrowedDate { get; set; }
        DateTime? ReturnedDate { get; set; }
        bool IsReturned { get; set; }
    }
}