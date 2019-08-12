namespace Myob.Fma.ShoppingCart
{
    public class Product : IProduct
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public PricingStatus PriceStatus { get; set; }
        public decimal Discount { get; set; }
  
        public Product(string description, string name, decimal price)
        {
            Description = description;
            Name = name;
            Price = price;
            PriceStatus = PricingStatus.FullPrice;
        }

        public void ApplyDiscount(PricingStatus discount)
        {
            switch (discount)
            {
                case PricingStatus.FullPrice:
                    Discount = 0;
                    PriceStatus = PricingStatus.FullPrice;
                    break;
                case PricingStatus.EndOfMonth:
                    Discount = AdjustPrice(10, Price);
                    PriceStatus = PricingStatus.EndOfMonth;
                    break;
                case PricingStatus.HalfPrice:
                    Discount = AdjustPrice(50, Price);
                    PriceStatus = PricingStatus.HalfPrice;
                    break;
                case PricingStatus.FlashSale:
                    Discount = AdjustPrice(70, Price);
                    PriceStatus = PricingStatus.FlashSale;
                    break;
            }
        }

        private decimal AdjustPrice(decimal percentage, decimal price)
        {
            return decimal.Round(price * (percentage / 100M), 2);
        }
    }
}