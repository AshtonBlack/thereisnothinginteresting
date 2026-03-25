using System.Threading;

namespace Caitlyn_v1._0
{
    internal class SolveServerError : Action
    {
        public override bool SolveTheIssue()
        {
            if (IsError())
            {
                Thread.Sleep(4000);
                if(IsError()) SpecialEvents.RestartBot();
            }
            return false;
        }
        bool IsError()
        {
            if (VisualCheck.Check(PointsAndRectangles.allrectangles["error"], "Error", 100)) return true;
            if (VisualCheck.Check(PointsAndRectangles.allrectangles["error"], "Error1", 100)) return true;
            if (VisualCheck.Check(PointsAndRectangles.allrectangles["error"], "Error2", 100)) return true;
            if (VisualCheck.Check(PointsAndRectangles.allrectangles["error"], "Error3", 100)) return true;
            return false;
        }
    }
}
