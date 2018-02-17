using InfoCapture.Sample.Infrastructure;
using System;

namespace InfoCapture.Sample.Data
{
	public class Customer : ObservableObject, InfoCapture.Sample.Data.ICustomer
	{
		private string firstName;
		private string lastName;
		private int customerID;
		private string email;
		private string phone;

		public Customer()
		{
			CustomerID = -1;
		}

		public string Phone
		{
			get { return phone; }
			set 
			{
				phone = value;

				RaisePropertyChanged();
			}
		}

		public string Email
		{
			get { return email; }
			set
			{
				email = value;

				RaisePropertyChanged();
			}
		}

		public int CustomerID
		{
			get { return customerID; }
			set
			{
				customerID = value;

				RaisePropertyChanged();
			}
		}

		public string LastName
		{
			get { return lastName; }
			set
			{
				lastName = value;

				RaisePropertyChanged();
			}
		}

		public string FirstName
		{
			get { return firstName; }
			set
			{
				firstName = value;

				RaisePropertyChanged();
			}
		}
	}
}