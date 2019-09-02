using System;
using System.Collections.Generic;
using Myob.Fma.CartExceptionsChallenge.Exceptions;
using Myob.Fma.CartExceptionsChallenge.ProductFiles;

namespace Myob.Fma.CartExceptionsChallenge.CartFiles
{
    public class Cart : ICart
    {
        private readonly List<IProduct> _products;

        public Cart()
        {
            _products = new List<IProduct>();
        }

        public void AddProductToCart(IProduct product)
        {
            _products.Add(product);
        }
        public decimal GetCartTotal()
        {
            var cartTotal = 0M;
            
            foreach (var product in _products)
            {
                try
                {
                    cartTotal += ValidateProduct(product);
                }
                catch (ProductCostZeroOrLess e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                
            }

            return cartTotal;
        }

        private decimal ValidateProduct(IProduct product)
        {
            if (product.Cost <= 0M) throw new ProductCostZeroOrLess(product.Name);

            return product.Cost;
        }
    }
}