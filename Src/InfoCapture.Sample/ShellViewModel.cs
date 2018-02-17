using InfoCapture.Sample.Data;
using InfoCapture.Sample.DataService;
using InfoCapture.Sample.Infrastructure;
using InfoCapture.Sample.UI.ViewModels;
using Microsoft.Practices.Unity;
using System;
using Microsoft.Practices.Prism.Regions;

namespace InfoCapture.Sample
{
    public class ShellViewModel : ViewModelBase
    {
        private ICustomer currentUser;
        private bool canViewCart;
        private ShoppingCartViewModel cartViewModel;
        public RelayCommand NavigateToShoppingCartViewCommand { get; set; }

        public ShellViewModel()
        {
            Eventaggregator.GetEvent<LoginCompleted>().Subscribe(customer => this.CurrentUser = new InfoCaptureDataService().FindCustomer(customer));
            NavigateToShoppingCartViewCommand = new RelayCommand(() => RegionManager.RequestNavigate(RegionNames.RightPaneRegion, new Uri("ShoppingCartView", UriKind.Relative)));
        }

        public bool CanViewCart
        {
            get { return canViewCart; }
            set 
            { 
                canViewCart = value;

                RaisePropertyChanged();
            }
        }

        public ICustomer CurrentUser
        {
            get { return currentUser; }
            set 
            {
                currentUser = value;

                CanViewCart = currentUser != null;

                RaisePropertyChanged();
            }
        }
    }
}