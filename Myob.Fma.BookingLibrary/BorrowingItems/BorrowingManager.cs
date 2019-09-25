using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.Resources;

namespace Myob.Fma.BookingLibrary.BorrowingItems
{
    public class BorrowingManager
    {
        private readonly List<IBorrowedItem> _borrowedItems = new List<IBorrowedItem>();

        public void BorrowItem(IResource resource, IMembership membership, DateTime dueDate)
        {
            var borrowedItem = new BorrowedItem()
            {
                Resource = resource,
                Member = membership,
                DueDate = dueDate,
                BorrowedDate = DateTime.UtcNow,
            };
            
            _borrowedItems.Add(borrowedItem);

        }
        
        public IEnumerable<IBorrowedItem> GetBorrowedItemHistoryForMember(int resourceId, int membershipId)
        {
            return _borrowedItems
                .Where(i =>
                    i.Member.MembershipId == membershipId && i.Resource.Id == resourceId);
        }    }
}