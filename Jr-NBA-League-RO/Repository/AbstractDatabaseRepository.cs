using Jr_NBA_League_RO.Domain;
using Npgsql;

namespace Jr_NBA_League_RO.Repository;

public delegate TEntity CreateEntity<out TEntity>(NpgsqlDataReader dataReader);

public abstract class AbstractDatabaseRepository<TId, TEntity> : InMemoryRepository<TId, TEntity> where TEntity: Entity<TId>
{
    protected NpgsqlConnection DatabaseConnection { get; set; }

    public AbstractDatabaseRepository(string connectionString)
    {
        DatabaseConnection = new NpgsqlConnection(connectionString);
        LoadData();
    }

    protected abstract void LoadData();
}