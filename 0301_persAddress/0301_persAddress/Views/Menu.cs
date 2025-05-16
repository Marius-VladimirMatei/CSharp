using System;
using _0301_persAddress.Services;

namespace _0301_persAddress.Views
{
    public class Menu
    {
        private readonly AddressBookManager addressBook;

        public Menu(AddressBookManager addressBook)
        {
            this.addressBook = addressBook;
        }

        public void DisplayMenu()
        {
            bool displayMenu = true;

            while (displayMenu)
            {
                Console.WriteLine("=== Personal data program ===");
                Console.WriteLine("\nAddress Book Menu:");
                Console.WriteLine("1. Add New Entry");
                Console.WriteLine("2. Remove Entry");
                Console.WriteLine("3. Find Entry");
                Console.WriteLine("4. Display All Entries");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        addressBook.AddAddress();
                        break;
                    case "2":
                        addressBook.RemoveAddress();
                        break;
                    case "3":
                        addressBook.FindAddress();
                        break;
                    case "4":
                        addressBook.DisplayAllEntries();
                        break;
                    case "5":
                        displayMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}


