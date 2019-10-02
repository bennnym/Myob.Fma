using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;

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
            foreach (var validation in _validations)
            {
                if (validation.IsValid(usersGuess) == false)
                {
                    message = validation.GetErrorMessage();
                    return false;
                }
            }
            
            message = Constant.ValidGuessMsg;
            return true;
        }

        public GuessColour[] GetValidColours(string usersGuess)
        {
            var usersGuessCapitalized = usersGuess.ToUpper();

            var colourMatches = new Regex(Constant.RegexColourPattern);

            return colourMatches
                .Matches(usersGuessCapitalized)
                .Select(m => (GuessColour) Enum.Parse(typeof(GuessColour), m.Value))
                .ToArray();
        }
    }
}