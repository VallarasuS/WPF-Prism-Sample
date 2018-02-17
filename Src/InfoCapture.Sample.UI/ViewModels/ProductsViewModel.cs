using InfoCapture.Sample.Common;
using InfoCapture.Sample.Data;
using InfoCapture.Sample.DataService;
using InfoCapture.Sample.Infrastructure;
using Microsoft.Practices.Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace InfoCapture.Sample.UI.ViewModels
{
    public class ProductsViewModel : ViewModelBase
    {
        private ObservableCollection<IProduct> products;
        private ICollectionView viewSource;

        public ProductsViewModel()
        {
            var dataService = new InfoCaptureDataService();

            Products = dataService.GetAllProducts();

            AddItemToCartCommand = new RelayCommand<IProduct>(product => {
                if (product.Stock > 0) product.Stock -= 1;
                RegionManager.RequestNavigate(RegionNames.RightPaneRegion, new Uri("ShoppingCartView", UriKind.Relative));
                Eventaggregator.GetEvent<AddItemToCart>().Publish(product);
            });

            viewSource = CollectionViewSource.GetDefaultView(Products);
            viewSource.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            viewSource.SortDescriptions.Add(new System.ComponentModel.SortDescription("Name", System.ComponentModel.ListSortDirection.Ascending));

            ViewSource = viewSource;
        }

        public ObservableCollection<IProduct> Products
        {
            get { return products; }
            set 
            {
                products = value;

                RaisePropertyChanged();
            }
        }

        public RelayCommand<IProduct> AddItemToCartCommand { get; set; }

        public ICollectionView ViewSource
        {
            get { return viewSource; }
            set 
            { 
                viewSource = value;

                RaisePropertyChanged();
            }
        }
    }
}
