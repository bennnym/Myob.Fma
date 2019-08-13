using System.Collections.Generic;

namespace Myob.Fma.ShoppingCart
{
    public class Cart
    {
        private readonly List<IProduct> _cart;

        public Cart()
        {
            _cart = new List<IProduct>();
        }

        public void AddProductToCart(IProduct product)
        {
            _cart.Add(product);
        }

        public decimal ApplyCartDiscount(int discountPercentage)
        {
            var cartTotal = GetCartTotal();

            var updatedCart = cartTotal - (cartTotal * (discountPercentage / 100M));

            return decimal.Round(updatedCart, 2);
        }

        public decimal GetCartTotal()
        {
            decimal sum = 0;

            _cart.ForEach(item => sum += ApplyProductDiscount(item));
            
            return sum;
        }
        
        private decimal ApplyProductDiscount(IProduct product)
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