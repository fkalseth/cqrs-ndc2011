using System;

namespace Domain
{
    public class SessionNotFoundException : Exception
    {
        public SessionNotFoundException(int sessionId, Conference conference) : base("No session with id " + sessionId + " found in conference " + conference.Name)
        {}
    }
}