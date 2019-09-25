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
        private ResourceManager _resourceManager = new ResourceManager();
        private MembershipManager _membershipManager = new MembershipManager();
        private BorrowingManager _borrowingManager = new BorrowingManager();

        public static Library CreateLibraryWithResourceManager(ResourceManager resourceManager)
        {
            return new Library
            {
                _resourceManager = resourceManager,
            };
        }

        public static Library CreateLibraryWithMembershipManager(MembershipManager membershipManager)
        {
            return new Library
            {
                _membershipManager = membershipManager
            };
        }

        public static Library CreateLibraryWithAllManagers(ResourceManager resourceManager,
            MembershipManager membershipManager, BorrowingManager borrowingManager)
        {
            return new Library
            {
                _resourceManager = resourceManager,
                _membershipManager = membershipManager,
                _borrowingManager = borrowingManager
            };
        }

        public void ReturnItem(int resourceId, int membershipId)
        {
        }

        public void BorrowItem(int resourceId, int membershipId)
        {
            if (_resourceManager.IsResourceAvailable(resourceId) == false)
                throw new ResourceNotAvailableException(Constant.ResourceNotAvailable);

            if (_membershipManager.IsMemberActive(membershipId) == false)
                throw new MembershipNotActiveException(Constant.MembershipNotActive);

            if (_membershipManager.IsMemberUnderBorrowingLimit(membershipId) == false)
                throw new MembersBorrowingLimitExceededException(Constant.MembersBorrowingLimitExceeded);

            _resourceManager.CheckoutResource(resourceId);
            CreateBorrowedItem(resourceId, membershipId, DateTime.UtcNow.AddDays(7)); //TODO: Refactor the duedate
        }

        private void CreateBorrowedItem(int resourceId, int membershipId, DateTime dueDate)
        {
            var resource = _resourceManager.GetResource(resourceId);
            var member = _membershipManager.GetMembership(membershipId);
            _borrowingManager.BorrowItem(resource, member, dueDate);
        }
    }
}