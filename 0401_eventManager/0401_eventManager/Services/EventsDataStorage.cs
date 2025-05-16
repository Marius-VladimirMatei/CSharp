using System;
using System.Collections.Generic;
using System.IO;
using _0401_eventManager.Models;

namespace _0401_eventManager.Services
{
    public static class EventsDataStorage
    { // Reads events.csv and adds each Event to the list.
        // Each line in the file should contain the event name, date, and location separated by commas.
        private const string EventsFile = "events.csv";

        public static List<Event> LoadEvents() 
        {
            var events = new List<Event>();
            if (File.Exists(EventsFile))
            {
                foreach (var line in File.ReadAllLines(EventsFile))
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3 && DateTime.TryParse(parts[1], out DateTime date))
                    {
                        events.Add(new Event(parts[0], date, parts[2]));
                    }
                }
            }
            return events;
        }
        // Writes out all Events to events.csv.
        public static void SaveEvents(List<Event> events)
        {
            using (var writer = new StreamWriter(EventsFile, false))
            {
                foreach (var ev in events)
                {
                    writer.WriteLine($"{ev.Name},{ev.Date:O},{ev.Location}");
                }
            }
        }
    }
}