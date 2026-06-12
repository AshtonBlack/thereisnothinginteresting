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
            //CarSorter carsorter = new CarSorter();
            bool itsTimeToPlay;
            do
            {
                itsTimeToPlay = true;
                for (int i = 1; i < timings.Length; i += 2)
                {
                    BreakTime bt = new BreakTime(timings[i], timings[i + 1]);
                    if (bt.isTimeToBreak())
                    {                       
                        itsTimeToPlay = false;
                        if (bt.isTimeToSortCars() && !CarSorter.started)
                        {
                            //carsorter.Sort();
                        }
                        Thread.Sleep(60000);
                        break;
                    }
                }                
            } while (!itsTimeToPlay);  
        }
        public void DefineNewBreakTimes()
        {
            NotePad np = new NotePad();
            DateTime[] times = new DateTime[12];
            times[0] = DateTime.Today;
            times[1] = DateTime.Today.AddHours(1);
            times[2] = DateTime.Today.AddHours(7);
            times[3] = DateTime.Today.AddHours(13);
            times[4] = DateTime.Today.AddHours(15);
            times[5] = DateTime.Today.AddHours(15.5);
            times[6] = DateTime.Today.AddHours(16.5);
            times[7] = DateTime.Today.AddHours(17);
            times[8] = DateTime.Today.AddHours(18.5);
            times[9] = DateTime.Today.AddHours(20);
            times[10] = DateTime.Today.AddHours(22.25);
            times[11] = DateTime.Today.AddHours(25);
            np.WriteTime(times);
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
        public int AdditionalMinutes()
        {
            Random r = new Random();
            int minutes = r.Next(56)-25;
            Thread.Sleep(37);
            return minutes;
        }
    }
}