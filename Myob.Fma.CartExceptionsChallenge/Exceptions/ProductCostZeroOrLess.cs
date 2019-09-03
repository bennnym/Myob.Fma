using System;

namespace Myob.Fma.CartExceptionsChallenge.Exceptions
{
    public class ProductCostZeroOrLessException : Exception
    {
        public ProductCostZeroOrLessException(string productName)
        {
            ProductName = productName;
        }

        public readonly string ProductName;
    }
}