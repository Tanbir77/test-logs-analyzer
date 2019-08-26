using System;
using System.Xml;

namespace TestLogsAnalyzer.Lib
{
    public class LogAnalyzer : ILogAnalyzer
    {
        public void ShowNonPassingTestsList<T>(T t)
        {
            XmlDocument doc = (XmlDocument)Convert.ChangeType(t, typeof(XmlDocument));
            XmlNodeList testNodeList = doc.GetElementsByTagName("UnitTest");
            XmlNodeList resultNodeList = doc.GetElementsByTagName("UnitTestResult");
            Console.WriteLine("\t\t\t\t\t*******List of all non-passing tests*******");
            Console.Write("--------------------------------------------------------------");
            Console.WriteLine("----------------------------------------------------------");
            int total = 0;
            for (int i = 0; i < testNodeList.Count; i++)
            {
                string id = testNodeList.Item(i).Attributes.GetNamedItem("id").Value;
                for (int j = 0; j < resultNodeList.Count; j++)
                {
                    if (id.Equals(resultNodeList.Item(j).Attributes.GetNamedItem("testId").Value) && !resultNodeList.Item(j).Attributes.GetNamedItem("outcome").Value.Equals("Passed"))
                    {
                        Console.Write("[" + ++total + "] ");
                        Console.Write(testNodeList.Item(i).LastChild.Attributes.GetNamedItem("className").Value);
                        Console.Write("->");
                        Console.Write(testNodeList.Item(i).LastChild.Attributes.GetNamedItem("name").Value);
                        Console.Write("->");
                        Console.WriteLine(resultNodeList.Item(j).Attributes.GetNamedItem("outcome").Value);
                    }
                }

            }
        }
    }
}
