using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Infrastructure;
using Myob.Fma.Mastermind.Utilities;

namespace Myob.Fma.Mastermind.GameServices.Input
{
    public class GameInput : IGameInput
    {
        private readonly ConsoleIoService _consoleIoService;
        private readonly PatternValidator _patternValidator;

        public GameInput(ConsoleIoService consoleIoService, PatternValidator patternValidator)
        {
            _consoleIoService = consoleIoService;
            _patternValidator = patternValidator;
        }

        public List<Colours> GetUsersCodeGuess()
        {
            _consoleIoService.DisplayOutput(Constant.Welcome);
            _consoleIoService.DisplayOutput(Constant.Instructions);

            var isUserInputValid = false;
            var usersGuess = string.Empty;

            while (isUserInputValid == false)
            {
                usersGuess = _consoleIoService.GetUserInput();

                isUserInputValid = IsUsersInputValid(usersGuess, out string message);

                _consoleIoService.DisplayOutput(message);
            }

            return _patternValidator.GetValidColours(usersGuess);
        }

        private bool IsUsersInputValid(string usersGuess, out string message)
        {
            if (_patternValidator.IsCountOfWordsInGuessValid(usersGuess) == false)
            {
                message = Constant.IncorrectNumberOfColoursErrorMsg;
                return false;
            }

            if (_patternValidator.AreColoursValid(usersGuess) == false)
            {
                message = Constant.InvalidColourErrorMsg;
                return false;
            }

            message = Constant.ValidGuessMsg;
            Thread.Sleep(2000);
            return true;
        }
    }
}