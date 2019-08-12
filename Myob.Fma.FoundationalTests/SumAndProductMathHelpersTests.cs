using Myob.Fma.Foundational.SumAndProductMathHelpers;
using NUnit.Framework;

namespace Myob.Fma.FoundationalTests
{
    public class SumAndProductMathHelpersTests
    {
        [Test]
        [TestCase(1, "The total sum from 1 to 1 is 1.")]
        [TestCase(2, "The total sum from 1 to 2 is 3.")]
        [TestCase(3, "The total sum from 1 to 3 is 6.")]
        public void Sum_ShouldSumUpAllNumsFromOneToN(int number, string expectedOutput)
        {
            var result = OperationFromOneToN.Sum(number);
            
            Assert.That(result, Is.EqualTo(expectedOutput));
        }
        
    }
}