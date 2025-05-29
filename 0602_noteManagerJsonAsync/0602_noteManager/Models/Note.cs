

namespace _0602_noteManager.Models
{
    // Class designed to represent a note with title, content, and creation date
    public class Note
    {
        // Public setters needed for JSON serialization
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }


        // Constructor to initialize a note with title and content
        // CreatedAt is not set by the user, it is automatically set to the current date and time
        public Note(string title, string content) // CreatedAt is missing here from the constructor because it is set automatically
        {
            Title = title;
            Content = content;
            CreatedAt = DateTime.Now;
        }
    }
}