using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Swack.Logic.Models;
using Swack.UI.ViewModels;

namespace Swack.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IEnumerable<Channel> Channels { get; private set; }

        public Channel? CurrentChannel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            var viewModel = new MainViewModel();

            DataContext = viewModel;
        }
    }
}