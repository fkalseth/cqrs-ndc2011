using Ndc2011.ServiceHost;

namespace Domain
{
    public class RegisterForSessionCommand : Command
    {
        public int ConferenceId { get; set; }

        public int AttendeeId { get; set; }

        public int SessionId { get; set; }
    }
}