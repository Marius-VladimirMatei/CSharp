using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0203_personalData
{

    // Class designed to manage the save and load of Person objects
    public static class DataStorage
    {
        private const string DataFile = "people.txt";


        // Writes the current list of Person instances to the data file in CSV format.

        public static void SaveData(List<Person> people)
        {
            using (var writer = new StreamWriter(DataFile, false))
            {
                foreach (var p in people)
                {
                    // Format: firstName,lastName,age,phone
                    writer.WriteLine($"{p.FirstName},{p.LastName},{p.Age},{p.TelephoneNumber}");
                }
            }
        }


        // Reads stored lines from the data file and converts them to Person instances.
        public static List<Person> LoadData()
        {
            var list = new List<Person>();
            if (!File.Exists(DataFile)) return list;

            var lines = File.ReadAllLines(DataFile);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 4 && int.TryParse(parts[2], out int age))
                {
                    // Create Person from CSV fields: firstName,lastName,age,phone
                    list.Add(new Person(parts[0], parts[1], age, parts[3]));
                }
            }
            return list;
        }
    }
}