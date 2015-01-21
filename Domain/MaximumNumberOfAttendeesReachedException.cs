using System;

namespace Domain
{
    public class MaximumNumberOfAttendeesReachedException : Exception
    {
        public MaximumNumberOfAttendeesReachedException(Session session)
            : base("The maximum number of attendees has been reached for the session " + session.Title)
        {

        }
    }
}