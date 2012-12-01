using NSubstitute;
using NUnit.Framework;

namespace Examples.Tests.Listing71
{
    [TestFixture]
    public class ConfigurationManagerTests
    {

        [Test]
        public void Analyze_EmptyFile_ThrowsException()
        {
            LoggingFacility.Logger = Substitute.For<ILogger>();

            ConfigurationManager cm = new ConfigurationManager();
            bool configured = cm.IsConfigured("something");
            //rest of test
        }

        [TearDown]
        public void teardown()
        {
            // need to reset a static resource between tests
            LoggingFacility.Logger = null;
        }


    }


    [TestFixture]
    public class LogAnalyzerTests
    {

        [Test]
        public void Analyze_EmptyFile_ThrowsException()
        {
            LoggingFacility.Logger = Substitute.For<ILogger>();

            LogAnalyzer la = new LogAnalyzer();
            la.Analyze("myemptyfile.txt");
            //rest of test
        }

        [TearDown]
        public void teardown()
        {
            // need to reset a static resource between tests
            LoggingFacility.Logger = null;
        }
    }

}
