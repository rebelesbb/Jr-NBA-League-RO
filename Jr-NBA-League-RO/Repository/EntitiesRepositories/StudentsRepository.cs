using Jr_NBA_League_RO.Domain;

namespace Jr_NBA_League_RO.Repository.EntitiesRepositories;

public class StudentsRepository : AbstractDatabaseRepository<long, Student>
{
    public StudentsRepository(string connectionString) : base(connectionString)
    {
    }

    protected override void LoadData()
    {
        var students = DataReader.ReadData(DatabaseConnection, "students", EntityDatabaseMapping.MapStudent);
        students.ForEach(student => Entities.Add(student.Id, student));
    }
}