using System;
using System.Collections.Generic;
using Myob.Fma.CartExceptionsChallenge.Exceptions;
using Myob.Fma.CartExceptionsChallenge.ProductFiles;

namespace Myob.Fma.CartExceptionsChallenge.CartFiles
{
    public class Cart : ICart
    {
        private readonly IInventory _inventory;
        private readonly IShipping _shipping;
        private readonly List<IProduct> _products;

        public Cart(IInventory inventory, IShipping shipping)
        {
            _inventory = inventory;
            _shipping = shipping;
            _products = new List<IProduct>();
        }

        public void AddProductToCart(IProduct product)
        {
            if (_inventory.CheckStockLevel(product) == 0)
                throw new Exception("Stock Level Too Low");
            
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
                    _shipping.CreateShippingRequest();
                }
                catch (ProductCostZeroOrLessException e)
                {
                    Console.WriteLine(
                        $"The price entered for the item {e.ProductName} was less than or equal to zero. " +
                        "All product prices need to be larger than 0.");
                    throw;
                }
            }

            return cartTotal;
        }

        private decimal ValidateProduct(IProduct product)
        {
            if (product.Cost <= 0M) throw new ProductCostZeroOrLessException(product.Name);

            return product.Cost;
        }
    }
}