namespace Myob.Fma.Mastermind.GameServices.Input.Validations
{
    public interface IValidationResult
    {
         bool IsValid { get;}
         string ErrorMessage { get; set; }

    }
}