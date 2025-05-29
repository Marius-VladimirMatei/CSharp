using System;
using System.Collections.Generic;
using System.IO;

namespace _0601_emplManagerAsync
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


        // Async Method to load employees from the CSV file

        public static async Task<List<Employee>> LoadEmployeesAsync()
        {
            // Simulate a long I/O operation then move the window to test async
            await Task.Delay(5000);

            var list = new List<Employee>();
            var lines = await File.ReadAllLinesAsync(DataFile);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length == 2 && int.TryParse(parts[1], out int age))
                    list.Add(new Employee(parts[0], age));
            }
            return list;
        }


        // Async Saves the full list of employees, overwriting the file.

        public static async Task SaveEmployeesAsync(List<Employee> employees)
        {
            using var w = new StreamWriter(DataFile, false);
            await w.WriteLineAsync("Name,Age");
            foreach (var e in employees)
                await w.WriteLineAsync($"{e.Name},{e.Age}");
        }
    }
}