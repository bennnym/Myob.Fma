namespace Myob.Fma.Mastermind.GameServices.Input.Validations.ValidationResults
{
    public interface IValidationResult
    {
         bool IsValid { get;}
         string ErrorMessage { get; set; }

    }
}