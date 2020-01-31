using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class FileInformation
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Расширение файла
        /// </summary>
        public string FileExtension { get; set; }

        /// <summary>
        /// Размер файла в байтах
        /// </summary>
        public float FileSize { get; set; }

        /// <summary>
        /// Абсолютный путь вместе с названием файла
        /// </summary>
        public string FilePath { get; set; }
    }
}
