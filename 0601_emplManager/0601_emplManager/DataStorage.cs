using System;
using System.Collections.Generic;
using System.IO;

namespace _0601_emplManager
{
    public static class DataStorage
    {
        private const string DataFile = "employees.csv";

        static DataStorage()
        {
            // Ensure file exists
            if (!File.Exists(DataFile))
                File.WriteAllText(DataFile, "Name,Age" + Environment.NewLine);
        }


        // Method to load employees from the CSV file

        public static List<Employee> LoadEmployees()
        {
            var list = new List<Employee>();  // List to hold employee records
            foreach (var line in File.ReadAllLines(DataFile))
            {
                var parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[1], out int age))
                    list.Add(new Employee(parts[0], age));
            }
            return list;
        }


        /// Saves the full list of employees, overwriting the file.

        public static void SaveEmployees(List<Employee> employees)
        {
            using (var w = new StreamWriter(DataFile, false))
            {
                w.WriteLine("Name,Age");
                foreach (var empl in employees)
                    w.WriteLine($"{empl.Name},{empl.Age}");
            }
        }
    }
}