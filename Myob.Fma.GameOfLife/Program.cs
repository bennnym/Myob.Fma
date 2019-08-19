using System;
using Myob.Fma.GameOfLife.Validation;

//https://stackoverflow.com/questions/12826760/printing-2d-array-in-matrix-format
//https://stackoverflow.com/questions/888533/how-can-i-update-the-current-line-in-a-c-sharp-windows-console-app
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays


namespace Myob.Fma.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInputs = PerformChecksOnUserInput(args);

            if (Validate.InputIsValid(userInputs))
            {
                // start game;
                Console.WriteLine("This was valid");
            }
            else
            {
                Console.WriteLine("Invalid Input:");
                Console.WriteLine("Input needs to be in the format of 'number of live cells' 'rows' 'columns'");
            }

        }

        static int[] PerformChecksOnUserInput(string[] userArgs)
        {
            var liveCellsInt = Validate.ConvertStringsToNumbers(userArgs[0]);
            var rowsInt = Validate.ConvertStringsToNumbers(userArgs[1]);
            var columnsInt = Validate.ConvertStringsToNumbers(userArgs[2]);

            return new [] {liveCellsInt, rowsInt, columnsInt};
        }
    }
}