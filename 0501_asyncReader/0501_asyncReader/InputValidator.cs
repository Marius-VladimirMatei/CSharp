using System;
using System.IO;

namespace _0501_asyncReader.Validators
{
    class InputValidator
    {
        public string ValidateFilePath(string filePath)
        {
            try
            {   // Ensure the file path is not null or empty
                if (string.IsNullOrWhiteSpace(filePath))
                    throw new ArgumentException("File path cannot be empty.");

                // Ensure the file path is a valid path
                if (!File.Exists(filePath))
                    throw new FileNotFoundException("The specified file does not exist.", filePath);

                return filePath;
            }
            catch (ArgumentException)
            {
                // Re-Throw exeption to be handled by the caller in order to preserve the original stack trace
                throw;
            }
            catch (FileNotFoundException)
            {
                // missing file
                throw;
            }
            catch (Exception ex)
            {
                // unexpected error during validation
                throw new ApplicationException("Unexpected error during file-path validation.", ex);
            }
        }
    }
}
