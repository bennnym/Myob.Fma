using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.Resources;

namespace Myob.Fma.BookingLibrary.BorrowingItems
{
    public class BorrowedItem
    {
        public IResource Resource { get; set; }
        public IMembership Member { get; set; }

        public BorrowedItem()
        {
            
        }
    }
}