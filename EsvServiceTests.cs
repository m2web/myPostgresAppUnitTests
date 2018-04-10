using System;
using NUnit.Framework;
using myApp.Services;
using Moq;

namespace UnitTests
{
    [TestFixture]
    public class EsvServiceTests {
        
        [Test]
        public void GetDailyVerseAsync_Should_not_Be_Empty(){
            System.Diagnostics.Debug.WriteLine("Starting GetDailyVerseAsync_Should_not_Be_Empty");
            var returnedOutput = "In the beginning was the Word....";
            var sut = new Mock<IEsvService>();
            sut.Setup(x => x.GetDailyVerseAsync()).ReturnsAsync(returnedOutput);
            var output = sut.Object.GetDailyVerseAsync().Result;
            Assert.AreEqual(returnedOutput, output);
        }

         [Test]
        public void GetTodaysPsalmAsync_Should_not_Be_Empty(){
            System.Diagnostics.Debug.WriteLine("Starting GetDailyVerseAsync_Should_not_Be_Empty");
            var returnedOutput = "The Lord is my Shepard....";
            var sut = new Mock<IEsvService>();
            sut.Setup(x => x.GetTodaysPsalmAsync()).ReturnsAsync(returnedOutput);
            var output = sut.Object.GetTodaysPsalmAsync().Result;
            Assert.AreEqual(returnedOutput, output);
        }
    }
}
