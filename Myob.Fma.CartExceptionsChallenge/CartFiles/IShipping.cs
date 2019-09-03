namespace Myob.Fma.CartExceptionsChallenge.CartFiles
{
    public interface IShipping
    {
        void CreateShippingRequest();
    }

    public class Shipping : IShipping
    {
        public void CreateShippingRequest()
        {
            throw new System.NotImplementedException();
        }
    }
}