namespace Myob.Fma.ShoppingCart
{
    public interface IProduct
    {
        decimal Price { get; set; }
        decimal Discount { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        PricingStatus PriceStatus { get; set; }
        void ChangePrice(decimal updatedPrice);
        void ChangeName(string updatedName);
        void ChangeDescription(string updatedDescription);
    }
}