using System.Collections.Generic;

namespace Myob.Fma.ShoppingCart
{
    public class Cart
    {
        protected readonly List<IProduct> _products;

        public Cart()
        {
            _products = new List<IProduct>();
        }

        public decimal CartDiscount { get; private set; }

        public void AddProductToCart(IProduct product)
        {
            _products.Add(product);
        }

        public void ApplyCartDiscount(int discountPercentage)
        {
            var cartTotal = GetCartTotal();

            var updatedCart = cartTotal - (-cartTotal * (discountPercentage / 100M));

            CartDiscount = decimal.Round(updatedCart, 2);
        }

        public virtual string GetAllProductDescriptions()
        {
            var products = string.Empty;

            foreach (var product in _products)
            {
                products += $"{product}\n";
            }

            return products;
        }

        public decimal GetCartTotal()
        {
            decimal sum = 0;

//            _products.ForEach(item => sum += ApplyProductDiscount(item));
            
            foreach (var product in _products)
            {
                sum += product.Price - CalculateProductDiscount(product);
            }
            
            return sum - CartDiscount;
        }
        
        private decimal CalculateProductDiscount(IProduct product)
        {
            return decimal.Round(product.Price * (product.DiscountPercentage / 100M), 2);
        }


        public decimal GetPriceExGst()
        {
            var cartTotal = GetCartTotal();

            var exGst = (cartTotal / 110) * 100;

            return decimal.Round(exGst, 2);
        }

        public decimal GetGst()
        {
            var cartTotal = GetCartTotal();

            var gst = (cartTotal / 110) * 10;

            return decimal.Round(gst, 2);
        }

        public decimal ShippingCost()
        {
            if (GetCartTotal() > 50)
            {
                return 0;
            }

            return 24.99M;
        }
    }
}