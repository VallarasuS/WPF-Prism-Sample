using InfoCapture.Sample.Infrastructure;

namespace InfoCapture.Sample.Data
{
    public class OrderEntry : ObservableObject, InfoCapture.Sample.Data.IOrderEntry
    {
        private IProduct product;
        private int quantity;
        private int orderEntryID;
        private IOrder order;

        public OrderEntry()
        {
            orderEntryID = -1;
        }

        public int OrderEntryID
        {
            get { return orderEntryID; }
            set
            {
                orderEntryID = value;

                RaisePropertyChanged();
            }
        }

        public IProduct Product
        {
            get { return product; }
            set
            {
                product = value;

                RaisePropertyChanged();
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;

                RaisePropertyChanged();
            }
        }

        public IOrder Order
        {
            get { return order; }
            set
            {
                order = value;

                RaisePropertyChanged();
            }
        }
    }
}