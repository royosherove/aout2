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
}
