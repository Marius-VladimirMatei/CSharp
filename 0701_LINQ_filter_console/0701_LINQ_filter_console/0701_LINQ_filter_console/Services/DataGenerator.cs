// File: Services/DataGenerator.cs
// Loads customer data from a hard-coded CSV path.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using _0701_LINQ_filter_console.Models;

namespace _0701_LINQ_filter_console.Services
{
    public static class DataGenerator
    {
        // Hard-coded path to the CSV file (relative to the executable)
        private static readonly string CsvPath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Customers.csv");

        // Reads customers from the CSV file at CsvPath.
        public static List<Customer> GenerateCustomers()
        {
            // ensure file exists
            if (!File.Exists(CsvPath))
                throw new FileNotFoundException($"CSV file not found at '{CsvPath}'.");

            var customers = new List<Customer>();
            var lines = File.ReadAllLines(CsvPath);

            // skip header row and parse each subsequent line
            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i].Trim();
                if (string.IsNullOrEmpty(line))
                    continue;

                var parts = line.Split(',');

                // parse each column
                var name = parts[0];
                var age = int.Parse(parts[1]);
                var city = parts[2];
                var category = parts[3];
                var orderDate = DateTime.ParseExact(
                                     parts[4], "yyyy-MM-dd",
                                     CultureInfo.InvariantCulture);
                var orderValue = decimal.Parse(
                                     parts[5],
                                     NumberStyles.Number,
                                     CultureInfo.InvariantCulture);

                customers.Add(new Customer(
                    name, age, city, category, orderDate, orderValue));
            }

            return customers;
        }
    }
}
