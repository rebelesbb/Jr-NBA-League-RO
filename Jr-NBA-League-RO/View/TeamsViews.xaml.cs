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
    /// Interaction logic for TeamsViews.xaml
    /// </summary>
    public partial class TeamsViews : UserControl
    {
        public JrNBALeagueService Service { get; set; }
        public ObservableCollection<Team> teamsModel { get; set; }

        public TeamsViews(JrNBALeagueService service)
        {
            DataContext = this;
            this.Service = service;
            teamsModel = new ObservableCollection<Team>();
            InitializeComponent();
            initModel();
        }

        private void initModel()
        {
            Service.GetTeams().ForEach(team => teamsModel.Add(team));
        }
    }
}
