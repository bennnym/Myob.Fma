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
    }
}