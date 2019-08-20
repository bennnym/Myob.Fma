using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Myob.Fma.Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var array2D = new int[5, 5] {{1,2,3,4,5},{6,7,8,9,10},{11,12,13,14,15},{16,17,18,19,20},{21,22,23,24,25}};
            
            var hashSet = new HashSet<int[]>();

            var testing = new int[5, 10];
            int i = 0;

            Console.WriteLine(array2D[-1,4]);


//            Console.WriteLine(array2D.GetLength(1));


//            string longWord = string.Empty;
//
//            for (int i = 0; i < 100; i++)
//            {

//                longWord += i.ToString();
//            }
//            
////            Console.WriteLine(array2D[3,1]);
//            Console.WriteLine(longWord);
//
//
//            foreach (var letter in longWord)
//            {
//                Thread.Sleep(1000);
//                Console.WriteLine();
//                Console.WriteLine($"doing something here");
//                Console.WriteLine($"{letter}");
//                Console.WriteLine($"doing something here");
//                Console.CursorTop -= 4;
//            }
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