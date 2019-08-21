namespace Myob.Fma.GameOfLife.Rules
{
    public interface IRule
    {
        void Condition(ICell cell);
    }
}