using Jr_NBA_League_RO.Domain;

namespace Jr_NBA_League_RO.Repository.EntitiesRepositories;

public class PlayersRepository : AbstractDatabaseRepository<long, Player>
{
    public PlayersRepository(string connectionString) : base(connectionString)
    {
    }

    protected override void LoadData()
    {
        const string query = "SELECT S.id, S.name, S.school, P.team_id FROM students S INNER JOIN players P ON S.id = P.student_id";
        var players = DataReader.ReadData(DatabaseConnection,EntityDatabaseMapping.MapPlayer, query);
        players.ForEach(player => Entities.Add(player.Id, player));
    }
}