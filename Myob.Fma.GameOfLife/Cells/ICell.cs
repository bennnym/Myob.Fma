namespace Myob.Fma.GameOfLife.Cells
{
    public interface ICell
    {
        bool CellState { get; set; }
        string Symbol { get; set; }
        int NeighboursAlive { get; set; }
        CellPosition Position { get; }
    }
}