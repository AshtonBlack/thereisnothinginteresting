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
            lastUpdateTime = DateTime.Now.Date;
            string[] times = new string[8];
            times[0] = DateTime.Today.ToShortDateString();
            times[1] = DateTime.Today.AddHours(5.5).AddMinutes(AdditionalMinutes()).ToString();
            times[2] = DateTime.Today.AddHours(8).AddMinutes(AdditionalMinutes()).ToString();
            times[3] = DateTime.Today.AddHours(12.75).AddMinutes(AdditionalMinutes()).ToString();
            times[4] = DateTime.Today.AddHours(17).AddMinutes(AdditionalMinutes()).ToString();
            times[5] = DateTime.Today.AddHours(18).AddMinutes(AdditionalMinutes()).ToString();
            times[6] = DateTime.Today.AddHours(23.25).AddMinutes(AdditionalMinutes()).ToString();
            times[7] = DateTime.Today.AddHours(26).AddMinutes(AdditionalMinutes()).ToString();
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
        public int AdditionalMinutes()
        {
            Random r = new Random();
            int minutes = r.Next(56)-25;
            Thread.Sleep(37);
            return minutes;
        }
    }
}