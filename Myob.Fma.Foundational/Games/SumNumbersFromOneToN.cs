using System;
using Myob.Fma.Foundational.SumAndProductMathHelpers;
using Myob.Fma.Foundational.ValidationHelpers;

namespace Myob.Fma.Foundational.Games
{
    public class SumNumbersFromOneToN : IGame
    {
        public string Play()
        {
            Console.WriteLine("Pick a number, any number and I will sum all the numbers from 1 to N!");
            
            var inputNumber = Console.ReadLine();

            if (UserInputValidation.NumberNegativeOrInvalid(inputNumber))
            {
                Console.WriteLine("Please enter a positive number, try again:");
                Play();
            }

            return OperationFromOneToN.Sum(int.Parse(inputNumber));
        }
    }
}