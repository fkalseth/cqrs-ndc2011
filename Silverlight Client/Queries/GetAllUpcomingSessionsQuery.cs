using System;
using System.Data.Services.Client;
using System.Linq;
using Silverlight_Client.Services;

namespace Silverlight_Client.Queries
{
    public class GetAllUpcomingSessionsQuery : DataContextQuery<Session, Session>
    {
        public GetAllUpcomingSessionsQuery(DataServiceContext context)
            : base(context)
        {}

        protected override IQueryable<Session> BuildQuery(DataServiceContext context)
        {
            var query = from s in context.CreateQuery<Session>("Sessions").Expand("Speakers")
                        orderby s.StartHour, s.Track ascending
                        select s;

            return query;
        }

        protected override Session Map(Session model)
        {
            return model;
        }
    }
}