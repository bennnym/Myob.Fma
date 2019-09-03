using Myob.Fma.CartExceptionsChallenge.ProductFiles;

namespace Myob.Fma.CartExceptionsChallenge.CartFiles
{
    public interface IInventory
    {
        int CheckStockLevel(IProduct product);
    }
}