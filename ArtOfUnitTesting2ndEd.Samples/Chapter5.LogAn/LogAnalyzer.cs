using System;

namespace Chapter5.LogAn
{
    public class LogAnalyzer
    {
        private ILogger _logger;

        public LogAnalyzer(ILogger logger)
        {
            _logger = logger;
        }

        public int MinNameLength { get; set; }

        public void Analyze(string filename)
        {
            if (filename.Length<MinNameLength)
            {
                _logger.LogError(string.Format("Filename too short: {0}",filename));
            }
        }
    }
    
    public class LogAnalyzer2
    {
        private ILogger _logger;
        private IWebService _webService;


        public LogAnalyzer2(ILogger logger,IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public int MinNameLength { get; set; }

        public void Analyze(string filename)
        {
            if (filename.Length<MinNameLength)
            {
                try
                {
                    _logger.LogError(string.Format("Filename too short: {0}",filename));
                }
                catch (Exception e)
                {
                    _webService.Write("Error From Logger: " + e);

                }
            }
        }
    }
    public class LogAnalyzer3
    {
        private ILogger _logger;
        private IWebService _webService;


        public LogAnalyzer3(ILogger logger,IWebService webService)
        {
            _logger = logger;
            _webService = webService;
        }

        public int MinNameLength { get; set; }

        public void Analyze(string filename)
        {
            if (filename.Length<MinNameLength)
            {
                try
                {
                    _logger.LogError(string.Format("Filename too short: {0}",filename));
                }
                catch (Exception e)
                {
                    _webService.Write(new ErrorInfo(1000, e.ToString()));

                }
            }
        }
    }

    public class ErrorInfo
    {
        private readonly int _severity;
        private readonly string _message;

        public ErrorInfo(int severity, string message)
        {
            _severity = severity;
            _message = message;
        }

        public int Severity
        {
            get { return _severity; }
        }

        public string Message
        {
            get { return _message; }
        }
    }

    public interface IWebService
    {
        void Write(string message);
        void Write(ErrorInfo message);
    }
}
