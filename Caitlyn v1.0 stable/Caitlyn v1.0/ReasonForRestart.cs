using System.Drawing;

namespace Caitlyn_v1._0
{
    internal class ReasonForRestart
    {
        Rectangle bounds { get; set; }
        string name { get; set; }
        public ReasonForRestart(Rectangle bounds, string name)
        {
            this.bounds = bounds;
            this.name = name;
        }
        public void Check()
        {
            if (VisualCheck.Check(bounds, name)) SpecialEvents.RestartBot();            
        }
    }
}
