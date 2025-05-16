using System;


namespace _0301_persAddress
{
    // / Address class inherits from Person
    public class Address : Person
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }

        // Constructor
        public Address(
            string firstName, string lastName, string street, string city, string postalCode, string phoneNumber) : base(firstName, lastName)
        {
            Street = street;
            City = city;
            PostalCode = postalCode;
            PhoneNumber = phoneNumber;
        }

        // override the abstract method to show full info
        public override string DisplayInfo()
        {
            Console.WriteLine($"Name: {FirstName} {LastName}");
            Console.WriteLine($"Address: {Street}, {City}, {PostalCode}");
            Console.WriteLine($"Phone Number: {PhoneNumber}");
            return $"Name: {FirstName} {LastName}, Address: {Street}, {City}, {PostalCode}, Phone: {PhoneNumber}";
        }
    }
}
