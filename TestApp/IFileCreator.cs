using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    /// <summary>
    /// Интерфейс для преобразовании объектов в файл
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFileCreator<T>
    {
        bool Save(List<T> fileCollection);
    }
}
