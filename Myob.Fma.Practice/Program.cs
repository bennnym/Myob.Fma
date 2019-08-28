using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Myob.Fma.Practice.ExtensionMethods;

namespace Myob.Fma.Practice
{
    //https://www.codewars.com/kata/52742f58faf5485cae000b9a
    class Program
    {
//        [1, 1, 2] ==> 2
//        [17, 17, 3, 17, 17, 17, 17] ==> 3
        static void Main(string[] args)
        {
            var delimiters = new List<string> {"***","---"};

            Console.WriteLine(PatternConstructor(delimiters));
            
            
          
        }
        
        static string PatternConstructor(List<string> delimiters)
        {
            var pattern = "(?<=";

            for (int i = 0; i < delimiters.Count(); i++)
            {
                if (i == delimiters.Count() - 1)
                {
                    pattern += $@"[{delimiters[i]}])-?\d+";
                }
                else
                {
                    pattern += $"[{delimiters[i]}]|";
                }
            }

            return pattern;
        }

    }

    public enum Duration
    {
        Minute = 60,
        Hour = 3600,
        Day = 86400,
        Month = 31536000
    }
}