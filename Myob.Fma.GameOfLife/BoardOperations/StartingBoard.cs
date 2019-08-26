using System.Collections.Generic;
using Myob.Fma.GameOfLife.Cells;

namespace Myob.Fma.GameOfLife.BoardOperations
{
    public static class StartingBoard
    {
        public static void SetUpBoard(IBoard board, HashSet<int> randomAliveCellPositions)
        {
            var cells = board.Grid.Length;

            for (var i = 1; i <= cells; i++)
            {
                SetCellState(board, i, randomAliveCellPositions.Contains(i));
            }
        }
        
        private static void SetCellState(IBoard board, int cellPosition, bool isAlive)
        {
            var cell = new Cell(isAlive);
            var index = ConvertIntToCellPosition(board.Grid.GetLength(1),cellPosition);
            cell.Position = index;
            board.Grid[index.XPosition, index.YPosition] = cell;
        }
        
        private static CellPosition ConvertIntToCellPosition(int columns, int index)
        {
            int x;
            int y;

            if (index % columns != 0)
            {
                x = index / columns;
                y = (index % columns) - 1;
            }
            else
            {
                x = (index / columns) - 1;
                y = columns - 1;
            }

            return new CellPosition()
            {
                XPosition = x,
                YPosition = y
            };
        }
    }
}