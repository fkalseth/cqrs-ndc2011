using System;

namespace Domain
{
    public class NotAttendingConferenceException : Exception
    {
        public NotAttendingConferenceException(Attendee attendee, Conference conference) : base(attendee.Name + " is not registered for the conference " + conference.Name)
        {
            
        }
    }
}