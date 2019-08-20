namespace Myob.Fma.GameOfLife
{
    public interface ICell
    {
        bool CellState { get; set; }
        string Symbol { get; set; }
        int NeighboursAlive { get; set; }
        int[] Position { get; set; }
    }
}