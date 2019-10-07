namespace Myob.Fma.Mastermind.GameServices.Input.Validations.ValidationResults
{
    public class FailingValidation : IValidationResult
    {
        public bool IsValid { get; }
        public string ErrorMessage { get; set; }
    }
}