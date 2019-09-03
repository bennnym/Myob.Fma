using Myob.Fma.CartExceptionsChallenge.ProductFiles;

namespace Myob.Fma.CartExceptionsChallenge.CartFiles
{
    public class Inventory : IInventory
    {
        public int CheckStockLevel(IProduct product)
        {
            throw new System.NotImplementedException();
        }
    }
}