using System;
using AOUT.CH6.LogAN;
using NUnit.Framework;

namespace Examples.Tests.Inherited
{
    public abstract class BaseStringParserTests
    {
        protected abstract IStringParser GetParser(string input);

        [Test]
        public void GetStringVersionFromHeader_SingleDigit_Found()
        {
            string input = "header;version=1;\n";
            IStringParser parser = GetParser(input);

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual("1",versionFromHeader);
        }

        [Test]
        public void GetStringVersionFromHeader_WithMinorVersion_Found()
        {
            string input = "header;version=1.1;\n";
            IStringParser parser = GetParser(input);

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual("1.1",versionFromHeader);
        }

        [Test]
        public void GetStringVersionFromHeader_WithRevision_Found()
        {
            string input = "header;version=1.1.1;\n";
            IStringParser parser = GetParser(input);

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual("1.1.1",versionFromHeader);
        }

        [Test]
        public void HasCorrectHeader_NoSpaces_ReturnsTrue()
        {
            string input = "header;version=1.1.1;\n";
            IStringParser parser = GetParser(input);

            bool result = parser.HasCorrectHeader();
            Assert.IsTrue(result);
        }

        [Test]
        public void HasCorrectHeader_WithSpaces_ReturnsTrue()
        {
            string input = "header ; version=1.1.1 ; \n";
            IStringParser parser = GetParser(input);

            bool result = parser.HasCorrectHeader();
            Assert.IsTrue(result);
        }

        [Test]
        public void HasCorrectHeader_MissingVersion_ReturnsFalse()
        {
            string input = "header; \n";
            IStringParser parser = GetParser(input);

            bool result = parser.HasCorrectHeader();
            Assert.IsFalse(result);
        }
    }
    public abstract class StringParserTests<T>
        where T:IStringParser
    {
        protected T GetParser(string input)
        {
            return (T) Activator.CreateInstance(typeof (T), input);
        }

        [Test]
        public void GetStringVersionFromHeader_SingleDigit_Found()
        {
            string input = "header; \n";
            T parser = GetParser(input);

            bool result = parser.HasCorrectHeader();
            Assert.IsFalse(result);
        }

        //more tests
        //...
   }
    [TestFixture]
    public class StandardStringParserGenericTests
                        :StringParserTests<StandardStringParser>
    {}
}