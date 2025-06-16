
using System.Windows.Input; // for ICommand interface actions that UI can invoke

namespace _0603_invoiceManager_Async_MVVM.Helpers
{
    // Simple ICommand implementation for MVVM bindings
    // Lets ViewModels expose ICommand properties for binding buttons in XAML
    // Allows binding UI actions to methods in ViewModels
   
    public class AsyncRelayCommand : ICommand
    {
        private readonly Func<Task> _execute;     // async method to run
        private bool _isExecuting;                // flag to prevent re-entry

        // Event to notify UI when CanExecute state changes
        public event EventHandler CanExecuteChanged;

        // Constructor accepts only the async method to execute
        public AsyncRelayCommand(Func<Task> execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        // Command is enabled only when not already executing
        public bool CanExecute(object parameter) => !_isExecuting;

        // Execute() is how WPF triggers the command
        // Run the async method, updating the executing flag and raising CanExecuteChanged
        public async void Execute(object parameter)
        {
            if (!CanExecute(parameter))
                return;

            _isExecuting = true;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

            try
            {
                await _execute();
            }
            finally
            {
                _isExecuting = false;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
