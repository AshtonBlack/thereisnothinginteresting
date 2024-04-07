using System.Threading;

namespace Caitlyn_v1._0
{
    internal class SolveBounty: Action
    {
        public override bool SolveTheIssue()
        {
            if(VisualCheck.Check(PointsAndRectangles.allrectangles["clubBounty"], "ClubBounty"))
            {
                if(VisualCheck.Check(PointsAndRectangles.allrectangles["noActiveBooster"], "Booster"))
                {
                    Rat.Clk(PointsAndRectangles.allpoints["clubBoosterActivation"]);
                    Thread.Sleep(2000);
                    Rat.Clk(PointsAndRectangles.allpoints["clubBoosterAcceptance"]);
                    Thread.Sleep(2000);
                }
                Rat.Clk(PointsAndRectangles.allpoints["acceptbounty"]);
                return true;
            }
            return false;
        }
    }
}
