// File: Services/FileService.cs
using System;
using System.IO;

namespace _0603_invoiceManager_non_mvvm.Services
{
    // Concrete implementation of IFileService
    // Writes invoice text to a timestamped .txt file in user's Documents
    public class FileService : IFileService
    {
        private readonly string _outputFolder;

        public FileService()
        {
            _outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public string SaveText(string content)
        {
            // Build filename with timestamp
            string filename = Path.Combine(_outputFolder, $"Invoice_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
            File.WriteAllText(filename, content);
            return filename;
        }
    }
}