using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.BookingLibrary.BorrowingItems;
using Myob.Fma.BookingLibrary.Constants;
using Myob.Fma.BookingLibrary.Exceptions;
using Myob.Fma.BookingLibrary.Memberships;
using Myob.Fma.BookingLibrary.Resources;

namespace Myob.Fma.BookingLibrary
{
    public class Library
    {
        private IResourceManager _resourceManager = new ResourceManager();
        private IMembershipManager _membershipManager = new MembershipManager();
        private IBorrowingManager _borrowingManager = new BorrowingManager();

        public static Library CreateLibraryWithPreExistingManagers(IResourceManager resourceManager = null,
            IMembershipManager membershipManager = null, IBorrowingManager borrowingManager = null)
        {
            return new Library
            {
                _resourceManager = resourceManager ?? new ResourceManager(),
                _membershipManager = membershipManager ?? new MembershipManager(),
                _borrowingManager = borrowingManager ?? new BorrowingManager()
            };
        }

        public void ReturnItem(int resourceId, int membershipId)
        {
            CheckForResourceInInventory(resourceId);
            CheckMembershipIsActive(membershipId);

            _resourceManager.ReturnResource(resourceId);
            UpdateBorrowedItemReturn(resourceId, membershipId);
        }

        public void BorrowItem(int resourceId, int membershipId)
        {
            CheckResourceIsAvailableToBorrow(resourceId);
            CheckMembershipIsActive(membershipId);
            CheckMemberIsUnderBorrowingLimit(membershipId);

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

        public void SignUpMember(IMembership membership)
        {
            _membershipManager.AddMembership(membership);
        }

        public void CancelMembership(IMembership membership)
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

            _borrowingManager.BorrowItem(resource, member);
        }

        private void CheckForResourceInInventory(int resourceId)
        {
            if (_resourceManager.IsResourceInInventory(resourceId) == false)
                throw new ResourceNotInInventoryException(Constant.ResourceNotInInventory);
        }

        private void CheckMembershipIsActive(int membershipId)
        {
            if (_membershipManager.IsMemberActive(membershipId) == false)
                throw new MembershipNotActiveException(Constant.MembershipNotActive);
        }

        private void CheckResourceIsAvailableToBorrow(int resourceId)
        {
            if (_resourceManager.IsResourceAvailableToBorrow(resourceId) == false)
                throw new ResourceNotAvailableToBorrowException(Constant.ResourceNotAvailable);
        }

        private void CheckMemberIsUnderBorrowingLimit(int membershipId)
        {
            var member = _membershipManager.GetMembership(membershipId);

            if (_borrowingManager.IsMemberUnderBorrowingLimit(member) == false)
                throw new MembersBorrowingLimitExceededException(Constant.MembersBorrowingLimitExceeded);
        }
    }
}