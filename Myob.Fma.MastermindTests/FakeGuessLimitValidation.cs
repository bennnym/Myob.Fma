using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.GameServices.Input.Validator;

namespace Myob.Fma.MastermindTests
{
    public class FakeGuessLimitValidation : IValidation
    {
        private int _guessesCount = 59;

        public bool IsNotValid(string userInput)
        {
            _guessesCount += 1;

            return _guessesCount >= Constant.GuessLimit;
        }

        public string GetErrorMessage()
        {
            return Constant.GuessLimitExceededErrorMsg;
        }
    }
}