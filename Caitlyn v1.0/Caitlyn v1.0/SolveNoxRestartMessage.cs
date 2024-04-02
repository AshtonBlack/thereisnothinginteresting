using System.Diagnostics;
using System.Threading;

namespace Caitlyn_v1._0
{
    internal class SolveNoxRestartMessage: Action
    {
        public override bool SolveTheIssue()
        {
            if (VisualCheck.Check(PointsAndRectangles.noxRestartMessage, "NoxRestartMessage"))
            {
                Rat.Clk(PointsAndRectangles.noxRestartMessageAcceptance);
                Thread.Sleep(1000);
                Rat.Clk(PointsAndRectangles.edgeOfTheScreen);
                Thread.Sleep(2*60*1000);
                //Process.Start(@"C:\Program Files (x86)\Nox\bin\Nox.exe", "-clone:Nox_1");
                Process.Start(@"C:\Program Files (x86)\Nox\bin\Nox.exe");
                return true;
            }
            return false;
        }
    }
}
