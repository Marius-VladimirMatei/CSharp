
using System;
using System.Globalization;

using System.Text.RegularExpressions;


namespace _0401_eventManager.Services
{
    public static class Validation
    {
        public static void ValidateText(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("Value cannot be empty.");
        }

        public static void ValidateEmail(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("Email cannot be empty.");
            var pattern = "^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$";
            if (!Regex.IsMatch(input, pattern))
                throw new Exception("Invalid email format.");
        }

        public static void ValidateDate(string input, out DateTime date)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("Date cannot be empty.");

            // dd-MM-yyyy  →  01–31, 01–12, four-digit year
            var pattern = @"^(0[1-9]|[12]\d|3[01])-(0[1-9]|1[0-2])-\d{4}$";
            if (!Regex.IsMatch(input, pattern))
                throw new Exception("Invalid date format. Please use dd-MM-yyyy.");

            // Now ensure it’s a real calendar date (rejects things like 31-02-2025)
            if (!DateTime.TryParseExact(
                    input,
                    "dd-MM-yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out date))
            {
                throw new Exception("Invalid calendar date.");
            }
        }
    }
}
