using System.Collections.Generic;

namespace Myob.Fma.Mastermind.GameServices.Input.Validator
{
    public interface IInputValidator
    {
        bool IsUsersInputValid(string userInput, out string message);
        List<Colours> GetValidColours(string userGuess);
    }
}