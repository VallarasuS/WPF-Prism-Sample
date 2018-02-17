using System.Windows.Controls;

namespace InfoCapture.Sample.UI
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        public SignUpView(SignUpViewModel vm)
        {
            InitializeComponent();

            DataContext = vm;
        }
    }
}