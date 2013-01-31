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
            //missing here: logic that parses xml
            return false;
        }

        public override string GetTextVersionFromHeader()
        {
            //missing here: logic that parses xml
            return String.Empty;
        }
    }

    public class IISLogStringParser : BaseStringParser
    {
        public IISLogStringParser(string toParse)
            : base(toParse) { }

        public override bool HasCorrectHeader()
        {
            //missing here: real implementation
            return false;
        }

        public override string GetTextVersionFromHeader()
        {
            //missing here: real implementation
            return "";
        }
    }
    public class StandardStringParser : BaseStringParser
    {
        public StandardStringParser(string toParse)
            : base(toParse) { }

        public override bool HasCorrectHeader()
        {
            //missing here: real implementation
            return false;
        }

        public override string GetTextVersionFromHeader()
        {
            //missing here: real implementation
            return "";
        }
    }
}
