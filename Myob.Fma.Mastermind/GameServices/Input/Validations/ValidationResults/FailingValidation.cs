namespace Myob.Fma.Mastermind.GameServices.Input.Validations
{
    public class FailingValidation : IValidationResult
    {
        public bool IsValid { get; }
        public string ErrorMessage { get; set; }
    }
}