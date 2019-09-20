using System.Linq;
using System.Text.RegularExpressions;
using Myob.Fma.Mastermind.Constants;

namespace Myob.Fma.Mastermind.Utilities
{
    public class PatternValidator : IPatternValidator
    {
        public bool IsTheCorrectAmountOfColoursEntered(string userGuess)
        {
            var wordSearch = new Regex(Constant.RegexWordSearchPattern);
            
            return wordSearch.Matches(userGuess).Count() == 4;
        }
    }
}