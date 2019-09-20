namespace Myob.Fma.Mastermind.Utilities
{
    public interface IPatternValidator
    {
        bool IsTheCorrectAmountOfColoursEntered(string userGuess);
    }
}