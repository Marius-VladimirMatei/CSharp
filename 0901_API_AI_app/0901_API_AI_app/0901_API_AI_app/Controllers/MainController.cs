
using _0901_API_AI_app.Models;
using _0901_API_AI_app.Services;
using _0901_API_AI_app.Utilities;

namespace _0901_API_AI_app.Controllers
{
    // MainController handles the interaction with OpenAI's chat completion service.
    // It manages the chat history and sends user input to the AI service.
    public class MainController
    {
        private readonly IOpenAiService _aiService;

        private readonly List<ChatMessage> _history;

        public MainController(IOpenAiService aiService)
        {
            _aiService = aiService; // Initialize the AI service for chat completions

            _history = new List<ChatMessage>(); // Initialize the chat history
        }


        /// Sends a text message to the AI service and updates the chat history.
        /// // List<ChatMessage> is used to store the chat history
        public async Task<List<ChatMessage>> SendTextAsync(string text) 
        {
            if (!InputValidator.IsNonEmpty(text))
                throw new ArgumentException("Input text cannot be empty.", nameof(text));

            // Add the user message to the chat history
            _history.Add(new ChatMessage(Role.User, text)); 

            // Only send the latest user message
            string assistantText = await _aiService.ChatCompletionAsync(text);

            // Add the AI's response to the chat history
            _history.Add(new ChatMessage(Role.Assistant, assistantText)); 

            // Return the updated chat history
            return _history; 
        }
    }
}
