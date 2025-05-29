using System.IO;
using System.Text.Json;
using _0602_noteManager.Models;


namespace _0602_noteManager.Storage
{
    public class FileNoteStorage
    // Class designed to handle note storage in a json file
    {

        private const string DataFile = "notes.json"; // File to store notes in JSON format

        public FileNoteStorage()
        {
            if (!File.Exists(DataFile))
                File.WriteAllText(DataFile, "[]"); // Initialize with an empty JSON array
        }

        public async Task<List<Note>> LoadNotesAsync()
        {
            try
            {
                var jsonFile = await File.ReadAllTextAsync(DataFile); // variable to hold the content of the file
                return JsonSerializer.Deserialize<List<Note>>(jsonFile) // deserialize the JSON content into a list of Note objects
                       ?? new List<Note>(); // Return an empty list if deserialization fails
            }

            catch (Exception ex)
            {
                // Handle exceptions such as file access issues, deserialization errors, etc.
                Console.WriteLine($"Error loading notes: {ex.Message}");
                return new List<Note>(); // Return an empty list in case of error
            }

        }


        public async Task SaveNotesAsync(List<Note> notes)
        {
            try
            {
                var jsonFile = JsonSerializer.Serialize(notes, new JsonSerializerOptions { WriteIndented = true }); // Serialize the list of notes to JSON format with indentation for readability
                await File.WriteAllTextAsync(DataFile, jsonFile); // Write the serialized JSON to the file
            }
            catch (Exception ex)
            {
                // Handle exceptions such as file access issues, serialization errors, etc.
                Console.WriteLine($"Error saving notes: {ex.Message}");
                throw; // Re-throw the exception to be handled by the caller if necessary

            }
        }
    }
}