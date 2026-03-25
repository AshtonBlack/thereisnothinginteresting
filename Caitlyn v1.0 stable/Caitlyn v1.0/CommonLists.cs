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
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.allrectangles["lostConnection"], "LostConnection"));
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.allrectangles["connectionInterrupted"], "ConnectionInterrupted"));
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.allrectangles["eventisnotavailable"], "EventIsNotAvailable"));
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.allrectangles["timeIsOut"], "TimeIsOut"));
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.allrectangles["carRepair"], "CarRepair"));
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.allrectangles["wrongParty"], "WrongParty"));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["startIcon"], "Icon", PointsAndRectangles.allpoints["clkTheIcon"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["startButton"], "Start", 40, PointsAndRectangles.allpoints["buttonStart"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["headPage"], "Head", PointsAndRectangles.allpoints["toEvents"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["missClick"], "WrongClick", PointsAndRectangles.allpoints["missClickCancelation"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["fbFuckBrain"], "fbFuckBrain", PointsAndRectangles.allpoints["fbFuckBrainClick"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["fbcontinue"], "FBcontinue", PointsAndRectangles.allpoints["fbFucksBrain"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["fbError"], "fbError", PointsAndRectangles.allpoints["fbFuckBrainClick"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["fbError"], "fbError1", PointsAndRectangles.allpoints["fbFuckBrainClick"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["fbError"], "fbError2", PointsAndRectangles.allpoints["fbFuckBrainClick"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["fbError"], "fbError3", PointsAndRectangles.allpoints["fbFuckBrainClick"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["SeasonEndBounty"], "SeasonEndBounty", PointsAndRectangles.allpoints["bountyForSeason"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["SeasonEndsBounds"], "SeasonEnds", PointsAndRectangles.allpoints["acceptSeasonEnd"]));
            //skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["controlScreen"], "ControlScreen", 20, PointsAndRectangles.allpoints["controlScreenToGarage"]));
            //skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["controlScreen"], "BugControlScreen", PointsAndRectangles.allpoints["buttonBack"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["upgrade"], "Upgrade", PointsAndRectangles.allpoints["upgradeCancelation"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["acceptThrow"], "AcceptThrow", PointsAndRectangles.allpoints["acceptanceToThrowRaces"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["wonSet"], "WonSet", PointsAndRectangles.allpoints["endOfRaceSet"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["lostSet"], "LostSet", PointsAndRectangles.allpoints["endOfRaceSet"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["drawSet"], "DrawSet", PointsAndRectangles.allpoints["endOfRaceSet"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["ending"], "PointsForRace", PointsAndRectangles.allpoints["passTheTableAfterRace"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["eventEnds"], "EventEnds", PointsAndRectangles.allpoints["eventEndsAcceptance"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["eventEnds"], "EventEnds1", PointsAndRectangles.allpoints["eventEndsAcceptance"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["eventisFull"], "FullEvent", PointsAndRectangles.allpoints["eventIsFullAcceptance"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["carMenu"], "CarMenu", PointsAndRectangles.allpoints["closeCarCard"]));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.allrectangles["raceEnd"], "RaceEnd", 220, PointsAndRectangles.allpoints["endOfTheFirstRace"]));
            issueSolvations.Add(new SolveServerError());
            issueSolvations.Add(new SolveEventPage());
            issueSolvations.Add(new SolveBounty());
            issueSolvations.Add(new SolveDailyBounty());
            issueSolvations.Add(new SolveNoxRestartMessage());
            issueSolvations.Add(new SolveEnemyIsReady());
            issueSolvations.Add(new SolveDoubleDevice());
            issueSolvations.Add(new SolveSpecialOffer());
            issueSolvations.Add(new SolveControlScreen());
        }
        public static void SkipAllSkipables()
        {
            while(true)
            {
                if(SomethingWasSkipped() == false) break;
            }
        }
        static bool SomethingWasSkipped()
        {
            foreach (ReasonForRestart reasonForRestart in reasonsForRestart)
            {
                reasonForRestart.Check();
            }
            foreach (SkipableMoment skipableMoment in skipableMoments)
            {
                if (skipableMoment.Skip()) return true;
            }
            foreach (Action issueSolvation in issueSolvations)
            {
                if (issueSolvation.SolveTheIssue()) return true;
            }
            return false;
        }
    }
}
