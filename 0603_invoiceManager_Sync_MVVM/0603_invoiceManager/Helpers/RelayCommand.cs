
using System.Windows.Input; // for ICommand interface actions that UI can invoke

namespace _0603_invoiceManager_Sync_MVVM.Helpers
{
 
    // Simple ICommand implementation for MVVM bindings
    // Lets VirewModels expose ICommand propperties for binding buttons in XAML
    // Allows binding UI actions to methods in ViewModels
    public class RelayCommand : ICommand
    // WPF buttons and other controls need ICommand interface of the DataContext to bind actions

    {
        private readonly Action _execute; // Action to execute when command is invoked


        // Event to notify UI when CanExecute state changes - part of ICommand interface
        // Result is that the buttons are always enabled.
        public event EventHandler CanExecuteChanged { add { } remove { } } 


        // Constructor accepts only the action to execute
        public RelayCommand(Action execute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
        }

        // Always true
        // CanExecute() is used to determine if the command can execute (shorthand version)
        public bool CanExecute(object parameter) => true;

        // Execute() is how WPF triggers the command and _execute() is the method to call
        public void Execute(object parameter) => _execute();
    }
}





