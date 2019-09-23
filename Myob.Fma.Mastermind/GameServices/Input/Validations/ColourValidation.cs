using System;
using System.Linq;
using System.Text.RegularExpressions;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.GameServices.Input.Validator;

namespace Myob.Fma.Mastermind.GameServices.Input.Validations
{
    public class ColourValidation : IValidation
    {
        public bool IsNotValid(string userInput)
        {
            var usersGuessCapitalized = userInput.ToUpper();

            var colourMatches = new Regex(Constant.RegexColourPattern);

            var validColoursMatched = colourMatches
                .Matches(usersGuessCapitalized)
                .Select(m => (Colours) Enum.Parse(typeof(Colours), m.Value));
            
            return validColoursMatched.Count() != 4;
        }

        public string GetErrorMessage()
        {
            return Constant.InvalidColourErrorMsg;
        }
    }
}