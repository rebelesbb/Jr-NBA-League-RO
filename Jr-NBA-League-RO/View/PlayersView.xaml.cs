using Jr_NBA_League_RO.Domain;
using Jr_NBA_League_RO.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jr_NBA_League_RO.View
{
    /// <summary>
    /// Interaction logic for PlayersView.xaml
    /// </summary>
    public partial class PlayersView : UserControl
    {
        public JrNBALeagueService Service { get; set; }
        public ObservableCollection<Player> PlayersModel { get; set; } 
        public ObservableCollection<Team> TeamsComboBoxItems { get; set; }

        public PlayersView(JrNBALeagueService service)
        {
            DataContext = this;
            this.Service = service;
            PlayersModel = new ObservableCollection<Player>();
            TeamsComboBoxItems = new ObservableCollection<Team>();
            InitializeComponent();
            InitModel();
        }

        private void InitModel()
        {
            Service.GetPlayers().ForEach(player => PlayersModel.Add(player));
            Service.GetTeams().ForEach(team => TeamsComboBoxItems.Add(team));
        }

        private void teamsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Team selectedTeam = (Team) TeamsComboBox.SelectedItem;
            if(selectedTeam != null)
            {
                PlayersModel.Clear();
                Service.GetPlayersOfTeam(selectedTeam.Id).ForEach(player => PlayersModel.Add(player));
            }
        }
    }
}
