namespace Myob.Fma.CheckoutApp
{
    public static class Pricing
    {
        public static int GetPrice(string item, int count)
        {
            if (count == 0)
            {
                return 0;
            }
            
            switch (item)
            {
                case "A":
                    if (count >= 3)
                    {
                        return 130 + GetPrice(item, count - 3);
                    }
                    return count * 50;
                case "B":
                    if (count >= 2)
                    {
                        return 45 + GetPrice(item, count - 2);
                    }
                    return count * 30;
                case "C":
                    return count * 20;
                case "D":
                    return count * 15;
                default:
                    return 0;
            }
        }
    }
}