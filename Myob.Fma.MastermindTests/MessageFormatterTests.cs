using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Output;
using Xunit;

namespace Myob.Fma.MastermindTests
{
    public class MessageFormatterTests
    {
        private readonly MessageFormatter _messageFormatter;

        public MessageFormatterTests()
        {
            _messageFormatter = new MessageFormatter();
        }

        [Fact]
        public void Should_Return_Winning_Message_When_Given_Winning_Hints()
        {
            // Arrange
            var winningHints = new HintColour[]
                {HintColour.Black, HintColour.Black, HintColour.Black, HintColour.Black};

            // Act
            var hintMessage = _messageFormatter.GetHintMessage(winningHints);

            // Assert
            Assert.Equal(Constant.WinningFeedback, hintMessage);
        }

        [Fact]
        public void Should_Return_No_Clue_Message()
        {
            // Arrange
            var hints = Enumerable.Empty<HintColour>();

            // Act
            var hintMessage = _messageFormatter.GetHintMessage(hints);

            // Assert
            Assert.Equal(Constant.NoCluesPresent, hintMessage);
        }

        [Theory]
        [MemberData(nameof(HintMessages))]
        public void Should_Return_Appropriate_Hint_Message(IEnumerable<HintColour> hints, string expectedOutput)
        {
            // Act
            var hintMessage = _messageFormatter.GetHintMessage(hints);

            // Assert
            Assert.Equal(expectedOutput, hintMessage);
        }

        public static IEnumerable<object[]> HintMessages =>
            new List<object[]>
            {
                new object[]
                {
                    new[] {HintColour.White},
                    Constant.CluePrompt + "White" + Constant.NewLine
                },
                new object[]
                {
                    new[] {HintColour.Black},
                    Constant.CluePrompt + "Black" + Constant.NewLine
                },
                new object[]
                {
                    new[] {HintColour.Black, HintColour.White},
                    Constant.CluePrompt + "Black, White" + Constant.NewLine
                },
                new object[]
                {
                    new[] {HintColour.Black, HintColour.White, HintColour.White},
                    Constant.CluePrompt + "Black, White, White" + Constant.NewLine
                },
            };
    }
}