using System;
using System.Collections.Generic;
using System.IO;
using _0401_eventManager.Models;

namespace _0401_eventManager.Services
{
    public static class DataStorage
    {
        private const string EventsFile = "events.csv";
        private const string ParticipantsFile = "participants.csv";

        public static List<Event> LoadData()
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

            if (File.Exists(ParticipantsFile))
            {
                foreach (var line in File.ReadAllLines(ParticipantsFile))
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        var eventName = parts[0];
                        var name = parts[1];
                        var email = parts[2];
                        var ev = events.Find(e => e.Name.Equals(eventName, StringComparison.OrdinalIgnoreCase));
                        if (ev != null)
                        {
                            ev.AddParticipant(new Participant(name, email));
                        }
                    }
                }
            }

            return events;
        }

        public static void SaveData(List<Event> events)
        {
            using (var writer = new StreamWriter(EventsFile, false))
            {
                foreach (var ev in events)
                {
                    writer.WriteLine($"{ev.Name},{ev.Date:O},{ev.Location}");
                }
            }

            using (var writer = new StreamWriter(ParticipantsFile, false))
            {
                foreach (var ev in events)
                {
                    foreach (var participant in ev.Participants)
                    {
                        writer.WriteLine($"{ev.Name},{participant.Name},{participant.Email}");
                    }
                }
            }
        }
    }
}