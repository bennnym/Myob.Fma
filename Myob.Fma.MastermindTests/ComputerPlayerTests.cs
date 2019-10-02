using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Mastermind;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Players;
using Myob.Fma.MastermindTests.Fakes;
using Xunit;

namespace Myob.Fma.MastermindTests
{
    public class ComputerPlayerTests
    {
        [Fact]
        public void Should_Contain_A_Code_With_Four_Elements_When_Computer_Player_Is_Created()
        {
            // Arrange
            var computerPlayer = new ComputerPlayer();

            // Act
            var arrayIsFourElementsInSize = computerPlayer.GetCodeSelection().Length == 4;

            // Assert
            Assert.True(arrayIsFourElementsInSize);
        }

    }
}