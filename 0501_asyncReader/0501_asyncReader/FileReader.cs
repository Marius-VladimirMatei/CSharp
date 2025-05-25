using System;
using System.IO;
using System.Threading.Tasks;

namespace _0501_asyncReader
{   // Class  responsible for reading the contents of the external file
    class FileReader
    {
        public async Task<string> ReadFileAsync(string filePath) 
        {
            try
            {   // Ensure the file path is not null or empty
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("The specified file was not found.", filePath);

                // variable to hold the file content
                string fileContent = "";
                using (var reader = new StreamReader(filePath)) // using statement to ensure the file is closed after reading
                {
                    string line; // variable to hold each line read from the file
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        fileContent += line + Environment.NewLine; // append each line to the fileContent variable
                    }
                } 
                return fileContent;
            }
            catch (FileNotFoundException)
            {
                // rethrow so caller can handle missing file specifically
                throw;
            }
            catch (Exception ex)
            {
                // wrap any other I/O or unexpected exceptions
                throw new IOException($"Error reading file at '{filePath}'", ex);
            }
        }
    }
}