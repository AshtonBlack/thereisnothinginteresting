using System.Drawing;
using System.Threading;

namespace Caitlyn_v1._0
{
    internal class SkipableMoment
    {
        Rectangle bounds { get; set; }
        string name { get; set; }
        int errors { get; set; }
        Point clkToSkip { get; set; }
        public SkipableMoment(Rectangle bounds, string name, Point clkToSkip)
        {
            this.bounds = bounds;
            this.name = name;
            this.clkToSkip = clkToSkip;
            errors= 0;
        }
        public SkipableMoment(Rectangle bounds, string name, int errors, Point clkToSkip)
        {
            this.bounds = bounds;
            this.name = name;
            this.clkToSkip = clkToSkip;
            this.errors = errors;
        }
        public bool Skip()
        {
            if(errors == 0)
            {
                if (VisualCheck.Check(bounds, name))
                {
                    Rat.Clk(clkToSkip);
                    Thread.Sleep(2000);
                    return true;
                }
            }
            else
            {
                if (VisualCheck.Check(bounds, name, errors))
                {
                    Rat.Clk(clkToSkip);
                    Thread.Sleep(2000);
                    return true;
                }
            } 
            return false;
        }
    }
}