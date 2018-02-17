using InfoCapture.Sample.UI.ViewModels;
using System.Windows.Controls;

namespace InfoCapture.Sample.UI.Views
{
    /// <summary>
    /// Interaction logic for ShoppingCartView.xaml
    /// </summary>
    public partial class ShoppingCartView : UserControl
    {
        public ShoppingCartView(ShoppingCartViewModel vm)
        {
            InitializeComponent();

            DataContext = vm;
        }
    }
}