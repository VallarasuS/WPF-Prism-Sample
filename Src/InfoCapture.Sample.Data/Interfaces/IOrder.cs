using System;
namespace InfoCapture.Sample.Data
{
    public interface IOrder
    {
        ICustomer Cutsomer { get; set; }
        System.Collections.ObjectModel.ObservableCollection<IOrderEntry> Entries { get; set; }
        DateTime OrderDate { get; set; }
        int OrderID { get; set; }
        OrderState OrderState { get; set; }
        double Prize { get; set; }
    }
}
