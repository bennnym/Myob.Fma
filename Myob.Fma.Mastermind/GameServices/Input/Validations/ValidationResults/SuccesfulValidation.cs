using Myob.Fma.Mastermind.Constants;

namespace Myob.Fma.Mastermind.GameServices.Input.Validations.ValidationResults
{
    public class SuccessfulValidation : IValidationResult
    {
        public SuccessfulValidation()
        {
            IsValid = true;
            ErrorMessage = Constant.ValidGuessMsg;
        }
        public bool IsValid { get; }
        public string ErrorMessage { get; set; }
    }
}