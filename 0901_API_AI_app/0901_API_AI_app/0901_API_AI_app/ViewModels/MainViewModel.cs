
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using _0901_API_AI_app.Controllers;
using _0901_API_AI_app.Models;
using _0901_API_AI_app.Services;   // for RateLimitExceededException
using _0901_API_AI_app.Utilities;

namespace _0901_API_AI_app.ViewModels
{
    // Exposes chat history and commands for the WPF view, with specific rate-limit handling
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly MainController _controller;
        private string _inputText;
        private bool _isBusy = false;   // flag to prevent multiple simultaneous sends of the same text

        // Collection of chat messages to be displayed in the UI
        public ObservableCollection<ChatMessage> ChatHistory { get; }

        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
                OnPropertyChanged(nameof(InputText));
                (SendTextCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        public ICommand SendTextCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel(MainController controller)
        {
            _controller = controller;
            ChatHistory = new ObservableCollection<ChatMessage>();
            ChatHistory.Add(new ChatMessage(Role.Assistant, "Welcome! I am your OpenAI Chat Assistant. How can I help you today?"));

            SendTextCommand = new RelayCommand(OnSendText, CanSendText);
        }

        private void OnSendText(object parameter)
        {
            _ = ExecuteSendTextAsync();
        }

        // Determines if the SendTextCommand can be executed
        private bool CanSendText(object parameter)
        {
            return InputValidator.IsNonEmpty(InputText) && !_isBusy;
        }



        // Asynchronously sends the input text to the controller and updates the chat history
        private async Task ExecuteSendTextAsync()
        {
            if (_isBusy)
                return;

            _isBusy = true;
            (SendTextCommand as RelayCommand)?.RaiseCanExecuteChanged();

            try
            {
                var history = await _controller.SendTextAsync(InputText);
                UpdateChatHistory(history); // update the chat history with the new messages
                InputText = string.Empty; // clear the input text after sending
            }
            catch (RateLimitExceedException ex)
            {
                MessageBox.Show(ex.Message,
                                "Rate Limit Reached",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred sending text:\n" + ex.Message,
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            finally
            {
                _isBusy = false;
                (SendTextCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        private void UpdateChatHistory(System.Collections.Generic.List<ChatMessage> history) // update the chat history with new messages
        {
            ChatHistory.Clear(); // clear the existing history before adding new messages
            foreach (var msg in history)
                ChatHistory.Add(msg); // add each message to the ObservableCollection
        }

        private void OnPropertyChanged(string propertyName) // notify the UI of property changes
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
