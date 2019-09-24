using Myob.Fma.Mastermind;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Players;
using Xunit;

namespace Myob.Fma.MastermindTests
{
    public class GameTests
    {
        [Fact]
        public void Should_Return_An_Array_When_A_Guess_Is_Made()
        {
            // Arrange
            var game = new Game(ComputerPlayer.GetPlayer());
            
            // Act
            var correctGuess = game.Check(new GuessColour[]
                {GuessColour.RED, GuessColour.RED, GuessColour.RED, GuessColour.RED});
            
            // Assert
            Assert.Equal(new HintColour[]{HintColour.Black, HintColour.Black, HintColour.Black, HintColour.Black}, correctGuess);
        }
        
        // red red orange orange
        
        // vs
        
        // orange green red blue 
    }
}