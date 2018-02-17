using System;
namespace InfoCapture.Sample.Data
{
    public interface IProduct
    {
        string Category { get; set; }
        string Description { get; set; }
        bool InStock { get; set; }
        string Name { get; set; }
        double Prize { get; set; }
        int ProductID { get; set; }
        string SellerName { get; set; }
        int Stock { get; set; }
    }
}
