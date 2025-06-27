

using _0902_Customer_Management_API.Models;

namespace _0902_Customer_Management_API.Repositories
{
    /// <summary>
    /// ICustomerRepository defines the contract for Customer data access operations.
    /// Abstraction for Customer data access
    /// Convention - is purely a naming convention that signals this class’s responsibility:
    /// it’s the place where you “save, load, update, and delete” Customer objects.
    /// </summary>

    public interface ICustomerRepository
    {
        // Retrieve all customer records
        IEnumerable<Customer> GetAll();

        // Retrieve a single customer by its primary key
        Customer GetById(int id);

        // Insert a new customer record
        void Create(Customer customer);

        // Update an existing customer record
        void Update(Customer customer);

        // Delete a customer record by its primary key
        void Delete(int id);
    }
}
