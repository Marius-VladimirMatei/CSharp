using System.Text.RegularExpressions;


namespace _0601_emplManager
{ 

    // Validates both Name and Age input fields.

    public class InputValidator
    {
       
        public void ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ValidationException("Name cannot be empty.");
            if (!Regex.IsMatch(name, "^[ a-zA-ZäÄöÖüÜß]+$"))
                throw new ValidationException("Name should contain only letters.");
        }


        public void ValidateAge(int age)
        {
            if (age < 0 || age > 120)
                throw new ValidationException("Age must be between 0 and 120.");
        }
    }
}