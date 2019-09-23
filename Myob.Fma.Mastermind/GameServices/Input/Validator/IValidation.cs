namespace Myob.Fma.Mastermind.GameServices.Input.Validator
{
    public interface IValidation
    {
        bool IsNotValid(string userInput);
        string GetErrorMessage();
    }
}