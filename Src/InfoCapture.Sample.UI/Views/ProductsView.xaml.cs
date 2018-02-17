using InfoCapture.Sample.UI.ViewModels;
using System.Windows.Controls;

namespace InfoCapture.Sample.UI.Views
{
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        public ProductsView(ProductsViewModel vm)
        {
            InitializeComponent();

            DataContext = vm;
        }
    }
}
