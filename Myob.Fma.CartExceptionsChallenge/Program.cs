using System;
using Myob.Fma.CartExceptionsChallenge.CartFiles;
using Myob.Fma.CartExceptionsChallenge.ProductFiles;

namespace Myob.Fma.CartExceptionsChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            StandardMessages.Welcome();

            var cart = new Cart();

            var customerIsAddingProducts = true;

            while (customerIsAddingProducts)
            {
                var productName = StandardMessages.CaptureUserData("product name");
                var productCost = StandardMessages.CaptureUserData("product price");

                customerIsAddingProducts = StandardMessages.AskIfTheyWantToContinue();

                var product = new Product(productCost, productName);

                cart.AddProductToCart(product);
            }

            Console.WriteLine(cart.GetCartTotal());
        }
    }
}