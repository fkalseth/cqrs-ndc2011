using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;

namespace Ndc2011.ServiceHost
{
    [ServiceContract, ServiceKnownType("GetKnownTypes", typeof(KnownCommandTypes))]
    public interface IAcceptCommands
    {

#if !SILVERLIGHT

            [OperationContract]
            CommandResult Execute(Command command);

#endif
#if SILVERLIGHT

            [OperationContract(AsyncPattern = true)]
            IAsyncResult BeginExecute(Command command, AsyncCallback callback, object state);
            CommandResult EndExecute(IAsyncResult ar);

#endif
    }


    public static class KnownCommandTypes
    {
        private static readonly List<Type> KnownTypes = new List<Type>();

        public static IEnumerable<Type> GetKnownTypes(ICustomAttributeProvider provider)
        {
            return KnownTypes;
        }

        public static void Add(Type commandType)
        {
            KnownTypes.Add(commandType);
        }
    }
}