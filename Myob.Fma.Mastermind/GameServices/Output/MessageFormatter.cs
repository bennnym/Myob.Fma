using System.Collections.Generic;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;

namespace Myob.Fma.Mastermind.GameServices.Output
{
    public class MessageFormatter : IMessageFormatter
    {
        public string GetHintMessage(string hintFeedback)
        {
            if (hintFeedback == string.Empty)
            {
                return Constant.IncorrectGuessClue + Constant.NewLine;
            }

            if (hintFeedback == Constant.WinningGuess)
            {
                return Constant.WinningFeedback + Constant.NewLine;
            }

            return Constant.CluePrompt + hintFeedback + Constant.NewLine;
        }

        public string TransformHintColourEnumerableToString(IEnumerable<HintColour> hintColours)
        {
            return string.Join(Constant.SpaceCommaDelimiter, hintColours);
        }
    }
}