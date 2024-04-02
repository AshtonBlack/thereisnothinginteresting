using System.Threading;

namespace Caitlyn_v1._0
{
    internal class SolveDoubleDevice: Action
    {
        public override bool SolveTheIssue()
        {
            if (VisualCheck.Check(PointsAndRectangles.doubleDevice, "DoubleDevice"))
            {
                NotePad.DoLog("Master is in game");
                Thread.Sleep(20 * 60 * 1000);
                SpecialEvents.RestartBot();
                return true;
            }
            return false;
        }
    }
}
