using System;
namespace InfoCapture.Sample.Data
{
    public interface IReview
    {
        string Description { get; set; }
        IProduct Product { get; set; }
        string ReviewerName { get; set; }
        int ReviewID { get; set; }
    }
}
