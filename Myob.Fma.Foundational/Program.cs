using System;
using Myob.Fma.Foundational.Games;
using Myob.Fma.Foundational.ValidationHelpers;

namespace Myob.Fma.Foundational
{
    class Program
    {
        static void Main(string[] args)
        {
            var play = true;

            while (play)
            {
                var game = new Game();
                game.Intro();
            
                var gameNumberSelection = game.GetUserGameSelection();
            
                var gameChoice = game.Start(gameNumberSelection);

                Console.WriteLine(gameChoice.Play());

                play = game.PlayAgain();
            }
        }
    }
}