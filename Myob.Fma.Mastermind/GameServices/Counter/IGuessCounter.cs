namespace Myob.Fma.Mastermind.GameServices.Counter
{
    public interface IGuessCounter
    {
        void IncrementCount();
        string GetRemainingGuessMessage();
        bool IsGuessLimitExceeded();
    }
}