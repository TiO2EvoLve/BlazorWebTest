using Microsoft.AspNetCore.Components;
using Web.Entitys;

namespace Web.Pages;

public class Home_razor : ComponentBase
{
    protected TimeSpan currentTime;
    private readonly DateTime StartTime = new (2025,3,27);
    private DateTime NowTime => DateTime.Now;

    
    protected override void OnInitialized()
    {
        currentTime = NowTime - StartTime;
        new Timer(UpdateTime, null, 0, 1000);
    }
    private void UpdateTime(object state)
    {
        currentTime = NowTime - StartTime;
        InvokeAsync(StateHasChanged);
    }
    
    protected readonly List<Skill> Skills =
    [
        new() { Name = "UE5", Class = "pink", Img = "./images/Icon/UE5.png", Progress = 80 },
        new() { Name = "C#", Class = "green", Img = "./images/Icon/C2.png", Progress = 95 },
        new() { Name = "Blender", Class = "blue", Img = "./images/Icon/Blender.png", Progress = 60 },
        new() { Name = "Python", Class = "purply", Img = "./images/Icon/python.png", Progress = 40 },
        new() { Name = "Pt", Class = "orange", Img = "./images/Icon/pt.png", Progress = 20 },
        new() { Name = "S&box", Class = "yellow", Img = "./images/Icon/sbox.png", Progress = 50 },
    ];


}