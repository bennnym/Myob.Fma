using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Myob.Fma.Practice.ExtensionMethods;

namespace Myob.Fma.Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = new string[] {"hello", "my", "name", "is", "ben"};

            var changedWords = words.Where(s => s.Contains('e')).OrderBy(w => w).Last();

            Console.WriteLine(changedWords);

        }

        public static bool TestForSquares(IEnumerable<int> numbers, IEnumerable<int> squares)
        {
            return numbers.Select(_ => _ * _).SequenceEqual(squares);

        }
        
        public static string GetTheLastWord(IEnumerable<string> words)
        {
            var result = words
                .Where(s => s.Contains('e'))
                .OrderBy(w => w);

            return "0";
        }
    }
}