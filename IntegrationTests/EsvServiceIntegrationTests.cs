using System;
using NUnit.Framework;
using myApp.Services;

namespace UnitTests
{
    //run at the command prompt with the following command:
    //dotnet test --filter TestCategory=Integration
    [TestFixture, Description("Integration Tests")]
    [Category("Integration")]
    //[Ignore("Ignoring these tests")]
    public class EsvServiceIntegrationTests {
        
        [Test]
        public void GetDailyVerseAsync_Should_not_Be_Empty(){
            System.Diagnostics.Debug.WriteLine("Starting GetDailyVerseAsync_Should_not_Be_Empty");
            var esvService = new EsvService();
            var output = esvService.GetDailyVerseAsync().Result;
            Assert.IsNotEmpty(output);
        }

         [Test]
        public void GetTodaysPsalmAsync_Should_not_Be_Empty(){
            System.Diagnostics.Debug.WriteLine("Starting GetDailyVerseAsync_Should_not_Be_Empty");
            var esvService = new EsvService();
            var output = esvService.GetTodaysPsalmAsync().Result;
            Assert.IsNotEmpty(output);
        }
    }
}