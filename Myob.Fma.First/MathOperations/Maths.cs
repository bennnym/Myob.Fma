using System;

namespace Myob.Fma.First.MathOperations
{
    public static class Maths
    {
        public static void Sum(int number)
        {
            int sum = 0;

            for (int i = 1; i <= number; i++)
            {
                sum += i;
            }

            Console.WriteLine($"The total sum from 1 to {number} is {sum}.");
        }

        public static void SumOfThreeOrFive(int number)
        {
            int sum = 0;

            for (int i = 0; i <= number; i++)
            {
                sum += i % 3 == 0 || i % 5 == 0 ? i : 0;
            }

            Console.WriteLine($"The sum of all the multiples of three and five between 1 and {number} are {sum}.");
        }

        public static void Product(int number)
        {
            long sum = 1;

            for (int i = 1; i <= number; i++)
            {
                sum *= i;
            }

            Console.WriteLine($"The product of all numbers from 1 to {number} are {sum}");
        }
    }
}