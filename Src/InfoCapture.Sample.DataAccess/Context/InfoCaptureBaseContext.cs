using InfoCapture.Sample.Data;

namespace InfoCapture.Sample.DataAccess
{
    public abstract class InfoCaptureBaseContext
    {
        public abstract DataSet<ICustomer> Customers { get; set; }

        public abstract DataSet<IOrder> Orders { get; set; }

        public abstract DataSet<IOrderEntry> OrderEntries { get; set; }

        public abstract DataSet<IReview> Reviews { get; set; }

        public abstract DataSet<IProduct> Products { get; set; }

        public static InfoCaptureBaseContext GetContext(DataStore dataStore)
        {
            if (dataStore == DataStore.SQL)
                return new SQLInfoCaptureContext();
            else
                return null;
        }
    }

    public enum DataStore
    {
        SQL,
    }
}