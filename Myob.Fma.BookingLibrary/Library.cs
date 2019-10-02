using Myob.Fma.BookingLibrary.BorrowedItemsManagement;
using Myob.Fma.BookingLibrary.MembershipManagement;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.ResourceManagement;
using Myob.Fma.BookingLibrary.Resources;

namespace Myob.Fma.BookingLibrary
{
    public class Library
    {
        public Library()
        {
            ResourceManager = new ResourceManager();
            MembershipManager = new MembershipManager();
            BorrowingManager = new BorrowingManager();
        }

        public Library(IResourceManager resourceManager,
            IMembershipManager membershipManager, IBorrowingManager borrowingManager)
        {
            ResourceManager = resourceManager;
            MembershipManager = membershipManager;
            BorrowingManager = borrowingManager;
        }

        public IResourceManager ResourceManager { get; }
        public IMembershipManager MembershipManager { get; }
        public IBorrowingManager BorrowingManager { get; }

        public void ReturnItem(int resourceId, int membershipId)
        {
            ResourceManager.CheckForResourceInInventory(resourceId);
            MembershipManager.CheckMembershipIsActive(membershipId);

            ResourceManager.ReturnBorrowedResource(resourceId);
            UpdateBorrowedItemReturn(resourceId, membershipId);
        }

        public void BorrowItem(int resourceId, int membershipId)
        {
            ResourceManager.CheckResourceIsAvailableToBorrow(resourceId);
            MembershipManager.CheckMembershipIsActive(membershipId);
            CheckMembersBorrowingLimit(membershipId);

            ResourceManager.CheckoutResource(resourceId);
            CreateBorrowedItem(resourceId, membershipId);
        }

        private void UpdateBorrowedItemReturn(int resourceId, int membershipId)
        {
            var resource = ResourceManager.GetResource(resourceId);
            var member = MembershipManager.GetMembership(membershipId);

            BorrowingManager.ReturnItem(resource, member);
        }

        private void CreateBorrowedItem(int resourceId, int membershipId)
        {
            var resource = ResourceManager.GetResource(resourceId);
            var member = MembershipManager.GetMembership(membershipId);

            BorrowingManager.AddEntryToBorrowedItemsHistory(resource, member);
        }

        private void CheckMembersBorrowingLimit(int membershipId)
        {
            var member = MembershipManager.GetMembership(membershipId);

            BorrowingManager.CheckMemberIsUnderBorrowingLimit(member);
        }
    }
}