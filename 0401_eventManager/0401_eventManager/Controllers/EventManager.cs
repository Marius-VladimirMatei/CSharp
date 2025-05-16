using System;
using System.Collections.Generic;
using _0401_eventManager.Models;
using _0401_eventManager.Services;
using _0401_eventManager.Interfaces;
using _0401_eventManager.Controllers;

namespace _0401_eventManager.Controllers
{
    public class EventManager
    {
        // List of events and the notifier for sending emails
        private readonly List<Event> _events;
        private readonly IEventNotifier _notifier;

        // Event to be triggered when a participant is added
        public event ParticipantAddedEventHandler ParticipantAdded;

        public EventManager()
        {
            // Load events and then attach participants to each
            _events = EventsDataStorage.LoadEvents();
            ParticipantsDataStorage.LoadParticipants(_events);

            // Initialize the email notifier
            _notifier = new EmailNotifier();
        }

        public void AddEvent()
        {
            Console.WriteLine("\nAdd New Event:");
            string name = InputHandler.GetText("Event Name: ");
            DateTime date = InputHandler.GetDate("Event Date (DD-MM-YYYY): ");
            string location = InputHandler.GetText("Event Location: ");

            // Check for existing event - If event already exists, show error message
            bool exists = false;
            foreach (var eventTest in _events)
            {
                if (eventTest.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    exists = true;
                    break;
                }
            }

            if (exists)
            {
                Console.WriteLine("Error: Event with this name already exists.");
                return;
            }

            var ev = new Event(name, date, location);
            _events.Add(ev);

            // Save both files: new event and updated participants
            EventsDataStorage.SaveEvents(_events);
            ParticipantsDataStorage.SaveParticipants(_events);

            Console.WriteLine("Event added successfully!");
        }

        public void DisplayAllEvents()
        {
            if (_events.Count == 0)
            {
                Console.WriteLine("No events available.");
                return;
            }

            Console.WriteLine("\nAll Events:");
            for (int index = 0; index < _events.Count; index ++)
            {
                var ev = _events[index];
                Console.WriteLine($"{index + 1} Event name: {ev.Name}, Date: {ev.Date:d}, Location: {ev.Location}, Current no. of Participants: {ev.Participants.Count}");
            }
        }

        // Adds a participant and raises the ParticipantAdded event
        public void AddParticipant()
        {
            Console.WriteLine("\nAdd Participant to Event:");
            DisplayAllEvents();
            string eventName = InputHandler.GetText("Enter Event Name: ");

            // Find the event - If event not found, show error message
            Event ev = null;
            foreach (var eventTest in _events)
            {
                if (eventTest.Name.Equals(eventName, StringComparison.OrdinalIgnoreCase))
                {
                    ev = eventTest;
                    break;
                }
            }
            if (ev == null)
            {
                Console.WriteLine($"Error: No event found with name '{eventName}'.");
                return;
            }

            string name = InputHandler.GetText("Participant Name: ");
            string email = InputHandler.GetEmail("Participant Email: ");

            // Check for existing participant - If participant already registered, show error message
            bool alreadyRegistered = false;
            foreach (var participantTest in ev.Participants)
            {
                if (participantTest.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    alreadyRegistered = true;
                    break;
                }
            }

            if (alreadyRegistered)
            {
                Console.WriteLine("Error: Participant with this email already registered for the event.");
                return;
            }

            var participant = new Participant(name, email);
            ev.AddParticipant(participant);

            // Raise the event with EventArgs class
            ParticipantAdded?.Invoke(this, new ParticipantAddedHandler(ev, participant));

            // Save participants file
            ParticipantsDataStorage.SaveParticipants(_events);

            // Notify the participant via email
            _notifier.Notify(ev, participant);

            Console.WriteLine("Participant added successfully!");
        }

        public void DisplayParticipants()
        {
            Console.WriteLine("\nDisplay Participants for Event:");
            DisplayAllEvents();
            string eventName = InputHandler.GetText("Enter Event Name: ");

            // Find the event - If event not found, show error message
            Event ev = null;
            foreach (var evTest in _events)
            {
                if (evTest.Name.Equals(eventName, StringComparison.OrdinalIgnoreCase))
                {
                    ev = evTest;
                    break;
                }
            }
            if (ev == null)
            {
                Console.WriteLine($"Error: No event found with name '{eventName}'.");
                return;
            }

            if (ev.Participants.Count == 0)
            {
                Console.WriteLine("No participants registered for this event.");
                return;
            }

            Console.WriteLine($"\nParticipants for '{ev.Name}':");
            for (int index = 0; index < ev.Participants.Count; index++)
            {
                var p = ev.Participants[index];
                Console.WriteLine($"{index + 1}. Participant name: {p.Name}, Email: {p.Email}");
            }
        }
    }
}
