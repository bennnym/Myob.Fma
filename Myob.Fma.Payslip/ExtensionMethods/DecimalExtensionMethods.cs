using System;

namespace Myob.Fma.Payslip.ExtensionMethods
{
    public static class DecimalExtensionMethods
    {
        public static int Rounding(this decimal value)
        {
            var wholeNumber = (int)Math.Floor(value);
            var remainder = value - wholeNumber;

            var rounding = remainder >= 0.5M ? 1 : 0;

            return wholeNumber + rounding;
        }
    }
}