using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using Myob.Fma.Mastermind;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Players;
using Myob.Fma.MastermindTests.Fakes;
using Xunit;

namespace Myob.Fma.MastermindTests
{
    public class GameTests
    {

        [Fact]
        public void Should_Return_An_Empty_Array_When_No_Matches_Are_Found()
        {
            // Arrange
            var computerPlayer = new Mock<ComputerPlayer>();
            var game = new Game(computerPlayer.Object);

            // Act
            computerPlayer.Setup(i => i.GetCodeSelection()).Returns(new[]
                {GuessColour.RED, GuessColour.RED, GuessColour.RED, GuessColour.RED});
            var hints = game.Check(new[] {GuessColour.BLUE, GuessColour.BLUE, GuessColour.BLUE, GuessColour.BLUE});

            // Assert
            Assert.Empty(hints);
        }

        [Theory]
        [MemberData(nameof(ExactMatches))]
        public void Should_Return_Amount_Of_Black_Hints_Related_To_Exact_Matches(GuessColour[] computerGuess,
            GuessColour[] playerGuess, HintColour[] expectedHint)
        {
            // Arrange
            var computerPlayer = new Mock<ComputerPlayer>();
            var game = new Game(computerPlayer.Object);

            // Act
            computerPlayer.Setup(i => i.GetCodeSelection()).Returns(computerGuess);
            var hints = game.Check(playerGuess);

            // Assert
            Assert.Equal(expectedHint, hints);
        }

        [Theory]
        [MemberData(nameof(NonExactMatches))]
        public void Should_Return_Amount_Of_White_Hints_Related_To_Non_Exact_Matches(GuessColour[] computerGuess,
            GuessColour[] playerGuess, HintColour[] expectedHint)
        {
            // Arrange
            var computerPlayer = new Mock<ComputerPlayer>();
            var game = new Game(computerPlayer.Object);

            // Act
            computerPlayer.Setup(i => i.GetCodeSelection()).Returns(computerGuess);
            var hints = game.Check(playerGuess);

            // Assert
            Assert.Equal(expectedHint, hints);
        }

        [Theory]
        [MemberData(nameof(MixOfMatches))]
        public void Should_Return_Amount_Of_Black_And_White_Hints_According_To_Matches(GuessColour[] computerGuess,
            GuessColour[] playerGuess, int expectedBlackHints, int expectedWhiteHints)
        {
            // Arrange
            var computerPlayer = new Mock<ComputerPlayer>();
            var game = new Game(computerPlayer.Object);

            // Act
            computerPlayer.Setup(i => i.GetCodeSelection()).Returns(computerGuess);
            var hints = game.Check(playerGuess);
            var numberOfBlackHints = hints.Count(g => g == HintColour.Black);
            var numberOfWhiteHints = hints.Count(g => g == HintColour.White);

            // Assert
            Assert.Equal(expectedBlackHints, numberOfBlackHints);
            Assert.Equal(expectedWhiteHints, numberOfWhiteHints);
        }

        public static IEnumerable<object[]> ExactMatches =>
            new List<object[]>
            {
                new object[]
                {
                    new[] {GuessColour.RED, GuessColour.RED, GuessColour.RED, GuessColour.RED},
                    new[] {GuessColour.RED, GuessColour.BLUE, GuessColour.BLUE, GuessColour.BLUE},
                    new[] {HintColour.Black}
                },
                new object[]
                {
                    new[] {GuessColour.GREEN, GuessColour.YELLOW, GuessColour.ORANGE, GuessColour.RED},
                    new[] {GuessColour.BLUE, GuessColour.BLUE, GuessColour.BLUE, GuessColour.RED},
                    new[] {HintColour.Black}
                },
                new object[]
                {
                    new[] {GuessColour.PURPLE, GuessColour.PURPLE, GuessColour.PURPLE, GuessColour.PURPLE},
                    new[] {GuessColour.BLUE, GuessColour.PURPLE, GuessColour.BLUE, GuessColour.RED},
                    new[] {HintColour.Black}
                },
                new object[]
                {
                    new[] {GuessColour.RED, GuessColour.RED, GuessColour.RED, GuessColour.RED},
                    new[] {GuessColour.RED, GuessColour.RED, GuessColour.BLUE, GuessColour.BLUE},
                    new[] {HintColour.Black, HintColour.Black}
                },
                new object[]
                {
                    new[] {GuessColour.GREEN, GuessColour.YELLOW, GuessColour.BLUE, GuessColour.RED},
                    new[] {GuessColour.BLUE, GuessColour.BLUE, GuessColour.BLUE, GuessColour.RED},
                    new[] {HintColour.Black, HintColour.Black}
                },
                new object[]
                {
                    new[] {GuessColour.PURPLE, GuessColour.PURPLE, GuessColour.PURPLE, GuessColour.PURPLE},
                    new[] {GuessColour.BLUE, GuessColour.PURPLE, GuessColour.BLUE, GuessColour.PURPLE},
                    new[] {HintColour.Black, HintColour.Black}
                },
                new object[]
                {
                    new[] {GuessColour.RED, GuessColour.PURPLE, GuessColour.PURPLE, GuessColour.PURPLE},
                    new[] {GuessColour.RED, GuessColour.PURPLE, GuessColour.BLUE, GuessColour.PURPLE},
                    new[] {HintColour.Black, HintColour.Black, HintColour.Black}
                },
                new object[]
                {
                    new[] {GuessColour.GREEN, GuessColour.YELLOW, GuessColour.ORANGE, GuessColour.PURPLE},
                    new[] {GuessColour.GREEN, GuessColour.PURPLE, GuessColour.ORANGE, GuessColour.PURPLE},
                    new[] {HintColour.Black, HintColour.Black, HintColour.Black}
                },
            };

        public static IEnumerable<object[]> NonExactMatches =>
            new List<object[]>
            {
                new object[]
                {
                    new[] {GuessColour.RED, GuessColour.YELLOW, GuessColour.RED, GuessColour.RED},
                    new[] {GuessColour.YELLOW, GuessColour.BLUE, GuessColour.GREEN, GuessColour.ORANGE},
                    new[] {HintColour.White}
                },
                new object[]
                {
                    new[] {GuessColour.RED, GuessColour.YELLOW, GuessColour.BLUE, GuessColour.RED},
                    new[] {GuessColour.YELLOW, GuessColour.BLUE, GuessColour.GREEN, GuessColour.ORANGE},
                    new[] {HintColour.White, HintColour.White}
                },
                new object[]
                {
                    new[] {GuessColour.RED, GuessColour.YELLOW, GuessColour.BLUE, GuessColour.RED},
                    new[] {GuessColour.YELLOW, GuessColour.BLUE, GuessColour.RED, GuessColour.ORANGE},
                    new[] {HintColour.White, HintColour.White, HintColour.White}
                },
                new object[]
                {
                    new[] {GuessColour.RED, GuessColour.YELLOW, GuessColour.ORANGE, GuessColour.BLUE},
                    new[] {GuessColour.YELLOW, GuessColour.BLUE, GuessColour.RED, GuessColour.ORANGE},
                    new[] {HintColour.White, HintColour.White, HintColour.White, HintColour.White}
                },
            };

        public static IEnumerable<object[]> MixOfMatches =>
            new List<object[]>
            {
                new object[]
                {
                    new[] {GuessColour.RED, GuessColour.YELLOW, GuessColour.RED, GuessColour.BLUE},
                    new[] {GuessColour.RED, GuessColour.BLUE, GuessColour.GREEN, GuessColour.ORANGE},
                    1, 1
                },
                new object[]
                {
                    new[] {GuessColour.RED, GuessColour.YELLOW, GuessColour.BLUE, GuessColour.RED},
                    new[] {GuessColour.YELLOW, GuessColour.BLUE, GuessColour.GREEN, GuessColour.RED},
                    1, 2
                },
                new object[]
                {
                    new[] {GuessColour.RED, GuessColour.YELLOW, GuessColour.BLUE, GuessColour.RED},
                    new[] {GuessColour.RED, GuessColour.BLUE, GuessColour.GREEN, GuessColour.RED},
                    2, 1
                },
                new object[]
                {
                    new[] {GuessColour.RED, GuessColour.GREEN, GuessColour.BLUE, GuessColour.RED},
                    new[] {GuessColour.RED, GuessColour.BLUE, GuessColour.GREEN, GuessColour.RED},
                    2, 2
                },
                new object[]
                {
                    new[] {GuessColour.RED, GuessColour.GREEN, GuessColour.BLUE, GuessColour.RED},
                    new[] {GuessColour.RED, GuessColour.BLUE, GuessColour.GREEN, GuessColour.YELLOW},
                    1, 2
                },
            };
    }
}