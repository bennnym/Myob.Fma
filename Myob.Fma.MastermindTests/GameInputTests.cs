using System;
using System.Collections.Generic;
using Moq;
using Myob.Fma.Mastermind;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Input;
using Myob.Fma.Mastermind.GameServices.Input.Processor;
using Myob.Fma.Mastermind.GameServices.Input.Validations;
using Myob.Fma.Mastermind.GameServices.Input.Validator;
using Myob.Fma.Mastermind.Infrastructure;
using Myob.Fma.MastermindTests.Fakes;
using Xunit;

namespace Myob.Fma.MastermindTests
{
    public class GameInputTests
    {
        private readonly IInputValidator _inputValidatorWordLength;
        private readonly InputValidator _inputValidator;

        public GameInputTests()
        {
            _inputValidatorWordLength = new InputValidator(
                new List<IValidation>()
                {
                    new WordCountValidation()
                });


            _inputValidator = new InputValidator(
                new List<IValidation>()
                {
                    new WordCountValidation(),
                    new ColourValidation(),
                    new GuessLimitValidation()
                });
        }

        [Theory]
        [InlineData("red yellow blue, orange")]
        [InlineData("red,red,blue,orange")]
        [InlineData("red,   red,blue//orange")]
        public void Should_Return_True_If_The_User_Has_Entered_Four_Words(string input)
        {
            // Act
            var userHasEnteredFourColours =
                _inputValidatorWordLength.IsUsersInputValid(input, out string message);

            // Assert
            Assert.True(userHasEnteredFourColours);
        }

        [Theory]
        [InlineData("red blue, orange")]
        [InlineData("redred,blue,orange")]
        [InlineData("red")]
        public void Should_Return_False_If_The_User_Has_Entered_Less_Than_Four_Words(string input)
        {
            // Act
            var userHasEnteredFourColours =
                _inputValidatorWordLength.IsUsersInputValid(input, out string message);

            // Assert
            Assert.False(userHasEnteredFourColours);
        }

        [Fact]
        public void Should_Return_False_If_The_User_Has_Made_60_Guesses()
        {
            // Arrange
            var inputValidatorGuessCount = new InputValidator(
                new List<IValidation>()
                {
                    new FakeGuessLimitValidation()
                });

            // Act
            var userHasMadeLessThanSixtyGuesses =
                inputValidatorGuessCount.IsUsersInputValid("red red red red", out string message);

            // Assert
            Assert.False(userHasMadeLessThanSixtyGuesses);
        }

        [Theory]
        [InlineData("red orange, orange orange")]
        [InlineData("red red,blue,orange")]
        [InlineData("purple blue green yellow")]
        public void Should_Return_True_When_User_Has_Entered_Valid_Colours(string input)
        {
            var inputValidatorColor = new InputValidator(
                new List<IValidation>()
                {
                    new ColourValidation(),
                });

            // Act
            var coloursValid = inputValidatorColor.IsUsersInputValid(input, out string message);

            // Assert
            Assert.True(coloursValid);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Should_Return_A_List_Of_Colours_When_Valid_Colours_Are_Entered(string userInput,
            List<GuessColour> expectedOutput)
        {
            // Arrange
            var mockConsoleService = new Mock<ConsoleIoService>();
            var inputReader = new InputProcessor(mockConsoleService.Object, _inputValidator);
            mockConsoleService.Setup(i => i.GetUserInput()).Returns(userInput);


            // Act
            var guesses = inputReader.GetUsersInput();

            // Assert
            Assert.Equal(expectedOutput, guesses);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    "red yellow purple green",
                    new List<GuessColour>() {GuessColour.RED, GuessColour.YELLOW, GuessColour.PURPLE, GuessColour.GREEN}
                },
                new object[]
                {
                    "red red red red",
                    new List<GuessColour>() {GuessColour.RED, GuessColour.RED, GuessColour.RED, GuessColour.RED}
                },
                new object[]
                {
                    "red yellow blue green",
                    new List<GuessColour>() {GuessColour.RED, GuessColour.YELLOW, GuessColour.BLUE, GuessColour.GREEN}
                },
            };
    }
}