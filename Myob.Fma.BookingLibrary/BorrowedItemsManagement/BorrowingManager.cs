using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.BookingLibrary.BorrowedItems;
using Myob.Fma.BookingLibrary.Constants;
using Myob.Fma.BookingLibrary.Exceptions;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.Resources;

namespace Myob.Fma.BookingLibrary.BorrowedItemsManagement
{
    public class BorrowingManager : IBorrowingManager
    {
        private readonly List<IBorrowedItem> _borrowedItemsHistory = new List<IBorrowedItem>();

        public void AddEntryToBorrowedItemsHistory(IResource resource, IMembership membership)
        {
            var borrowedItem = CreateBorrowedItem(resource, membership);

            _borrowedItemsHistory.Add(borrowedItem);
        }

        public void ReturnItem(IResource resource, IMembership membership)
        {
            var returnedItem = GetOutstandingBorrowedItem(resource, membership);

            returnedItem.IsReturned = true;
            returnedItem.ReturnedDate = DateTime.UtcNow;
        }

        public IEnumerable<IBorrowedItem> GetItemBorrowingHistoryForMember(int resourceId, int membershipId)
        {
            return _borrowedItemsHistory
                .Where(i =>
                    i.Member.Id == membershipId && i.Resource.Id == resourceId);
        }

        public void CheckMemberIsUnderBorrowingLimit(IMembership membership)
        {
            if ( IsMemberUnderBorrowingLimit(membership) == false)
                throw new MembersBorrowingLimitExceededException(Constant.MembersBorrowingLimitExceeded);
        }

        private IBorrowedItem CreateBorrowedItem(IResource resource, IMembership membership)
        {
            return new BorrowedItem
            {
                Resource = resource,
                Member = membership,
                DueDate = membership.GetDateMemberCanBorrowTill(),
                BorrowedDate = DateTime.UtcNow,
            };
        }

        private int GetNumberOfBorrowedItems(int membershipId)
        {
            return _borrowedItemsHistory.Count(i => i.IsReturned == false && i.Member.Id == membershipId);
        }
        
        private bool IsMemberUnderBorrowingLimit(IMembership membership)
        {
            var currentBorrowedItems = GetNumberOfBorrowedItems(membership.Id);

            return membership.GetMembersResourceBorrowingLimit() > currentBorrowedItems;
        }

        private IBorrowedItem GetOutstandingBorrowedItem(IResource resource, IMembership membership)
        {
            return _borrowedItemsHistory
                .First(i => i.Resource.Id == resource.Id && i.Member.Id == membership.Id && !i.IsReturned);
        }
    }
}