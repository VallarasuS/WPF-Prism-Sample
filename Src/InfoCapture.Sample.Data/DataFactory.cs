using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoCapture.Sample.Data
{
    public static class DataFactory
    {
        public static ICustomer CreateCustomer(int id)
        {
            return new Customer { CustomerID = id };
        }

        public static ICustomer CreateCustomer(int id, string firstName, string lastName, string email, string phone)
        {
            return new Customer { CustomerID = id, FirstName = firstName, LastName = lastName, Email = email, Phone = phone };
        }

        public static IOrder CreateOrder(int id)
        {
            return new Order { OrderID = id };
        }

        public static IOrder CreateOrder(int id, ICustomer customer,DateTime date, ObservableCollection<IOrderEntry> entries = null, OrderState state = OrderState.InMaking, double prize = 0d)
        {
            if (entries == null)
                entries = new ObservableCollection<IOrderEntry>();

            return new Order { OrderID = id, Cutsomer = customer, Entries = entries, OrderState = state, Prize = prize, OrderDate = date };
        }

        public static IOrderEntry CreateOrderEntry(int id)
        {
            return new OrderEntry { OrderEntryID = id };
        }

        public static IOrderEntry CreateOrderEntry(IProduct product,int quantity, ICustomer customer, IOrder order, int id = -1)
        {
            return new OrderEntry { Order = order, OrderEntryID = id, Product = product, Quantity = quantity };
        }

        public static IProduct CreateProduct(int id)
        {
            return new Product { ProductID = id };
        }

        public static IProduct CreateProduct(int id, string name, string category, string desc,double prize, string seller, int stock)
        {
            return new Product { ProductID = id, Name = name, Description = desc, Category = category, SellerName =seller, Prize = prize, Stock = stock };
        }
    }
}
