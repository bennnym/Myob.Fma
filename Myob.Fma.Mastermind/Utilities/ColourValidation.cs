using System;
using System.Linq;
using System.Text.RegularExpressions;
using Myob.Fma.Mastermind.Constants;

namespace Myob.Fma.Mastermind.Utilities
{
    public class ColourValidation : IValidation
    {
        public bool IsValid(string userInput)
        {
            var usersGuessCapitalized = userInput.ToUpper();

            var colourMatches = new Regex(Constant.RegexColourPattern);

            var validColoursMatched = colourMatches
                .Matches(usersGuessCapitalized)
                .Select(m => (Colours) Enum.Parse(typeof(Colours), m.Value));
            
            return validColoursMatched.Count() == 4;
        }

        public string GetErrorMessage()
        {
            return Constant.InvalidColourErrorMsg;
        }
    }
}