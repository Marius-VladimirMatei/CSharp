// File: Filters/CustomerFilters.cs
// Implements all required LINQ filters in both query syntax and method syntax (method syntax uses named local functions and method group syntax).
using System;
using System.Collections.Generic;
using System.Linq;
using _0701_LINQ_filter_console.Models;

namespace _0701_LINQ_filter_console.Filters
{
    public static class CustomerFilters
    {
        // Filter 1: All customers from a specific city.
        public static IEnumerable<Customer> FilterByCity_Query(IEnumerable<Customer> customers, string city)
        {
            var result =
                from c in customers
                where c.City.Equals(city, StringComparison.OrdinalIgnoreCase)
                select c;
            return result;
        }

        public static IEnumerable<Customer> FilterByCity_Method(IEnumerable<Customer> customers, string city)
        {
            // method syntax without lambda or delegate
            bool Match(Customer c)
            {
                return c.City.Equals(city, StringComparison.OrdinalIgnoreCase);
            }
            return customers.Where(Match);
        }

        // Filter 2: Customers who are younger than 30 years old.
        public static IEnumerable<Customer> FilterYoungerThan30_Query(IEnumerable<Customer> customers)
        {
            var result =
                from c in customers
                where c.Age < 30
                select c;
            return result;
        }

        public static IEnumerable<Customer> FilterYoungerThan30_Method(IEnumerable<Customer> customers)
        {
            bool IsYoungerThan30(Customer c)
            {
                return c.Age < 30;
            }
            return customers.Where(IsYoungerThan30);
        }

        // Filter 3: Customers whose order value is over 100 Euros.
        public static IEnumerable<Customer> FilterOrderValueOver100_Query(IEnumerable<Customer> customers)
        {
            var result =
                from c in customers
                where c.OrderValue > 100m
                select c;
            return result;
        }

        public static IEnumerable<Customer> FilterOrderValueOver100_Method(IEnumerable<Customer> customers)
        {
            bool IsOrderValueOver100(Customer c)
            {
                return c.OrderValue > 100m;
            }
            return customers.Where(IsOrderValueOver100);
        }

        // Filter 4: Customers who purchased a given product category.
        public static IEnumerable<Customer> FilterByProductCategory_Query(IEnumerable<Customer> customers, string category)
        {
            var result =
                from c in customers
                where c.ProductCategory.Equals(category, StringComparison.OrdinalIgnoreCase)
                select c;
            return result;
        }

        public static IEnumerable<Customer> FilterByProductCategory_Method(IEnumerable<Customer> customers, string category)
        {
            bool MatchesCategory(Customer c)
            {
                return c.ProductCategory.Equals(category, StringComparison.OrdinalIgnoreCase);
            }
            return customers.Where(MatchesCategory);
        }

        // Filter 5: Customers who ordered after a specific date.
        public static IEnumerable<Customer> FilterOrderedAfter_Query(IEnumerable<Customer> customers, DateTime date)
        {
            var result =
                from c in customers
                where c.OrderDate > date
                select c;
            return result;
        }

        public static IEnumerable<Customer> FilterOrderedAfter_Method(IEnumerable<Customer> customers, DateTime date)
        {
            bool OrderedAfterDate(Customer c)
            {
                return c.OrderDate > date;
            }
            return customers.Where(OrderedAfterDate);
        }

        // Filter 6: All customers, sorted by name. (A-Z).
        public static IEnumerable<Customer> SortByName_Query(IEnumerable<Customer> customers)
        {
            var result =
                from c in customers
                orderby c.Name ascending
                select c;
            return result;
        }

        public static IEnumerable<Customer> SortByName_Method(IEnumerable<Customer> customers)
        {
            string SelectName(Customer c)
            {
                return c.Name;
            }
            return customers.OrderBy(SelectName);
        }

        // Filter 7: Group customers by city.
        public static IEnumerable<IGrouping<string, Customer>> GroupByCity_Query(IEnumerable<Customer> customers)
        {
            var result =
                from c in customers
                group c by c.City into cityGroup
                select cityGroup;
            return result;
        }

        public static IEnumerable<IGrouping<string, Customer>> GroupByCity_Method(IEnumerable<Customer> customers)
        {
            string KeyByCity(Customer c)
            {
                return c.City;
            }
            return customers.GroupBy(KeyByCity);
        }

        // Filter 8: The three oldest customers.
        public static IEnumerable<Customer> ThreeOldestCustomers_Query(IEnumerable<Customer> customers)
        {
            var result =
                (from c in customers
                 orderby c.Age descending
                 select c)
                .Take(3);
            return result;
        }

        public static IEnumerable<Customer> ThreeOldestCustomers_Method(IEnumerable<Customer> customers)
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
