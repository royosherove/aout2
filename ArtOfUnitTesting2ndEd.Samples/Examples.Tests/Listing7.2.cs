using NSubstitute;
using NUnit.Framework;

namespace Examples.Tests.Listing72
{

     [TestFixture]
    public class BaseTestsClass
    {
         public ILogger FakeTheLogger()
         {
             LoggingFacility.Logger = Substitute.For<ILogger>();
             return LoggingFacility.Logger;
         }

        [TearDown]
        public void teardown()
        {
            // need to reset a static resource between tests
           LoggingFacility.Logger = null;
        }

    }

   [TestFixture]
   public class ConfigurationManagerTests:BaseTestsClass
   {

       [Test]
        public void Analyze_EmptyFile_ThrowsException()
        {
           FakeTheLogger();
           
           ConfigurationManager cm = new ConfigurationManager();
           bool configured = cm.IsConfigured("something");
            //rest of test
        }
    }


    [TestFixture]
    public class LogAnalyzerTests : BaseTestsClass
    {

       [Test]
        public void Analyze_EmptyFile_ThrowsException()
        {
           FakeTheLogger();

           LogAnalyzer la = new LogAnalyzer();
           la.Analyze("myemptyfile.txt");
            //rest of test
        }

    }

}
