using System.Collections.Generic;
using Myob.Fma.BookingLibrary.BorrowingItems;
using Myob.Fma.BookingLibrary.Core;

namespace Myob.Fma.BookingLibrary.Memberships
{
    public interface IMembership
    {
        int BorrowingLimit { get; set; }
        int MembershipId { get; set; }
        bool IsActive { get; set; }

        IEnumerable<IBorrowedItem> GetCurrentBorrowedItems();
    }
}