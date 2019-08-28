namespace Myob.Fma.Calculator
{
    public class RealPaymentProvider : IPaymentProvider
    {
        public int GetSerialCode()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IPaymentProvider
    {
        int GetSerialCode();
    }
    public class Cart
    {
        private readonly IPaymentProvider _paymentProvider;

        public Cart(IPaymentProvider paymentProvider)
        {
            _paymentProvider = paymentProvider;
        }

        public string GetSerialCode()
        {
            return "S"+_paymentProvider.GetSerialCode();
        }
    }
}