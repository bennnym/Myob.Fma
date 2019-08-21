namespace Myob.Fma.GameOfLife.Rules
{
    public class UnderPopulation : IRule
    {
        public void Condition(ICell cell)
        {
            if (cell.CellState && cell.NeighboursAlive < 2)
            {
                cell.CellState = false;
            }
        }
    }
}