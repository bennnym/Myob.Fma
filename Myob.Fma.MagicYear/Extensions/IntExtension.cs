using System;

namespace Myob.Fma.MagicYear.Extensions
{
    public static class IntExtension
    {
        public static int Rounding(decimal i)
        {
            var whole = Math.Floor(i);
            var fraction = i - whole;
            
            if (fraction >= 0.50M)
            {
                whole += 1;
            }

            return (int) whole;
        }

    }
}