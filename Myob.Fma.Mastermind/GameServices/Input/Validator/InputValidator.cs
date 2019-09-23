using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Myob.Fma.Mastermind.Constants;

namespace Myob.Fma.Mastermind.GameServices.Input.Validator
{
    public class InputValidator : IInputValidator
    {
        private readonly List<IValidation> _validations;

        public InputValidator(List<IValidation> validations)
        {
            _validations = validations;
        }
        public bool IsUsersInputValid(string usersGuess, out string message)
        {
            foreach (var validityCheck in _validations)
            {
                if (validityCheck.IsNotValid(usersGuess))
                {
                    message = validityCheck.GetErrorMessage();
                    return false;
                }
            }

            message = Constant.ValidGuessMsg;
            return true;
        }

        public List<Colours> GetValidColours(string usersGuess)
        {
            var usersGuessCapitalized = usersGuess.ToUpper();

            var colourMatches = new Regex(Constant.RegexColourPattern);

            return colourMatches
                .Matches(usersGuessCapitalized)
                .Select(m => (Colours) Enum.Parse(typeof(Colours), m.Value))
                .ToList();
        }
    }
}