using System.Collections.Generic;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;

namespace Myob.Fma.Mastermind.GameServices.Output
{
    public class MessageFormatter : IMessageFormatter
    {
        public string GetHintMessage(IEnumerable<HintColour> hintColours)
        {
            var hintString = TransformHintColourEnumerableToString(hintColours);
            
            if (hintString == string.Empty)
            {
                return Constant.IncorrectGuessClue + Constant.NewLine;
            }

            if (hintString == Constant.WinningGuess)
            {
                return Constant.WinningFeedback + Constant.NewLine;
            }

            return Constant.CluePrompt + hintString + Constant.NewLine;
        }

        private static string TransformHintColourEnumerableToString(IEnumerable<HintColour> hintColours)
        {
            return string.Join(Constant.SpaceCommaDelimiter, hintColours);
        }
    }
}