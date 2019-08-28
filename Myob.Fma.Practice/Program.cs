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
            var input = @"//[*1*][%]";

            var delimiters = GetDelimiterFromString(input);
            
            



        }
        
        static string GetDelimiterFromString(string inputString)
        {
            var regex = new Regex(@"(?<=\//\[).+(?=\])"); // looks for the pattern //[pattern]\n

            var matches = regex.Matches(inputString);

            if (matches.Any())        
            {
                return matches.First().ToString();
            }

            var indexOfLineBreak = inputString.IndexOf('\n');

            return inputString[indexOfLineBreak - 1].ToString();
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