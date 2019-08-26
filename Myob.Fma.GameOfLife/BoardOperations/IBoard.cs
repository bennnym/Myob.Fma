using Myob.Fma.GameOfLife.Cells;

namespace Myob.Fma.GameOfLife.BoardOperations
{
    public interface IBoard
    {
        ICell[,] Grid { get; }
        bool isInitialized { get; }
        int StartingAliveCells { get; }
    }
}