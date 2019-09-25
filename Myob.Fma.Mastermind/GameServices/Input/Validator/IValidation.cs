namespace Myob.Fma.Mastermind.GameServices.Input.Validator
{
    public interface IValidation
    {
        bool IsValid(string userInput);
        string GetErrorMessage();
    }
}