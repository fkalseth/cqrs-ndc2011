// Type: System.Windows.Application
// Assembly: System.Windows, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e
// Assembly location: c:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\Silverlight\v4.0\System.Windows.dll

using MS.Internal;
using System;
using System.Collections;
using System.ComponentModel;
using System.Security;
using System.Windows.Interop;
using System.Windows.Resources;

namespace System.Windows
{
    public class Application : IManagedPeer, IManagedPeerBase, INativeCoreTypeWrapper
    {
        public Application();
        public ResourceDictionary Resources { get; set; }

        public UIElement RootVisual { get; [SecuritySafeCritical]
        set; }

        public Window MainWindow { [SecuritySafeCritical]
        get; }

        public IList ApplicationLifetimeObjects { get; }
        public SilverlightHost Host { get; }
        public InstallState InstallState { get; }
        public bool IsRunningOutOfBrowser { get; }

        public bool HasElevatedPermissions { get; [EditorBrowsable(EditorBrowsableState.Never), SecurityCritical]
        set; }

        public static Application Current { [SecuritySafeCritical]
        get; }

        #region IManagedPeer Members

        [SecurityCritical]
        void IManagedPeer.BeginShutdown();

        [SecurityCritical]
        void IManagedPeer.EndShutdown();

        [SecurityCritical]
        void IManagedPeer.RemovePeerReferenceToItem(IManagedPeerBase child);

        [SecurityCritical]
        void IManagedPeer.AddPeerReferenceToItem(IManagedPeerBase child);

        Delegate IManagedPeer.GetInstanceEventDelegate(string eventName);

        IntPtr IManagedPeerBase.NativeObject { [SecurityCritical]
        get; }

        #endregion

        [SecuritySafeCritical]
        public bool Install();

        public void CheckAndDownloadUpdateAsync();

        [SecuritySafeCritical]
        public static void LoadComponent(object component, Uri resourceLocator);

        public static StreamResourceInfo GetResourceStream(StreamResourceInfo zipPackageStreamResourceInfo, Uri uriResource);
        public static StreamResourceInfo GetResourceStream(Uri uriResource);

        public event StartupEventHandler Startup;
        public event EventHandler Exit;
        public event EventHandler<ApplicationUnhandledExceptionEventArgs> UnhandledException;
        public event EventHandler InstallStateChanged;
        public event CheckAndDownloadUpdateCompletedEventHandler CheckAndDownloadUpdateCompleted;
    }
}
