namespace _0901_API_AI_app.Utilities
{
    // Provides simple validation methods for user inputs
    public static class InputValidator
    {
        // Checks that a string is neither null nor whitespace
        public static bool IsNonEmpty(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        // Validates that a duration (in seconds) is positive
        public static bool IsPositiveDuration(int seconds)
        {
            return seconds > 0;
        }
    }
}
