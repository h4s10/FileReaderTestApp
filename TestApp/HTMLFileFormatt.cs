using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Xml;

namespace TestApp
{
    public class HTMLFileFormatt : IFileCreator<FileInformation>
    {
        public void Save(IEnumerable<FileInformation> fileCollection)
        {
            try
            {
                using (StreamWriter fs = File.CreateText(Directory.GetCurrentDirectory() + @"\index.html"))
                {               
                    var doc = new XmlDocument();
                    var table = doc.CreateElement("table");
                    table.AppendChild(doc.CreateElement("tr"));
                    foreach (var prop in fileCollection.First().GetType().GetProperties())
                    {
                        var table_head = doc.CreateElement("th");
                        table_head.AppendChild(doc.CreateTextNode(prop.Name));
                        table.ChildNodes[0].AppendChild(table_head);
                    }
                    foreach (var fileInfo in fileCollection)
                    {
                        var table_row = doc.CreateElement("tr");
                        foreach (var prop in fileCollection.First().GetType().GetProperties())
                        {
                            var td = doc.CreateElement("td");
                            td.AppendChild(doc.CreateTextNode(prop.GetValue(fileInfo).ToString()));
                            table_row.AppendChild(td);
                        }
                        table.AppendChild(table_row);
                    }
                    var root = doc.CreateElement("html");
                    var body = doc.CreateElement("body");
                    body.AppendChild(table);
                    root.AppendChild(body);
                    doc.AppendChild(root);
                    fs.WriteLine(doc.OuterXml);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
