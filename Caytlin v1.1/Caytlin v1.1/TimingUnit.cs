using System;

namespace Caytlin_v1._1
{
    internal class TimingUnit
    {
        public DateTime[] timings { get; set; }
        public TimingUnit()
        {
            timings = NotePad.ReadTime();
        }
        public void CheckTime()
        {
            for (int i = 1; i < timings.Length; i += 2)
            {
                BreakTime bt = new BreakTime(timings[i], timings[i + 1]);
                if (bt.isTimeToBreak())
                {
                    NotePad.DoLog("Time is over");
                    SpecialEvents se = new SpecialEvents();
                    se.RestartBot();
                }
            }
        }
    }
}
