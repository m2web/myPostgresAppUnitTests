using System;
using NUnit.Framework;
using myApp.Services;
using Moq;
using System.Collections.Generic;
using myApp.Models;

namespace UnitTests
{
    //run at the command prompt with the following command:
    //dotnet test --filter TestCategory=Unit
    //or decorate the Integration Tests with 
    //[Ignore("Ignoring these tests")]
    [TestFixture, Description("Unit Tests")]
    [Category("Unit")]
    public class WestminstCatServiceTests{

        Westminstercatechism catechism = new Westminstercatechism();
        
        [SetUp]
        public void Setup() { 
            catechism = new Westminstercatechism(){
                Id = It.IsAny<int>(),
                Number = It.IsAny<int>(),
                Question = It.IsAny<string>(),
                Answer = It.IsAny<string>()
            };
        }

        [TearDown]
        public void TearDown() {
            catechism = null;
        }

        [Test]
        public void GetTodaysCatechism_Should_Be_Equal_To_Expected_Output(){
            System.Diagnostics.Debug.WriteLine("Starting GetTodaysCatechism_Should_Be_Equal_To_Expected_Output");
            var expectedOutout = catechism;
            var sut = new Mock<IWestminsterCatechismService>();
            sut.Setup(x => x.GetTodaysCatechism()).Returns(catechism);
            var output = sut.Object.GetTodaysCatechism();
            Assert.AreEqual(expectedOutout, output);
        }
    }
}