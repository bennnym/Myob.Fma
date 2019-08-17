using System;

namespace Myob.Fma.ShoppingBasket
{
    class Program
    {
        static void Main(string[] args)
        {
            var bread = new Product("bread", "helgas", 5.99M, 1000);
            var deodorant = new Product("deodorant", "linx", 7.95M, 3000);
            var razors = new Product("eggs", "farm land", 3.50M, 6666);
            
            var movie = new EventProduct("movie-tickets", "hoyts", 24.99M, 450);
            
            var rockClimbing = new ActionProduct("rock-climbing", "climbing company", 49.99M, Int32.MaxValue, "North Sydney");
            
            var cart = new Cart();
            
            cart.AddProductToCart(bread);
            cart.AddProductToCart(deodorant);
            cart.AddProductToCart(razors);
            cart.AddProductToCart(movie);
            cart.AddProductToCart(rockClimbing);

            Console.WriteLine(cart.GetAllProductsInCart());
        }
    }
}