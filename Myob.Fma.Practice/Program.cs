using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace Myob.Fma.Practice
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxMultiply(2, 7));


        }
        
        public static int MaxMultiply(int divisor, int bound)
        {
            int maxMultiple = 0;
            int counter = divisor;
            
            while (counter <= bound)
            {
                if (counter % divisor == 0) maxMultiple = counter;

                counter++;
            }

            return maxMultiple;
        }
    }
}