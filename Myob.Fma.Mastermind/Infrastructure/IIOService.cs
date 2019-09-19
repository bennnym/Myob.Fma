namespace Myob.Fma.Mastermind.Infrastructure
{
    public interface IIoService
    {
        void DisplayOutput(string message);
        string GetUserInput();
    }
}