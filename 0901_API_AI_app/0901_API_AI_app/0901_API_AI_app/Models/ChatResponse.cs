namespace _0901_API_AI_app.Models
{
    // Models for correct deserialization of Chat Completions response

    // This class structure matches the expected JSON response from OpenAI's Chat Completions API.
    // It is needed to deserialize the JSON response  from OpenAI into C# objects.
    public class ChatResponse
    {
        public Choice[] choices { get; set; } // Represents the list of choices returned by the API
    }

    public class Choice
    {
        public Message message { get; set; }
    }

    public class Message
    {
        public string role { get; set; }
        public string content { get; set; }
    }
}
