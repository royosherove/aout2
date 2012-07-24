using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Chapter5.LogAn;
using NUnit.Framework;

namespace NSubExamples
{
    [TestFixture]
    class TestsWithoutAnIsolationFramework
    {
        [Test]
        public void Analyze_TooShortFileName_CallLogger()
        {
            FakeLogger logger = new FakeLogger();

            LogAnalyzer analyzer = new LogAnalyzer(logger);

            analyzer.MinNameLength= 6;
            analyzer.Analyze("a.txt");

            StringAssert.Contains("too short",logger.LastError);
        }
    }

    class FakeLogger: ILogger
    {
        public string LastError;

        public void LogError(string message)
        {
            LastError = message;
        }
    }
}
