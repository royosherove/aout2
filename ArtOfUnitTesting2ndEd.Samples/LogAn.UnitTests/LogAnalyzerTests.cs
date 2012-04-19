using System;
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

        [Test]
        [ExpectedException(typeof(ArgumentException),
              ExpectedMessage = "filename has to be provided")]
        public void IsValidFileName_EmptyFileName_ThrowsException()
        {
            LogAnalyzer la = MakeAnalyzer();
            la.IsValidLogFileName(string.Empty);
        }

        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }

        [Test]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            LogAnalyzer la = MakeAnalyzer();

            var ex = Assert.Throws<ArgumentException>(() => la.IsValidLogFileName(""));
            
            StringAssert.Contains("filename has to be provided",ex.Message);
        }
        
        [Test]
        public void IsValidFileName_EmptyFileName_ThrowsFluent()
        {
            LogAnalyzer la = MakeAnalyzer();

            var ex = Assert.Throws<ArgumentException>(() => la.IsValidLogFileName(""));
            
            Assert.That(ex.Message,Is.StringContaining("filename has to be provided"));
        }
        
        [Test]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid()
        {
            LogAnalyzer la = MakeAnalyzer();

            la.IsValidLogFileName("badname.foo");

            Assert.IsFalse(la.WasLastFileNameValid);
        }

        //refactored from above
        [TestCase("badfile.foo", false)]
        [TestCase("goodfile.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
        {
            LogAnalyzer la = MakeAnalyzer();

            la.IsValidLogFileName(file);

            Assert.AreEqual(expected, la.WasLastFileNameValid);
        }
    }
}
