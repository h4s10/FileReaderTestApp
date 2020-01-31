using System;
using System.Collections.Generic;
using System.IO;

namespace TestApp
{
    public class HTMLFileFormatt : IFileCreator<FileInformation>
    {
        public bool Save(List<FileInformation> fileCollection)
        {
            try
            {
                using (StreamWriter fs = File.CreateText(Directory.GetCurrentDirectory() + @"\index.html"))
                {
                    fs.WriteLine("<table border = \"1\">");

                    fs.WriteLine("<tr>");
                    foreach (var prop in fileCollection[0].GetType().GetProperties())
                        fs.WriteLine(string.Format("<th>{0}</th>", prop));
                    fs.WriteLine("</tr>");

                    foreach (var fileInfo in fileCollection)
                    {
                        fs.WriteLine("<tr>");
                        foreach (var prop in fileCollection[0].GetType().GetProperties())
                            fs.WriteLine(string.Format("<td>{0}</td>", prop.GetValue(fileInfo)));
                        fs.WriteLine("</tr>");
                    }

                    fs.WriteLine("</table>");
                    fs.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
