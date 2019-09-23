namespace Myob.Fma.Mastermind.Utilities
{
    public interface IValidation
    {
        bool IsValid(string userInput);
        string GetErrorMessage();
    }
}