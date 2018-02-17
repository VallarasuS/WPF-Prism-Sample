using InfoCapture.Sample.Infrastructure;
using InfoCapture.Sample.UI.Views;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;
using System;

namespace InfoCapture.Sample.UI
{
    public class UIInitializer : Initializer
    {
        public UIInitializer(IUnityContainer container, IRegionManager regionManager)
            : base(container, regionManager)
        {
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<Object, LoginView>("LoginView");
            Container.RegisterType<Object, SignUpView>("SignUpView");
            Container.RegisterType<Object, ProductsView>("ProductsView");
            Container.RegisterType<Object, ShoppingCartView>("ShoppingCartView");
        }

        protected override void RegisterServices()
        {
 
        }
    }
}
