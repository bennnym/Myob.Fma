using System;
using System.Collections.Generic;
using Myob.Fma.GameOfLife.BoardOperations;
using Myob.Fma.GameOfLife.GameOperations;
using Myob.Fma.GameOfLife.Rules;
using Myob.Fma.GameOfLife.RandomNumbers;

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

            var gameRules = new List<IRule>
            {
                new OverPopulation(),
                new Reproduction(),
                new UnderPopulation()
            };

            var randomCellPositions = NumberGenerator.Random(userInputs);

            Board board = new Board(userInputs);
            board.Initialize(randomCellPositions);

            Game game = new Game(board, gameRules);
            
            GameSimulator.Play(game);
        }
    }
}