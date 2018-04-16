using System;
using NUnit.Framework;
using myApp.Services;
using myApp.Controllers;
using Moq;
using System.Collections.Generic;
using myApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace UnitTests
{
    //run at the command prompt with the following command:
    //dotnet test --filter TestCategory=Unit
    //or decorate the Integration Tests with 
    //[Ignore("Ignoring these tests")]
    [TestFixture, Description("Unit Tests")]
    [Category("Unit")]
    public class TodayPrayerControllerTests{

        Westminstercatechism catechism = new Westminstercatechism();
        List<Jmverse> jmVerseList = new List<Jmverse>();
        List<Prayerrequest> prayerRequests = new List<Prayerrequest>();
        AppSettings appSettings = new AppSettings();
        
        [SetUp]
        public void Setup() { 
            catechism = new Westminstercatechism(){
                Id = It.IsAny<int>(),
                Number = It.IsAny<int>(),
                Question = It.IsAny<string>(),
                Answer = It.IsAny<string>()
            };

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

            prayerRequests = new List<Prayerrequest>{
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

            appSettings = new AppSettings(){
                ValleyOfVisionURLBase = It.IsAny<string>()
            };
        }

        [TearDown]
        public void TearDown() {
            catechism = null;
            jmVerseList = null;
            prayerRequests = null;
            appSettings = null;
        }

        [Test]
        public void Methods_Should_Not_Be_Null_And_Return_Expected_Type(){
            System.Diagnostics.Debug.WriteLine("Starting Methods_Should_Not_Be_Null_And_Return_Expected_Type");
            //setup Westminster Catechism Service xctor input parameter
            var catechismServiceMock = new Mock<IWestminsterCatechismService>();
            catechismServiceMock.Setup(x => x.GetTodaysCatechism()).Returns(catechism);
            //setup JMVerse Service xctor input parameter
            var jmversesMock = new Mock<IJmVersesService>();
            jmversesMock.Setup(x => x.GetYearsVerses(true)).Returns(jmVerseList);
            //setup PrayerRequestService Service xctor input parameter
            var prayerRequestServiceMock = new Mock<IPrayerRequestService>();
            prayerRequestServiceMock.Setup(x => x.GetTodaysPrayerRequests(It.IsAny<string>())).Returns(prayerRequests);
            //setup IOptions<AppSettings> xctor input parameter
            var appSettingsMock = new Mock<IOptions<AppSettings>>();
            appSettingsMock.Setup(x => x.Value).Returns(appSettings);
            //setup UserManager<ApplicationUser> xctor parameter
            var userManagerMock = GetMockUserManager();

            var sut = new TodaysPrayerController(jmversesMock.Object, catechismServiceMock.Object,
                prayerRequestServiceMock.Object, appSettingsMock.Object, userManagerMock.Object);

            //set the HttpContext state
            sut.ControllerContext = new ControllerContext{
                 HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, "username")
                    }, "someAuthTypeName"))
                }
            };
            
            //set the controller methods
            var indexResult = sut.Index();
            var vovPrayerLinkResult = sut.GetVovPrayerLink();
            
            //asserts
            Assert.IsNotNull(vovPrayerLinkResult);
            Assert.IsNotNull(indexResult);

            Assert.IsInstanceOf<ActionResult>(vovPrayerLinkResult);
            Assert.IsInstanceOf<System.Threading.Tasks.Task<ActionResult>>(indexResult);
        }

        private Mock<UserManager<ApplicationUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userMock = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);

            return userMock;
        }
    }
}