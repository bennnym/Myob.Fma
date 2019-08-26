using System;
using System.Text;

namespace Myob.Fma.GameOfLife.BoardOperations
{
    public static class PrintBoard
    {
        public static void Print(IBoard board)
        {
            var gridImage = new StringBuilder();
            var gridLine = 0;

            foreach (var cell in board.Grid)
            {
                var cellRow = cell.Position.XPosition;

                if (cellRow != gridLine)
                {
                    gridLine = cellRow;
                    gridImage.AppendLine();
                }

                gridImage.Append(cell.Symbol);
            }

            gridImage.AppendLine();
            gridImage.AppendLine();

            Console.WriteLine(gridImage.ToString());
        }
    }
}