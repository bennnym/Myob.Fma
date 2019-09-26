using System.Collections.Generic;
using Myob.Fma.BookingLibrary.BorrowedItems;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.Resources;

namespace Myob.Fma.BookingLibrary.BorrowedItemsManagment
{
    public interface IBorrowingManager
    {
        void BorrowItem(IResource resource, IMembership membership);
        void ReturnItem(IResource resource, IMembership membership);
        IEnumerable<IBorrowedItem> GetItemBorrowingHistoryForMember(int resourceId, int membershipId);
        void CheckMemberIsUnderBorrowingLimit(IMembership membership);
    }
}