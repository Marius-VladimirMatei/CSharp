using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0203_personalData
{
    public class PersonManager
    {
        // List to hold all Person objects
        private List<Person> personList;

        public PersonManager()
        {
            // Load all data from external file
            personList = DataStorage.LoadData();
        }

        public void Run()
        {
            bool exitRequested = false;
            while (!exitRequested)
            {
                Menu.ShowMenu();
                string choice = Menu.GetChoice();
                Console.WriteLine(); // Blank line for readability

                switch (choice)
                {
                    case "1":
                        AddPerson();
                        break;

                    case "2":
                        FilterByAge();
                        break;

                    case "3":
                        DisplayAll();
                        break;

                    case "4":
                        exitRequested = true;
                        Console.WriteLine("Exiting application. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose between 1 and 4.\n");
                        break;
                }
            }
        }

        // Method for adding and saving a new Person object
        private void AddPerson()
        {
            var newPerson = InputHandler.ManualEntry();
            // Add new Person to the list
            personList.Add(newPerson);
            // Save the updated list to the external file
            DataStorage.SaveData(personList);
            Console.WriteLine("Person added successfully!\n");
        }


        // Method for filtering and displaying Person objects by age
        private void FilterByAge()
        {
            // Prompt user for maximum age
            Console.Write("Enter the maximum age: ");
            if (int.TryParse(Console.ReadLine(), out int maxAge))
            {
                // New list to hold filtered Person objects
                List<Person> filteredPersons = new List<Person>();
                foreach (Person objectPerson in personList)
                {
                    if (objectPerson.Age <= maxAge)
                    {
                        filteredPersons.Add(objectPerson);
                    }
                }

                if (filteredPersons.Count == 0)
                {
                    Console.WriteLine($"No entries found with age <= {maxAge}.\n");
                    return;
                }

                Console.WriteLine($"People aged {maxAge} or younger:");
                foreach (Person p in filteredPersons)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();  // Blank line for readability
            }
            else
            {
                Console.WriteLine("Invalid age input. Please enter a number.\n");
            }
        }

        // Method for displaying all Person objects
        private void DisplayAll()
        {
            if (personList.Count == 0)
            {
                Console.WriteLine("No entries available.\n");
                return;
            }

            Console.WriteLine("All entries:");
            foreach (var p in personList)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine(); // Blank line for readability
        }
    }
}
