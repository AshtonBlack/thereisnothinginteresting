using System.Threading;

namespace Caitlyn_v1._0
{
    internal class SolveBounty: Action
    {
        public override void SolveTheIssue()
        {
            if(VisualCheck.Check(PointsAndRectangles.clubBounty, "ClubBounty"))
            {
                if(VisualCheck.Check(PointsAndRectangles.noActiveBooster, "Booster"))
                {
                    Rat.Clk(PointsAndRectangles.clubBoosterActivation);
                    Thread.Sleep(2000);
                    Rat.Clk(PointsAndRectangles.clubBoosterAcceptance);
                    Thread.Sleep(2000);
                }
                else
                {
                    Rat.Clk(PointsAndRectangles.acceptbounty);
                }
            }
        }
    }
}
