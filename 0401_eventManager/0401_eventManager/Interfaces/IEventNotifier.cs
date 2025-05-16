
using _0401_eventManager.Controllers;
using _0401_eventManager.Models;

namespace _0401_eventManager.Interfaces
{
    public interface IEventNotifier
    {
       
        void Notify(Event ev, Participant participant);

        void HandleParticipantAdded(object sender, ParticipantAddedHandler e);
    }
}
