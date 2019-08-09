using System;
using Myob.Fma.First.MathOperations;

namespace Myob.Fma.First.Programs
{
    public class SumToN : IGame
    {
        public void Play()
        {
            Console.WriteLine("Pick a number, any number and I will sum all the numbers from 1 to N!");
            
            var validInput =  int.TryParse(Console.ReadLine(), out int number);

            if ( number <= 1 || !validInput )
                throw new ArgumentException("Entry must be a number and must be greater than 1");
            
            Maths.Sum(number);
        }
    }
}