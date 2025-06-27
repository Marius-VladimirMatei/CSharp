


using System.Data;


///<summary>
/// Interface for creating database connections
/// </summary>

namespace _0902_Customer_Management_API.Data
{
    // Defines a factory for creating ADO.NET database connections
    public interface IDbConnectionFactory
    {
        // Creates and returns a new, closed IDbConnection instance
        IDbConnection CreateConnection();
    }
}
