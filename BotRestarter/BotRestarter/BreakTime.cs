﻿using System;

namespace BotRestarter
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
        public bool isTimeToSortCars()
        {
            if (breakEnd > DateTime.Now.AddHours(3))
            {
                return true;
            }
            return false;
        }
    }
}