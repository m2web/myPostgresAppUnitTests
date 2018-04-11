using System;
using NUnit.Framework;
using myApp.Services;

namespace UnitTests
{
    //run at the command prompt with the following command:
    //dotnet test --filter TestCategory=Integration
    [TestFixture, Description("Integration Tests")]
    [Category("Integration")]
    //[Ignore("Ignoring these tests")]
    public class JmVersesServiceIntegrationTests{
        
        [Test]
        public void GetYearsVerses_Should_Be_Not_Be_Empty(){
            //TODO: complete test
            Assert.Fail();
        }

        [Test]
        public void GetCurrentVerses_Should_Be_Not_Be_Empty(){
            //TODO: complete test
            Assert.Fail();
        }
    }
}