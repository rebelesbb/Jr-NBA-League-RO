using Jr_NBA_League_RO.Domain;

namespace Jr_NBA_League_RO.Repository.EntitiesRepositories;

public class GamesRepository : AbstractDatabaseRepository<long, Game>
{
    public GamesRepository(string connectionString) : base(connectionString)
    {
    }

    protected override void LoadData()
    {
        var games = DataReader.ReadData(DatabaseConnection, "games", EntityDatabaseMapping.MapGame);
        games.ForEach(game => Entities.Add(game.Id, game));
    }
}