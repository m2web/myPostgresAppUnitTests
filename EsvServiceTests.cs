using System;
using NUnit.Framework;
using myApp.Services;

namespace UnitTests
{
    [TestFixture]
    public class EsvServiceTests {
        
        [Test]
        public void GetDailyVerseAsync_Should_not_Be_Null(){
            System.Diagnostics.Debug.WriteLine("Starting GetDailyVerseAsync_Should_not_Be_Null");
            var esvService = new EsvService();
            var output = esvService.GetDailyVerseAsync().Result;
            Assert.IsNotNull(output);
        }
    }
}
