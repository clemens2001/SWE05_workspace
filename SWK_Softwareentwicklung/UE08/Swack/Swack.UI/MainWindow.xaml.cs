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
using Swack.Logic;
using Swack.Logic.Models;
using Swack.UI.ViewModels;

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

            var user = new User("czellinger", "https://robohash.org/clemens");
            var logic = new SimulatedMessagingLogic(user);

            var viewModel = new MainViewModel(logic);
            DataContext = viewModel;

            Loaded += async (sender, e) => await viewModel.InitializeAsync();
        }
    }
}