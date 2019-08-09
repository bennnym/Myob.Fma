using System;

namespace Myob.Fma.Foundational.SumAndProductMathHelpers
{
    public class OperationFromOneToN
    {
        public static string Sum(int number)
        {
            int sum = 0;

            for (var i = 1; i <= number; i++)
            {
                sum += i;
            }

            return $"The total sum from 1 to {number} is {sum}.";
        }

        public static string Product(int number)
        {
            long sum = 1;

            for (var i = 1; i <= number; i++)
            {
                sum *= i;
            }

            return $"The product of all numbers from 1 to {number} are {sum}";
        }
    }
}