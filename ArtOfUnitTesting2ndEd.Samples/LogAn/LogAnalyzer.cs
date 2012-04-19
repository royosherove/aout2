using System;

namespace LogAn
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }

        public bool IsValidLogFileName(string fileName)
        {
            WasLastFileNameValid = false;

            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException("filename has to be provided");
            }
            if (!fileName.EndsWith(".SLF",StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }

            WasLastFileNameValid = true;
            return true;
        }

    }
}
