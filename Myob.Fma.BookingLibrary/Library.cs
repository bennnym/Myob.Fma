﻿using System;
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
        private readonly List<IBorrowedItem> _borrowedItems;

        public Library(List<IResource> resources, List<IMembership> memberships, List<IBorrowedItem> borrowedItems)
        {
            _resources = resources;
            _memberships = memberships;
            _borrowedItems = borrowedItems;
        }

        public bool IsResourceAvailable(int id)
        {
            return _resources.Any(r => r.Id == id && r.IsAvailable);
        }

        public bool IsMemberActive(int id)
        {
            return _memberships.Any(m => m.MembershipId == id && m.IsActive);
        }

        public bool IsMemberUnderBorrowingLimit(int membershipId)
        {
            var currentBorrowedItems =
                _borrowedItems.Count(i => i.Member.MembershipId == membershipId && i.IsReturned == false);

            var member = _memberships.Find(m => m.MembershipId == membershipId);

            return member.BorrowingLimit >= currentBorrowedItems;
        }

        public IBorrowedItem GetBorrowedItemForMember(int membershipId, int resourceId)
        {
            return _borrowedItems
                .FirstOrDefault(i => i.Member.MembershipId == membershipId && i.Resource.Id == resourceId && i.IsReturned == false);
        }

        public void Borrow(int resourceId, int membershipId)
        {
            if (IsResourceAvailable(resourceId) == false)
                throw new ResourceNotAvailableException(Constant.ResourceNotAvailable);

            if (IsMemberActive(membershipId) == false)
                throw new MembershipNotActiveException(Constant.MembershipNotActive);

            if (IsMemberUnderBorrowingLimit(membershipId) == false)
                throw new MembersBorrowingLimitExceededException(Constant.MembersBorrowingLimitExceeded);

            CheckoutResource(resourceId);
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
        
    }
}