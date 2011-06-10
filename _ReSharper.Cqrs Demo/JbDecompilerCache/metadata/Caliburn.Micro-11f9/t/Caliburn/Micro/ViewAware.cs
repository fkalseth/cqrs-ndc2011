// Type: Caliburn.Micro.ViewAware
// Assembly: Caliburn.Micro, Version=1.1.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f
// Assembly location: E:\Dropbox\Dropbox\Source\ndc2011\Cqrs Demo\packages\Caliburn.Micro.1.1.0\lib\SL40\Caliburn.Micro.dll

using System;
using System.Collections.Generic;

namespace Caliburn.Micro
{
    public class ViewAware : PropertyChangedBase, IViewAware
    {
        public static bool CacheViewsByDefault;
        protected readonly Dictionary<object, object> Views;
        public ViewAware();
        public ViewAware(bool cacheViews);
        protected bool CacheViews { get; set; }

        #region IViewAware Members

        void IViewAware.AttachView(object view, object context);
        public virtual object GetView(object context = null);
        public event EventHandler<ViewAttachedEventArgs> ViewAttached;

        #endregion

        protected virtual void OnViewAttached(object view, object context);
        protected virtual void OnViewLoaded(object view);
    }
}
