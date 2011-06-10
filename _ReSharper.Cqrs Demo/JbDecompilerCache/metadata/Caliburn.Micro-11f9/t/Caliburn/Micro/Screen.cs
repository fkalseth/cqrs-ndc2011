// Type: Caliburn.Micro.Screen
// Assembly: Caliburn.Micro, Version=1.1.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f
// Assembly location: E:\Dropbox\Dropbox\Source\ndc2011\Cqrs Demo\packages\Caliburn.Micro.1.1.0\lib\SL40\Caliburn.Micro.dll

using System;
using System.ComponentModel;

namespace Caliburn.Micro
{
    public class Screen : ViewAware, IScreen, IHaveDisplayName, IActivate, IDeactivate, IGuardClose, IClose, INotifyPropertyChangedEx, INotifyPropertyChanged, IChild
    {
        public Screen();
        public bool IsInitialized { get; private set; }

        #region IChild Members

        public virtual object Parent { get; set; }

        #endregion

        #region IScreen Members

        void IActivate.Activate();
        void IDeactivate.Deactivate(bool close);
        public virtual void CanClose(Action<bool> callback);
        public void TryClose();
        public virtual string DisplayName { get; set; }
        public bool IsActive { get; private set; }
        public event EventHandler<ActivationEventArgs> Activated;
        public event EventHandler<DeactivationEventArgs> AttemptingDeactivation;
        public event EventHandler<DeactivationEventArgs> Deactivated;

        #endregion

        protected virtual void OnInitialize();
        protected virtual void OnActivate();
        protected virtual void OnDeactivate(bool close);
    }
}
