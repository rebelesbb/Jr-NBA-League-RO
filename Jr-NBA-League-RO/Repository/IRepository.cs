using Jr_NBA_League_RO.Domain;

namespace Jr_NBA_League_RO.Repository;

public interface IRepository<TId, TEntity> where TEntity : Entity<TId>
{
    IEnumerable<TEntity> FindAll();
}