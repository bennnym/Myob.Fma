using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace Myob.Fma.Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers1 = { 1, 2, 3,3 };
            int[] numbers2 = { 3, 4, 5,3 };

            var result = numbers1.Intersect(numbers2);

            foreach (var num in result)
            {
                Console.WriteLine(num);
            }


        }
        
    }
}