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

        public bool CarMenu()
        {
            bool x = false;
            Rectangle CarMenuPathBounds = new Rectangle(1075, 345, 60, 60);
            string CarMenuPath = "HeadPictures\\TestCarMenu";
            string CarMenuOriginal = "HeadPictures\\OriginalCarMenu";
            MasterOfPictures.MakePicture(CarMenuPathBounds, CarMenuPath);
            if (MasterOfPictures.Verify(CarMenuPath, CarMenuOriginal)) x = true;
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
            bool x = false;
            string WrongPartyPath = "HeadPictures\\TestWrongParty";
            string WrongPartyOriginal = "HeadPictures\\OriginalWrongParty";
            Rectangle WrongPartyBounds = new Rectangle(830, 615, 150, 30);
            MasterOfPictures.MakePicture(WrongPartyBounds, WrongPartyPath);
            if (MasterOfPictures.Verify(WrongPartyPath, WrongPartyOriginal)) x = true;
            return x;
        }

        public bool ReadyToRace()
        {
            bool x = false;
            string GarageRaceButtonPath = "HeadPictures\\TestGarageRaceButton";
            string GarageRaceButtonOriginal = "HeadPictures\\OriginalGarageRaceButton";
            Rectangle GarageRaceButtonBounds = new Rectangle(1075, 795, 95, 20);
            MasterOfPictures.MakePicture(GarageRaceButtonBounds, GarageRaceButtonPath);
            if (MasterOfPictures.Verify(GarageRaceButtonPath, GarageRaceButtonOriginal)) x = true;
            return x;
        }       

        public bool StartIcon()
        {
            bool x = false;
            Rectangle IcBounds = new Rectangle(805, 350, 50, 40);
            string IcPath = "HeadPictures\\TestIcon";
            string IcOriginal = "HeadPictures\\OriginalIcon";
            MasterOfPictures.MakePicture(IcBounds, IcPath);
            if (MasterOfPictures.Verify(IcPath, IcOriginal)) x = true;
            return x;
        }

        public bool StartButton()
        {
            bool x = false;
            string AlcPath = "HeadPictures\\TestStart";
            string AlcOriginal = "HeadPictures\\OriginalStart";
            Rectangle AlcBounds = new Rectangle(291, 593, 85, 21);
            MasterOfPictures.MakePicture(AlcBounds, AlcPath);
            if (MasterOfPictures.Verify(AlcPath, AlcOriginal)) x = true;
            return x;
        }

        public bool HeadPage()
        {
            bool x = false;
            string HeadPath = "HeadPictures\\TestHead";
            string HeadOriginal = "HeadPictures\\OriginalHead";
            Rectangle HeadBounds = new Rectangle(196, 187, 124, 30);
            MasterOfPictures.MakePicture(HeadBounds, HeadPath);
            if (MasterOfPictures.Verify(HeadPath, HeadOriginal)) x = true;
            return x;
        }        

        public bool WrongADS()
        {
            bool x = false;
            string WrongADSPath = "HeadPictures\\TestWrongADS";
            string WrongADSOriginal = "HeadPictures\\OriginalWrongADS";
            Rectangle WrongADSBounds = new Rectangle(63, 193, 25, 25);
            MasterOfPictures.MakePicture(WrongADSBounds, WrongADSPath);
            if (MasterOfPictures.Verify(WrongADSPath, WrongADSOriginal))
            {
                x = true;
            }

            return x;
        }

        public bool CarIsUpgraded()
        {
            bool x = false;
            string CarIsUpgradedPath = "HeadPictures\\TestCarIsUpgraded";
            string CarIsUpgradedOriginal = "HeadPictures\\OriginalCarIsUpgraded";
            Rectangle CarIsUpgradedBounds = new Rectangle(576, 707, 128, 27);
            MasterOfPictures.MakePicture(CarIsUpgradedBounds, CarIsUpgradedPath);
            if (MasterOfPictures.Verify(CarIsUpgradedPath, CarIsUpgradedOriginal))
            {
                x = true;
            }

            return x;
        }

        public bool NoActiveBooster()
        {
            bool x = false;
            string BoosterPath = "HeadPictures\\TestBooster";
            string BoosterOriginal = "HeadPictures\\OriginalBooster";
            Rectangle BoosterBounds = new Rectangle(1023, 657, 43, 19);
            MasterOfPictures.MakePicture(BoosterBounds, BoosterPath);
            if (MasterOfPictures.Verify(BoosterPath, BoosterOriginal))
            {
                x = true;
            }

            return x;
        }

        public bool LostConnection()
        {
            bool x = false;
            string LostConnectionPath = "HeadPictures\\TestLostConnection";
            string LostConnectionOriginal = "HeadPictures\\OriginalLostConnection";
            Rectangle LostConnectionBounds = new Rectangle(365, 385, 300, 30);
            MasterOfPictures.MakePicture(LostConnectionBounds, LostConnectionPath);
            if (MasterOfPictures.Verify(LostConnectionPath, LostConnectionOriginal)) x = true;
            return x;
        }

        public bool NoxRestartMessage()
        {
            bool x = false;
            string NoxRestartMessagePath = "HeadPictures\\TestNoxRestartMessage";
            string NoxRestartMessageOriginal = "HeadPictures\\OriginalNoxRestartMessage";
            Rectangle NoxRestartMessageBounds = new Rectangle(405, 405, 475, 180);
            MasterOfPictures.MakePicture(NoxRestartMessageBounds, NoxRestartMessagePath);
            if (MasterOfPictures.Verify(NoxRestartMessagePath, NoxRestartMessageOriginal))
            {
                x = true;
            }

            return x;
        }

        public bool NoxPosition()
        {
            bool x = false;
            string NoxPositionPath = "HeadPictures\\TestNoxPosition";
            string NoxPositionOriginal = "HeadPictures\\OriginalNoxPosition";
            Rectangle NoxPositionBounds = new Rectangle(1221, 143, 18, 15);
            MasterOfPictures.MakePicture(NoxPositionBounds, NoxPositionPath);
            if (MasterOfPictures.Verify(NoxPositionPath, NoxPositionOriginal))
            {
                x = true;
            }

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
            bool x = false;
            string WrongNoxPositionPath = "HeadPictures\\TestWrongNoxPosition";
            string WrongNoxPositionOriginal = "HeadPictures\\OriginalWrongNoxPosition";
            Rectangle WrongNoxPositionBounds = new Rectangle(880, 20, 15, 15);
            MasterOfPictures.MakePicture(WrongNoxPositionBounds, WrongNoxPositionPath);
            if (MasterOfPictures.Verify(WrongNoxPositionPath, WrongNoxPositionOriginal))
            {
                x = true;
            }

            return x;
        }

        public bool TypeIsOpenned()
        {
            bool x = false;
            string TypeIsOpennedPath = "HeadPictures\\TestTypeIsOpenned";
            string TypeIsOpennedOriginal = "HeadPictures\\OriginalTypeIsOpenned";
            Rectangle TypeIsOpennedBounds = new Rectangle(1082, 250, 25, 20);
            MasterOfPictures.MakePicture(TypeIsOpennedBounds, TypeIsOpennedPath);
            if (MasterOfPictures.Verify(TypeIsOpennedPath, TypeIsOpennedOriginal))
            {
                x = true;
            }

            return x;
        }

        public bool FilterIsOpenned()
        {
            bool x = false;
            string FilterIsOpennedPath = "HeadPictures\\TestFilterIsOpenned";
            string FilterIsOpennedOriginal = "HeadPictures\\OriginalFilterIsOpenned";
            Rectangle FilterIsOpennedBounds = new Rectangle(935, 250, 25, 20);
            MasterOfPictures.MakePicture(FilterIsOpennedBounds, FilterIsOpennedPath);
            if (MasterOfPictures.Verify(FilterIsOpennedPath, FilterIsOpennedOriginal))
            {
                x = true;
            }

            return x;
        }

        public bool MissClick()
        {
            bool x = false;
            string WrongClickPath = "HeadPictures\\TestWrongClick";
            string WrongClickOriginal = "HeadPictures\\OriginalWrongClick";
            Rectangle WrongClickBounds = new Rectangle(1136, 231, 20, 20);
            MasterOfPictures.MakePicture(WrongClickBounds, WrongClickPath);
            if (MasterOfPictures.Verify(WrongClickPath, WrongClickOriginal))
            {
                x = true;
            }

            return x;
        }

        public bool Google()
        {
            bool x = false;
            string GooglePath = "HeadPictures\\TestGoogle";
            string GoogleOriginal = "HeadPictures\\OriginalGoogle";
            Rectangle GoogleBounds = new Rectangle(875, 555, 25, 15);
            MasterOfPictures.MakePicture(GoogleBounds, GooglePath);
            if (MasterOfPictures.Verify(GooglePath, GoogleOriginal))
            {
                x = true;
            }

            return x;
        }

        public bool FBcontinue()
        {
            bool x = false;
            string FBcontinuePath = "HeadPictures\\TestFBcontinue";
            string FBcontinueOriginal = "HeadPictures\\OriginalFBcontinue";
            Rectangle FBcontinueBounds = new Rectangle(580, 615, 120, 20);
            MasterOfPictures.MakePicture(FBcontinueBounds, FBcontinuePath);
            if (MasterOfPictures.Verify(FBcontinuePath, FBcontinueOriginal))
            {
                x = true;
            }

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
            bool x = false;
            string ButtonToEventTest = "HeadPictures\\TestButtonToEvent";
            string ButtonToEventOriginal = "HeadPictures\\OriginalButtonToEvent";
            Rectangle ButtonToEventBounds = new Rectangle(1055, 790, 20, 20);
            MasterOfPictures.MakePicture(ButtonToEventBounds, ButtonToEventTest);
            if (MasterOfPictures.Verify(ButtonToEventOriginal, ButtonToEventTest)) x = true;

            return x;
        }

        public bool EmptyGarageSlot(int n)
        {
            Point GarageSlot1 = new Point(535, 400);
            Point GarageSlot2 = new Point(535, 590);
            Point GarageSlot3 = new Point(830, 400);
            Point GarageSlot4 = new Point(830, 590);
            Point GarageSlot5 = new Point(1130, 400);
            Point GarageSlot6 = new Point(1130, 590);
            /*Point GarageSlot7 = new Point(500, 400);
            Point GarageSlot8 = new Point(500, 590);
            Point GarageSlot9 = new Point(810, 400);
            Point GarageSlot10 = new Point(810, 590);*/
            Point[] a = { GarageSlot1, GarageSlot2, GarageSlot3, GarageSlot4, GarageSlot5, GarageSlot6 };
            bool x = true;

            string[] b = {//с рамками
                "Color [A=255, R=107, G=170, B=205]",//PL11
                "Color [A=255, R=110, G=173, B=208]",//PL11
                "Color [A=255, R=96, G=156, B=188]",//PL11
                "Color [A=255, R=91, G=148, B=176]",//PL11
                "Color [A=255, R=72, G=96, B=107]",
                "Color [A=255, R=74, G=94, B=105]"
            };

            string[] c = {//без рамок
                "Color [A=255, R=72, G=102, B=118]",
                "Color [A=255, R=74, G=103, B=120]",
                "Color [A=255, R=67, G=95, B=110]",
                "Color [A=255, R=65, G=91, B=104]",
                "Color [A=255, R=88, G=154, B=187]",//PL11
                "Color [A=255, R=92, G=150, B=183]"//PL11
            };

            if (MasterOfPictures.PixelIndicator(a[n]) == b[n] || MasterOfPictures.PixelIndicator(a[n]) == c[n])
            {
                x = false;
            }
            return x;
        }

        public bool ControlScreen()
        {
            string ControlScreenPath = "HeadPictures\\TestControlScreen";
            string ControlScreenOriginal = "HeadPictures\\OriginalControlScreen";
            Rectangle ControlScreenBounds = new Rectangle(790, 790, 85, 25);
            bool x = false;
            MasterOfPictures.MakePicture(ControlScreenBounds, ControlScreenPath);
            if (MasterOfPictures.Verify(ControlScreenPath, ControlScreenOriginal)) x = true;
            return x;
        }
        public bool BugControlScreen()
        {
            string BugControlScreenPath = "HeadPictures\\TestBugControlScreen";
            string BugControlScreenOriginal = "HeadPictures\\OriginalBugControlScreen";
            Rectangle BugControlScreenBounds = new Rectangle(790, 790, 85, 25);
            bool x = false;
            MasterOfPictures.MakePicture(BugControlScreenBounds, BugControlScreenPath);
            if (MasterOfPictures.Verify(BugControlScreenPath, BugControlScreenOriginal)) x = true;
            return x;
        }

        public bool ClubMap()
        {
            string ClubMapPath = "HeadPictures\\TestClubMap";
            string ClubMapOriginal = "HeadPictures\\OriginalClubMap";
            Rectangle ClubMapBounds = new Rectangle(800, 720, 30, 30);
            bool x = false;
            MasterOfPictures.MakePicture(ClubMapBounds, ClubMapPath);
            if (MasterOfPictures.Verify(ClubMapPath, ClubMapOriginal))
            {
                NotePad.DoLog("карта клубов");
                x = true;
            }

            return x;
        }

        public bool RaceOn()
        {
            bool x = false;
            string RacePath = "HeadPictures\\TestRace";
            string RaceOriginal = "HeadPictures\\OriginalRace";
            Rectangle RaceBounds = new Rectangle(60, 185, 40, 40);
            MasterOfPictures.MakePicture(RaceBounds, RacePath);
            if (MasterOfPictures.Verify(RacePath, RaceOriginal)) x = true;
            return x;
        }

        public bool Ending()
        {
            bool x = false;
            string PointsForRacePath = "HeadPictures\\TestPointsForRace";
            string PointsForRaceOriginal = "HeadPictures\\OriginalPointsForRace";
            Rectangle PointsForRaceBounds = new Rectangle(723, 718, 189, 20);
            MasterOfPictures.MakePicture(PointsForRaceBounds, PointsForRacePath);
            if (MasterOfPictures.Verify(PointsForRacePath, PointsForRaceOriginal)) x = true;
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
            bool x = false;
            string EventEndsPath = "HeadPictures\\TestEventEnds";
            string EventEndsOriginal = "HeadPictures\\OriginalEventEnds";
            Rectangle EventEndsBounds = new Rectangle(560, 580, 160, 20);
            MasterOfPictures.MakePicture(EventEndsBounds, EventEndsPath);
            if (MasterOfPictures.Verify(EventEndsPath, EventEndsOriginal)) x = true;
            return x;
        }

        public bool Upgrade()
        {
            bool x = false;
            string UpgradePath = "HeadPictures\\TestUpgrade";
            string UpgradeOriginal = "HeadPictures\\OriginalUpgrade";
            Rectangle UpgradeBounds = new Rectangle(425, 251, 135, 30);
            MasterOfPictures.MakePicture(UpgradeBounds, UpgradePath);
            if (MasterOfPictures.Verify(UpgradePath, UpgradeOriginal)) x = true;
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
            bool x = false;
            Rectangle FullEventBounds = new Rectangle(560, 564, 156, 20);
            string FullEventPath = "HeadPictures\\TestFullEvent";
            string FullEventOriginal = "HeadPictures\\OriginalFullEvent";
            MasterOfPictures.MakePicture(FullEventBounds, FullEventPath);//проверка сообщения "эвент заполнен"
            if (MasterOfPictures.Verify(FullEventPath, FullEventOriginal)) x = true;
            return x;
        }

        public bool RedReadytoRace()
        {
            bool x = false;
            string GarageRedRaceButtonPath = "HeadPictures\\TestRedRaceButton";
            string GarageRedRaceButtonOriginal = "HeadPictures\\OriginalRedRaceButton";
            Rectangle GarageRedRaceButtonBounds = new Rectangle(1075, 795, 95, 20);
            MasterOfPictures.MakePicture(GarageRedRaceButtonBounds, GarageRedRaceButtonPath);
            if (MasterOfPictures.Verify(GarageRedRaceButtonPath, GarageRedRaceButtonOriginal)) x = true;
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
            bool x = false;
            string AcceptThrowPath = "HeadPictures\\TestAcceptThrow";
            string AcceptThrowOriginal = "HeadPictures\\OriginalAcceptThrow";
            Rectangle AcceptThrowBounds = new Rectangle(885, 615, 35, 25);
            MasterOfPictures.MakePicture(AcceptThrowBounds, AcceptThrowPath);
            if (MasterOfPictures.Verify(AcceptThrowPath, AcceptThrowOriginal))
            {
                x = true;
                NotePad.DoLog("подтверждаю пропуск");
            }
            return x;
        }

        public bool WonSet()
        {
            bool x = false;
            string WonSetPath = "HeadPictures\\TestWonSet";
            string WonSetOriginal = "HeadPictures\\OriginalWonSet";
            Rectangle WonSetBounds = new Rectangle(370, 540, 230, 50);
            MasterOfPictures.MakePicture(WonSetBounds, WonSetPath);
            if (MasterOfPictures.Verify(WonSetPath, WonSetOriginal))
            {
                x = true;
                NotePad.DoLog("выиграл сет");
            }
            return x;
        }

        public bool LostSet()
        {
            bool x = false;
            string LostSetPath = "HeadPictures\\TestLostSet";
            string LostSetOriginal = "HeadPictures\\OriginalLostSet";
            Rectangle LostSetBounds = new Rectangle(370, 540, 325, 45);
            MasterOfPictures.MakePicture(LostSetBounds, LostSetPath);
            if (MasterOfPictures.Verify(LostSetPath, LostSetOriginal))
            {
                x = true;
                NotePad.DoLog("проиграл сет");
            }
            return x;
        }

        public bool DrawSet()
        {
            bool x = false;
            string DrawSetPath = "HeadPictures\\TestDrawSet";
            string DrawSetOriginal = "HeadPictures\\OriginalDrawSet";
            Rectangle DrawSetBounds = new Rectangle(370, 540, 195, 45);
            MasterOfPictures.MakePicture(DrawSetBounds, DrawSetPath);
            if (MasterOfPictures.Verify(DrawSetPath, DrawSetOriginal))
            {
                x = true;
                NotePad.DoLog("ничья");
            }
            return x;
        }

        public bool DailyBounty()
        {
            bool x = false;
            string DailyBountyPath = "HeadPictures\\TestDailyBounty";
            string DailyBountyOriginal = "HeadPictures\\OriginalDailyBounty";
            Rectangle DailyBountyBounds = new Rectangle(80, 200, 290, 30);
            MasterOfPictures.MakePicture(DailyBountyBounds, DailyBountyPath);
            if (MasterOfPictures.Verify(DailyBountyPath, DailyBountyOriginal))
            {
                x = true;
                NotePad.DoLog("Ежедневная награда");//640 770
            }
            return x;
        }

        public bool DailyBountyEnd()
        {
            bool x = false;
            string DailyBountyEndPath = "HeadPictures\\TestDailyBountyEnd";
            string DailyBountyEndOriginal = "HeadPictures\\OriginalDailyBountyEnd";
            Rectangle DailyBountyEndBounds = new Rectangle(560, 760, 160, 20);
            MasterOfPictures.MakePicture(DailyBountyEndBounds, DailyBountyEndPath);
            if (MasterOfPictures.Verify(DailyBountyEndPath, DailyBountyEndOriginal))
            {
                x = true;//640 510
                NotePad.DoLog("Ежедневная награда");//630 770
            }
            return x;
        }

        public bool TimeIsOut()
        {
            bool x = false;
            string TimeIsOutPath = "HeadPictures\\TestTimeIsOut";
            string TimeIsOutOriginal = "HeadPictures\\OriginalTimeIsOut";
            Rectangle TimeIsOutBounds = new Rectangle(565, 580, 155, 20);
            MasterOfPictures.MakePicture(TimeIsOutBounds, TimeIsOutPath);
            if (MasterOfPictures.Verify(TimeIsOutPath, TimeIsOutOriginal))
            {
                x = true;
                NotePad.DoLog("Disconnected");
            }
            return x;
        }

        public bool FaultNox()
        {
            bool x = false;
            string FaultNoxPath = "HeadPictures\\TestFaultNox";
            string FaultNoxOriginal = "HeadPictures\\OriginalFaultNox";
            Rectangle FaultNoxBounds = new Rectangle(933, 314, 26, 26);
            MasterOfPictures.MakePicture(FaultNoxBounds, FaultNoxPath);
            if (MasterOfPictures.Verify(FaultNoxPath, FaultNoxOriginal))
            {
                x = true;
                NotePad.DoLog("Свернулась игра");
            }
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