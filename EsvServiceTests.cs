using System;
using NUnit.Framework;
using myApp.Services;
using Moq;

namespace UnitTests
{
    //run at the command prompt with the following command:
    //dotnet test --filter TestCategory=Unit
    //or decorate the Integration Tests with 
    //[Ignore("Ignoring these tests")]
    [TestFixture, Description("Unit Tests")]
    [Category("Unit")]
    public class EsvServiceTests {
        
        [Test]
        public void GetDailyVerseAsync_Should_Be_Equal_To_Input(){
            System.Diagnostics.Debug.WriteLine("Starting GetDailyVerseAsync_Should_Be_Equal_To_Input");
            var expectedOutout = "In the beginning was the Word....";
            var sut = new Mock<IEsvService>();
            sut.Setup(x => x.GetDailyVerseAsync()).ReturnsAsync(expectedOutout);
            var output = sut.Object.GetDailyVerseAsync().Result;
            Assert.AreEqual(expectedOutout, output);
        }

        [Test]
        public void GetTodaysPsalmAsync_Should_Be_Equal_To_Input(){
            System.Diagnostics.Debug.WriteLine("Starting GetDailyVerseAsync_Should_Be_Equal_To_Input");
            var expectedOutout = "The Lord is my Shepard....";
            var sut = new Mock<IEsvService>();
            sut.Setup(x => x.GetTodaysPsalmAsync()).ReturnsAsync(expectedOutout);
            var output = sut.Object.GetTodaysPsalmAsync().Result;
            Assert.AreEqual(expectedOutout, output);
        }

        [Test]
        public void GetVerseAsync_Should_Be_Equal_To_Input(){
            System.Diagnostics.Debug.WriteLine("GetVerseAsync_Should_Be_Equal_To_Input");
            var expectedOutout = "In the beginning was the Word....";
            var inputParameter = "John 1:1";
            var sut = new Mock<IEsvService>();
            sut.Setup(x => x.GetVerseAsync(inputParameter)).ReturnsAsync(expectedOutout);
            var output = sut.Object.GetVerseAsync(inputParameter).Result;
            Assert.AreEqual(expectedOutout, output);
        }
    }
}
