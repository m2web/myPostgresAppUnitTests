using System;
using NUnit.Framework;
using myApp.Services;

namespace UnitTests
{
    [TestFixture]
    public class EsvServiceTests {
        
        [Test]
        public void GetDailyVerseAsync_Should_not_Be_Empty(){
            System.Diagnostics.Debug.WriteLine("Starting GetDailyVerseAsync_Should_not_Be_Empty");
            var sut = new EsvService();//EsvService is the System Under Test (sut)
            var output = sut.GetDailyVerseAsync().Result;
            Assert.IsNotEmpty(output);
        }

         [Test]
        public void GetTodaysPsalmAsync_Should_not_Be_Empty(){
            System.Diagnostics.Debug.WriteLine("Starting GetDailyVerseAsync_Should_not_Be_Empty");
            var sut = new EsvService();
            var output = sut.GetTodaysPsalmAsync().Result;
            Assert.IsNotEmpty(output);
        }
    }
}
