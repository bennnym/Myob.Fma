using Myob.Fma.Foundational.Games;
using NUnit.Framework;

namespace Myob.Fma.FoundationalTests
{
    public class GreetAliceOrBobTests
    {
        private GreetAliceOrBob _greeting;
        
        [SetUp]
        public void Setup()
        {
            _greeting = new GreetAliceOrBob();
        }

        [Test]
        [TestCase("alice", "Hello alice!")]
        [TestCase("bob", "Hello bob!")]
        [TestCase("bob martin", "Hello bob martin!")]
        [TestCase("alice jones", "Hello alice jones!")]
        public void CheckForAliceOrBob_IfNameIsAliceOrBob_saysHello(string name, string expectedOutput)
        {
            var result = _greeting.CheckForAliceOrBob(name);
            
            Assert.That(result, Is.EqualTo($"Hello {name}!"));
        }
        
        [Test]
        [TestCase("Ben", "I can't say hello to you, sorry!")]
        [TestCase("James", "I can't say hello to you, sorry!")]
        [TestCase("Sam", "I can't say hello to you, sorry!")]
        [TestCase("Amr", "I can't say hello to you, sorry!")]
        public void CheckForAliceOrBob_IfNameIsNotAliceOrBob_ReturnICantSayHelloToYou(string name, string expectedOutput)
        {
            var result = _greeting.CheckForAliceOrBob(name);
            Assert.That(result, Is.EqualTo(expectedOutput));
        }
    }
}