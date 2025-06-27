

namespace _0801_Customer_Management_GUI_DB.Models
{
    public class Customer
    {
        public int Id { get; set; } // Unique identifier
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
}