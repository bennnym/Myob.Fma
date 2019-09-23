using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Myob.Fma.Mastermind.Constants;

namespace Myob.Fma.Mastermind.Utilities
{
    public class PatternValidator : IPatternValidator
    {
        public List<Colours> GetValidColours(string usersGuess)
        {
            var usersGuessCapitalized = usersGuess.ToUpper();

            var colourMatches = new Regex(Constant.RegexColourPattern);

            return colourMatches
                .Matches(usersGuessCapitalized)
                .Select(m => (Colours) Enum.Parse(typeof(Colours), m.Value))
                .ToList();
        }

        public bool IsUsersInputValid(string usersGuess, out string message)
        {
            if (IsCountOfWordsInGuessValid(usersGuess) == false)
            {
                message = Constant.IncorrectNumberOfColoursErrorMsg;
                return false;
            }

            if (AreColoursValid(usersGuess) == false)
            {
                message = Constant.InvalidColourErrorMsg;
                return false;
            }

            message = Constant.ValidGuessMsg;
            Thread.Sleep(2000);
            return true;
        }

        private bool IsCountOfWordsInGuessValid(string userGuess)
        {
            var wordSearch = new Regex(Constant.RegexWordSearchPattern);

            return wordSearch.Matches(userGuess).Count() == 4;
        }

        private bool AreColoursValid(string userGuess)
        {
            var validColoursMatched = GetValidColours(userGuess);

            return validColoursMatched.Count() == 4;
        }
    }
}