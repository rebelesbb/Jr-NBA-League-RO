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
    /// Interaction logic for GamesView.xaml
    /// </summary>
    public partial class GamesView : UserControl
    {
        public JrNBALeagueService Service { get; set; }
        public ObservableCollection<Game> GamesModel { get; set; } 
        public GamesView(JrNBALeagueService service)
        {
            DataContext = this;
            this.Service = service;
            GamesModel = [];
            InitializeComponent();
            InitModel();
        }

        public void InitModel()
        {
            GamesModel.Clear();
            Service.GetGames().ForEach(game => GamesModel.Add(game));
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(EndDatePicker.SelectedDate != null && StartDatePicker.SelectedDate != null)
            {
                DateTime startDate = (DateTime) StartDatePicker.SelectedDate;
                DateTime endDate = (DateTime) EndDatePicker.SelectedDate;

                GamesModel.Clear();
                Service.GetGamesOfTimePeriod(startDate, endDate)
                    .ForEach(game => GamesModel.Add(game));
            }
            else
            { 
                InitModel();
            }
        }

        private void GamesListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(GamesListView.SelectedItem != null)
            {
                Game selectedGame = (Game) GamesListView.SelectedItem;
                Score score = Service.GetScoreOfGame(selectedGame.Id);
                
                FirstTeamNameLabel.Content = score.FirstTeamName;
                FirstTeamScoreLabel.Content = score.FirstTeamScore.ToString();

                SecondTeamNameLabel.Content = score.SecondTeamName;
                SecondTeamScoreLabel.Content = score.SecondTeamScore.ToString();
            }
            else
            {
                FirstTeamNameLabel.Content = "Team number 1";
                FirstTeamScoreLabel.Content = "";

                SecondTeamNameLabel.Content = "Team number 2";
                SecondTeamScoreLabel.Content = "";
            }
        }
    }
}
