namespace Myob.Fma.Mastermind.GameServices.Input.Validations
{
    public interface IValidationResult
    {
         bool IsValid { get; set; }
         string ErrorMessage { get; set; }

    }
}