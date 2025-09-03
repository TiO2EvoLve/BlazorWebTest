namespace Web.Entitys;

public class Games
{
    public int appid { get; set; }
    public string name { get; set; }
    public int playtime_2weeks { get; set; }
    public int playtime_forever { get; set; }
    public string? HeaderImage { get; set; }
}

public class GameResponse
{
    public GameResponseData Response { get; set; } = new();
}

public class GameResponseData
{
    public List<Games> games { get; set; } = new();
}
public class AppDetailsResponse
{
    public bool success { get; set; }
    public AppData data { get; set; } = new();
}

public class AppData
{
    public int steam_appid { get; set; }
    public string name { get; set; }
    public string header_image { get; set; }
}