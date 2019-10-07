using System.Collections.Generic;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Output;
using Xunit;

namespace Myob.Fma.MastermindTests
{
    public class MessageFormatterTests
    {
        private MessageFormatter _messageFormatter;

        public MessageFormatterTests()
        {
            _messageFormatter = new MessageFormatter();
        }

        [Theory]
        [MemberData(nameof(HintEnumerable))]
        public void Should_Return_String_Of_Hints_From_Enumerable(IEnumerable<HintColour> hints, string expectedOutput)
        {
            // Act
            var hintString = _messageFormatter.TransformHintColourEnumerableToString(hints);
            
            // Assert
            Assert.Equal(expectedOutput, hintString);
        }

        [Theory]
        [MemberData(nameof(HintMessages))]
        public void Should_Return_Appropriate_Hint_Message(string hintString, string expectedOutput)
        {
            // Act
            var hintMessage = _messageFormatter.GetHintMessage(hintString);
            
            // Assert
            Assert.Equal(expectedOutput, hintMessage);
        }
        
        public static IEnumerable<object[]> HintMessages =>
            new List<object[]>
            {
                new object[]
                {
                    new[] {HintColour.White},
                    "White"
                },
                new object[]
                {
                    new[] {HintColour.Black},
                    "Black"
                },
                new object[]
                {
                    new[] {HintColour.White, HintColour.Black},
                    "White, Black"
                },
                new object[]
                {
                    new[] {HintColour.Black, HintColour.White},
                    "Black, White"
                },
                new object[]
                {
                    new[] {HintColour.White, HintColour.White, HintColour.White, HintColour.White},
                    "White, White, White, White"
                },
                new object[]
                {
                    new[] {HintColour.Black, HintColour.Black, HintColour.Black, HintColour.Black},
                    "Black, Black, Black, Black"
                },
            };

        public static IEnumerable<object[]> HintEnumerable =>
            new List<object[]>
            {
                new object[]
                {
                    new[] {HintColour.White},
                    "White"
                },
                new object[]
                {
                    new[] {HintColour.Black},
                    "Black"
                },
                new object[]
                {
                    new[] {HintColour.White, HintColour.Black},
                    "White, Black"
                },
                new object[]
                {
                    new[] {HintColour.Black, HintColour.White},
                    "Black, White"
                },
                new object[]
                {
                    new[] {HintColour.White, HintColour.White, HintColour.White, HintColour.White},
                    "White, White, White, White"
                },
                new object[]
                {
                    new[] {HintColour.Black, HintColour.Black, HintColour.Black, HintColour.Black},
                    "Black, Black, Black, Black"
                },
            };

    }
}