using System;

namespace Myob.Fma.FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz();
        }

        static void FizzBuzz()
        {
            for (int i = 1; i < 100; i++)
            {
                if (IsDivisibleByThreeAndFive(i))
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (IsDivisibleByThree(i))
                {
                    Console.WriteLine("Fizz");
                }
                else if (IsDivisibleByFive(i))
                {
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool IsDivisibleByThreeAndFive(int number)
        {
            return number % 3 == 0 && number % 5 == 0;
        }

        static bool IsDivisibleByThree(int number)
        {
            return number % 3 == 0;
        }
        
        static bool IsDivisibleByFive(int number)
        {
            return number % 5 == 0;
        }
    }
}