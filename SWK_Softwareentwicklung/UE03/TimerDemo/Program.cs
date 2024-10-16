
void LogTimerExpiration()
{
    Console.WriteLine("Timer elapsed!!!");
}

var timer = new TimerDemo.Timer();

timer.Interval = 500;

timer.Expired = LogTimerExpiration;
timer.Expired = () => Console.WriteLine("Timer (lambda) elapsed");

timer.Start();