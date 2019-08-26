using System;
using System.Threading.Tasks;
using System.Xml;

namespace TestLogsAnalyzer.Lib
{
    public class FileManager
    {
        public static XmlDocument GetDocument(IReadableFile aReadableFile, string fileName)
        {
            aReadableFile.LoadContent(fileName);
            return aReadableFile.GetContent<XmlDocument>();
        }
    }
}
