using System.Configuration;
using Jr_NBA_League_RO.Repository.EntitiesRepositories;

namespace Jr_NBA_League_RO.Utils;

public class DataManager
{
    public GamesRepository GamesRepository { get; set; }
    public PlayersRepository PlayersRepository { get; set; }
    public TeamsRepository TeamsRepository { get; set; }
    public ActivePlayersRepository ActivePlayersRepository { get; set; }

    public DataManager()
    {
        GamesRepository = new GamesRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        PlayersRepository = new PlayersRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        TeamsRepository = new TeamsRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        ActivePlayersRepository = new ActivePlayersRepository(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    }
    
    public DataManager(PlayersRepository playersRepository, TeamsRepository teamsRepository,
        GamesRepository gamesRepository, ActivePlayersRepository activePlayersRepository)
    {
        PlayersRepository = playersRepository;
        TeamsRepository = teamsRepository;
        GamesRepository = gamesRepository;
        ActivePlayersRepository = activePlayersRepository;
    }

}