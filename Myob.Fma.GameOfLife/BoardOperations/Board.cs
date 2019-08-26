using Myob.Fma.GameOfLife.Cells;

namespace Myob.Fma.GameOfLife.BoardOperations
{
    public class Board : IBoard
    {
        public ICell[,] Grid { get; private set; }
        public int StartingAliveCells { get; private set; }
        
        public static Board Create(UserInputs userInputs)
        {
            return new Board()
            {
                Grid = new ICell[userInputs.Rows,userInputs.Columns],
                StartingAliveCells = userInputs.Lives
            };
        }
    }
}