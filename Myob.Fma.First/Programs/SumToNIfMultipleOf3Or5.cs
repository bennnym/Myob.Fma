using System;
using Myob.Fma.First.MathOperations;

namespace Myob.Fma.First.Programs
{
    public class SumToNIfMultipleOf3Or5
    {
        public SumToNIfMultipleOf3Or5()
        {
            Console.WriteLine("Enter a number and I will return the sum of all multiples of 3 or 5 from 1 to N");
            
            var validInput = int.TryParse(Console.ReadLine(), out int number);
            
            if ( number <= 1 || !validInput ) throw new ArgumentException("a number must be entered and it must be greater than 1");

            Maths.SumOfThreeOrFive(number);
        }
    }
}