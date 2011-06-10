using System.Data.Services;
using System.Data.Services.Common;
using Domain;

namespace Ndc2011.ServiceHost
{
    public class Data : DataService<ConferenceContext>
    {
        public static void InitializeService(DataServiceConfiguration config)
        {
            config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
            config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
        }
    }
}