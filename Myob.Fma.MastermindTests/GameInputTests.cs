using System;
using System.Collections.Generic;
using Moq;
using Myob.Fma.Mastermind;
using Myob.Fma.Mastermind.GameServices.Input;
using Myob.Fma.Mastermind.Infrastructure;
using Xunit;

namespace Myob.Fma.MastermindTests
{
    public class GameInputTests
    {
        [Theory]
        [InlineData("red yellow purple green", new List<Colours>(){Colours.RED, Colours.YELLOW, Colours.PURPLE, Colours.GREEN})]
        public void Should_Return_A_List_Of_Colours_When_Valid_Colours_Are_Entered(string input, List<Colours> expectedoutput)
        {
            var mockConsoleService = new Mock<ConsoleIoService>();
            var inputReader = new GameInput(mockConsoleService.Object);
            mockConsoleService.Setup(i=> i.GetUserInput()).Returns(input);
            

            // Arrange
            var guesses = inputReader.GetUsersCodeGuess();
            
            // Assert
            Assert.Equal(expectedoutput, guesses);
        }
    }
}