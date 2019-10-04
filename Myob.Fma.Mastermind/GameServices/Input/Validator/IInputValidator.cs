using System.Collections.Generic;
using Myob.Fma.Mastermind.Enums;
using Myob.Fma.Mastermind.GameServices.Input.Validations;
using Myob.Fma.Mastermind.GameServices.Input.Validations.ValidationResults;

namespace Myob.Fma.Mastermind.GameServices.Input.Validator
{
    public interface IInputValidator
    {
        IValidationResult GetValidationResults(string userInput);
        GuessColour[] GetValidColours(string userGuess);
    }
}