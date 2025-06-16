using System;
using System.IO;

namespace _0603_invoiceManager_Sync_MVVM.Services
{
    // Service for saving invoice files - save .txt or .doc)
    public static class FileService
    {
        private static readonly string OutputFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Saves content to a .txt file and returns the filename
        public static string SaveAsTxt(string content)
        {
            var filename = Path.Combine(OutputFolder, $"Invoice_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
            File.WriteAllText(filename, content);
            return filename;
        }

        // Saves content to a .doc file (plain text with .doc extension) and returns the filename
        public static string SaveAsDoc(string content)
        {
            var filename = Path.Combine(OutputFolder, $"Invoice_{DateTime.Now:yyyyMMdd_HHmmss}.doc");
            File.WriteAllText(filename, content);
            return filename;
        }
    }
}
