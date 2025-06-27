// Services/IValidationService.cs
// --------------------------------
// REQUIREMENT: Define validation rules for Customer input
// Detailed Requirement: Ensure all required fields are provided and formats are valid

using _0902_Customer_Management_API.Models;

namespace _0902_Customer_Management_API.Services
{
    // Abstraction for input validation logic
    public interface IValidationService
    {
        // Validates a Customer object, throws ArgumentException on validation failures
        void ValidateCustomer(Customer customer);
    }
}
