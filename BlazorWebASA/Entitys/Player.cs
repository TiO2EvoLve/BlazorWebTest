namespace Web.Entitys;

public class Player
{
    public string SteamId { get; set; } = "";
    public string PersonaName { get; set; } = "";
    public string AvatarFull { get; set; } = "";
    public string Profileurl { get; set; } = "";
    public double Lastlogoff { get; set; }
    public int Personastate { get; set; }
    public double Timecreated { get; set; }
    public string Loccountrycode { get; set; }
}