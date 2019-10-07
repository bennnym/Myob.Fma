namespace Myob.Fma.Mastermind.GameServices.Input.Validations.InputValidations
{
    public interface IValidation
    {
        bool IsValid(string userInput);
        string GetErrorMessage();
    }
}