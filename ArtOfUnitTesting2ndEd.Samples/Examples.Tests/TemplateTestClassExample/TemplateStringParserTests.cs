using System;
using AOUT.CH6.LogAN;
using NUnit.Framework;

namespace Examples.Tests.Templated
{
    [TestFixture]
    public abstract class TemplateStringParserTests
    {
        public abstract void TestGetStringVersionFromHeader_SingleDigit_Found();

        public abstract void TestGetStringVersionFromHeader_WithMinorVersion_Found();

        public abstract void TestGetStringVersionFromHeader_WithRevision_Found();
    }

    [TestFixture]
    public class XmlStringParserTests : TemplateStringParserTests
    {
        protected IStringParser GetParser(string input)
        {
            return new XMLStringParser(input);
        }

        [Test]
        public override void TestGetStringVersionFromHeader_SingleDigit_Found()
        {
            IStringParser parser = GetParser("<Header>1</Header>");

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual("1",versionFromHeader);
        }

        [Test]
        public override void TestGetStringVersionFromHeader_WithMinorVersion_Found()
        {
            IStringParser parser = GetParser("<Header>1.1</Header>");

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual("1.1",versionFromHeader);
        }

        [Test]
        public override void TestGetStringVersionFromHeader_WithRevision_Found()
        {
            IStringParser parser = GetParser("<Header>1.1.1</Header>");

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual("1.1.1",versionFromHeader);
        }
    }
}