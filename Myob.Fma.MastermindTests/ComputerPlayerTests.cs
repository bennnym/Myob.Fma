using System.Linq;
using Myob.Fma.Mastermind;
using Myob.Fma.Mastermind.GameServices.Players;
using Xunit;

namespace Myob.Fma.MastermindTests
{
    public class ComputerPlayerTests
    {
        [Fact]
        public void Should_Return_An_Array_Of_Four_Items()
        {
            // Arrange
            var computerPlayer = ComputerPlayer.GetPlayer(); 
            
            // Act
            var arrayIsFourElementsInSize = computerPlayer.GetCodeSelection().Length == 4; // check all are colours
            
            // Assert
            Assert.True(arrayIsFourElementsInSize);
        }

        [Fact]
        public void Should_Return_A_Dictionary_With_Occurances_And_Indexes()
        {
            
        }
    }
}