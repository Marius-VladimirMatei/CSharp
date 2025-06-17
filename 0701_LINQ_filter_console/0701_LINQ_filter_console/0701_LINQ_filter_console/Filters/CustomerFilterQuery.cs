// File: Filters/CustomerFilters.cs
// Implements all required LINQ filters in both query syntax and method syntax (method syntax uses named local functions and method group syntax).
using System;
using System.Collections.Generic;
using System.Linq;
using _0701_LINQ_filter_console.Models;

namespace _0701_LINQ_filter_console.Filters
{
    public static class CustomerFilterQuery
    {
        // Filter 1: All customers from a specific city.

        // IEnumerable<Customer> creates a collection of customers from a specific city.
        public static IEnumerable<Customer> FilterByCity(IEnumerable<Customer> customers, string city)
        {
            var result =
                from c in customers // c is a Customer object in the customers collection
                where c.City.Equals(city, StringComparison.OrdinalIgnoreCase)
                select c;
            return result;
        }



        // Filter 2: Customers who are younger than 30 years old.
        // IEnumerable<Customer> creates a collection of customers who are younger than 30 years old.
        public static IEnumerable<Customer> FilterYoungerThan30(IEnumerable<Customer> customers)
        {
            var result =
                from c in customers // c is a Customer object in the customers collection
                where c.Age < 30
                select c;
            return result;
        }



        // Filter 3: Customers whose order value is over 100 Euros.
        public static IEnumerable<Customer> FilterOrderValueOver100(IEnumerable<Customer> customers)
        {
            var result =
                from c in customers
                where c.OrderValue > 100m
                select c;
            return result;
        }



        // Filter 4: Customers who purchased a given product category.
        public static IEnumerable<Customer> FilterByProductCategory(IEnumerable<Customer> customers, string category)
        {
            var result =
                from c in customers
                where c.ProductCategory.Equals(category, StringComparison.OrdinalIgnoreCase)
                select c;
            return result;
        }



        // Filter 5: Customers who ordered after a specific date.
        public static IEnumerable<Customer> FilterOrderedAfter(IEnumerable<Customer> customers, DateTime date)
        {
            var result =
                from c in customers
                where c.OrderDate > date
                select c;
            return result;
        }


        // Filter 6: All customers, sorted by name. (A-Z).
        public static IEnumerable<Customer> SortByName(IEnumerable<Customer> customers)
        {
            var result =
                from c in customers
                orderby c.Name ascending
                select c;
            return result;
        }



        // Filter 7: Group customers by city.
        public static IEnumerable<IGrouping<string, Customer>> GroupByCity(IEnumerable<Customer> customers)
        {
            var result =
                from c in customers
                group c by c.City into cityGroup
                select cityGroup;
            return result;
        }

 

        // Filter 8: The three oldest customers.
        public static IEnumerable<Customer> ThreeOldestCustomers(IEnumerable<Customer> customers)
        {
            var result =
                (from c in customers
                 orderby c.Age descending
                 select c)
                .Take(3);
            return result;
        }


    }
}
