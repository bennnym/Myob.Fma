using System;
using System.Collections.Generic;
using System.Linq;
using Myob.Fma.BookingLibrary.BorrowingItems;
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

        public void Borrow(int resourceId, int membershipId)
        {
            if (IsResourceAvailable(resourceId) == false) throw new Exception("Resource is not available");
            if (IsMemberActive(membershipId) == false) throw new Exception("Membership is not active");

            var resource = GetResource(resourceId);
            resource.IsAvailable = false;

        }

        private IResource GetResource(int resourceId)
        {
            return _resources.Find(r => r.Id == resourceId);
        }
    }
}