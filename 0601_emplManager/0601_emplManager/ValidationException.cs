

namespace _0601_emplManager
{

    // Thrown when any validation fails.

    public class ValidationException : Exception
    {
        public ValidationException(string message)
            : base(message)
        {
        }
    }
}