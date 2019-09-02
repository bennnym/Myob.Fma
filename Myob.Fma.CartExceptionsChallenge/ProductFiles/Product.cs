namespace Myob.Fma.CartExceptionsChallenge.ProductFiles
{
    public class Product : IProduct
    {
        public decimal Cost { get; }
        public string Name { get; }

        public Product(string cost, string name)
        {
            // ignoring format validation for now
            Cost = decimal.Parse(cost); // I know this is bad, just doing it for this example
            Name = name;
        }
    }
}