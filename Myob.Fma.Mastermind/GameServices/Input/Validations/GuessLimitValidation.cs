using System;
using Myob.Fma.Mastermind.Constants;
using Myob.Fma.Mastermind.GameServices.Input.Validator;

namespace Myob.Fma.Mastermind.GameServices.Input.Validations
{
    public class GuessLimitValidation : IValidation
    {
        private int _guessesCount;
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