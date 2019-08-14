using System;
using Myob.Fma.ShoppingCart.Enums;

namespace Myob.Fma.ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {
            var deodorant = new Product("deodorant", "lynx", 4.99M);
            var bread = new Product("bread", "Helgas", 12.99M, 100);


            var cart = new Cart();

//            Console.WriteLine(deo.DiscountPercentage); // discount is 0%
//            
//            deo.UpdateOffers(Holidays.NewYearsDay, AppliedDiscount.HalfPrice);
//            
//            deo.UpdateDailyOfferDiscount(DateTime.Now);
//
//            Console.WriteLine(deo.DiscountPercentage);

            cart.AddProductToCart(deodorant);
            cart.AddProductToCart(bread);
            Console.WriteLine($"cart total before discount: {cart.GetCartTotal()}");

//            Console.WriteLine(cart.GetCartTotal());
//
//            Console.WriteLine($"bread discount : {bread.DiscountPercentage}");

            cart.ApplyCartDiscount(50);
            Console.WriteLine($"cart total after discount: {cart.GetCartTotal()}");


//            cart.AddProductToCart(deo);
//            cart.AddProductToCart(bread);
//
//            Console.WriteLine(cart.GetCartTotal());
//            Console.WriteLine(cart.GetGst());
//            Console.WriteLine(cart.GetPriceExGst());
//            Console.WriteLine(cart.ShippingCost());
//
//            Console.WriteLine(cart.ApplyCartDiscount(50));
//
//            Console.WriteLine(cart.GetCartTotal());
        }
    }
}