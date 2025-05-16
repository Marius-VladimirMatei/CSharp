
using System;
using _0401_eventManager.Controllers;
using _0401_eventManager.Services;
using _0401_eventManager.Views;

namespace _0401_eventManager
{
    class Program
    {
        static void Main()
        {
            var eventManager = new EventManager();
            var emailNotifier = new EmailNotifier();

            // Wire up the email notifier to the event manager
            eventManager.ParticipantAdded += emailNotifier.HandleParticipantAdded;

            // Wire up a named console‐logging handler
            eventManager.ParticipantAdded += OnParticipantAdded;

            var menu = new Menu(eventManager);
            menu.DisplayMenu();
        }

        // Named handler for console diagnostics logging
        private static void OnParticipantAdded(object sender, ParticipantAddedHandler e)
        {
            Console.WriteLine(
                "[EVENT FIRED] Participant '{0}' (email: {1}) " +
                "added to event '{2}' on {3:d} at {4}",
                e.Participant.Name,
                e.Participant.Email,
                e.Event.Name,
                e.Event.Date,
                e.Event.Location
            );
        }
    }
}