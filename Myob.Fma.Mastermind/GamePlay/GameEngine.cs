using System.Collections.Generic;
using System.Linq;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Counter;
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

        public void Mastermind(IGame game)
        {
            _consoleDisplayService.DisplayOutput(Constant.WelcomeInstructions);
            var hints = Enumerable.Empty<HintColour>();
            var guessCounter = new GuessCounter();

            game.SetComputerPlayersCode();

            while (IsNotWinningCombination(hints))
            {
                _consoleDisplayService.DisplayOutput(guessCounter.GetRemainingGuessMessage());

                if (guessCounter.IsGuessLimitExceeded()) _consoleDisplayService.ExitApplication();

                hints = game.Check(_inputProcessor.GetUsersColourGuess());

                guessCounter.IncrementCount();

                _consoleDisplayService.DisplayOutput(_messageFormatter.GetHintMessage(hints));
            }
        }

        private static bool IsNotWinningCombination(IEnumerable<HintColour> hints)
        {
            return hints.Count(hc => hc == HintColour.Black) == Constant.BlackHintsRequiredToWin;
        }
    }
}