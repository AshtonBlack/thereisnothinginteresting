﻿using System.Drawing;
using System.Threading;

namespace WindowsFormsApp1
{
    class FastCheck
    {
        SpecialEvents se = new SpecialEvents();

        public bool AnyHandSlotIsEmpty()
        {
            bool x = false;
            Rectangle HandSlot1 = new Rectangle(85, 725, 115, 65);
            Rectangle HandSlot2 = new Rectangle(277, 725, 115, 65);
            Rectangle HandSlot3 = new Rectangle(469, 725, 115, 65);
            Rectangle HandSlot4 = new Rectangle(661, 725, 115, 65);
            Rectangle HandSlot5 = new Rectangle(853, 725, 115, 65);
            Rectangle[] handSlots = { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };

            string CarSlotPath = "Check\\TestCarSlot";
            string CarSlotOriginal = "Check\\OriginalCarSlot";

            for(int i = 0; i < 5; i++)
            {
                MasterOfPictures.MakePicture(handSlots[i], CarSlotPath + i);
                if (MasterOfPictures.Verify(CarSlotPath + i, CarSlotOriginal + i))
                {
                    NotePad.DoLog("Тачка на " + i + " позиции отсутствует");
                    x = true;
                }                    
            }
            
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

        public bool EventPage()
        {
            bool x = false;
            string EventPath = "HeadPictures\\TestEvent";
            string EventOriginal = "HeadPictures\\OriginalEvent";
            Rectangle EventBounds = new Rectangle(196, 187, 134, 30);
            MasterOfPictures.MakePicture(EventBounds, EventPath);
            if (MasterOfPictures.Verify(EventPath, EventOriginal)) x = true;
            return x;
        }

        public bool ClickedWrongADS()
        {
            bool x = false;
            string ClickedWrongADSPath = "HeadPictures\\TestClickedWrongADS";
            string ClickedWrongADSOriginal = "HeadPictures\\OriginalClickedWrongADS";
            Rectangle ClickedWrongADSBounds = new Rectangle(60, 630, 25, 25);
            MasterOfPictures.MakePicture(ClickedWrongADSBounds, ClickedWrongADSPath);
            if (MasterOfPictures.Verify(ClickedWrongADSPath, ClickedWrongADSOriginal)) x = true;
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
    }
}