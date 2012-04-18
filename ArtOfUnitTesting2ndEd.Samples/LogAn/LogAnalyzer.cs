using System;
using System.Globalization;

namespace LogAn
{
    public class LogAnalyzer
    {
        public bool IsValidLogFileName(string fileName)
        {
            if (!fileName.EndsWith(".SLF",StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            return true;
        }

    }
}
