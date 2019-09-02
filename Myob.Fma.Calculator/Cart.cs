using System;
using System.Collections.Generic;
using System.Linq;

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

    public interface IProduct
    {
        decimal Cost { get; set; }
    }

    public class Product : IProduct
    {
        public decimal Cost { get; set; }
    }

    public interface IPaymentProvider
    {
        int GetSerialCode();
    }

    public class Cart
    {
        private readonly IPaymentProvider _paymentProvider;
        private readonly List<IProduct> _products;

        public Cart(IPaymentProvider paymentProvider, List<IProduct> products)
        {
            _paymentProvider = paymentProvider;
            _products = products;
        }

        public decimal LocalTax { get; set; }

        public decimal CalculateSubTotal()
        {
            return _products.Sum(p => p.Cost);
        }

        public decimal CalculateCartTotal()
        {
            try
            {
                throw new ArgumentException("message1");
                return CalculateSubTotal() + CartGst();
            }
            catch (DivideByZeroException e)
            {
                throw new CartException("12345");
            }
        }

        public decimal CalculateFinalCartTotal()
        {
            try
            {
                return CalculateCartTotal();
            }
            catch (CartException e)
            {
                return 0;
            }
            catch (ArgumentException e)
            {
                return 88;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public decimal CartGst()
        {
            return (CalculateSubTotal() / LocalTax);
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