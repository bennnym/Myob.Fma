using Myob.Fma.Mastermind.Constants;

namespace Myob.Fma.Mastermind.GameServices.Counter
{
    public class GuessCounter : IGuessCounter
    {
        private int _guessCount;
        
        public void IncrementCount()
        {
            _guessCount += 1;
        }

        public string GetRemainingGuessMessage()
        {
            return _guessCount <= Constant.GuessLimit - 1
                ? GetCurrentGuessCountMessage()
                : Constant.GuessLimitExceededErrorMsg;
        }

        public bool IsGuessLimitExceeded()
        {
            return _guessCount >= 60;
        }

        private string GetCurrentGuessCountMessage()
        {
            return Constant.GuessCountPrompt + _guessCount + Constant.NewLine + Constant.RemainingGuessesPrompt +
                   (Constant.GuessLimit - _guessCount) + Constant.NewLine;
        }
    }
}