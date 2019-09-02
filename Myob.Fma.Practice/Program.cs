using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Myob.Fma.Practice
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter something");
            
            var input = Console.ReadLine();

            Console.WriteLine(input == "5");


        }

        public static bool TestForSquares(IEnumerable<int> numbers, IEnumerable<int> squares)
        {
            return numbers.Select(_ => _ * _).SequenceEqual(squares);
        }

        public static int TripleDouble(long num1, long num2)
        {
            var triples = num1.ToString().GroupBy(i => i).Where(g => g.Count() == 3);
            var lookForDoubles = num2.ToString();

            var found = 0;

            foreach (var triple in triples)
            {
                var lookingFor = new string(triple.Key, 2);

                if (lookForDoubles.Contains(lookingFor)) return 1;
            }

            return found;
        }
    }
}