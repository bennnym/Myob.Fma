using System.Linq;
using System.Text.RegularExpressions;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.GameServices.Input.Validator;

namespace Myob.Fma.Mastermind.GameServices.Input.Validations
{
    public class WordCountValidation : IValidation
    {
        public bool IsNotValid(string userInput)
        {
            var wordSearch = new Regex(Constant.RegexWordSearchPattern);

            return wordSearch.Matches(userInput).Count() != 4;
        }

        public string GetErrorMessage()
        {
            return Constant.IncorrectNumberOfColoursErrorMsg;
        }
    }
}