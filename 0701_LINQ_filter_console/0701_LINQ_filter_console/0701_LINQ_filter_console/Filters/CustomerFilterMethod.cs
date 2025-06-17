// File: Filters/CustomerFilters.cs
// Implements all required LINQ filters in both query syntax and method syntax (method syntax uses named local functions and method group syntax).
using System;
using System.Collections.Generic;
using System.Linq;
using _0701_LINQ_filter_console.Models;

namespace _0701_LINQ_filter_console.Filters
{
    public static class CustomerFilterMethod
    {

        // Filter 1: All customers from a specific city.

        // IEnumerable<Customer> creates a collection of customers from a specific city.
        public static IEnumerable<Customer> FilterByCity(IEnumerable<Customer> customers, string city)
        {
            // method syntax without lambda or delegate
            bool Match(Customer c) //  // Match checks if the customer's city matches the input city, ignoring case.

            { 
                return c.City.Equals(city, StringComparison.OrdinalIgnoreCase); //
            }
            return customers.Where(Match); // returns the collection of customers that match the city.
        }




        // Filter 2: Customers who are younger than 30 years old.

        public static IEnumerable<Customer> FilterYoungerThan30(IEnumerable<Customer> customers)
        {
            bool IsYoungerThan30(Customer c)
            {
                return c.Age < 30;
            }
            return customers.Where(IsYoungerThan30);
        }



        // Filter 3: Customers whose order value is over 100 Euros.

        public static IEnumerable<Customer> FilterOrderValueOver100(IEnumerable<Customer> customers)
        {
            bool IsOrderValueOver100(Customer c)
            {
                return c.OrderValue > 100m;
            }
            return customers.Where(IsOrderValueOver100);
        }




        // Filter 4: Customers who purchased a given product category.

        public static IEnumerable<Customer> FilterByProductCategory(IEnumerable<Customer> customers, string category)
        {
            bool MatchesCategory(Customer c)
            {
                return c.ProductCategory.Equals(category, StringComparison.OrdinalIgnoreCase);
            }
            return customers.Where(MatchesCategory);
        }




        // Filter 5: Customers who ordered after a specific date.

        public static IEnumerable<Customer> FilterOrderedAfter(IEnumerable<Customer> customers, DateTime date)
        {
            bool OrderedAfterDate(Customer c)
            {
                return c.OrderDate > date;
            }
            return customers.Where(OrderedAfterDate);
        }





        // Filter 6: All customers, sorted by name. (A-Z).

        // IEnumerable<Customer> creates a collection of customers sorted by name.
        public static IEnumerable<Customer> SortByName(IEnumerable<Customer> customers)
        {
            string SelectName(Customer c)
            {
                return c.Name;
            }
            return customers.OrderBy(SelectName);
        }



        // Filter 7: Group customers by city.
        // IGrouping<string, Customer> creates a group of customers with the same city name as the key.
        public static IEnumerable<IGrouping<string, Customer>> GroupByCity(IEnumerable<Customer> customers)
        {
            string KeyByCity(Customer c)  // KeyByCity creates the key for grouping.
            {
                return c.City;
            }
            return customers.GroupBy(KeyByCity); // returns the collection of groups.
        }



        // Filter 8: The three oldest customers.

        public static IEnumerable<Customer> ThreeOldestCustomers(IEnumerable<Customer> customers)
        {
            int SelectAge(Customer c)
            {
                return c.Age;
            }
            return customers
                .OrderByDescending(SelectAge)
                .Take(3);
        }
    }
}
