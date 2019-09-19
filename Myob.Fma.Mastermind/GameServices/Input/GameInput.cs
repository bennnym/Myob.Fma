using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Infrastructure;

namespace Myob.Fma.Mastermind.GameServices.Input
{
    class GameInput : IGameInput
    {
        private readonly ConsoleIoService _consoleIoService;

        public GameInput(ConsoleIoService consoleIoService)
        {
            _consoleIoService = consoleIoService;
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

        }

        private bool IsUsersInputValid(string usersGuess, out string message)
        {
            if (IsTheCorrectAmountOfColoursEntered(usersGuess) == false)
            {
                message = "Error: you must pass 4 colours!";
                return false;
            }
            
            if (IsColoursValid(usersGuess) == false)
            {
                message = "Error: you have given an invalid colour!";
                return false;
            }

            message = "Valid guess, calculating clues...";
            return true;
        }
        
        private bool IsTheCorrectAmountOfColoursEntered(string usersGuess)
        {
            return usersGuess.Split(" ").Length == 4;
        }
        
        private bool IsColoursValid(string usersGuess)
        {
            var usersGuessCapitalized = usersGuess.ToUpper();

            var regex = new Regex(Constant.RegexColourPattern);

            return regex.Matches(usersGuessCapitalized).Count() == 4;
        }
    }
}