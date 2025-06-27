
using System;
using System.Windows.Input;

namespace _0901_API_AI_app.Utilities
{
    // Simple ICommand implementation for MVVM commands
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;          // action to run
        private readonly Func<object, bool> _canExecute;   // predicate to check if execution is allowed

        // Raised when CanExecute changes
        public event EventHandler CanExecuteChanged;

        // Constructor with execute action and optional canExecute predicate
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        // Determines whether the command can run
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        // Executes the command action
        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        // Call this to notify the UI that CanExecute might have changed
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
