using _0602_noteManager.Models;
using System.ComponentModel.DataAnnotations;
using _0602_noteManager.Storage;
using _0602_noteManager.Validation;

namespace _0602_noteManager.Controllers
{
    public class NoteController
    // Controller class designed to manage notes
    {
        private readonly FileNoteStorage _storage;
        private readonly InputValidator _validator = new();

        public NoteController(FileNoteStorage storage)
        {
            _storage = storage; // Storage controller instance to handle note data
        }

        // Method to add a new note
        public async Task<string> AddNoteAsync(string title, string content)
        {
            _validator.ValidateTitle(title);
            _validator.ValidateContent(content);

            var notes = await _storage.LoadNotesAsync();

            // Check if a note with the same title already exists
            if (notes.Any(n => n.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))
                throw new ValidationException($"A note titled '{title}' already exists.");

            notes.Add(new Note(title, content));
            await _storage.SaveNotesAsync(notes);

            return $"Note '{title}' added successfully.";
        }

        // Method to remove a note by its index
        public async Task<string> RemoveNoteAsync(int index)
        {
            try
            {
                var notes = await _storage.LoadNotesAsync();

                // Check if the index is valid
                if (index < 0 || index >= notes.Count)
                    throw new ValidationException("Please select a valid note to delete.");

                // Remove the note at the specified index
                var removed = notes[index];
                notes.RemoveAt(index);
                await _storage.SaveNotesAsync(notes); // Save the updated list of notes

                return $"Note '{removed.Title}' deleted.";
            }

            catch (Exception ex)
            {
                // Handle other exceptions such as file access issues, deserialization errors, etc.
                return $"Error removing note: {ex.Message}";
            }

        }


        // Method to retrieve all notes as a formatted string
        public async Task<List<string>> GetAllNotesAsync()
        {
            try
            {
                var notes = await _storage.LoadNotesAsync();
                if (!notes.Any())
                    return new List<string> { "No notes found." };

                // Return one formatted string per note
                return notes
                    .Select((note, index) =>
                        $"{index + 1}: {note.Title} (Created: {note.CreatedAt:G}){Environment.NewLine}{note.Content}" // G format for general date/time pattern
                    )
                    .ToList();
            }
            catch (Exception ex)
            {
                // Surface error as a single-item list
                return new List<string> { $"Error retrieving notes: {ex.Message}" };
            }
        }
    }
}