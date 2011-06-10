using System;
using System.ServiceModel;
using System.Windows;
using Ndc2011.ServiceHost;

namespace Silverlight_Client
{
    public class CommandSender : ISendCommands
    {
        public void SendCommand(Command command, Action<CommandResult> resultCallback = null)
        {
            var channel = CreateChannel();

            channel.BeginExecute(command, ar =>
            {
                var commandResult = channel.EndExecute(ar);
                if (null != resultCallback) Deployment.Current.Dispatcher.BeginInvoke(()=>resultCallback(commandResult));

            }, null);
        }

        private static IAcceptCommands CreateChannel()
        {
            var factory = new ChannelFactory<IAcceptCommands>(new BasicHttpBinding(),
                                                              new EndpointAddress("http://localhost:4040/Commands.svc"));
            var channel = factory.CreateChannel();
            return channel;
        }
    }
}