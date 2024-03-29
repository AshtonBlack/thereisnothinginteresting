﻿using System.Collections.Generic;
using System.Threading;

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
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.carRepair, "CarRepair"));
            reasonsForRestart.Add(new ReasonForRestart(PointsAndRectangles.wrongParty, "WrongParty"));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.startIcon, "Icon", PointsAndRectangles.clkTheIcon));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.startButton, "Start", PointsAndRectangles.buttonStart));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.headPage, "Head", PointsAndRectangles.toEvents));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.missClick, "WrongClick", PointsAndRectangles.missClickCancelation));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.fbFuckBrain, "fbFuckBrain", PointsAndRectangles.fbFuckBrainClick));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.fbcontinue, "FBcontinue", PointsAndRectangles.fbFucksBrain));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.SeasonEndBounty, "SeasonEndBounty", PointsAndRectangles.bountyForSeason));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.SeasonEndsBounds, "SeasonEnds", PointsAndRectangles.acceptSeasonEnd));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.controlScreen, "ControlScreen", PointsAndRectangles.controlScreenToGarage));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.controlScreen, "BugControlScreen", PointsAndRectangles.buttonBack));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.upgrade, "Upgrade", PointsAndRectangles.upgradeCancelation));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.acceptThrow, "AcceptThrow", PointsAndRectangles.acceptanceToThrowRaces));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.wonSet, "WonSet", PointsAndRectangles.endOfRaceSet));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.lostSet, "LostSet", PointsAndRectangles.endOfRaceSet));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.drawSet, "DrawSet", PointsAndRectangles.endOfRaceSet));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.ending, "PointsForRace", PointsAndRectangles.passTheTableAfterRace));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.eventEnds, "EventEnds", PointsAndRectangles.eventEndsAcceptance));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.eventEnds, "EventEnds1", PointsAndRectangles.eventEndsAcceptance));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.eventisFull, "FullEvent", PointsAndRectangles.eventIsFullAcceptance));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.carMenu, "CarMenu", PointsAndRectangles.closeCarCard));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.raceEnd, "RaceEnd", 220, PointsAndRectangles.endOfTheFirstRace));
            skipableMoments.Add(new SkipableMoment(PointsAndRectangles.chooseanEnemy, "ChooseanEnemy", 90, PointsAndRectangles.ChooseAnEnemy));
            issueSolvations.Add(new SolveServerError());
            issueSolvations.Add(new SolveEventPage());
            issueSolvations.Add(new SolveBounty());
            issueSolvations.Add(new SolveDailyBounty());
            issueSolvations.Add(new SolveNoxRestartMessage());
            issueSolvations.Add(new SolveEnemyIsReady());
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
            NotePad.DoLog("solving known issues");
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
            Thread.Sleep(1000);
            return false;
        }
    }
}
