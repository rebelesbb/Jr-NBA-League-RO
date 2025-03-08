using Jr_NBA_League_RO.Domain;

namespace Jr_NBA_League_RO.Repository.EntitiesRepositories;

public class ActivePlayersRepository : AbstractDatabaseRepository<Tuple<long, long>, ActivePlayer>
{
    public ActivePlayersRepository(string connectionString) : base(connectionString)
    {
    }

    protected override void LoadData()
    {
        var activePlayers = DataReader.ReadData(DatabaseConnection, "active_players", EntityDatabaseMapping.MapActivePlayer);
        activePlayers.ForEach(player => Entities.Add(player.Id, player));
    }
}