using System.Diagnostics;
using System.Drawing;
using System.Threading;

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
            if (VisualCheck.Check(bounds, name, errors)) RestartBot();
        }
        void RestartBot()
        {
            Rat.Clk(PointsAndRectangles.noxClosing);//close Nox
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.noxClosingAcceptance);//accept Nox close
            Thread.Sleep(1000);
            Process.Start(@"C:\Bot\BotRestarter\BotRestarter\bin\Debug\BotRestarter.exe");
            Process.GetCurrentProcess().Kill();
        }
    }
}
