using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using _0603_invoiceManager_non_mvvm.Services;
using _0603_invoiceManager_non_mvvm.Views;

namespace _0603_invoiceManager_non_mvvm.Views
{
    // Code-behind for LoginWindow.xaml, handling login logic directly (non-MVVM)
    public partial class LoginWindow : Window
    {
        private readonly IValidationService _validationService;

        public LoginWindow()
        {
            InitializeComponent();

            // Inject validation service (DIP)
            _validationService = new ValidationService();

            // Wire button click and Enter key to the login action
            loginButton.Click += (s, e) => PerformLogin();
            this.PreviewKeyDown += Window_PreviewKeyDown;
        }

        // Handle Enter key globally to trigger login
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PerformLogin();
                e.Handled = true;
            }
        }

        // Reads user inputs, validates, and transitions to MainWindow on success
        private void PerformLogin()
        {
            var username = usernameTextBox.Text;
            var password = passwordBox.Password;

            // Validate credentials via service
            if (!_validationService.ValidateLogin(username, password))
            {
                MessageBox.Show("Invalid username or password.", "Login Failed",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Upon successful login, open the main window and close login
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
