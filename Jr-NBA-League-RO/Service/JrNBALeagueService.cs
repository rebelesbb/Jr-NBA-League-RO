using Jr_NBA_League_RO.Domain;
using Jr_NBA_League_RO.Utils;

namespace Jr_NBA_League_RO.Service;

public class JrNBALeagueService
{
    private DataManager _dataManager;

    public JrNBALeagueService(DataManager dataManager)
    {
        _dataManager = dataManager;
    }

    public List<Player> GetPlayersOfTeam(long teamId)
    {
        return _dataManager.PlayersRepository.FindAll()
            .Where(p => p.TeamId == teamId).ToList();
    }

    public List<ActivePlayer> GetActivePlayersOfTeamAtGame(long teamId, long gameId)
    {
        var teamPlayers = GetPlayersOfTeam(teamId).ConvertAll(p  => p.Id);
        return _dataManager.ActivePlayersRepository.FindAll()
            .Where(ap => ap.GameId == gameId && teamPlayers.Contains(ap.PlayerId)).ToList();
    }

    public List<Game> GetGamesOfTimePeriod(DateTime startDate, DateTime endDate)
    {
        return _dataManager.GamesRepository.FindAll()
            .Where(g => startDate <= g.Date && g.Date <= endDate).ToList();
    }

    public Score GetScoreOfGame(long gameId)
    {
        var game = _dataManager.GamesRepository.FindAll().ToList().First(g => g.Id == gameId);
        var firstTeamPlayers = GetPlayersOfTeam(game.FirstTeamId).ConvertAll(p  => p.Id);
        var secondTeamPlayers = GetPlayersOfTeam(game.SecondTeamId).ConvertAll(p => p.Id);
        
        var firstTeamScore = _dataManager.ActivePlayersRepository.FindAll()
            .Where(activePlayer => activePlayer.GameId == gameId && firstTeamPlayers.Contains(activePlayer.PlayerId))
            .Sum(activePlayer => activePlayer.ScoredPointsNumber);
        
        var secondTeamScore = _dataManager.ActivePlayersRepository.FindAll()
            .Where(activePlayer => activePlayer.GameId == gameId && secondTeamPlayers.Contains(activePlayer.PlayerId))
            .Sum(activePlayer => activePlayer.ScoredPointsNumber);

        var score = new Score
        {
            FirstTeamScore = firstTeamScore,
            SecondTeamScore = secondTeamScore,
            FirstTeamName = _dataManager.TeamsRepository.FindAll().First(team => team.Id == game.FirstTeamId).Name,
            SecondTeamName = _dataManager.TeamsRepository.FindAll().First(team => team.Id == game.SecondTeamId).Name
        };

        return score;
    }

    public List<Team> GetTeams()
    {
        return [.. _dataManager.TeamsRepository.FindAll()];
    }

    public List<Player> GetPlayers()
    {
        return [.. _dataManager.PlayersRepository.FindAll()];
    }

    public List<Game> GetGamesOfTeam(long teamId)
    {
        return _dataManager.GamesRepository.FindAll()
            .Where(game => game.FirstTeamId == teamId || game.SecondTeamId == teamId)
            .ToList();
    }

    public List<Game> GetGames()
    {
        return [.. _dataManager.GamesRepository.FindAll()];
    }
}