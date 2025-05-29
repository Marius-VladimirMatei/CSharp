using System.Windows;
using _0602_noteManager.Controllers;
using System.ComponentModel.DataAnnotations;
using _0602_noteManager.Storage;

namespace _0602_noteManager
{
    public partial class MainWindow : Window
    {
        private readonly NoteController _controller;

        public MainWindow()
        {
            InitializeComponent();
            _controller = new NoteController(new FileNoteStorage());
            _ = DisplayAllNotesAsync();
        }


        private async void AddButton_Click(object sender, RoutedEventArgs e) // Button click event handler for adding a new note
        {
            try
            { // Call the controller to add a new note
                var msg = await _controller.AddNoteAsync( // Take title and content from the input fields
                    TitleTextBox.Text,
                    ContentTextBox.Text);

                StatusTextBlock.Text = msg; // Send the message to the status text block

                // Clear inputs after success
                TitleTextBox.Clear();
                ContentTextBox.Clear();

                await DisplayAllNotesAsync();
            }
            catch (ValidationException vex)
            {
                StatusTextBlock.Text = "Validation Error: " + vex.Message;
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = "Unexpected Error: " + ex.Message;
            }
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e) // Button click event handler for deleting a note
        {
            try
            {
                // Check if a note is selected
                int idx = NotesListBox.SelectedIndex; // Get the index of the selected note
                var msg = await _controller.RemoveNoteAsync(idx); // Call the controller to remove the note at the selected index
                StatusTextBlock.Text = msg;
                await DisplayAllNotesAsync();
            }
            catch (ValidationException vex)
            {
                StatusTextBlock.Text = "Validation Error: " + vex.Message;
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = "Unexpected Error: " + ex.Message;
            }
        }

        private async Task DisplayAllNotesAsync() // Method to display all notes in the ListBox
        {
            // Controller now returns List<string> directly
            var notes = await _controller.GetAllNotesAsync();
            NotesListBox.ItemsSource = notes;
        }

        private async void DisplayAllNotesButton_Click(object sender, RoutedEventArgs e) // Button click event handler for displaying all notes
        {
            try
            {
                await DisplayAllNotesAsync();
                StatusTextBlock.Text = "Notes displayed successfully.";
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = $"Error displaying notes: {ex.Message}";
            }
        }
    }
}