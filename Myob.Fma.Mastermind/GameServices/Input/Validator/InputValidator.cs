using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Input.Validations;

namespace Myob.Fma.Mastermind.GameServices.Input.Validator
{
    public class InputValidator : IInputValidator
    {
        private readonly List<IValidation> _validations;

        public InputValidator(List<IValidation> validations)
        {
            _validations = validations;
        }
        public IValidationResult GetValidationResults(string usersGuess)
        {
            var validationResult = new ValidationResult();
            
            foreach (var validation in _validations)
            {
                if (!validation.IsValid(usersGuess))
                {
                    validationResult.IsValid = false;
                    validationResult.ErrorMessage = validation.GetErrorMessage();
                    return validationResult;
                }
            }
            return validationResult;
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