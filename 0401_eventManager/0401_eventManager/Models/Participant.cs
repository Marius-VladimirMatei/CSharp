

namespace _0401_eventManager.Models
{
    public class Participant
    {
        // Read-only properties not to be modified after creation
        public string Name { get; set; } 
        public string Email { get; set; }

        public Participant(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
