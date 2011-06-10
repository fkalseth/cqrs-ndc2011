using System.Windows;
using Caliburn.Micro;
using Domain;
using Silverlight_Client.Queries;
using Silverlight_Client.Services;

namespace Silverlight_Client.Views
{
    public class SessionsViewModel : Screen
    {
        private readonly GetAllUpcomingSessionsQuery _query;
        private readonly ISendCommands _commands;

        public SessionsViewModel(GetAllUpcomingSessionsQuery query, ISendCommands commands)
        {
            _query = query;
            _commands = commands;
        }

        protected override void OnActivate()
        {
            Sessions.Clear();
            _query.Execute(Sessions);
        }

        private readonly BindableCollection<Session> _sessions = new BindableCollection<Session>();

        public BindableCollection<Session> Sessions
        {
            get { return _sessions; }
        }

        public void Attend(Session session)
        {
            _commands.SendCommand(new RegisterForSessionCommand
            {
                AttendeeId = CurrentAttendeeId, 
                ConferenceId = session.Agenda_Id, 
                SessionId = session.Id
            }, result =>
            {
                if (result.IsExecuted) MessageBox.Show("A seat has been reserved for you!");
                else MessageBox.Show("Reservation failed: " + result.Message);
            });

        }

        protected int CurrentAttendeeId = 1; // hardcoded for demo purposes
    }
}
