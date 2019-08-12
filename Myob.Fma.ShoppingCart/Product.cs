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

        public void ChangePrice(decimal updatedPrice)
        {
            Price = updatedPrice;
        }

        public void ChangeName(string updatedName)
        {
            Name = updatedName;
        }

        public void ChangeDescription(string updateDescription)
        {
            Description = updateDescription;
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
                    Discount = MoneySaved(10, Price);
                    PriceStatus = PricingStatus.EndOfMonth;
                    break;
                case PricingStatus.HalfPrice:
                    Discount = MoneySaved(50, Price);
                    PriceStatus = PricingStatus.HalfPrice;
                    break;
                case PricingStatus.FlashSale:
                    Discount = MoneySaved(70, Price);
                    PriceStatus = PricingStatus.FlashSale;
                    break;
            }
        }

        private decimal MoneySaved(decimal percentage, decimal price)
        {
            return decimal.Round(price * (percentage / 100), 2);
        }
        
        
    }
}