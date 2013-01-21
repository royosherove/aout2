using AOUT.CH6.LogAN;
using NUnit.Framework;

namespace AOUT.CH6.LogAn.Tests
{
    [TestFixture]
    public class StandardStringParserTests : BaseStringParserTests
    {
        protected override IStringParser GetParser(string input)
        {
            return new StandardStringParser(input);
        }
    }
    
    [TestFixture]
    public class XMLStringParserTests: BaseStringParserTests
    {
        protected override IStringParser GetParser(string input)
        {
            return new XMLStringParser(input);
        }
    }
    [TestFixture]
    public class IISLogParserTests: BaseStringParserTests
    {
        protected override IStringParser GetParser(string input)
        {
            return new IISLogStringParser(input);
        }

        [Test]
        public void GetStringVersionFromHeader_DoubleDigit_Found()
        {
            string input = "header;version=11;\n";
            IStringParser parser = GetParser(input);

            string versionFromHeader = parser.GetTextVersionFromHeader();
            Assert.AreEqual("11", versionFromHeader);
        }

    }
}
