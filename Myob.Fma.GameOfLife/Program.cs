using System;
using System.Collections.Generic;
using Myob.Fma.GameOfLife.Rules;

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
            
                var rule1 = new OverPopulation();
                var rule2 = new Reproduction();
                var rule3 = new UnderPopulation();
                var gameRules = new List<IRule> {rule1, rule2, rule3};
                
                var grid = new Grid(userInputs.Lives, userInputs.Rows, userInputs.Columns, gameRules);
                grid.PopulateGrid();
                grid.StartGameOfLife();

        }    
    }
}