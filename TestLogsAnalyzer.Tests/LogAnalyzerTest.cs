using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLogsAnalyzer.Lib;

namespace TestLogsAnalyzer.Tests
{
    [TestClass]
    public class LogAnaylyzerTest
    {
        [TestMethod]
        public void TestShowNonPassingTestsList()
        {
            var analyzer = new TestLogsAnalyzer.Lib.Fakes.StubILogAnalyzer();
            analyzer.ShowNonPassingTestsListOf1M0<XmlDocument>((doc) =>
                Console.WriteLine(doc.ToString())
            );

            XmlDocument xmlDoc = FileManager.GetDocument(new LogFile(), "C:\\ProgramData\\SampleTrxXMLTestLogFile.trx");
            new LogAnalyzer().ShowNonPassingTestsList<XmlDocument>(xmlDoc);
        }
    }
}
