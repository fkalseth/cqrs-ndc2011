using System.Linq;

namespace Domain
{
    public partial class Conference
    {
         public void SignUpForSession(Attendee attendee, int sessionId)
         {
             EnsureAttendeeIsAttendingThisConference(attendee);

             var session = FindSession(sessionId);

             session.Attend(attendee);
         }

        private Session FindSession(int sessionId)
        {
            var session = Sessions.FirstOrDefault(s => s.Id == sessionId);

            if (null == session) throw new SessionNotFoundException(sessionId, this);

            return session;
        }

        private void EnsureAttendeeIsAttendingThisConference(Attendee attendee)
        {
            if (!IsAttending(attendee))
            {
                throw new NotAttendingConferenceException(attendee, this);
            }
        }

        private bool IsAttending(Attendee attendee)
        {
            return Attendees.Contains(attendee);
        }
    }
}