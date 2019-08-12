using System;

namespace Myob.Fma.ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            var deo = new Product("deodorant", "lynx", 4.99M);
            var bread = new Product("bread", "Helgas", 12.99M);
            
            var cart = new Cart();
            
            cart.AddProductToCart(deo);
            cart.AddProductToCart(bread);

            Console.WriteLine(cart.CartTotal());
            Console.WriteLine(cart.GetGst());
            Console.WriteLine(cart.GetPriceExGst());
            Console.WriteLine(cart.ShippingCost());

            Console.WriteLine(cart.ApplyCartDiscount(50));

            Console.WriteLine(cart.CartTotal());




        }
    }
}