using System;
using System.IO;
using System.Xml;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLogsAnalyzer.Lib;
using Moq;

namespace TestLogsAnalyzer.Tests
{
    [TestClass]
    public class ReadableFileTest
    {
        [TestMethod]
        public void TestLoadContent()
        {

            IReadableFile readableFile = new TestLogsAnalyzer.Lib.Fakes.StubIReadableFile()
            {
                LoadContentString = (fileName) => { new XmlDocument().Load(Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData), "SampleTrxXMLTestLogFile.trx")); }
            };
            readableFile.LoadContent("dummyName");

            using (ShimsContext.Create())
            {
                System.IO.Fakes.ShimPath.CombineStringString = (folderPath, fileName) =>
                {
                    return "C:\\ProgramData\\SampleTrxXMLTestLogFile.trx";
                };
                var logFile = new LogFile();
                logFile.LoadContent("dummyName");
            }

        }
        [TestMethod]
        public void TestGetContent()
        {
            /*XmlDocument doc = new XmlDocument();
            doc.Load(Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData), "SampleTrxXMLTestLogFile.trx"));

            var readalbeFile = new TestLogsAnalyzer.Lib.Fakes.StubIReadableFile();
            readalbeFile.GetContentOf1(() =>
                doc
            );*/
            var mock = new Mock<IReadableFile>();
            mock.Setup(file => file.GetContent<XmlDocument>()).Returns(new XmlDocument());
            

            using (ShimsContext.Create())
            {
                TestLogsAnalyzer.Lib.Fakes.ShimLogFile logFile = new TestLogsAnalyzer.Lib.Fakes.ShimLogFile();
                logFile.GetContentOf1(() =>
                    new XmlDocument()
                );
            }
        }
    }
}
