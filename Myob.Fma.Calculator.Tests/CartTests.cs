using Xunit;

namespace Myob.Fma.Calculator.Tests
{
    public class CartTests
    {
        [Fact]
        public void When_Cart_Retrieves_Serial_Number_Expects_A_Valid_Serial_Number()
        {
            // Arrange
            var fakePaymentProvider = new FakePaymentProvider();
            var cart = new Cart(fakePaymentProvider);
            // Act
            var result = cart.GetSerialCode();
            // Assert
            Assert.Equal("111",result);
        }
    }

    internal class FakePaymentProvider : IPaymentProvider
    {
        public int GetSerialCode()
        {
            return 111;
        }
    }
}