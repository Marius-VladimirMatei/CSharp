
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using _0901_API_AI_app.Models;

namespace _0901_API_AI_app.Services
{
    // Creates a service for interacting with OpenAI's chat completion API:
    // - creates a HTTP client to send requests to the OpenAI API
    // - handles chat completions by sending user messages and receiving AI responses
    // - recieves the AI's reply in a structured format
    // - parses the JSON response to extract the AI's reply
    public class OpenAiService : IOpenAiService
    {
        private readonly HttpClient _httpClient;  // HttpClient for making requests to OpenAI API
        private readonly OpenAiSettings _settings;  // Settings for OpenAI API, including API key and model

        public OpenAiService(OpenAiSettings settings)
        {
            _settings = settings; // Initialize settings for OpenAI API
            _httpClient = new HttpClient { BaseAddress = new Uri("https://api.openai.com/v1/") }; // Set base address for API requests
            // Set authorization header with API key. "Bearer" is the authentication scheme used by OpenAI API - who has the API key is authorized to access the API resources.
            // No need for user and password, just the API key is sufficient for authentication.
            _httpClient.DefaultRequestHeaders.Authorization = 
                new AuthenticationHeaderValue("Bearer", _settings.ApiKey); 
        }

        // Sends a chat completion request to OpenAI API with the user's text
        public async Task<string> ChatCompletionAsync(string userText) 
        {
            var messages = new[] // Create a message array with the user's input
            {
                new { role = "user", content = userText }
            };



        // Create the payload (Data sent to OpenAI) for the chat completion request.
        // The payload includes the model to use, the messages (user input), and the temperature setting.
        var payload = new
            {
                model = _settings.ChatModel,
                messages = messages,
                // Note: The temperature value can be adjusted based on the desired creativity of the response.
                temperature = 0.7
            };
           


        // Create the payload object to send in the request
        var jsonPayload = JsonConvert.SerializeObject(payload); 
            var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");


            // Set the content type to application/json
           
            HttpResponseMessage response;  // Variable to hold the HTTP response from OpenAI API
            try
            {
                response = await _httpClient.PostAsync("chat/completions", httpContent);
            }
            catch (HttpRequestException e)
            {
                throw new Exception("Chat completion request failed: " + e.Message);
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
                throw new Exception("Chat completion endpoint not found (404). Verify BaseAddress and model name.");

            if (response.StatusCode == HttpStatusCode.TooManyRequests)
                throw new RateLimitExceedException("ChatGPT rate limit exceeded. Please wait and try again.");

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            try
            {
                var result = JsonConvert.DeserializeObject<ChatResponse>(json);
                return result.choices[0].message.content?.Trim();
            }
            catch (Exception ex)
            {
                throw new Exception("Error parsing chat completion response: " + ex.Message + "\nRaw JSON:\n" + json);
            }
        }
    }
}
