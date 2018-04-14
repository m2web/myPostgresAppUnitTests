using System;
using NUnit.Framework;
using myApp.Services;
using myApp.Controllers;
using Moq;
using System.Collections.Generic;
using myApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace UnitTests
{
    //run at the command prompt with the following command:
    //dotnet test --filter TestCategory=Unit
    //or decorate the Integration Tests with 
    //[Ignore("Ignoring these tests")]
    [TestFixture, Description("Unit Tests")]
    [Category("Unit")]
    public class HomeControllerTests{

        Westminstercatechism catechism = new Westminstercatechism();
        List<Jmverse> jmVerseList = new List<Jmverse>();
        
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
        }

        [TearDown]
        public void TearDown() {
            catechism = null;
            jmVerseList = null;
        }

        [Test]
        public void Methods_Should_Not_Be_Null_And_Return_Expected_Type(){
            System.Diagnostics.Debug.WriteLine("Starting Methods_Should_Not_Be_Null_And_Return_Expected_Type");
            //setup Westminster Catechism Service xctor input parameter
            var catechismService = new Mock<IWestminsterCatechismService>();
            catechismService.Setup(x => x.GetTodaysCatechism()).Returns(catechism);
            //setup JMVerse Service xctor input parameter
            var Jmverses = new Mock<IJmVersesService>();
            Jmverses.Setup(x => x.GetYearsVerses(true)).Returns(jmVerseList);

            var sut = new HomeController(catechismService.Object, Jmverses.Object);
            
            var indexResult = sut.Index();
            var prayerResult = sut.Prayer();
            
            Assert.IsNotNull(prayerResult);
            Assert.IsNotNull(indexResult);
            Assert.IsInstanceOf<ViewResult>(indexResult);
            Assert.IsInstanceOf<ViewResult>(prayerResult);
            
        }
    }
}