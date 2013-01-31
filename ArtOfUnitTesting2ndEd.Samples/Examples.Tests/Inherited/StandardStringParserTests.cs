using AOUT.CH6.LogAN;
using NUnit.Framework;

namespace Examples.Tests.Inherited
{
    [TestFixture]
    public class StandardStringParserTests : FillInTheBlanksStringParserTests
    {
        protected override string HeaderVersion_SingleDigit
        {get { return string.Format("header\tversion={0}\t\n", EXPECTED_SINGLE_DIGIT); }}

        protected override string HeaderVersion_WithMinorVersion
        {get { return string.Format("header\tversion={0}\t\n", EXPECTED_WITH_MINORVERSION); }}

        protected override string HeaderVersion_WithRevision
        {get { return string.Format("header\tversion={0}\t\n", EXPECTED_WITH_REVISION); }}

        protected override IStringParser GetParser(string input)
        {
            return new StandardStringParser(input);
        }
    }
    
    [TestFixture]
    public class XMLStringParserTests: FillInTheBlanksStringParserTests
    {
        protected override string HeaderVersion_SingleDigit
        { get { return string.Format("<Header><Version>{0}<Version></Header>", EXPECTED_SINGLE_DIGIT); }}

        protected override string HeaderVersion_WithMinorVersion
        {get { return string.Format("<Header><Version>{0}<Version></Header>", EXPECTED_WITH_MINORVERSION);; }}

        protected override string HeaderVersion_WithRevision
        {get { return string.Format("<Header><Version>{0}<Version></Header>", EXPECTED_WITH_REVISION); }}

        protected override IStringParser GetParser(string input)
        {
            return new XMLStringParser(input);
        }
    }
    [TestFixture]
    public class IISLogParserTests: FillInTheBlanksStringParserTests
    {
        protected override IStringParser GetParser(string input)
        {
            return new IISLogStringParser(input);
        }

        protected override string HeaderVersion_SingleDigit
        {get { return "header;version=1;\n"; }}

        protected override string HeaderVersion_WithMinorVersion
        {get { return "header;version=1.1;\n"; }}

        protected override string HeaderVersion_WithRevision
        {get { return "header;version=1.1.1;\n"; }}

        [Test]
        public void ExtraTestForGoodMeasure()
        {
            //some test that is specific for this class
        }

    }
}
