// File: Services/IFileService.cs
namespace _0603_invoiceManager_non_mvvm.Services
{
    // Abstraction for file I/O operations (SRP & DIP compliance)
    public interface IFileService
    {
        // Saves given text content to a file and returns the full path
        string SaveText(string content);
    }
}



