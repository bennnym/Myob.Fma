namespace Myob.Fma.Mastermind.GameServices.Counter
{
    public interface IGuessCounter
    {
        void IncrementCount();
        string DisplayMessage { get; }
        bool IsGameOver { get; }
    }
}