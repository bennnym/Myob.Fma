using System.Collections.Generic;
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

                isUserInputValid = _patternValidator.IsUsersInputValid(usersGuess, out var message);

                _consoleIoService.DisplayOutput(message);
            }

            return _patternValidator.GetValidColours(usersGuess);
        }
    }
}