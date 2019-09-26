using Myob.Fma.BookingLibrary.MembershipManagment;
using Myob.Fma.BookingLibrary.Memberships;
using Xunit;

namespace Myob.Fma.BookingLibraryTests
{
    public class MembershipManagerTests
    {
        private readonly IMembership _member;
        private readonly MembershipManager _membershipManager;

        public MembershipManagerTests()
        {
            _member = new Membership()
            {
                Id = 1,
                IsActive = true
            };

            _membershipManager = new MembershipManager();
        }

        [Fact]
        public void Should_Return_False_When_When_Member_Is_Not_Active()
        {
            // Arrange
            var id = 1;
            
            //Act
            var isActiveMembership = _membershipManager.IsMemberActive(id);

            //Assert
            Assert.False(isActiveMembership);
        }
        
        [Fact]
        public void Should_Return_True_When_When_Member_Is_Active()
        {
            // Arrange
            var id = 1;
            
            //Act
            _membershipManager.AddMembership(_member);
            var isActiveMembership = _membershipManager.IsMemberActive(id);

            //Assert
            Assert.True(isActiveMembership);
        }
    }
}