using System;
using System.Collections.Generic;
using Myob.Fma.GameOfLife.Rules;
using Myob.Fma.GameOfLife.Validation;

//https://stackoverflow.com/questions/12826760/printing-2d-array-in-matrix-format
//https://stackoverflow.com/questions/888533/how-can-i-update-the-current-line-in-a-c-sharp-windows-console-app
//https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/multidimensional-arrays
//https://stackoverflow.com/questions/19596132/how-to-move-console-cursor-up

namespace Myob.Fma.GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInputs = UserInputs.GenerateUserInput(args);

//            if (Validate.InputIsValid(userInputs))
//            {
                // start game;
                var rule1 = new OverPopulation();
                var rule2 = new Reproduction();
                var rule3 = new UnderPopulation();
                var gameRules = new List<IRule> {rule1, rule2, rule3};
                
                var grid = new Grid(userInputs.Lives, userInputs.Rows, userInputs.Columns, gameRules);
                grid.PopulateGrid();
                grid.StartGameOfLife();

//            }
//            else
//            {
//                Console.ForegroundColor = ConsoleColor.Red;
//                Console.WriteLine("Invalid Input:");
//                Console.WriteLine("Input needs to be in the format: 'number of live cells' 'rows' 'columns'");
//                Console.WriteLine($"Hint: Input must be a number greater than zero");
//                Console.WriteLine($"Hint: Number of live cells can not be larger than (rows * columns)");
//            }
        }    
    }
}