using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0501_normalReader
{
    public class InputValidator
    {
        public string ValidateFilePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be empty.");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified file does not exist.", filePath);

            return filePath;
        }
    }
}