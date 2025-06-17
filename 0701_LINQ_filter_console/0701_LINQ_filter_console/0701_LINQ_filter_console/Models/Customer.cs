using System;

namespace _0701_LINQ_filter_console.Models
{
    // Class to represent a customer with personal and order details for filtering operations.
    public class Customer
    {
        public string Name { get; set; }

       
        public int Age { get; set; }

       
        public string City { get; set; }

       
        public string ProductCategory { get; set; }

        
        public DateTime OrderDate { get; set; }

        
        public decimal OrderValue { get; set; }

        
        public Customer(string name, int age, string city, string productCategory, DateTime orderDate, decimal orderValue)
        {
            Name = name;
            Age = age;
            City = city;
            ProductCategory = productCategory;
            OrderDate = orderDate;
            OrderValue = orderValue;
        }
    }
}
