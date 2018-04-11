// GetRequestById(id)

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
    public class PrayerRequestServiceTests{

        List<Prayerrequest> requests = new List<Prayerrequest>();
        Prayerrequest request = new Prayerrequest();

        DateTime today = DateTime.Now;
        
        [SetUp]
        public void Setup() {
            requests = new List<Prayerrequest>(){
                new Prayerrequest(){
                    Id = It.IsAny<int>(),
                    Category = It.IsAny<string>(),
                    Request = It.IsAny<string>(),
                    Userid = It.IsAny<string>()
                },
                new Prayerrequest(){
                    Id = It.IsAny<int>(),
                    Category = It.IsAny<string>(),
                    Request = It.IsAny<string>(),
                    Userid = It.IsAny<string>()
                }
            };

            request = new Prayerrequest(){
                Id = It.IsAny<int>(),
                Category = It.IsAny<string>(),
                Request = It.IsAny<string>(),
                Userid = It.IsAny<string>()
            };
        }

        [TearDown]
        public void TearDown() {
            requests = null;
            request = null;
        }

        [Test]
        public void GetTodaysESTDate_Should_Be_Equal_To_Expected_Output(){
            System.Diagnostics.Debug.WriteLine("Starting GetTodaysESTDate_Should_Be_Equal_To_Expected_Output");
            var expectedOutout = today;
            var sut = new Mock<IPrayerRequestService>();
            sut.Setup(x => x.GetTodaysESTDate()).Returns(today);
            var output = sut.Object.GetTodaysESTDate();
            Assert.AreEqual(expectedOutout, output);
        }

        [Test]
        public void GetTodaysPrayerRequests_Should_Be_Equal_To_Expected_Output(){
            System.Diagnostics.Debug.WriteLine("Starting GetTodaysPrayerRequests_Should_Be_Equal_To_Expected_Output");
            var expectedOutout = requests;
            var sut = new Mock<IPrayerRequestService>();
            sut.Setup(x => x.GetTodaysPrayerRequests(It.IsAny<string>())).Returns(requests);
            var output = sut.Object.GetTodaysPrayerRequests(It.IsAny<string>());
            Assert.AreEqual(expectedOutout, output);
        }

        [Test]
        public void GetRequests_Should_Be_Equal_To_Expected_Output(){
            System.Diagnostics.Debug.WriteLine("Starting GetRequests_Should_Be_Equal_To_Expected_Output");
            var expectedOutout = requests;
            var sut = new Mock<IPrayerRequestService>();
            sut.Setup(x => x.GetRequests(It.IsAny<string>())).Returns(requests);
            var output = sut.Object.GetRequests(It.IsAny<string>());
            Assert.AreEqual(expectedOutout, output);
        }

        [Test]
        public void GetRequestById_Should_Be_Equal_To_Expected_Output(){
            System.Diagnostics.Debug.WriteLine("Starting GetRequestById_Should_Be_Equal_To_Expected_Output");
            var expectedOutout = request;
            var sut = new Mock<IPrayerRequestService>();
            sut.Setup(x => x.GetRequestById(It.IsAny<int>())).Returns(request);
            var output = sut.Object.GetRequestById(It.IsAny<int>());
            Assert.AreEqual(expectedOutout, output);
        }
    }
}