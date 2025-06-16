using System;
using System.Windows;
using System.Windows.Controls;
using _0603_invoiceManager_Sync_MVVM.ViewModels;

namespace _0603_invoiceManager_Sync_MVVM.Views
{
    // Code-behind for LoginWindow.xaml
    // Handles the login logic and interaction with the LoginViewModel
    // Extends Window to create a WPF window for user login
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            // Set DataContext to LoginViewModel
            var viewModel = DataContext as LoginViewModel;

            // Subscribe to success action to open MainWindow
            // Public action OnLoginSuccess is invoked when login is successful => when login is successful, the MainWindow is shown and the LoginWindow is closed.
            viewModel.OnLoginSuccess = () =>
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            };
        }

        // Handler to propagate PasswordBox changes into the ViewModel
        // This method is called when the password in the PasswordBox changes
        // It updates the Password property in the LoginViewModel
        // WPF does not bind PasswordBox.Password directly => handle the PasswordChanged event is needed

        //Casts the DataContext back to LoginViewModel => Casts the sender to a PasswordBox =>  Reads passwordBox.Password (the plaintext the user just typed) and assigns it to viewModel.Password.
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as LoginViewModel;
            if (viewModel != null)
            {
                var passwordBox = sender as System.Windows.Controls.PasswordBox;
                viewModel.Password = passwordBox.Password;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
