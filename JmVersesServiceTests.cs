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
    public class JmVersesServiceTests{
        List<Jmverse> jmVerseList = new List<Jmverse>();

        [SetUp]
        public void Setup() { 
            jmVerseList = new List<Jmverse>(){
                new Jmverse(){
                    Id = It.IsAny<int>(),
                    Reference = It.IsAny<string>(),
                    Text = It.IsAny<string>(),
                    Year = It.IsAny<string>(),
                    Month = It.IsAny<int>(),
                    Startdate = It.IsAny<DateTime>(),
                    Enddate = It.IsAny<DateTime>()
                },
                new Jmverse(){
                    Id = It.IsAny<int>(),
                    Reference = It.IsAny<string>(),
                    Text = It.IsAny<string>(),
                    Year = It.IsAny<string>(),
                    Month = It.IsAny<int>(),
                    Startdate = It.IsAny<DateTime>(),
                    Enddate = It.IsAny<DateTime>()
                }
            };
        }

        [TearDown]
        public void TearDown() {
            jmVerseList = null;
        }

        [Test]
        public void GetYearsVerses_Should_Be_Equal_To_Expected_Output(){
            System.Diagnostics.Debug.WriteLine("Starting GetYearsVerses_Should_Be_Equal_To_Expected_Output");
            var expectedOutout = jmVerseList;
            var sut = new Mock<IJmVersesService>();
            sut.Setup(x => x.GetYearsVerses(true)).Returns(expectedOutout);
            var output = sut.Object.GetYearsVerses(true);
            Assert.AreEqual(expectedOutout, output);
        }

        [Test]
        public void GetCurrentVerses_Should_Be_Equal_To_Expected_Output(){
            System.Diagnostics.Debug.WriteLine("Starting GetCurrentVerses_Should_Be_Equal_To_Expected_Output");
            var expectedOutout = jmVerseList;
            var sut = new Mock<IJmVersesService>();
            sut.Setup(x => x.GetCurrentVerses(It.IsAny<string>())).Returns(expectedOutout);
            var output = sut.Object.GetCurrentVerses(It.IsAny<string>());
            Assert.AreEqual(expectedOutout, output);
        }
    }
}