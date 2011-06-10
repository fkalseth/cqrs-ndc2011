using System;
using Ndc2011.ServiceHost;

namespace Silverlight_Client
{
    public interface ISendCommands
    {
        void SendCommand(Command command, Action<CommandResult> resultCallback = null);
    }
}