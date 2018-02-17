using System.Windows;

namespace InfoCapture.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell(ShellViewModel vm)
        {
            InitializeComponent();

            DataContext = vm;
        }
    }
}
