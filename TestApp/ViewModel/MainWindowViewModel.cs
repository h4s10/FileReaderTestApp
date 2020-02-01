using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestApp
{
    public class MainWindowViewModel : ObservableObject
    {
        #region Commands
        public ICommand ReadFilesInDirectoryCommand { get; }
        public ICommand SaveToFileCommand { get; }
        #endregion Commands

        #region Properties
        private ObservableCollection<FileInformation> _FilesCollection;
        /// <summary>
        /// Коллекция файлов в указанной директории и вложенных папках
        /// </summary>
        public ObservableCollection<FileInformation> FilesCollection
        {
            get => _FilesCollection;
            set => OnPropertyChanged(ref _FilesCollection, value);
        }
        #endregion Properties

        public MainWindowViewModel(IFileCreator<FileInformation> fileCreator)
        {
            ReadFilesInDirectoryCommand = new RelayCommand(x => ReadFilesInDirectory(Directory.GetCurrentDirectory()), x => true);//Current Directory
            SaveToFileCommand = new RelayCommand(x => fileCreator.Save(FilesCollection.ToList()), x => true);
        }

        private void ReadFilesInDirectory(string path)
        {
            FilesCollection = new ObservableCollection<FileInformation>();
            var filepaths = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            foreach(var filepath in filepaths)
            {
                var fileInfo = new FileInformation();
                fileInfo.FileExtension = Path.GetExtension(filepath);
                fileInfo.FileName = Path.GetFileName(filepath);
                fileInfo.FilePath = Path.GetFullPath(filepath);
                fileInfo.FileSize = new FileInfo(filepath).Length;
                FilesCollection.Add(fileInfo);
            }
        }
    }
}
