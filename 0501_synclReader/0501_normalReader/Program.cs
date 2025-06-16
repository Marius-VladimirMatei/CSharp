using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0501_normalReader
{
    class Program
    {
        static void Main(string[] args)
        {
            var validator = new InputValidator();
            var fileReader = new FileReader();

            try
            {
                string filePath = validator.ValidateFilePath("test.txt");
                string content = fileReader.ReadFile(filePath);

                Console.WriteLine("\nFile contents:");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
