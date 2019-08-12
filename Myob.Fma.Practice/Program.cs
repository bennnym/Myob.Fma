using System;

namespace Myob.Fma.Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Math.Floor(5.6));
        }

        static int Sum(params int[] nums)
        {
            int sum = 0;
            
            foreach (var number in nums)
            {
                sum += number;
            }

            return sum;
        }
    }
}