using System;
using System.Collections.Generic;
using System.Linq;

namespace Myob.Fma.Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<Holidays, Discounts>();

            dict.Add(Holidays.Christmas, Discounts.HalfPrice);

            Console.WriteLine((int)dict[Holidays.Christmas]);

            Console.WriteLine((int)Discounts.FullPrice);
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
    }
}