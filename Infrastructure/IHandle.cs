namespace Ndc2011.ServiceHost.Infrastructure
{
    public interface IHandle<in TCommand>
    {
        CommandResult Handle(TCommand command);
    }
}