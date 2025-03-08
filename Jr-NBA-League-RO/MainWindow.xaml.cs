using System.Collections.ObjectModel;
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
using Jr_NBA_League_RO.Service;
using Jr_NBA_League_RO.Utils;
using Jr_NBA_League_RO.View;

namespace Jr_NBA_League_RO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        public JrNBALeagueService Service { get; set; }
        
        public MainWindow()
        {
            DataManager dataManager = new DataManager();
            Service = new JrNBALeagueService(dataManager);
            InitializeComponent();
            ContentArea.Content = new HomeView();
        }

        private void TeamsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new TeamsViews(Service);
        }

        private void PlayersMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new PlayersView(Service);
        }

        private void ActivePlayersMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new ActivePlayersView(Service);
        }

        private void GamesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new GamesView(Service);
        }
    }
}