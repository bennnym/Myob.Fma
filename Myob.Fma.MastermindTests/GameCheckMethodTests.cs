using System.Collections.Generic;
using System.Linq;
using Moq;
using Myob.Fma.Mastermind;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GamePlay;
using Myob.Fma.Mastermind.GameServices.Counter;
using Myob.Fma.Mastermind.GameServices.Players;
using Myob.Fma.Mastermind.Infrastructure;
using Xunit;

namespace Myob.Fma.MastermindTests
{
    public class GameCheckMethodTests
    {
        private readonly Mock<IComputerPlayer> _computerPlayer;
        private readonly Game _game;

        public GameCheckMethodTests()
        {
            _computerPlayer = new Mock<IComputerPlayer>();
            _game = new Game(_computerPlayer.Object);
        }

        [Fact]
        public void Should_Return_An_Empty_Array_When_No_Matches_Are_Found()
        {
            // Arrange
  
            var allRedCode = new[] {GuessColour.RED, GuessColour.RED, GuessColour.RED, GuessColour.RED};
            var allBlueGuess = new[] {GuessColour.BLUE, GuessColour.BLUE, GuessColour.BLUE, GuessColour.BLUE};

            // Act
            _computerPlayer.Setup(i => i.GetCodeSelection()).Returns(allRedCode);
            var hints = _game.Check(allBlueGuess);

            // Assert
            Assert.Empty(hints);
        }

        [Theory]
        [MemberData(nameof(ExactMatches))]
        public void Should_Return_Amount_Of_Black_Hints_Related_To_Exact_Matches(GuessColour[] computerGuess,
            GuessColour[] playerGuess, HintColour[] expectedHint)
        {
            // Arrange
            _computerPlayer.Setup(i => i.GetCodeSelection()).Returns(computerGuess);
            
            // Act
            var hints = _game.Check(playerGuess);

            // Assert
            Assert.Equal(expectedHint, hints);
        }

        [Theory]
        [MemberData(nameof(NonExactMatches))]
        public void Should_Return_Amount_Of_White_Hints_Related_To_Non_Exact_Matches(GuessColour[] computerGuess,
            GuessColour[] playerGuess, HintColour[] expectedHint)
        {
            // Arrange
            _computerPlayer.Setup(i => i.GetCodeSelection()).Returns(computerGuess);

            // Act
            var hints = _game.Check(playerGuess);

            // Assert
            Assert.Equal(expectedHint, hints);
        }

        [Theory]
        [MemberData(nameof(MixOfMatches))]
        public void Should_Return_Amount_Of_Black_And_White_Hints_According_To_Matches(GuessColour[] computerGuess,
            GuessColour[] playerGuess, int expectedBlackHints, int expectedWhiteHints)
        {
            // Arrange
            _computerPlayer.Setup(i => i.GetCodeSelection()).Returns(computerGuess);

            // Act
            var hints = _game.Check(playerGuess);
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
                    new[] {GuessColour.RED, GuessColour.YELLOW, GuessColour.BLUE, GuessColour.RED},
                    new[] {GuessColour.YELLOW, GuessColour.RED, GuessColour.RED, GuessColour.ORANGE},
                    new[] {HintColour.White, HintColour.White, HintColour.White}
                },
                new object[]
                {
                    new[] {GuessColour.RED, GuessColour.YELLOW, GuessColour.ORANGE, GuessColour.BLUE},
                    new[] {GuessColour.YELLOW, GuessColour.BLUE, GuessColour.RED, GuessColour.ORANGE},
                    new[] {HintColour.White, HintColour.White, HintColour.White, HintColour.White}
                },
                new object[]
                {
                    new[] {GuessColour.RED, GuessColour.PURPLE, GuessColour.BLUE, GuessColour.GREEN},
                    new[] {GuessColour.BLUE, GuessColour.BLUE, GuessColour.ORANGE, GuessColour.YELLOW},
                    new[] {HintColour.White}
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