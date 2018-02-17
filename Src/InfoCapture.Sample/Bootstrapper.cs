using InfoCapture.Sample.Infrastructure;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;
using System;
using System.Diagnostics;
using System.Windows;

namespace InfoCapture.Sample
{
	public class Bootstrapper : UnityBootstrapper
	{
		protected override DependencyObject CreateShell()
		{
			Trace.TraceInformation(String.Format("{0} : Initializing shell", DateTime.Now));

			return Container.Resolve<Shell>();

			Trace.TraceInformation(String.Format("{0} : Shell initialization completed", DateTime.Now));
		}

		public void ShowMainWindow()
		{
			Application.Current.MainWindow = (Window)Shell;
			Application.Current.MainWindow.Show();
		}

		protected override IModuleCatalog CreateModuleCatalog()
		{
			Trace.TraceInformation(String.Format("{0} : Configuring module catalog", DateTime.Now));

			return new ConfigurationModuleCatalog();

			Trace.TraceInformation(String.Format("{0} : Module catalog configuration completed", DateTime.Now));
		}

		protected override Microsoft.Practices.Prism.Regions.RegionAdapterMappings ConfigureRegionAdapterMappings()
		{
			RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();

			return mappings;
		}
	}
}
