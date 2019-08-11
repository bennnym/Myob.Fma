using System;
using Myob.Fma.Foundational.ValidationHelpers;


namespace Myob.Fma.Foundational
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args[0] == "game")
            {
                PlayAnyGame();
            }
            else if (args[0].Length > 0)
            {
                UserDefinedGame(args[0]);
            }
            else 
            {
                Console.WriteLine("Invalid game selection");
            }
        }

        private static void PlayAnyGame()
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

        private static void UserDefinedGame(string gameSelection)
        {
            var validInput = UserInputValidation.GameSelectionCheck(gameSelection);

            if (!validInput)
            {
                Console.WriteLine("Invalid game selection");
            }
            else
            {
                var game = new Game();
                var gameChoice = game.Start(int.Parse(gameSelection));

                Console.WriteLine(gameChoice.Play());
            }
        }
    }
}