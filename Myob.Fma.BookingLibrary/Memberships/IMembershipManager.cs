namespace Myob.Fma.BookingLibrary.Memberships
{
    public interface IMembershipManager
    {
        bool IsMemberActive(int id);
        void AddMembership(IMembership membership);
        void RemoveMembership(IMembership membership);
        IMembership GetMembership(int membershipId);
        void CheckMembershipIsActive(int membershipId);
    }
}