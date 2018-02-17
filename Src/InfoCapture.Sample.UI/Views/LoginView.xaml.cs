using InfoCapture.Sample.UI.ViewModels;
using System.Windows.Controls;

namespace InfoCapture.Sample.UI.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView(LoginViewModel vm)
        {
            InitializeComponent();
            
            DataContext = vm;
        }
    }
}
