
using System.Windows;

using _0801_Customer_Management_GUI_DB.Views;

namespace _0801_Customer_Management_GUI_DB

{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Load LoginView first
            MainContent.Content = new LoginView();
        }

        // Method to swap views (can be called after login)
        public void ShowMainView()
        {
            MainContent.Content = new MainView();
        }
    }
}