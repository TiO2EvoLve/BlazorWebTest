using Microsoft.AspNetCore.Components;

namespace BlazorWebASA.Pages;

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
}