using System.Collections.Generic;
using Myob.Fma.GameOfLife.Cells;

namespace Myob.Fma.GameOfLife.BoardOperations
{
    public class Board : IBoard
    {
        public ICell[,] Grid { get; private set; }
        public int StartingAliveCells { get; private set; }

        public bool isInitialized { get; private set; }

        public Board(UserInputs userInputs)
        {
            Grid = new ICell[userInputs.Rows, userInputs.Columns];
            StartingAliveCells = userInputs.Lives;
        }

        public void Initialize(HashSet<int> randomAliveCellPositions)
        {
            var cellsToFill = Grid.Length;

            for (var i = 1; i <= cellsToFill; i++)
            {
                SetCellState(Grid, i, randomAliveCellPositions.Contains(i));
            }

            isInitialized = true;
        }
        
        private void SetCellState(ICell[,] grid, int cellPosition, bool isAlive)
        {
            var cell = new Cell(isAlive);
            var index = ConvertIntToCellPosition(grid.GetLength(1),cellPosition);
            cell.Position = index;
            grid[index.XPosition, index.YPosition] = cell;
        }
        
        private CellPosition ConvertIntToCellPosition(int columns, int index)
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