
using System;
using System.Collections.Generic;
using System.Linq;
using _0701_LINQ_filter_console.Models;
using _0701_LINQ_filter_console.Filters;
using _0701_LINQ_filter_console.Helpers;

namespace _0701_LINQ_filter_console.ConsoleMenu
{
    internal static class MenuActions
    {
        // Prompt user to choose syntax at each filter execution
        private static bool AskUseMethodSynthax()
        {
            while (true)
            {
                Console.WriteLine("Choose filter syntax:");
                Console.WriteLine("----------------------");
                Console.WriteLine("1) Query syntax");
                Console.WriteLine("2) Method syntax");
                Console.WriteLine("----------------------");
                Console.Write("Enter choice (1-2): ");
                string input = Console.ReadLine();
                if (InputValidator.ValidateMenuChoice(input, 1, 2, out int syntaxChoice))
                {
                    return syntaxChoice == 2;
                }
                Console.WriteLine("Invalid choice. Please enter 1 or 2.\n");
            }
        }

        // 1 Execute the filter by city
        public static void ExecuteFilterByCity(List<Customer> customers)
        {
            bool useMethod = AskUseMethodSynthax();
            Console.Write("Enter city: ");
            string city = Console.ReadLine();
            IEnumerable<Customer> result;
            if (useMethod)
            {
                result = CustomerFilterMethod.FilterByCity(customers, city);
            }
            else
            {
                result = CustomerFilterQuery.FilterByCity(customers, city);
            }
            DisplayResults(result);
        }


        // 2 Execute the filter for customers younger than 30
        public static void ExecuteYoungerThan30(List<Customer> customers)
        {
            bool useMethod = AskUseMethodSynthax();
            IEnumerable<Customer> result;
            if (useMethod)
            {
                result = CustomerFilterMethod.FilterYoungerThan30(customers);
            }
            else
            {
                result = CustomerFilterQuery.FilterYoungerThan30(customers);
            }
            DisplayResults(result);
        }


        // 3 Execute the filter for customers with order value over 100
        public static void ExecuteOrderValueOver100(List<Customer> customers)
        {
            bool useMethod = AskUseMethodSynthax();
            IEnumerable<Customer> result;
            if (useMethod)
            {
                result = CustomerFilterMethod.FilterOrderValueOver100(customers);
            }
            else
            {
                result = CustomerFilterQuery.FilterOrderValueOver100(customers);
            }
            DisplayResults(result);
        }


        // 4 Execute the filter for customers by product category
        public static void ExecuteByCategory(List<Customer> customers)
        {
            bool useMethod = AskUseMethodSynthax();
            Console.Write("Enter product category: ");
            string category = Console.ReadLine();
            IEnumerable<Customer> result;
            if (useMethod)
            {
                result = CustomerFilterMethod.FilterByProductCategory(customers, category);
            }
            else
            {
                result = CustomerFilterQuery.FilterByProductCategory(customers, category);
            }
            DisplayResults(result);
        }


        // 5 Execute the filter for customers who ordered after a specific date
        public static void ExecuteOrderedAfter(List<Customer> customers)
        {
            bool useMethod = AskUseMethodSynthax();
            Console.Write("Enter date (yyyy-MM-dd): ");
            if (!InputValidator.ValidateDate(Console.ReadLine(), out DateTime date))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }
            IEnumerable<Customer> result;
            if (useMethod)
            {
                result = CustomerFilterMethod.FilterOrderedAfter(customers, date);
            }
            else
            {
                result = CustomerFilterQuery.FilterOrderedAfter(customers, date);
            }
            DisplayResults(result);
        }


        // 6 Execute the sort by name
      =
        public static void ExecuteSortByName(List<Customer> customers)
        {
            bool useMethod = AskUseMethodSynthax();
            IEnumerable<Customer> result;
            if (useMethod)
            {
                result = CustomerFilterMethod.SortByName(customers);
            }
            else
            {
                result = CustomerFilterQuery.SortByName(customers);
            }
            DisplayResults(result);
        }


        // 7 Execute the group by city
        // GroupBy - Linq method that groups elements that share a common key.
        public static void ExecuteGroupByCity(List<Customer> customers)
        {
            bool useMethod = AskUseMethodSynthax();
            IEnumerable<IGrouping<string, Customer>> groups;
            if (useMethod)
            {
                groups = CustomerFilterMethod.GroupByCity(customers);
            }
            else
            {
                groups = CustomerFilterQuery.GroupByCity(customers);
            }
            foreach (var group in groups)
            {
                Console.WriteLine($"City: {group.Key}"); 
                int index = 1;
                foreach (var c in group)
                {
                    Console.WriteLine($"{index++}. {c.Name}, Age: {c.Age}, City: {c.City}, Category: {c.ProductCategory}, Date: {c.OrderDate:yyyy-MM-dd}, Value: {c.OrderValue} Euro");
                }
            }
        }

        // 8 Execute the three oldest customers
        public static void ExecuteThreeOldest(List<Customer> customers)
        {
            bool useMethod = AskUseMethodSynthax();
            IEnumerable<Customer> result;
            if (useMethod)
            {
                result = CustomerFilterMethod.ThreeOldestCustomers(customers);
            }
            else
            {
                result = CustomerFilterQuery.ThreeOldestCustomers(customers);
            }
            DisplayResults(result);
        }

        private static void DisplayResults(IEnumerable<Customer> customers)
        {
            int index = 1;
            foreach (var c in customers)
            {
                Console.WriteLine($"{index++}. {c.Name}, Age: {c.Age}, City: {c.City}, Category: {c.ProductCategory}, Date: {c.OrderDate:yyyy-MM-dd}, Value: {c.OrderValue} Euro");
            }
        }
    }
}
