namespace Web.Entitys;

public class Games
{
    public int appid { get; set; }
    public string name { get; set; }
    public int playtime_2weeks { get; set; }
    public int playtime_forever { get; set; }
}

public class GameResponse
{
    public GameResponseData Response { get; set; } = new();
}

public class GameResponseData
{
    public List<Games> games { get; set; } = new();
}