namespace _0603_invoiceManager_non_mvvm.Services
{
    // Abstraction for validating user input (SRP & DIP compliance)
    public interface IValidationService
    {
        // Checks username/password against fixed credentials
        bool ValidateLogin(string username, string password);

        // Ensures a string is not null, empty, or whitespace
        bool ValidateRequiredString(string input);

        // Validates "KU-" prefix plus digits only
        bool ValidateCustomerNumber(string customerNo);

        // Quantity must be a positive integer
        bool ValidatePositiveQuantity(int quantity);

        // Price must be non-negative
        bool ValidatePrice(decimal price);
    }
}
