using Xunit;

namespace Myob.Fma.Calculator.Tests
{
    public class CartTests
    {
//        [Fact]
//        public void When_Cart_Retrieves_Serial_Number_Expects_A_Valid_Serial_Number()
//        {
//            // Arrange
//            var fakePaymentProvider = new FakePaymentProvider();
//            var realPaymentProvider = new RealPaymentProvider();
//            var cart = new Cart(realPaymentProvider);
//            // Act
//            var result = cart.GetLabelCode();
//            // Assert
//            Assert.Equal("111", result);
//        }

//        [Fact]
//        public void Test_For_S()
//        {
//            // Arrange
//            var fakePaymentProvider = new FakePaymentProvider();
//            var cart = new Cart(fakePaymentProvider);
//            // Act
//            var result = cart.GetLabelCode();
//            // Assert
//            Assert.StartsWith("S", result);


        [Theory]
        [InlineData(ProductType.Action, "a")]
        [InlineData(ProductType.Event, "e")]
        [InlineData(ProductType.Physical, "p")]
        public void When_Valid_Product_Type_Expect_Valid_Label_Code_Prefix(ProductType productType, string expectedOutput)
        {
            // Arrange
            var fakeProvider = new FakePaymentProvider();
            var cart = new Cart(fakeProvider);
            // Act
            var result = cart.GetLabelCode(productType);
            // Assert
            Assert.StartsWith(expectedOutput, result);
        }

//        
//        [Fact]
//        public void Test_For_S_Static()
//        {
//            // Arrange
//            var fakeParmentProvider = new FakePaymentProvider();
//            var cart = new Cart(fakeParmentProvider);
//            // Act
//            var result = cart.GetLabelCode();
//            // Assert
//            Assert.StartsWith("S", result);
//
//        }
//    }
    }

    internal class FakePaymentProvider : IPaymentProvider
    {
        public int GetSerialCode()
        {
            return 111;
        }
    }
}