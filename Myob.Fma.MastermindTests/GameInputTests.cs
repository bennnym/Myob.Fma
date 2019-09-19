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
//        [Fact]
//        public void Should_Return_A_List_Of_Colours_When_Valid_Colours_Are_Entered()
//        {
//            var mockConsoleService = new Mock<ConsoleIoService>();
//            var inputReader = new GameInput(mockConsoleService.Object);
//            mockConsoleService.Setup(i => i.GetUserInput()).Returns("red yellow purple green");
//
//
//            // Arrange
//            var guesses = inputReader.GetUsersCodeGuess();
//
//            // Assert
//            Assert.Equal(new List<Colours>() {Colours.RED, Colours.YELLOW, Colours.PURPLE, Colours.GREEN}, guesses);
//        }
        
//        [Theory]
//        [InlineData("red yellow purple green", new List<Colours>(){Colours.RED, Colours.YELLOW, Colours.PURPLE, Colours.GREEN})]
//        public void Should_Return_A_List_Of_Colours_When_Valid_Colours_Are_Entered(string userInput, List<Colours> expectedOutput)
//        {
//            var mockConsoleService = new Mock<ConsoleIoService>();
//            var inputReader = new GameInput(mockConsoleService.Object);
//            mockConsoleService.Setup(i => i.GetUserInput()).Returns(userInput);
//
//
//            // Arrange
//            var guesses = inputReader.GetUsersCodeGuess();
//
//            // Assert
//            Assert.Equal(expectedOutput, guesses);
//        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should(string userInput, List<Colours> expectedOutput)
        {
            // Arrange
            var mockConsoleService = new Mock<ConsoleIoService>();
            var inputReader = new GameInput(mockConsoleService.Object);
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