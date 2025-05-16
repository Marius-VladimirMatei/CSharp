using System;
using _0401_eventManager.Controllers;
namespace _0401_eventManager.Views
{
    public class Menu
    {
        private readonly EventManager _eventManager;

        public Menu(EventManager eventManager)
        {
            _eventManager = eventManager;
        }

        public void DisplayMenu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n=== Event Management System ===");
                Console.WriteLine("1. Add New Event");
                Console.WriteLine("2. Display All Events");
                Console.WriteLine("3. Add Participant to Event");
                Console.WriteLine("4. Display Participants for Event");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        _eventManager.AddEvent();
                        break;
                    case "2":
                        _eventManager.DisplayAllEvents();
                        break;
                    case "3":
                        _eventManager.AddParticipant();
                        break;
                    case "4":
                        _eventManager.DisplayParticipants();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }
    }
}