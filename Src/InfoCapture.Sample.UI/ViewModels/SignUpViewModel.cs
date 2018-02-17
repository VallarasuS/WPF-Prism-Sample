using InfoCapture.Sample.Data;
using InfoCapture.Sample.DataService;
using InfoCapture.Sample.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Regions;

namespace InfoCapture.Sample.UI
{
    public class SignUpViewModel : ViewModelBase
    {
        private string firstName;
        private string lastName;
        private int customerID;
        private string email;
        private string phone;

        public SignUpViewModel()
        {
            SingUpCommand = new RelayCommand(SingUp);
        }

        private void SingUp()
        {
            var dataService = new InfoCaptureDataService();

            ICustomer customer = DataFactory.CreateCustomer( 
                -1,
                FirstName,
                LastName,
                Email,
                Phone
            );

            customer = dataService.AddCustomer(customer);

            RegionManager.RequestNavigate(RegionNames.RightPaneRegion, new Uri("LoginView", UriKind.Relative));
        }

        public RelayCommand SingUpCommand { get; set; }

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
