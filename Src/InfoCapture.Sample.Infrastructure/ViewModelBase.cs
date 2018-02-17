using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoCapture.Sample.Infrastructure
{
    public class ViewModelBase : ObservableObject
    {
        private IRegionManager regionManager;
        private IEventAggregator eventaggregator;
        private IUnityContainer container;

        public IUnityContainer Container
        {
            get { return container; }
            set { container = value; }
        }

        public IEventAggregator Eventaggregator
        {
            get { return eventaggregator; }
            set { eventaggregator = value; }
        }

        public IRegionManager RegionManager
        {
            get { return regionManager; }
            set { regionManager = value; }
        }

        public ViewModelBase()
        {
            RegionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            Eventaggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            Container = ServiceLocator.Current.GetInstance<IUnityContainer>();
        }
    }
}
