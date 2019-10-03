namespace Myob.Fma.Mastermind.GameServices.Input.Validations
{
    public interface IValidation
    {
        bool IsValid(string userInput);
        string GetErrorMessage();
    }
}