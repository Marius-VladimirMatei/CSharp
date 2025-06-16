
using System.Windows;

namespace _0601_emplManager
{
    public partial class MainWindow : Window
    {
        private readonly EmployeeController _controller = new EmployeeController();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Submit definition for the button click event
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Delegate all logic to the controller
                string message = _controller.AddEmployee(
                    NameTextBox.Text,
                    AgeTextBox.Text);

                ResultTextBlock.Text = message;
            }
            catch (ValidationException vex)
            {
                // Friendly feedback on validation errors
                ResultTextBlock.Text = $"Error: {vex.Message}";
            }
            catch (Exception ex)
            {
                // Catch-all for unexpected exceptions
                ResultTextBlock.Text = $"Unexpected error: {ex.Message}";
            }
        }

        // Display definition for the button click event
        private void DisplayAllButton_Click(object sender, RoutedEventArgs e)
        {
            // Load and display every record
            ResultTextBlock.Text = _controller.DisplayAllEmployees();
        }
    }
}