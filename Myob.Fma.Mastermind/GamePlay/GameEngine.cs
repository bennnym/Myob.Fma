using System.Collections.Generic;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Input.Processor;
using Myob.Fma.Mastermind.Infrastructure;

namespace Myob.Fma.Mastermind.GamePlay
{
    public class GameEngine
    {
        private readonly IInputProcessor _inputProcessor;
        private readonly IConsoleDisplayService _consoleDisplayService;

        public GameEngine(IInputProcessor inputProcessor, IConsoleDisplayService consoleDisplayService)
        {
            _inputProcessor = inputProcessor;
            _consoleDisplayService = consoleDisplayService;
        }

        public void Mastermind(Game game)
        {
            _consoleDisplayService.DisplayOutput(Constant.WelcomeInstructions);
            var guessClues = string.Empty;
            
            game.ComputerPlayer.SetHiddenCode();

            while (guessClues != Constant.WinningGuess)
            {
                game.GuessCounter.DisplayCountMessage();
                var userGuess = _inputProcessor.GetUsersColourGuess();
                var hintFeedback = game.Check(userGuess);
                game.GuessCounter.IncrementCount();
                guessClues = GetCluesAsAString(hintFeedback);
                var userHintFeedback = GetHintMessage(guessClues);
                _consoleDisplayService.DisplayOutput(userHintFeedback);
            }
        }

        private static string GetHintMessage(string hintFeedback)
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

        private static string GetCluesAsAString(IEnumerable<HintColour> hintColours)
        {
            return string.Join(Constant.SpaceCommaDelimiter, hintColours);
        }
    }
}