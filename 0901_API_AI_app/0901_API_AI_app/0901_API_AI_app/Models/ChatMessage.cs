namespace _0901_API_AI_app.Models

{
    // Represents a message in the chat (user or assistant)

    // MainViewModel uses an ObservableCollection<ChatMessage> for chat history
    // Is used  for representing a chat message in your UI (the history)
    // and to store/display a chat history in your app.
    public class ChatMessage
    {
        // Who sent the message
        public Role Role { get; set; } = Role.Assistant; // default Role — safe!

        // The message content (matches XAML binding and OpenAI)
        public string Content { get; set; } = string.Empty;

        // Construct a new chat message
        public ChatMessage(Role role, string content)
        {
            Role = role;
            Content = content;
        }
    }
}
