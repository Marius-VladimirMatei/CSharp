

namespace _0601_emplManagerAsync
{

    // Thrown when any validation fails.
    // Extends Exception to provide specific validation error messages
    public class ValidationException : Exception 
    {
        public ValidationException(string message)
            : base(message) // Pass message to base Exception class
        {
        }
    }
}