using System.Threading;

namespace Caitlyn_v1._0
{
    internal class SolveDailyBounty: Action
    {
        public override void SolveTheIssue()
        {
            if(VisualCheck.Check(PointsAndRectangles.dailyBounty, "DailyBounty"))
            {
                SpecialEvents se = new SpecialEvents();
                GameState.antiLoopCounter = 0;
                bool bountyisavailable = true;
                do
                {
                    if (GameState.antiLoopCounter > 20) se.RestartBot();
                    if (new SkipableMoment(PointsAndRectangles.dailyBounty, "DailyBounty", PointsAndRectangles.dailyBountyStart).Skip()) Thread.Sleep(15000);
                    if (new SkipableMoment(PointsAndRectangles.dailyBountyEnd, "DailyBountyEnd", PointsAndRectangles.confirmdailyBountyEnd).Skip()) bountyisavailable = false;                    
                    if (bountyisavailable) Rat.Clk(PointsAndRectangles.dailyBountyThrow);
                    GameState.antiLoopCounter++;
                    Thread.Sleep(10000);
                } while (bountyisavailable);          
                se.RestartBot();
            }
        }
    }
}
