using InfoCapture.Sample.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace InfoCapture.Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledExceptionOccurred;

            base.OnStartup(e);

            Trace.TraceInformation(String.Format("{0} : Initiating boot strapper sequence", DateTime.Now));
            
            // throws the shell window
            var bootStrapper = new Bootstrapper();
            bootStrapper.Run();

            Trace.TraceInformation(String.Format("{0} : Boot strapper sequence completed", DateTime.Now));

            bootStrapper.ShowMainWindow();

            // navigate to Login on start

            var container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            var regionManager = container.Resolve<IRegionManager>();
            regionManager.RequestNavigate(RegionNames.RightPaneRegion, new Uri("LoginView", UriKind.Relative));  
        }

        private void OnUnhandledExceptionOccurred(object sender, UnhandledExceptionEventArgs e)
        {
            Trace.WriteLine(e.ExceptionObject,"Un handled exception occurred");

            MessageBox.Show("Requested operation cannot be completed! Check the logs for more information. \nApplication will now exit.", "Error");

            Environment.Exit(1);
        }
    }
}