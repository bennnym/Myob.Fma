using System;

namespace Myob.Fma.Calculator
{
    public class CartException : Exception
    {
        private readonly string _cartId;
        public CartException(string cartId)
        {
            _cartId = cartId;
        }
    }
}