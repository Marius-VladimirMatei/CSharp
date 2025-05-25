using System;
using System.Threading.Tasks; // GIves the possibility to use the Task class and async/await modifiers

namespace _0501_asyncReader
{
    // Prints a recuring message to the console while a file is being read until the reading is complete and Stop() is called
    class ProgressIndicator
    {
        private bool _isRunning; // Flag to indicate if the progress indicator is running
        private Task _progressTask; // Task to run the progress indicator

        public void Start()
        {
            _isRunning = true; // Turn on the loop
            _progressTask = Task.Run(ProgressLoop); // Start the progress loop in a new task
        }
        private async Task ProgressLoop() // Use Task to be runned now or in the future
        {
            while (_isRunning)
            {
                Console.WriteLine("Loading file...");
                await Task.Delay(500); // Asynchronous delay for 500 milliseconds before the next iteration
            }
        }

        // Stops the progress indicator by setting the _isRunning flag to false and waiting for the task to complete
        public void Stop()
        {
            _isRunning = false;
            _progressTask?.Wait();
        }
    }
}
