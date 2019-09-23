using System;
using System.Collections.Generic;
using Moq;
using Myob.Fma.Mastermind;
using Myob.Fma.Mastermind.GameServices.Input;
using Myob.Fma.Mastermind.Infrastructure;
using Myob.Fma.Mastermind.Utilities;
using Xunit;

namespace Myob.Fma.MastermindTests
{
    public class GameInputTests
    {

        [Theory]
        [InlineData("red yellow blue, orange")]
        [InlineData("red,red,blue,orange")]
        [InlineData("red,   red,blue//orange")]
        public void Should_Return_True_If_The_User_Has_Entered_Four_Words(string input)
        {
            // Arrange
            var patternValidator = new PatternValidator();
            
            // Act
            var userHasEnteredFourColours =
                patternValidator.IsUsersInputValid(input, out string message);
            
            // Assert
            Assert.True(userHasEnteredFourColours);
        }
        
        [Theory]
        [InlineData("red blue, orange")]
        [InlineData("redred,blue,orange")]
        [InlineData("red")]
        public void Should_Return_False_If_The_User_Has_Entered_Less_Than_Four_Words(string input)
        {
            // Arrange
            var patternValidator = new PatternValidator();
            
            // Act
            var userHasEnteredFourColours =
                patternValidator.IsUsersInputValid(input, out string message);
            
            // Assert
            Assert.False(userHasEnteredFourColours);
        }

        [Theory]
        [InlineData("red orange, orange orange")]
        [InlineData("red red,blue,orange")]
        [InlineData("purple blue green yellow")]
        public void Should_Return_True_When_User_Has_Entered_Valid_Colours(string input)
        {
            // Arrange
            var patternValidator = new PatternValidator();
            
            // Act
            var coloursValid = patternValidator.IsUsersInputValid(input, out string message);
            
            // Assert
            Assert.True(coloursValid);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_Return_A_List_Of_Colours_When_Valid_Colours_Are_Entered(string userInput,
            List<Colours> expectedOutput)
        {
            // Arrange
            var mockConsoleService = new Mock<ConsoleIoService>();
            var patternService = new Mock<PatternValidator>();
            var inputReader = new GameInput(mockConsoleService.Object, patternService.Object);
            mockConsoleService.Setup(i => i.GetUserInput()).Returns(userInput);


            // Act
            var guesses = inputReader.GetUsersCodeGuess();

            // Assert
            Assert.Equal(expectedOutput, guesses);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    "red yellow purple green",
                    new List<Colours>() {Colours.RED, Colours.YELLOW, Colours.PURPLE, Colours.GREEN}
                },
                new object[]
                {
                    "red red red red",
                    new List<Colours>() {Colours.RED, Colours.RED, Colours.RED, Colours.RED}
                },
                new object[]
                {
                    "red yellow blue green",
                    new List<Colours>() {Colours.RED, Colours.YELLOW, Colours.BLUE, Colours.GREEN}
                },
            };
    }
}