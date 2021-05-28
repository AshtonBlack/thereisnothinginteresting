using System.Drawing;
using System.Threading;

namespace WindowsFormsApp1 //universal
{
    class FastCheck
    {
        SpecialEvents se = new SpecialEvents();

        Point acceptbounty = new Point(635, 750);

        Rectangle HandSlot1 = new Rectangle(85, 725, 115, 65);//new
        Rectangle HandSlot2 = new Rectangle(280, 725, 115, 65);//new
        Rectangle HandSlot3 = new Rectangle(475, 725, 115, 65);//new
        Rectangle HandSlot4 = new Rectangle(669, 725, 115, 65);//new
        Rectangle HandSlot5 = new Rectangle(864, 725, 115, 65);//new
        Rectangle carMenu = new Rectangle(1085, 343, 62, 62);//new
        Rectangle ClickedWrongADSBounds = new Rectangle(60, 630, 25, 25);
        Rectangle EventBounds = new Rectangle(196, 183, 134, 30);//for eventpage//new
        Rectangle wrongParty = new Rectangle(838, 617, 150, 26);//new
        Rectangle readyToRace = new Rectangle(1084, 796, 95, 20);//new
        Rectangle startIcon = new Rectangle(884, 355, 50, 35);//new
        Rectangle startButton = new Rectangle(291, 593, 85, 21);//new
        Rectangle headPage = new Rectangle(196, 183, 124, 30);//new
        Rectangle wrongADS = new Rectangle(63, 193, 25, 25);
        Rectangle carIsUpgraded = new Rectangle(576, 707, 128, 27);
        Rectangle noActiveBooster = new Rectangle(1023, 657, 43, 19);
        Rectangle lostConnection = new Rectangle(365, 385, 300, 30);
        Rectangle noxRestartMessage = new Rectangle(405, 405, 475, 180);
        Rectangle brokenInterface = new Rectangle(335, 415, 610, 185);
        Rectangle noxPosition = new Rectangle(1221, 143, 18, 15);
        Rectangle noxPositionWithRepair = new Rectangle(1190, 135, 12, 12);
        Rectangle wrongNoxPosition = new Rectangle(880, 20, 15, 15);
        Rectangle typeIsOpenned = new Rectangle(1092, 247, 25, 20);//new
        Rectangle filterIsOpenned = new Rectangle(943, 247, 25, 20);//new
        Rectangle missClick = new Rectangle(1147, 227, 20, 20);//new
        Rectangle google = new Rectangle(875, 555, 25, 15);
        Rectangle fbcontinue = new Rectangle(580, 615, 120, 20);
        Rectangle SeasonEndsBounds = new Rectangle(565, 560, 155, 25);//new
        Rectangle SeasonEndBounty = new Rectangle(525, 645, 240, 25);//new
        Rectangle activeEvent = new Rectangle(1064, 794, 20, 20);//new
        Rectangle controlScreen = new Rectangle(796, 793, 85, 25);//new
        Rectangle clubMap = new Rectangle(800, 720, 30, 30);//new
        Rectangle raceOn = new Rectangle(50, 175, 60, 60);//new
        Rectangle ending = new Rectangle(730, 720, 189, 20);//new
        Rectangle inGarage = new Rectangle(195, 183, 160, 30); //for itsgarage //new
        Rectangle eventEnds = new Rectangle(560, 580, 160, 20);//new
        Rectangle upgrade = new Rectangle(425, 251, 135, 30);
        Rectangle error = new Rectangle(546, 794, 185, 25);
        Rectangle eventisFull = new Rectangle(560, 564, 156, 20);
        Rectangle arrangementWindow = new Rectangle(75, 515, 5, 5);//new
        Rectangle acceptThrow = new Rectangle(895, 615, 35, 25);//new
        Rectangle wonSet = new Rectangle(370, 540, 230, 50);//new
        Rectangle lostSet = new Rectangle(370, 540, 325, 45);//new
        Rectangle drawSet = new Rectangle(370, 540, 195, 45);
        Rectangle dailyBounty = new Rectangle(78, 195, 290, 30);//new
        Rectangle dailyBountyEnd = new Rectangle(564, 763, 160, 20);//new
        Rectangle timeIsOut = new Rectangle(565, 580, 155, 20);
        Rectangle faultNox = new Rectangle(933, 314, 26, 26);
        Rectangle chooseanEnemy = new Rectangle(148, 605, 35, 35);//new
        Rectangle raceEnd = new Rectangle(546, 750, 190, 30);//new
        //Rectangle cardBug = new Rectangle(860, 290, 115, 15);
        Rectangle inCommonEvent = new Rectangle(935, 790, 90, 25);
        Rectangle clubBounty = new Rectangle(525, 742, 240, 25);//new
        Rectangle Galaxy = new Rectangle(1150, 220, 18, 18);
        Rectangle carRepair = new Rectangle(208, 447, 870, 55);//new

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
            bool x = MainFrame(carMenu, "CarMenu");
            return x;
        }

        public bool CarRepair()
        {
            bool x = MainFrame(carRepair, "CarRepair");
            return x;
        }

        public int CheckHandSlot(int startslot, int endslot)
        {
            int x = 0;            
            Rectangle[] handSlots = { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };

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

        public bool ClickedWrongADS()
        {
            bool x = false;
            string ClickedWrongADSPath = "HeadPictures\\TestClickedWrongADS";
            string ClickedWrongADSOriginal = "HeadPictures\\OriginalClickedWrongADS";
            string ClickedWrongADSOriginal1 = "HeadPictures\\OriginalClickedWrongADS1";
            string ClickedWrongADSOriginal2 = "HeadPictures\\OriginalClickedWrongADS2";            
            MasterOfPictures.MakePicture(ClickedWrongADSBounds, ClickedWrongADSPath);
            if (MasterOfPictures.Verify(ClickedWrongADSPath, ClickedWrongADSOriginal)) x = true;
            if (MasterOfPictures.Verify(ClickedWrongADSPath, ClickedWrongADSOriginal1)) x = true;
            if (MasterOfPictures.Verify(ClickedWrongADSPath, ClickedWrongADSOriginal2)) x = true;
            return x;
        }

        public bool EventPage()
        {
            bool x = false;
            string EventPath = "HeadPictures\\TestEvent";
            string EventOriginal = "HeadPictures\\OriginalEvent";           
            MasterOfPictures.MakePicture(EventBounds, EventPath);
            if (MasterOfPictures.Verify(EventPath, EventOriginal)) x = true;
            return x;
        }

        public bool IsGalaxy()
        {
            bool x = MainFrame(Galaxy, "Galaxy");
            return x;
        }

        public bool WrongParty()
        {            
            bool x = MainFrame(wrongParty, "WrongParty");
            return x;
        }

        public bool ReadyToRace()
        {            
            bool x = MainFrame(readyToRace, "GarageRaceButton");
            return x;
        }       

        public bool StartIcon()
        {                       
            bool x = MainFrame(startIcon, "Icon");
            return x;
        }

        public bool StartButton()
        {
            bool x = MainFrame(startButton, "Start");
            return x;
        }

        public bool HeadPage()
        {            
            bool x = MainFrame(headPage, "Head");
            return x;
        }        

        public bool WrongADS()
        {
            bool x = MainFrame(wrongADS, "WrongADS");
            return x;
        }

        public bool CarIsUpgraded()
        {
            bool x = MainFrame(carIsUpgraded, "CarIsUpgraded");
            return x;
        }

        public bool NoActiveBooster()
        {
            bool x = MainFrame(noActiveBooster, "Booster");
            return x;
        }

        public bool LostConnection()
        {
            bool x = MainFrame(lostConnection, "LostConnection");
            return x;
        }

        public bool NoxRestartMessage()
        {
            bool x = MainFrame(noxRestartMessage, "NoxRestartMessage");
            return x;
        }

        public bool BrokenInterface()
        {
            bool x = MainFrame(brokenInterface, "BrokenInterface");
            return x;
        }

        public bool NoxPosition()
        {
            bool x = MainFrame(noxPosition, "NoxPosition");
            return x;
        }

        public void NoxPositionWithRepair()
        {
            bool x = MainFrame(noxPositionWithRepair, "NoxPositionWithRepair");
            if (x)
            {
                se.RepairNoxPosition();
                NotePad.DoErrorLog("fail after ads");
            }
        }

        public bool WrongNoxPosition()
        {
            bool x = MainFrame(wrongNoxPosition, "WrongNoxPosition");
            return x;
        }

        public bool TypeIsOpenned()
        {
            bool x = MainFrame(typeIsOpenned, "TypeIsOpenned");
            return x;
        }

        public bool FilterIsOpenned()
        {
            bool x = MainFrame(filterIsOpenned, "FilterIsOpenned");
            return x;
        }

        public bool MissClick()
        {
            bool x = MainFrame(missClick, "WrongClick");
            return x;
        }

        public bool Google()
        {
            bool x = MainFrame(google, "Google");
            return x;
        }

        public bool FBcontinue()
        {
            bool x = MainFrame(fbcontinue, "FBcontinue");
            return x;
        }

        public bool SeasonEndsBounty()
        {            
            bool x = false;
            string SeasonEndsPath = "HeadPictures\\TestSeasonEnds";
            string SeasonEndsOriginal = "HeadPictures\\OriginalSeasonEnds";
            MasterOfPictures.MakePicture(SeasonEndsBounds, SeasonEndsPath);
            if (MasterOfPictures.Verify(SeasonEndsPath, SeasonEndsOriginal))
            {
                x = true;
            }
            return x;
        }

        public bool Bounty()
        {
            bool x = MainFrame(clubBounty, "ClubBounty");
            if (x)
            {
                if (NoActiveBooster())
                {
                    se.ActivateClubBooster();
                }
                Thread.Sleep(200);
                Rat.Clk(acceptbounty);
                x = true;
            }
            return x;
        }//принимает награду

        public bool ActiveEvent()
        {
            bool x = MainFrame(activeEvent, "ButtonToEvent");
            return x;
        }
        
        public bool ControlScreen()
        {
            bool x = MainFrame(controlScreen, "ControlScreen");
            return x;
        }

        public bool BugControlScreen()
        {
            bool x = MainFrame(controlScreen, "BugControlScreen");
            return x;
        }

        public bool ClubMap()
        {
            bool x = MainFrame(clubMap, "ClubMap");
            return x;
        }

        public bool RaceOn()
        {
            bool x = MainFrame(raceOn, "Race");
            return x;
        }

        public bool Ending()
        {
            bool x = MainFrame(ending, "PointsForRace");
            return x;
        }

        public bool ItsGarage()
        {
            if (StartIcon())
            {
                se.RestartBot();
            } //если свернулась игра
            bool x = MainFrame(inGarage, "InGarage");
            return x;
        }

        public bool EventEnds()
        {
            bool x = MainFrame(eventEnds, "EventEnds");
            return x;
        }

        public bool Upgrade()
        {
            bool x = MainFrame(upgrade, "Upgrade");
            return x;
        }

        public bool ServerError()
        {
            bool x = MainFrameBW(error, "Error", 100);
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
            bool x = MainFrame(eventisFull, "FullEvent");
            return x;
        }

        public bool ArrangementWindow()
        {
            bool x = MainFrame(arrangementWindow, "Arrangement");
            return x;
        }

        public bool RedReadytoRace()
        {
            bool x = MainFrame(readyToRace, "RedRaceButton");
            return x;
        }

        public bool EnemyIsReady()
        {
            bool x = MainFrameBW(chooseanEnemy, "ChooseanEnemy", 90);
            if (x)
            {
                NotePad.DoLog("противник загрузился, готов фотать трассы");
            }
            return x;
        }

        public bool RaceEnd()
        {
            bool x = MainFrameBW(raceEnd, "RaceEnd", 220);
            if (x)
            {
                NotePad.DoLog("первую трассу проехал, жму пропуск");
            }
            return x;
        }

        public bool AcceptThrow()
        {
            bool x = MainFrame(acceptThrow, "AcceptThrow");
            return x;
        }

        public bool WonSet()
        {
            bool x = MainFrame(wonSet, "WonSet");
            return x;
        }

        public bool LostSet()
        {
            bool x = MainFrame(lostSet, "LostSet");
            return x;
        }

        public bool DrawSet()
        {
            bool x = MainFrame(drawSet, "DrawSet");
            return x;
        }

        public bool DailyBounty()
        {
            bool x = MainFrame(dailyBounty, "DailyBounty");
            return x;
        }

        public bool DailyBountyEnd()
        {
            bool x = MainFrame(dailyBountyEnd, "DailyBountyEnd");
            return x;
        }

        public bool TimeIsOut()
        {
            bool x = MainFrame(timeIsOut, "TimeIsOut");
            return x;
        }

        public bool FaultNox()
        {
            bool x = MainFrame(faultNox, "FaultNox");
            return x;
        }
        /*
        public bool CardBug()
        {
            bool x = MainFrameBW(cardBug, "CardBug", 130);
            if (x)
            {
                NotePad.DoLog("Вылезла карта");
            }
            return x;
        }
        */
        public bool InCommonEvent()
        {
            bool x = MainFrameBW(inCommonEvent, "InCommonEvent", 10);
            if (x)
            {
                NotePad.DoLog("Зашел в событие");
            }
            return x;
        }
    }
}