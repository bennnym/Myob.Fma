using System;
using System.Linq;

namespace Myob.Fma.Calculator
{
    public class Calculator
    {
        public int Add(params int[] inputs)
        {
            var total = 0;

            foreach (var number in inputs)
            {
                total += number;
            }

            return total;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public bool LargerThan(int x, int y)
        {
            return x > y;
        }
        
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}