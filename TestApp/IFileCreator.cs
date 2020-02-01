using System.Collections.Generic;

namespace TestApp
{
    /// <summary>
    /// Интерфейс для преобразовании объектов в файл
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IFileCreator<T>
    {
        void Save(IEnumerable<T> fileCollection);
    }
}
