using System.Collections.Generic;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Input.Processor;
using Myob.Fma.Mastermind.Infrastructure;

namespace Myob.Fma.Mastermind
{
    public class GameEngine
    {
        private readonly IInputProcessor _inputProcessor;
        private readonly IConsoleDisplayService _ioService;

        public GameEngine(IInputProcessor inputProcessor, IConsoleDisplayService ioService)
        {
            _inputProcessor = inputProcessor;
            _ioService = ioService;
        }

        public void Mastermind(Game game)
        {
            _ioService.DisplayOutput(Constant.WelcomeInstructions);
            var guessClues = string.Empty;

            while (guessClues != Constant.WinningGuess)
            {
                var userGuess = _inputProcessor.GetUsersColourGuess();
                var hintFeedback = game.Check(userGuess);
                guessClues = GetCluesAsAString(hintFeedback);
                var userHintFeedback = GetHintMessage(guessClues);
                _ioService.DisplayOutput(userHintFeedback);
            }
        }

        private string GetHintMessage(string hintFeedback)
        {
            if (hintFeedback == string.Empty)
            {
                return Constant.IncorrectGuessClue;
            }

            if (hintFeedback == Constant.WinningGuess)
            {
                return Constant.WinningFeedback;
            }
            
            return Constant.CluePrompt + hintFeedback + Constant.NewLine;
        }

        private string GetCluesAsAString(IEnumerable<HintColour> hintColours)
        {
            return string.Join(Constant.SpaceCommaDelimiter, hintColours);
        }
    }
}