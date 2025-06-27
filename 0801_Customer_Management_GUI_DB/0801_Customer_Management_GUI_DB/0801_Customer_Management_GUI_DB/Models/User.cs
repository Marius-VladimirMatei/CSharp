public enum UserRole
{
    admin,
    guest
}

namespace _0801_Customer_Management_GUI_DB.Models
{
    public class User
    {
        public string Username { get; }
        public string Password { get; }
        public UserRole Role { get; }

        public User(string username, string password, UserRole role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}