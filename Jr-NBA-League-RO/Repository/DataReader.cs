using Npgsql;

namespace Jr_NBA_League_RO.Repository;

public class DataReader
{
    public static List<TEntity> ReadData<TEntity>(NpgsqlConnection connection, string tableName, CreateEntity<TEntity> createEntity)
    {
        List<TEntity> entities = [];
        var query = $"SELECT * FROM {tableName}";

        try
        {
            connection.Open();
        

            using(var command = new NpgsqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var entity = createEntity(reader);
                        entities.Add(entity);
                    }
                }
            }

            return entities;
        
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return [];
        }
    }

    public static List<TEntity> ReadData<TEntity>(NpgsqlConnection connection, CreateEntity<TEntity> createEntity, string query)
    {
        List<TEntity> entities = [];
        try
        {
            connection.Open();
        

            using(var command = new NpgsqlCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var entity = createEntity(reader);
                        entities.Add(entity);
                    }
                }
            }

            return entities;
        
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return [];
        }
    }
}