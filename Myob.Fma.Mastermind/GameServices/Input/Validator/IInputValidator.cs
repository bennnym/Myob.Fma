using System.Collections.Generic;
using Myob.Fma.Mastermind.Enums;

namespace Myob.Fma.Mastermind.GameServices.Input.Validator
{
    public interface IInputValidator
    {
        bool IsUsersInputValid(string userInput, out string message);
        GuessColour[] GetValidColours(string userGuess);
    }
}