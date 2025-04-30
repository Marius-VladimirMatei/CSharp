using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0203_personalData
{

    // Class designed to handle the user input
    public static class InputHandler
    {
        // Prompts the user for person details and returns a new Person instance.
        public static Person ManualEntry()
        {
            Console.Write("First name: ");
            string firstName = Console.ReadLine();

            Console.Write("Last name: ");
            string lastName = Console.ReadLine();

            int age;
            Console.Write("Age: ");
            // Loop until a valid integer is entered
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.Write("Invalid input. Please enter a valid age: ");
            }

            Console.Write("Telephone number: ");
            string phone = Console.ReadLine();

            // Return a new Person with the gathered data
            return new Person(firstName, lastName, age, phone);
        }
    }
}
