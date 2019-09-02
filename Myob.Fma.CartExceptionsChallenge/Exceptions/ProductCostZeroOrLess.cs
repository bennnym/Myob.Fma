using System;

namespace Myob.Fma.CartExceptionsChallenge.Exceptions
{
    public class ProductCostZeroOrLess : Exception
    {
        private readonly string _productName;

        public ProductCostZeroOrLess(string productName)
        {
            _productName = productName;
        }
    }
}