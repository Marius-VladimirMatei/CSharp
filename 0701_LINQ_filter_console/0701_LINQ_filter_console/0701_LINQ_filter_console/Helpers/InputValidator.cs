using System;

namespace _0701_LINQ_filter_console.Helpers
{
    public static class InputValidator
    {
        // Validates that the menu choice is an integer within [min..max]
        public static bool ValidateMenuChoice(string input, int min, int max, out int choice)
        {
            if (int.TryParse(input, out choice) && choice >= min && choice <= max)
                return true;

            choice = -1; // reset choice if validation fails
            return false;
        }

        // Validates date input in a standard format
        public static bool ValidateDate(string input, out DateTime date)
        {
            return DateTime.TryParse(input, out date);
        }
    }
}
