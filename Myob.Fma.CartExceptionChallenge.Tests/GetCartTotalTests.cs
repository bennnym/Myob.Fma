using System;
using Moq;
using Myob.Fma.CartExceptionsChallenge.CartFiles;
using Myob.Fma.CartExceptionsChallenge.Exceptions;
using Myob.Fma.CartExceptionsChallenge.ProductFiles;
using Xunit;

namespace Myob.Fma.CartExceptionChallenge.Tests
{
    public class GetCartTotalTests
    {
        private readonly Mock<IInventory> _inventory;
        private readonly Mock<IShipping> _shipping;

        public GetCartTotalTests()
        {
            
            _inventory = new Mock<IInventory>();
            _shipping = new Mock<IShipping>();
        }
        
        [Fact]
        public void Should_Throw_ProductCostZeroOrLess_Exception_When_Cart_Has_A_Product_Costing_0_Or_Less()
        {
            var product = new Product("-1", "milk");
            var inventory = new Mock<IInventory>();
            inventory.Setup(x => x.CheckStockLevel(product)).Returns(1);
            var cart = new Cart(_inventory.Object, _shipping.Object);
            cart.AddProductToCart(product);

            Assert.Throws<ProductCostZeroOrLessException>(() => cart.GetCartTotal());
        }
        
        [Fact]
        public void Should_Throw_StockLevelTooLow_Exception_When_Inventory_Is_Zero()
        {
            var product = new Product("-1", "milk");
            _inventory.Setup(x => x.CheckStockLevel(product)).Returns(0);
            var cart = new Cart(_inventory.Object, _shipping.Object);

            Assert.Throws<Exception>(() => cart.AddProductToCart(product));
        }

        [Fact]
        public void Should_Return_Sum_Of_Products_When_All_Product_Costs_Are_Greater_Than_Zero()
        {
            // Arrange
            var product1 = new Product("3.50", "chocolate");
            var product2 = new Product("5.50", "fruit");
            var product3 = new Product("7.20", "hotdogs");
            
            _inventory.Setup(x => x.CheckStockLevel(product1)).Returns(1);
            _inventory.Setup(x => x.CheckStockLevel(product2)).Returns(1);
            _inventory.Setup(x => x.CheckStockLevel(product3)).Returns(1);
            
            var cart = new Cart(_inventory.Object, _shipping.Object);
            
            cart.AddProductToCart(product1);
            
            cart.AddProductToCart(product2);
            
            cart.AddProductToCart(product3);
            
            // Act
            var result = cart.GetCartTotal();
            
            Assert.Equal(16.20M, result);
            
            _shipping.Verify(x => x.CreateShippingRequest(), Times.Exactly(3));
        }
    }
}