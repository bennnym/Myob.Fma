using System.Collections.Generic;

namespace Myob.Fma.Mastermind.Utilities
{
    public interface IPatternValidator
    {
        bool IsUsersInputValid(string userInput, out string message);
        List<Colours> GetValidColours(string userGuess);
    }
}