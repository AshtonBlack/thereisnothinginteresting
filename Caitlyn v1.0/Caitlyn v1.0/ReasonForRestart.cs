using System.Drawing;

namespace Caitlyn_v1._0
{
    internal class ReasonForRestart
    {
        Rectangle bounds { get; set; }
        string name { get; set; }
        int errors { get; set; }
        public ReasonForRestart(Rectangle bounds, string name)
        {
            this.bounds = bounds;
            this.name = name;
            errors= 0;
        }
        public ReasonForRestart(Rectangle bounds, string name, int errors)
        {
            this.bounds = bounds;
            this.name = name;
            this.errors = errors;
        }
        public void Check()
        {
            if (errors == 0) { if (VisualCheck.Check(bounds, name)) SpecialEvents.RestartBot(); }
            else if (VisualCheck.Check(bounds, name, errors)) SpecialEvents.RestartBot();            
        }
    }
}
