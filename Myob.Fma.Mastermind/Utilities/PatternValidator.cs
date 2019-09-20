using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Myob.Fma.Mastermind.Constants;

namespace Myob.Fma.Mastermind.Utilities
{
    public class PatternValidator : IPatternValidator
    {
        public bool IsCountOfWordsInGuessValid(string userGuess)
        {
            var wordSearch = new Regex(Constant.RegexWordSearchPattern);

            return wordSearch.Matches(userGuess).Count() == 4;
        }

        public bool AreColoursValid(string userGuess)
        {
            var validColoursMatched = GetValidColours(userGuess);

            return validColoursMatched.Count() == 4;
        }
        
        public List<Colours> GetValidColours(string usersGuess)
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