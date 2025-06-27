using System.Windows;
using System.Windows.Controls;
using _0801_Customer_Management_GUI_DB.ViewModels;

namespace _0801_Customer_Management_GUI_DB.Views
{
    // LoginView inherits from UserControl – building block for the login interface
    public partial class LoginView : UserControl
    {
        private readonly LoginViewModel _viewModel;

        public LoginView()
        {
            InitializeComponent();      // wires  the XAML to the code-behind
            _viewModel = new LoginViewModel();
            DataContext = _viewModel;   // sets the ViewModel for bindings
        }

        // Copyes the PasswordBox.Password into the VM before the LoginCommand fires
        private void OnLoginButtonClick(object sender, RoutedEventArgs e)
        {
            _viewModel.Password = PasswordBox.Password;
        }
    }
}
