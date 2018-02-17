using InfoCapture.Sample.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InfoCapture.Sample.Data
{
    public class Order: ObservableObject, InfoCapture.Sample.Data.IOrder
    {
        private ICustomer cutsomer;
        private DateTime orderDate;
        private int orderID;
        private ObservableCollection<IOrderEntry> entries;
        private double prize;
        private OrderState orderState;


        public Order()
        {
            Entries = new ObservableCollection<IOrderEntry>();
            OrderID = -1;
        }

        public ObservableCollection<IOrderEntry> Entries
        {
            get { return entries; }
            set
            {
                entries = value;

                RaisePropertyChanged();
            }
        }

        public OrderState OrderState
        {
            get { return orderState; }
            set
            {
                orderState = value;

                RaisePropertyChanged();
            }
        }

        public int OrderID
        {
            get { return orderID; }
            set
            {
                orderID = value;

                RaisePropertyChanged();
            }
        }

        public DateTime OrderDate
        {
            get { return orderDate; }
            set
            {
                orderDate = value;

                RaisePropertyChanged();
            }
        }

        public double Prize
        {
            get { return prize; }
            set
            {
                prize = value;

                RaisePropertyChanged();
            }
        }

        public ICustomer Cutsomer
        {
            get { return cutsomer; }
            set
            {
                cutsomer = value;

                RaisePropertyChanged();
            }
        }
    }
}