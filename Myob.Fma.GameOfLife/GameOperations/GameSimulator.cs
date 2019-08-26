using System;
using System.Collections.Generic;
using System.Threading;
using Myob.Fma.GameOfLife.BoardOperations;
using Myob.Fma.GameOfLife.Cells;
using Myob.Fma.GameOfLife.Rules;

namespace Myob.Fma.GameOfLife.GameOperations
{
    public static class GameSimulator
    {
        public static void Play(IGame game)
        {
            if (game.Board.isInitialized)
            {
                Console.WriteLine();
                PrintBoard.Print(game.Board);
                UpdateStateOfGridCells(game);
                Console.CursorTop -= game.Board.Grid.GetLength(0) + 3;
                Thread.Sleep(500);
                Play(game);
            }

            Console.WriteLine("ERROR - please initialize board before playing");
        }

        private static void UpdateStateOfGridCells(IGame game)
        {
            foreach (var cell in game.Board.Grid)
            {
                var cornerPosition = GetCornerIndex(cell.Position, game.Board);
                cell.NeighboursAlive = UpdateNeighbouringCellsAliveCount(game.Board, cell.Position, cornerPosition);
                ApplyRules(cell, game.Rules);
            }
        }

        private static void ApplyRules(ICell cell, IList<IRule> rules)
        {
            foreach (var rule in rules)
            {
                rule.Condition(cell);
                cell.Symbol = cell.CellState ? " @ " : " . ";
            }
        }

        private static int UpdateNeighbouringCellsAliveCount(IBoard board, CellPosition targetCell,
            CellPosition cornerCell,
            int yAdjustment = 0,
            int xAdjustment = 0)
        {
            // change to constant end of line
            const int endOfRowAndEndofColumn = 5;
            const int endOfRow = 3;


            if (yAdjustment + xAdjustment == endOfRowAndEndofColumn)
            {
                return board.Grid[targetCell.XPosition, targetCell.YPosition].CellState ? -1 : 0;
            }

            if (yAdjustment == endOfRow)
            {
                xAdjustment++;
                yAdjustment = 0;
            }

            var x = ProcessXAxis(cornerCell.XPosition + xAdjustment, board.Grid.GetLength(0) - 1);
            var y = ProcessYAxis(cornerCell.YPosition + yAdjustment, board.Grid.GetLength(1) - 1);

            var alive = board.Grid[x, y].CellState ? 1 : 0;
            yAdjustment++;

            return alive + UpdateNeighbouringCellsAliveCount(board, targetCell, cornerCell, yAdjustment, xAdjustment);
        }

        private static int ProcessXAxis(int x, int rows)
        {
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

        private static int ProcessYAxis(int y, int columns)
        {
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

        private static CellPosition GetCornerIndex(CellPosition cell, IBoard board)
        {
            var x = cell.XPosition - 1;
            var y = cell.YPosition - 1;

            return new CellPosition()
            {
                XPosition = ProcessXAxis(x, board.Grid.GetLength(0) - 1),
                YPosition = ProcessYAxis(y,board.Grid.GetLength(1) - 1)
            };
        }
    }
}