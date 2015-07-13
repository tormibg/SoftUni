using System;
using System.Threading;

namespace AsyncTimer
{
    public class AsyncTimer
    {
        public AsyncTimer(Action<int> action, int ticks, int interval)
        {
            this.Ticks = ticks;
            this.Interval = interval;
            this.Action = action;
        }

        private int Ticks { get; set; }
        private int Interval { get; set; }
        private Action<int> Action { get; set; }

        public void Execute()
        {
            Thread newThread = new Thread(this.Run);
            newThread.Start();
        }

        private void Run()
        {
            Random rand = new Random();
            for (int i = 0; i < this.Ticks; i++)
            {
                Thread.Sleep(this.Interval);
                if (this.Action != null)
                {
                    this.Action(rand.Next(this.Ticks, this.Interval));
                }
            }
        }

    }
}