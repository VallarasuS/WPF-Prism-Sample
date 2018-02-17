
using InfoCapture.Sample.DataService;
using InfoCapture.Sample.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Diagnostics;

namespace InfoCapture.Sample.UI.ViewModels
{
	public class LoginViewModel : ViewModelBase
	{
		private string customerName;
		private string error;

		public LoginViewModel()
		{
			LoginCommand = new RelayCommand(Login, () => !string.IsNullOrEmpty(CustomerName));
			SignUpcommand = new RelayCommand(() => RegionManager.RequestNavigate(RegionNames.RightPaneRegion, new Uri("SignUpView", UriKind.Relative)));
		}

		private void Login()
		{
			var dataService = new InfoCaptureDataService();

			Trace.TraceInformation(String.Format("{0} : Attempting to login", DateTime.Now));

			var customer = dataService.FindCustomer(CustomerName);

			if (customer != null)
			{
				Eventaggregator.GetEvent<LoginCompleted>().Publish(customer.FirstName);
				InfoCaptureDataService.CurrentUser = customer;
				RegionManager.RequestNavigate(RegionNames.RightPaneRegion, new Uri("ProductsView", UriKind.Relative));

				Trace.TraceInformation(String.Format("{0} : Login successful", DateTime.Now));
			}
			else
			{
			 
				Error = "Login Failed, Try again!";

				Trace.TraceInformation(String.Format("{0} : Login failed", DateTime.Now));
			}
		}

		public string Error
		{
			get { return error; }
			set 
			{
				error = value;

				RaisePropertyChanged();
			}
		}

		public RelayCommand LoginCommand { get; private set; }

		public RelayCommand SignUpcommand { get; private set; }

		public string CustomerName
		{
			get { return customerName; }
			set
			{
				customerName = value;

				Error = String.Empty;

				RaisePropertyChanged();
			}
		}
	}
}