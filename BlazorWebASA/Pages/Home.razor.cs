using Microsoft.AspNetCore.Components;

namespace BlazorWebASA.Pages;

public class Home_razor : ComponentBase
{
    public TimeSpan currentTime;

    protected override void OnInitialized()
    {
        currentTime = GetTime();
        new Timer(UpdateTime, null, 0, 1000);
    }
    private void UpdateTime(object state)
    {
        currentTime = GetTime();
        InvokeAsync(StateHasChanged);
    }

    private TimeSpan GetTime()
    {
        DateTime StartTime = new DateTime(2025,3,27,0,0,0);
        DateTime NowTime = DateTime.Now;
        TimeSpan timeSpan = NowTime - StartTime;
        return timeSpan;
    }
}