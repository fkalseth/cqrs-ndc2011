using System.ServiceModel.Activation;
using Ndc2011.ServiceHost.Infrastructure;

namespace Ndc2011.ServiceHost
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Commands : IAcceptCommands
    {
        private readonly IExecuteCommands _executor;

        public Commands(IExecuteCommands executor)
        {
            _executor = executor;
        }

        public CommandResult Execute(Command command)
        {
            var result = _executor.Execute(command);
            return result;
        }
    }
}
