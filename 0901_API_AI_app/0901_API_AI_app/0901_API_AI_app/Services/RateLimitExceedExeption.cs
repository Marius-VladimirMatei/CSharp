using System;

namespace _0901_API_AI_app.Services
{
    // Thrown when the OpenAI API returns a 429 rate-limit error
    // This exception indicates that the user has exceeded their allowed number of requests within a given time frame.
    // Used when there were no tokens available to process the request due to rate limiting (need to pay for tokens for specific model).
    public class RateLimitExceedException : Exception
    {

        public RateLimitExceedException(string message)
            : base(message)
        {
        }
    }
}