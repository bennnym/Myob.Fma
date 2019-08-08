using System;
using Myob.Fma.First.MathOperations;

namespace Myob.Fma.First.Programs
{
    public class SumOrProduct
    {
        public SumOrProduct()
        {
            Console.WriteLine("Enter any number");

            var validInput = int.TryParse(Console.ReadLine(), out int number);
            
            if ( !validInput ) throw new ArgumentException("You must enter a valid number.");

            Console.WriteLine("For the sum of all numbers from 1 to n, enter [ s ]");
            Console.WriteLine("For the product of all numbers from 1 to n, enter [ p ]");
            Console.WriteLine("enter ( s / p ) :");
            
            var operation = ValidateInput(Console.ReadLine().Trim().ToLower());

            if (operation == "s")
            {
                Maths.Sum(number);
            }
            else
            {
                Maths.Product(number);
            }

        }

        public string ValidateInput(string userInput)
        {
            if (userInput != "p" && userInput != "s")
            {
                throw new ArgumentOutOfRangeException("The only valid input is [s] or [p]");
            }

            return userInput;
        }

    }
}