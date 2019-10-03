using Myob.Fma.Mastermind.Constants;

namespace Myob.Fma.Mastermind.GameServices.Input.Validations
{
    public class ValidationResult : IValidationResult
    {
        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
}