using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerDemo
{
    public delegate void ExpiredEventHandler();
    public class Timer
    {

        private const int DEFAULT_INTERVAL = 1000;
        private readonly Thread thread;

        public Timer()
        {
            thread = new Thread(OnTick);
        }

        public int Interval { get; set; } = DEFAULT_INTERVAL;
        
        public ExpiredEventHandler? Expired { get; set; }

        public void Start() => thread.Start();

        private void OnTick()
        {
            while (true) {
                Thread.Sleep(Interval);

                // Console.WriteLine("Timer elapsed!!!");
                Expired?.Invoke();
            }
        }
    }
}
