using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MazeControl
{
    public class MazeDataPoint
    {
        private DateTime StartTime = DateTime.Now;
        private DateTime EndTime;
        public int Session { get; set; } = -1;
        public int Trial { get; set; } = -1;
        public string State { get; set; } = "";
        public int SensorCount { get; set; } = 0;
        public string ExitAction { get; set; } = "";
        private bool InProgress = true;
        //private Timer UpdateTimer = new Timer(250);

        public double Duration
        {
            get
            {
                TimeSpan RetVal = TimeSpan.FromSeconds(0);
                if (!InProgress)
                {
                    RetVal = EndTime - StartTime;
                }
                //else
                //{
                //    RetVal = DateTime.Now - StartTime;
                //}
                return Math.Round(RetVal.TotalSeconds, 2);
            }
        }

        public MazeDataPoint(string State)
        {
            this.State = State;
            StartTime = DateTime.Now;
            //UpdateTimer.Elapsed += UpdateTimer_Elapsed;
            //UpdateTimer.Start();
        }

        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Update();
        }

        public void Update()
        {
            EndTime = DateTime.Now;
        }

        public void Stop()
        {
            //UpdateTimer.Stop();
            InProgress = false;
            Update();
        }

        public static List<string> GetFields()
        {
            List<string> RetVal = new List<string>()
            {
                "Session",
                "Trial",
                "State",
                "SensorCount",
                "ExitAction",
                "Duration"
            };
            return RetVal;
        }
        public override string ToString()
        {
            List<string> Fields = new List<string>();
            Fields.Add(Session.ToString());
            Fields.Add(Trial.ToString());
            Fields.Add(State);
            Fields.Add(SensorCount.ToString());
            Fields.Add(ExitAction);
            Fields.Add(Duration.ToString());
            return string.Join(",", Fields);
        }

    }
}
