using InfoCapture.Sample.Data;
using InfoCapture.Sample.DataAccess;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace InfoCapture.Sample.DataService
{
    public class InfoCaptureDataService
    {
        private static InfoCaptureBaseContext context;
        private static ICustomer currentUser;

        public InfoCaptureBaseContext Context
        {
            get 
            {
                return InfoCaptureDataService.context; 
            }
            set 
            {
                InfoCaptureDataService.context = value; 
            }
        }

        public static ICustomer CurrentUser
        {
            get { return InfoCaptureDataService.currentUser; }
            set
            {
                InfoCaptureDataService.currentUser = value;
            }
        }

        public InfoCaptureDataService()
        {
            if (InfoCaptureDataService.context == null)
            {
                Trace.TraceInformation(string.Format("{0} : Initializing data context", DateTime.Now));

                InfoCaptureDataService.context = InfoCaptureBaseContext.GetContext(DataStore.SQL);

                Trace.TraceInformation(string.Format("{0} : Data context initialization completed", DateTime.Now));
            }
        }

        public ICustomer AddCustomer(ICustomer customer)
        {
            return Context.Customers.Add(customer);
        }

        public ICustomer FindCustomer(string name)
        {
            var customers = Context.Customers.GetAll();

            return customers.FirstOrDefault(c => c.FirstName == name);
        }

        public System.Collections.ObjectModel.ObservableCollection<IProduct> GetAllProducts()
        {
            var products = Context.Products.GetAll();

            return new System.Collections.ObjectModel.ObservableCollection<IProduct>(products);
        }

        public System.Collections.ObjectModel.ObservableCollection<IOrder> GetAllOrders(int customerID)
        {
            var orders = Context.Orders.GetAll().Where(o => o.Cutsomer.CustomerID == customerID);

            orders
                .ToList()
                .ForEach(o => o.Entries = new ObservableCollection<IOrderEntry>(Context.OrderEntries.GetAll().Where(e => e.Order.OrderID == o.OrderID)));

            orders.SelectMany(o => o.Entries).ToList().ForEach(e => e.Product = Context.Products.GetAll().FirstOrDefault(p => p.ProductID == e.Product.ProductID));

            return new System.Collections.ObjectModel.ObservableCollection<IOrder>(orders);
        }

        public IOrder AddOrder(IOrder order)
        {
            return Context.Orders.Add(order);
        }
    }
}
