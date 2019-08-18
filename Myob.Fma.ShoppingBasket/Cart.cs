using System.Collections.Generic;

namespace Myob.Fma.ShoppingBasket
{
    public class Cart
    {
        private readonly List<Product> _cart;

        public Cart()
        {
            _cart = new List<Product>();
        }

        public void AddProductToCart(Product product)
        {
            _cart.Add(product);
        }

        public string GetAllProductsInCart()
        {
            var productsString = "";

            foreach (var product in _cart)
                if (product is ActionProduct)
                {
                    var actionProd = product as ActionProduct;
                    productsString += $"{actionProd.ProductType}-{actionProd.Location}\n";
                }
                else
                {
                    productsString += $"{product.ProductType}\n";
                }

            return productsString;
        }
        
            
    }
}