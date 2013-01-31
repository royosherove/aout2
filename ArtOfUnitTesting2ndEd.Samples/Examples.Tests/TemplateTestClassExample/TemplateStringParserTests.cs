using System;
using AOUT.CH6.LogAN;
using NUnit.Framework;

namespace Examples.Tests.Templated
{
    [TestFixture]
    public abstract class TemplateStringParserTests
    {
        protected abstract IStringParser GetParser(string input);
        protected abstract string HeaderVersion_SingleDigit { get; }
        protected abstract string HeaderVersion_WithMinorVersion { get; }
        protected abstract string HeaderVersion_WithRevision { get; }
        public const string EXPECTED_SINGLE_DIGIT = "1";
        public const string EXPECTED_WITH_REVISION = "1.1.1";
        public const string EXPECTED_WITH_MINORVERSION = "1.1";


        public abstract void TestGetStringVersionFromHeader_SingleDigit_Found();


        public abstract void TestGetStringVersionFromHeader_WithMinorVersion_Found();

        public abstract void TestGetStringVersionFromHeader_WithRevision_Found();
    }

    [TestFixture]
    public class XmlStringParserTests : TemplateStringParserTests
    {
        protected override IStringParser GetParser(string input)
        {
            return new XMLStringParser(input);
        }

        protected override string HeaderVersion_SingleDigit
        {
            get { return "<Header>1</Header>"; }
        }

        protected override string HeaderVersion_WithMinorVersion
        {
            get { return "<Header>1.1</Header>"; }
        }

        protected override string HeaderVersion_WithRevision
        {
            get { return "<Header>1.1.1</Header>"; }
        }

        [Test]
        public override void TestGetStringVersionFromHeader_SingleDigit_Found()
        {
            string input = HeaderVersion_SingleDigit;
            IStringParser parser = GetParser(input);

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual(EXPECTED_SINGLE_DIGIT,versionFromHeader);
        }

        [Test]
        public override void TestGetStringVersionFromHeader_WithMinorVersion_Found()
        {
            string input = HeaderVersion_WithMinorVersion;
            IStringParser parser = GetParser(input);

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual(EXPECTED_WITH_MINORVERSION,versionFromHeader);
        }

        [Test]
        public override void TestGetStringVersionFromHeader_WithRevision_Found()
        {
            string input = HeaderVersion_WithRevision;
            IStringParser parser = GetParser(input);

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual(EXPECTED_WITH_REVISION,versionFromHeader);
        }
    }
}