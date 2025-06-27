namespace _0901_API_AI_app.Models
{
    // Holds OpenAI API configuration values
    // This class is used to store settings for the OpenAI API, such as the API key and the model to use for chat completions.
    public class OpenAiSettings
    {
        // Your OpenAI API key
        public string ApiKey { get; set; }

        // Model to use for chat completions (e.g. "gpt-3.5-turbo")
        public string ChatModel { get; set; }

        // Parameterless constructor for appsettings.json binding
        public OpenAiSettings()
        {
            ChatModel = "gpt-3.5-turbo";
        }

        // Constructor for hardcoded use
        public OpenAiSettings(string apiKey)
        {
            ApiKey = apiKey;
            ChatModel = "gpt-3.5-turbo";
        }
    }
}
