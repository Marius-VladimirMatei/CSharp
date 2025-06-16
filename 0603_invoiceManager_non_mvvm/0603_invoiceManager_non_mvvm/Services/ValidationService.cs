using System.Text.RegularExpressions;
using _0603_invoiceManager_non_mvvm.Services;

namespace _0603_invoiceManager_non_mvvm.Services
{
    // Concrete implementation of IValidationService
    // Provides input validation logic for the application
    public class ValidationService : IValidationService
    {
        // Checks username/password against fixed credentials
        public bool ValidateLogin(string username, string password)
        {
            return username == "admin12321" && password == "password65456";
        }

        // Ensures a string is not null, empty, or whitespace
        public bool ValidateRequiredString(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        // Validates "KU-" prefix plus one or more digits
        public bool ValidateCustomerNumber(string customerNo)
        {
            if (string.IsNullOrWhiteSpace(customerNo)) return false;
            return Regex.IsMatch(customerNo, "^KU-\\d+$");
        }

        // Quantity must be a positive integer
        public bool ValidatePositiveQuantity(int quantity)
        {
            return quantity > 0;
        }

        // Price must be non-negative
        public bool ValidatePrice(decimal price)
        {
            return price >= 0m;
        }
    }
}
