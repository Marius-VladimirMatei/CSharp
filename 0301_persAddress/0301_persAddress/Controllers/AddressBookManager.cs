using System;
using System.Collections.Generic;
using _0301_persAddress.Interfaces;

namespace _0301_persAddress.Services
{
    // Class designed to manage the address book
    // Implements the methods from IAddressBook interface
    public class AddressBookManager : IAddressBook
    {
        // List to store address entries
        private readonly List<Address> addresses;

        public AddressBookManager()
        {
            // load existing entries (or empty list if file missing)
            addresses = DataStorage.LoadAdress();
        }

        // Method to add a new address entry
        public void AddAddress()
        {

            // Console.Clear(); // Clear screen before starting the add-address process
            try
            {
                // Get user input for address details
                string firstName = InputHandler.GetName("Enter First name: ");
                string lastName = InputHandler.GetName("Enter Last name: ");
                string street = InputHandler.GetText("Enter Street name: ");
                string city = InputHandler.GetText("Enter City: ");
                string postalCode = InputHandler.GetPostalCode("Enter Postal code: ");
                string phoneNumber = InputHandler.GetPhone("Enter Phone number: ");

                // Duplicate phone number exception handling
                // Check for duplicate phone number
                bool duplicate = false;
                foreach (Address addr in addresses)
                {
                    if (addr.PhoneNumber == phoneNumber)
                    {
                        duplicate = true;
                        break;
                    }
                }
                if (duplicate)
                {
                    Console.WriteLine("Error: An address with this phone number already exists.");
                    return;
                }

                // Create a new Address object and add it to the list
                Address address = new Address(firstName, lastName, street, city, postalCode, phoneNumber);
                // Add the address to the list
                addresses.Add(address);
                // Save the updated list to the file
                DataStorage.SaveAddress(addresses);
                Console.WriteLine("Address added successfully!");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during input or saving and display an error message
                // according to the step of the process
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Method to remove an address entry
        public void RemoveAddress()
        {
            // Console.Clear(); // Clear screen before starting the remove-address process
            try
            {
                // Prompt the user for the last name and trim any whitespace
                Console.Write("Enter Last name to remove: ");
                string lastName = Console.ReadLine()?.Trim();

                // Find the address to remove
                Address toRemove = null; // Initialize to null
                foreach (Address address in addresses)
                {
                    if (address.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)) // Case insensitive comparison
                    {
                        toRemove = address;
                        break; // Exit the loop if the address is found
                    }
                }

                // Throw exception if address not found
                if (toRemove == null)
                    throw new Exception($"No address found with last name '{lastName}'.");

                // Remove and save
                addresses.Remove(toRemove);
                DataStorage.SaveAddress(addresses);
                Console.WriteLine("Address removed successfully!");
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying the error message
                Console.WriteLine($"Error: {ex.Message}");
            }
        }



        // Method to find an address entry
        public void FindAddress()
        {
            // Console.Clear(); // Clear screen before starting the find address process
            try
            {
                Console.Write("Enter Last name to find: ");
                string lastName = Console.ReadLine()?.Trim();

                // Find the address
                Address foundAddress = null; // Initialize to null
                foreach (Address address in addresses)
                {
                    if (address.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)) // Case insensitive comparison
                    {
                        foundAddress = address;
                        break; // Exit the loop if the address is found
                    }
                }

                // Throw exception if address not found
                if (foundAddress == null)
                    throw new Exception($"No address found with last name '{lastName}'.");

                // Display the found address
                foundAddress.DisplayInfo();
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying the error message
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Method to display all address entries
        public void DisplayAllEntries()
        {
            // Console.Clear(); // Clear screen before displaying all entries
            // If no entries exist, inform user
            if (addresses.Count == 0)
            {
                Console.WriteLine("No address entries found.");
                return;
            }

            Console.WriteLine("\nAll entries:");
            foreach (Address address in addresses)
            {
                address.DisplayInfo();
                Console.WriteLine();
            }
        }
    }
}

