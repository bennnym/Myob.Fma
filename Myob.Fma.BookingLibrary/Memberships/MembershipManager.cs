using System.Collections.Generic;
using System.Linq;
using Myob.Fma.BookingLibrary.Constants;
using Myob.Fma.BookingLibrary.Exceptions;

namespace Myob.Fma.BookingLibrary.Memberships
{
    public class MembershipManager : IMembershipManager
    {
        private readonly List<IMembership> _members = new List<IMembership>();
        
        public bool IsMemberActive(int id)
        {
            return _members.Any(m => m.Id == id && m.IsActive);
        }

        public void AddMembership(IMembership membership)
        {
            membership.IsActive = true;
            _members.Add(membership);
        }

        public void RemoveMembership(IMembership membership)
        {
            _members.Remove(membership);
        }

        public IMembership GetMembership(int membershipId)
        {
            return _members.Find(m => m.Id == membershipId);
        }
        
        public void CheckMembershipIsActive(int membershipId)
        {
            if (IsMemberActive(membershipId) == false)
                throw new MembershipNotActiveException(Constant.MembershipNotActive);
        }
    }
}