using System;
using System.Linq;
using System.Text.RegularExpressions;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Input.Validator;

namespace Myob.Fma.Mastermind.GameServices.Input.Validations
{
    public class ColourValidation : IValidation
    {
        public bool IsValid(string userInput)
        {
            var usersGuessCapitalized = userInput.ToUpper();

            var colourMatches = new Regex(Constant.RegexColourPattern);

            var validColoursMatched = colourMatches
                .Matches(usersGuessCapitalized)
                .Select(m => (GuessColour) Enum.Parse(typeof(GuessColour), m.Value));
            
            return validColoursMatched.Count() == 4;
        }

        public string GetErrorMessage()
        {
            return Constant.InvalidColourErrorMsg;
        }
    }
}