using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Myob.Fma.Practice.ExtensionMethods;

namespace Myob.Fma.Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>()
            {
                1,2,3,3,5,5,7,6,9,1
            };

            var occurences = list.GroupBy(x => x > 6);
            
            foreach (var occurence in occurences)
            {
                Console.WriteLine($"printing groups of : {occurence.Key}");
                foreach (var item in occurence)
                {
                    Console.WriteLine(item);
                    
                }
            }
        }

        public enum Holidays
        {
            Christmas,
            BlackFriday,
            NewYearsDay,
            BoxingDay
        }

        public enum Discounts
        {
            FullPrice = 100,
            HalfPrice = 50,
            Percent10 = 10,
            Percent30 = 30
        }

        public static string Disemove(string str)
        {
            var vowels = new List<char> {'a', 'e', 'i', 'o', 'u'};
            var stringWithNoVowels = "";

            foreach (var letter in str)
            {
                if (vowels.Contains(char.ToLower(letter)))
                {
                    continue;
                }

                stringWithNoVowels += letter;
            }

            return stringWithNoVowels;
        }

        public static string Tickets(int[] peopleInLine)
        {
            var change = new Dictionary<int, int>();

            foreach (var ticket in peopleInLine)
            {
                if (ticket >= 25)
                {
                    var changeRequired = ticket - 25;
                }
            }

            return "ok";
        }

        public static bool validBraces(String braces)
        {
            var parenthesis = 0;
            var square = 0;
            var curly = 0;

            foreach (var bracket in braces)
            {
                switch (bracket)
                {
                    case '(':
                        parenthesis++;
                        break;
                    case ')':
                        parenthesis--;
                        break;
                    case '{':
                        curly++;
                        break;
                    case '}':
                        curly--;
                        break;
                    case '[':
                        square++;
                        break;
                    case ']':
                        square--;
                        break;
                }
            }

            return 0 == parenthesis && 0 == square && 0 == curly;
        }
    }
}