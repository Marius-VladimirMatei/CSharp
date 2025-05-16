using System;
using System.Collections.Generic;

namespace _0401_eventManager.Models
{
    public class Event
    {   // Properties to store event details
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        // Generic List to store participants
        public List <Participant> Participants { get; } = new List<Participant>();
       

        // Constructor to initialize the event
        public Event(string name, DateTime date, string location)
        {
            Name = name;
            Date = date;
            Location = location;
        }
        // Method to add a participant to the event
        public void AddParticipant(Participant participant)
        {
            if (participant == null)
            {
                throw new ArgumentNullException(nameof(participant), "Participant cannot be null");
            }
            if (Participants.Contains(participant))
            {
                throw new InvalidOperationException("Participant already registered for this event");
            }
            Participants.Add(participant);
        }
    }
}
