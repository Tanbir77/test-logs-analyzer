using System;
using System.Configuration;
using System.Xml;
using TestLogsAnalyzer.Lib;

namespace TestLogsAnalyzer.Lib
{
    class Starter
    {
        static void Main(string[] args)
        {
            XmlDocument doc = FileManager.GetDocument(new LogFile(), ConfigurationManager.AppSettings["logFileName"]);
            ILogAnalyzer analyser = new LogAnalyzer();
            analyser.ShowNonPassingTestsList<XmlDocument>(doc);
            Console.ReadKey();
        }
    }
}
