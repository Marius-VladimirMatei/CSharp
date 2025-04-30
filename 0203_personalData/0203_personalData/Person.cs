using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0203_personalData
{

    // Class designed to represent a person with specific attributes
    public class Person
    {
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string TelephoneNumber { get; set; }



        // Constructor
        public Person(string firstName, string lastName, int age, string telephoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            TelephoneNumber = telephoneNumber;
        }

        // Formatted string of Person representation
        public override string ToString()
        {
            return $"{FirstName} {LastName}, Age: {Age}, Phone: {TelephoneNumber}";
        }
    }
}
