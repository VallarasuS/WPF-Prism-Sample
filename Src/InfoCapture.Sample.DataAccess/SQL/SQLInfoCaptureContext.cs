
using System.Configuration;
namespace InfoCapture.Sample.DataAccess
{
    public class SQLInfoCaptureContext : InfoCaptureBaseContext
    {
        public SQLInfoCaptureContext()
        {
            Customers = new CustomerDataSet();
            Products = new ProductDataSet();
            Orders = new OrderDataSet();
            OrderEntries = new OrderEntryDataSet();
        }
        
        public static IDataStore dataStore;

        public static IDataStore GetDataStore()
        {
            if (dataStore == null)
                dataStore = new SqlDataStore(ConfigurationSettings.AppSettings["ConnectionString"]);

            return dataStore;
        }

        public override DataSet<Data.ICustomer> Customers
        {
            get;
            set;
        }

        public override DataSet<Data.IOrder> Orders
        {
            get;
            set;
        }

        public override DataSet<Data.IOrderEntry> OrderEntries
        {
            get;
            set;
        }

        public override DataSet<Data.IReview> Reviews
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }

        public override DataSet<Data.IProduct> Products
        {
            get;
            set;
        }
    }
}
