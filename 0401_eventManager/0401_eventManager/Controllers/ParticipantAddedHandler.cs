using System;
using _0401_eventManager.Models;

namespace _0401_eventManager.Controllers
{
    // Carries details of the event and the new added participant
    public class ParticipantAddedHandler : EventArgs
    {   
        public Event Event { get; }
        public Participant Participant { get; }
        public ParticipantAddedHandler(Event ev, Participant participant)
        {
            Event = ev;
            Participant = participant;
        }

    }
    // Delegate to handle the event - fires when a participant is added
    public delegate void ParticipantAddedEventHandler(object sender, ParticipantAddedHandler e);

}
