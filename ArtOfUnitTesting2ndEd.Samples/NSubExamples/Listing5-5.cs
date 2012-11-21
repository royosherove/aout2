using System;
using Chapter5.LogAn;
using NSubstitute;
using NUnit.Framework;

namespace NSubExamples
{
    [TestFixture]
    class LogAnalyzerTestsWithHandWrittenFakes
    {
        [Test]
        public void Analyze_LoggerThrows_CallsWebService()
        {
           FakeWebService mockWebService = new FakeWebService();

           FakeLogger2 stubLogger = new FakeLogger2();
           stubLogger.WillThrow = new Exception("fake exception");

            LogAnalyzer2 analyzer2 = new LogAnalyzer2(stubLogger, mockWebService);
                 analyzer2.MinNameLength = 8;
        
            string tooShortFileName="abc.ext";
            analyzer2.Analyze(tooShortFileName);

            Assert.That(mockWebService.MessageToWebService,
                            Is.StringContaining("fake exception"));
        }
    }
    public class FakeWebService:IWebService
    {
        public string MessageToWebService;

        public void Write(string message)
        {
            MessageToWebService = message;
        }
    }

    public class FakeLogger2:ILogger
    {
        public Exception WillThrow = null;
        public string LoggerGotMessage = null;


        public void LogError(string message)
        {
            LoggerGotMessage = message;
            if (WillThrow != null)
            {
                throw WillThrow;
            }
        }
    }

    }


    public interface IPerson
    {
        IPerson GetManager();
    }



