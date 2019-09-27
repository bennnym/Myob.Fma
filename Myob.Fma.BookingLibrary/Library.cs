using Myob.Fma.BookingLibrary.BorrowedItemsManagement;
using Myob.Fma.BookingLibrary.MembershipManagement;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.ResourceManagement;
using Myob.Fma.BookingLibrary.Resources;

namespace Myob.Fma.BookingLibrary
{
    public class Library
    {
        private readonly IResourceManager _resourceManager;
        private readonly IMembershipManager _membershipManager;
        private readonly IBorrowingManager _borrowingManager;

        public Library()
        {
            _resourceManager = new ResourceManager();
            _membershipManager = new MembershipManager();
            _borrowingManager = new BorrowingManager();
        }

        public Library(IResourceManager resourceManager,
            IMembershipManager membershipManager, IBorrowingManager borrowingManager)
        {
            _resourceManager = resourceManager;
            _membershipManager = membershipManager;
            _borrowingManager = borrowingManager;
        }

        public static Library CreateLibraryWithPreExistingManagers(IResourceManager resourceManager = null,
            IMembershipManager membershipManager = null, IBorrowingManager borrowingManager = null)
        {
            return new Library(resourceManager, membershipManager, borrowingManager);
        }

        public void ReturnItem(int resourceId, int membershipId)
        {
            _resourceManager.CheckForResourceInInventory(resourceId);
            _membershipManager.CheckMembershipIsActive(membershipId);

            _resourceManager.ReturnResource(resourceId);
            UpdateBorrowedItemReturn(resourceId, membershipId);
        }

        public void BorrowItem(int resourceId, int membershipId)
        {
            _resourceManager.CheckResourceIsAvailableToBorrow(resourceId);
            _membershipManager.CheckMembershipIsActive(membershipId);
            CheckMembersBorrowingLimit(membershipId);

            _resourceManager.CheckoutResource(resourceId);
            CreateBorrowedItem(resourceId, membershipId);
        }

        public void AddResourceToLibrary(IResource resource)
        {
            _resourceManager.AddResourceToInventory(resource);
        }

        public void RemoveResourceFromLibrary(IResource resource)
        {
            _resourceManager.RemoveResourceFromInventory(resource);
        }

        public void AddMember(IMembership membership)
        {
            _membershipManager.AddMembership(membership);
        }

        public void RemoveMembership(IMembership membership)
        {
            _membershipManager.RemoveMembership(membership);
        }
        
        private void UpdateBorrowedItemReturn(int resourceId, int membershipId)
        {
            var resource = _resourceManager.GetResource(resourceId);
            var member = _membershipManager.GetMembership(membershipId);

            _borrowingManager.ReturnItem(resource, member);
        }

        private void CreateBorrowedItem(int resourceId, int membershipId)
        {
            var resource = _resourceManager.GetResource(resourceId);
            var member = _membershipManager.GetMembership(membershipId);

            _borrowingManager.AddEntryToBorrowedItemsHistory(resource, member);
        }

        private void CheckMembersBorrowingLimit(int membershipId)
        {
            var member = _membershipManager.GetMembership(membershipId);

            _borrowingManager.CheckMemberIsUnderBorrowingLimit(member);
        }
    }
}