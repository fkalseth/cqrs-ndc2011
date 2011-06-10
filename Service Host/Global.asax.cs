using System;
using System.Data.Objects;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Domain;
using Infrastructure;
using Ndc2011.ServiceHost.Infrastructure;
using Ninject;
using Ninject.Extensions.Interception.Infrastructure.Language;

namespace Ndc2011.ServiceHost
{
    public class Global : Ninject.Extensions.Wcf.NinjectWcfApplication
    {
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();

            var commandExecutorBinding = kernel.Bind<IExecuteCommands>().To<CommandExecutor>().InTransientScope();

            kernel.Bind(typeof (IRepository<>)).To(typeof (Repository<>)).InRequestScope();
            kernel.Bind<ObjectContext>().To<ConferenceContext>().InRequestScope();

            commandExecutorBinding.Intercept().With<CommitChangesInterceptor>().InOrder(10);
            commandExecutorBinding.Intercept().With<CommandTransactionInterceptor>().InOrder(5);
            commandExecutorBinding.Intercept().With<ExceptionToCommandResultInterceptor>().InOrder(1);

            BindAllHandlers(kernel);

            return kernel;
        }

        private void BindAllHandlers(IKernel kernel)
        {
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                if (asm.FullName.StartsWith("System")) continue;

                Debug.WriteLine("Searching assembly for handlers: " + asm.FullName);

                BindAllHandlersInAssembly(kernel, asm);
            }
        }

        private static void BindAllHandlersInAssembly(IKernel kernel, Assembly asm)
        {
            foreach (var type in asm.GetTypes())
            {
                if (type.Name.EndsWith("CommandHandler"))
                {
                    var commandHandlerType = type.GetInterfaces().FirstOrDefault(i => i.Name.StartsWith("IHandle"));

                    if (null == commandHandlerType) continue;

                    BindCommandHandler(kernel, type, commandHandlerType);
                }
            }
        }

        private static void BindCommandHandler(IKernel kernel, Type commandHandlerConcreteType, Type commandHandlerInterfaceType)
        {
            kernel.Bind(commandHandlerInterfaceType).To(commandHandlerConcreteType).InTransientScope();
            var commandType = commandHandlerInterfaceType.GetGenericArguments()[0];
            KnownCommandTypes.Add(commandType);
            Debug.WriteLine("Registered handler " + commandHandlerConcreteType.Name + " for " + commandType.Name);
        }
    }
}