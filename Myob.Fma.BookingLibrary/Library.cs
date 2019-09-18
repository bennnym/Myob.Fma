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
        private readonly List<IResource> _resources;
        private readonly List<IMembership> _memberships;

        public Library(List<IResource> resources, List<IMembership> memberships)
        {
            _resources = resources;
            _memberships = memberships;
        }

        public bool IsResourceAvailable(int id)
        {
            return _resources.Any(r => r.Id == id && r.IsAvailable);
        }

        public bool IsMemberActive(int id)
        {
            return _memberships.Any(m => m.MembershipId == id && m.IsActive);
        }

        public int GetMembersBorrowingLimit(int membershipId)
        {
            return _memberships.Find(m => m.MembershipId == membershipId).BorrowingLimit;
        }

        public void Borrow(int resourceId, int membershipId)
        {
            if (IsResourceAvailable(resourceId) == false) 
                throw new ResourceNotAvailableException(Constant.ResourceNotAvailable);
            
            if (IsMemberActive(membershipId) == false) 
                throw new MembershipNotActiveException(Constant.MembershipNotActive);
            
            if (GetMembersBorrowingLimit(membershipId) < 1) 
                throw new MembersBorrowingLimitExceededException(Constant.MembersBorrowingLimitExceeded);

            CheckoutResource(resourceId);
            ReduceMembersBorrowingLimit(membershipId);

        }
        private IResource GetResource(int resourceId)
        {
            return _resources.Find(r => r.Id == resourceId);
        }

        private void CheckoutResource(int resourceId)
        {
            var resource = GetResource(resourceId);
            resource.IsAvailable = false;
        }

        private void ReduceMembersBorrowingLimit(int membershipId)
        {
            var membership = _memberships.Find(m => m.MembershipId == membershipId);
            membership.BorrowingLimit--;
        }
    }
}