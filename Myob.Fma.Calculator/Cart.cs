using System;

namespace Myob.Fma.Calculator
{
    public class RealPaymentProvider : IPaymentProvider
    {
        public int GetSerialCode()
        {
            throw new System.NotImplementedException();
        }

        public static int GetSerialCodeTwo()
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

        public string GetLabelCode(ProductType productType)
        {

            var prefix = string.Empty;
            
            switch (productType)
            {
                case ProductType.Event:
                    prefix = "e";
                    break;
                case ProductType.Action:
                    prefix = "a";
                    break;
                case ProductType.Physical:
                    prefix = "pop";
                    break;
            }
            
            return prefix + _paymentProvider.GetSerialCode();
        }
    }

    public enum ProductType
    {
        Event,
        Action,
        Physical,
        Invalid
    }
}