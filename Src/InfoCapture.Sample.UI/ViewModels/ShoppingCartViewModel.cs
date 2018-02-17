using InfoCapture.Sample.Common;
using InfoCapture.Sample.Data;
using InfoCapture.Sample.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Regions;
using InfoCapture.Sample.DataService;
using System.Collections.ObjectModel;

namespace InfoCapture.Sample.UI.ViewModels
{
    public class ShoppingCartViewModel : ViewModelBase
    {
        private ObservableCollection<IOrder> orders;
        private IOrder currentOrder;
        InfoCaptureDataService dataService;

        public ObservableCollection<IOrder> Orders
        {
            get { return orders; }
            set 
            {
                orders = value;

                RaisePropertyChanged();
            }
        }

        public RelayCommand NavigateToProductsCommand { get; set; }
        public RelayCommand<OrderEntry> RemoveEntryCommand { get; set; }
        public RelayCommand<Order> PlaceOrderCommand { get; set; }

        public ShoppingCartViewModel()
        {
            Orders = new ObservableCollection<IOrder>();
            Eventaggregator.GetEvent<AddItemToCart>().Subscribe(BuildOrder);
            NavigateToProductsCommand = new RelayCommand(() => RegionManager.RequestNavigate(RegionNames.RightPaneRegion, new Uri("ProductsView", UriKind.Relative)));
            RemoveEntryCommand = new RelayCommand<OrderEntry>(entry => currentOrder.Entries.Remove(entry));
            PlaceOrderCommand = new RelayCommand<Order>(PlaceOrder);

            dataService = new InfoCaptureDataService();
            Orders = dataService.GetAllOrders(InfoCaptureDataService.CurrentUser.CustomerID);
        }

        private void PlaceOrder(IOrder order)
        {
            order.OrderState = OrderState.Placed;

            dataService.AddOrder(order);

            this.currentOrder = null;
        }

        private void BuildOrder(IProduct product)
        {
            Action evaluatePrize = () => currentOrder.Prize = currentOrder.Entries.Sum(e => e.Product.Prize * e.Quantity);

            if(currentOrder == null)
            {
                currentOrder = DataFactory.CreateOrder(-1, InfoCaptureDataService.CurrentUser, DateTime.Now);
                currentOrder.Entries.CollectionChanged += delegate { evaluatePrize(); };
            }

            IOrderEntry entry = currentOrder.Entries.FirstOrDefault(o => o.Product.ProductID == product.ProductID);

            if (entry == null)
                entry = Data.DataFactory.CreateOrderEntry(product, 1, null, currentOrder);
            else
            {
                entry.Quantity += 1;
                evaluatePrize();
            }

            entry.Product = product;
            entry.Order = currentOrder;

            if (!currentOrder.Entries.Contains(entry))
                currentOrder.Entries.Add(entry);

            if (!Orders.Contains(currentOrder))
                Orders.Add(currentOrder);
        }
    }
}
