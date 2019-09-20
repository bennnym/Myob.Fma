using System.Collections.Generic;

namespace Myob.Fma.Mastermind.Utilities
{
    public interface IPatternValidator
    {
        bool IsCountOfWordsInGuessValid(string userGuess);
        bool AreColoursValid(string userGuess);
        List<Colours> GetValidColours(string userGuess);
    }
}