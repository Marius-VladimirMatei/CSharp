using System;
using System.Threading.Tasks;
using _0501_asyncReader.Validators;

namespace _0501_asyncReader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Create instances of the classes
            var validator = new InputValidator();
            var fileReader = new FileReader();
            var progressIndicator = new ProgressIndicator();

            try
            {
                string filePath = validator.ValidateFilePath("test.txt"); // Use validator for the file path
                progressIndicator.Start(); // Start the progress indicator
                string content = await fileReader.ReadFileAsync(filePath); // Read the file asynchronously and wait until the ReadFileAsync method is completed
                progressIndicator.Stop(); // Stop the progress indicator once the red is done

                // Print the file contents to the console
                Console.WriteLine("File contents:");
                Console.WriteLine(content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadLine();
        }
    }
}
