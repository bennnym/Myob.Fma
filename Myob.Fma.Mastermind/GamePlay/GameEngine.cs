using System.Collections.Generic;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Input.Processor;
using Myob.Fma.Mastermind.GameServices.Output;
using Myob.Fma.Mastermind.Infrastructure;

namespace Myob.Fma.Mastermind.GamePlay
{
    public class GameEngine
    {
        private readonly IInputProcessor _inputProcessor;
        private readonly IConsoleDisplayService _consoleDisplayService;
        private readonly IMessageFormatter _messageFormatter;

        public GameEngine(IInputProcessor inputProcessor, IConsoleDisplayService consoleDisplayService,
            IMessageFormatter messageFormatter)
        {
            _inputProcessor = inputProcessor;
            _consoleDisplayService = consoleDisplayService;
            _messageFormatter = messageFormatter;
        }

        public void Mastermind(Game game)
        {
            _consoleDisplayService.DisplayOutput(Constant.WelcomeInstructions);
            var guessHint = string.Empty;

            game.ComputerPlayer.SetHiddenCode();

            while (guessHint != Constant.WinningGuess)
            {
                var guessStatusMessage = game.GuessCounter.RemainingGuessesMessage;
                _consoleDisplayService.DisplayOutput(guessStatusMessage);
                CheckForEndOfGame(game.GuessCounter.IsGuessLimitExceeded);
                
                var userGuess = _inputProcessor.GetUsersColourGuess();
                var hintFeedback = game.Check(userGuess);
                
                game.GuessCounter.IncrementCount();
                
                guessHint = _messageFormatter.GetHintColoursAsAString(hintFeedback);
                var userHintFeedback = _messageFormatter.GetHintMessage(guessHint);
                _consoleDisplayService.DisplayOutput(userHintFeedback);
            }
        }

        private void CheckForEndOfGame(bool isTheGameOver)
        {
            if (isTheGameOver)
            {
                _consoleDisplayService.ExitApplication();
            }
        }
    }
}