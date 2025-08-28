using Microsoft.AspNetCore.Components;

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

    public class Skill
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Img { get; set; }
        public int Progress { get; set; }
    }

    public List<Skill> Skills = new()
    {
        new Skill { Name = "UE5", Class = "pink",Img = "./images/Icon/UE5.png", Progress = 100 },
        new Skill { Name = "C#", Class = "green",Img = "./images/Icon/C2.png", Progress = 90 },
        new Skill { Name = "Blender", Class = "blue",Img = "./images/Icon/Blender.png", Progress = 80 },
        new Skill { Name = "Python", Class = "purply",Img = "./images/Icon/python.png", Progress = 75 },
        new Skill { Name = "PS", Class = "orange", Img = "./images/Icon/ps.png",Progress = 40 },
        new Skill { Name = "S&box", Class = "yellow",Img = "./images/Icon/sbox.png", Progress = 40 }
    };


}