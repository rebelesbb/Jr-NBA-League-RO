using Jr_NBA_League_RO.Domain;
using Jr_NBA_League_RO.Repository.EntitiesRepositories;
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
    /// Interaction logic for ActivePlayersView.xaml
    /// </summary>
    public partial class ActivePlayersView : UserControl
    {
        public JrNBALeagueService Service { get; set; }
        public ObservableCollection<Team> TeamsComboBoxItems { get; set; }
        public ObservableCollection<Game> GamesComboBoxItems { get; set; }

        public ObservableCollection<ActivePlayer> ActivePlayersModel { get; set; }

        private long _currentTeamId { get; set; }
        private long _currentGameId { get; set; }

        public ActivePlayersView(JrNBALeagueService service)
        {
            DataContext = this;
            this.Service = service;

            ActivePlayersModel = [];

            TeamsComboBoxItems = [];
            _currentTeamId = -1;

            GamesComboBoxItems = [];
            _currentGameId = -1;

            InitializeComponent();
            InitModel();
        }

        public void InitModel()
        {
            Service.GetTeams().ForEach(team => TeamsComboBoxItems.Add(team));
        }

        private void TeamsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TeamsComboBox.SelectedItem != null)
            {
                Team selectedTeam = (Team)TeamsComboBox.SelectedItem;
                _currentTeamId = selectedTeam.Id;
                
                ActivePlayersModel.Clear();
                GamesComboBoxItems.Clear();
                Service.GetGamesOfTeam(selectedTeam.Id)
                    .ForEach(game => GamesComboBoxItems.Add(game));
            }
            else
            {
                _currentTeamId = -1;
                _currentGameId = -1;
                GamesComboBoxItems.Clear();
            }
        }

        private void GamesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(GamesComboBox.SelectedItem != null)
            {
                ActivePlayersModel.Clear();
                Game selectedGame = (Game)GamesComboBox.SelectedItem;
                _currentGameId = selectedGame.Id;

                if(_currentTeamId != -1 && _currentGameId != -1)
                {
                    Service.GetActivePlayersOfTeamAtGame(_currentTeamId, _currentGameId)
                        .ForEach(activePlayer => ActivePlayersModel.Add(activePlayer));
                }
            }
            else 
            {
                _currentGameId = -1;
                ActivePlayersModel.Clear();
            }
        }
    }
}
