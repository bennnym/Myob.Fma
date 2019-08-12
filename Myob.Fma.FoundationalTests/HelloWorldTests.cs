using Myob.Fma.Foundational.Games;
using NUnit.Framework;

namespace Myob.Fma.FoundationalTests
{
    public class HelloWorldTests
    {
        private HelloWorld _helloWorld;

        [SetUp]
        public void Setup()
        {
            _helloWorld = new HelloWorld();
        }

        [Test]
        public void HelloWorldPlay_ReturnsTheString_HelloWorld()
        {
            var result = _helloWorld.Play();
            
            Assert.That(result, Is.EqualTo("Hello World"));
        }
    }
}