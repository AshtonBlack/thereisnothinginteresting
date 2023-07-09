using System.Collections.Generic;

namespace Caitlyn_v1._0
{
    static class CommonLists
    {
        static List<SkipableMoment> skipableMoments = new List<SkipableMoment>();
        static List<ReasonForRestart> reasonsForRestart = new List<ReasonForRestart>();
        static List<Action> issueSolvations = new List<Action>();
        static CommonLists()
        {
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.lostConnection, "LostConnection"));
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.connectionInterrupted, "ConnectionInterrupted"));
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.eventisnotavailable, "EventIsNotAvailable"));
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.timeIsOut, "TimeIsOut"));
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.error, "Error", 100));
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.error, "Error1", 100));
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.error, "Error2", 100));
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.error, "Error3", 100));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.startIcon, "Icon", PointsAndRectangles.clkTheIcon));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.startButton, "Start", PointsAndRectangles.buttonStart));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.headPage, "Head", PointsAndRectangles.toEvents));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.missClick, "WrongClick", PointsAndRectangles.missClickCancelation));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.fbFuckBrain, "fbFuckBrain", PointsAndRectangles.fbFuckBrainClick));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.fbcontinue, "FBcontinue", PointsAndRectangles.fbFucksBrain));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.SeasonEndBounty, "SeasonEndBounty", PointsAndRectangles.bountyForSeason));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.SeasonEndsBounds, "SeasonEnds", PointsAndRectangles.acceptSeasonEnd));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.controlScreen, "ControlScreen", PointsAndRectangles.controlScreenToGarage));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.controlScreen, "BugControlScreen", PointsAndRectangles.backToClubMap));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.upgrade, "Upgrade", PointsAndRectangles.upgradeCancelation));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.acceptThrow, "AcceptThrow", PointsAndRectangles.acceptanceToThrowRaces));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.wonSet, "WonSet", PointsAndRectangles.endOfRaceSet));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.lostSet, "LostSet", PointsAndRectangles.endOfRaceSet));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.drawSet, "DrawSet", PointsAndRectangles.endOfRaceSet));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.ending, "PointsForRace", PointsAndRectangles.passTheTableAfterRace));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.eventEnds, "EventEnds", PointsAndRectangles.eventEndsAcceptance));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.eventEnds, "EventEnds1", PointsAndRectangles.eventEndsAcceptance));
            issueSolvations.Add(new SolveServerError());
            issueSolvations.Add(new SolveEventPage());
            issueSolvations.Add(new SolveBounty());
            issueSolvations.Add(new SolveDailyBounty());
        }
        public static void SkipAllSkipables()
        {
            foreach(ReasonForRestart reason in reasonsForRestart)
            {
                reason.Check();
            }
            foreach(SkipableMoment skipableMoment in skipableMoments)
            {
                skipableMoment.Skip();
            }
            foreach(Action issueSolvation in issueSolvations)
            {
                issueSolvation.SolveTheIssue();
            }
        }
    }
}
