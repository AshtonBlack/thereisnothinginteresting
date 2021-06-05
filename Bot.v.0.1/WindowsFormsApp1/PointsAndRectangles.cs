﻿using System.Drawing;

namespace WindowsFormsApp1
{
    static class PointsAndRectangles
    {
        public static string[,] allpoints { get; set; }
        public static string[,] allrectangles { get; set; }
        static PointsAndRectangles()
        {
            AllpointsMakeTable();
            AllrectanglesMakeTable();
        }
        public static void AllpointsMakeTable()
        {

        }
        public static void AllrectanglesMakeTable()
        {

        }
        //ChooseEvent
        public static Rectangle Condition1Bounds = new Rectangle(1000, 392, 205, 20);//new
        public static Rectangle Condition2Bounds = new Rectangle(1000, 418, 205, 20);//new
        public static Rectangle RQBounds = new Rectangle(1150, 367, 85, 18);//new
        public static Point clktoClubs = new Point(240, 500);
        public static Point eventN1 = new Point(960, 570);
        public static Point eventN2 = new Point(960, 660);
        public static Point eventN3 = new Point(960, 750);
        public static Point eventN4 = new Point(960, 830);
        public static Point toeventlist = new Point(920, 270);
        //Condition
        public static Point tiresMenu = new Point(200, 635);
        public static Point dynamic = new Point(490, 450);
        public static Point standart = new Point(700, 450);
        public static Point allseason = new Point(910, 450);
        public static Point offroad = new Point(1120, 450);
        public static Point slik = new Point(490, 600);
        public static Point fwd = new Point(700, 600);
        public static Point rwd = new Point(910, 600);
        public static Point awd = new Point(1120, 600);
        //FastCheck
        public static Point acceptbounty = new Point(635, 750);
        public static Rectangle HandSlot1 = new Rectangle(85, 725, 115, 65);//new
        public static Rectangle HandSlot2 = new Rectangle(280, 725, 115, 65);//new
        public static Rectangle HandSlot3 = new Rectangle(475, 725, 115, 65);//new
        public static Rectangle HandSlot4 = new Rectangle(669, 725, 115, 65);//new
        public static Rectangle HandSlot5 = new Rectangle(864, 725, 115, 65);//new
        public static Rectangle carMenu = new Rectangle(1085, 343, 62, 62);//new
        public static Rectangle ClickedWrongADSBounds = new Rectangle(60, 630, 25, 25);
        public static Rectangle EventBounds = new Rectangle(196, 183, 134, 30);//for eventpage//new
        public static Rectangle wrongParty = new Rectangle(838, 617, 150, 26);//new
        public static Rectangle readyToRace = new Rectangle(1084, 796, 95, 20);//new
        public static Rectangle startIcon = new Rectangle(884, 355, 50, 35);//new
        public static Rectangle startButton = new Rectangle(291, 593, 85, 21);//new
        public static Rectangle headPage = new Rectangle(196, 183, 124, 30);//new
        public static Rectangle wrongADS = new Rectangle(63, 193, 25, 25);
        public static Rectangle carIsUpgraded = new Rectangle(576, 707, 128, 27);
        public static Rectangle noActiveBooster = new Rectangle(1033, 658, 43, 19);//new
        public static Rectangle lostConnection = new Rectangle(365, 385, 300, 30);
        public static Rectangle noxRestartMessage = new Rectangle(427, 410, 475, 170);//new
        public static Rectangle brokenInterface = new Rectangle(335, 415, 610, 185);
        public static Rectangle typeIsOpenned = new Rectangle(1092, 247, 25, 20);//new
        public static Rectangle filterIsOpenned = new Rectangle(943, 247, 25, 20);//new
        public static Rectangle missClick = new Rectangle(1147, 227, 20, 20);//new
        public static Rectangle google = new Rectangle(875, 555, 25, 15);
        public static Rectangle fbcontinue = new Rectangle(580, 615, 120, 20);
        public static Rectangle SeasonEndsBounds = new Rectangle(345, 463, 600, 25);//new
        public static Rectangle SeasonEndBounty = new Rectangle(525, 645, 240, 25);//new
        public static Rectangle activeEvent = new Rectangle(1064, 794, 20, 20);//new
        public static Rectangle controlScreen = new Rectangle(796, 793, 85, 25);//new
        public static Rectangle clubMap = new Rectangle(800, 720, 30, 30);//new
        public static Rectangle raceOn = new Rectangle(50, 175, 60, 60);//new
        public static Rectangle ending = new Rectangle(730, 720, 189, 20);//new
        public static Rectangle inGarage = new Rectangle(195, 183, 160, 30); //for itsgarage //new
        public static Rectangle eventEnds = new Rectangle(561, 565, 160, 20);//new
        public static Rectangle upgrade = new Rectangle(427, 247, 135, 30);//new
        public static Rectangle error = new Rectangle(546, 794, 185, 25);
        public static Rectangle eventisFull = new Rectangle(560, 564, 156, 20);
        public static Rectangle arrangementWindow = new Rectangle(75, 515, 5, 5);//new
        public static Rectangle acceptThrow = new Rectangle(895, 615, 35, 25);//new
        public static Rectangle wonSet = new Rectangle(370, 540, 230, 50);//new
        public static Rectangle lostSet = new Rectangle(370, 540, 325, 45);//new
        public static Rectangle drawSet = new Rectangle(370, 540, 195, 45);//new
        public static Rectangle dailyBounty = new Rectangle(78, 195, 290, 30);//new
        public static Rectangle dailyBountyEnd = new Rectangle(564, 763, 160, 20);//new
        public static Rectangle timeIsOut = new Rectangle(565, 580, 155, 20);
        public static Rectangle faultNox = new Rectangle(933, 314, 26, 26);
        public static Rectangle chooseanEnemy = new Rectangle(148, 605, 35, 35);//new
        public static Rectangle raceEnd = new Rectangle(546, 750, 190, 30);//new
        public static Rectangle inCommonEvent = new Rectangle(935, 790, 90, 25);
        public static Rectangle clubBounty = new Rectangle(525, 742, 240, 25);//new
        public static Rectangle carRepair = new Rectangle(208, 447, 870, 55);//new
        public static Rectangle eventisnotavailable = new Rectangle(564, 580, 156, 20);//new
        //GrandArrangement
        public static Point Finger1 = new Point(350, 770);
        public static Point Finger2 = new Point(540, 770);
        public static Point Finger3 = new Point(730, 770);
        public static Point Finger4 = new Point(900, 770);
        public static Point Finger5 = new Point(1100, 770);
        public static Point Track1position = new Point(185, 610);
        public static Point Track2position = new Point(410, 610);
        public static Point Track3position = new Point(635, 610);
        public static Point Track4position = new Point(865, 610);
        public static Point Track5position = new Point(1090, 610);
        //HandMaking        
        public static Rectangle Car1Bounds = new Rectangle(390, 325, 290, 150);
        public static Rectangle Car2Bounds = new Rectangle(390, 530, 290, 150);
        public static Rectangle Car3Bounds = new Rectangle(705, 325, 290, 150);
        public static Rectangle Car4Bounds = new Rectangle(705, 530, 290, 150);
        public static Rectangle Car5Bounds = new Rectangle(670, 325, 290, 150);
        public static Rectangle Car6Bounds = new Rectangle(670, 530, 290, 150);
        public static Rectangle Car7Bounds = new Rectangle(670, 325, 290, 150);
        public static Rectangle Car8Bounds = new Rectangle(670, 530, 290, 150);
        public static Point commonCondition = new Point(640, 265);
        public static Point cond1 = new Point(425, 310);
        public static Point cond2 = new Point(425, 400);
        public static Point commonConditionCross = new Point(845, 260);
        public static Point filter = new Point(945, 265);
        public static Point clear = new Point(525, 785);
        public static Point accept = new Point(940, 785);
        public static Point rarity = new Point(200, 415);
        public static Point f = new Point(490, 450);
        public static Point e = new Point(700, 450);
        public static Point d = new Point(910, 450);
        public static Point c = new Point(1120, 450);
        public static Point b = new Point(490, 600);
        public static Point a = new Point(700, 600);
        public static Point s = new Point(910, 600);
        public static Point xy1 = new Point(180, 430);
        public static Point xy2 = new Point(180, 630);
        public static Point clearall = new Point(240, 795);//сброс
        public static Point sorting = new Point(1090, 265);//сортировка
        public static Point closesorting = new Point(840, 790);//закрыть сортировку
        public static Point r1 = new Point(100, 410);//rarity
        public static Point r2 = new Point(100, 475);//rq
        public static Point r3 = new Point(100, 545);//max speed
        public static Point r4 = new Point(100, 615);//0-60
        public static Point r5 = new Point(430, 410);//handling
        public static Point r6 = new Point(430, 475);//wheels drive
        public static Point r7 = new Point(430, 545);//country
        public static Point r8 = new Point(430, 615);//width
        public static Point r9 = new Point(765, 410);//height
        public static Point r10 = new Point(765, 475);//weight
        public static Point GarageSlot1 = new Point(535, 400);
        public static Point GarageSlot2 = new Point(535, 590);
        public static Point GarageSlot3 = new Point(830, 400);
        public static Point GarageSlot4 = new Point(830, 590);
        public static Point ds1 = new Point(1010, 495);
        public static Point de1 = new Point(665, 495);
        public static Point GarageSlot5 = new Point(750, 400);
        public static Point GarageSlot6 = new Point(750, 590);
        public static Point ds2 = new Point(660, 495);
        public static Point de2 = new Point(330, 495);
        public static Point GarageSlot7 = new Point(750, 400);
        public static Point GarageSlot8 = new Point(750, 590);
        public static Point pHandSlot1 = new Point(170, 770);
        public static Point pHandSlot2 = new Point(350, 770);
        public static Point pHandSlot3 = new Point(540, 770);
        public static Point pHandSlot4 = new Point(730, 770);
        public static Point pHandSlot5 = new Point(910, 770);
        //Navigation
        public static Point clubEventEnter = new Point(1060, 800);
        public static Point startTheRace = new Point(1120, 800);
        public static Point passTheTableAfterRace = new Point(820, 730);
        public static Point backToClubMap = new Point(70, 205);
        //PlayClubsPositions
        public static Point bountyForSeason = new Point(635, 660);
        public static Point eventIsEnd = new Point(640, 590);
        public static Point closeCarCard = new Point(685, 280);
        public static Point controlScreenToGarage = new Point(820, 790);
        public static Point bugwithControlScreen = new Point(70, 205);
        public static Point ChooseAnEnemy = new Point(640, 705);
        public static Point forceTheRace = new Point(180, 580);
        public static Point acceptSeasonEnd = new Point(635, 570);
        //SpecialEvents
        public static Point handSlot1e = new Point(160, 500);
        public static Point handSlot2e = new Point(355, 500);
        public static Point handSlot3e = new Point(545, 500);
        public static Point handSlot4e = new Point(740, 500);
        public static Point handSlot5e = new Point(930, 500);
        public static Point dragMapS = new Point(750, 500);
        public static Point dragMapE = new Point(240, 500);
        public static Point endOfRaceSet = new Point(635, 570);
        public static Point endOfTheFirstEace = new Point(640, 215);
        public static Point acceptanceToThrowRaces = new Point(890, 625);
        public static Point startToWatchADS = new Point(965, 745);
        public static Point itsWrongADS = new Point(75, 205);
        public static Point itsRightADS = new Point(1205, 200);
        public static Point itsClickedWrongADS = new Point(75, 205);
        public static Point upgradeAcceptance = new Point(635, 720);
        public static Point upgradeCancelation = new Point(570, 745);
        public static Point clubBoosterActivation = new Point(1025, 665);
        public static Point clubBoosterAcceptance = new Point(905, 610);
        public static Point noxClosing = new Point(1230, 150);
        public static Point noxClosingAcceptance = new Point(675, 540);//new
        public static Point missClickCancelation = new Point(1145, 240);
        public static Point eventEndsAcceptance = new Point(640, 590);
        public static Point eventIsFullAcceptance = new Point(645, 575);
        public static Point buttonBack = new Point(85, 215);
        public static Point dailyBountyStart = new Point(640, 770);
        public static Point confirmdailyBountyEnd = new Point(630, 770);
        public static Point dailyBountyThrow = new Point(640, 510);
        public static Point toClubs = new Point(240, 500);
        public static Point toEvents = new Point(630, 390);
        public static Point seasonEndAcceptance = new Point(635, 660);
        public static Point buttonStart = new Point(340, 600);
        public static Point noxRestartMessageAcceptance = new Point(820, 560);
        public static Point edgeOfTheScreen = new Point(1200, 0);
        public static Point clkTheIcon = new Point(830, 375);
        public static Point fbFucksBrain = new Point(640, 625);
        public static Point reconnectionAfterLostConnection = new Point(785, 615);
        public static Point brokenInterfaceAcceptance = new Point(380, 555);
        public static Point googleNotificationAcceptance = new Point(890, 565);
        public static Point eventIsNotAvailableAcceptance = new Point(640, 590);//new
        //TrackInfo
        public static Rectangle Track1 = new Rectangle(148, 524, 165, 35);//new
        public static Rectangle Track2 = new Rectangle(353, 524, 165, 35);//new
        public static Rectangle Track3 = new Rectangle(563, 524, 165, 35);//new
        public static Rectangle Track4 = new Rectangle(768, 524, 165, 35);//new
        public static Rectangle Track5 = new Rectangle(973, 524, 165, 35);//new
        public static Rectangle Ground1 = new Rectangle(196, 604, 115, 30);//new
        public static Rectangle Ground2 = new Rectangle(399, 604, 115, 30);//new
        public static Rectangle Ground3 = new Rectangle(613, 604, 115, 30);//new
        public static Rectangle Ground4 = new Rectangle(816, 604, 115, 30);//new
        public static Rectangle Ground5 = new Rectangle(1021, 604, 115, 30);//new
        public static Rectangle Weather1 = new Rectangle(196, 561, 75, 34);//new
        public static Rectangle Weather2 = new Rectangle(399, 561, 75, 34);//new
        public static Rectangle Weather3 = new Rectangle(613, 561, 75, 34);//new
        public static Rectangle Weather4 = new Rectangle(816, 561, 75, 34);//new
        public static Rectangle Weather5 = new Rectangle(1021, 561, 75, 34);//new
    }
}