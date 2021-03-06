using System.Data.Services.Client;
using System.Reflection;
using System.Windows;
using System.Windows.Resources;
using Ndc2011.ServiceHost;
using Ninject;
using Silverlight_Client.Services;

namespace Silverlight_Client
{
	using System;
	using System.Collections.Generic;
	using Caliburn.Micro;
    public class AppBootstrapper : Bootstrapper<ShellViewModel>
    {
        private IKernel _kernel;

        protected override void Configure()
        {
            _kernel = new StandardKernel();

            _kernel.Bind<IWindowManager>().To<WindowManager>().InSingletonScope();
            _kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            _kernel.Bind<ISendCommands>().To<CommandSender>().InTransientScope();

            _kernel.Bind<ConferenceContext>().ToMethod(c => new ConferenceContext(new Uri("http://localhost:4040/Data.svc"))).InTransientScope();
            _kernel.Bind<DataServiceContext>().ToMethod(c => c.Kernel.Get<ConferenceContext>());

            RegisterKnownCommandTypes();
        }

        private void RegisterKnownCommandTypes()
        {
            foreach (AssemblyPart ap in Deployment.Current.Parts)
            {
                StreamResourceInfo sri = Application.GetResourceStream(new Uri(ap.Source, UriKind.Relative)); 
                Assembly asm = new AssemblyPart().Load(sri.Stream);

                foreach(var type in asm.GetTypes())
                {
                    if(type.BaseType == typeof(Command))
                    {
                        KnownCommandTypes.Add(type);
                    }
                }
            }

        }

        protected override object GetInstance(Type service, string key)
        {
            if (service != null)
            {
                return _kernel.Get(service);
            }

            throw new ArgumentNullException("service");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _kernel.GetAll(service);
        }

        protected override void BuildUp(object instance)
        {
            _kernel.Inject(instance);
        }

        protected override IEnumerable<Assembly> SelectAssemblies()
        {
            return new[] { Assembly.GetExecutingAssembly() };
        }
    }
}
