using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace InfoCapture.Sample.Infrastructure
{
	public abstract class Initializer : IModule
	{
		protected IUnityContainer Container { get; private set; }
		protected IRegionManager RegionManager { get; private set; }

		public Initializer(IUnityContainer container, IRegionManager regionManager)
		{
			Container = container;
			RegionManager = regionManager;
		}

		public void Initialize()
		{
			RegisterTypes();
			RegisterServices();
		}

		protected abstract void RegisterTypes();
		protected abstract void RegisterServices();
	}
}