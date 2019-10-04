using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.GameServices.Input.Validations;

namespace Myob.Fma.MastermindTests.Fakes
{
    public class FakeGuessLimitValidation : IValidation
    {
        private int _guessesCount = 59;

        public bool IsValid(string userInput)
        {
            _guessesCount += 1;

            return _guessesCount < Constant.GuessLimit;
        }

        public string GetErrorMessage()
        {
            return Constant.GuessLimitExceededErrorMsg;
        }
    }
}