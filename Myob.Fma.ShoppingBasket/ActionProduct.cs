namespace Myob.Fma.ShoppingBasket
{
    public class ActionProduct : Product
    {
        public ActionProduct(string productType, string brand, decimal price, int quantity, string location) : base(productType, brand,
            price, quantity)
        {
            ProductType = $"Action-{productType}";
            Location = location;
        }

        public override string ProductType { get; }
        public string Location { get; }
    }
}