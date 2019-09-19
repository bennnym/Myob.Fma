using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
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

           return GetValidColours(usersGuess);

        }

        private bool IsUsersInputValid(string usersGuess, out string message)
        {
            if (IsTheCorrectAmountOfColoursEntered(usersGuess) == false)
            {
                message = Constant.IncorrectNumberOfColoursErrorMsg;
                return false;
            }
            
            if (IsColoursValid(usersGuess) == false)
            {
                message = Constant.InvalidColourErrorMsg;
                return false;
            }

            message = Constant.ValidGuess;
            Thread.Sleep(2000);
            return true;
        }
        
        private bool IsTheCorrectAmountOfColoursEntered(string usersGuess)
        {
            return usersGuess.Split(Constant.Delimiter).Length == 4;
        }
        
        private bool IsColoursValid(string usersGuess)
        {
            var validColoursMatched = GetValidColours(usersGuess);

            return validColoursMatched.Count() == 4;
        }

        private List<Colours> GetValidColours(string usersGuess)
        {
            var usersGuessCapitalized = usersGuess.ToUpper();

            var colourMatches = new Regex(Constant.RegexColourPattern);

            return colourMatches
                .Matches(usersGuessCapitalized)
                .Select(m => (Colours)Enum.Parse(typeof(Colours), m.Value))
                .ToList();
        }
    }
}