using System;
namespace InfoCapture.Sample.Data
{
    public interface IOrderEntry
    {
        IOrder Order { get; set; }
        int OrderEntryID { get; set; }
        IProduct Product { get; set; }
        int Quantity { get; set; }
    }
}
