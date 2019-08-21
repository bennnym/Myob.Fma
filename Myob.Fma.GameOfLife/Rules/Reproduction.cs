namespace Myob.Fma.GameOfLife.Rules
{
    public class Reproduction : IRule
    {
        public void Condition(ICell cell)
        {
            if (!cell.CellState && cell.NeighboursAlive == 3)
            {
                cell.CellState = true;
            }
        }
    }
}