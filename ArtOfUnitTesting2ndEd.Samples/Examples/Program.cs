using System;
using System.Windows.Forms;

namespace Examples
{
    public static class LoggingFacility
    {
        public static void Log(string text)
        {
            logger.Log(text);
        }
        private static ILogger logger;

        public static ILogger Logger
        {
            get { return logger; }
            set { logger = value; }
        }
    }

    public interface ILogger
    {
        void Log(string text);
    }

    //This class uses the LoggingFacility Internally
    public class LogAnalyzer
    {
        public void Analyze(string fileName)
        {
            if (fileName.Length < 8)
            {
                LoggingFacility.Log("Filename too short:" + fileName);
            }
            //rest of the method here
        }
    }

    //another class that uses the LoggingFacility internally
    public class ConfigurationManager
    {
        public bool IsConfigured(string configName)
        {
            LoggingFacility.Log("checking " + configName);
            return true; //just fo demo
        }
    }



    public static class TimeLogger
    {
        public static string CreateMessage(string info)
        {
            return SystemTime.Now.ToShortDateString() + " " + info;
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}