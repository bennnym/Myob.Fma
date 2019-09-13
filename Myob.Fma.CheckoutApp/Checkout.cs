using System;
using System.Linq;

namespace Myob.Fma.CheckoutApp
{
    public class Checkout
    {
        public int Scan(string items)
        {
            var sum = 0;
            var groupString = items.GroupBy(l => l);
            foreach (var item in groupString)
            {
                sum += Pricing.GetPrice(item.Key.ToString(), item.Count());
            }

            return sum;
        }
    }
}