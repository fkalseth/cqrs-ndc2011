using System;

namespace Ndc2011.ServiceHost
{
    public class CommandResult
    {
        public CommandStatus Status { get; set; }

        public string Message { get; set; }

        public bool IsExecuted { get { return Status == CommandStatus.Executed; } }

        public static CommandResult Executed(string message)
        {
            return new CommandResult {Status = CommandStatus.Executed, Message = message};
        }

        public static CommandResult Failed(string message)
        {
            return new CommandResult {Status = CommandStatus.Failed, Message = message};
        }
    }
}