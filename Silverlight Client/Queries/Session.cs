using System;
using System.Linq;
using Caliburn.Micro;

namespace Silverlight_Client.Services
{
    public partial class Session
    {
        public Session()
        {
            Speakers.CollectionChanged += (s, e) => OnPropertyChanged("SpeakerNames");
        }

        partial void OnDurationInMinutesChanged()
        {
            OnPropertyChanged("EndHour");
            OnPropertyChanged("EndMinute");
        }
        
        public int EndHour
        {
            get { return new TimeSpan(StartHour, StartMinute, 0).Add(TimeSpan.FromMinutes(DurationInMinutes)).Hours; }
        }

        public int EndMinute
        {
            get { return new TimeSpan(StartHour, StartMinute, 0).Add(TimeSpan.FromMinutes(DurationInMinutes)).Minutes; }
        }
        
        public string SpeakerNames
        {
            get { return string.Join(",", Speakers.Select(s => s.Name)); }
        }

        public string PhotoUrl
        {
            get { return Speakers.First().PhotoUrl; }
        }
    }
}