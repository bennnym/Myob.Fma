using Myob.Fma.CartExceptionsChallenge.ProductFiles;

namespace Myob.Fma.CartExceptionsChallenge.CartFiles
{
    public interface ICart
    {
        decimal GetCartTotal();
        void AddProductToCart(IProduct product);
    }
}