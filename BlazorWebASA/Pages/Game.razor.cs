using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Web.Entitys;

namespace Web.Pages;

public class Game_razor: ComponentBase
{

    protected Player? player;
    [Inject]
    private HttpClient Http { get; set; } = default!;
    protected readonly Dictionary<int,string> state= new ()
    {
        {0,"离线" }, 
        {1,"在线" },
        {2,"忙碌" },
        {3,"离开" },
        {4,"打盹" },
        {5,"想交易" },
        {6,"想玩游戏" }
    };

    protected override async Task OnInitializedAsync()
    {
        //获取Steam信息
        var result = await Http.GetFromJsonAsync<SteamResponse>(
            "/.netlify/functions/steam?steamid=76561198325902444"
        );
        player = result?.Response?.Players?.FirstOrDefault();
        
    }

    public class SteamResponse
    {
        public SteamResponseData Response { get; set; } = new();
    }

    public class SteamResponseData
    {
        public List<Player> Players { get; set; } = new();
    }

    public string GetTime(double time)
    {
        
        // 将Unix时间戳转换为DateTime
        DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            .AddSeconds(time)
            .ToLocalTime(); // 转换为本地时间
        
        // 格式化为"yyyy-MM-dd"格式
        return dateTime.ToString("yyyy-MM-dd");
        
    }
    
    
}