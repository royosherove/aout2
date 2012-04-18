using NUnit.Framework;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);

        }
        [Test]
        public void IsValidLogFileName_GoodExtensionlowercase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithgoodextension.slf");

            Assert.True(result);

        }


        [Test]
        public void IsValidLogFileName_GoodExtensionUpperCase_ReturnsTrue()
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName("filewithgoodextension.SLF");

            Assert.True(result);

        }

        // this is a refactoring of the previous two tests
        [TestCase("filewithgoodextension.SLF")]
        [TestCase("filewithgoodextension.slf")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string file)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName(file);

            Assert.True(result);
        }
        
        // this is a refactoring of all the "regular" tests
        [TestCase("filewithgoodextension.SLF",true)]
        [TestCase("filewithgoodextension.slf",true)]
        [TestCase("filewithbadextension.foo",false)]
        public void IsValidLogFileName_VariousExtensions_ChecksThem(string file,bool expected)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName(file);

            Assert.AreEqual(expected,result);
        }

    }
}
