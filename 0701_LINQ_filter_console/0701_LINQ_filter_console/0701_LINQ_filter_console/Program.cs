// File: Program.cs
// Entry point: loads data from the hard-coded CSV path and launches the menu.
using System;
using System.Collections.Generic;
using System.IO;
using _0701_LINQ_filter_console.Models;
using _0701_LINQ_filter_console.Services;
using _0701_LINQ_filter_console.ConsoleMenu;

namespace _0701_LINQ_filter_console
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Customer> customers;

            try
            {
                // load all customers from the hard-coded CSV
                customers = DataGenerator.GenerateCustomers();
            }
            catch (Exception ex) when (ex is FileNotFoundException || ex is FormatException)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
                return;
            }

            // start the menu-driven UI
            Menu.Show(customers);
        }
    }
}
