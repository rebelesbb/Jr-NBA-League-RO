using Npgsql;

namespace Jr_NBA_League_RO.Domain;

public class EntityDatabaseMapping
{
    public static Team MapTeam(NpgsqlDataReader reader)
    {
        var teamName = reader["name"].ToString();
        var teamId = Convert.ToInt64(reader["id"].ToString());
        
        var team = new Team(teamName!)
        {
            Id = teamId
        };

        return team;
    }

    public static Student MapStudent(NpgsqlDataReader reader)
    {
        var studentName = reader["name"].ToString();
        var studentSchool = reader["school"].ToString();
        var studentId = Convert.ToInt64(reader["id"].ToString());

        Student student = new Student(studentName!, studentSchool!)
        {
            Id = studentId
        };

        return student;
    }

    public static Player MapPlayer(NpgsqlDataReader reader)
    {
        var name = reader["name"].ToString();
        var school = reader["school"].ToString();
        var studentId = Convert.ToInt64(reader["id"].ToString());
        var teamId = Convert.ToInt64(reader["team_id"].ToString());

        Player player = new Player(name!, school!, teamId)
        {
            Id = studentId
        };

        return player;
    }

    public static Game MapGame(NpgsqlDataReader reader)
    {
        var firstTeamId = Convert.ToInt64(reader["first_team_id"].ToString());
        var secondTeamId = Convert.ToInt64(reader["second_team_id"].ToString());
        var gameDate = Convert.ToDateTime(reader["game_date"].ToString());
        var gameId = Convert.ToInt64(reader["id"].ToString());

        Game game = new Game(firstTeamId, secondTeamId, gameDate)
        {
            Id = gameId
        };
        
        return game;
    }

    public static ActivePlayer MapActivePlayer(NpgsqlDataReader reader)
    {
        var playerId = Convert.ToInt64(reader["player_id"].ToString());
        var gameId = Convert.ToInt64(reader["game_id"].ToString());
        var scoredPointsNum = Convert.ToInt64(reader["scored_points"].ToString());
        var playerType = reader["player_type"].ToString();

        ActivePlayer activePlayer = new ActivePlayer(scoredPointsNum, Enum.Parse<PlayerType>(playerType!))
        {
            Id = new Tuple<long, long>(playerId, gameId)
        };
        
        return activePlayer;
    }
}