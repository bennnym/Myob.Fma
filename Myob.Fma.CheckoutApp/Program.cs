using System;

namespace Myob.Fma.CheckoutApp
{
    class Program
    {
        static void Main()
        {
            var checkout = new Checkout();

            var items = "AAAABBBCCDDDDD";

            Console.WriteLine(
                checkout.Scan(items));
        }
    }
}