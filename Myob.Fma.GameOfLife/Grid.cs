using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Myob.Fma.GameOfLife.Rules;

namespace Myob.Fma.GameOfLife
{
    public class Grid
    {
        private readonly ICell[,] _grid;
        private readonly int _aliveStartingCells;
        private readonly IList<IRule> _rules;
        private int _aliveCells;
        private int _deadCells;


        public Grid(int aliveStartingCells, int rows, int columns, IList<IRule> rules)
        {
            _grid = new ICell[rows, columns];
            _aliveStartingCells = aliveStartingCells;
            _rules = rules;
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
                    _grid[index[0], index[1]] = cell;
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
            UpdateStateOfGridCells();
            Console.CursorTop -= _grid.GetLength(0) + 4;
            Thread.Sleep(500);
            StartGameOfLife();
        }

        private void PrintGrid()
        {
            var gridImage = new StringBuilder();
            var gridLine = 0;

            foreach (var cell in _grid)
            {
                var cellRow = cell.Position[0];

                if (cellRow == gridLine)
                {
                    gridImage.Append(cell.Symbol);
                }
                else
                {
                    gridLine = cellRow;
                    gridImage.AppendLine();
                    gridImage.Append(cell.Symbol);
                }
            }

            gridImage.AppendLine();
            gridImage.AppendLine();
            gridImage.Append($"Life Count: {_aliveCells}");
            gridImage.AppendLine();
            gridImage.Append($"Death Count: {_deadCells}");

            Console.WriteLine(gridImage.ToString());
        }

        private HashSet<int> GenerateRandomNumbersForAliveCells()
        {
            var randomNumbers = new HashSet<int>();
            var upperLimit = _grid.Length + 1;

            while (randomNumbers.Count < _aliveStartingCells)
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

            return new[] {x, y};
        }

        private void UpdateStateOfGridCells()
        {
            var cellLifeCount = 0;
            
            foreach (var cell in _grid)
            {
                var cornerPosition = GetCornerIndex(cell.Position);
                cell.NeighboursAlive = UpdateNeighbouringCellsAliveCount(cell.Position, cornerPosition);
                ApplyeRules(cell);
                cellLifeCount += cell.CellState ? 1 : 0;
            }

            _aliveCells = cellLifeCount;
            _deadCells = (_grid.GetLength(0) * _grid.GetLength(1)) - _aliveCells;
        }

        private void ApplyeRules(ICell cell)
        {
            foreach (var rule in _rules)
            {
                rule.Condition(cell);
                cell.Symbol = cell.CellState ? " @ " : " . ";
            }
        }

        private int UpdateNeighbouringCellsAliveCount(int[] targetCell, int[] cornerPosition, int yAdjustment = 0,
            int xAdjustment = 0)
        {
            if (yAdjustment == 3 && xAdjustment == 2)
            {
                return _grid[targetCell[0], targetCell[1]].CellState ? -1 : 0;
            }

            if (yAdjustment == 3)
            {
                xAdjustment++;
                yAdjustment = 0;
            }

            var x = ProcessXAxis(cornerPosition[0] + xAdjustment);
            var y = ProcessYAxis(cornerPosition[1] + yAdjustment);

            var alive = _grid[x, y].CellState ? 1 : 0;
            yAdjustment++;

            return alive + UpdateNeighbouringCellsAliveCount(targetCell, cornerPosition, yAdjustment, xAdjustment);
        }

        private int ProcessXAxis(int x)
        {
            var rows = _grid.GetLength(0) - 1;
            if (x < 0)
            {
                return rows;
            }

            if (x > rows)
            {
                return x - rows - 1;
            }

            return x;
        }

        private int ProcessYAxis(int y)
        {
            var columns = _grid.GetLength(1) - 1;
            if (y < 0)
            {
                return columns;
            }

            if (y > columns)
            {
                return y - columns - 1;
            }

            return y;
        }

        private int[] GetCornerIndex(int[] cellPosition)
        {
            var x = cellPosition[0] - 1;
            var y = cellPosition[1] - 1;

            return new[] {ProcessXAxis(x), ProcessYAxis(y)};
        }
    }
}