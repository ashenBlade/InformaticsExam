namespace AspNetCoreSampleApp;

public class TimeService: ITimeService
{
    public DateTime GetCurrentTime()
    {
        return DateTime.Now;
    }
}