using Jr_NBA_League_RO.Domain;

namespace Jr_NBA_League_RO.Repository.EntitiesRepositories;

public class TeamsRepository : AbstractDatabaseRepository<long, Team>
{
    public TeamsRepository(string connectionString) : base(connectionString)
    {
    }
    
    protected override void LoadData()
    {
        var teams = DataReader.ReadData(DatabaseConnection, "teams", EntityDatabaseMapping.MapTeam);
        teams.ForEach(team => Entities.Add(team.Id, team));
    }
}