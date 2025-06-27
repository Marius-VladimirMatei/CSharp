


using System.Data;
using MySql.Data.MySqlClient;



///<summary>
///  Setup ADO.NET connection to MySQL using connection string from configuration
///  Implements IDbConnectionFactory and reads “customerdb” from appsettings.json
/// </summary>
/// 
namespace _0902_Customer_Management_API.Data
{
    // Concrete factory for MySQL connections
    public class MySqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString; 

        // Constructor that takes IConfiguration to read connection string
        public MySqlConnectionFactory(IConfiguration configuration) 
        {
            _connectionString = configuration.GetConnectionString("customerdb");
        }

        // Creates a closed MySqlConnection - repository will open/close as needed
        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
