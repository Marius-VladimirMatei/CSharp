using System;
using System.Text.RegularExpressions;

namespace _0603_invoiceManager_Sync_MVVM.Services
{
    // Service for validating input fields - input validation for all fields)

    public static class ValidationService
    {
        // Validates the login credentials against fixed values
        public static bool ValidateLogin(string username, string password)
        {
            // Fixed access data
            return username == "admin12321" && password == "password65456";
        }

        // Checks that a string is not null, empty or whitespace
        public static bool ValidateRequiredString(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        // Validates that customer number starts with "KU-" followed by 4 digits
        public static bool ValidateCustomerNumber(string customerNo)
        {
            if (string.IsNullOrWhiteSpace(customerNo))
                return false;

            // allow any positive‐length sequence of digits after "KU-"
            var pattern = "^KU-\\d+$";
            return Regex.IsMatch(customerNo, pattern);
        }
        

        // Validates that a number is positive
        // Quantity - positive integer
        public static bool ValidatePositiveQuantity(int quantity)
        {
            return quantity > 0;
        }

        // Validates that a decimal price is non-negative
        public static bool ValidatePrice(decimal price)
        {
            return price >= 0m;
        }
    }
}
