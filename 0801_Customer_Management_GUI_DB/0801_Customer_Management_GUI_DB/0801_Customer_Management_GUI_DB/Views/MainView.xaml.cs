using System.Windows;
using System.Windows.Controls;
using _0801_Customer_Management_GUI_DB.ViewModels;

namespace _0801_Customer_Management_GUI_DB.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // any startup logic
        }

        // Handle row edit ending events 
        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
           
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            // 1-based row index in the row header
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }




    }
}
