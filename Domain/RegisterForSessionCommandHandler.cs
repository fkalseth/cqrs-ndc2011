using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure;
using Ndc2011.ServiceHost;
using Ndc2011.ServiceHost.Infrastructure;

namespace Domain
{
    public class RegisterForSessionCommandHandler : IHandle<RegisterForSessionCommand>
    {
        private readonly IRepository<Conference> _conferences;
        private readonly IRepository<Attendee> _attendees;

        public RegisterForSessionCommandHandler(IRepository<Conference> conferences, IRepository<Attendee> attendees)
        {
            _conferences = conferences;
            _attendees = attendees;
        }

        public CommandResult Handle(RegisterForSessionCommand command)
        {
            Conference conference = _conferences.Get(command.ConferenceId);
            Attendee attendee = _attendees.Get(command.AttendeeId);

            conference.SignUpForSession(attendee, command.SessionId);

            return CommandResult.Executed(attendee.Name + " successfully signed up for session.");
        }
    }

}
