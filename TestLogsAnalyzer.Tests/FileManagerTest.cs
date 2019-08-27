using System;
using System.IO;
using System.Xml;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLogsAnalyzer.Lib;

namespace TestLogsAnalyzer.Tests
{
    [TestClass]
    public class FileManagerTest
    {
        [TestMethod]
        public void TestGetDocument()
        {
            using (ShimsContext.Create())
            {
                IReadableFile readableFile = new TestLogsAnalyzer.Lib.Fakes.StubIReadableFile()
                {
                    LoadContentString = (fileName) => { new XmlDocument().Load(Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData), "SampleTrxXMLTestLogFile.trx")); }
                };
                Assert.IsNull(FileManager.GetDocument(new LogFile(),"dummyFile"));
            }

        }
        
    }
}
