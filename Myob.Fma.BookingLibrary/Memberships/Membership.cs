using System.Collections.Generic;
using System.Linq;
using Myob.Fma.BookingLibrary.BorrowingItems;

namespace Myob.Fma.BookingLibrary.Memberships
{
    public class  Membership : IMembership
    {
        private readonly List<IBorrowedItem> _borrowingHistory = new List<IBorrowedItem>(); 
        public int BorrowingLimit { get; set; }
        public int MembershipId { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<IBorrowedItem> GetCurrentBorrowedItems()
        {
           return _borrowingHistory.Where(i => i.IsReturned == false);
        }
        
    }
}