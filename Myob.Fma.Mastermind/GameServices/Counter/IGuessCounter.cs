namespace Myob.Fma.Mastermind.GameServices.Counter
{
    public interface IGuessCounter
    {
        void IncrementCount();
        string RemainingGuessesMessage { get; }
        bool IsGuessLimitExceeded { get; }
    }
}