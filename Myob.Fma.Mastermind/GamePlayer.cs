using System.Collections.Generic;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Input.Processor;
using Myob.Fma.Mastermind.Infrastructure;

namespace Myob.Fma.Mastermind
{
    public class GamePlayer
    {
        private readonly IInputProcessor _inputProcessor;
        private readonly IIoService _ioService;

        public GamePlayer(IInputProcessor inputProcessor, IIoService ioService)
        {
            _inputProcessor = inputProcessor;
            _ioService = ioService;
        }

        public void MasterMind(Game game)
        {
            _ioService.DisplayOutput(Constant.WelcomeInstructions);
            var feedbackMessage = string.Empty;

            while (feedbackMessage != Constant.WinningGuess)
            {
                var userGuess = _inputProcessor.GetUsersInput();
                var hintFeedback = game.Check(userGuess);
                feedbackMessage = GetHintsAsAString(hintFeedback);
                DisplayCorrectHintOutput(feedbackMessage);
            }
        }

        private void DisplayCorrectHintOutput(string hintFeedback)
        {
            if (hintFeedback == string.Empty)
            {
                _ioService.DisplayOutput(Constant.IncorrectGuessClue);
            }
            else if (hintFeedback == Constant.WinningGuess)
            {
                _ioService.DisplayOutput(Constant.WinningFeedback);
            }
            else
            {
                _ioService.DisplayOutput(Constant.CluePrompt + hintFeedback);
            }
        }
        
        private string GetHintsAsAString(IEnumerable<HintColour> hintColours)
        {
            return string.Join(Constant.SpaceCommaDelimiter, hintColours);
        }

    }
}