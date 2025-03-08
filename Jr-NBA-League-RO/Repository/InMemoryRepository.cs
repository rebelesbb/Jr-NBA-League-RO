using Jr_NBA_League_RO.Domain;

namespace Jr_NBA_League_RO.Repository;

public class InMemoryRepository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : Entity<TId> where TId : notnull
{
    protected IDictionary<TId, TEntity> Entities = new Dictionary<TId, TEntity>();

    public IEnumerable<TEntity> FindAll()
    {
        return Entities.Values.ToList();
    }
}