using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Infrastructure;

namespace Myob.Fma.Mastermind.GameServices.Counter
{
    public class GuessCounter : IGuessCounter
    {
        private int _guessCount;

        public string RemainingGuessesMessage =>
            _guessCount <= Constant.GuessLimit - 1 ? CurrentGuessCount() : Constant.GuessLimitExceededErrorMsg;

        public bool IsGuessLimitExceeded => _guessCount >= 60;

        public void IncrementCount()
        {
            _guessCount += 1;
        }

        private string CurrentGuessCount()
        {
            return Constant.GuessCountPrompt + _guessCount + Constant.NewLine + Constant.RemainingGuessesPrompt +
                   (Constant.GuessLimit - _guessCount) + Constant.NewLine;
        }
    }
}