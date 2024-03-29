﻿using System;
using System.IO;
using System.Xml;

namespace TestLogsAnalyzer.Lib
{
    public class LogFile : IReadableFile
    {
        private XmlDocument doc;


        public void LoadContent(string fileName)
        {
            string folderLocation = Environment.GetFolderPath(System.Environment.SpecialFolder.CommonApplicationData);
            try
            {
                doc = new XmlDocument();
                doc.Load(Path.Combine(folderLocation, fileName));
            }
            catch (FileNotFoundException e)
            {
                doc = null;
                Console.WriteLine(e.Message+"Rebuild your solution");
            }
        }

        public T GetContent<T>()
        {
            return (T)Convert.ChangeType(doc, typeof(T));
        }
    }
}
