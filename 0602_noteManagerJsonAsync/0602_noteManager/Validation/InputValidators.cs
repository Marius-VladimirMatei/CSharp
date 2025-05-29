
using System.ComponentModel.DataAnnotations;


namespace _0602_noteManager.Validation
{
    public class InputValidator
    {
        public void ValidateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ValidationException("Title cannot be empty.");
            if (title.Length > 100)
                throw new ValidationException("Title cannot exceed 100 characters.");
        }

        public void ValidateContent(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ValidationException("Content cannot be empty.");
            if (content.Length > 1000)
                throw new ValidationException("Content cannot exceed 1000 characters.");
        }
    }
}