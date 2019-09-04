using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Myob.Fma.Yatzy.Dice_Files;
using Myob.Fma.Yatzy.Enums;
using Myob.Fma.Yatzy.Scoring;

namespace Myob.Fma.Yatzy
{
    class Program
    {
        static void Main(string[] args)
        {

            var list = new List<int>
            {
                2, 4, 6, 8
            };

            Console.WriteLine(OddOne(list));
        }
        
        public static int OddOne(List<int> list)
        {
            return list.FindIndex(x => Math.Abs(x % 2) == 1);

        }
      
        
       
    }
}