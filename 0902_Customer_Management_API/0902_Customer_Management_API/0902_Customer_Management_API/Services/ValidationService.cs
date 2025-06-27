// Services/ValidationService.cs
// -----------------------------
// REQUIREMENT: Implement input validation for Customer fields
// Detailed Requirement: Check non-null, length limits, and email format

using System;
using System.Text.RegularExpressions;
using _0902_Customer_Management_API.Models;

namespace _0902_Customer_Management_API.Services
{
    // Concrete validation logic for Customer entities
    public class ValidationService : IValidationService
    {
        // Simple email regex (covers basic cases)
        private static readonly Regex EmailRegex =
            new("^[^@\\s]+@[^@\\s]+\\.[^@\\s]+$", RegexOptions.Compiled);

        public void ValidateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentException("Customer object cannot be null");

            if (string.IsNullOrWhiteSpace(customer.FirstName))
                throw new ArgumentException("FirstName is required");

            if (string.IsNullOrWhiteSpace(customer.LastName))
                throw new ArgumentException("LastName is required");

            if (string.IsNullOrWhiteSpace(customer.Email))
                throw new ArgumentException("Email is required");

            if (!EmailRegex.IsMatch(customer.Email))
                throw new ArgumentException("Email format is invalid");


        }
    }
}
