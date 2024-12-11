using Swack.Logic;
using Swack.Logic.Models;
using Swack.UI.ViewModels;
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

namespace Swack.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        

        public MainWindow()
        {
            InitializeComponent();

            var user = new User("pointex", "https://robohash.org/philipp");

            var logic = new SimulatedMessagingLogic(user);

            var viewModel = new MainViewModel(logic);
            DataContext = viewModel;

            Loaded += async (s, e) => await viewModel.InitializeAsync();
        }
    }
}