using System;
using Myob.Fma.Foundational.ValidationHelpers;

namespace Myob.Fma.Foundational.Games
{
    public class SumIfMultiplesOf3Or5 : IGame
    {
        public string Play()
        {
            Console.WriteLine("Enter a number and I will return the sum of all multiples of 3 or 5 from 1 to N");
            
            var inputNumber = Console.ReadLine();

            if (UserInputValidation.NumberNegativeOrInvalid(inputNumber))
            {
                Console.WriteLine("Please enter a positive number, try again:");
                Play();
            }

            return SumNumbersIfMultiplesOf3Or5(int.Parse(inputNumber));
        }

        private static string SumNumbersIfMultiplesOf3Or5(int limit)
        {
            int sum = 0;

            for (var i = 0; i <= limit; i++)
            {
                sum += i % 3 == 0 || i % 5 == 0 ? i : 0;
            }
            return $"The sum of all the multiples of three and five between 1 and {limit} are {sum}.";
        }
    }
}