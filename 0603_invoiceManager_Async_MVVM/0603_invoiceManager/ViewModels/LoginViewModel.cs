using System;
using System.Windows;
using System.Windows.Input;
using _0603_invoiceManager_Async_MVVM.Helpers;
using _0603_invoiceManager_Async_MVVM.Services;

namespace _0603_invoiceManager_Async_MVVM.ViewModels


    // ViewModel for the login page - simple login mechanism
    // LoginViewModel inherits from BaseViewModel to utilize INotifyPropertyChanged and SetProperty helper
{
 
    public class LoginViewModel : BaseViewModel
    {
        // Properties to store the values for username and password
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }                   // Getter returns the current value of _username
            set { SetProperty(ref _username, value); }  // Setter calls SetProperty to check if the value has changed and notify the UI
        }

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        // LoginCommand is the command the login button binds to - implements ICommand so WPF can enable/disable and invoke it.
        public ICommand LoginCommand { get; }

        // Callback action to execute when login is successful
        public Action OnLoginSuccess { get; set; }

        //Constructor initializes LoginCommand by passing in the ExecuteLogin method.
        // RelayCommand always returns true from CanExecute => Login button is always enabled.
        public LoginViewModel()
        {
            // Removed predicate; always enabled
            LoginCommand = new AsyncRelayCommand(ExecuteLogin);
        }



        // Updated ExecuteLogin method to return Task instead of void
        private async Task ExecuteLogin()
        {
            bool isValid = ValidationService.ValidateLogin(Username, Password);
            if (isValid)
            {
                OnLoginSuccess?.Invoke();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}







