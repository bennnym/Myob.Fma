using System;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Input.Validator;
using Myob.Fma.Mastermind.Infrastructure;

namespace Myob.Fma.Mastermind.GameServices.Input.Processor
{
    public class InputProcessor : IInputProcessor
    {
        private readonly IConsoleDisplayService _consoleIoService;
        private readonly IInputValidator _inputValidator;

        public InputProcessor(IConsoleDisplayService ioService, IInputValidator inputValidator)
        {
            _consoleIoService = ioService;
            _inputValidator = inputValidator;
        }

        public GuessColour[] GetUsersColourGuess()
        {
            var isUserInputValid = false;
            var usersGuess = string.Empty;

            while (isUserInputValid == false)
            {
                usersGuess = _consoleIoService.GetConsoleInput();

                isUserInputValid = _inputValidator.IsUsersInputValid(usersGuess, out var message); // return class?

                _consoleIoService.DisplayOutput(message);
                CheckIfGuessLimitExceeded(message);
            }

            return _inputValidator.GetValidColours(usersGuess);
        }

        private void CheckIfGuessLimitExceeded(string message) // move this to guess limit validations?
        {
            if (message == Constant.GuessLimitExceededErrorMsg)
            {
                Environment.Exit(0); // bound to console - add to its class
            }
        }
    }
}