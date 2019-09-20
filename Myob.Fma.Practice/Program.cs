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
            Console.WriteLine(Add("-1,3,-5"));

        }
        
        public static string Add(string input, int indexIHaveLookedAt = 0, string indexes = "")
        {
            if (input.Length == 0)
            {
                return indexes; // base case
            }
            var charachterIAmLookigAt = input[0];
            
            if (charachterIAmLookigAt is '-')
            {
                indexes += indexIHaveLookedAt + " ";
            }
            var newInput = input.Substring(1, input.Length - 1);
            
            return Add(newInput, indexIHaveLookedAt + 1, indexes);
        }
    }
}