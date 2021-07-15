using System;
using System.Threading;

namespace BotRestarter
{
    class TimingUnit
    {
        public DateTime[] timings { get; set; }
        DateTime lastUpdateTime { get; set; }
        public TimingUnit()
        {
            NotePad np = new NotePad();
            timings = np.ReadTime();
            lastUpdateTime = timings[0];
            if (!IsUpDated()) DefineNewBreakTimes();
        }
        public void WaitForAvailableTime()
        {
            bool itsTimeToPlay = true;
            do
            {
                for (int i = 1; i < timings.Length; i += 2)
                {
                    BreakTime bt = new BreakTime(timings[i], timings[i + 1]);
                    if (bt.isTimeToBreak())
                    {                       
                        itsTimeToPlay = false;
                        break;
                    }
                }
                Thread.Sleep(60000);
            } while (!itsTimeToPlay);  
        }
        public void DefineNewBreakTimes()
        {
            NotePad np = new NotePad();
            lastUpdateTime = DateTime.Now.Date;
            string[] times = new string[6];
            times[0] = DateTime.Today.ToShortDateString();
            times[1] = DateTime.Today.ToShortDateString() + " 01:00:00";
            times[2] = DateTime.Today.ToShortDateString() + " 08:00:00";
            times[3] = DateTime.Today.ToShortDateString() + " 13:00:00";
            times[4] = DateTime.Today.ToShortDateString() + " 16:00:00";
            times[5] = DateTime.Today.ToShortDateString() + " 19:00:00";
            times[6] = DateTime.Today.ToShortDateString() + " 23:00:00";
            times[7] = DateTime.Today.AddDays(1).ToShortDateString() + " 01:00:00";
            timings[0] = lastUpdateTime;
            for(int i = 1; i < timings.Length; i++)
            {
                timings[i] = Convert.ToDateTime(times[i - 1]);
            }
            np.WriteTime(timings);
        }
        public bool IsUpDated()
        {
            bool isUpDated = false;
            if (lastUpdateTime.AddHours(24) > DateTime.Now)
            {
                isUpDated = true;
            }
            return isUpDated;
        }
    }
}