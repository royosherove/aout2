using System;

namespace AOUT.CH6.LogAN
{
    public abstract class BaseStringParser : IStringParser
    {
        private string stringToParse;

        public string StringToParse
        {
            get { return stringToParse; }
        }

        protected BaseStringParser(string filename)
        {
            this.stringToParse = filename;
        }

        public abstract bool HasCorrectHeader();
        public abstract string GetTextVersionFromHeader();
    }


    public class XMLStringParser:BaseStringParser
    {
        public XMLStringParser(string toParse) 
            : base(toParse){}

        public override bool HasCorrectHeader()
        {
            //use the logic that parses the XML Header
            return false;
        }

        public override string GetTextVersionFromHeader()
        {
            //Use logic to get version from XML Header
            return String.Empty;
        }
    }

    public class IISLogStringParser : BaseStringParser
    {
        public IISLogStringParser(string toParse)
            : base(toParse) { }

        public override bool HasCorrectHeader()
        {
            //use the logic that parses the XML Header
            return false;
        }

        public override string GetTextVersionFromHeader()
        {
            //Use logic to get version from XML Header
            return "";
        }
    }
    public class StandardStringParser : BaseStringParser
    {
        public StandardStringParser(string toParse)
            : base(toParse) { }

        public override bool HasCorrectHeader()
        {
            //use the logic that parses the XML Header
            return false;
        }

        public override string GetTextVersionFromHeader()
        {
            //Use logic to get version from XML Header
            return "";
        }
    }
}
