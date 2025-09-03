namespace Web.Entitys;

public class Games
{
    public string appid;
    public string name;
    public double playtime_2weeks;
    public double playtime_foreve;
}

public class GameResponse
{
    public GameResponseData Response { get; set; } = new();
}

public class GameResponseData
{
    public List<Games> games { get; set; } = new();
}