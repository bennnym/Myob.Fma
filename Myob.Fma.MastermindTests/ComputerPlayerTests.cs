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
        public void Should_Return_An_Array_Of_Four_Items()
        {
            // Arrange
            var computerPlayer = new FakeComputerPlayer();
            var game = new Game(computerPlayer);
            var usersGuess = new GuessColour[] {GuessColour.RED, GuessColour.RED, GuessColour.RED, GuessColour.RED};

            // Act
            var codeHints = game.Check(usersGuess);


            // Assert
            Assert.Equal(new HintColour[] {HintColour.Black, HintColour.Black, HintColour.Black, HintColour.Black},
                codeHints);
        }

        [Fact]
        public void Should_Return_An_Array_Of_Four_Black_Hints_If_Correct()
        {
            // Arrange
            var computerPlayer = ComputerPlayer.GetPlayer();

            // Act
            var arrayIsFourElementsInSize = computerPlayer.GetCodeSelection().Length == 4;

            // Assert
            Assert.True(arrayIsFourElementsInSize);
        }

        // red red green green

        // vs

        // red yellow blue orange
    }
}