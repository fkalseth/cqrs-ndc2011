using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace Ndc2011.ServiceHost.Infrastructure
{
    public class CommandExecutor : IExecuteCommands
    {
        private readonly IKernel _kernel;

        public CommandExecutor(IKernel kernel)
        {
            _kernel = kernel;
        }

        public virtual CommandResult Execute(object command)
        {
            dynamic handler = FindHandlerFor(command);

            CommandResult result = handler.Handle(command as dynamic);
            return result;
        }

        private object FindHandlerFor(object command)
        {
            var handlerType = typeof(IHandle<>).MakeGenericType(command.GetType());

            dynamic handler = _kernel.Get(handlerType);
            return handler;
        }
    }
}