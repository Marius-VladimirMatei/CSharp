using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0401_eventManager.Models;

namespace _0401_eventManager.Services
{
    public static class ParticipantsDataStorage
    {
        private const string ParticipantsFile = "participants.csv";

   
        /// Reads participants.csv and adds each Participant to its matching Event (by name).
       
        public static void LoadParticipants(List<Event> events)
        {
            if (!File.Exists(ParticipantsFile))
                return;

            foreach (var line in File.ReadAllLines(ParticipantsFile))
            {
                var parts = line.Split(',');
                if (parts.Length != 3) continue;

                var eventName = parts[0];
                var name = parts[1];
                var email = parts[2];

                // Explicitly search for the matching Event
                Event foundEvent = null;
                foreach (var ev in events)
                {
                    if (ev.Name.Equals(eventName, StringComparison.OrdinalIgnoreCase))
                    {
                        foundEvent = ev;
                        break;
                    }
                }

                if (foundEvent != null)
                {
                    foundEvent.AddParticipant(new Participant(name, email));
                }
            }
        }

     
        /// Writes out all Participants under their Event name into participants.csv.
     
        public static void SaveParticipants(List<Event> events)
        {
            using (var writer = new StreamWriter(ParticipantsFile, false))
            {
                foreach (var ev in events)
                {
                    foreach (var p in ev.Participants)
                    {
                        writer.WriteLine($"{ev.Name},{p.Name},{p.Email}");
                    }
                }
            }
        }
    }
}