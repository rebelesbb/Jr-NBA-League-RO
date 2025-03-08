namespace Jr_NBA_League_RO.Domain;

public class Player: Student
{
    public long TeamId { get; set; }

    public Player(string name, string school, long teamId) : base(name, school)
    {
        TeamId = teamId;
    }

    public override string ToString()
    {
        return Name;
    }
}