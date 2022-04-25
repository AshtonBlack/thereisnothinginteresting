using System.Drawing;
using System.Threading;

namespace Caitlyn_v1._0
{
    class FastCheck
    {
        SpecialEvents se = new SpecialEvents();

        public bool AnyHandSlotIsEmpty()
        {
            bool x = false;
            if (CheckHandSlot(1, 5) > 0) x = true;
            return x;
        }

        public bool MainFrame(Rectangle bounds, string name)
        {
            bool x = false;
            string testPicture = "HeadPictures\\Test" + name;
            string originalPicture = "HeadPictures\\Original" + name;
            MasterOfPictures.MakePicture(bounds, testPicture);
            if (MasterOfPictures.Verify(testPicture, originalPicture)) x = true;
            return x;
        }

        public bool MainFrameBW(Rectangle bounds, string name, int errors)
        {
            bool x = false;
            string testPicture = "HeadPictures\\Test" + name;
            string originalPicture = "HeadPictures\\Original" + name;
            MasterOfPictures.BW2Capture(bounds, testPicture);
            if (MasterOfPictures.VerifyBW(testPicture, originalPicture, errors)) x = true;
            return x;
        }

        public bool CarMenu()
        {
            bool x = MainFrame(PointsAndRectangles.carMenu, "CarMenu");
            return x;
        }

        public bool CarRepair()
        {
            bool x = MainFrame(PointsAndRectangles.carRepair, "CarRepair");
            return x;
        }

        public int CheckHandSlot(int startslot, int endslot)
        {
            int x = 0;
            Rectangle[] handSlots = { PointsAndRectangles.HandSlot1,
                PointsAndRectangles.HandSlot2,
                PointsAndRectangles.HandSlot3,
                PointsAndRectangles.HandSlot4,
                PointsAndRectangles.HandSlot5 };

            for (int i = (startslot - 1); i < endslot; i++)
            {
                bool y = MainFrame(handSlots[i], "CarSlot" + i);
                if (y)
                {
                    NotePad.DoLog("Тачка на " + (i + 1) + " позиции отсутствует");
                    x++;
                }
            }

            return x;
        }

        public bool EventPage()
        {
            bool x = false;
            string EventPath = "HeadPictures\\TestEvent";
            string EventOriginal = "HeadPictures\\OriginalEvent";
            MasterOfPictures.MakePicture(PointsAndRectangles.EventBounds, EventPath);
            if (MasterOfPictures.Verify(EventPath, EventOriginal)) x = true;
            return x;
        }

        public bool WrongParty()
        {
            bool x = MainFrame(PointsAndRectangles.wrongParty, "WrongParty");
            return x;
        }

        public bool ReadyToRace()
        {
            bool x = MainFrame(PointsAndRectangles.readyToRace, "GarageRaceButton");
            return x;
        }

        public bool StartIcon()
        {
            bool x = MainFrame(PointsAndRectangles.startIcon, "Icon");
            return x;
        }

        public bool StartButton()
        {
            bool x = MainFrame(PointsAndRectangles.startButton, "Start");
            return x;
        }

        public bool HeadPage()
        {
            bool x = MainFrame(PointsAndRectangles.headPage, "Head");
            return x;
        }

        public bool NoActiveBooster()
        {
            bool x = MainFrame(PointsAndRectangles.noActiveBooster, "Booster");
            return x;
        }

        public bool LostConnection()
        {
            bool x = MainFrame(PointsAndRectangles.lostConnection, "LostConnection");
            return x;
        }

        public bool NoxRestartMessage()
        {
            bool x = MainFrame(PointsAndRectangles.noxRestartMessage, "NoxRestartMessage");
            return x;
        }
        /*
        public bool BrokenInterface()
        {
            bool x = MainFrame(PointsAndRectangles.brokenInterface, "BrokenInterface");
            return x;
        }*/

        public bool TypeIsOpenned()
        {
            bool x = MainFrame(PointsAndRectangles.typeIsOpenned, "TypeIsOpenned");
            return x;
        }

        public bool FilterIsOpenned()
        {
            bool x = MainFrame(PointsAndRectangles.filterIsOpenned, "FilterIsOpenned");
            return x;
        }

        public bool MissClick()
        {
            bool x = MainFrame(PointsAndRectangles.missClick, "WrongClick");
            return x;
        }
        /*
        public bool Google()
        {
            bool x = MainFrame(PointsAndRectangles.google, "Google");
            return x;
        }*/

        public bool FBcontinue()
        {
            bool x = MainFrame(PointsAndRectangles.fbcontinue, "FBcontinue");
            return x;
        }

        public bool SeasonEndsBounty()
        {
            bool x = MainFrame(PointsAndRectangles.SeasonEndBounty, "SeasonEndBounty");
            return x;
        }

        public bool SeasonIsEnded()
        {
            bool x = MainFrame(PointsAndRectangles.SeasonEndsBounds, "SeasonEnds");
            return x;
        }

        public bool Bounty()
        {
            bool x = MainFrame(PointsAndRectangles.clubBounty, "ClubBounty");
            if (x)
            {
                if (NoActiveBooster())
                {
                    se.ActivateClubBooster();
                }
                Thread.Sleep(200);
                Rat.Clk(PointsAndRectangles.acceptbounty);
                x = true;
            }
            return x;
        }//принимает награду

        public bool ActiveEvent()
        {
            bool x = MainFrame(PointsAndRectangles.activeEvent, "ButtonToEvent");
            return x;
        }

        public bool ControlScreen()
        {
            bool x = MainFrame(PointsAndRectangles.controlScreen, "ControlScreen");
            return x;
        }

        public bool BugControlScreen()
        {
            bool x = MainFrame(PointsAndRectangles.controlScreen, "BugControlScreen");
            return x;
        }

        public bool ClubMap()
        {
            bool x = MainFrame(PointsAndRectangles.clubMap, "ClubMap");
            return x;
        }

        public bool RaceOn()
        {
            if (MainFrame(PointsAndRectangles.raceOn, "Race") || MainFrame(PointsAndRectangles.raceOn, "Race2"))
                return true;
            return false;
        }

        public bool Ending()
        {
            bool x = MainFrame(PointsAndRectangles.ending, "PointsForRace");
            return x;
        }

        public bool ItsGarage()
        {
            if (StartIcon())
            {
                se.RestartBot();
            } //если свернулась игра
            bool x = MainFrame(PointsAndRectangles.inGarage, "InGarage");
            return x;
        }

        public bool EventEnds()
        {
            bool x = MainFrame(PointsAndRectangles.eventEnds, "EventEnds");
            return x;
        }

        public bool EventIsNotAvailable()
        {
            bool x = MainFrame(PointsAndRectangles.eventisnotavailable, "EventIsNotAvailable");
            return x;
        }

        public bool Upgrade()
        {
            bool x = MainFrame(PointsAndRectangles.upgrade, "Upgrade");
            return x;
        }

        public bool ServerError()
        {
            bool x = false;
            bool x1 = MainFrameBW(PointsAndRectangles.error, "Error", 100);
            bool x2 = MainFrameBW(PointsAndRectangles.error, "Error1", 100);
            bool x3 = MainFrameBW(PointsAndRectangles.error, "Error2", 100);
            bool x4 = MainFrameBW(PointsAndRectangles.error, "Error3", 100);
            if (x1 || x2 || x3 || x4) x = true;
            return x;
        }

        public bool ConditionActivated()
        {
            bool x = false;
            string active = "Color [A=255, R=56, G=56, B=56]";
            Point p = new Point(415, 260);
            if (MasterOfPictures.PixelIndicator(p) == active) x = true;
            return x;
        }

        public bool EventisFull()
        {
            bool x = MainFrame(PointsAndRectangles.eventisFull, "FullEvent");
            return x;
        }

        public bool ArrangementWindow()
        {
            bool x = MainFrame(PointsAndRectangles.arrangementWindow, "Arrangement");
            return x;
        }

        public bool RedReadytoRace()
        {
            bool x = MainFrame(PointsAndRectangles.readyToRace, "RedRaceButton");
            return x;
        }

        public bool EnemyIsReady()
        {
            bool x = MainFrameBW(PointsAndRectangles.chooseanEnemy, "ChooseanEnemy", 90);
            if (x)
            {
                NotePad.DoLog("противник загрузился, готов фотать трассы");
            }
            return x;
        }

        public bool RaceEnd()
        {
            bool x = MainFrameBW(PointsAndRectangles.raceEnd, "RaceEnd", 220);
            if (x)
            {
                NotePad.DoLog("первую трассу проехал, жму пропуск");
            }
            return x;
        }

        public bool AcceptThrow()
        {
            bool x = MainFrame(PointsAndRectangles.acceptThrow, "AcceptThrow");
            return x;
        }

        public bool WonSet()
        {
            bool x = MainFrame(PointsAndRectangles.wonSet, "WonSet");
            return x;
        }

        public bool LostSet()
        {
            bool x = MainFrame(PointsAndRectangles.lostSet, "LostSet");
            return x;
        }

        public bool DrawSet()
        {
            bool x = MainFrame(PointsAndRectangles.drawSet, "DrawSet");
            return x;
        }

        public bool DailyBounty()
        {
            bool x = MainFrame(PointsAndRectangles.dailyBounty, "DailyBounty");
            return x;
        }

        public bool DailyBountyEnd()
        {
            bool x = MainFrame(PointsAndRectangles.dailyBountyEnd, "DailyBountyEnd");
            return x;
        }

        public bool TimeIsOut()
        {
            bool x = MainFrame(PointsAndRectangles.timeIsOut, "TimeIsOut");
            return x;
        }
        /*
        public bool FaultNox()
        {
            bool x = MainFrame(PointsAndRectangles.faultNox, "FaultNox");
            return x;
        }*/

        public bool InCommonEvent()
        {
            bool x = MainFrameBW(PointsAndRectangles.inCommonEvent, "InCommonEvent", 10);
            if (x)
            {
                NotePad.DoLog("Зашел в событие");
            }
            return x;
        }
    }
}
