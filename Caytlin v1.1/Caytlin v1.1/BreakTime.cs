using System;

namespace Caytlin_v1._1
{
    internal class BreakTime
    {
        public DateTime breakStart;
        public DateTime breakEnd;
        public BreakTime(DateTime breakStart, DateTime brakeEnd)
        {
            this.breakStart = breakStart;
            this.breakEnd = brakeEnd;
        }
        public bool isTimeToBreak()
        {
            if (breakStart < DateTime.Now && breakEnd > DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }
}
