using Application.Common.Interfaces;

namespace Infrastructure.Hangfire;

public class ScheduledJobService : IScheduledJobService
{
    public ScheduledJobService()
    {
        
    }

    public void ScheduledCalculateSum()
    {
        var sum = 1 + 1;
        Console.WriteLine(sum);
    }
}
