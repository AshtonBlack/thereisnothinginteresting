using System.Threading;

namespace Caitlyn_v1._0
{
    internal class SolveDailyBounty: Action
    {
        public override bool SolveTheIssue()
        {
            if(VisualCheck.Check(PointsAndRectangles.allrectangles["dailyBounty"], "DailyBounty"))
            {
                GameState.antiLoopCounter = 0;
                bool bountyisavailable = true;
                do
                {
                    if (GameState.antiLoopCounter > 20) SpecialEvents.RestartBot();
                    if (new SkipableMoment(PointsAndRectangles.allrectangles["dailyBounty"], "DailyBounty", PointsAndRectangles.allpoints["dailyBountyStart"]).Skip()) Thread.Sleep(15000);
                    if (new SkipableMoment(PointsAndRectangles.allrectangles["dailyBountyEnd"], "DailyBountyEnd", PointsAndRectangles.allpoints["confirmdailyBountyEnd"]).Skip()) bountyisavailable = false;                    
                    if (bountyisavailable) Rat.Clk(PointsAndRectangles.allpoints["dailyBountyThrow"]);
                    GameState.antiLoopCounter++;
                    Thread.Sleep(10000);
                } while (bountyisavailable);          
                SpecialEvents.RestartBot();
            }
            return false;
        }
    }
}
