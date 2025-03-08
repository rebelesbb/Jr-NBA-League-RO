namespace Jr_NBA_League_RO.Domain;

public class Team: Entity<long>
{
    public string Name { get; set; }

    public Team(string name)
    {
        Name = name;
    }
    
    public override string ToString() => Name;
}