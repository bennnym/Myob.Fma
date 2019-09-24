using System.Collections.Generic;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Input.Validator;
using Myob.Fma.Mastermind.Infrastructure;

namespace Myob.Fma.Mastermind.GameServices.Input.Processor
{
    public class InputProcessor : IInputProcessor
    {
        private readonly ConsoleIoService _consoleIoService;
        private readonly IInputValidator _inputValidator;

        public InputProcessor(ConsoleIoService consoleIoService, IInputValidator patternValidator)
        {
            _consoleIoService = consoleIoService;
            _inputValidator = patternValidator;
        }

        public List<GuessColour> GetUsersInput()
        {
            _consoleIoService.DisplayOutput(Constant.Welcome);
            _consoleIoService.DisplayOutput(Constant.Instructions);

            var isUserInputValid = false;
            var usersGuess = string.Empty;

            while (isUserInputValid == false)
            {
                usersGuess = _consoleIoService.GetUserInput();

                isUserInputValid = _inputValidator.IsUsersInputValid(usersGuess, out var message);

                _consoleIoService.DisplayOutput(message);
            }

            return _inputValidator.GetValidColours(usersGuess);
        }
    }
}