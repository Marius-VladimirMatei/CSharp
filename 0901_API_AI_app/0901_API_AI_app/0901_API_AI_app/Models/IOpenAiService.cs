
// Interface for OpenAI service to handle chat completions
namespace _0901_API_AI_app.Services
{
    public interface IOpenAiService
    {
        Task<string> ChatCompletionAsync(string userText);
    }
}