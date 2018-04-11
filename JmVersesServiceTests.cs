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
    public class JmVersesServiceTests{

        [Test]
        public void GetYearsVerses(bool isDescendingOrder){
            Assert.Fail("Intentional Fail");
        }

        [Test]
        public void GetCurrentVerses(string userId){
            Assert.Fail("Intentional Fail");
        }
    }
}