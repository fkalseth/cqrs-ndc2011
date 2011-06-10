using System.Linq;

namespace Domain
{
    public partial class Session
    {
        public void Attend(Attendee attendee)
        {
            EnsureSessionIsNotFull();
            Attendees.Add(attendee);
        }

        private void EnsureSessionIsNotFull()
        {
            if(!HasCapacity)
            {
                throw new MaximumNumberOfAttendeesReachedException(this);
            }

        }

        protected bool HasCapacity
        {
            get { return Attendees.Count() < Capacity; }
        }
    }
}