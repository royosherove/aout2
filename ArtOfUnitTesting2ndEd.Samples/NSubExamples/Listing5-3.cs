using Chapter5.LogAn;
using NSubstitute;
using NUnit.Framework;

namespace NSubExamples
{
    [TestFixture]
    class LogAnalyzerTests
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            ILogger logger = Substitute.For<ILogger>();

            LogAnalyzer analyzer = new LogAnalyzer(logger);

            analyzer.MinNameLength = 6;
            analyzer.Analyze("a.txt");

           logger.Received().LogError("Filename too short: a.txt");
        }

        [Test]
        public void Analyze_TooShortFileName_CallLoggerArgMatchers()
        {
            ILogger logger = Substitute.For<ILogger>();

            LogAnalyzer analyzer = new LogAnalyzer(logger);

            analyzer.MinNameLength = 6;
            analyzer.Analyze("a.txt");

           logger.Received().LogError(Arg.Is<string>(s => s.Contains("too short")));
        }
    }
}
