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
        private readonly List<IValidation> _validations;

        public PatternValidator(List<IValidation> validations)
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