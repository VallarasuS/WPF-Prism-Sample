using InfoCapture.Sample.Infrastructure;
using System;

namespace InfoCapture.Sample.Data
{
	public class Review : ObservableObject, InfoCapture.Sample.Data.IReview
	{
		private string reviewerName;
		private string description;
		private int reviewID;
		private IProduct product;

		public IProduct Product
		{
			get { return product; }
			set
			{
				product = value;

				RaisePropertyChanged();
			}
		}

		public int ReviewID
		{
			get { return reviewID; }
			set
			{
				reviewID = value;

				RaisePropertyChanged();
			}
		}

		public string Description
		{
			get { return description; }
			set
			{
				description = value;

				RaisePropertyChanged();
			}
		}

		public string ReviewerName
		{
			get { return reviewerName; }
			set
			{
				reviewerName = value;

				RaisePropertyChanged();
			}
		}
	}
}