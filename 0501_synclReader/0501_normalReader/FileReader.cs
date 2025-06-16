using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0501_normalReader
{
    public class FileReader
    {
        public string ReadFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException("The specified file was not found.", filePath);

            var fileContent = string.Empty;
            using (var reader = new StreamReader(filePath)) // Changed to traditional using statement
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    fileContent += line + Environment.NewLine;
                }
            }
            return fileContent;
        }
    }
}