using System.Collections.Generic;
using Xunit;

namespace Myob.Fma.Calculator.Tests
{
    public class CartExceptionTests
    {
        [Fact]
        public void method()
        {
            // Arrange
            var pp = new FakePaymentProvider();
            var cart = new Cart(pp, new List<IProduct>(){new Product()
            {
                Cost = 10M
                    
            }});
            // Act
            var result = cart.CalculateFinalCartTotal();
            // Assert
            Assert.Equal(1, result);
        }

    }
}