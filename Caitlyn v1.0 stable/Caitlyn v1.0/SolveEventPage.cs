namespace Caitlyn_v1._0
{
    internal class SolveEventPage:Action
    {
        public override bool SolveTheIssue()
        {
            if(VisualCheck.Check(PointsAndRectangles.allrectangles["EventBounds"], "Event"))
            {
                GameState.needToDragMap = true;
                new SkipableMoment(PointsAndRectangles.allrectangles["inCommonEvent"], "InCommonEvent", 10, PointsAndRectangles.allpoints["buttonBack"]).Skip();
                new SkipableMoment(PointsAndRectangles.allrectangles["EventBounds"], "Event", PointsAndRectangles.allpoints["toClubs"]).Skip();
                return true;
            }
            return false;
        }
    }
}
