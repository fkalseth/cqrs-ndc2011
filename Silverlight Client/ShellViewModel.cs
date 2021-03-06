using System.Linq;
using Caliburn.Micro;
using Silverlight_Client.Views;

namespace Silverlight_Client {
    using System.ComponentModel.Composition;

    [Export(typeof(IShell))]
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive
    {
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        private IEventAggregator _eventAggregator;

        protected override void OnInitialize()
        {
            var view = IoC.Get<SessionsViewModel>();
            _eventAggregator.Subscribe(view);
            Items.Add(view);
            ActivateItem(Items.First());
        }
    }
}
