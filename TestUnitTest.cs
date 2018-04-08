using System;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class TestUnitTest {
        
        [Test]
        public void True_should_equal_true(){
            Assert.AreEqual(true, true);
        }
    }
}
