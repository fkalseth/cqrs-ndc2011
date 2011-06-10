namespace Ndc2011.ServiceHost.Infrastructure
{
    public interface IExecuteCommands
    {
        CommandResult Execute(object command);
    }
}