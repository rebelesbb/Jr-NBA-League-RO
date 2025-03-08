namespace Jr_NBA_League_RO.Domain;

public struct Score
{
    public long FirstTeamScore { get; set; }
    public long SecondTeamScore { get; set; }
    public string FirstTeamName { get; set; }
    public string SecondTeamName { get; set; }
}

public class Game : Entity<long>
{
    public long FirstTeamId { get; set; }
    public long SecondTeamId { get; set; }
    public DateTime Date { get; set; }

    public Game(long firstTeamId, long secondTeamId, DateTime date)
    {
        FirstTeamId = firstTeamId;
        SecondTeamId = secondTeamId;
        Date = date;
    }

    public override string ToString()
    {
        return $"Game Id{Id} : {FirstTeamId}, {SecondTeamId}, {Date}";
    }
}