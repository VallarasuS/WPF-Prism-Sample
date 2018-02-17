using InfoCapture.Sample.Infrastructure;
using System;

namespace InfoCapture.Sample.Data
{
	public class Product : ObservableObject, InfoCapture.Sample.Data.IProduct
	{
		private string name;
		private string category;
		private string sellerName;
		private string description;
		private int productID;
		private double prize;
		private int stock;
		private bool inStock;

		public Product()
		{
			ProductID = -1;
		}

		public bool InStock
		{
			get { return inStock; }
			set
			{
				inStock = value;

				RaisePropertyChanged();
			}
		}

		public int Stock
		{
			get { return stock; }
			set
			{
				stock = value;

				InStock = stock > 0;

				RaisePropertyChanged();
			}
		}

		public string Category
		{
			get { return category; }
			set
			{
				category = value;

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

		public int ProductID
		{
			get { return productID; }
			set
			{
				productID = value;

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

		public string SellerName
		{
			get { return sellerName; }
			set
			{
				sellerName = value;

				RaisePropertyChanged();
			}
		}

		public string Name
		{
			get { return name; }
			set
			{
				name = value;

				RaisePropertyChanged();
			}
		}
	}
}