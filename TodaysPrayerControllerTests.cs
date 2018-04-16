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

            var prayerRequestServiceMock = new Mock<IPrayerRequestService>();
            prayerRequestServiceMock.Setup(x => x.GetTodaysPrayerRequests(It.IsAny<string>())).Returns(prayerRequests);

            var appSettingsMock = new Mock<IOptions<AppSettings>>();
            appSettingsMock.Setup(x => x.Value).Returns(appSettings);

            var userManagerMock = GetMockUserManager();

            var sut = new TodaysPrayerController(jmversesMock.Object, catechismServiceMock.Object,
                prayerRequestServiceMock.Object, appSettingsMock.Object, userManagerMock.Object);
            
            //TODO: get sut.Index() call working
            // var indexResult = sut.Index();
            var vovPrayerLinkResult = sut.GetVovPrayerLink();
            
            Assert.IsNotNull(vovPrayerLinkResult);
            //TODO: get call working
            // Assert.IsNotNull(indexResult);
            
        }

        private Mock<UserManager<ApplicationUser>> GetMockUserManager()
        {
            var userStoreMock = new Mock<IUserStore<ApplicationUser>>();
            var userMock = new Mock<UserManager<ApplicationUser>>(
                userStoreMock.Object, null, null, null, null, null, null, null, null);
            
            var principal = new CustomPrincipal();
            principal.UserId = "2038786";
            principal.FirstName = "Test";
            principal.LastName = "User";
            principal.IsStoreUser = true;
            
            var newUser = new ApplicationUser();
            newUser.Id = "2038786";
            newUser.UserName = "Test";
            newUser.Email = "me@here.com";
            userMock.Setup(x => x.GetUserAsync(principal)).ReturnsAsync(newUser);

            return userMock;
        }
    }

    public class CustomPrincipal : ClaimsPrincipal
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsStoreUser { get; set; }
    }
}