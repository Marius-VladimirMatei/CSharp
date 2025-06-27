
/// summary> 
/// Maps the "Customers" table from the MySQL database - Ensure properties exactly match column names and types
/// CRUD operations will use this model in API endpoints
/// </summary>



namespace _0902_Customer_Management_API.Models
{
    // Customer record, mapped directly to the Customers table.
    public class Customer
    {
        // Primary key, auto-incremented in DB
        public int Id { get; set; }

        // Customer's first name (required)
        public string FirstName { get; set; }

        // Customer's last name (required)
        public string LastName { get; set; }

        // Customer's street address (optional)
        public string Street { get; set; }

        // House number as string (optional)
        public string HouseNumber { get; set; }

        // ZIP/postal code (optional)
        public string ZipCode { get; set; }

        // City name (optional)
        public string City { get; set; }

        // Customer's email address (required, validated)
        public string Email { get; set; }
    }
}
