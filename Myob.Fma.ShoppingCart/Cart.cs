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
            var cartTotal = CartTotal();

            var updatedCart = cartTotal - (cartTotal * (discountPercentage / 100M));

            return decimal.Round(updatedCart, 2);
        }

        public decimal CartTotal()
        {
            decimal sum = 0;

            _cart.ForEach(item => sum += (item.Price - item.Discount));
            
            return sum;
        }


        public decimal GetPriceExGst()
        {
            var cartTotal = CartTotal();

            var exGst = (cartTotal / 110) * 100;

            return decimal.Round(exGst, 2);
        }

        public decimal GetGst()
        {
            var cartTotal = CartTotal();

            var gst = (cartTotal / 110) * 10;

            return decimal.Round(gst, 2);
        }

        public decimal ShippingCost()
        {
            if (CartTotal() > 50)
            {
                return 0;
            }

            return 24.99M;
        }
    }
}