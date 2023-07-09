namespace Caitlyn_v1._0
{
    internal class SolveEventPage:Action
    {
        public override void SolveTheIssue()
        {
            if(VisualCheck.Check(PointsAndRectangles.EventBounds, "Event"))
            {
                GameState.needToDragMap = true;
                new SkipableMoment(PointsAndRectangles.inCommonEvent, "InCommonEvent", 10, PointsAndRectangles.buttonBack).Skip();
                new SkipableMoment(PointsAndRectangles.EventBounds, "Event", PointsAndRectangles.toClubs).Skip();
            }
        }
    }
}
