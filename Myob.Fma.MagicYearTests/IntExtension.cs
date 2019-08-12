using NUnit.Framework;
using Myob.Fma.MagicYear.Extensions;


namespace Myob.Fma.MagicYearTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        
        [Test]
        [TestCase(5.55, 6)]
        [TestCase(5.55, 6)]
        [TestCase(2.55, 3)]
        public void Rounding_ShouldRoundUp_ReturnWholeNumber(decimal number, decimal output)
        {
            var result = IntExtension.Rounding(number);
            
            Assert.That(result, Is.EqualTo(output));
        }
        
        [Test]
        [TestCase(5.49, 5)]
        [TestCase(5.33, 5)]
        [TestCase(2.2, 2)]
        public void Rounding_ShouldRoundDown_ReturnWholeNumber(decimal number, decimal output)
        {
            var result = IntExtension.Rounding(number);
            
            Assert.That(result, Is.EqualTo(output));
        }
        
    }
}