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
            var tester = "//[*1*][%]\n1*1*2%3";

            var update = tester.Replace("//", "YOLO");

            var regexSearch = new Regex(@"(?<=\])(\n).*");

            var match = regexSearch.Match(tester);

            Console.WriteLine(match);




        }
    }
}