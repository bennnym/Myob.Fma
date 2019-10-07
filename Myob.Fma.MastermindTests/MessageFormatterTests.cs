using System.Collections.Generic;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Output;
using Xunit;

namespace Myob.Fma.MastermindTests
{
    public class MessageFormatterTests
    {
        [Theory]
        [MemberData(nameof(HintMessages))]
        public void Should_Return_Appropriate_Hint_Message(IEnumerable<HintColour> hints, string expectedOutput)
        {
            // Arrange
            var messageFormatter = new MessageFormatter();

            // Act
            var hintMessage = messageFormatter.GetHintMessage(hints);

            // Assert
            Assert.Equal(expectedOutput, hintMessage);
        }

        public static IEnumerable<object[]> HintMessages =>
            new List<object[]>
            {
                new object[]
                {
                    new HintColour[1],
                    Constant.IncorrectGuessClue + Constant.NewLine
                },
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