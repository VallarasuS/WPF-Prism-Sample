using System;
namespace InfoCapture.Sample.Data
{
    public interface ICustomer
    {
        int CustomerID { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
    }
}
