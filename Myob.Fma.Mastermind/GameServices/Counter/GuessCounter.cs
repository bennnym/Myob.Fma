using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Infrastructure;

namespace Myob.Fma.Mastermind.GameServices.Counter
{
    public class GuessCounter : IGuessCounter
    {
        private int _guessCount;
        private readonly IConsoleDisplayService _consoleDisplayService;

        public GuessCounter(IConsoleDisplayService consoleDisplayService)
        {
            _consoleDisplayService = consoleDisplayService;
        }

        public void IncrementCount()
        {
            _guessCount += 1;
        }

        public void DisplayCountMessage()
        {
            if (_guessCount <= 59)
            {
                DisplayCurrentGuessCount();
            }
            else
            {
                _consoleDisplayService.DisplayOutput(Constant.GuessLimitExceededErrorMsg);
                _consoleDisplayService.ExitApplication();
            }
        }

        private void DisplayCurrentGuessCount()
        {
            _consoleDisplayService.DisplayOutput(Constant.GuessCountPrompt + _guessCount);
            _consoleDisplayService.DisplayOutput(
                Constant.RemainingGuessesPrompt + (Constant.GuessLimit - _guessCount));
            _consoleDisplayService.DisplayOutput(Constant.NewLine);
        }
    }
}