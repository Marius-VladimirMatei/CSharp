using System.Text.RegularExpressions;



namespace _0601_emplManagerAsync
{
    // Validates both Name and Age input fields.
    public class InputValidator
    {
        public void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Name cannot be empty.");

            // Allow letters, spaces and German umlauts/ß
            if (!Regex.IsMatch(name, "^[ a-zA-ZäÄöÖüÜß]+$"))
                throw new ValidationException("Name should contain only letters.");
        }

        // Validates and parses the age input, throwing ValidationException on errors
        public int ValidateAge(string ageInput)
        {
            if (string.IsNullOrWhiteSpace(ageInput))
                throw new ValidationException("Age cannot be empty.");

            // Ensure only digits
            if (!Regex.IsMatch(ageInput, @"^\d+$"))
                throw new ValidationException("Age must be a valid number.");

            // Parse to integer
            int age = int.Parse(ageInput);

            // Range check
            if (age < 0 || age > 120)
                throw new ValidationException("Age must be between 0 and 120.");

            return age;
        }
    }
}