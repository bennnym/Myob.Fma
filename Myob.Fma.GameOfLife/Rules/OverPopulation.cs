namespace Myob.Fma.GameOfLife.Rules
{
    public class OverPopulation : IRule    
    {
        public void Condition(ICell cell)
        {
            if (cell.CellState && cell.NeighboursAlive > 3)
            {
                cell.CellState = false;
            }
        }
    }
}