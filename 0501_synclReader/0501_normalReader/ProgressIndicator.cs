using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0501_normalReader
{
    class ProgressIndicator
    {
        private volatile bool _isRunning;
        private Thread _thread;

        public void Start()
        {
            _isRunning = true;
            _thread = new Thread(ProgressLoop);
            _thread.Start();
        }

        private void ProgressLoop()
        {
            while (_isRunning)
            {
                Console.WriteLine("Loading file...");
                Thread.Sleep(500);
            }
        }

        public void Stop()
        {
            _isRunning = false;
            _thread.Join();
        }
    }
}