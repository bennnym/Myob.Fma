using System.Collections.Generic;
using Myob.Fma.BookingLibrary.Core;

namespace Myob.Fma.BookingLibrary.Memberships
{
    public class  Membership : IMembership
    {
        public Person Member { get; set; }
        public int BorrowingLimit { get; set; }
        public int MembershipId { get; set; }
        public bool IsActive { get; set; }
    }
}