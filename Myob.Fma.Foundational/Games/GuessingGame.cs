using System;
using System.Collections.Generic;

namespace Myob.Fma.Foundational.Games
{
    public class GuessingGame : IGame
    {
            private readonly HashSet<int> _guesses;
            private bool _success;
            private readonly int _secretNumber;
            
            public GuessingGame()
            {
                _guesses = new HashSet<int>();
            
                var random = new Random();
                _secretNumber = random.Next(0, 100);
            
                Play();
            }

            public string Play()
            {
                Console.WriteLine("I have chosen a number inbetween 1 and 100, see if you can guess it... ");
                Console.WriteLine("I will give you hints along the way!");
            
                while (!_success)
                {

                    Console.WriteLine("Enter a number to guess:");

                    var validInput = int.TryParse(Console.ReadLine(), out int guess);
                
                    if ( !validInput ) throw new ArgumentException("You must enter a valid number");

                    _guesses.Add(guess);

                    Hint(guess);
                }

                return $"You guessed the magic number in {_guesses.Count} guesses, well done!";
            }

            private void Hint(int guess)
            {
                if (guess > _secretNumber)
                {
                    Console.WriteLine("Guess is too high, try a lower number.");
                }
                else if (guess < _secretNumber)
                {
                    Console.WriteLine("Guess is too low, try a higher number.");
                }
                else
                {
                    _success = true;
                }
            }
            
    }
}
