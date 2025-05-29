

namespace _0602_noteManager.Exeptions
{
    // Class designed to represent validation errors
    // Extends the base Exception class
    public class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message) // Call base constructor with the error message
        {
        }
    }
}