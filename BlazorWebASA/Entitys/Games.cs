namespace Web.Entitys;

public class Games
{
    public string appid;
    public string name;
    public string playtime_2weeks;
    public string playtime_foreve;
}

public class GameResponse
{
    public GameResponseData gameResponse { get; set; } = new();
}

public class GameResponseData
{
    public List<Games> games { get; set; } = new();
}