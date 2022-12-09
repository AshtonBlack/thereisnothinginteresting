using System;

namespace Caitlyn_v1._0
{
    class BreakTime
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