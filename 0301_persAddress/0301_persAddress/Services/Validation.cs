using System;
using System.Text.RegularExpressions;


namespace _0301_persAddress.Services
{
    // Pure validation logic: throws Exception with message if invalid
    public static class Validation
    {
        public static void ValidateName(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("Name cannot be empty.");
            if (!Regex.IsMatch(input, "^[a-zA-ZäÄöÖüÜß]+$"))
                throw new Exception("Name should contain only letters.");
        }

        public static void ValidateText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("Text cannot be empty.");
        }

        public static void ValidatePostalCode(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("Postal Code cannot be empty.");
            if (!Regex.IsMatch(input, "^\\d}{4$"))
                throw new Exception("Postal Code should be 4 digits.");
        }

        public static void ValidatePhone(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("Phone number cannot be empty.");
            if (!Regex.IsMatch(input, "^\\+43\\d{10}$"))
                throw new Exception("Phone number should contain the prefix +43 and 10 digits.");
        }
    }
}

