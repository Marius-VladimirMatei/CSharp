using System;
using _0401_eventManager.Models;
using _0401_eventManager.Interfaces;
using _0401_eventManager.Controllers;

namespace _0401_eventManager.Services
{
    public class EmailNotifier : IEventNotifier
    {
        public void Notify(Event ev, Participant participant)
        {
            Console.WriteLine($"Email sent to {participant.Email}: You have been registered for '{ev.Name}' on {ev.Date:d} at {ev.Location}.");
        }
        
        public void HandleParticipantAdded(object sender, ParticipantAddedHandler e)
        {
            Notify(e.Event, e.Participant);
        }
    }
}