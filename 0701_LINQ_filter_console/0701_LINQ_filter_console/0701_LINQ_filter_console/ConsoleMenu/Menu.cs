using System;
using System.Collections.Generic;
using _0701_LINQ_filter_console.Helpers;
using _0701_LINQ_filter_console.Models;
using _0701_LINQ_filter_console.ConsoleMenu;

namespace _0701_LINQ_filter_console.ConsoleMenu
{
    public static class Menu
    {
        public static void Show(List<Customer> customers)
        {
            int choice;
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Filter Console App");
                Console.WriteLine("----------------------");
                Console.WriteLine("1) Filter customers by city");
                Console.WriteLine("2) Filter customers younger than 30");
                Console.WriteLine("3) Filter customers with order value over 100 Euro");
                Console.WriteLine("4) Filter customers by product category");
                Console.WriteLine("5) Filter customers who ordered after the date");
                Console.WriteLine("6) Sort customers by name (A-Z)");
                Console.WriteLine("7) Group customers by city");
                Console.WriteLine("8) Show the three oldest customers");
                Console.WriteLine("----------------------");
                Console.WriteLine("9) Exit");
                Console.Write("Enter choice (1-9): ");

                if (!InputValidator.ValidateMenuChoice(Console.ReadLine(), 1, 9, out choice))
                {
                    Console.WriteLine("Invalid choice. Try again.");
                    continue;
                }

                if (choice == 9)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }

                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        MenuActions.ExecuteFilterByCity(customers);
                        break;
                    case 2:
                        MenuActions.ExecuteYoungerThan30(customers);
                        break;
                    case 3:
                        MenuActions.ExecuteOrderValueOver100(customers);
                        break;
                    case 4:
                        MenuActions.ExecuteByCategory(customers);
                        break;
                    case 5:
                        MenuActions.ExecuteOrderedAfter(customers);
                        break;
                    case 6:
                        MenuActions.ExecuteSortByName(customers);
                        break;
                    case 7:
                        MenuActions.ExecuteGroupByCity(customers);
                        break;
                    case 8:
                        MenuActions.ExecuteThreeOldest(customers);
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Press any key to return to menu:");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}