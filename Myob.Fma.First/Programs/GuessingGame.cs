using System;
using System.Collections.Generic;

namespace Myob.Fma.First.Programs
{
    public class GuessingGame
    {
        private readonly HashSet<int> _guesses;
        private bool Success;
        private int SecretNumber;
        
        public GuessingGame()
        {
            _guesses = new HashSet<int>();
            
            var random = new Random();
            SecretNumber = random.Next(0, 100);
            
            GameLoop();

            Console.WriteLine($"You guessed the magic number in {_guesses.Count} guesses, well done!");
        }

        public void GameLoop()
        {
            Console.WriteLine("I have chosen a number inbetween 1 and 100, see if you can guess it... ");
            Console.WriteLine("I will give you hints along the way!");
            
            while (!Success)
            {

                Console.WriteLine("Enter a number to guess:");

                var validInput = int.TryParse(Console.ReadLine(), out int guess);
                
                if ( !validInput ) throw new ArgumentException("You must enter a valid number");

                _guesses.Add(guess);

                Hint(guess);
            }
        }

        public void Hint(int guess)
        {
            if (guess > SecretNumber)
            {
                Console.WriteLine("Guess is too high, try a lower number.");
            }
            else if (guess < SecretNumber)
            {
                Console.WriteLine("Guess is too low, try a higher number.");
            }
            else
            {
                Success = true;
            }
        }
    }
}