using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Myob.Fma.GameOfLife
{
    public class Grid
    {
        private readonly ICell[,] _grid;
        private readonly int _aliveCells;
        
        public Grid(int aliveCells, int rows, int columns)
        {
            _grid = new ICell[rows,columns];
            _aliveCells = aliveCells;
        }

        public void PopulateGrid()
        {
            var randomNumbers = GenerateRandomNumbersForAliveCells();
            var cells = _grid.Length;

            for (int i = 1; i <= cells; i++)
            {
                if (randomNumbers.Contains(i))
                {
                    var cell = new Cell(true);
                    var index = ConvertIntToCellIndex(i);
                    cell.Position = index;
                    _grid[index[0],index[1]] = cell;
                }
                else
                {
                    var cell = new Cell(false);
                    var index = ConvertIntToCellIndex(i);
                    cell.Position = index;
                    _grid[index[0], index[1]] = cell;
                }
            }
        }

        public void StartGameOfLife()
        {
            Console.WriteLine();
            PrintGrid();
            UpdateStateOfCells();
            Console.CursorTop -= _grid.GetLength(0) + 1;
            Thread.Sleep(500);
            StartGameOfLife();
        }

        private void PrintGrid()
        {
            var gridSnapshot = new StringBuilder();
            var gridLine = 0;

            foreach (var cell in _grid)
            {
                var cellRow = cell.Position[0];
                
                if (cellRow == gridLine)
                {
                    gridSnapshot.Append(cell.Symbol);
                }
                else
                {
                    gridLine = cellRow;
                    gridSnapshot.AppendLine();
                    gridSnapshot.Append(cell.Symbol);    
                }
            }

            Console.WriteLine(gridSnapshot.ToString());
        }

        private HashSet<int> GenerateRandomNumbersForAliveCells()
        {
            var randomNumbers = new HashSet<int>();
            var upperLimit = _grid.Length + 1;

            while (randomNumbers.Count < _aliveCells )
            {
                var randNumberGenerator = new Random();
                var num = randNumberGenerator.Next(1, upperLimit);
                randomNumbers.Add(num);
            }
            return randomNumbers;
        }

        private int[] ConvertIntToCellIndex(int index)
        {
            var columns = _grid.GetLength(1);
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
            
            return new [] {x,y};
        }

        private void UpdateStateOfCells()
        {
            foreach (var cell in _grid)
            {
                cell.NeighboursAlive = CalculateHowManySurroundingCellsAreAlive(cell.Position);
                ApplyGameOfLifeRules(cell);
            }
        }

        private void ApplyGameOfLifeRules(ICell cell)
        {
            // interface needed!!!!
            
            if (cell.CellState)
            {
                if (cell.NeighboursAlive < 2)
                {
                    cell.CellState = false;
                }
                else if (cell.NeighboursAlive > 3)
                {
                    cell.CellState = false;
                }
            }
            else if (!cell.CellState && cell.NeighboursAlive == 3)
            {
                cell.CellState = true;
            }
            
            cell.Symbol = cell.CellState ? " @ " : " . ";
        }

        private int CalculateHowManySurroundingCellsAreAlive(int[] cellPosition)
        {
            
            var x = cellPosition[0];
            var y = cellPosition[1];
            var yStartingPosition = y - 1;
            var aliveSurroundingCells = 0;
            var gridRows = _grid.GetLength(0);
            var gridCols = _grid.GetLength(1);
            
            // top row surrounding the cell
            for (int i = 0; i < 3; i++)
            {
                var rowPosition = x - 1 < 0 ? gridRows - 1 : x - 1; // upper overflow
                var columnPosition = yStartingPosition + i < 0 ? gridCols - 1 : yStartingPosition + i; // left overflow
                
                columnPosition = yStartingPosition + i > gridCols - 1? 0 : columnPosition; // right overflow

                aliveSurroundingCells += _grid[rowPosition, columnPosition].CellState ? 1 : 0;
            }
            
            // bottom row surrounding the cell
            for (int i = 0; i < 3; i++)
            {
                var rowPosition = x + 1 > gridRows - 1 ? 0 : x + 1; // bottom overflow
                var columnPosition = yStartingPosition + i < 0 ? gridCols - 1 : yStartingPosition + i; // left overflow
                columnPosition = yStartingPosition + i > gridCols - 1 ? 0 : columnPosition; // right overflow

                aliveSurroundingCells += _grid[rowPosition, columnPosition].CellState ? 1 : 0;
            }
            
            // middle row
            for (int i = 0; i < 3; i++)
            {
                var columnPosition = yStartingPosition + i < 0 ? gridCols - 1 : yStartingPosition + i; // left overflow
                columnPosition = yStartingPosition + i > gridCols - 1 ? 0 : columnPosition; // right overflow
                
                if (columnPosition != y)
                {
                    aliveSurroundingCells += _grid[x, columnPosition].CellState ? 1 : 0;
                }
            }
            return aliveSurroundingCells;
        }
        
    }
}