using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace MazeControl
{
    public class CountdownTimer
    {
        public event EventHandler<int> Started;
        public event EventHandler<int> Tick;
        public event EventHandler Ended;
        public int Seconds { get; set; } = 0;
        private System.Timers.Timer timer = new System.Timers.Timer(1000);
        private int _CurrentCount;
        public string Label { get; set; }

        public CountdownTimer(int Seconds) : this(Seconds, "")
        {

        }

        public CountdownTimer(int Seconds, string Label)
        {
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            this.Seconds = Seconds;
            this._CurrentCount = Seconds;
            this.Label = Label;
        }

        public int CurrentCount
        {
            get
            {
                return _CurrentCount;
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _CurrentCount--;
            Tick?.Invoke(this, _CurrentCount);
            if (_CurrentCount <= 0)
            {
                timer.Stop();
                Ended?.Invoke(this, new EventArgs());
            }
        }

        public void Start()
        {
            Started?.Invoke(this, Seconds);
            timer.Start();
        }

        public async Task RunAsync(CancellationToken ct)
        {
            this._CurrentCount = Seconds;
            Started?.Invoke(this, Seconds);
            timer.Start();
            int Counter = Seconds;
            await Task.Run(async () =>
            {
                while (!ct.IsCancellationRequested && timer.Enabled && Counter > 0)
                {
                    try
                    {
                        await Task.Delay(1000, ct);
                    }
                    catch(Exception ex)
                    {
                        timer.Stop();
                    }
                    Counter--;
                    Tick?.Invoke(this, Counter);
                }
            });
            Ended?.Invoke(this, new EventArgs());
        }
    }
}
