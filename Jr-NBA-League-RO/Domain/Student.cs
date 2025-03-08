namespace Jr_NBA_League_RO.Domain;

public class Student: Entity<long>
{
    public string Name { get; set; }
    public string School { get; set; }

    public Student(string name, string school)
    {
        Name = name;
        School = school;
    }

    public override string ToString()
    {
        return $"Student id{Id}: {Name}, School: {School}";
    }
}