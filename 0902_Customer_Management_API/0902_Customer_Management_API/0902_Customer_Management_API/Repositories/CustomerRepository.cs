

using MySql.Data.MySqlClient;
using _0902_Customer_Management_API.Data;
using _0902_Customer_Management_API.Models;


/// <summary>
/// CustomerRepository implementation for CRUD operations (Create, Read, Update, Delete).
/// Acts as a data-access layer for all Customer objects.
/// Uses ADO.NET framework with MySQL to perform operations on the Customers table.
/// ADO.NET provides connection objects, commands, and data readers for database interaction.
/// </summary>

namespace _0902_Customer_Management_API.Repositories
{
    
   
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        // Constructor that takes an IDbConnectionFactory to create database connections
        public CustomerRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory; // Variable to hold the database connection factory
        }

        // Retrieve all customers
        // IEnumerable<Customer> used to return the collection of customer objects needed to be displayed in the API response
        // GetAll method needs to handle both required (non-nullable) abd optional (nullable) fields in the Customer model
        public IEnumerable<Customer> GetAll() 
        {
            var customers = new List<Customer>(); // Initialize a list to hold customer records
            using var conn = _connectionFactory.CreateConnection();
            conn.Open(); // Open the database connection

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, FirstName, LastName, Street, HouseNumber, ZipCode, City, Email FROM Customers";

            using var reader = cmd.ExecuteReader(); // Execute the command and get a data reader
            while (reader.Read())
            {
                customers.Add(new Customer
                {
                    // Read each field from the data reader and map it to the Customer model
                    // Read the “Id” column as a 32-bit integer.
                    // reader.GetOrdinal("Id") looks up the zero-based column index for “Id”,
                    // then GetInt32 pulls the int value at that index.
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),

                    // Read the “FirstName” column as a non-null string.
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),

                    // “Street” is nullable => check reader.IsDBNull before reading.
                    // If the DB value is NULL => null vallue is assigned, otherwise  GetString().
                    Street = reader.IsDBNull(reader.GetOrdinal("Street")) ? null : reader.GetString(reader.GetOrdinal("Street")),
                    HouseNumber = reader.IsDBNull(reader.GetOrdinal("HouseNumber")) ? null : reader.GetString(reader.GetOrdinal("HouseNumber")),
                    ZipCode = reader.IsDBNull(reader.GetOrdinal("ZipCode")) ? null : reader.GetString(reader.GetOrdinal("ZipCode")),
                    City = reader.IsDBNull(reader.GetOrdinal("City")) ? null : reader.GetString(reader.GetOrdinal("City")),
                    Email = reader.GetString(reader.GetOrdinal("Email"))
                });
            }

            return customers; // Return the list of customers
        }

        // Retrieve one customer by ID
        public Customer GetById(int id)
        {
            Customer customer = null; // Initialize customer object to null
            using var conn = _connectionFactory.CreateConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, FirstName, LastName, Street, HouseNumber, ZipCode, City, Email FROM Customers WHERE Id = @Id";
            // Create a parameter for the ID by linking the ID placeholder in the SQL query to the actual ID value
            var param = cmd.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = id;
            cmd.Parameters.Add(param); // Add the parameter to the command

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                customer = new Customer
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")), 
                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                    Street = reader.IsDBNull(reader.GetOrdinal("Street")) ? null : reader.GetString(reader.GetOrdinal("Street")),
                    HouseNumber = reader.IsDBNull(reader.GetOrdinal("HouseNumber")) ? null : reader.GetString(reader.GetOrdinal("HouseNumber")),
                    ZipCode = reader.IsDBNull(reader.GetOrdinal("ZipCode")) ? null : reader.GetString(reader.GetOrdinal("ZipCode")),
                    City = reader.IsDBNull(reader.GetOrdinal("City")) ? null : reader.GetString(reader.GetOrdinal("City")),
                    Email = reader.GetString(reader.GetOrdinal("Email"))
                };
            }

            return customer;
        }

        // Insert a new customer
        public void Create(Customer customer)
        {
            // Create a new connection to the database using the factory
            using var conn = _connectionFactory.CreateConnection();
            conn.Open();

            // Build the SQL command to insert a new customer record
            using var cmd = conn.CreateCommand();
            cmd.CommandText =
                "INSERT INTO Customers (FirstName, LastName, Street, HouseNumber, ZipCode, City, Email) " +
                "VALUES (@FirstName, @LastName, @Street, @HouseNumber, @ZipCode, @City, @Email)";

            // Add parameters to the command
            cmd.Parameters.Add(new MySqlParameter("@FirstName", customer.FirstName));
            cmd.Parameters.Add(new MySqlParameter("@LastName", customer.LastName));
            cmd.Parameters.Add(new MySqlParameter("@Street", (object)customer.Street));
            cmd.Parameters.Add(new MySqlParameter("@HouseNumber", (object)customer.HouseNumber));
            cmd.Parameters.Add(new MySqlParameter("@ZipCode", (object)customer.ZipCode));
            cmd.Parameters.Add(new MySqlParameter("@City", (object)customer.City));
            cmd.Parameters.Add(new MySqlParameter("@Email", customer.Email));

            
            var mySqlCmd = (MySqlCommand)cmd; // cast the databse command to MySqlCommand class to access MySQL-specific features - LastInsertedId
            mySqlCmd.ExecuteNonQuery(); // Execute the command to insert the new customer
            customer.Id = (int)mySqlCmd.LastInsertedId; // Retrieve the auto-generated ID - LastInsertedId holds the newly assigned numeric primary key
        }



        // Update an existing customer
        public void Update(Customer customer)
        {
            using var conn = _connectionFactory.CreateConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText =
                "UPDATE Customers SET FirstName=@FirstName, LastName=@LastName, Street=@Street, " +
                "HouseNumber=@HouseNumber, ZipCode=@ZipCode, City=@City, Email=@Email WHERE Id=@Id";

            cmd.Parameters.Add(new MySqlParameter("@FirstName", customer.FirstName));
            cmd.Parameters.Add(new MySqlParameter("@LastName", customer.LastName));
            cmd.Parameters.Add(new MySqlParameter("@Street", (object)customer.Street ?? DBNull.Value));
            cmd.Parameters.Add(new MySqlParameter("@HouseNumber", (object)customer.HouseNumber ?? DBNull.Value));
            cmd.Parameters.Add(new MySqlParameter("@ZipCode", (object)customer.ZipCode ?? DBNull.Value));
            cmd.Parameters.Add(new MySqlParameter("@City", (object)customer.City ?? DBNull.Value));
            cmd.Parameters.Add(new MySqlParameter("@Email", customer.Email));
            cmd.Parameters.Add(new MySqlParameter("@Id", customer.Id));

            cmd.ExecuteNonQuery();
        }

        // Delete a customer by ID
        public void Delete(int id)
        {
            using var conn = _connectionFactory.CreateConnection();
            conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Customers WHERE Id=@Id";
            cmd.Parameters.Add(new MySqlParameter("@Id", id));

            cmd.ExecuteNonQuery();
        }
    }
}
