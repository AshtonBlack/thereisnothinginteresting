using System.Drawing;
using System.Threading;

namespace WindowsFormsApp1
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

        public bool CarMenu()
        {
            Rectangle bounds = new Rectangle(1075, 345, 60, 60);
            bool x = MainFrame(bounds, "CarMenu");
            return x;
        }

        public int CheckHandSlot(int startslot, int endslot)
        {
            int x = 0;
            Rectangle HandSlot1 = new Rectangle(85, 725, 115, 65);
            Rectangle HandSlot2 = new Rectangle(277, 725, 115, 65);
            Rectangle HandSlot3 = new Rectangle(469, 725, 115, 65);
            Rectangle HandSlot4 = new Rectangle(661, 725, 115, 65);
            Rectangle HandSlot5 = new Rectangle(853, 725, 115, 65);
            Rectangle[] handSlots = { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };

            string CarSlotPath = "Check\\TestCarSlot";
            string CarSlotOriginal = "Check\\OriginalCarSlot";

            for (int i = (startslot - 1); i < endslot; i++)
            {
                MasterOfPictures.MakePicture(handSlots[i], CarSlotPath + i);
                if (MasterOfPictures.Verify(CarSlotPath + i, CarSlotOriginal + i))
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
            Rectangle ClickedWrongADSBounds = new Rectangle(60, 630, 25, 25);
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
            string EventOriginal1 = "HeadPictures\\OriginalEvent2";
            Rectangle EventBounds = new Rectangle(196, 187, 134, 30);
            MasterOfPictures.MakePicture(EventBounds, EventPath);
            if (MasterOfPictures.Verify(EventPath, EventOriginal)) x = true;
            if (MasterOfPictures.Verify(EventPath, EventOriginal1)) x = true;
            return x;
        }

        public bool WrongParty()
        {
            Rectangle bounds = new Rectangle(830, 615, 150, 30);
            bool x = MainFrame(bounds, "WrongParty");
            return x;
        }

        public bool ReadyToRace()
        {
            Rectangle bounds = new Rectangle(1075, 795, 95, 20);
            bool x = MainFrame(bounds, "GarageRaceButton");
            return x;
        }       

        public bool StartIcon()
        {
            Rectangle bounds = new Rectangle(805, 350, 50, 40);            
            bool x = MainFrame(bounds, "Icon");
            return x;
        }

        public bool StartButton()
        {
            Rectangle bounds = new Rectangle(291, 593, 85, 21);
            bool x = MainFrame(bounds, "Start");
            return x;
        }

        public bool HeadPage()
        {            
            Rectangle bounds = new Rectangle(196, 187, 124, 30);
            bool x = MainFrame(bounds, "Head");
            return x;
        }        

        public bool WrongADS()
        {
            Rectangle bounds = new Rectangle(63, 193, 25, 25);
            bool x = MainFrame(bounds, "WrongADS");
            return x;
        }

        public bool CarIsUpgraded()
        {
            Rectangle bounds = new Rectangle(576, 707, 128, 27);
            bool x = MainFrame(bounds, "CarIsUpgraded");
            return x;
        }

        public bool NoActiveBooster()
        {
            Rectangle bounds = new Rectangle(1023, 657, 43, 19);
            bool x = MainFrame(bounds, "Booster");
            return x;
        }

        public bool LostConnection()
        {
            Rectangle bounds = new Rectangle(365, 385, 300, 30);
            bool x = MainFrame(bounds, "LostConnection");
            return x;
        }

        public bool NoxRestartMessage()
        {
            Rectangle bounds = new Rectangle(405, 405, 475, 180);
            bool x = MainFrame(bounds, "NoxRestartMessage");
            return x;
        }

        public bool BrokenInterface()
        {
            Rectangle bounds = new Rectangle(335, 415, 610, 185);
            bool x = MainFrame(bounds, "BrokenInterface");
            return x;
        }

        public bool NoxPosition()
        {
            Rectangle bounds = new Rectangle(1221, 143, 18, 15);
            bool x = MainFrame(bounds, "NoxPosition");
            return x;
        }

        public void NoxPositionWithRepair()
        {            
            string NoxPositionWithRepairPath = "HeadPictures\\TestNoxPositionWithRepair";
            string NoxPositionWithRepairOriginal = "HeadPictures\\OriginalNoxPositionWithRepair";
            Rectangle NoxPositionWithRepairBounds = new Rectangle(1190, 135, 12, 12);
            MasterOfPictures.MakePicture(NoxPositionWithRepairBounds, NoxPositionWithRepairPath);
            if (MasterOfPictures.Verify(NoxPositionWithRepairPath, NoxPositionWithRepairOriginal))
            {
                se.RepairNoxPosition();
                NotePad.DoErrorLog("fail after ads");
            }
        }

        public bool WrongNoxPosition()
        {
            Rectangle bounds = new Rectangle(880, 20, 15, 15);
            bool x = MainFrame(bounds, "WrongNoxPosition");
            return x;
        }

        public bool TypeIsOpenned()
        {
            Rectangle bounds = new Rectangle(1082, 250, 25, 20);
            bool x = MainFrame(bounds, "TypeIsOpenned");
            return x;
        }

        public bool FilterIsOpenned()
        {
            Rectangle bounds = new Rectangle(935, 250, 25, 20);
            bool x = MainFrame(bounds, "FilterIsOpenned");
            return x;
        }

        public bool MissClick()
        {
            Rectangle bounds = new Rectangle(1136, 231, 20, 20);
            bool x = MainFrame(bounds, "WrongClick");
            return x;
        }

        public bool Google()
        {
            Rectangle bounds = new Rectangle(875, 555, 25, 15);
            bool x = MainFrame(bounds, "Google");
            return x;
        }

        public bool FBcontinue()
        {
            Rectangle bounds = new Rectangle(580, 615, 120, 20);
            bool x = MainFrame(bounds, "FBcontinue");
            return x;
        }

        public bool SeasonEndsBounty()
        {            
            bool x = false;
            string SeasonEndsPath = "HeadPictures\\TestSeasonEnds";
            string SeasonEndsOriginal = "HeadPictures\\OriginalSeasonEnds";
            string SeasonEndsOriginal1 = "HeadPictures\\OriginalSeasonEnds1";
            Rectangle SeasonEndsBounds = new Rectangle(520, 645, 240, 25);
            MasterOfPictures.MakePicture(SeasonEndsBounds, SeasonEndsPath);
            if (MasterOfPictures.Verify(SeasonEndsPath, SeasonEndsOriginal))
            {
                x = true;
            }
            if (MasterOfPictures.Verify(SeasonEndsPath, SeasonEndsOriginal1))
            {
                x = true;
            }
            return x;
        }

        public bool Bounty()
        {
            bool x = false;
            string ClubBounty = "HeadPictures\\TestClubBounty";
            string ClubBountyOriginal = "HeadPictures\\OriginalClubBounty";
            Rectangle ClubBountyBounds = new Rectangle(520, 740, 240, 25);
            MasterOfPictures.MakePicture(ClubBountyBounds, ClubBounty);
            if (MasterOfPictures.Verify(ClubBountyOriginal, ClubBounty))
            {
                if (NoActiveBooster())
                {
                    se.ActivateClubBooster();
                }

                Thread.Sleep(200);
                Rat.Clk(635, 750);
                x = true;
            }
            return x;
        }//принимает награду

        public bool ActiveEvent()
        {
            Rectangle bounds = new Rectangle(1055, 790, 20, 20);
            bool x = MainFrame(bounds, "ButtonToEvent");
            return x;
        }
        
        public bool ControlScreen()
        {
            Rectangle bounds = new Rectangle(790, 790, 85, 25);
            bool x = MainFrame(bounds, "ControlScreen");
            return x;
        }

        public bool BugControlScreen()
        {
            Rectangle bounds = new Rectangle(790, 790, 85, 25);
            bool x = MainFrame(bounds, "BugControlScreen");
            return x;
        }

        public bool ClubMap()
        {
            Rectangle bounds = new Rectangle(800, 720, 30, 30);
            bool x = MainFrame(bounds, "ClubMap");
            return x;
        }

        public bool RaceOn()
        {
            Rectangle bounds = new Rectangle(60, 185, 40, 40);
            bool x = MainFrame(bounds, "Race");
            return x;
        }

        public bool Ending()
        {
            Rectangle bounds = new Rectangle(723, 718, 189, 20);
            bool x = MainFrame(bounds, "PointsForRace");
            return x;
        }

        public bool ItsGarage()
        {
            if (StartIcon())
            {
                se.RestartBot();
            } //если свернулась игра
            bool x = false;
            string InGaragePath = "HeadPictures\\TestInGarage";
            string InGarageOriginal = "HeadPictures\\OriginalInGarage";
            Rectangle InGarageBounds = new Rectangle(200, 190, 90, 30);
            MasterOfPictures.MakePicture(InGarageBounds, InGaragePath);
            if (MasterOfPictures.Verify(InGaragePath, InGarageOriginal))
            {
                x = true;
            }
            return x;
        }

        public bool EventEnds()
        {
            Rectangle bounds = new Rectangle(560, 580, 160, 20);
            bool x = MainFrame(bounds, "EventEnds");
            return x;
        }

        public bool Upgrade()
        {
            Rectangle bounds = new Rectangle(425, 251, 135, 30);
            bool x = MainFrame(bounds, "Upgrade");
            return x;
        }

        public bool ServerError()
        {
            bool x = false;
            string ErrorPath = "HeadPictures\\TestError";
            string ErrorOriginal = "HeadPictures\\OriginalError";
            Rectangle ErrorBounds = new Rectangle(546, 794, 185, 25);
            MasterOfPictures.BW2Capture(ErrorBounds, ErrorPath);
            if (MasterOfPictures.VerifyBW(ErrorPath, ErrorOriginal, 100)) x = true;
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
            Rectangle bounds = new Rectangle(560, 564, 156, 20);
            bool x = MainFrame(bounds, "FullEvent");
            return x;
        }

        public bool RedReadytoRace()
        {
            Rectangle bounds = new Rectangle(1075, 795, 95, 20);
            bool x = MainFrame(bounds, "RedRaceButton");
            return x;
        }

        public bool EnemyIsReady()
        {
            bool x = false;
            string ChooseanEnemyPath = "HeadPictures\\TestChooseanEnemy";
            string ChooseanEnemyOriginal = "HeadPictures\\OriginalChooseanEnemy";
            Rectangle ChooseanEnemyBounds = new Rectangle(154, 605, 35, 35);
            MasterOfPictures.BW2Capture(ChooseanEnemyBounds, ChooseanEnemyPath);
            if (MasterOfPictures.VerifyBW(ChooseanEnemyPath, ChooseanEnemyOriginal, 90))//для начала проверяем на 100 ошибок
            {
                x = true;
                NotePad.DoLog("противник загрузился, готов фотать трассы");
            }
            return x;
        }

        public bool RaceEnd()
        {
            bool x = false;
            string RaceEndPath = "HeadPictures\\TestRaceEnd";
            string RaceEndOriginal = "HeadPictures\\OriginalRaceEnd";
            Rectangle RaceEndBounds = new Rectangle(545, 750, 190, 30);
            MasterOfPictures.BW2Capture(RaceEndBounds, RaceEndPath);
            if (MasterOfPictures.VerifyBW(RaceEndPath, RaceEndOriginal, 220))//для начала проверяем на 100 ошибок
            {
                x = true;
                NotePad.DoLog("первую трассу проехал, жму пропуск");                
            }
            return x;
        }

        public bool AcceptThrow()
        {
            Rectangle bounds = new Rectangle(885, 615, 35, 25);
            bool x = MainFrame(bounds, "AcceptThrow");
            return x;
        }

        public bool WonSet()
        {
            Rectangle bounds = new Rectangle(370, 540, 230, 50);
            bool x = MainFrame(bounds, "WonSet");
            return x;
        }

        public bool LostSet()
        {
            Rectangle bounds = new Rectangle(370, 540, 325, 45);
            bool x = MainFrame(bounds, "LostSet");
            return x;
        }

        public bool DrawSet()
        {
            Rectangle bounds = new Rectangle(370, 540, 195, 45);
            bool x = MainFrame(bounds, "DrawSet");
            return x;
        }

        public bool DailyBounty()
        {
            Rectangle bounds = new Rectangle(80, 200, 290, 30);
            bool x = MainFrame(bounds, "DailyBounty");
            return x;
        }

        public bool DailyBountyEnd()
        {
            Rectangle bounds = new Rectangle(560, 760, 160, 20);
            bool x = MainFrame(bounds, "DailyBountyEnd");
            return x;
        }

        public bool TimeIsOut()
        {
            Rectangle bounds = new Rectangle(565, 580, 155, 20);
            bool x = MainFrame(bounds, "TimeIsOut");
            return x;
        }

        public bool FaultNox()
        {
            Rectangle bounds = new Rectangle(933, 314, 26, 26);
            bool x = MainFrame(bounds, "FaultNox");
            return x;
        }

        public bool CardBug()
        {
            bool x = false;
            string CardBugPath = "HeadPictures\\TestCardBug";
            string CardBugOriginal = "HeadPictures\\OriginalCardBug";
            Rectangle CardBugBounds = new Rectangle(860, 290, 115, 15);
            MasterOfPictures.BW2Capture(CardBugBounds, CardBugPath);
            if (MasterOfPictures.VerifyBW(CardBugPath, CardBugOriginal, 130))
            {
                x = true;
                NotePad.DoLog("Вылезла карта");
            }
            return x;
        }

        public bool InCommonEvent()
        {
            bool x = false;
            string InCommonEventPath = "HeadPictures\\TestInCommonEvent";
            string InCommonEventOriginal = "HeadPictures\\OriginalInCommonEvent";
            Rectangle InCommonEventBounds = new Rectangle(935, 790, 90, 25);
            MasterOfPictures.BW2Capture(InCommonEventBounds, InCommonEventPath);
            if (MasterOfPictures.Verify(InCommonEventPath, InCommonEventOriginal))
            {
                x = true;
                NotePad.DoLog("Зашел в событие");
            }
            return x;
        }
    }
}