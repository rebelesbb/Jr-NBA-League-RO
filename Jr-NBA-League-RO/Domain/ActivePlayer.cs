namespace Jr_NBA_League_RO.Domain;

public enum PlayerType
{
    Rezerva, 
    Participant
}

public class ActivePlayer : Entity<Tuple<long, long>>
{
    public long PlayerId 
    { 
        get => Id.Item1; 
        set => Id = new Tuple<long, long>(value, Id.Item2); 
    }
    public long GameId
    {
        get => Id.Item2; 
        set => Id = new Tuple<long, long>(value, Id.Item1);
    }
    public long ScoredPointsNumber { get; set; }
    public PlayerType PlayerType { get; set; }

    public ActivePlayer(long scoredPointsNumber, PlayerType playerType)
    {
        ScoredPointsNumber = scoredPointsNumber;
        PlayerType = playerType;
    }

    public override string ToString()
    {
        return $"Active Player [player:{Id.Item1}, game:{Id.Item2}] : scoredPointsNumber: {ScoredPointsNumber} | playerType: {PlayerType}";
    }
}
