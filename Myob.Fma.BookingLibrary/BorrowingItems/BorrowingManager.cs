using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.Resources;

namespace Myob.Fma.BookingLibrary.BorrowingItems
{
    public class BorrowingManager : IBorrowingManager
    {
        private readonly List<IBorrowedItem> _borrowedItems = new List<IBorrowedItem>();

        public void BorrowItem(IResource resource, IMembership membership)
        {
            var borrowedItem = new BorrowedItem()
            {
                Resource = resource,
                Member = membership,
                DueDate = membership.GetMembersDueDateFromNow(),
                BorrowedDate = DateTime.UtcNow,
            };

            _borrowedItems.Add(borrowedItem);
        }

        public void ReturnItem(IResource resource, IMembership membership)
        {
            var returnedItem =
                _borrowedItems.First(i => i.Resource.Id == resource.Id && i.Member.Id == membership.Id && !i.IsReturned);

            returnedItem.IsReturned = true;
            returnedItem.ReturnedDate = DateTime.UtcNow;


        }

        public bool IsMemberUnderBorrowingLimit(IMembership membership)
        {
            var currentBorrowedItems = _borrowedItems.Count(i => i.IsReturned == false && i.Member.Id == membership.Id);

            return membership.GetMembersResourceBorrowingLimit() > currentBorrowedItems;
        }

        public IEnumerable<IBorrowedItem> GetItemBorrowingHistoryForMember(int resourceId, int membershipId)
        {
            return _borrowedItems
                .Where(i =>
                    i.Member.Id == membershipId && i.Resource.Id == resourceId);
        }
    }
}