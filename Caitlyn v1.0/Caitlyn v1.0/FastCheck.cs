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
            string testPicture = "HeadPictures\\Test" + name;
            string originalPicture = "HeadPictures\\Original" + name;
            MasterOfPictures.MakePicture(bounds, testPicture);
            if (MasterOfPictures.Verify(testPicture, originalPicture)) return true;
            return false;
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
        public bool NoActiveBooster()
        {
            bool x = MainFrame(PointsAndRectangles.noActiveBooster, "Booster");
            return x;
        }        
        public bool NoxRestartMessage()
        {
            bool x = MainFrame(PointsAndRectangles.noxRestartMessage, "NoxRestartMessage");
            return x;
        }
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
        public bool Bounty()
        {
            bool x = MainFrame(PointsAndRectangles.clubBounty, "ClubBounty");
            if (x)
            {
                Thread.Sleep(1000);
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
        public bool ClubMap()
        {
            if(MainFrameBW(PointsAndRectangles.clubMap, "ClubMap", 400))
            {
                return true;
            }
            if (ActiveEvent())
            {
                return true;
            }
            return false;
        }
        public bool RaceOn()
        {
            if (MainFrame(PointsAndRectangles.raceOn, "Race")
                || MainFrame(PointsAndRectangles.raceOn, "Race1")
                || MainFrame(PointsAndRectangles.raceOn, "Race2"))
                return true;
            return false;
        }        
        public bool ItsGarage()
        {
            bool x = MainFrame(PointsAndRectangles.inGarage, "InGarage");
            return x;
        }
        public bool EventEnds()
        {
            if (MainFrame(PointsAndRectangles.eventEnds, "EventEnds"))
            {
                return true;
            }
            if (MainFrame(PointsAndRectangles.eventEnds, "EventEnds1"))
            {
                return true;
            }
            return false;
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
            string active = "Color [A=255, R=4, G=5, B=5]";
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
        public bool EventPage()
        {
            return MainFrame(PointsAndRectangles.EventBounds, "Event");
        }
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