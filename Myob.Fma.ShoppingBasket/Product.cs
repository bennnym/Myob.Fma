namespace Myob.Fma.ShoppingBasket
{
    public class Product
    {
        private string _brand;
        
        public Product(string productType, string brand, decimal price, int quantity)
        {
            Price = price;
            Quantity = quantity;
            ProductType = productType;
            _brand = brand;
        }
        public virtual string ProductType { get; }
        public decimal Price;
        public decimal Quantity;
    }
}