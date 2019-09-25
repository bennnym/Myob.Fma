using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.BookingLibrary.Memberships
{
    public class MembershipManager
    {
        private readonly List<IMembership> _members = new List<IMembership>();
        
        public bool IsMemberActive(int id)
        {
            return _members.Any(m => m.MembershipId == id && m.IsActive);
        }

        public void AddMembership(IMembership membership)
        {
            _members.Add(membership);
        }

        public void RemoveMembership(IMembership membership)
        {
            _members.Remove(membership);
        }
        
        public bool IsMemberUnderBorrowingLimit(int membershipId)
        {
            var member = GetMembership(membershipId);
            var currentBorrowedItems =   member.GetCurrentBorrowedItems().Count();
            
            return member.BorrowingLimit > currentBorrowedItems;
        }
        
        public IMembership GetMembership(int membershipId)
        {
            return _members.Find(m => m.MembershipId == membershipId);
        }
    }
}