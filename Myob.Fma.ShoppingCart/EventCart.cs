namespace Myob.Fma.ShoppingCart
{
    public class EventCart : Cart
    {
        public override string GetAllProductDescriptions()
        {
            var products = string.Empty;
            
            foreach (var product in _products)
            {
                if (product is EventProduct)
                {
                    var eventProduct = product as EventProduct;
                    
                    products += $"{eventProduct.GetSession()}\n";
                }
                else
                {
                    products += $"{product.Name}\n";
                }
            }

            return products;
        }
    }
}