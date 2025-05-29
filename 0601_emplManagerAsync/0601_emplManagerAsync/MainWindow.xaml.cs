using System.Windows;

namespace _0601_emplManagerAsync
{
    public partial class MainWindow : Window
    {
        private readonly EmployeeController _controller = new EmployeeController();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Submit definition for the button click event
        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Delegate all logic to the controller
                string message = await _controller.AddEmployeeAsync(
                    NameTextBox.Text,
                    AgeTextBox.Text);

                ResultTextBlock.Text = message;

                // Clear input fields after successful submission
                NameTextBox.Clear();
                AgeTextBox.Clear();
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
        private async void DisplayAllButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Load and display every record
                string result = await _controller.DisplayAllEmployeesAsync();
                ResultTextBlock.Text = result;
            }
            catch (ValidationException vex)
            {
                // Validation errors from the controller
                ResultTextBlock.Text = $"Error: {vex.Message}";
            }
            catch (Exception ex)
            {
                // Anything unexpected
                ResultTextBlock.Text = $"Unexpected error: {ex.Message}";
            }
        }
    }
}