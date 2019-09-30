using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Input.Validator;
using Myob.Fma.Mastermind.Infrastructure;

namespace Myob.Fma.Mastermind.GameServices.Input.Processor
{
    public class InputProcessor : IInputProcessor
    {
        private readonly IIoService _consoleIoService;
        private readonly IInputValidator _inputValidator;

        public InputProcessor(IIoService consoleIoService, IInputValidator inputValidator)
        {
            _consoleIoService = consoleIoService;
            _inputValidator = inputValidator;
        }

        public GuessColour[] GetUsersInput()
        {
            var isUserInputValid = false;
            var usersGuess = string.Empty;

            while (isUserInputValid == false)
            {
                usersGuess = _consoleIoService.GetUserInput();

                isUserInputValid = _inputValidator.IsUsersInputValid(usersGuess, out var message);

                _consoleIoService.DisplayOutput(message);
                CheckIfGuessLimitExceeded(message);
            }

            return _inputValidator.GetValidColours(usersGuess);
        }

        private void CheckIfGuessLimitExceeded(string message)
        {
            if (message == Constant.GuessLimitExceededErrorMsg)
            {
                Environment.Exit(0);
            }
        }
    }
}