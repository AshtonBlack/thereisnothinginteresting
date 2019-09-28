using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Bot.v._0._04
{
    public partial class Form1 : Form
    {        
        private Bitmap captured; //создаем объект Bitmap (растровое изображение), будет нужен как при самом получении изображения, так и при сохранении изображения

        public Form1()
        {            
            InitializeComponent();
            
            Opacity = 0;
        }
        
        private void Form1_Load_1(object sender, EventArgs err)
        {
            this.Location = new Point(0, 0); //локация формы(невидимая)
            Thread.Sleep(500);
            Clk(1165, 20); //Свернуть VS
            Thread.Sleep(1000);
            //UniversalCapture(Conditions1Bounds, Conditions1);
            //UniversalCapture(Conditions2Bounds, Conditions2);
            //BW2Capture(ErrorBounds, ErrorOriginal);            
            //Console.WriteLine(PixelIndicator(GarageSlot1));
            //Verify("Finger1\\3", "Finger1\\4");                    
            //UniversalCapture(FullEventBounds, FullEventOriginal);
            //ReadFile();

            //DeleteThis();

            Loading(); 

            //BranchCampaing();

            BranchClubs();  

            Thread.Sleep(500);
            Application.Exit();            
        }
        
        [DllImport("User32.dll")]
        public static extern void mouse_event(int dsFlag, int x, int y, int cButton, int dsExtraInfo);
        
        public const int MOUSEEVENTF_LEFTDOWN = 0X02;
        public const int MOUSEEVENTF_LEFTUP = 0X04;
        public const int MOUSEEVENTF_RIGHTDOWN = 0X08;
        public const int MOUSEEVENTF_RIGHTUP = 0X10;

        public Rectangle FullEventBounds = new Rectangle(565, 560, 150, 20);
        public Rectangle GoldRewardBounds = new Rectangle(725, 487, 30, 35);
        public Rectangle InGarageBounds = new Rectangle(80, 260, 18, 18);
        public Rectangle ErrorBounds = new Rectangle(550, 785, 16, 17);
        public Rectangle ButtonToEventBounds = new Rectangle(1045, 785, 12, 13);
        public Rectangle MapBounds = new Rectangle(800, 710, 25, 25);
        public Rectangle EventNameBounds = new Rectangle(960, 295, 240, 20);
        public Rectangle AdsWOWBounds = new Rectangle(1190, 183, 30, 30);
        public Rectangle AdsREBounds = new Rectangle(1138, 235, 30, 30);
        public Rectangle AdsNutrilakBounds = new Rectangle(1190, 195, 20, 20);
        public Rectangle WrongClickBounds = new Rectangle(1120, 240, 20, 20);
        public Rectangle Ground1Bounds = new Rectangle(140, 495, 145, 35);
        public Rectangle Ground2Bounds = new Rectangle(365, 495, 145, 35);
        public Rectangle Ground3Bounds = new Rectangle(595, 495, 145, 35);
        public Rectangle Ground4Bounds = new Rectangle(825, 495, 145, 35);
        public Rectangle Ground5Bounds = new Rectangle(1050, 495, 145, 35);
        public Rectangle AdsWMBounds = new Rectangle(1135, 230, 35, 35);
        public Rectangle ControlScreenBounds = new Rectangle(785, 785, 80, 15);
        public Rectangle PointsForRaceBounds = new Rectangle(720, 710, 180, 22);
        public Rectangle ChooseanEnemyBounds = new Rectangle(178, 600, 15, 30);
        public Rectangle UnloadedClubsBounds = new Rectangle(900, 540, 100, 100);        
        public Rectangle ADSBounds = new Rectangle(220, 770, 15, 30);
        public Rectangle EventEndMessageBounds = new Rectangle(567, 578, 145, 20);
        public Rectangle GarageRaceButtonBounds = new Rectangle(1060, 785, 90, 20);
        public Rectangle ArrangementBounds = new Rectangle(140, 495, 5, 5);
        public Rectangle RaceBounds = new Rectangle(75, 200, 10, 10);
        public Rectangle RQBounds = new Rectangle(1124, 374, 77, 16);
        public Rectangle Conditions1Bounds = new Rectangle(1000, 395, 180, 25);
        public Rectangle Conditions2Bounds = new Rectangle(1000, 420, 180, 25);
        public Rectangle ClubBountyBounds = new Rectangle(523, 732, 232, 20);
        public Rectangle CampaingBounds = new Rectangle(213, 198, 15, 25);
        public Rectangle MonacoBounds = new Rectangle(213, 198, 15, 25);
        public Rectangle RacingBounds = new Rectangle(707, 234, 2, 2);
        public Rectangle EventsBounds = new Rectangle(213, 198, 15, 25);
        public Rectangle HeadBounds = new Rectangle(213, 198, 15, 25);
        public Rectangle AlcBounds = new Rectangle(300, 620, 87, 25);
        public Rectangle AcBounds = new Rectangle(436, 257, 20, 20);
        public Rectangle IcBounds = new Rectangle(211, 454, 58, 40);
        public Rectangle ClubBounds = new Rectangle(910, 260, 12, 12);

        public string FullEventPath = "TestFullEvent";
        public string FullEventOriginal = "OriginalFullEvent";
        public string GoldRewardPath = "TestGoldReward";
        public string GoldRewardOriginal = "OriginalGoldReward";
        public string InGaragePath = "TestInGarage";
        public string InGarageOriginal = "OriginalInGarage";
        public string ErrorPath = "TestError";
        public string ErrorOriginal = "OriginalError";
        public string ButtonToEventPath = "TestButtonToEvent";
        public string ButtonToEventOriginal = "OriginalButtonToEvent";
        public string MapPath = "TestMap";
        public string MapOriginal = "OriginalMap";
        public string EventNamePath = "TestEventName";
        public string EventName = "Coverage\\";
        public string AdsREOriginal = "OriginalAdsRE";
        public string AdsREPath = "TestAdsRE";
        public string AdsWOWOriginal = "OriginalAdsWOW";
        public string AdsWOWPath = "TestAdsWOW";
        public string AdsNutrilakOriginal = "OriginalAdsNutrilak";
        public string AdsNutrilakPath = "TestAdsNutrilak";
        public string AdsWMOriginal = "OriginalAdsWM";
        public string AdsWMPath = "TestAdsWM";
        public string WrongClickPath = "TestWrongClick";        
        public string WrongClickOriginal = "OriginalWrongClick";
        public string Ground1Path = "Ground1\\";
        public string Ground2Path = "Ground2\\";
        public string Ground3Path = "Ground3\\";
        public string Ground4Path = "Ground4\\";
        public string Ground5Path = "Ground5\\";
        public string ControlScreenPath = "TestControlScreen";
        public string ControlScreenOriginal = "OriginalControlScreen";
        public string PointsForRacePath = "TestPointsForRace";
        public string PointsForRaceOriginal = "OriginalPointsForRace";
        public string ChooseanEnemyPath = "TestChooseanEnemy";
        public string ChooseanEnemyOriginal = "OriginalChooseanEnemy";
        public string UnloadedClubsPath = "TestUnloadedClubs";
        public string UnloadedClubsOriginal = "OriginalUnloadedClubs";
        public string EventEndMessagePath = "TestEventEndMessage";
        public string EventEndMessageOriginal = "OriginalEventEndMessage";
        public string ArrangementPath = "TestArrangement";
        public string ArrangementOriginal = "OriginalArrangement";
        public string GarageRaceButtonPath = "TestGarageRaceButton";
        public string GarageRaceButtonOriginal = "OriginalGarageRaceButton";
        public string RacePath = "TestRace";
        public string RaceOriginal = "OriginalRace";
        public string ADSPath = "TestADS";
        public string ADSOriginal = "OriginalADS";
        public string Conditions1Path = "TestConditions1";
        public string Dump1Path = "Dump\\1Unsorted";
        public string Conditions2Path = "TestConditions2";
        public string Dump2Path = "Dump\\2Unsorted";
        public int c = 52;
        public string Conditions1 = "C18";
        public string Conditions2 = "CC5";
        public string RQPath = "TestRQ";
        public string RQ = "140";        
        public string ClubBountyPath = "TestClubBounty";
        public string ClubBountyOriginal = "OriginalClubBounty";
        public string CampaingPath = "TestCampaing";
        public string CampaingOriginal = "OriginalCampaing";
        public string MonacoPath = "TestMonaco";
        public string MonacoOriginal = "OriginalMonaco";
        public string RacingPath = "TestRacing";
        public string RacingOriginal = "OriginalRacing";
        public string HeadPath = "TestHead";
        public string HeadOriginal = "OriginalHead";
        public string EventsPath = "TestEvents";
        public string EventsOriginal = "OriginalEvents";
        public string AlcPath = "TestStart";
        public string AcOriginal = "OriginalAc";
        public string AcOriginal1 = "OriginalAc1";
        public string AcPath = "TestAc";
        public string AlcOriginal = "OriginalStart";
        public string IcPath = "TestIcon";
        public string IcOriginal = "OriginalIcon";
        public string ClubPath = "TestClub";
        public string ClubOriginal = "OriginalClub";

        private void Loading()
        {
            ClearLog();
            Process.Start("C:\\Program Files\\Microvirt\\MEmu\\MEmu.exe");
            //Process.Start("C:\\Program Files (x86)\\Microvirt\\MEmu\\MEmu.exe");//Pc2
            Thread.Sleep(10000);

            do
            {
                UniversalCapture(IcBounds, IcPath);
                Thread.Sleep(2000);
            } while (!Verify(IcPath, IcOriginal));

            Clk(240, 470);//Icon

            Thread.Sleep(10000);

            do
            {
                UniversalCapture(AlcBounds, AlcPath);
                Thread.Sleep(2000);
            } while (!Verify(AlcPath, AlcOriginal));

            Clk(340, 630);//Start game

            Thread.Sleep(3000);

            int n = 1;
            UniversalCapture(ADSBounds, ADSPath);
            if (!Verify(ADSPath, ADSOriginal))
            {                
                while (n < 5)
                {
                    if (n == 1)
                    {
                        Clk(285, 790);
                        Thread.Sleep(500);
                        do
                        {
                            UniversalCapture(GoldRewardBounds, GoldRewardPath);
                            Thread.Sleep(2000);
                        } while (!Verify(GoldRewardPath, GoldRewardOriginal));
                        Clk(650, 500);
                        Thread.Sleep(7000);
                    }
                    else
                    {
                        Clk(285, 790);
                        Thread.Sleep(60000);
                        AdsKiller();
                        do
                        {
                            UniversalCapture(GoldRewardBounds, GoldRewardPath);
                            Thread.Sleep(2000);
                        } while (!Verify(GoldRewardPath, GoldRewardOriginal));
                        Clk(650, 500);
                        Thread.Sleep(7000);
                    }

                    n++;
                }

                if(n == 5)//после просмотра рекламы перезапуск
                {

                    Clk(1211, 164);//close memu
                    Thread.Sleep(1000);
                    Clk(598, 511);// accept memu close
                    Thread.Sleep(1000);
                    Clk(20, 1000);//start
                    Thread.Sleep(1000);
                    Clk(20, 960);//off
                    Thread.Sleep(3000);
                    Clk(40, 910);//reloading
                    Thread.Sleep(1000);
                    Clk(40, 910);//reloading
                    Application.Exit();
                }
                
            }

        }

        private void BranchClubs()
        {
            DoLog("Кликаю на события");
            Clk(640, 400);
                        
            do
            {
                ClubBountyCheck();
                UniversalCapture(EventsBounds, EventsPath);
                Thread.Sleep(1000);
            } while (!Verify(EventsPath, EventsOriginal));
            
            DoLog("Кликаю на клубы");
            Clk(250, 500);//Clubs
            Thread.Sleep(15000);

            DoLog("Ожидаю загрузки");
            Thread.Sleep(10000);
            ClubBountyCheck();

            DoLog("Сдвиг карты");
            MoveMouse(750, 500);
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_LEFTDOWN, 750, 500, 0, 0);
            Thread.Sleep(2000);
            for (int drag = 750; drag > 300; drag -= 8)
            {
                MoveMouse(drag, 500);
                Thread.Sleep(60);
            }
            Thread.Sleep(1000);
            MoveMouse(240, 500);
            Thread.Sleep(2000);
            mouse_event(MOUSEEVENTF_LEFTUP, 240, 500, 0, 0);
            Thread.Sleep(1000);

            while (true)
            {                                  
                Thread.Sleep(2000);
                int i = 0;                
                UniversalCapture(ButtonToEventBounds, ButtonToEventPath);
                if(Verify(ButtonToEventPath, ButtonToEventOriginal))
                {
                    DoLog("вхожу в активный эвент");
                    i = 1;
                    Clk(1050, 790);
                    int[] a = ReadSaves();
                    int[] b = new int[5];
                    Array.Copy(a, 3, b, 0, 5);
                    while (i < 50)
                    {
                        i++;                        
                        if (!PlayClubs(a[0], a[1], a[2], b, i)) break;
                    }
                }

                else
                {
                    DoLog("Подбираю эвент с одним условием");
                    int condition = ChooseNormalEvent();

                    DoLog("Вычисляю РК эвента");
                    int rq = GotRQ();

                    int tires = WhichEvent();

                    DoLog("Вхожу в эвент  " + rq + " рк");
                    Clk(1050, 790);//ClubEventEnter   

                    while (i < 50)
                    {
                        int[] b = { 0, 0, 0, 0, 0 };
                        i++;
                        if (!PlayClubs(rq, condition, tires, b, i)) break;
                    }
                }
                
                Thread.Sleep(2000);
            }
            
        }

        private void BranchCampaing()
        {
            Clk(270, 500);//Campaing

            Thread.Sleep(1000);

            do
            {
                Thread.Sleep(2000);
                UniversalCapture(CampaingBounds, CampaingPath);
            } while (!Verify(CampaingPath, CampaingOriginal));

            Clk(1050, 500);//Monaco

            Thread.Sleep(1000);
                        
            int i = 1;

            while (i < 1000)
            {
                DoLog("Начинаю " + i + " цикл");
                PlayCampaing();
                i++;
            }
        }
        
        static void DoMouseLeftClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        private bool PlayClubs(int rq, int condition, int tires, int[] b, int i)
        {            
            bool x = true;
            bool y = false;            
            Thread.Sleep(2000);

            do
            {
                if (ClubBountyCheck())
                {
                    x = false;
                    y = true;
                }

                UniversalCapture(EventEndMessageBounds, EventEndMessagePath);//проверка сообщения "эвент окончен"
                if (Verify(EventEndMessagePath, EventEndMessageOriginal))
                {
                    DoLog("эвент окончен");
                    Clk(640, 590);//Accept Message
                    if (i != 1)
                    {
                        while (!ClubBountyCheck()) Thread.Sleep(2000);
                    }
                    Thread.Sleep(3000);
                    x = false;
                    y = true;
                }               

                UniversalCapture(ControlScreenBounds, ControlScreenPath);
                if (Verify(ControlScreenPath, ControlScreenOriginal))
                {
                    DoLog("Перехожу в гараж");
                    Clk(820, 790);//Play
                    Thread.Sleep(5000);

                    do
                    {
                        if (i == 1)
                        {
                            ClearHand();
                            Thread.Sleep(500);
                            DoLog("Собираю пробную руку c 1 условием");
                            MakingTryHandwith1Condition(rq, condition, tires);
                        }

                        if (i != 1)
                        {
                            if (!HandCarFixed() || !VerifyHand())
                            {
                                if (rq != 0)
                                {
                                    ClearHand();
                                    Thread.Sleep(500);
                                    DoLog("Меняю руку");
                                    MakingTryHandwith1Condition(rq, condition, tires);
                                }
                            }
                        }
                    } while (!VerifyHand());

                    DoLog("Проверяю актуальность руки");
                    do
                    {
                        Thread.Sleep(500);
                        UniversalCapture(GarageRaceButtonBounds, GarageRaceButtonPath);
                    } while (!Verify(GarageRaceButtonPath, GarageRaceButtonOriginal));

                    Thread.Sleep(1000);
                    DoLog("Начинаю заезд");
                    Clk(1100, 800);//GarageRaceButton

                    do
                    {
                        Thread.Sleep(500);
                        UniversalErrorDefense();
                        UniversalCapture(GarageRaceButtonBounds, GarageRaceButtonPath);
                    } while (Verify(GarageRaceButtonPath, GarageRaceButtonOriginal));

                    Thread.Sleep(3000);
                     
                    UniversalCapture(EventEndMessageBounds, EventEndMessagePath);//проверка сообщения "эвент окончен"
                    if (Verify(EventEndMessagePath, EventEndMessageOriginal))
                    {
                        DoLog("эвент окончен");
                        Clk(640, 590);//Accept Message
                        Thread.Sleep(3000);
                        x = false;
                    }

                    UniversalCapture(FullEventBounds, FullEventPath);//проверка сообщения "эвент заполнен"
                    if (Verify(FullEventPath, FullEventOriginal))
                    {
                        DoLog("эвент заполнен");
                        Clk(640, 570);//Accept Message

                        if (InGarage())
                        {
                            Clk(85, 215);//back
                            Thread.Sleep(2000);
                            Clk(85, 215);//back to club map
                        }                        
                        Thread.Sleep(3000);
                        x = false;
                    }

                    if (x)
                    {                        
                        do
                        {
                            UniversalErrorDefense();
                            BW2Capture(ChooseanEnemyBounds, ChooseanEnemyPath);
                            Thread.Sleep(1500);
                        } while (!VerifyBW(ChooseanEnemyPath, ChooseanEnemyOriginal, 40));

                        int[] a1 = Tracks();//Track info
                        int[] b1 = Grounds();//Ground info
                        int[] c1 = Weathers();//Weather info

                        Clk(640, 705);//ChooseanEnemy
                        DoLog("Выбрал противника");
                        Thread.Sleep(1000);

                        do
                        {
                            UniversalErrorDefense();
                            Thread.Sleep(2000);
                            UniversalCapture(ArrangementBounds, ArrangementPath);
                        } while (!Verify(ArrangementPath, ArrangementOriginal));

                        Thread.Sleep(1000);
                        Arrangement(a1, b1, c1);

                        do
                        {
                            UniversalErrorDefense();
                            Thread.Sleep(2000);
                            UniversalCapture(RaceBounds, RacePath);
                        } while (!Verify(RacePath, RaceOriginal));

                        Thread.Sleep(2500);
                        Clk(180, 580); //ускорить заезд, клик в пусой области
                        Thread.Sleep(2000);

                        while (Verify(RacePath, RaceOriginal))
                        {
                            Thread.Sleep(2000);
                            UniversalCapture(RaceBounds, RacePath);
                        }

                        Thread.Sleep(6000);
                        Clk(640, 220); //кнопка "пропустить"

                        Thread.Sleep(2000);
                        Clk(895, 620);//подтвержение "пропуска"

                        Thread.Sleep(6000);
                        Clk(635, 670);//звезды  

                        Thread.Sleep(5000);
                        bool newflag = false;
                        do
                        {
                            UniversalCapture(AcBounds, AcPath);//проверка рекламы на прокачку
                            if (Verify(AcPath, AcOriginal) || Verify(AcPath, AcOriginal1))
                            {
                                DoLog("Смотрю рекламу на прокачку");
                                Clk(1025, 740); //начать просмотр
                                Thread.Sleep(60000);
                                AdsKiller();                                
                                Thread.Sleep(12000);
                                Clk(630, 715); //подтвердить проркачку
                                Thread.Sleep(5000);
                                newflag = true;
                            }
                            UniversalCapture(PointsForRaceBounds, PointsForRacePath);
                            if (Verify(PointsForRacePath, PointsForRaceOriginal))
                            {
                                newflag = true;
                            }
                        } while (!newflag);

                        DoLog("Просматриваю таблицу результатов");
                        Clk(870, 712);//Table
                        Thread.Sleep(5000);
                        bool flag1 = false;

                        do
                        {
                            Thread.Sleep(2000);                            
                            if (ClubBountyCheck())
                            {                                
                                x = false;
                                flag1 = true;
                            }
                            UniversalCapture(ControlScreenBounds, ControlScreenPath);//Проверка экрана контроля
                            if (Verify(ControlScreenPath, ControlScreenOriginal))
                            {
                                flag1 = true;
                            }
                            UniversalCapture(MapBounds, MapPath);
                            if(Verify(MapPath, MapOriginal))
                            {
                                x = false;
                                flag1 = true;
                            }
                        } while (flag1 == false);
                    }
                    y = true;
                }                
            } while (!y);
            
            return x;
        }

        private void AdsKiller()
        {
            UniversalCapture(AdsWOWBounds, AdsWOWPath);
            if (Verify(AdsWOWPath, AdsWOWOriginal))
            {
                Clk(1205, 200);  //close WOW
            }
            else
            {

                UniversalCapture(AdsWMBounds, AdsWMPath);
                if (Verify(AdsWMPath, AdsWMOriginal))
                {
                    Clk(1150, 245);  //close WM
                }
                else
                {
                    UniversalCapture(AdsNutrilakBounds, AdsNutrilakPath);
                    if (Verify(AdsNutrilakPath, AdsNutrilakOriginal))
                    {
                        Clk(1200, 200);  //close Nutrilak
                    }
                    else
                    {
                        UniversalCapture(AdsREBounds, AdsREPath);
                        if (Verify(AdsREPath, AdsREOriginal))
                        {
                            Clk(1155, 250);  //close RE
                        }
                        else
                        {

                            {
                                Clk(85, 205); //close
                            }
                        }
                    }
                }
            }
        }

        private void Arrangement(int[] a1, int[] b1, int[] c1)
        {
            Point Finger1 = new Point(350, 770);
            Point Finger2 = new Point(540, 770);
            Point Finger3 = new Point(730, 770);
            Point Finger4 = new Point(900, 770);
            Point Finger5 = new Point(1100, 770);
            Point Track1 = new Point(185, 610);
            Point Track2 = new Point(410, 610);
            Point Track3 = new Point(635, 610);
            Point Track4 = new Point(865, 610);
            Point Track5 = new Point(1090, 610);

            Point[] a = { Finger1, Finger2, Finger3, Finger4, Finger5 };
            Point[] b = { Track1, Track2, Track3, Track4, Track5 };

            int[] saves = ReadSaves();
            int[] carsid = new int[5];
            Array.Copy(saves, 3, carsid, 0, 5);
            carsid[0] = Identify1Car(carsid[0]);//converting picture id to car id
            carsid[1] = Identify2Car(carsid[1]);
            carsid[2] = Identify3Car(carsid[2]);
            carsid[3] = Identify4Car(carsid[3]);
            carsid[4] = Identify5Car(carsid[4]);
            double[] emptycar = { 0, 0, 0, 0, 0, 0, 0 };

            double[][] carstats = new double[5][];
            for(int m = 0; m < 5; m++)
            {
                carstats[m] = CarStats(carsid[m]);
            }

            string[] a2 = IdentifyTracks(a1);//Track name                        
            string[] b2 = IdentifyGround(b1);//Coverage            
            string[] c2 = IdentifyWeather(c1);//Weather
            string[,] d = TrackPackage(a2, b2, c2);//race full info
            int[] a3 = TrackRank(a2);//Track Rank

            for (int i = 0; i < 4; i++)//track priority
            {
                for (int i1 = (i+1); i1 < 5; i1++)
                {
                    if(a3[i] > a3[i1])
                    {
                        int f1 = a3[i];
                        a3[i] = a3[i1];
                        a3[i1] = f1;
                        Point f2 = b[i];
                        b[i] = b[i1];
                        b[i1] = f2;
                        for(int j = 0; j < 3; j++)
                        {
                            string var = d[j, i];
                            d[j, i] = d[j, i1];
                            d[j, i1] = var; 
                        }                        
                    }
                }
            }

            for(int j = 0; j < 5; j++)//logic for dragndrop
            {
                Thread.Sleep(3000);
                double empty = -5000;
                double x;
                int usingfinger = 0;
                for(int n = 0; n < 5; n++)
                {
                    if(carstats[n] == emptycar)
                    {
                        x = -10000;
                    }
                    else
                    {
                        x = CalculateCompatibility(d[0, j], d[1, j], d[2, j], carstats[n]);
                    }
                    
                    if (x > empty)
                    {
                        usingfinger = n;//choose the best car for track
                        empty = x; 
                    }
                }
                DragnDrop(a[usingfinger], b[j]);//set choosen car on track
                carstats[usingfinger] = emptycar;//set used finger as empty
            }
        }

        private int[] RememberHand()
        {
            Rectangle HandSlot1 = new Rectangle(100, 725, 115, 60);
            Rectangle HandSlot2 = new Rectangle(285, 725, 115, 60);
            Rectangle HandSlot3 = new Rectangle(470, 725, 115, 60);
            Rectangle HandSlot4 = new Rectangle(655, 725, 115, 60);
            Rectangle HandSlot5 = new Rectangle(845, 725, 115, 60);
            string carsDB = "finger";
            int lastcar = 500;
            int[] carsid = new int[5];

            int n;
            bool flag;
            Rectangle[] b = { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };
            for (int i = 0; i < 5; i++)
            {
                UniversalCapture(b[i], (carsDB + (i + 1) + "\\test"));
                flag = true;
                n = 0;
                for (int i1 = 1; i1 < lastcar; i1++)
                {
                    if (File.Exists("C:\\Users\\Public\\test\\Finger" + (i + 1) + "\\" + i1 + ".jpg"))
                    {
                        n = i1;
                    }
                    else break;
                }

                for (int i2 = 1; i2 < (n + 1); i2++)
                {
                    if (Verify(("Finger" + (i + 1) + "\\" + i2), ("Finger" + (i + 1) + "\\test")))
                    {
                        DoLog("На " + (i + 1) + " месте " + i2 + " тачка");
                        carsid[i] = i2;
                        File.Delete("C:\\Users\\Public\\test\\Finger" + (i + 1) + "\\test.jpg");
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    DoLog("Добавляю новую тачку");
                    carsid[i] = n + 1;
                    File.Move("C:\\Users\\Public\\test\\Finger" + (i + 1) + "\\test.jpg", "C:\\Users\\Public\\test\\Finger" + (i + 1) + "\\" + (n + 1) + ".jpg");
                }
            }

            return carsid;
        }

        private bool VerifyHand()
        {
            Point HandSlot1 = new Point(170, 770);
            Point HandSlot2 = new Point(350, 770);
            Point HandSlot3 = new Point(540, 770);
            Point HandSlot4 = new Point(730, 770);
            Point HandSlot5 = new Point(910, 770);
            Point[] a = { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };
            bool x = true;
            string emptyslot = "Color [A=255, R=200, G=200, B=200]";

            for(int i = 0; i < 5; i++)
            {
                if(PixelIndicator(a[i]) == emptyslot)
                {
                    x = false;
                    break;
                }
            }

            return x;
        }

        private void MakingTryHandwith1Condition(int rq, int condition, int tires)
        {
            int f = 6;
            int e = 10;
            int d = 14;
            int c = 18;
            int b = 22;
            int a = 26;
            int s = 30;
            int[] rqclass = new int[] { f, e, d, c, b, a, s };
            int[,] hand = new int[5, 7];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    hand[i, j] = rqclass[j];
                }
            }

            int[] finger = new int[5];
            Random r = new Random();
            int n;
            int handrq;
            switch (condition)
            {
                case 52://pontiac
                    finger[0] = 0;
                    finger[1] = 0;
                    finger[2] = 0;
                    finger[3] = 1;
                    finger[4] = 1;
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 102)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 4);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк понтиак 102");
                    break;

                case 51://opel
                    finger[0] = 0;
                    finger[1] = 1;
                    finger[2] = 1;
                    finger[3] = 3;
                    finger[4] = 3;
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 110)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 4);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк опель 110");
                    break;

                case 50://chevrolet
                    finger[0] = 0;
                    for (int x = 1; x < 5; x++)
                    {
                        finger[x] = 1;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 130)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк шеви 130");
                    break;

                case 49://bmw
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 130)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк бмв 140");
                    break;

                case 44://dodge
                    finger[0] = 0;
                    finger[1] = 1;
                    finger[2] = 2;
                    finger[3] = 2;
                    finger[4] = 2;
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 110)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 4);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк додж 110");
                    break;

                case 42://citroen
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    finger[0] = 2;
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 76)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 3);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }                        
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк ситроен 76");
                    break;

                case 38://alfa
                    finger[0] = 1;
                    finger[1] = 1;
                    finger[2] = 2;
                    finger[3] = 2;
                    finger[4] = 2;
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 108)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }                        
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк alfa 108");
                    break;

                case 36:
                case 35:
                case 34://cadillac
                    finger[0] = 0;
                    finger[1] = 0;
                    finger[2] = 1;
                    finger[3] = 3;
                    finger[4] = 3;
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 140)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк cadillac 140");
                    break;

                case 46:
                case 33://french renaissance                    
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 1;
                    }
                    
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 130)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 6);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк фр ренесанса 130");
                    break;

                case 32:
                case 31://Honda x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 110)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 4);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк хонды 110");
                    break;

                case 17://Style Icon
                    finger[0] = 0;
                    finger[1] = 2;
                    for (int x = 2; x < 5; x++)
                    {
                        finger[x] = 1;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }

                    while ((rq - handrq) > 3 && handrq != 106)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 4);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";    у икон стиля только 4 экстрима и одна обычная");
                    break;

                case 29://All Surface Tyres x5
                case 27:
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 1;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }

                    while ((rq - handrq) > 3 && handrq != 146)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
                    break;

                case 30://Subaru x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 126)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   У субару 4 эпика");
                    break;

                case 47:
                case 28://5 Seaters x5
                case 26:
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }

                    while ((rq - handrq) > 3 && handrq != 130)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
                    break;

                case 14: //Super x3
                    for (int x = 0; x < 5; x++)
                    {
                        if(x > 1)
                        {
                            finger[x] = 3; //выставляем 3 суперских
                        }
                        else
                        {
                            finger[x] = 0;
                        }                        
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }

                    while ((rq - handrq) > 3)
                    {
                        do
                        {
                            n = r.Next(0, 2);//рандомим 2 твчки
                        } while (finger[n] == 6);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
                    break;

                case 10://Common x3
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }

                    while ((rq - handrq) > 3)
                    {
                        do
                        {
                            n = r.Next(0, 2);// 3 обычных, остальное рандомим
                        } while (finger[n] == 6);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
                    break;
                    
                case 15://Uncommon x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 1;
                    }
                    DoLog("собрал необычные");
                    break;

                case 8://Common x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    DoLog("собрал обычные");
                    break;

                case 48:
                case 2://Rare x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 2;
                    }
                    DoLog("собрал редкостные");
                    break;
                case 20://FWD x5
                case 6:
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];                        
                    }
                    if (tires != 1 || tires != 4 || tires != 9 || tires != 10 || tires != 17)
                    {
                        while ((rq - handrq) > 3 && handrq != 110)
                        {
                            do
                            {
                                n = r.Next(0, 5);
                            } while (finger[n] == 4);
                            finger[n]++;

                            handrq = 0;
                            for (int x = 0; x < 5; x++)
                            {
                                handrq += hand[x, finger[x]];
                            }
                        }
                        DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк переднего привода 110");
                    }
                    else
                    {
                        while ((rq - handrq) > 3 && handrq != 90)
                        {
                            do
                            {
                                n = r.Next(0, 5);
                            } while (finger[n] == 3);
                            finger[n]++;

                            handrq = 0;
                            for (int x = 0; x < 5; x++)
                            {
                                handrq += hand[x, finger[x]];
                            }
                        }
                        DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк переднего привода 110");
                    }
                    break;

                case 11://Hot hutch x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];                        
                    }
                    while ((rq - handrq) > 3 && handrq != 122)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);                        
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];                           
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";  только 2 эпика");
                    break;

                case 12://Renault x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];                        
                    }
                    while ((rq - handrq) > 3 && handrq != 122)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);                        
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];                           
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";  только 2 эпика");
                    break;

                case 13://Italy x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];                      
                    }
                    while ((rq - handrq) > 3 && handrq != 110)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 4);                        
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];                           
                        }
                    }

                    if ((rq - handrq) > 7)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;
                    }

                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }

                    if ((rq - handrq) > 3)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";  только 1 эпик и 1 лега");
                    break;

                case 37://std x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 130)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);                        
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Нет выше эпиков");
                    break;

                case 7://Japan x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];                        
                    }
                    while ((rq - handrq) > 3 && handrq != 130)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);                       
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];                            
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Нет выше эпиков");
                    break;

                default:
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];                       
                    }

                    while ((rq - handrq) > 3)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 6);                        
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];                           
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
                    break;
            }  

            int remember;
            for (int l = 0; l < 4; l++)
            {
                for (int l1 = 0; l1 < (4 - l); l1++)
                    if (finger[l1] > finger[l1 + 1])
                    {
                        remember = finger[l1];
                        finger[l1] = finger[l1 + 1];
                        finger[l1 + 1] = remember;
                    }
            }

            f = 0;
            e = 0;
            d = 0;
            c = 0;
            b = 0;
            a = 0;
            s = 0;

            for (int k = 0; k < 5; k++)
            {
                DoLog(finger[k].ToString());
                switch (finger[k])
                {
                    case 0:
                        f++;
                        break;

                    case 1:
                        e++;
                        break;

                    case 2:
                        d++;
                        break;

                    case 3:
                        c++;
                        break;

                    case 4:
                        b++;
                        break;

                    case 5:
                        a++;
                        break;

                    case 6:
                        s++;
                        break;
                }

            }

            int var; //недобор
            int usedhandslots = 0;            

            if (s > 0)
            {
                Randomizer(condition, rq, tires);
                var = UseFilter("s", s, usedhandslots, tires, condition);
                usedhandslots += s - var;                
                a += var;               
            }

            if (a > 0)
            {
                Randomizer(condition, rq, tires);
                var = UseFilter("a", a, usedhandslots, tires, condition);
                usedhandslots += a - var;
                b += var;                
            }           

            if (b > 0)
            {
                Randomizer(condition, rq, tires);
                var = UseFilter("b", b, usedhandslots, tires, condition);
                usedhandslots += b - var;
                c += var;                
            }

            if (c > 0)
            {
                Randomizer(condition, rq, tires);
                var = UseFilter("c", c, usedhandslots, tires, condition);
                usedhandslots += c - var;
                d += var;                
            }

            if (d > 0)
            {
                Randomizer(condition, rq, tires);
                var = UseFilter("d", d, usedhandslots, tires, condition);
                usedhandslots += d - var;
                e += var;               
            }

            if (e > 0)
            {
                Randomizer(condition, rq, tires);
                var = UseFilter("e", e, usedhandslots, tires, condition);
                usedhandslots += e - var;
                f += var;                
            }

            if (f > 0)
            {
                Randomizer(condition, rq, tires);
                UseFilter("f", f, usedhandslots, tires, condition);
            }

            if (VerifyHand())//проверка руки, чтобы не сохранял пустые картинки
            {
                int[] carsid = RememberHand();
                Saves(rq, condition, tires, carsid);
            }
        }

        private void MakingHandwith1Condition(int rq, int condition)
        {
            int f = 6;
            int e = 10;
            int d = 14;
            int c = 18;
            int b = 22;
            int a = 26;
            int s = 30;
            int[] rqclass = new int[] { f, e, d, c, b, a, s };
            int[,] hand = new int[5, 7];
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    hand[i, j] = rqclass[j];
                }
            }

            int[] finger = new int[5];
            Random r = new Random();
            int n;
            int handrq;
            switch (condition)
            {
                case 52://pontiac
                    finger[0] = 0;
                    finger[1] = 0;
                    finger[2] = 0;
                    finger[3] = 1;
                    finger[4] = 1;
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 102)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 4);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк понтиак 102");
                    break;

                case 51://opel
                    finger[0] = 0;
                    finger[1] = 1;
                    finger[2] = 1;
                    finger[3] = 3;
                    finger[4] = 3;
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 110)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 4);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк опель 110");
                    break;

                case 50://chevrolet
                    finger[0] = 0;
                    for (int x = 1; x < 5; x++)
                    {
                        finger[x] = 1;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 130)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк шеви 130");
                    break;

                case 49://bmw
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 130)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк бмв 140");
                    break;

                case 44://dodge
                    finger[0] = 0;
                    finger[1] = 1;
                    finger[2] = 2;
                    finger[3] = 2;
                    finger[4] = 2;
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 110)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 4);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк додж 110");
                    break;

                case 42://citroen
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    finger[0] = 2;
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 76)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 3);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк ситроен 76");
                    break;

                case 38://alfa
                    finger[0] = 1;
                    finger[1] = 1;
                    finger[2] = 2;
                    finger[3] = 2;
                    finger[4] = 2;
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 108)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк alfa 108");
                    break;

                case 36:
                case 35:
                case 34://cadillac
                    finger[0] = 0;
                    finger[1] = 0;
                    finger[2] = 1;
                    finger[3] = 3;
                    finger[4] = 3;
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 140)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк cadillac 140");
                    break;

                case 46:
                case 33://french renaissance                    
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 1;
                    }

                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 130)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 6);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк фр ренесанса 130");
                    break;

                case 32:
                case 31://Honda x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 110)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 4);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк хонды 110");
                    break;

                case 17://Style Icon
                    finger[0] = 0;
                    finger[1] = 2;
                    for (int x = 2; x < 5; x++)
                    {
                        finger[x] = 1;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }

                    while ((rq - handrq) > 3 && handrq != 106)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 4);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";    у икон стиля только 4 экстрима и одна обычная");
                    break;

                case 29://All Surface Tyres x5
                case 27:
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 1;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }

                    while ((rq - handrq) > 3 && handrq != 146)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
                    break;

                case 30://Subaru x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 126)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   У субару 4 эпика");
                    break;

                case 47:
                case 28://5 Seaters x5
                case 26:
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }

                    while ((rq - handrq) > 3 && handrq != 130)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
                    break;

                case 14: //Super x3
                    for (int x = 0; x < 5; x++)
                    {
                        if (x > 1)
                        {
                            finger[x] = 3; //выставляем 3 суперских
                        }
                        else
                        {
                            finger[x] = 0;
                        }
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }

                    while ((rq - handrq) > 3)
                    {
                        do
                        {
                            n = r.Next(0, 2);//рандомим 2 твчки
                        } while (finger[n] == 6);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
                    break;

                case 10://Common x3
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }

                    while ((rq - handrq) > 3)
                    {
                        do
                        {
                            n = r.Next(0, 2);// 3 обычных, остальное рандомим
                        } while (finger[n] == 6);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
                    break;

                case 15://Uncommon x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 1;
                    }
                    DoLog("собрал необычные");
                    break;

                case 8://Common x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    DoLog("собрал обычные");
                    break;

                case 48:
                case 2://Rare x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 2;
                    }
                    DoLog("собрал редкостные");
                    break;
                case 20://FWD x5
                case 6:
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 90)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 3);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк переднего привода 110");

                    break;

                case 11://Hot hutch x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 122)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";  только 2 эпика");
                    break;

                case 12://Renault x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 122)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";  только 2 эпика");
                    break;

                case 13://Italy x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 110)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 4);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }

                    if ((rq - handrq) > 7)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;
                    }

                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }

                    if ((rq - handrq) > 3)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";  только 1 эпик и 1 лега");
                    break;

                case 37://std x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 130)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Нет выше эпиков");
                    break;

                case 7://Japan x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 && handrq != 130)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 5);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Нет выше эпиков");
                    break;

                default:
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    handrq = 0;
                    for (int x = 0; x < 5; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }

                    while ((rq - handrq) > 3)
                    {
                        do
                        {
                            n = r.Next(0, 5);
                        } while (finger[n] == 6);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
                    break;
            }

            int remember;
            for (int l = 0; l < 4; l++)
            {
                for (int l1 = 0; l1 < (4 - l); l1++)
                    if (finger[l1] > finger[l1 + 1])
                    {
                        remember = finger[l1];
                        finger[l1] = finger[l1 + 1];
                        finger[l1 + 1] = remember;
                    }
            }

            for (int k = 0; k < 5; k++)
            {
                //отправляем условия первого трэка
                ChooseCar(finger[k]);
            }
        }

        private void ChooseCar(int cls)
        {
            while (!InGarage()) Thread.Sleep(2000);
            Clk(940, 270);//filter
            Thread.Sleep(3000);
            while (!InGarage()) Thread.Sleep(2000);
            Clk(250, 775);//сброс
            Thread.Sleep(2000);
            while (!InGarage()) Thread.Sleep(2000);
            Clk(940, 270);//filter
            Thread.Sleep(3000);
            while (!InGarage()) Thread.Sleep(2000);
            switch (cls)
            {
                case 0:
                    Clk(110, 405);//выбрать f класс                    
                    break;

                case 1:
                    Clk(110, 475);//выбрать e класс                    
                    break;

                case 2:
                    Clk(110, 540);//выбрать d класс                    
                    break;

                case 3:
                    Clk(110, 600);//выбрать c класс                    
                    break;

                case 4:
                    Clk(110, 665);//выбрать b класс                    
                    break;

                case 5:
                    Clk(110, 713);//выбрать a класс                    
                    break;

                case 6:
                    Point a1 = new Point(200, 636);
                    Point a2 = new Point(200, 470);
                    SlowDragnDrop(a1, a2);
                    Clk(113, 680);//выбрать s класс
                    break;
            }
        }

        private void ChooseTires(int eventN, string cls)
        {
            Point xy1 = new Point(1100, 630);
            Point xy2 = new Point(1100, 390);
            Thread.Sleep(500);
            switch (eventN)
            {
                case 1:
                case 17:
                case 21:
                    switch (cls)
                    {
                        case "f":
                            Clk(980, 715);//std
                            Thread.Sleep(500);
                            break;
                        case "e":
                            Clk(980, 665);//off
                            Thread.Sleep(500);
                            Clk(980, 715);//std
                            Thread.Sleep(500);
                            SlowDragnDrop(xy1, xy2);
                            Thread.Sleep(2000);
                            Clk(980, 650);//all 
                            Thread.Sleep(500);
                            break;
                        default:
                            Clk(980, 665);//off
                            Thread.Sleep(500);
                            SlowDragnDrop(xy1, xy2);
                            Thread.Sleep(2000);
                            Clk(980, 650);//all
                            Thread.Sleep(500);
                            break;
                    }
                    break;

                case 19:
                case 15:
                case 2:
                    Clk(980, 600);//dyn
                    Thread.Sleep(500);
                    Clk(980, 715);//std
                    Thread.Sleep(500);
                    break;

                case 3:
                case 8:
                case 11:
                    Clk(980, 600);//dyn
                    Thread.Sleep(500);
                    Clk(980, 715);//std
                    Thread.Sleep(500);
                    break;

                case 4:
                case 9:
                case 10:
                    switch (cls)
                    {
                        case "f":
                            Clk(980, 715);//std
                            Thread.Sleep(500);
                            break;
                        case "e":
                            Clk(980, 715);//std
                            Thread.Sleep(500);
                            Clk(980, 665);//off
                            Thread.Sleep(500);
                            SlowDragnDrop(xy1, xy2);
                            Thread.Sleep(2000);
                            Clk(980, 650);//all
                            Thread.Sleep(500);
                            break;
                        default:
                            Clk(980, 665);//off
                            Thread.Sleep(500);
                            SlowDragnDrop(xy1, xy2);
                            Thread.Sleep(2000);
                            Clk(980, 650);//all
                            Thread.Sleep(500);
                            break;
                    }
                    break;

                case 13:
                case 5:
                case 12:
                    Clk(980, 600);//dyn
                    Thread.Sleep(500);
                    Clk(980, 715);//std
                    Thread.Sleep(500);
                    break;

                case 24:
                case 23:
                case 6:
                    Clk(980, 600);//dyn
                    Thread.Sleep(500);
                    Clk(980, 715);//std
                    Thread.Sleep(500);
                    Clk(980, 665);//off
                    Thread.Sleep(500);
                    SlowDragnDrop(xy1, xy2);
                    Thread.Sleep(2000);
                    Clk(980, 650);//all
                    Thread.Sleep(500);
                    break;

                case 32:
                case 30:
                case 7:
                    Clk(980, 600);//dyn
                    Thread.Sleep(500);
                    Clk(980, 715);//std
                    Thread.Sleep(500);
                    break;

                case 14:
                    switch (cls)
                    {
                        case "f":
                            Clk(980, 600);//dyn
                            Thread.Sleep(500);
                            Clk(980, 715);//std
                            Thread.Sleep(500);
                            break;
                        case "e":
                            Clk(980, 600);//dyn
                            Thread.Sleep(500);
                            Clk(980, 665);//off
                            Thread.Sleep(500);
                            Clk(980, 715);//std
                            Thread.Sleep(500);
                            SlowDragnDrop(xy1, xy2);
                            Thread.Sleep(2000);
                            Clk(980, 650);//all 
                            Thread.Sleep(500);
                            break;
                        default:
                            Clk(980, 600);//dyn
                            Thread.Sleep(500);
                            Clk(980, 715);//std
                            Thread.Sleep(500);
                            Clk(980, 665);//off
                            Thread.Sleep(500);
                            SlowDragnDrop(xy1, xy2);
                            Thread.Sleep(2000);
                            Clk(980, 650);//all
                            Thread.Sleep(500);
                            break;
                    }
                    break;

                case 29:
                case 28:
                case 16:
                    Clk(980, 600);//dyn
                    Thread.Sleep(500);
                    Clk(980, 715);//std
                    Thread.Sleep(500);
                    break;
                
                case 22:
                case 20:
                case 18:
                    Clk(980, 600);//dyn
                    Thread.Sleep(500);
                    Clk(980, 715);//std
                    Thread.Sleep(500);
                    /*SlowDragnDrop(xy1, xy2);
                    Thread.Sleep(2000);
                    Clk(980, 585);//slk
                    Thread.Sleep(500);   */
                    break;

                case 34:
                case 33:
                case 31:
                    Clk(980, 715);//std
                    Thread.Sleep(500);
                    SlowDragnDrop(xy1, xy2);
                    Thread.Sleep(2000);
                    Clk(980, 650);//all
                    Thread.Sleep(500);
                    break;

                default:
                    break;
            }
        }
        
        private bool InGarage()
        {
            bool x = false;

            UniversalCapture(InGarageBounds, InGaragePath);
            if (Verify(InGaragePath, InGarageOriginal)) x = true;

            return x;
        }

        private int UseFilter(string cls, int n, int uhl, int tires, int condition)
        {
            while (!InGarage()) Thread.Sleep(2000);
            Clk(940, 270);//filter
            Thread.Sleep(3000);
            while (!InGarage()) Thread.Sleep(2000);
            Clk(250, 775);//сброс
            Thread.Sleep(2000);
            while (!InGarage()) Thread.Sleep(2000);
            Clk(940, 270);//filter
            Thread.Sleep(3000);
            while (!InGarage()) Thread.Sleep(2000);
            switch (cls)
            {                
                case "f":                           
                    Clk(110, 405);//выбрать класс                    
                    break;

                case "e":                    
                    Clk(110, 475);//выбрать класс                    
                    break;

                case "d":                   
                    Clk(110, 540);//выбрать класс                    
                    break;

                case "c":                   
                    Clk(110, 600);//выбрать класс                    
                    break;

                case "b":                   
                    Clk(110, 665);//выбрать класс                    
                    break;
                    
                case "a":                    
                    Clk(110, 713);//выбрать класс                    
                    break;                   

                case "s":
                    Point a1 = new Point(200, 636);
                    Point a2 = new Point(200, 470);
                    SlowDragnDrop(a1, a2);                    
                    Clk(113, 680);//выбрать класс
                    break;
            }

            Thread.Sleep(500);
            while (!InGarage()) Thread.Sleep(2000);
            if (condition != 27 && condition != 29 && condition != 17 && condition != 30 && condition != 37 && condition != 38  && condition != 42 && condition != 44 && condition != 51 && condition != 52) ChooseTires(tires, cls); //исключить всесезонки, стандарты и иконы стиля 
            Thread.Sleep(1000);
            while (!InGarage()) Thread.Sleep(2000);
            Clk(830, 780);//закрыть фильтр
            Thread.Sleep(2500);
            while (!InGarage()) Thread.Sleep(2000);
            if (condition != 0) Clk(650, 270); //включить фильтр условия события
            Thread.Sleep(2000);
            int emptycars = DragnDpopHand(n, uhl);

            return emptycars;
        }

        private int DragnDpopHand(int n, int uhl)
        {
            Point GarageSlot1 = new Point(535, 400);
            Point GarageSlot2 = new Point(535, 590);
            Point GarageSlot3 = new Point(830, 400);
            Point GarageSlot4 = new Point(830, 590);
            //точки для сдвига 995/495 и 600/495
            Point GarageSlot5 = new Point(750, 400);
            Point GarageSlot6 = new Point(750, 590);
            //точки для сдвига 615/495 и 300/495
            Point GarageSlot7 = new Point(750, 400);
            Point GarageSlot8 = new Point(750, 590);
            //-------------
            Point GarageSlot9 = new Point(810, 400);
            Point GarageSlot10 = new Point(810, 590);

            Point HandSlot1 = new Point(170, 770);
            Point HandSlot2 = new Point(350, 770);
            Point HandSlot3 = new Point(540, 770);
            Point HandSlot4 = new Point(730, 770);
            Point HandSlot5 = new Point(910, 770);

            Point[] a = new Point[] { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };
            Point[] b = new Point[] { GarageSlot1, GarageSlot2, GarageSlot3, GarageSlot4, GarageSlot5, GarageSlot6, GarageSlot7, GarageSlot8, GarageSlot9, GarageSlot10 };
            int emptyCars = 0;
            int newN = 0;
            int x = 0;
            int h = 0;
            int drag = 0;
            int usefullcars = 0;
            for(int number = 0; number < 6; number++)//для начала научимся проверять первые 6 слотов
            {
                if (!EmptyGarageSlot(number)) break;//не удается отладить проверку далее 6 слота
                else usefullcars = number + 1;
            }
            DoLog("Подходят " + usefullcars + " авто");
            if(n > usefullcars)
            {
                newN = usefullcars;
                emptyCars = n - usefullcars;
            }
            else
            {
                newN = n;
            }

            while(x < newN) //x имеет значение и при нуле
            {
                if (x > 3 && drag == 0)
                {
                    MoveMouse(995, 495);
                    Thread.Sleep(100);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 995, 495, 0, 0);
                    Thread.Sleep(2000);
                    for (int i = 995; i > 600; i -= 5)
                    {
                        MoveMouse(i, 495);
                        Thread.Sleep(70);
                    }
                    Thread.Sleep(1000);
                    MoveMouse(600, 495);
                    Thread.Sleep(2000);
                    mouse_event(MOUSEEVENTF_LEFTUP, 600, 495, 0, 0);
                    Thread.Sleep(1000);
                    drag = 1;
                }

                if (x > 5 && drag == 1)
                {
                    MoveMouse(915, 495);
                    Thread.Sleep(100);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 615, 495, 0, 0);
                    Thread.Sleep(2000);
                    for (int i = 615; i > 300; i -= 5)
                    {
                        MoveMouse(i, 495);
                        Thread.Sleep(70);
                    }
                    Thread.Sleep(1000);
                    MoveMouse(300, 495);
                    Thread.Sleep(2000);
                    mouse_event(MOUSEEVENTF_LEFTUP, 300, 495, 0, 0);
                    Thread.Sleep(1000);
                    drag = 2;
                }

                if (CarFixed(x))
                {
                    DoLog("Тачка " + (x + 1) + " исправна");
                    while (!InGarage()) Thread.Sleep(2000);
                    DragnDropGarage(b[x], a[h + uhl]);
                    x++;
                    h++;
                }                    
                else
                {
                    DoLog("Тачка " + x + " не готова");
                    x++;
                    newN++;
                }
            }

            return emptyCars;
        }

        private int Selection(int eventN)
        {
            Point n1 = new Point(1000, 580);
            Point n2 = new Point(1000, 665);
            Point n3 = new Point(1000, 740);
            Point n4 = new Point(1000, 820);
            int x = 500;
            Random rand = new Random();
            bool flag;
            int filename;

            do
            {
                flag = true;
                switch (eventN)
                {
                    case 1:
                        Clk(n1.X, n1.Y);
                        break;
                    case 2:
                        Clk(n2.X, n2.Y);
                        break;
                    case 3:
                        Clk(n3.X, n3.Y);
                        break;
                    case 4:
                        Clk(n4.X, n4.Y);
                        break;
                }                
                Thread.Sleep(4000);
                UniversalCapture(WrongClickBounds, WrongClickPath);
                if (Verify(WrongClickPath, WrongClickOriginal))
                {
                    Clk(1130, 250);
                    flag = false;
                }
                Thread.Sleep(2000);
            } while (flag == false);

            UniversalCapture(Conditions1Bounds, Conditions1Path);
            UniversalCapture(Conditions2Bounds, Conditions2Path);
            if (Verify(Conditions2Path, "CC0"))
            {               
                for (x = 0; x < (c + 1); x++)
                {                   
                    if (Verify(Conditions1Path, "C" + x))
                    {
                        break;
                    }
                }
                DoLog("номер условия " + x);
                if (x == (c + 1))
                {
                    DoLog("Неизвестное условие");
                    do
                    {
                        filename = rand.Next(10000);
                    } while (File.Exists("C:\\Users\\Public\\test\\UnknownCondition" + filename + ".jpg"));                    
                    File.Move("C:\\Users\\Public\\test\\" + Conditions1Path +".jpg", "C:\\Users\\Public\\test\\UnknownCondition" + filename + ".jpg");
                    DoLog("Сделал скрин");
                    x = 500;
                }

                if (x != 500) //Исключаю неизвестный
                {
                    int rq = GotRQ();
                    if (rq > 17)
                    {                        
                        DoLog(eventN + " событие подходит");
                        DoLog("1 условие = " + x);
                        if (x == 42 && rq < 38)
                        {
                            DoLog("выпало исключение citroen");
                            x = 500;
                        }

                        if (x == 52 && rq < 33)
                        {
                            DoLog("выпало исключение pontiac");
                            x = 500;
                        }

                        if (x == 51 && rq < 58)
                        {
                            DoLog("выпало исключение opel");
                            x = 500;
                        }

                        if (x == 44 && rq < 53)
                        {
                            DoLog("выпало исключение dodge");
                            x = 500;
                        }

                        if (x == 38 && rq < 53)
                        {
                            DoLog("выпало исключение альфа");
                            x = 500;
                        }
                        if (x == 33 && rq < 58)
                        {
                            DoLog("выпало исключение франция");
                            x = 500;
                        }
                        if (x == 34 && rq < 54)
                        {
                            DoLog("выпало исключение кадил");
                            x = 500;
                        }
                    }
                    else
                    {
                        x = 500;
                    }
                }
                else
                {                    
                    x = 500;
                }
            }
            /*else
            {                
                int ending = rand.Next(1000);
                UniversalCapture(Conditions1Bounds, (Dump1Path + ending));
                UniversalCapture(Conditions2Bounds, (Dump2Path + ending));
                for(int i = 1; i < 9; i++)
                {
                    if(Verify(("Dump\\" + i), (Dump1Path + ending)))
                    {
                        File.Delete("C:\\Users\\Public\\test\\"+ Dump1Path + ending + ".jpg");
                        break;
                    }
                }

                for (int j = 1; j < 5; j++)
                {
                    if (Verify(("Dump\\s" + j), (Dump2Path + ending)))
                    {
                        File.Delete("C:\\Users\\Public\\test\\" + Dump2Path + ending + ".jpg");
                        break;
                    }
                }
            }*/
            return x;
        }

        private int ChooseNormalEvent()
        {
            int x = 500;
            while (x == 500)
            {
                for (int i = 1; i < 5; i++)
                {
                    do
                    {
                        UniversalCapture(WrongClickBounds, WrongClickPath);
                        if (Verify(WrongClickPath, WrongClickOriginal))
                        {
                            Clk(1130, 250);                           
                        }
                        Thread.Sleep(100);
                        ClubBountyCheck();
                        UniversalCapture(MapBounds, MapPath);
                    } while (!Verify(MapPath, MapOriginal));

                    x = Selection(i);
                    if (x == 500)
                    {
                        Clk(905, 275);//Back
                        Thread.Sleep(3000);                       
                    }
                    else
                    {
                        break;
                    }
                }
            }            

            return x;
        }     

        private void PlayCampaing()
        {
            Point Finger1 = new Point(350, 770);
            Point Finger2 = new Point(540, 770);
            Point Finger3 = new Point(730, 770);
            Point Finger4 = new Point(900, 770);
            Point Finger5 = new Point(1100, 770);
            Point Track1 = new Point(185, 610);
            Point Track2 = new Point(410, 610);
            Point Track3 = new Point(635, 610);
            Point Track4 = new Point(865, 610);
            Point Track5 = new Point(1090, 610);

            do
            {
                Thread.Sleep(2000);
                UniversalCapture(MonacoBounds, MonacoPath);
            } while (!Verify(MonacoPath, MonacoOriginal));

            Clk(800, 500);//Monaco 10

            Thread.Sleep(2000);

            do
            {
                Thread.Sleep(2000);
                UniversalCapture(GarageRaceButtonBounds, GarageRaceButtonPath);
            } while (!Verify(GarageRaceButtonPath, GarageRaceButtonOriginal));

            Clk(1100, 800);//GarageRace

            Thread.Sleep(1000);

            do
            {
                Thread.Sleep(2000);
                UniversalCapture(ArrangementBounds, ArrangementPath);
            } while (!Verify(ArrangementPath, ArrangementOriginal));

            DragnDrop(Finger1, Track1);

            Thread.Sleep(3000);
            DragnDrop(Finger2, Track2);

            Thread.Sleep(3000);
            DragnDrop(Finger3, Track3);

            Thread.Sleep(3000);
            DragnDrop(Finger4, Track4);

            Thread.Sleep(3000);
            DragnDrop(Finger5, Track5);
                       
            Thread.Sleep(3000);

            do
            {
                Thread.Sleep(2000);
                UniversalCapture(RacingBounds, RacingPath);
            } while (!Verify(RacingPath, RacingOriginal));
            Thread.Sleep(2000);

            Clk(180, 580); //ускорить заезд, клик в пусой области

            Thread.Sleep(15000); //кнопка "пропустить"
            Clk(640, 220);

            Thread.Sleep(5000); //подтвержение "пропуска"
            Clk(895, 620);
            
            Thread.Sleep(5000); //звезды                       
            Clk(635, 670);

            Thread.Sleep(5000);
            UniversalCapture(AcBounds, AcPath);//проверка рекламы на прокачку
            if (Verify(AcPath, AcOriginal))
            {
                DoLog("смотрим рекламу");
                Clk(1025, 740); //начать просмотр
                Thread.Sleep(60000);
                UniversalCapture(AdsWMBounds, AdsWMPath);
                if (Verify(AdsWMPath, AdsWMOriginal))
                {
                    Clk(1150, 245);  //close WM
                }
                else
                {
                    UniversalCapture(AdsNutrilakBounds, AdsNutrilakPath);
                    if (Verify(AdsNutrilakPath, AdsNutrilakOriginal))
                    {
                        Clk(1200, 200);  //close Nutrilak
                    }
                    else
                    {
                        Clk(85, 205); //close
                    }
                }
                Thread.Sleep(10000);
                Clk(630, 715); //подтвердить проркачку
            }            

        }

        private void DragnDrop(Point xy1, Point xy2)
        {
            int dox1 = xy1.X;
            int doy1 = xy1.Y;
            int dox2 = xy2.X;
            int doy2 = xy2.Y;
            string x1;
            string x2;
            do
            {
                x1 = PixelIndicator(xy1);
                MoveMouse(dox1, doy1);
                Thread.Sleep(100);
                mouse_event(MOUSEEVENTF_LEFTDOWN, dox1, doy1, 0, 0);
                Thread.Sleep(1000);
                MoveMouse(dox2, doy2);
                Thread.Sleep(3000);
                mouse_event(MOUSEEVENTF_LEFTUP, dox2, doy2, 0, 0);
                Thread.Sleep(2000);
                x2 = PixelIndicator(xy1);
            } while (x1 == x2);
                       
        }

        private void SlowDragnDrop(Point xy1, Point xy2)
        {
            int dox1 = xy1.X;
            int doy1 = xy1.Y;
            int dox2 = xy2.X;
            int doy2 = xy2.Y;
            MoveMouse(dox1, doy1);
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_LEFTDOWN, dox1, doy1, 0, 0);
            Thread.Sleep(2000);
            for (int i = doy1; i > doy2; i -= 5)
            {
                MoveMouse(dox1, i);
                Thread.Sleep(70);
            }
            Thread.Sleep(1000);
            MoveMouse(dox2, doy2);
            Thread.Sleep(2000);
            mouse_event(MOUSEEVENTF_LEFTUP, dox2, doy2, 0, 0);
            Thread.Sleep(1000);
        }

        private void DragnDropGarage(Point xy1, Point xy2)
        {
            int dox1 = xy1.X;
            int doy1 = xy1.Y;
            int dox2 = xy2.X;
            int doy2 = xy2.Y;
            MoveMouse(dox1, doy1);
            Thread.Sleep(100);
            mouse_event(MOUSEEVENTF_LEFTDOWN, dox1, doy1, 0, 0);
            Thread.Sleep(2000);
            for (int i = doy1; i < doy2; i += 8)
            {
                MoveMouse(dox1, i);
                Thread.Sleep(60);
            }
            Thread.Sleep(1000);
            MoveMouse(dox2, doy2);
            Thread.Sleep(2000);
            mouse_event(MOUSEEVENTF_LEFTUP, dox2, doy2, 0, 0);
            Thread.Sleep(1000);
        }

        private void Clk(int dox, int doy)
        {            
            MoveMouse(dox, doy);
            Thread.Sleep(100);
            DoMouseLeftClick(dox, doy);
        }

        [DllImport("User32.dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("User32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;

            public int y;
        }
        
        private string PixelIndicator(Point p)
        {            
            int colourDepth = Screen.PrimaryScreen.BitsPerPixel;
            PixelFormat format;
            switch (colourDepth)
            {
                case 8:
                case 16:
                    format = PixelFormat.Format16bppRgb565;
                    break;

                case 24:
                    format = PixelFormat.Format24bppRgb;
                    break;

                case 32:
                    format = PixelFormat.Format32bppArgb;
                    break;

                default:
                    format = PixelFormat.Format32bppArgb;
                    break;
            }
            Bitmap indicator = new Bitmap(1, 1, format);
            Graphics gdi = Graphics.FromImage(indicator);
            gdi.CopyFromScreen(p.X, p.Y, 0, 0, new Size(1, 1));
            string pix = indicator.GetPixel(0, 0).ToString(); 
            gdi.Dispose();
            indicator.Dispose();
            return pix;
        }

        private void UniversalCapture(Rectangle bounds, string PATH)
        {            
            int colourDepth = Screen.PrimaryScreen.BitsPerPixel;
            PixelFormat format;
            switch (colourDepth)
            {
                case 8:
                case 16:
                    format = PixelFormat.Format16bppRgb565;
                    break;

                case 24:
                    format = PixelFormat.Format24bppRgb;
                    break;

                case 32:
                    format = PixelFormat.Format32bppArgb;
                    break;

                default:
                    format = PixelFormat.Format32bppArgb;
                    break;
            }
            captured = new Bitmap(bounds.Width, bounds.Height, format);
            Graphics gdi = Graphics.FromImage(captured);
            gdi.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
            if (captured != null)
            {
                captured.Save("C:\\Users\\Public\\test\\" + PATH + ".jpg", ImageFormat.Jpeg);
                Console.WriteLine("Создал " + PATH);
            }
            gdi.Dispose();
            captured.Dispose();            
        }

        private void DoLog(string text)
        {            
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Public\test\Log.txt", true, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine(text + "  " + DateTime.Now.ToLongTimeString());
                sw.Close(); 
            }
        }
        
        private void Saves(int rq, int condition, int tires, int[] carsid)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Public\test\Saves.txt", false, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine(rq);
                sw.WriteLine(condition);
                sw.WriteLine(tires);
                for (int i = 0; i < 5; i++)
                {
                    sw.WriteLine(carsid[i]);
                }
                sw.Close();
            }
        }

        private int[] ReadSaves()
        {
            int[] a = new int[8];
            using(StreamReader sr = new StreamReader(@"C:\Users\Public\test\Saves.txt", System.Text.Encoding.Default))
            {
                for(int i = 0; i < 8; i++)
                {
                    a[i] = Convert.ToInt32(sr.ReadLine());//rq, condition, tires, carsid(5)
                }
                sr.Close();
            }
            return a;
        }

        private void ClearLog()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Public\test\Log.txt", false, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine("Начинаю новую сессию");
                sw.Close();
            }
        }
        
        private int WhichEvent()
        {
            int filename;
            Random rand1 = new Random();
            int eventName = 0;
            UniversalCapture(EventNameBounds, EventNamePath);            
            for (int i = 1; i < 40; i++)
            {
                if (Verify(EventNamePath, "Coverage\\" + i.ToString()))
                {
                    eventName = i;
                    DoLog("Название эвента =  " + i);
                    break;
                }                 
            }  

            if(eventName == 0)
            {
                DoLog("Неизвестный эвент");
                do
                {
                    filename = rand1.Next(10000);
                } while (File.Exists("C:\\Users\\Public\\test\\Coverage\\UnknownEventName" + filename + ".jpg"));
                File.Move("C:\\Users\\Public\\test\\" + EventNamePath + ".jpg", "C:\\Users\\Public\\test\\Coverage\\UnknownEventName" + filename + ".jpg");
                DoLog("Сделал скрин");
            }
            
            return eventName;
        }

        private int GotRQ()
        {
            Random rand = new Random();
            int filename;
            int rq = 0;
            UniversalCapture(RQBounds, RQPath);
            for(int i = 18; i < 151; i++)
            {
                if(Verify(RQPath, i.ToString()))
                {
                    rq = i;
                    DoLog("рк =  " + rq);
                    break;
                }
            }

            if(rq == 0)
            {
                DoLog("неизвестное рк");
                do
                {
                    filename = rand.Next(100);
                } while (File.Exists("C:\\Users\\Public\\test\\UnknownRQ" + filename + ".jpg"));
                File.Move("C:\\Users\\Public\\test\\TestRQ.jpg", "C:\\Users\\Public\\test\\UnknownRQ" + filename + ".jpg");
                DoLog("Сделал скрин");
            }

            return rq;
        }

        private bool Verify(string PATH, string ORIGINALPATH)
        {
            Console.WriteLine("Начал проверку " + PATH);
            Bitmap picturetest = new Bitmap("C:\\Users\\Public\\test\\" + PATH + ".jpg");
            Bitmap picture = new Bitmap("C:\\Users\\Public\\test\\" + ORIGINALPATH + ".jpg");
            bool flag1 = true;          
            for (int x = 0; x < picturetest.Width; x++) 
            {
                if (flag1 == true)
                {
                    for (int y = 0; y < picturetest.Height; y++)
                    {
                        /*Console.Write("сравниваю пиксель " + x + " " + y + " " + DateTime.Now.ToLongTimeString() + " ");
                        Console.Write(picturetest.GetPixel(x, y) + " ");
                        Console.Write(picture.GetPixel(x, y) + " ");*/
                        if (picturetest.GetPixel(x, y) != picture.GetPixel(x, y))
                        /*{
                            Console.WriteLine("совпали");                            
                        }                        
                        else*/
                        {
                            Console.WriteLine("разные");
                            flag1 = false;                            
                            break;
                        }                        
                    }
                }              
            }            
            picturetest.Dispose();
            picture.Dispose();
            return flag1;
        }
        
        private void MoveMouse(int x, int y)
        {
            POINT p = new POINT();

            p.x = x;

            p.y = y;

            ClientToScreen(Handle, ref p);

            SetCursorPos(p.x, p.y);            
        }

        private void ClearHand()
        {
            Point HandSlot1 = new Point(170, 770);
            Point HandSlot2 = new Point(350, 770);
            Point HandSlot3 = new Point(540, 770);
            Point HandSlot4 = new Point(730, 770);
            Point HandSlot5 = new Point(910, 770);

            Point[] a = new Point[] { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };
            for(int i = 0; i < 5; i++)
            {                
                    MoveMouse(a[i].X, a[i].Y);
                    Thread.Sleep(100);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, a[i].X, a[i].Y, 0, 0);
                    Thread.Sleep(1500);
                    for (int l = a[i].Y; l > 500; l -= 10)
                    {
                        MoveMouse(a[i].X, l);
                        Thread.Sleep(80);
                    }
                    Thread.Sleep(1000);
                    MoveMouse(a[i].X, 500);
                    Thread.Sleep(2000);
                    mouse_event(MOUSEEVENTF_LEFTUP, a[i].X, 500, 0, 0);
                    Thread.Sleep(1000);                   
            }
        }

        private void Randomizer(int condition, int rq, int tires)
        {
            Point r1 = new Point(115, 415);//rarity
            Point r2 = new Point(115, 480);//rq
            Point r3 = new Point(115, 545);//max speed
            Point r4 = new Point(115, 610);//0-60
            Point r5 = new Point(440, 415);//handling
            Point r6 = new Point(440, 480);//wheels drive
            Point r7 = new Point(440, 545);//country
            Point r8 = new Point(440, 610);//width
            Point r9 = new Point(765, 415);//height
            Point r10 = new Point(765, 480);//weight
            Point[] a = new Point[] { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10 };
            Random rand = new Random();
            Point p = new Point();
            while (!InGarage()) Thread.Sleep(2000);
            switch (condition)
            {
                case 2:
                    if (rq < 70)
                    {
                        DoLog("сортирую по рк");
                        Thread.Sleep(200);
                        Clk(1075, 275);//сортировка
                        Thread.Sleep(1000);
                        Clk(250, 785);//сброс
                        Thread.Sleep(1000);
                        Clk(1075, 275);//сортировка
                        Thread.Sleep(1000);
                        Clk(115, 480);//сортировка по рк                                               
                    }
                    else
                    {
                        Thread.Sleep(200);
                        Clk(1075, 275);//сортировка
                        Thread.Sleep(1000);
                        switch (tires)
                        {
                            case 26:
                            case 25:
                            case 7:
                                if (rand.Next(2) == 1)
                                {
                                    p = r5;
                                    Clk(p.X, p.Y);//выбрать условие
                                    Thread.Sleep(200);
                                }
                                else p = r10;
                                Clk(p.X, p.Y);//выбрать условие                                  
                                break;

                            case 22:
                            case 20:
                            case 18:
                            case 16:
                                if (rand.Next(2) == 1)
                                {
                                    p = r3;
                                    Clk(p.X, p.Y);//выбрать условие
                                    Thread.Sleep(200);
                                }
                                else p = r4;
                                Clk(p.X, p.Y);//выбрать условие         
                                break;

                            default:
                                int r = rand.Next(10);
                                p = a[r];
                                switch (r + 1)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 5:
                                        Clk(p.X, p.Y);//выбрать условие
                                        Thread.Sleep(200);
                                        Clk(p.X, p.Y);//выбрать условие                                
                                        break;

                                    case 4:
                                    case 9:
                                    case 10:
                                        Clk(p.X, p.Y);//выбрать условие                                
                                        break;

                                    default:
                                        if (rand.Next(2) == 1)
                                        {
                                            Clk(p.X, p.Y);//выбрать условие
                                            Thread.Sleep(200);
                                        }
                                        Clk(p.X, p.Y);//выбрать условие                                
                                        break;
                                }
                                break;
                        }
                    }
                    break;

                case 15:
                    if (rq < 50)
                    {
                        DoLog("сортирую по рк");
                        Thread.Sleep(200);
                        Clk(1075, 275);//сортировка
                        Thread.Sleep(1000);
                        Clk(250, 785);//сброс
                        Thread.Sleep(1000);                        
                        Clk(1075, 275);//сортировка
                        Thread.Sleep(1000);
                        Clk(115, 480);//сортировка по рк                       
                    }
                    else
                    {
                        Thread.Sleep(200);
                        Clk(1075, 275);//сортировка
                        Thread.Sleep(1000);
                        switch (tires)
                        {
                            case 26:
                            case 25:
                            case 7:
                                if (rand.Next(2) == 1)
                                {
                                    p = r5;
                                    Clk(p.X, p.Y);//выбрать условие
                                    Thread.Sleep(200);
                                }
                                else p = r10;
                                Clk(p.X, p.Y);//выбрать условие                                  
                                break;

                            case 22:
                            case 20:
                            case 18:
                            case 16:
                                if (rand.Next(2) == 1)
                                {
                                    p = r3;
                                    Clk(p.X, p.Y);//выбрать условие
                                    Thread.Sleep(200);
                                }
                                else p = r4;
                                Clk(p.X, p.Y);//выбрать условие         
                                break;

                            default:
                                int r = rand.Next(10);
                                p = a[r];
                                switch (r + 1)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 5:
                                        Clk(p.X, p.Y);//выбрать условие
                                        Thread.Sleep(200);
                                        Clk(p.X, p.Y);//выбрать условие                                
                                        break;

                                    case 4:
                                    case 9:
                                    case 10:
                                        Clk(p.X, p.Y);//выбрать условие                                
                                        break;

                                    default:
                                        if (rand.Next(2) == 1)
                                        {
                                            Clk(p.X, p.Y);//выбрать условие
                                            Thread.Sleep(200);
                                        }
                                        Clk(p.X, p.Y);//выбрать условие                                
                                        break;
                                }
                                break;
                        }
                    }
                    break;

                default:
                    if (rq < 30)
                    {
                        DoLog("сортирую по рк");
                        Thread.Sleep(200);
                        Clk(1075, 275);//сортировка
                        Thread.Sleep(1000);
                        Clk(250, 785);//сброс
                        Thread.Sleep(1000);
                        Clk(1075, 275);//сортировка
                        Thread.Sleep(1000);
                        Clk(115, 480);//сортировка по рк                                               
                    }                  
                    
                    else
                    {
                        Thread.Sleep(200);
                        Clk(1075, 275);//сортировка
                        Thread.Sleep(1000);
                        switch (tires)
                        {
                            case 26:
                            case 25:
                            case 7:                                
                                if (rand.Next(2) == 1) 
                                {
                                    p = r5;
                                    Clk(p.X, p.Y);//выбрать условие
                                    Thread.Sleep(200);
                                }
                                else p = r10;
                                Clk(p.X, p.Y);//выбрать условие                                  
                                break;

                            case 22:
                            case 20:
                            case 18:
                            case 16:
                                if (rand.Next(2) == 1)
                                {
                                    p = r3;
                                    Clk(p.X, p.Y);//выбрать условие
                                    Thread.Sleep(200);
                                }
                                else p = r4;
                                Clk(p.X, p.Y);//выбрать условие         
                                break;

                            default:                                
                                int r = rand.Next(10);
                                p = a[r];
                                switch (r + 1)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 5:
                                        Clk(p.X, p.Y);//выбрать условие
                                        Thread.Sleep(200);
                                        Clk(p.X, p.Y);//выбрать условие                                
                                        break;

                                    case 4:
                                    case 9:
                                    case 10:
                                        Clk(p.X, p.Y);//выбрать условие                                
                                        break;

                                    default:
                                        if (rand.Next(2) == 1)
                                        {
                                            Clk(p.X, p.Y);//выбрать условие
                                            Thread.Sleep(200);
                                        }
                                        Clk(p.X, p.Y);//выбрать условие                                
                                        break;
                                }
                                break;
                        }                                                       
                    }
                    break;
            }
            Thread.Sleep(500);
            Clk(825, 775);//закрыть сортировку
            Thread.Sleep(4000);
        }

        private bool CarFixed(int slot)
        {
            Rectangle Car1Bounds = new Rectangle(400, 370, 200, 20);
            Rectangle Car2Bounds = new Rectangle(400, 560, 200, 20);
            Rectangle Car3Bounds = new Rectangle(705, 370, 200, 20);
            Rectangle Car4Bounds = new Rectangle(705, 560, 200, 20);

            Rectangle Car5Bounds = new Rectangle(635, 370, 200, 20);
            Rectangle Car6Bounds = new Rectangle(635, 560, 200, 20);

            Rectangle Car7Bounds = new Rectangle(635, 370, 200, 20);
            Rectangle Car8Bounds = new Rectangle(635, 560, 200, 20);
            ///---------
            Rectangle Car9Bounds = new Rectangle(655, 370, 200, 20);
            Rectangle Car10Bounds = new Rectangle(655, 560, 200, 20);
            Rectangle[] bounds = new Rectangle[] { Car1Bounds, Car2Bounds, Car3Bounds, Car4Bounds, Car5Bounds, Car6Bounds, Car7Bounds, Car8Bounds, Car9Bounds, Car10Bounds };
            string[] n = new string[] { "1car", "2car", "3car", "4car", "5car", "6car", "7car", "8car", "9car", "10car" };
            UniversalCapture(bounds[slot], n[slot] + "0");
            Thread.Sleep(1700);//на 1500 еще ошибается
            UniversalCapture(bounds[slot], n[slot] + "1");
            return Verify(n[slot] + "0", n[slot] + "1");
        }

        private bool HandCarFixed()
        {
            Rectangle finger1Bounds = new Rectangle(115, 750, 100, 35);
            Rectangle finger2Bounds = new Rectangle(300, 750, 100, 35);
            Rectangle finger3Bounds = new Rectangle(485, 750, 100, 35);
            Rectangle finger4Bounds = new Rectangle(670, 750, 100, 35);
            Rectangle finger5Bounds = new Rectangle(860, 750, 100, 35);
            bool x = true;
            Rectangle[] bounds = new Rectangle[] { finger1Bounds, finger2Bounds, finger3Bounds, finger4Bounds, finger5Bounds };
            string[] n = new string[] { "finger1", "finger2", "finger3", "finger4", "finger5"};
            for(int i = 0; i < 5; i++)
            {
                UniversalCapture(bounds[i], n[i] + "0");
            }            
            Thread.Sleep(1700); //1100 мало
            for (int j = 0; j < 5; j++)
            {
                UniversalCapture(bounds[j], n[j] + "1");
            }

            for (int k = 0; k < 5; k++)
            {
                if(!Verify(n[k] + "0", n[k] + "1"))
                {
                    DoLog("Тачка на " + (k + 1) + " месте неисправна");
                    x = false;
                    break;
                }
            }
            return x;
        }

        private bool EmptyGarageSlot(int n)
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
            string[] b = {
                "Color [A=255, R=78, G=104, B=118]",
                "Color [A=255, R=80, G=105, B=119]",
                "Color [A=255, R=75, G=97, B=111]",
                "Color [A=255, R=72, G=96, B=107]",
                "Color [A=255, R=75, G=95, B=106]",
                "Color [A=255, R=74, G=94, B=105]"
            };

            string[] c = {
                "Color [A=255, R=72, G=102, B=118]",
                "Color [A=255, R=74, G=103, B=120]",
                "Color [A=255, R=68, G=94, B=110]",
                "Color [A=255, R=65, G=92, B=105]",
                "Color [A=255, R=68, G=91, B=104]",
                "Color [A=255, R=67, G=90, B=103]"
            };

            if (PixelIndicator(a[n]) == b[n] || PixelIndicator(a[n]) == c[n])
            {
                x = false;
            }
            return x;
        }

        private bool VerifyBW(string PATH, string ORIGINALPATH, int maxdiffernces)
        {
            //Console.WriteLine("Начал проверку " + PATH);
            Bitmap picturetest = new Bitmap("C:\\Users\\Public\\test\\" + PATH + ".jpg");
            Bitmap picture = new Bitmap("C:\\Users\\Public\\test\\" + ORIGINALPATH + ".jpg");
            bool flag1 = true;
            int differences = 0;
            for (int x = 0; x < picturetest.Width; x++)
            {
                if (flag1 == true)
                {
                    for (int y = 0; y < picturetest.Height; y++)
                    {
                        //Console.Write("сравниваю пиксель " + x + " " + y + " " + DateTime.Now.ToLongTimeString() + " ");
                        //Console.Write(picturetest.GetPixel(x, y) + " ");
                        //Console.Write(picture.GetPixel(x, y) + " ");
                        if (Math.Abs((int)picturetest.GetPixel(x, y).R - (int)picture.GetPixel(x, y).R) < 200)
                        {
                            //Console.WriteLine("совпали");
                        }
                        else
                        {
                            //Console.WriteLine("разные");
                            differences++;
                            if(differences == maxdiffernces)
                            {
                                flag1 = false;
                                break;
                            }                            
                        }
                    }
                }
            }
            picturetest.Dispose();
            picture.Dispose();
            return flag1;
        }

        private void TrackCapture(Rectangle bounds, string PATH)
        {
            int colourDepth = Screen.PrimaryScreen.BitsPerPixel;
            PixelFormat format;
            switch (colourDepth)
            {
                case 8:
                case 16:
                    format = PixelFormat.Format16bppRgb565;
                    break;

                case 24:
                    format = PixelFormat.Format24bppRgb;
                    break;

                case 32:
                    format = PixelFormat.Format32bppArgb;
                    break;

                default:
                    format = PixelFormat.Format32bppArgb;
                    break;
            }
            captured = new Bitmap(bounds.Width, bounds.Height, format);
            Bitmap BW = new Bitmap(bounds.Width, bounds.Height, format);
            Graphics gdi = Graphics.FromImage(captured);
            gdi.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
            for (int row = 0; row < captured.Width; row++) // Indicates row number
            {
                for (int column = 0; column < captured.Height; column++) // Indicate column number
                {
                    var colorValue = captured.GetPixel(row, column); // Get the color pixel
                    //Console.WriteLine(colorValue);
                    var averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G) / 3; // get the average for black and white
                    if (averageValue > 220) averageValue = 255;
                    else averageValue = 0;
                    BW.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel
                }
            }

            BW.Save("C:\\Users\\Public\\test\\" + PATH + ".jpg", ImageFormat.Jpeg); // Save the black ad white image            
            //Console.WriteLine("Создал " + PATH);

            gdi.Dispose();
            captured.Dispose();
            BW.Dispose();
        }

        private void BW2Capture(Rectangle bounds, string PATH)
        {
            int colourDepth = Screen.PrimaryScreen.BitsPerPixel;
            PixelFormat format;
            switch (colourDepth)
            {
                case 8:
                case 16:
                    format = PixelFormat.Format16bppRgb565;
                    break;

                case 24:
                    format = PixelFormat.Format24bppRgb;
                    break;

                case 32:
                    format = PixelFormat.Format32bppArgb;
                    break;

                default:
                    format = PixelFormat.Format32bppArgb;
                    break;
            }
            captured = new Bitmap(bounds.Width, bounds.Height, format);
            Bitmap BW = new Bitmap(bounds.Width, bounds.Height, format);
            Graphics gdi = Graphics.FromImage(captured);
            gdi.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
            for (int row = 0; row < captured.Width; row++) // Indicates row number
            {
                for (int column = 0; column < captured.Height; column++) // Indicate column number
                {
                    var colorValue = captured.GetPixel(row, column); // Get the color pixel
                    //Console.WriteLine(colorValue);                    
                    var averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G) / 3; // get the average for black and white
                    if (averageValue > 200) averageValue = 255;
                    else averageValue = 0;
                    BW.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel
                }
            }

            BW.Save("C:\\Users\\Public\\test\\" + PATH + ".jpg", ImageFormat.Jpeg); // Save the black ad white image            
            //Console.WriteLine("Создал " + PATH);

            gdi.Dispose();
            captured.Dispose();
            BW.Dispose();
        }

        private int[] Tracks()
        {
            Rectangle Track1 = new Rectangle(170, 520, 155, 40);
            Rectangle Track2 = new Rectangle(365, 520, 155, 40);
            Rectangle Track3 = new Rectangle(560, 520, 155, 40);
            Rectangle Track4 = new Rectangle(755, 520, 155, 40);
            Rectangle Track5 = new Rectangle(955, 520, 155, 40);

            int n;
            bool flag;                      
            Rectangle[] a = { Track1, Track2, Track3, Track4, Track5 };
            int[] a1 = new int[5];           
            
            for (int i = 0; i < 5; i++)
            {
                flag = true;
                TrackCapture(a[i], ("Track" + (i + 1) + "\\test"));               
                n = 0;
                for (int i1 = 1; i1 < 100; i1++)
                {
                    if (File.Exists("C:\\Users\\Public\\test\\Track" + (i+1) + "\\" + i1 + ".jpg"))
                    {
                        n = i1;
                    }
                    else break;
                }

                for (int i2 = 1; i2 < (n+1); i2++)
                {
                    if (VerifyBW(("Track" + (i+1) + "\\" + i2), ("Track" + (i+1) + "\\test"), 120))
                    {
                        //DoLog("На " + (i+1) + " месте " + i2 + " трэк");
                        a1[i] = i2;
                        File.Delete("C:\\Users\\Public\\test\\Track" + (i+1) + "\\test.jpg");
                        flag = false;
                        break;
                    }
                }

                if(flag == true)
                {
                    a1[i] = 0;
                    DoLog("Добавляю новый трэк");
                    File.Move("C:\\Users\\Public\\test\\Track" + (i+1) + "\\test.jpg", "C:\\Users\\Public\\test\\Track" + (i+1) + "\\" + (n+1) + ".jpg");                    
                }
            }       

            return a1;
        }

        private int[] Grounds()
        {
            Rectangle Ground1 = new Rectangle(210, 600, 110, 35);
            Rectangle Ground2 = new Rectangle(407, 600, 110, 35);
            Rectangle Ground3 = new Rectangle(604, 600, 110, 35);
            Rectangle Ground4 = new Rectangle(801, 600, 110, 35);
            Rectangle Ground5 = new Rectangle(1000, 600, 110, 35);

            Rectangle[] b = { Ground1, Ground2, Ground3, Ground4, Ground5 };
            int n;
            bool flag;
            int[] b1 = new int[5];
            for (int i = 0; i < 5; i++)
            {
                flag = true;
                BW2Capture(b[i], ("Ground" + (i + 1) + "\\test"));
                n = 0;
                for (int i1 = 1; i1 < 100; i1++)
                {
                    if (File.Exists("C:\\Users\\Public\\test\\Ground" + (i + 1) + "\\" + i1 + ".jpg"))
                    {
                        n = i1;
                    }
                    else break;
                }

                for (int i2 = 1; i2 < (n + 1); i2++)
                {
                    if (VerifyBW(("Ground" + (i + 1) + "\\" + i2), ("Ground" + (i + 1) + "\\test"), 150))
                    {
                        //DoLog("На " + (i + 1) + " месте " + i2 + " покрытие");
                        b1[i] = i2;
                        File.Delete("C:\\Users\\Public\\test\\Ground" + (i + 1) + "\\test.jpg");
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    b1[i] = 0;
                    DoLog("Добавляю новое покрытие");
                    File.Move("C:\\Users\\Public\\test\\Ground" + (i + 1) + "\\test.jpg", "C:\\Users\\Public\\test\\Ground" + (i + 1) + "\\" + (n + 1) + ".jpg");
                }
            }

            return b1;
        }

        private int[] Weathers()
        {
            Rectangle Weather1 = new Rectangle(210, 563, 70, 28);
            Rectangle Weather2 = new Rectangle(407, 563, 70, 28);
            Rectangle Weather3 = new Rectangle(604, 563, 70, 28);
            Rectangle Weather4 = new Rectangle(801, 563, 70, 28);
            Rectangle Weather5 = new Rectangle(1000, 563, 70, 28);

            Rectangle[] c = { Weather1, Weather2, Weather3, Weather4, Weather5 };
            int n;
            bool flag;
            int[] c1 = new int[5];

            for (int i = 0; i < 5; i++)
            {
                flag = true;
                BW2Capture(c[i], ("Weather" + (i + 1) + "\\test"));
                n = 0;
                for (int i1 = 1; i1 < 20; i1++)
                {
                    if (File.Exists("C:\\Users\\Public\\test\\Weather" + (i + 1) + "\\" + i1 + ".jpg"))
                    {
                        n = i1;
                    }
                    else break;
                }

                for (int i2 = 1; i2 < (n + 1); i2++)
                {
                    if (VerifyBW(("Weather" + (i + 1) + "\\" + i2), ("Weather" + (i + 1) + "\\test"), 30))
                    {
                        //DoLog("На " + (i + 1) + " месте " + i2 + " погода");
                        c1[i] = i2;
                        File.Delete("C:\\Users\\Public\\test\\Weather" + (i + 1) + "\\test.jpg");
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    c1[i] = 0;
                    DoLog("Добавляю новую погоду");
                    File.Move("C:\\Users\\Public\\test\\Weather" + (i + 1) + "\\test.jpg", "C:\\Users\\Public\\test\\Weather" + (i + 1) + "\\" + (n + 1) + ".jpg");
                }
            }

            return c1;
        }

        private string[,] TrackPackage(string[] a2, string[] b2, string[] c2)
        {
            string[,] d = new string[3, 5];
            for(int i = 0; i < 5; i++)
            {
                d[0, i] = a2[i];
                d[1, i] = b2[i];
                d[2, i] = c2[i];
            }
            for (int i = 0; i < 5; i++)
            {
                DoLog((i + 1) + " Трэк: " + d[0, i] + " " + d[1, i] + " " + d[2,i]);
            }

            return d;
        }

        private string[] IdentifyGround(int[] b1)
        {
            string[] b2 = new string[5];
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        switch (b1[i])
                        {
                            case 1:
                                b2[i] = "Асфальт";
                                break;
                            case 2:
                                b2[i] = "Грунт";
                                break;
                            case 3:
                                b2[i] = "Гравий";
                                break;
                            case 4:
                                b2[i] = "Песок";
                                break;
                            case 5:
                                b2[i] = "Трава";
                                break;
                            case 6:
                                b2[i] = "Снег";
                                break;
                            case 7:
                                b2[i] = "Смешанное";
                                break;
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                    case 1:
                        switch (b1[i])
                        {
                            case 1:
                                b2[i] = "Асфальт";
                                break;
                            case 2:
                                b2[i] = "Гравий";
                                break;
                            case 3:
                                b2[i] = "Грунт";
                                break;
                            case 4:
                                b2[i] = "Песок";
                                break;
                            case 5:
                                b2[i] = "Трава";
                                break;
                            case 6:
                                b2[i] = "Лед";
                                break;
                            case 7:
                                b2[i] = "Снег";
                                break;
                            case 8:
                                b2[i] = "Смешанное";
                                break;
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                    case 2:
                        switch (b1[i])
                        {
                            case 1:
                                b2[i] = "Асфальт";
                                break;
                            case 2:
                                b2[i] = "Асфальт";
                                break;
                            case 3:
                                b2[i] = "Снег";
                                break;
                            case 4:
                                b2[i] = "Гравий";
                                break;
                            case 5:
                                b2[i] = "Грунт";
                                break;
                            case 6:
                                b2[i] = "Трава";
                                break;
                            case 7:
                                b2[i] = "Смешанное";
                                break;
                            case 8:
                                b2[i] = "Лед";
                                break;
                            case 9:
                                b2[i] = "Песок";
                                break;
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                    case 3:
                        switch (b1[i])
                        {
                            case 1:
                                b2[i] = "Асфальт";
                                break;
                            case 2:
                                b2[i] = "Песок";
                                break;
                            case 3:
                                b2[i] = "Снег";
                                break;
                            case 4:
                                b2[i] = "Смешанное";
                                break;
                            case 5:
                                b2[i] = "Грунт";
                                break;
                            case 6:
                                b2[i] = "Трава";
                                break;
                            case 7:
                                b2[i] = "Гравий";
                                break;
                            case 8:
                                b2[i] = "Лед";
                                break;
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                    case 4:
                        switch (b1[i])
                        {
                            case 1:
                                b2[i] = "Асфальт";
                                break;
                            case 2:
                                b2[i] = "Грунт";
                                break;
                            case 3:
                                b2[i] = "Гравий";
                                break;
                            case 4:
                                b2[i] = "Снег";
                                break;
                            case 5:
                                b2[i] = "Смешанное";
                                break;
                            case 6:
                                b2[i] = "Песок";
                                break;
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                }
            }
            return b2;
        }

        private string[] IdentifyWeather(int[] c1)
        {
            string[] c2 = new string[5];
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        switch (c1[i])
                        {
                            case 1:
                                c2[i] = "Дождь";
                                break;
                            case 2:
                                c2[i] = "Солнечно";
                                break;
                            case 3:
                                c2[i] = "Дождь";
                                break;
                            case 4:
                                c2[i] = "Солнечно";
                                break;
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
                    case 1:
                        switch (c1[i])
                        {
                            case 1:
                                c2[i] = "Дождь";
                                break;
                            case 2:
                                c2[i] = "Солнечно";
                                break;
                            case 3:
                                c2[i] = "Солнечно";
                                break;
                            case 4:
                                c2[i] = "Дождь";
                                break;
                            case 5:
                                c2[i] = "Солнечно";
                                break;
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
                    case 2:
                        switch (c1[i])
                        {
                            case 1:
                                c2[i] = "Дождь";
                                break;
                            case 2:
                                c2[i] = "Солнечно";
                                break;
                            case 3:
                                c2[i] = "Солнечно";
                                break;
                            case 4:
                                c2[i] = "Солнечно";
                                break;
                            case 5:
                                c2[i] = "Солнечно";
                                break;
                            case 6:
                                c2[i] = "Дождь";
                                break;
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
                    case 3:
                        switch (c1[i])
                        {
                            case 1:
                                c2[i] = "Дождь";
                                break;
                            case 2:
                                c2[i] = "Солнечно";
                                break;
                            case 3:
                                c2[i] = "Солнечно";
                                break;
                            case 4:
                                c2[i] = "Дождь";
                                break;
                            case 5:
                                c2[i] = "Солнечно";
                                break;
                            case 6:
                                c2[i] = "Солнечно";
                                break;
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
                    case 4:
                        switch (c1[i])
                        {
                            case 1:
                                c2[i] = "Дождь";
                                break;
                            case 2:
                                c2[i] = "Солнечно";
                                break;
                            case 3:
                                c2[i] = "Солнечно";
                                break;
                            case 4:
                                c2[i] = "Солнечно";
                                break;
                            case 5:
                                c2[i] = "Дождь";
                                break;
                            case 6:
                                c2[i] = "Дождь";
                                break;
                            case 7:
                                c2[i] = "Солнечно";
                                break;
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
                }
            }
            return c2;
        }

        private string[] IdentifyTracks(int[] a1)
        {
            string[] a2 = new string[5];
            for(int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        switch (a1[i])
                        {
                            case 1:
                                a2[i] = "Улица ср";
                                break;
                            case 2:
                                a2[i] = "Улица мал";
                                break;
                            case 3:
                                a2[i] = "1/4";
                                break;
                            case 4:
                                a2[i] = "Серпантин";
                                break;
                            case 5:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 6:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 7:
                                a2[i] = "Лесная дорога";
                                break;
                            case 8:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 9:
                                a2[i] = "Перегрузка";
                                break;
                            case 10:
                                a2[i] = "Слалом";
                                break;
                            case 11:
                                a2[i] = "0-100";
                                break;
                            case 12:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 13:
                                a2[i] = "Ралли-кросс ср.";
                                break;
                            case 14:
                                a2[i] = "Токио трасса";
                                break;
                            case 15:
                                a2[i] = "Токио петля";
                                break;
                            case 16:
                                a2[i] = "Токио мост";
                                break;
                            case 17:
                                a2[i] = "Токио перегрузки";
                                break;
                            case 18:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 19:
                                a2[i] = "Парковка";
                                break;
                            case 20:
                                a2[i] = "Каньон экспедиция";
                                break;
                            case 21:
                                a2[i] = "Обзор";
                                break;
                            case 22:
                                a2[i] = "Мотокросс";
                                break;
                            case 23:
                                a2[i] = "Подъем на холм";
                                break;
                            case 24:
                                a2[i] = "Ралли-кросс мал";
                                break;
                            case 25:
                                a2[i] = "Трасса набережная";
                                break;
                            case 26:
                                a2[i] = "Тестовый круг";
                                break;
                            case 27:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 28:
                                a2[i] = "1";
                                break;
                            case 29:
                                a2[i] = "Монако серпантин";
                                break;
                            case 30:
                                a2[i] = "Монако городские улицы";
                                break;
                            case 31:
                                a2[i] = "Highway";
                                break;
                            case 32:
                                a2[i] = "Лесной слалом";
                                break;
                            case 33:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 34:
                                a2[i] = "Лесная переправа";
                                break;
                            case 35:
                                a2[i] = "Тест на перегрузки";
                                break;
                            case 36:
                                a2[i] = "0-100-0";
                                break;
                            case 37:
                                a2[i] = "Крутой холм";
                                break;
                            default:
                                a2[i] = "Неизвестная трасса";
                                break;
                        }           
                        break;

                    case 1:
                        switch (a1[i])
                        {
                            case 1:
                                a2[i] = "Улица мал";
                                break;
                            case 2:
                                a2[i] = "0-100";
                                break;
                            case 3:
                                a2[i] = "1/4";
                                break;
                            case 4:
                                a2[i] = "Тестовый круг";
                                break;
                            case 5:
                                a2[i] = "Серпантин";
                                break;
                            case 6:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 7:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 8:
                                a2[i] = "Лесная дорога";
                                break;
                            case 9:
                                a2[i] = "Лесная дорога";
                                break;
                            case 10:
                                a2[i] = "Каньон грунтовая дорога";
                                break;
                            case 11:
                                a2[i] = "Парковка";
                                break;
                            case 12:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 13:
                                a2[i] = "Улица ср";
                                break;
                            case 14:
                                a2[i] = "Лесной слалом";
                                break;
                            case 15:
                                a2[i] = "Слалом";
                                break;                          
                            case 16:
                                a2[i] = "Слалом";
                                break;
                            case 17:
                                a2[i] = "Перегрузка";
                                break;
                            case 18:
                                a2[i] = "Ралли-кросс ср";
                                break;
                            case 19:
                                a2[i] = "Ралли-кросс мал";
                                break;
                            case 20:
                                a2[i] = "1";
                                break;
                            case 21:
                                a2[i] = "Токио мост";
                                break;
                            case 22:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 23:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 24:
                                a2[i] = "Токио тест на перегрузки";
                                break;
                            case 25:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 26:
                                a2[i] = "Грунтовая дорога";
                                break;
                            case 27:
                                a2[i] = "Замерзшее озеро";
                                break;
                            case 28:
                                a2[i] = "1/2";
                                break;
                            case 29:
                                a2[i] = "0-100-0";
                                break;
                            case 30:
                                a2[i] = "Монако серпантин";
                                break;
                            case 31:
                                a2[i] = "Монако тест на перегрузки";
                                break;
                            case 32:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 33:
                                a2[i] = "Токио съезд";
                                break;
                            case 34:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 35:
                                a2[i] = "Мотокросс";
                                break;
                            case 36:
                                a2[i] = "Трасса набережная";
                                break;
                            case 37:
                                a2[i] = "Монако узкие улицы";
                                break;
                            case 38:
                                a2[i] = "Highway";
                                break;
                            case 39:
                                a2[i] = "Лесная переправа";
                                break;
                            case 40:
                                a2[i] = "1/2";
                                break;
                            case 41:
                                a2[i] = "Тестовый круг";
                                break;
                            case 42:
                                a2[i] = "Подъем на холм";
                                break;
                            case 43:
                                a2[i] = "Подъем на холм";
                                break;
                            default:
                                a2[i] = "Неизвестная трасса";
                                break;
                        }
                        break;
                    case 2:
                        switch (a1[i])
                        {
                            case 1:
                                a2[i] = "Подъем на холм";
                                break;
                            case 2:
                                a2[i] = "Подъем на холм";
                                break;
                            case 3:
                                a2[i] = "1";
                                break;
                            case 4:
                                a2[i] = "1/2";
                                break;
                            case 5:
                                a2[i] = "Серпантин";
                                break;
                            case 6:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 7:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 8:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 9:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 10:
                                a2[i] = "Лесной слалом";
                                break;
                            case 11:
                                a2[i] = "Лесной слалом";
                                break;
                            case 12:
                                a2[i] = "Слалом";
                                break;
                            case 13:
                                a2[i] = "Перегрузка";
                                break;
                            case 14:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 15:
                                a2[i] = "Ралли-кросс мал";
                                break;
                            case 16:
                                a2[i] = "Ралли-кросс ср";
                                break;
                            case 17:
                                a2[i] = "Токио мостик";
                                break;
                            case 18:
                                a2[i] = "Токио мост";
                                break;
                            case 19:
                                a2[i] = "Улица мал";
                                break;
                            case 20:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 21:
                                a2[i] = "Парковка";
                                break;
                            case 22:
                                a2[i] = "Токио тест на перегрузки";
                                break;
                            case 23:
                                a2[i] = "Тестовый круг";
                                break;
                            case 24:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 25:
                                a2[i] = "Крутой холм";
                                break;
                            case 26:
                                a2[i] = "Грунтовая дорога";
                                break;
                            case 27:
                                a2[i] = "Токио тест на перегрузки";
                                break;
                            case 28:
                                a2[i] = "0-100-0";
                                break;
                            case 29:
                                a2[i] = "Монако узкие улицы";
                                break;
                            case 30:
                                a2[i] = "Монако длинные городские улицы";
                                break;
                            case 31:
                                a2[i] = "Highway";
                                break;
                            case 32:
                                a2[i] = "Улица ср";
                                break;
                            case 33:
                                a2[i] = "75-125";
                                break;
                            case 34:
                                a2[i] = "Лесная дорога";
                                break;
                            case 35:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 36:
                                a2[i] = "Лесная переправа";
                                break;
                            case 37:
                                a2[i] = "0-100";
                                break;
                            case 38:
                                a2[i] = "Трасса набережная";
                                break;
                            case 39:
                                a2[i] = "Мотокросс";
                                break;
                            case 40:
                                a2[i] = "Каньон грунтовая дорога";
                                break;
                            default:
                                a2[i] = "Неизвестная трасса";
                                break;
                        }
                        break;
                    case 3:
                        switch (a1[i])
                        {
                            case 1:
                                a2[i] = "Улица ср";
                                break;
                            case 2:
                                a2[i] = "1/2";
                                break;
                            case 3:
                                a2[i] = "Тестовый круг";
                                break;
                            case 4:
                                a2[i] = "Тестовый круг";
                                break;
                            case 5:
                                a2[i] = "Серпантин";
                                break;
                            case 6:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 7:
                                a2[i] = "Каньон экспедиция";
                                break;
                            case 8:
                                a2[i] = "Лесная дорога";
                                break;
                            case 9:
                                a2[i] = "Лесная дорога";
                                break;
                            case 10:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 11:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 12:
                                a2[i] = "Лесной слалом";
                                break;
                            case 13:
                                a2[i] = "Лесной слалом";
                                break;
                            case 14:
                                a2[i] = "Слалом";
                                break;
                            case 15:
                                a2[i] = "Перегрузка";
                                break;
                            case 16:
                                a2[i] = "Перегрузка";
                                break;
                            case 17:
                                a2[i] = "1";
                                break;
                            case 18:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 19:
                                a2[i] = "Токио тест на перешрузки";
                                break;
                            case 20:
                                a2[i] = "Токио трасса";
                                break;
                            case 21:
                                a2[i] = "Токио съезд";
                                break;
                            case 22:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 23:
                                a2[i] = "Токио петля";
                                break;
                            case 24:
                                a2[i] = "0-100";
                                break;
                            case 25:
                                a2[i] = "Грунтовая дорога";
                                break;
                            case 26:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 27:
                                a2[i] = "Улица мал";
                                break;
                            case 28:
                                a2[i] = "Мотокросс";
                                break;
                            case 29:
                                a2[i] = "1/4";
                                break;
                            case 30:
                                a2[i] = "Ралли-кросс ср";
                                break;
                            case 31:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 32:
                                a2[i] = "Монако серпантин";
                                break;
                            case 33:
                                a2[i] = "0-100-0";
                                break;
                            case 34:
                                a2[i] = "Замерзшее озеро";
                                break;
                            case 35:
                                a2[i] = "Монако узкие улицы";
                                break;
                            case 36:
                                a2[i] = "Трасса набережная";
                                break;
                            case 37:
                                a2[i] = "Парковка";
                                break;
                            case 38:
                                a2[i] = "75-125";
                                break;
                            case 39:
                                a2[i] = "Трасса для мотокросса";
                                break;
                            case 40:
                                a2[i] = "Подъем на холм";
                                break;
                            default:
                                a2[i] = "Неизвестная трасса";
                                break;
                        }
                        break;
                    case 4:
                        switch (a1[i])
                        {
                            case 1:
                                a2[i] = "1/4";
                                break;
                            case 2:
                                a2[i] = "Улица мал";
                                break;
                            case 3:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 4:
                                a2[i] = "Парковка";
                                break;
                            case 5:
                                a2[i] = "Серпантин";
                                break;
                            case 6:
                                a2[i] = "Монако перегрузка";
                                break;
                            case 7:
                                a2[i] = "1";
                                break;
                            case 8:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 9:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 10:
                                a2[i] = "Лесной слалом";
                                break;
                            case 11:
                                a2[i] = "Лесная дорога";
                                break;
                            case 12:
                                a2[i] = "Лесной слалом";
                                break;
                            case 13:
                                a2[i] = "Улица ср";
                                break;
                            case 14:
                                a2[i] = "Ралли-кросс мал";
                                break;
                            case 15:
                                a2[i] = "Мотокросс";
                                break;
                            case 16:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 17:
                                a2[i] = "Токио мост";
                                break;
                            case 18:
                                a2[i] = "Токио съезд";
                                break;
                            case 19:
                                a2[i] = "Токио тест на перешрузки";
                                break;
                            case 20:
                                a2[i] = "Слалом";
                                break;
                            case 21:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 22:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 23:
                                a2[i] = "Обзор";
                                break;
                            case 24:
                                a2[i] = "Крутой холи";
                                break;
                            case 25:
                                a2[i] = "Подъем на холм";
                                break;
                            case 26:
                                a2[i] = "Подъем на холм";
                                break;
                            case 27:
                                a2[i] = "Лесная дорога";
                                break;
                            case 28:
                                a2[i] = "Тестовый круг";
                                break;
                            case 29:
                                a2[i] = "Перегрузка";
                                break;
                            case 30:
                                a2[i] = "Монако серпантин";
                                break;
                            case 31:
                                a2[i] = "Монако городские";
                                break;
                            case 32:
                                a2[i] = "Перегрузка";
                                break;
                            case 33:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 34:
                                a2[i] = "Токио трасса";
                                break;
                            case 35:
                                a2[i] = "0-100-0";
                                break;
                            case 36:
                                a2[i] = "Трасса набережная";
                                break;
                            case 37:
                                a2[i] = "Highway";
                                break;
                            case 38:
                                a2[i] = "Лесная переправа";
                                break;
                            case 39:
                                a2[i] = "1";
                                break;
                            case 40:
                                a2[i] = "50-150";
                                break;
                            case 41:
                                a2[i] = "Обзор";
                                break;
                            default:
                                a2[i] = "Неизвестная трасса";
                                break;
                        }
                        break;
                }
            }
            return a2;
        }

        private void UniversalErrorDefense()
        {
            BW2Capture(ErrorBounds, ErrorPath);//проверка ошибки сервера
            if (VerifyBW(ErrorPath, ErrorOriginal, 10))//при ошибке запустить перезапуск
            {
                
                Clk(1211, 164);//close memu
                Thread.Sleep(1000);
                Clk(598, 511);// accept memu close
                Thread.Sleep(1000);
                Clk(20, 1000);
                Thread.Sleep(1000);
                Clk(20, 960);
                Thread.Sleep(3000);
                Clk(40, 910);
                Thread.Sleep(1000);
                Clk(40, 910);//reloading
                Application.Exit();
            }
        }

        private bool ClubBountyCheck()
        {
            bool x = false;
            UniversalCapture(ClubBountyBounds, ClubBountyPath);//проверка клубной награды
            if (Verify(ClubBountyPath, ClubBountyOriginal))
            {
                Thread.Sleep(1000);
                DoLog("Получаю Награду");
                Clk(630, 740); //получить награду                
                Thread.Sleep(3000);
                x = true;
            }
            return x;
        }

        private double CalculateCompatibility(string track, string coverage, string weather, double[] carstats)
        {
            //carstats[клиренс, резина, привод, разгон до сотки, максималка, управление, масса]
            /*
            1 - slk
            2 - dyn
            3 - std
            4 - all
            5 - off            
            */
            double x = 0;

            switch (coverage)
            {
                case "Асфальт":
                    switch (weather)
                    {
                        case "Солнечно":
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 500;
                                    break;
                                case 2:
                                    x += 400;
                                    break;
                                case 3:
                                    x += 200;
                                    break;
                                case 4:
                                    x += 100;
                                    break;
                                case 5:
                                    x += 200;
                                    break;
                            }
                            if (carstats[2] == 4) x -= 50;
                            break;

                        case "Дождь":
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    if (carstats[2] == 4) x += 50;
                                    x += 200;
                                    break;
                                case 3:
                                    x += 500;
                                    break;
                                case 4:
                                    x += 100;
                                    break;
                                case 5:
                                    x += 0;
                                    break;
                            }
                            break;
                        default:
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    x += 200;
                                    break;
                                case 3:
                                    x += 500;
                                    break;
                                case 4:
                                    x += 100;
                                    break;
                                case 5:
                                    x += 0;
                                    break;
                            }
                            break;
                    }
                    break;
                case "Гравий":
                    switch (carstats[1])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 100;
                            break;
                        case 3:
                            x += 300;
                            break;
                        case 4:
                            x += 450;
                            break;
                        case 5:
                            x += 250;
                            break;
                    }
                    if (carstats[2] == 4) x += 50;
                    break;
                case "Грунт":
                    switch (weather)
                    {
                        case "Солнечно":
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 100;
                                    break;
                                case 2:
                                    x += 100;
                                    break;
                                case 3:
                                    x += 250;
                                    break;
                                case 4:
                                    x += 500;
                                    break;
                                case 5:
                                    x += 500;
                                    break;
                            }
                            if (carstats[2] == 4) x += 50;
                            break;
                        case "Дождь":
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    x += 50;
                                    break;
                                case 3:
                                    x += 200;
                                    break;
                                case 4:
                                    x += 500;
                                    break;
                                case 5:
                                    x += 500;
                                    break;
                            }
                            if (carstats[2] == 4) x += 100;
                            break;
                        default:
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    x += 50;
                                    break;
                                case 3:
                                    x += 200;
                                    break;
                                case 4:
                                    x += 500;
                                    break;
                                case 5:
                                    x += 500;
                                    break;
                            }
                            break;
                    }
                    break;
                case "Песок":
                    switch (carstats[1])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 50;
                            break;
                        case 3:
                            x += 250;
                            break;
                        case 4:
                            x += 500;
                            break;
                        case 5:
                            x += 500;
                            break;
                    }
                    if (carstats[2] == 4) x += 50;
                    break;
                case "Снег":
                    switch (carstats[1])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 50;
                            break;
                        case 3:
                            x += 100;
                            break;
                        case 4:
                            x += 500;
                            break;
                        case 5:
                            x += 500;
                            break;
                    }
                    if (carstats[2] == 4) x += 100;
                    break;
                case "Смешанное":
                    switch (weather)
                    {
                        case "Солнечно":
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    x += 50;
                                    break;
                                case 3:
                                    x += 100;
                                    break;
                                case 4:
                                    x += 500;
                                    break;
                                case 5:
                                    x += 300;
                                    break;
                            }
                            break;
                        case "Дождь":
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    x += 50;
                                    break;
                                case 3:
                                    x += 100;
                                    break;
                                case 4:
                                    x += 500;
                                    break;
                                case 5:
                                    x += 250;
                                    break;
                            }
                            break;
                        default:
                            switch (carstats[1])
                            {
                                case 1:
                                    x += 0;
                                    break;
                                case 2:
                                    x += 50;
                                    break;
                                case 3:
                                    x += 100;
                                    break;
                                case 4:
                                    x += 500;
                                    break;
                                case 5:
                                    x += 500;
                                    break;
                            }
                            break;
                    }
                    if (carstats[2] == 4) x += 50;
                    break;
                case "Трава":
                    switch (carstats[1])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 50;
                            break;
                        case 3:
                            x += 100;
                            break;
                        case 4:
                            x += 350;
                            break;
                        case 5:
                            x += 500;
                            break;
                    }
                    if (carstats[2] == 4) x += 50;
                    break;
                case "Лед":
                    switch (carstats[1])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 50;
                            break;
                        case 3:
                            x += 100;
                            break;
                        case 4:
                            x += 400;
                            break;
                        case 5:
                            x += 500;
                            break;
                    }
                    if (carstats[2] == 4) x += 50;
                    break;
            }

            switch (track)
            {
                case "Улица ср":
                    switch (carstats[0])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 700;
                            break;
                        case 3:
                            x += 300;
                            break;
                    }

                    x -= carstats[4];
                    x -= carstats[5];
                    break;
                case "Улица мал":
                    switch (carstats[0])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 700;
                            break;
                        case 3:
                            x += 300;
                            break;
                    }

                    x -= carstats[4];
                    x -= carstats[5];
                    break;
                case "Подъем на холм":
                    switch (carstats[0])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 200;
                            break;
                        case 3:
                            x += 500;
                            break;
                    }
                    x -= carstats[3] * 50;
                    if (carstats[2] == 4) x += 200;
                    break;
                case "Трасса для мотокросса":
                    switch (carstats[0])
                    {
                        case 1:
                            x += 0;
                            break;
                        case 2:
                            x += 200;
                            break;
                        case 3:
                            x += 500;
                            break;
                    }
                    break;
                case "50-150":
                    x -= carstats[3] * 200;
                    x -= carstats[5];
                    x += carstats[4] * 5;
                    break;
                case "75-125":
                    x -= carstats[3] * 200;
                    x -= carstats[5];
                    x += carstats[4] * 5;
                    break;
                case "0-100":
                    if (coverage != "Асфальт")
                    {
                        if (carstats[2] == 4) x += 200;
                    }
                    x -= carstats[3] * 100;
                    x -= carstats[5];
                    x += carstats[4] * 2;
                    break;
                case "0-100-0":
                    if (coverage != "Асфальт")
                    {
                        if (carstats[2] == 4) x += 200;
                    }
                    x -= carstats[3] * 100;
                    x -= carstats[5];
                    x += carstats[4] * 2;
                    break;
                case "1":
                    if (coverage != "Асфальт")
                    {
                        if (carstats[2] == 4) x += 100;
                    }
                    x -= carstats[3] * 80;
                    x -= carstats[5];
                    x += carstats[4] * 3;
                    break;
                case "1/2":
                    if (coverage != "Асфальт")
                    {
                        if (carstats[2] == 4) x += 200;
                    }
                    x -= carstats[3] * 80;
                    x -= carstats[5];
                    x += carstats[4];
                    break;
                case "1/4":
                    if (coverage != "Асфальт")
                    {
                        if (carstats[2] == 4) x += 300;
                    }
                    x -= carstats[3] * 120;
                    x -= carstats[5];
                    x += carstats[4] / 2;
                    break;
                case "Токио трасса":
                    if (coverage != "Асфальт")
                    {
                        if (carstats[2] == 4) x += 200;
                    }
                    x -= carstats[3] * 100;
                    x -= carstats[5];
                    x += carstats[4];
                    break;
                case "Трасса набережная":
                    if (coverage != "Асфальт")
                    {
                        if (carstats[2] == 4) x += 200;
                    }
                    x -= carstats[3] * 100;
                    x -= carstats[5];
                    x += carstats[4];
                    break;
                case "Тестовый круг":
                    x += carstats[4] * 5;
                    x -= carstats[5];
                    break;
                case "Токио мостик":
                    x += carstats[4] * 3;
                    x -= carstats[3] * 6;
                    break;
                case "Токио петля":
                    x += carstats[4] * 2;
                    x -= carstats[3] * 8;
                    break;
                case "Замерзшее озеро":
                    break;
                case "Извилистая дорога":
                    if (coverage != "Асфальт")
                    {
                        switch (carstats[0])
                        {
                            case 1:
                                x += 0;
                                break;
                            case 2:
                                x += 200;
                                break;
                            case 3:
                                x += 300;
                                break;
                        }
                        if (carstats[2] == 4) x += 50;
                    }
                    break;
                case "Быстрая трасса":
                    x -= carstats[3] * 40;
                    x -= carstats[5] / 2;
                    x += carstats[4];
                    break;
                case "Highway":
                    x -= carstats[3] * 40;
                    x -= carstats[5] / 2;
                    x += carstats[4];
                    break;
                case "Монако длинные городские улицы":
                    x -= carstats[3] * 40;
                    x -= carstats[5] / 2;
                    x += carstats[4];
                    break;
                case "Каньон экспедиция":
                    x -= carstats[3] * 30;
                    x -= carstats[5] / 4;
                    x += carstats[4];
                    break;
                case "Серпантин":
                    x -= carstats[3] * 50;
                    break;
                case "Монако серпантин":
                    x -= carstats[3] * 50;
                    break;
                case "Извилистая трасса":
                    break;
                case "Токио мост":
                    break;
                case "Токио съезд":
                    break;
                case "Монако городские":
                    break;
                case "Обзор":
                    break;
                case "Каньон грунтовая дорога":
                    break;
                case "Грунтовая дорога":
                    break;
                case "Лесная переправа":
                    break;
                case "Ралли-кросс мал":
                    break;
                case "Ралли кросс ср":
                    break;
                case "Крутой холм":
                    break;
                case "Лесная дорога":
                    break;
                case "Монако узкие улицы":
                    break;
                case "Монако тест на перегрузки":
                    break;
                case "Токио тест на перегрузки ":
                    break;
                case "Трасса для картинга":
                    break;
                case "Парковка":
                    break;
                case "Лесной слалом":
                    break;
                case "Закрытый картинг":
                    break;
                case "Слалом":
                    break;
                case "Перегрузка":
                    break;
                case "Неизвестная трасса":
                    break;
                default:
                    break;
            }

            return x;
        }

        private int Identify1Car(int a)
        {
            int carid = 0;
            switch (a)
            {
                case 1:
                    carid = 872;
                    break;
                case 2:
                    carid = 1046;
                    break;
                case 3:
                    carid = 249;
                    break;
                case 4:
                    carid = 200;
                    break;
                case 5:
                    carid = 197;
                    break;
                case 6:
                    carid = 244;
                    break;
                case 7:
                    carid = 572;
                    break;
                case 8:
                    carid = 667;
                    break;
                case 9:
                    carid = 1235;
                    break;
                case 10:
                    carid = 749;
                    break;
                case 11:
                    carid = 1218;
                    break;
                case 12:
                    carid = 1144;
                    break;
                case 13:
                    carid = 1108;
                    break;
                case 14:
                    carid = 1105;
                    break;
                case 15:
                    carid = 144;
                    break;
                case 16:
                    carid = 1068;
                    break;
                case 17:
                    carid = 1112;
                    break;
                case 18:
                    carid = 681;
                    break;
                case 19:
                    carid = 805;
                    break;
                case 20:
                    carid = 1103;
                    break;
                case 21:
                    carid = 1303;
                    break;
                case 22:
                    carid = 1113;
                    break;
                case 23:
                    carid = 9;
                    break;
                case 24:
                    carid = 173;
                    break;
                case 25:
                    carid = 1057;
                    break;
                case 26:
                    carid = 1263;
                    break;
                case 27:
                    carid = 252;
                    break;
                case 28:
                    carid = 46;
                    break;
                case 29:
                    carid = 1130;
                    break;
                case 30:
                    carid = 1007;
                    break;
                case 31:
                    carid = 990;
                    break;
                case 32:
                    carid = 322;
                    break;
                case 33:
                    carid = 1027;
                    break;
                case 34:
                    carid = 765;
                    break;
                case 35:
                    carid = 375;
                    break;
                case 36:
                    carid = 1079;
                    break;
                case 37:
                    carid = 253;
                    break;
                case 38:
                    carid = 730;
                    break;
                case 39:
                    carid = 66;
                    break;
                case 40:
                    carid = 258;
                    break;
                case 41:
                    carid = 298;
                    break;
                case 42:
                    carid = 250;
                    break;
                case 43:
                    carid = 276;
                    break;
                case 44:
                    carid = 838;
                    break;
                case 45:
                    carid = 431;
                    break;
                case 46:
                    carid = 719;
                    break;
                case 47:
                    carid = 436;
                    break;
                case 48:
                    carid = 1183;
                    break;
                case 49:
                    carid = 362;
                    break;
                case 50:
                    carid = 257;
                    break;
                case 51:
                    carid = 264;
                    break;
                case 52:
                    carid = 218;
                    break;
                case 53:
                    carid = 61;
                    break;
                case 54:
                    carid = 471;
                    break;
                case 55:
                    carid = 534;
                    break;
                case 56:
                    carid = 671;
                    break;
                case 57:
                    carid = 576;
                    break;
                case 58:
                    carid = 587;
                    break;
                case 59:
                    carid = 989;
                    break;
                case 60:
                    carid = 1104;
                    break;
                case 61:
                    carid = 507;
                    break;
                case 62:
                    carid = 715;
                    break;
                case 63:
                    carid = 256;
                    break;
                case 64:
                    carid = 792;
                    break;
                case 65:
                    carid = 669;
                    break;
                case 66:
                    carid = 738;
                    break;
                case 67:
                    carid = 1061;
                    break;
                case 68:
                    carid = 897;
                    break;
                case 69:
                    carid = 44;
                    break;
                case 70:
                    carid = 1312;
                    break;
                case 71:
                    carid = 217;
                    break;
                case 72:
                    carid = 222;
                    break;
                case 73:
                    carid = 1260;
                    break;
                case 74:
                    carid = 296;
                    break;
                case 75:
                    carid = 1119;
                    break;
                case 76:
                    carid = 908;
                    break;
                case 77:
                    carid = 35;
                    break;
                case 78:
                    carid = 283;
                    break;
                case 79:
                    carid = 808;
                    break;
                case 80:
                    carid = 869;
                    break;
                case 81:
                    carid = 216;
                    break;
                case 82:
                    carid = 64;
                    break;
                case 83:
                    carid = 99;
                    break;
                case 84:
                    carid = 1049;
                    break;
                case 85:
                    carid = 1142;
                    break;
                case 86:
                    carid = 650;
                    break;
                case 87:
                    carid = 727;
                    break;
                case 88:
                    carid = 1377;
                    break;
                case 89:
                    carid = 675;
                    break;
                case 90:
                    carid = 626;
                    break;
                case 91:
                    carid = 439;
                    break;
                case 92:
                    carid = 1366;
                    break;
                case 93:
                    carid = 962;
                    break;
                case 94:
                    carid = 590;
                    break;
                case 95:
                    carid = 569;
                    break;
                case 96:
                    carid = 504;
                    break;
                case 97:
                    carid = 961;
                    break;
                case 98:
                    carid = 505;
                    break;
                case 99:
                    carid = 892;
                    break;
                case 100:
                    carid = 1276;
                    break;
                case 101:
                    carid = 708;
                    break;
                case 102:
                    carid = 464;
                    break;
                case 103:
                    carid = 29;
                    break;
                case 104:
                    carid = 690;
                    break;
                case 105:
                    carid = 21;
                    break;
                case 106:
                    carid = 915;
                    break;
                case 107:
                    carid = 574;
                    break;
                case 108:
                    carid = 224;
                    break;
                case 109:
                    carid = 851;
                    break;
                case 110:
                    carid = 381;
                    break;
                case 111:
                    carid = 16;
                    break;
                case 112:
                    carid = 380;
                    break;
                case 113:
                    carid = 263;
                    break;
                case 114:
                    carid = 575;
                    break;
                case 115:
                    carid = 1281;
                    break;
                case 116:
                    carid = 746;
                    break;
                case 117:
                    carid = 170;
                    break;
                case 118:
                    carid = 653;
                    break;
                case 119:
                    carid = 524;
                    break;
                case 120:
                    carid = 577;
                    break;
                case 121:
                    carid = 659;
                    break;
                case 122:
                    carid = 1439;
                    break;
                case 123:
                    carid = 760;
                    break;
                case 124:
                    carid = 1284;
                    break;
                case 125:
                    carid = 791;
                    break;
                case 126:
                    carid = 135;
                    break;
                case 127:
                    carid = 1438;
                    break;
                case 128:
                    carid = 233;
                    break;
                case 129:
                    carid = 821;
                    break;
                case 130:
                    carid = 204;
                    break;
                case 131:
                    carid = 1080;
                    break;
                case 132:
                    carid = 1075;
                    break;
                case 133:
                    carid = 655;
                    break;
                case 134:
                    carid = 1138;
                    break;
                case 135:
                    carid = 992;
                    break;
                case 136:
                    carid = 721;
                    break;
                case 137:
                    carid = 458;
                    break;
                case 138:
                    carid = 1121;
                    break;
                case 139:
                    carid = 680;
                    break;
                case 140:
                    carid = 1114;
                    break;
                case 141:
                    carid = 636;
                    break;
                case 142:
                    carid = 1382;
                    break;
                case 143:
                    carid = 15;
                    break;
                case 144:
                    carid = 172;
                    break;
                case 145:
                    carid = 1135;
                    break;
                case 146:
                    carid = 742;
                    break;
                case 147:
                    carid = 426;
                    break;
                case 148:
                    carid = 1368;
                    break;
                case 149:
                    carid = 382;
                    break;
                case 150:
                    carid = 1443;
                    break;
                case 151:
                    carid = 1155;
                    break;
                case 152:
                    carid = 282;
                    break;
                case 153:
                    carid = 441;
                    break;
                case 154:
                    carid = 777;
                    break;
                case 155:
                    carid = 729;
                    break;
                case 156:
                    carid = 147;
                    break;
                case 157:
                    carid = 710;
                    break;
                case 158:
                    carid = 756;
                    break;
                case 159:
                    carid = 688;
                    break;
                case 160:
                    carid = 912;
                    break;
                case 161:
                    carid = 1073;
                    break;
                case 162:
                    carid = 722;
                    break;
                case 163:
                    carid = 254;
                    break;
                case 164:
                    carid = 679;
                    break;
                case 165:
                    carid = 310;
                    break;
                case 166:
                    carid = 672;
                    break;
                case 167:
                    carid = 506;
                    break;
                case 168:
                    carid = 717;
                    break;
                case 169:
                    carid = 11;
                    break;
                case 170:
                    carid = 1248;
                    break;
                case 171:
                    carid = 316;
                    break;
                case 172:
                    carid = 874;
                    break;
                case 173:
                    carid = 734;
                    break;
                case 174:
                    carid = 890;
                    break;
                case 175:
                    carid = 868;
                    break;
                case 176:
                    carid = 450;
                    break;
                case 177:
                    carid = 693;
                    break;
                case 178:
                    carid = 662;
                    break;
                case 179:
                    carid = 176;
                    break;
                case 180:
                    carid = 871;
                    break;
                case 181:
                    carid = 1246;
                    break;
                case 182:
                    carid = 1127;
                    break;
                case 183:
                    carid = 109;
                    break;
                case 184:
                    carid = 183;
                    break;
                case 185:
                    carid = 1313;
                    break;
                case 186:
                    carid = 641;
                    break;
                case 187:
                    carid = 1025;
                    break;
                case 188:
                    carid = 1287;
                    break;
                case 189:
                    carid = 305;
                    break;
                case 190:
                    carid = 996;
                    break;
                case 191:
                    carid = 955;
                    break;
                case 192:
                    carid = 319;
                    break;
                case 193:
                    carid = 433;
                    break;
                case 194:
                    carid = 435;
                    break;
                case 195:
                    carid = 437;
                    break;
                case 196:
                    carid = 429;
                    break;
                case 197:
                    carid = 430;
                    break;
                case 198:
                    carid = 438;
                    break;
                case 199:
                    carid = 432;
                    break;
                case 200:
                    carid = 673;
                    break;
                case 201:
                    carid = 718;
                    break;
                case 202:
                    carid = 440;
                    break;
                case 203:
                    carid = 663;
                    break;
                case 204:
                    carid = 311;
                    break;
                case 205:
                    carid = 646;
                    break;
                case 206:
                    carid = 684;
                    break;
                case 207:
                    carid = 165;
                    break;
                case 208:
                    carid = 1225;
                    break;
                case 209:
                    carid = 312;
                    break;
                case 210:
                    carid = 349;
                    break;
                case 211:
                    carid = 1002;
                    break;
                case 212:
                    carid = 521;
                    break;
                case 213:
                    carid = 562;
                    break;
                case 214:
                    carid = 392;
                    break;
                case 215:
                    carid = 146;
                    break;
                case 216:
                    carid = 850;
                    break;
                case 217:
                    carid = 726;
                    break;
                case 218:
                    carid = 593;
                    break;
                case 219:
                    carid = 291;
                    break;
                case 220:
                    carid = 93;
                    break;
                case 221:
                    carid = 103;
                    break;
                case 222:
                    carid = 352;
                    break;
                case 223:
                    carid = 125;
                    break;
                case 224:
                    carid =1146;
                    break;
                case 225:
                    carid = 288;
                    break;
                case 226:
                    carid = 270;
                    break;
                case 227:
                    carid = 260;
                    break;
                case 228:
                    carid = 848;
                    break;
                case 229:
                    carid = 1223;
                    break;
                case 230:
                    carid = 936;
                    break;
                case 231:
                    carid = 231;
                    break;
                case 232:
                    carid = 723;
                    break;
                case 233:
                    carid = 508;
                    break;
                case 234:
                    carid = 203;
                    break;
                case 235:
                    carid = 704;
                    break;
                case 236:
                    carid = 417;
                    break;
                case 237:
                    carid = 1128;
                    break;
                case 238:
                    carid = 1133;
                    break;
                case 239:
                    carid = 516;
                    break;
                case 240:
                    carid = 713;
                    break;
                case 241:
                    carid = 1015;
                    break;
                case 242:
                    carid = 277;
                    break;
                case 243:
                    carid = 1371;
                    break;
                case 244:
                    carid = 1147;
                    break;
                case 245:
                    carid = 558;
                    break;
                case 246:
                    carid = 259;
                    break;
                case 247:
                    carid = 75;
                    break;
                case 248:
                    carid = 1434;
                    break;
                case 249:
                    carid = 456;
                    break;
                case 250:
                    carid = 784;
                    break;
                case 251:
                    carid = 1141;
                    break;
                case 252:
                    carid = 649;
                    break;
                case 253:
                    carid = 1250;
                    break;
                case 254:
                    carid = 1327;
                    break;
                case 255:
                    carid = 1132;
                    break;
                case 256:
                    carid = 37;
                    break;
                case 257:
                    carid = 824;
                    break;
                case 258:
                    carid = 608;
                    break;
                case 259:
                    carid = 39;
                    break;
                case 260:
                    carid = 757;
                    break;
                case 261:
                    carid = 149;
                    break;
                case 262:
                    carid = 106;
                    break;
                case 263:
                    carid = 72;
                    break;
                case 264:
                    carid = 104;
                    break;
                case 265:
                    carid = 141;
                    break;
                case 266:
                    carid = 676;
                    break;
                case 267:
                    carid = 119;
                    break;
                case 268:
                    carid = 134;
                    break;
                case 269:
                    carid = 740;
                    break;
                case 270:
                    carid = 1301;
                    break;
                case 271:
                    carid = 594;
                    break;
                case 272:
                    carid = 1163;
                    break;
                case 273:
                    carid = 71;
                    break;
                case 274:
                    carid = 1005;
                    break;
                case 275:
                    carid = 685;
                    break;
                case 276:
                    carid = 393;
                    break;
                case 277:
                    carid = 724;
                    break;
                case 278:
                    carid = 126;
                    break;
                case 279:
                    carid = 185;
                    break;
                case 280:
                    carid = 803;
                    break;
                case 281:
                    carid = 712;
                    break;
                case 282:
                    carid = 514;
                    break;
                case 283:
                    carid = 1129;
                    break;
                case 284:
                    carid = 857;
                    break;
                case 285:
                    carid = 815;
                    break;
                case 286:
                    carid = 1283;
                    break;
                case 287:
                    carid = 303;
                    break;
                case 288:
                    carid = 1354;
                    break;
                case 289:
                    carid = 281;
                    break;
                case 290:
                    carid = 374;
                    break;
                case 291:
                    carid = 299;
                    break;
                case 292:
                    carid = 592;
                    break;
                case 293:
                    carid = 49;
                    break;
                case 294:
                    carid = 523;
                    break;
                case 295:
                    carid = 459;
                    break;
                case 296:
                    carid = 859;
                    break;
                case 297:
                    carid = 274;
                    break;
                case 298:
                    carid = 785;
                    break;
                case 299:
                    carid = 175;
                    break;
                case 300:
                    carid = 304;
                    break;
                case 301:
                    carid = 798;
                    break;
                case 302:
                    carid = 275;
                    break;
                case 303:
                    carid = 1307;
                    break;
                case 304:
                    carid = 279;
                    break;
                case 305:
                    carid = 658;
                    break;
                case 306:
                    carid = 1394;
                    break;
                case 307:
                    carid = 601;
                    break;
                case 308:
                    carid = 1014;
                    break;
                case 309:
                    carid = 502;
                    break;
                case 310:
                    carid = 335;
                    break;
                case 311:
                    carid = 466;
                    break;
                case 312:
                    carid = 445;
                    break;
                case 313:
                    carid = 922;
                    break;
                case 314:
                    carid = 1021;
                    break;
                case 315:
                    carid = 145;
                    break;                
                case 316:
                    carid = 0;
                    break;
                case 317:
                    carid = 0;
                    break;
                case 318:
                    carid = 0;
                    break;
                case 319:
                    carid = 0;
                    break;
                case 320:
                    carid = 0;
                    break;
                case 321:
                    carid = 0;
                    break;
                case 322:
                    carid = 0;
                    break;
                case 323:
                    carid = 0;
                    break;
                case 324:
                    carid = 0;
                    break;
                case 325:
                    carid = 0;
                    break;
                case 326:
                    carid = 0;
                    break;
                case 327:
                    carid = 0;
                    break;
                case 328:
                    carid = 0;
                    break;
                case 329:
                    carid = 0;
                    break;
                case 330:
                    carid = 0;
                    break;
                case 331:
                    carid = 0;
                    break;
                case 332:
                    carid = 0;
                    break;
                case 333:
                    carid = 0;
                    break;
                case 334:
                    carid = 0;
                    break;
                case 335:
                    carid = 0;
                    break;
                case 336:
                    carid = 0;
                    break;
                case 337:
                    carid = 0;
                    break;
                case 338:
                    carid = 0;
                    break;
                case 339:
                    carid = 0;
                    break;
                case 340:
                    carid = 0;
                    break;
                case 341:
                    carid = 0;
                    break;
                case 342:
                    carid = 0;
                    break;
                case 343:
                    carid = 0;
                    break;
                case 344:
                    carid = 0;
                    break;
                case 345:
                    carid = 0;
                    break;
                case 346:
                    carid = 0;
                    break;
                case 347:
                    carid = 0;
                    break;
                case 348:
                    carid = 0;
                    break;
                case 349:
                    carid = 0;
                    break;

                default:
                    DoLog("неизвестная тачка");
                    carid = 0;
                    break;
            }
            return carid;
        }

        private int Identify2Car(int a)
        {
            int carid = 0;
            switch (a)
            {
                case 1:
                    carid = 857;
                    break;
                case 2:
                    carid = 1045;
                    break;
                case 3:
                    carid = 251;
                    break;
                case 4:
                    carid = 1133;
                    break;
                case 5:
                    carid = 872;
                    break;
                case 6:
                    carid = 1127;
                    break;
                case 7:
                    carid = 249;
                    break;
                case 8:
                    carid = 1105;
                    break;
                case 9:
                    carid = 254;
                    break;
                case 10:
                    carid = 1108;
                    break;
                case 11:
                    carid = 1443;
                    break;
                case 12:
                    carid = 174;
                    break;
                case 13:
                    carid = 515;
                    break;
                case 14:
                    carid = 1235;
                    break;
                case 15:
                    carid = 807;
                    break;
                case 16:
                    carid = 1079;
                    break;
                case 17:
                    carid = 1078;
                    break;
                case 18:
                    carid = 1027;
                    break;
                case 19:
                    carid = 1059;
                    break;
                case 20:
                    carid = 990;
                    break;
                case 21:
                    carid = 1223;
                    break;
                case 22:
                    carid = 1104;
                    break;
                case 23:
                    carid = 738;
                    break;
                case 24:
                    carid = 1113;
                    break;
                case 25:
                    carid = 1370;
                    break;
                case 26:
                    carid = 1225;
                    break;
                case 27:
                    carid = 50;
                    break;
                case 28:
                    carid = 16;
                    break;
                case 29:
                    carid = 1130;
                    break;
                case 30:
                    carid = 253;
                    break;
                case 31:
                    carid = 1068;
                    break;
                case 32:
                    carid = 992;
                    break;
                case 33:
                    carid = 1268;
                    break;
                case 34:
                    carid = 324;
                    break;
                case 35:
                    carid = 32;
                    break;
                case 36:
                    carid = 855;
                    break;
                case 37:
                    carid = 760;
                    break;
                case 38:
                    carid = 1094;
                    break;
                case 39:
                    carid = 264;
                    break;
                case 40:
                    carid = 641;
                    break;
                case 41:
                    carid = 1142;
                    break;
                case 42:
                    carid = 593;
                    break;
                case 43:
                    carid = 1303;
                    break;
                case 44:
                    carid = 298;
                    break;
                case 45:
                    carid = 250;
                    break;
                case 46:
                    carid = 257;
                    break;
                case 47:
                    carid = 577;
                    break;
                case 48:
                    carid = 439;
                    break;
                case 49:
                    carid = 450;
                    break;
                case 50:
                    carid = 438;
                    break;
                case 51:
                    carid = 299;
                    break;
                case 52:
                    carid = 306;
                    break;
                case 53:
                    carid = 64;
                    break;
                case 54:
                    carid = 727;
                    break;
                case 55:
                    carid = 1183;
                    break;
                case 56:
                    carid = 291;
                    break;
                case 57:
                    carid = 730;
                    break;
                case 58:
                    carid = 275;
                    break;
                case 59:
                    carid = 576;
                    break;
                case 60:
                    carid = 197;
                    break;
                case 61:
                    carid = 534;
                    break;
                case 62:
                    carid = 535;
                    break;
                case 63:
                    carid = 283;
                    break;
                case 64:
                    carid = 1036;
                    break;
                case 65:
                    carid = 791;
                    break;
                case 66:
                    carid = 435;
                    break;
                case 67:
                    carid = 1439;
                    break;
                case 68:
                    carid = 826;
                    break;
                case 69:
                    carid = 184;
                    break;
                case 70:
                    carid = 146;
                    break;
                case 71:
                    carid = 664;
                    break;
                case 72:
                    carid = 821;
                    break;
                case 73:
                    carid = 256;
                    break;
                case 74:
                    carid = 522;
                    break;
                case 75:
                    carid = 1061;
                    break;
                case 76:
                    carid = 897;
                    break;
                case 77:
                    carid = 708;
                    break;
                case 78:
                    carid = 279;
                    break;
                case 79:
                    carid = 1246;
                    break;
                case 80:
                    carid = 1056;
                    break;
                case 81:
                    carid = 217;
                    break;
                case 82:
                    carid = 660;
                    break;
                case 83:
                    carid = 1116;
                    break;
                case 84:
                    carid = 1264;
                    break;
                case 85:
                    carid = 1265;
                    break;
                case 86:
                    carid = 880;
                    break;
                case 87:
                    carid = 869;
                    break;
                case 88:
                    carid = 713;
                    break;
                case 89:
                    carid = 76;
                    break;
                case 90:
                    carid = 649;
                    break;
                case 91:
                    carid = 1075;
                    break;
                case 92:
                    carid = 1254;
                    break;
                case 93:
                    carid = 506;
                    break;
                case 94:
                    carid = 166;
                    break;
                case 95:
                    carid = 311;
                    break;
                case 96:
                    carid = 1279;
                    break;
                case 97:
                    carid = 472;
                    break;
                case 98:
                    carid = 312;
                    break;
                case 99:
                    carid = 574;
                    break;
                case 100:
                    carid = 1048;
                    break;
                case 101:
                    carid = 335;
                    break;
                case 102:
                    carid = 936;
                    break;
                case 103:
                    carid = 29;
                    break;
                case 104:
                    carid = 1366;
                    break;
                case 105:
                    carid = 962;
                    break;
                case 106:
                    carid = 504;
                    break;
                case 107:
                    carid = 1421;
                    break;
                case 108:
                    carid = 203;
                    break;
                case 109:
                    carid = 1128;
                    break;
                case 110:
                    carid = 1283;
                    break;
                case 111:
                    carid = 507;
                    break;
                case 112:
                    carid = 258;
                    break;
                case 113:
                    carid = 1276;
                    break;
                case 114:
                    carid = 1145;
                    break;
                case 115:
                    carid = 1368;
                    break;
                case 116:
                    carid = 636;
                    break;
                case 117:
                    carid = 729;
                    break;
                case 118:
                    carid = 204;
                    break;
                case 119:
                    carid = 714;
                    break;
                case 120:
                    carid = 393;
                    break;
                case 121:
                    carid = 362;
                    break;
                case 122:
                    carid = 530;
                    break;
                case 123:
                    carid = 517;
                    break;
                case 124:
                    carid = 681;
                    break;
                case 125:
                    carid = 650;
                    break;
                case 126:
                    carid = 1163;
                    break;
                case 127:
                    carid = 381;
                    break;
                case 128:
                    carid = 392;
                    break;
                case 129:
                    carid = 673;
                    break;
                case 130:
                    carid = 382;
                    break;
                case 131:
                    carid = 1218;
                    break;
                case 132:
                    carid = 54;
                    break;
                case 133:
                    carid = 304;
                    break;
                case 134:
                    carid = 808;
                    break;
                case 135:
                    carid = 218;
                    break;
                case 136:
                    carid = 157;
                    break;
                case 137:
                    carid = 996;
                    break;
                case 138:
                    carid = 66;
                    break;
                case 139:
                    carid = 955;
                    break;
                case 140:
                    carid = 587;
                    break;
                case 141:
                    carid = 672;
                    break;
                case 142:
                    carid = 164;
                    break;
                case 143:
                    carid = 792;
                    break;
                case 144:
                    carid = 655;
                    break;
                case 145:
                    carid = 835;
                    break;
                case 146:
                    carid = 151;
                    break;
                case 147:
                    carid = 850;
                    break;
                case 148:
                    carid = 531;
                    break;
                case 149:
                    carid = 99;
                    break;
                case 150:
                    carid = 1170;
                    break;
                case 151:
                    carid = 1080;
                    break;
                case 152:
                    carid = 609;
                    break;
                case 153:
                    carid = 661;
                    break;
                case 154:
                    carid = 756;
                    break;
                case 155:
                    carid = 1005;
                    break;
                case 156:
                    carid = 859;
                    break;
                case 157:
                    carid = 170;
                    break;
                case 158:
                    carid = 510;
                    break;
                case 159:
                    carid = 724;
                    break;
                case 160:
                    carid = 1138;
                    break;
                case 161:
                    carid = 195;
                    break;
                case 162:
                    carid = 1155;
                    break;
                case 163:
                    carid = 456;
                    break;
                case 164:
                    carid = 989;
                    break;
                case 165:
                    carid = 1123;
                    break;
                case 166:
                    carid = 310;
                    break;
                case 167:
                    carid = 998;
                    break;
                case 168:
                    carid = 21;
                    break;
                case 169:
                    carid = 881;
                    break;
                case 170:
                    carid = 374;
                    break;
                case 171:
                    carid = 590;
                    break;
                case 172:
                    carid = 1129;
                    break;
                case 173:
                    carid = 1137;
                    break;
                case 174:
                    carid = 1250;
                    break;
                case 175:
                    carid = 1207;
                    break;
                case 176:
                    carid = 1383;
                    break;
                case 177:
                    carid = 305;
                    break;
                case 178:
                    carid = 241;
                    break;
                case 179:
                    carid = 505;
                    break;
                case 180:
                    carid = 562;
                    break;
                case 181:
                    carid = 658;
                    break;
                case 182:
                    carid = 688;
                    break;
                case 183:
                    carid = 690;
                    break;
                case 184:
                    carid = 684;
                    break;
                case 185:
                    carid = 712;
                    break;
                case 186:
                    carid = 757;
                    break;
                case 187:
                    carid = 718;
                    break;
                case 188:
                    carid = 1031;
                    break;
                case 189:
                    carid = 848;
                    break;
                case 190:
                    carid = 1318;
                    break;
                case 191:
                    carid = 502;
                    break;
                case 192:
                    carid = 726;
                    break;
                case 193:
                    carid = 1120;
                    break;
                case 194:
                    carid = 1304;
                    break;
                case 195:
                    carid = 1248;
                    break;
                case 196:
                    carid = 442;
                    break;
                case 197:
                    carid = 252;
                    break;
                case 198:
                    carid = 598;
                    break;
                case 199:
                    carid = 890;
                    break;
                case 200:
                    carid = 874;
                    break;
                case 201:
                    carid = 742;
                    break;
                case 202:
                    carid = 569;
                    break;
                case 203:
                    carid = 594;
                    break;
                case 204:
                    carid = 607;
                    break;
                case 205:
                    carid = 734;
                    break;
                case 206:
                    carid = 1441;
                    break;
                case 207:
                    carid = 739;
                    break;
                case 208:
                    carid = 1132;
                    break;
                case 209:
                    carid = 868;
                    break;
                case 210:
                    carid = 680;
                    break;
                case 211:
                    carid = 1277;
                    break;
                case 212:
                    carid = 658;
                    break;
                case 213:
                    carid = 697;
                    break;
                case 214:
                    carid = 144;
                    break;
                case 215:
                    carid = 1437;
                    break;
                case 216:
                    carid = 670;
                    break;
                case 217:
                    carid = 749;
                    break;
                case 218:
                    carid = 908;
                    break;
                case 219:
                    carid = 612;
                    break;
                case 220:
                    carid = 410;
                    break;
                case 221:
                    carid = 1285;
                    break;
                case 222:
                    carid = 103;
                    break;
                case 223:
                    carid = 172;
                    break;
                case 224:
                    carid = 182;
                    break;
                case 225:
                    carid = 805;
                    break;
                case 226:
                    carid = 915;
                    break;
                case 227:
                    carid = 1176;
                    break;
                case 228:
                    carid = 1047;
                    break;
                case 229:
                    carid = 1046;
                    break;
                case 230:
                    carid = 61;
                    break;
                case 231:
                    carid = 432;
                    break;
                case 232:
                    carid = 436;
                    break;
                case 233:
                    carid = 428;
                    break;
                case 234:
                    carid = 440;
                    break;
                case 235:
                    carid = 511;
                    break;
                case 236:
                    carid = 426;
                    break;
                case 237:
                    carid = 441;
                    break;
                case 238:
                    carid = 427;
                    break;
                case 239:
                    carid = 437;
                    break;
                case 240:
                    carid = 496;
                    break;
                case 241:
                    carid = 1263;
                    break;
                case 242:
                    carid = 303;
                    break;
                case 243:
                    carid = 911;
                    break;
                case 244:
                    carid = 765;
                    break;
                case 245:
                    carid = 282;
                    break;
                case 246:
                    carid = 288;
                    break;
                case 247:
                    carid = 276;
                    break;
                case 248:
                    carid = 222;
                    break;
                case 249:
                    carid = 1284;
                    break;
                case 250:
                    carid = 1333;
                    break;
                case 251:
                    carid = 997;
                    break;
                case 252:
                    carid = 431;
                    break;
                case 253:
                    carid = 838;
                    break;
                case 254:
                    carid = 582;
                    break;
                case 255:
                    carid = 135;
                    break;
                case 256:
                    carid = 150;
                    break;
                case 257:
                    carid = 185;
                    break;
                case 258:
                    carid = 233;
                    break;
                case 259:
                    carid = 693;
                    break;
                case 260:
                    carid = 126;
                    break;
                case 261:
                    carid = 509;
                    break;
                case 262:
                    carid = 806;
                    break;
                case 263:
                    carid = 263;
                    break;
                case 264:
                    carid = 746;
                    break;
                case 265:
                    carid = 922;
                    break;
                case 266:
                    carid = 173;
                    break;
                case 267:
                    carid = 1011;
                    break;
                case 268:
                    carid = 15;
                    break;
                case 269:
                    carid = 1306;
                    break;
                case 270:
                    carid = 1266;
                    break;
                case 271:
                    carid = 1015;
                    break;
                case 272:
                    carid = 259;
                    break;
                case 273:
                    carid = 352;
                    break;
                case 274:
                    carid = 260;
                    break;
                case 275:
                    carid = 244;
                    break;
                case 276:
                    carid = 572;
                    break;
                case 277:
                    carid = 375;
                    break;
                case 278:
                    carid = 721;
                    break;
                case 279:
                    carid = 167;
                    break;
                case 280:
                    carid = 270;
                    break;
                case 281:
                    carid = 499;
                    break;
                case 282:
                    carid = 823;
                    break;
                case 283:
                    carid = 741;
                    break;
                case 284:
                    carid = 261;
                    break;
                case 285:
                    carid = 626;
                    break;
                case 286:
                    carid = 295;
                    break;
                case 287:
                    carid = 349;
                    break;
                case 288:
                    carid = 1394;
                    break;
                case 289:
                    carid = 704;
                    break;
                case 290:
                    carid = 1377;
                    break;
                case 291:
                    carid = 231;
                    break;
                case 292:
                    carid = 976;
                    break;
                case 293:
                    carid = 851;
                    break;
                case 294:
                    carid = 558;
                    break;
                case 295:
                    carid = 512;
                    break;
                case 296:
                    carid = 216;
                    break;
                case 297:
                    carid = 286;
                    break;
                case 298:
                    carid = 316;
                    break;
                case 299:
                    carid = 281;
                    break;
                case 300:
                    carid = 474;
                    break;
                case 301:
                    carid = 349;
                    break;
                case 302:
                    carid = 788;
                    break;
                case 303:
                    carid = 520;
                    break;
                case 304:
                    carid = 961;
                    break;
                case 305:
                    carid = 39;
                    break;
                case 306:
                    carid = 1141;
                    break;
                case 307:
                    carid = 1271;
                    break;
                case 308:
                    carid = 719;
                    break;
                case 309:
                    carid = 417;
                    break;
                case 310:
                    carid = 350;
                    break;
                case 311:
                    carid = 1144;
                    break;
                case 312:
                    carid = 109;
                    break;
                case 313:
                    carid = 46;
                    break;
                case 314:
                    carid = 1162;
                    break;
                case 315:
                    carid = 671;
                    break;
                case 316:
                    carid = 41;
                    break;
                case 317:
                    carid = 464;
                    break;
                case 318:
                    carid = 740;
                    break;
                case 319:
                    carid = 159;
                    break;
                case 320:
                    carid = 124;
                    break;
                case 321:
                    carid = 112;
                    break;
                case 322:
                    carid = 788;
                    break;
                case 323:
                    carid = 107;
                    break;
                case 324:
                    carid = 153;
                    break;
                case 325:
                    carid = 129;
                    break;
                case 326:
                    carid = 5;
                    break;
                case 327:
                    carid = 141;
                    break;
                case 328:
                    carid = 154;
                    break;
                case 329:
                    carid = 277;
                    break;
                case 330:
                    carid = 149;
                    break;
                case 331:
                    carid = 125;
                    break;
                case 332:
                    carid = 134;
                    break;
                case 333:
                    carid = 72;
                    break;
                case 334:
                    carid = 110;
                    break;
                case 335:
                    carid = 679;
                    break;
                case 336:
                    carid = 1409;
                    break;
                case 337:
                    carid = 71;
                    break;
                case 338:
                    carid = 1438;
                    break;
                case 339:
                    carid = 524;
                    break;
                case 340:
                    carid = 1301;
                    break;
                case 341:
                    carid = 728;
                    break;
                case 342:
                    carid = 240;
                    break;
                case 343:
                    carid = 1355;
                    break;
                case 344:
                    carid = 514;
                    break;
                case 345:
                    carid = 710;
                    break;
                case 346:
                    carid = 1313;
                    break;
                case 347:
                    carid = 373;
                    break;
                case 348:
                    carid = 466;
                    break;
                case 349:
                    carid = 711;
                    break;
                case 350:
                    carid = 1367;
                    break;
                case 351:
                    carid = 211;
                    break;
                case 352:
                    carid = 1354;
                    break;
                case 353:
                    carid = 608;
                    break;
                case 354:
                    carid = 614;
                    break;
                case 355:
                    carid = 565;
                    break;
                case 356:
                    carid = 332;
                    break;
                case 357:
                    carid = 49;
                    break;
                case 358:
                    carid = 732;
                    break;
                case 359:
                    carid = 686;
                    break;
                case 360:
                    carid = 1327;
                    break;
                case 361:
                    carid = 1206;
                    break;
                case 362:
                    carid = 783;
                    break;
                case 363:
                    carid = 1356;
                    break;
                case 364:
                    carid = 152;
                    break;
                case 365:
                    carid = 1317;
                    break;
                case 366:
                    carid = 143;
                    break;
                case 367:
                    carid = 145;
                    break;
                case 368:
                    carid = 898;
                    break;
                case 369:
                    carid = 274;
                    break;
                case 370:
                    carid = 176;
                    break;
                case 371:
                    carid = 669;
                    break;
                case 372:
                    carid = 317;
                    break;
                case 373:
                    carid = 171;
                    break;
                case 374:
                    carid = 1035;
                    break;
                case 375:
                    carid = 1043;
                    break;
                case 376:
                    carid = 296;
                    break;
                case 377:
                    carid = 445;
                    break;
                case 378:
                    carid = 725;
                    break;
                case 379:
                    carid = 1014;
                    break;
                case 380:
                    carid = 366;
                    break;
                case 381:
                    carid = 313;
                    break;
                case 382:
                    carid = 9;
                    break;
                case 383:
                    carid = 183;
                    break;
                case 384:
                    carid = 1049;
                    break;
                case 385:
                    carid = 735;
                    break;
                case 386:
                    carid = 372;
                    break;
                case 387:
                    carid = 916;
                    break;
                case 388:
                    carid = 646;
                    break;
                case 389:
                    carid = 856;
                    break;
                case 390:
                    carid = 847;
                    break;
                case 391:
                    carid = 561;
                    break;
                case 392:
                    carid = 1312;
                    break;
                case 393:
                    carid = 473;
                    break;
                case 394:
                    carid = 1310;
                    break;
                case 395:
                    carid = 839;
                    break;
                case 396:
                    carid = 471;
                    break;
                case 397:
                    carid = 175;
                    break;
                case 398:
                    carid = 1311;
                    break;
                case 399:
                    carid = 181;
                    break;
                case 400:
                    carid = 1316;
                    break;
                case 401:
                    carid = 339;
                    break;
                case 402:
                    carid = 723;
                    break;
                case 403:
                    carid = 817;
                    break;
                case 404:
                    carid = 1055;
                    break;
                case 405:
                    carid = 867;
                    break;
                case 406:
                    carid = 519;
                    break;
                case 407:
                    carid = 1398;
                    break;
                case 408:
                    carid = 777;
                    break;
                case 409:
                    carid = 667;
                    break;
                case 410:
                    carid = 34;
                    break;
                case 411:
                    carid = 871;
                    break;
                case 412:
                    carid = 1252;
                    break;
                case 413:
                    carid = 1365;
                    break;
                case 414:
                    carid = 470;
                    break;
                case 415:
                    carid = 539;
                    break;
                case 416:
                    carid = 1253;
                    break;
                case 417:
                    carid = 1390;
                    break;
                case 418:
                    carid = 882;
                    break;
                case 419:
                    carid = 1251;
                    break;
                case 420:
                    carid = 1258;
                    break;
                case 421:
                    carid = 508;
                    break;
                case 422:
                    carid = 892;
                    break;
                case 423:
                    carid = 1259;
                    break;
                case 424:
                    carid = 1262;
                    break;
                default:
                    carid = 0;
                    break;
            }
            return carid;
        }

        private int Identify3Car(int a)
        {
            int carid = 0;
            switch (a)
            {
                case 1:
                    carid = 1079;
                    break;
                case 2:
                    carid = 1046;
                    break;
                case 3:
                    carid = 32;
                    break;
                case 4:
                    carid = 1144;
                    break;
                case 5:
                    carid = 1138;
                    break;
                case 6:
                    carid = 1127;
                    break;
                case 7:
                    carid = 672;
                    break;
                case 8:
                    carid = 432;
                    break;
                case 9:
                    carid = 253;
                    break;
                case 10:
                    carid = 256;
                    break;
                case 11:
                    carid = 169;
                    break;
                case 12:
                    carid = 1146;
                    break;
                case 13:
                    carid = 1218;
                    break;
                case 14:
                    carid = 54;
                    break;
                case 15:
                    carid = 1394;
                    break;
                case 16:
                    carid = 176;
                    break;
                case 17:
                    carid = 681;
                    break;
                case 18:
                    carid = 855;
                    break;
                case 19:
                    carid = 1268;
                    break;
                case 20:
                    carid = 996;
                    break;
                case 21:
                    carid = 46;
                    break;
                case 22:
                    carid = 1132;
                    break;
                case 23:
                    carid = 1027;
                    break;
                case 24:
                    carid = 254;
                    break;
                case 25:
                    carid = 765;
                    break;
                case 26:
                    carid = 1368;
                    break;
                case 27:
                    carid = 1112;
                    break;
                case 28:
                    carid = 322;
                    break;
                case 29:
                    carid = 290;
                    break;
                case 30:
                    carid = 1356;
                    break;
                case 31:
                    carid = 1240;
                    break;
                case 32:
                    carid = 727;
                    break;
                case 33:
                    carid = 1327;
                    break;
                case 34:
                    carid = 1381;
                    break;
                case 35:
                    carid = 303;
                    break;
                case 36:
                    carid = 1276;
                    break;
                case 37:
                    carid = 171;
                    break;
                case 38:
                    carid = 1113;
                    break;
                case 39:
                    carid = 137;
                    break;
                case 40:
                    carid = 144;
                    break;
                case 41:
                    carid = 1235;
                    break;
                case 42:
                    carid = 1108;
                    break;
                case 43:
                    carid = 577;
                    break;
                case 44:
                    carid = 562;
                    break;
                case 45:
                    carid = 738;
                    break;
                case 46:
                    carid = 742;
                    break;
                case 47:
                    carid = 679;
                    break;
                case 48:
                    carid = 249;
                    break;
                case 49:
                    carid = 992;
                    break;
                case 50:
                    carid = 1054;
                    break;
                case 51:
                    carid = 362;
                    break;
                case 52:
                    carid = 243;
                    break;
                case 53:
                    carid = 439;
                    break;
                case 54:
                    carid = 435;
                    break;
                case 55:
                    carid = 305;
                    break;
                case 56:
                    carid = 440;
                    break;
                case 57:
                    carid = 175;
                    break;
                case 58:
                    carid = 641;
                    break;
                case 59:
                    carid = 576;
                    break;
                case 60:
                    carid = 534;
                    break;
                case 61:
                    carid = 64;
                    break;
                case 62:
                    carid = 232;
                    break;
                case 63:
                    carid = 1142;
                    break;
                case 64:
                    carid = 1117;
                    break;
                case 65:
                    carid = 912;
                    break;
                case 66:
                    carid = 283;
                    break;
                case 67:
                    carid = 1243;
                    break;
                case 68:
                    carid = 181;
                    break;
                case 69:
                    carid = 660;
                    break;
                case 70:
                    carid = 760;
                    break;
                case 71:
                    carid = 1279;
                    break;
                case 72:
                    carid = 579;
                    break;
                case 73:
                    carid = 1024;
                    break;
                case 74:
                    carid = 222;
                    break;
                case 75:
                    carid = 1277;
                    break;
                case 76:
                    carid = 471;
                    break;
                case 77:
                    carid = 1265;
                    break;
                case 78:
                    carid = 713;
                    break;
                case 79:
                    carid = 150;
                    break;
                case 80:
                    carid = 348;
                    break;
                case 81:
                    carid = 185;
                    break;
                case 82:
                    carid = 1183;
                    break;
                case 83:
                    carid = 183;
                    break;
                case 84:
                    carid = 749;
                    break;
                case 85:
                    carid = 820;
                    break;
                case 86:
                    carid = 507;
                    break;
                case 87:
                    carid = 896;
                    break;
                case 88:
                    carid = 37;
                    break;
                case 89:
                    carid = 1255;
                    break;
                case 90:
                    carid = 1313;
                    break;
                case 91:
                    carid = 1360;
                    break;
                case 92:
                    carid = 910;
                    break;
                case 93:
                    carid = 530;
                    break;
                case 94:
                    carid = 714;
                    break;
                case 95:
                    carid = 1439;
                    break;
                case 96:
                    carid = 698;
                    break;
                case 97:
                    carid = 1271;
                    break;
                case 98:
                    carid = 240;
                    break;
                case 99:
                    carid = 460;
                    break;
                case 100:
                    carid = 650;
                    break;
                case 101:
                    carid = 286;
                    break;
                case 102:
                    carid = 166;
                    break;
                case 103:
                    carid = 1005;
                    break;
                case 104:
                    carid = 826;
                    break;
                case 105:
                    carid = 756;
                    break;
                case 106:
                    carid = 366;
                    break;
                case 107:
                    carid = 313;
                    break;
                case 108:
                    carid = 708;
                    break;
                case 109:
                    carid = 470;
                    break;
                case 110:
                    carid = 504;
                    break;
                case 111:
                    carid = 505;
                    break;
                case 112:
                    carid = 1283;
                    break;
                case 113:
                    carid = 1418;
                    break;
                case 114:
                    carid = 671;
                    break;
                case 115:
                    carid = 29;
                    break;
                case 116:
                    carid = 1163;
                    break;
                case 117:
                    carid = 729;
                    break;
                case 118:
                    carid = 1367;
                    break;
                case 119:
                    carid = 850;
                    break;
                case 120:
                    carid = 1208;
                    break;
                case 121:
                    carid = 1284;
                    break;
                case 122:
                    carid = 329;
                    break;
                case 123:
                    carid = 1143;
                    break;
                case 124:
                    carid = 502;
                    break;
                case 125:
                    carid = 1207;
                    break;
                case 126:
                    carid = 990;
                    break;
                case 127:
                    carid = 835;
                    break;
                case 128:
                    carid = 539;
                    break;
                case 129:
                    carid = 380;
                    break;
                case 130:
                    carid = 382;
                    break;
                case 131:
                    carid = 392;
                    break;
                case 132:
                    carid = 395;
                    break;
                case 133:
                    carid = 649;
                    break;
                case 134:
                    carid = 680;
                    break;
                case 135:
                    carid = 381;
                    break;
                case 136:
                    carid = 410;
                    break;
                case 137:
                    carid = 16;
                    break;
                case 138:
                    carid = 145;
                    break;
                case 139:
                    carid = 509;
                    break;
                case 140:
                    carid = 922;
                    break;
                case 141:
                    carid = 158;
                    break;
                case 142:
                    carid = 748;
                    break;
                case 143:
                    carid = 250;
                    break;
                case 144:
                    carid = 1303;
                    break;
                case 145:
                    carid = 1376;
                    break;
                case 146:
                    carid = 233;
                    break;
                case 147:
                    carid = 658;
                    break;
                case 148:
                    carid = 734;
                    break;
                case 149:
                    carid = 350;
                    break;
                case 150:
                    carid = 21;
                    break;
                case 151:
                    carid = 335;
                    break;
                case 152:
                    carid = 310;
                    break;
                case 153:
                    carid = 312;
                    break;
                case 154:
                    carid = 1080;
                    break;
                case 155:
                    carid = 733;
                    break;
                case 156:
                    carid = 450;
                    break;
                case 157:
                    carid = 837;
                    break;
                case 158:
                    carid = 659;
                    break;
                case 159:
                    carid = 598;
                    break;
                case 160:
                    carid = 808;
                    break;
                case 161:
                    carid = 658;
                    break;
                case 162:
                    carid = 915;
                    break;
                case 163:
                    carid = 739;
                    break;
                case 164:
                    carid = 1121;
                    break;
                case 165:
                    carid = 456;
                    break;
                case 166:
                    carid = 724;
                    break;
                case 167:
                    carid = 1170;
                    break;
                case 168:
                    carid = 458;
                    break;
                case 169:
                    carid = 197;
                    break;
                case 170:
                    carid = 1130;
                    break;
                case 171:
                    carid = 99;
                    break;
                case 172:
                    carid = 675;
                    break;
                case 173:
                    carid = 1354;
                    break;
                case 174:
                    carid = 1155;
                    break;
                case 175:
                    carid = 374;
                    break;
                case 176:
                    carid = 174;
                    break;
                case 177:
                    carid = 1382;
                    break;
                case 178:
                    carid = 282;
                    break;
                case 179:
                    carid = 1333;
                    break;
                case 180:
                    carid = 1383;
                    break;
                case 181:
                    carid = 590;
                    break;
                case 182:
                    carid = 961;
                    break;
                case 183:
                    carid = 1371;
                    break;
                case 184:
                    carid = 1443;
                    break;
                case 185:
                    carid = 872;
                    break;
                case 186:
                    carid = 231;
                    break;
                case 187:
                    carid = 164;
                    break;
                case 188:
                    carid = 167;
                    break;
                case 189:
                    carid = 302;
                    break;
                case 190:
                    carid = 848;
                    break;
                case 191:
                    carid = 569;
                    break;
                case 192:
                    carid = 59;
                    break;
                case 193:
                    carid = 1206;
                    break;
                case 194:
                    carid = 725;
                    break;
                case 195:
                    carid = 998;
                    break;
                case 196:
                    carid = 521;
                    break;
                case 197:
                    carid = 777;
                    break;
                case 198:
                    carid = 258;
                    break;
                case 199:
                    carid = 667;
                    break;
                case 200:
                    carid = 373;
                    break;
                case 201:
                    carid = 531;
                    break;
                case 202:
                    carid = 838;
                    break;
                case 203:
                    carid = 252;
                    break;
                case 204:
                    carid = 669;
                    break;
                case 205:
                    carid = 690;
                    break;
                case 206:
                    carid = 1176;
                    break;
                case 207:
                    carid = 304;
                    break;
                case 208:
                    carid = 525;
                    break;
                case 209:
                    carid = 851;
                    break;
                case 210:
                    carid = 726;
                    break;
                case 211:
                    carid = 728;
                    break;
                case 212:
                    carid = 1248;
                    break;
                case 213:
                    carid = 1312;
                    break;
                case 214:
                    carid = 746;
                    break;
                case 215:
                    carid = 730;
                    break;
                case 216:
                    carid = 655;
                    break;
                case 217:
                    carid = 891;
                    break;
                case 218:
                    carid = 607;
                    break;
                case 219:
                    carid = 1025;
                    break;
                case 220:
                    carid = 703;
                    break;
                case 221:
                    carid = 614;
                    break;
                case 222:
                    carid = 1266;
                    break;
                case 223:
                    carid = 1411;
                    break;
                case 224:
                    carid = 1250;
                    break;
                case 225:
                    carid = 871;
                    break;
                case 226:
                    carid = 868;
                    break;
                case 227:
                    carid = 1120;
                    break;
                case 228:
                    carid = 609;
                    break;
                case 229:
                    carid = 1441;
                    break;
                case 230:
                    carid = 646;
                    break;
                case 231:
                    carid = 805;
                    break;
                case 232:
                    carid = 1285;
                    break;
                case 233:
                    carid = 319;
                    break;
                case 234:
                    carid = 171;
                    break;
                case 235:
                    carid = 587;
                    break;
                case 236:
                    carid = 511;
                    break;
                case 237:
                    carid = 535;
                    break;
                case 238:
                    carid = 182;
                    break;
                case 239:
                    carid = 61;
                    break;
                case 240:
                    carid = 184;
                    break;
                case 241:
                    carid = 897;
                    break;
                case 242:
                    carid = 427;
                    break;
                case 243:
                    carid = 442;
                    break;
                case 244:
                    carid = 429;
                    break;
                case 245:
                    carid = 441;
                    break;
                case 246:
                    carid = 741;
                    break;
                case 247:
                    carid = 430;
                    break;
                case 248:
                    carid = 908;
                    break;
                case 249:
                    carid = 1026;
                    break;
                case 250:
                    carid = 1370;
                    break;
                case 251:
                    carid = 347;
                    break;
                case 252:
                    carid = 1118;
                    break;
                case 253:
                    carid = 317;
                    break;
                case 254:
                    carid = 433;
                    break;
                case 255:
                    carid = 684;
                    break;
                case 256:
                    carid = 120;
                    break;
                case 257:
                    carid = 810;
                    break;
                case 258:
                    carid = 431;
                    break;
                case 259:
                    carid = 288;
                    break;
                case 260:
                    carid = 437;
                    break;
                case 261:
                    carid = 1021;
                    break;
                case 262:
                    carid = 295;
                    break;
                case 263:
                    carid = 325;
                    break;
                case 264:
                    carid = 204;
                    break;
                case 265:
                    carid = 60;
                    break;
                case 266:
                    carid = 281;
                    break;
                case 267:
                    carid = 1000;
                    break;
                case 268:
                    carid = 276;
                    break;
                case 269:
                    carid = 1011;
                    break;
                case 270:
                    carid = 351;
                    break;
                case 271:
                    carid = 721;
                    break;
                case 272:
                    carid = 260;
                    break;
                case 273:
                    carid = 1223;
                    break;
                case 274:
                    carid = 1306;
                    break;
                case 275:
                    carid = 224;
                    break;
                case 276:
                    carid = 723;
                    break;
                case 277:
                    carid = 103;
                    break;
                case 278:
                    carid = 963;
                    break;
                case 279:
                    carid = 881;
                    break;
                case 280:
                    carid = 352;
                    break;
                case 281:
                    carid = 1078;
                    break;
                case 282:
                    carid = 316;
                    break;
                case 283:
                    carid = 1049;
                    break;
                case 284:
                    carid = 259;
                    break;
                case 285:
                    carid = 263;
                    break;
                case 286:
                    carid = 141;
                    break;
                case 287:
                    carid = 574;
                    break;
                case 288:
                    carid = 375;
                    break;
                case 289:
                    carid = 218;
                    break;
                case 290:
                    carid = 261;
                    break;
                case 291:
                    carid = 572;
                    break;
                case 292:
                    carid = 264;
                    break;
                case 293:
                    carid = 704;
                    break;
                case 294:
                    carid = 1421;
                    break;
                case 295:
                    carid = 26;
                    break;
                case 296:
                    carid = 466;
                    break;
                case 297:
                    carid = 349;
                    break;
                case 298:
                    carid = 561;
                    break;
                case 299:
                    carid = 417;
                    break;
                case 300:
                    carid = 565;
                    break;
                case 301:
                    carid = 241;
                    break;
                case 302:
                    carid = 1390;
                    break;
                case 303:
                    carid = 1145;
                    break;
                case 304:
                    carid = 1366;
                    break;
                case 305:
                    carid = 583;
                    break;
                case 306:
                    carid = 321;
                    break;
                case 307:
                    carid = 1015;
                    break;
                case 308:
                    carid = 436;
                    break;
                case 309:
                    carid = 298;
                    break;
                case 310:
                    carid = 685;
                    break;
                case 311:
                    carid = 275;
                    break;
                case 312:
                    carid = 1379;
                    break;
                case 313:
                    carid = 517;
                    break;
                case 314:
                    carid = 869;
                    break;
                case 315:
                    carid = 216;
                    break;
                case 316:
                    carid = 524;
                    break;
                case 317:
                    carid = 41;
                    break;
                case 318:
                    carid = 976;
                    break;
                case 319:
                    carid = 962;
                    break;
                case 320:
                    carid = 558;
                    break;
                case 321:
                    carid = 506;
                    break;
                case 322:
                    carid = 1263;
                    break;
                case 323:
                    carid = 217;
                    break;
                case 324:
                    carid = 1123;
                    break;
                case 325:
                    carid = 1246;
                    break;
                case 326:
                    carid = 575;
                    break;
                case 327:
                    carid = 801;
                    break;
                case 328:
                    carid = 1162;
                    break;
                case 329:
                    carid = 151;
                    break;
                case 330:
                    carid = 157;
                    break;
                case 331:
                    carid = 109;
                    break;
                case 332:
                    carid = 172;
                    break;
                case 333:
                    carid = 124;
                    break;
                case 334:
                    carid = 107;
                    break;
                case 335:
                    carid = 719;
                    break;
                case 336:
                    carid = 142;
                    break;
                case 337:
                    carid = 173;
                    break;
                case 338:
                    carid = 165;
                    break;
                case 339:
                    carid = 1068;
                    break;
                case 340:
                    carid = 291;
                    break;
                case 341:
                    carid = 154;
                    break;
                case 342:
                    carid = 135;
                    break;
                case 343:
                    carid = 1063;
                    break;
                case 344:
                    carid = 693;
                    break;
                case 345:
                    carid = 143;
                    break;
                case 346:
                    carid = 792;
                    break;
                case 347:
                    carid = 71;
                    break;
                case 348:
                    carid = 1075;
                    break;
                case 349:
                    carid = 791;
                    break;
                default:
                    break;
            }
            
            return carid;
        }

        private int Identify4Car(int a)
        {
            int carid = 0;
            switch (a)
            {
                case 1:
                    carid = 727;
                    break;
                case 2:
                    carid = 1352;
                    break;
                case 3:
                    carid = 685;
                    break;
                case 4:
                    carid = 152;
                    break;
                case 5:
                    carid = 724;
                    break;
                case 6:
                    carid = 963;
                    break;
                case 7:
                    carid = 760;
                    break;
                case 8:
                    carid = 324;
                    break;
                case 9:
                    carid = 738;
                    break;
                case 10:
                    carid = 151;
                    break;
                case 11:
                    carid = 256;
                    break;
                case 12:
                    carid = 170;
                    break;
                case 13:
                    carid = 1266;
                    break;
                case 14:
                    carid = 1027;
                    break;
                case 15:
                    carid = 1078;
                    break;
                case 16:
                    carid = 1240;
                    break;
                case 17:
                    carid = 1080;
                    break;
                case 18:
                    carid = 681;
                    break;
                case 19:
                    carid = 1065;
                    break;
                case 20:
                    carid = 29;
                    break;
                case 21:
                    carid = 362;
                    break;
                case 22:
                    carid = 141;
                    break;
                case 23:
                    carid = 310;
                    break;
                case 24:
                    carid = 1079;
                    break;
                case 25:
                    carid = 698;
                    break;
                case 26:
                    carid = 1349;
                    break;
                case 27:
                    carid = 1075;
                    break;
                case 28:
                    carid = 791;
                    break;
                case 29:
                    carid = 516;
                    break;
                case 30:
                    carid = 1005;
                    break;
                case 31:
                    carid = 176;
                    break;
                case 32:
                    carid = 562;
                    break;
                case 33:
                    carid = 587;
                    break;
                case 34:
                    carid = 1276;
                    break;
                case 35:
                    carid = 35;
                    break;
                case 36:
                    carid = 1225;
                    break;
                case 37:
                    carid = 1073;
                    break;
                case 38:
                    carid = 1113;
                    break;
                case 39:
                    carid = 1098;
                    break;
                case 40:
                    carid = 808;
                    break;
                case 41:
                    carid = 990;
                    break;
                case 42:
                    carid = 641;
                    break;
                case 43:
                    carid = 749;
                    break;
                case 44:
                    carid = 319;
                    break;
                case 45:
                    carid = 1142;
                    break;
                case 46:
                    carid = 577;
                    break;
                case 47:
                    carid = 311;
                    break;
                case 48:
                    carid = 765;
                    break;
                case 49:
                    carid = 145;
                    break;
                case 50:
                    carid = 264;
                    break;
                case 51:
                    carid = 998;
                    break;
                case 52:
                    carid = 372;
                    break;
                case 53:
                    carid = 317;
                    break;
                case 54:
                    carid = 366;
                    break;
                case 55:
                    carid = 757;
                    break;
                case 56:
                    carid = 1011;
                    break;
                case 57:
                    carid = 276;
                    break;
                case 58:
                    carid = 345;
                    break;
                case 59:
                    carid = 299;
                    break;
                case 60:
                    carid = 728;
                    break;
                case 61:
                    carid = 991;
                    break;
                case 62:
                    carid = 684;
                    break;
                case 63:
                    carid = 283;
                    break;
                case 64:
                    carid = 433;
                    break;
                case 65:
                    carid = 287;
                    break;
                case 66:
                    carid = 1116;
                    break;
                case 67:
                    carid = 61;
                    break;
                case 68:
                    carid = 182;
                    break;
                case 69:
                    carid = 50;
                    break;
                case 70:
                    carid = 850;
                    break;
                case 71:
                    carid = 826;
                    break;
                case 72:
                    carid = 1279;
                    break;
                case 73:
                    carid = 710;
                    break;
                case 74:
                    carid = 660;
                    break;
                case 75:
                    carid = 1271;
                    break;
                case 76:
                    carid = 651;
                    break;
                case 77:
                    carid = 373;
                    break;
                case 78:
                    carid = 16;
                    break;
                case 79:
                    carid = 1183;
                    break;
                case 80:
                    carid = 64;
                    break;
                case 81:
                    carid = 471;
                    break;
                case 82:
                    carid = 507;
                    break;
                case 83:
                    carid = 168;
                    break;
                case 84:
                    carid = 52;
                    break;
                case 85:
                    carid = 1255;
                    break;
                case 86:
                    carid = 598;
                    break;
                case 87:
                    carid = 1146;
                    break;
                case 88:
                    carid = 1147;
                    break;
                case 89:
                    carid = 222;
                    break;
                case 90:
                    carid = 615;
                    break;
                case 91:
                    carid = 646;
                    break;
                case 92:
                    carid = 924;
                    break;
                case 93:
                    carid = 530;
                    break;
                case 94:
                    carid = 1439;
                    break;
                case 95:
                    carid = 1265;
                    break;
                case 96:
                    carid = 1327;
                    break;
                case 97:
                    carid = 329;
                    break;
                case 98:
                    carid = 1325;
                    break;
                case 99:
                    carid = 55;
                    break;
                case 100:
                    carid = 1287;
                    break;
                case 101:
                    carid = 472;
                    break;
                case 102:
                    carid = 240;
                    break;
                case 103:
                    carid = 1120;
                    break;
                case 104:
                    carid = 714;
                    break;
                case 105:
                    carid = 7;
                    break;
                case 106:
                    carid = 417;
                    break;
                case 107:
                    carid = 524;
                    break;
                case 108:
                    carid = 916;
                    break;
                case 109:
                    carid = 675;
                    break;
                case 110:
                    carid = 963;
                    break;
                case 111:
                    carid = 725;
                    break;
                case 112:
                    carid = 241;
                    break;
                case 113:
                    carid = 1440;
                    break;
                case 114:
                    carid = 439;
                    break;
                case 115:
                    carid = 1283;
                    break;
                case 116:
                    carid = 534;
                    break;
                case 117:
                    carid = 997;
                    break;
                case 118:
                    carid = 253;
                    break;
                case 119:
                    carid = 335;
                    break;
                case 120:
                    carid = 715;
                    break;
                case 121:
                    carid = 26;
                    break;
                case 122:
                    carid = 712;
                    break;
                case 123:
                    carid = 59;
                    break;
                case 124:
                    carid = 374;
                    break;
                case 125:
                    carid = 1301;
                    break;
                case 126:
                    carid = 349;
                    break;
                case 127:
                    carid = 1379;
                    break;
                case 128:
                    carid = 565;
                    break;
                case 129:
                    carid = 535;
                    break;
                case 130:
                    carid = 305;
                    break;
                case 131:
                    carid = 1411;
                    break;
                case 132:
                    carid = 410;
                    break;
                case 133:
                    carid = 704;
                    break;
                case 134:
                    carid = 393;
                    break;
                case 135:
                    carid = 851;
                    break;
                case 136:
                    carid = 915;
                    break;
                case 137:
                    carid = 392;
                    break;
                case 138:
                    carid = 415;
                    break;
                case 139:
                    carid = 382;
                    break;
                case 140:
                    carid = 1307;
                    break;
                case 141:
                    carid = 992;
                    break;
                case 142:
                    carid = 175;
                    break;
                case 143:
                    carid = 1176;
                    break;
                case 144:
                    carid = 838;
                    break;
                case 145:
                    carid = 746;
                    break;
                case 146:
                    carid = 473;
                    break;
                case 147:
                    carid = 531;
                    break;
                case 148:
                    carid = 659;
                    break;
                case 149:
                    carid = 837;
                    break;
                case 150:
                    carid = 21;
                    break;
                case 151:
                    carid = 835;
                    break;
                case 152:
                    carid = 1438;
                    break;
                case 153:
                    carid = 332;
                    break;
                case 154:
                    carid = 569;
                    break;
                case 155:
                    carid = 312;
                    break;
                case 156:
                    carid = 733;
                    break;
                case 157:
                    carid = 142;
                    break;
                case 158:
                    carid = 1138;
                    break;
                case 159:
                    carid = 450;
                    break;
                case 160:
                    carid = 1129;
                    break;
                case 161:
                    carid = 1127;
                    break;
                case 162:
                    carid = 726;
                    break;
                case 163:
                    carid = 456;
                    break;
                case 164:
                    carid = 435;
                    break;
                case 165:
                    carid = 466;
                    break;
                case 166:
                    carid = 460;
                    break;
                case 167:
                    carid = 672;
                    break;
                case 168:
                    carid = 1132;
                    break;
                case 169:
                    carid = 881;
                    break;
                case 170:
                    carid = 1268;
                    break;
                case 171:
                    carid = 504;
                    break;
                case 172:
                    carid = 636;
                    break;
                case 173:
                    carid = 561;
                    break;
                case 174:
                    carid = 962;
                    break;
                case 175:
                    carid = 961;
                    break;
                case 176:
                    carid = 590;
                    break;
                case 177:
                    carid = 441;
                    break;
                case 178:
                    carid = 626;
                    break;
                case 179:
                    carid = 742;
                    break;
                case 180:
                    carid = 165;
                    break;
                case 181:
                    carid = 1206;
                    break;
                case 182:
                    carid = 15;
                    break;
                case 183:
                    carid = 539;
                    break;
                case 184:
                    carid = 1208;
                    break;
                case 185:
                    carid = 308;
                    break;
                case 186:
                    carid = 1421;
                    break;
                case 187:
                    carid = 1163;
                    break;
                case 188:
                    carid = 1297;
                    break;
                case 189:
                    carid = 1316;
                    break;
                case 190:
                    carid = 381;
                    break;
                case 191:
                    carid = 729;
                    break;
                case 192:
                    carid = 257;
                    break;
                case 193:
                    carid = 669;
                    break;
                case 194:
                    carid = 688;
                    break;
                case 195:
                    carid = 544;
                    break;
                case 196:
                    carid = 1026;
                    break;
                case 197:
                    carid = 667;
                    break;
                case 198:
                    carid = 721;
                    break;
                case 199:
                    carid = 912;
                    break;
                case 200:
                    carid = 249;
                    break;
                case 201:
                    carid = 679;
                    break;
                case 202:
                    carid = 713;
                    break;
                case 203:
                    carid = 558;
                    break;
                case 204:
                    carid = 848;
                    break;
                case 205:
                    carid = 515;
                    break;
                case 206:
                    carid = 653;
                    break;
                case 207:
                    carid = 922;
                    break;
                case 208:
                    carid = 891;
                    break;
                case 209:
                    carid = 874;
                    break;
                case 210:
                    carid = 747;
                    break;
                case 211:
                    carid = 894;
                    break;
                case 212:
                    carid = 896;
                    break;
                case 213:
                    carid = 243;
                    break;
                case 214:
                    carid = 739;
                    break;
                case 215:
                    carid = 607;
                    break;
                case 216:
                    carid = 868;
                    break;
                case 217:
                    carid = 1248;
                    break;
                case 218:
                    carid = 1119;
                    break;
                case 219:
                    carid = 740;
                    break;
                case 220:
                    carid = 1257;
                    break;
                case 221:
                    carid = 996;
                    break;
                case 222:
                    carid = 871;
                    break;
                case 223:
                    carid = 936;
                    break;
                case 224:
                    carid = 1284;
                    break;
                case 225:
                    carid = 183;
                    break;
                case 226:
                    carid = 496;
                    break;
                case 227:
                    carid = 184;
                    break;
                case 228:
                    carid = 172;
                    break;
                case 229:
                    carid = 756;
                    break;
                case 230:
                    carid = 1223;
                    break;
                case 231:
                    carid = 741;
                    break;
                case 232:
                    carid = 181;
                    break;
                case 233:
                    carid = 897;
                    break;
                case 234:
                    carid = 427;
                    break;
                case 235:
                    carid = 442;
                    break;
                case 236:
                    carid = 445;
                    break;
                case 237:
                    carid = 438;
                    break;
                case 238:
                    carid = 144;
                    break;
                case 239:
                    carid = 428;
                    break;
                case 240:
                    carid = 440;
                    break;
                case 241:
                    carid = 1243;
                    break;
                case 242:
                    carid = 316;
                    break;
                case 243:
                    carid = 296;
                    break;
                case 244:
                    carid = 347;
                    break;
                case 245:
                    carid = 431;
                    break;
                case 246:
                    carid = 350;
                    break;
                case 247:
                    carid = 1262;
                    break;
                case 248:
                    carid = 1367;
                    break;
                case 249:
                    carid = 281;
                    break;
                case 250:
                    carid = 233;
                    break;
                case 251:
                    carid = 325;
                    break;
                case 252:
                    carid = 291;
                    break;
                case 253:
                    carid = 432;
                    break;
                case 254:
                    carid = 583;
                    break;
                case 255:
                    carid = 288;
                    break;
                case 256:
                    carid = 60;
                    break;
                case 257:
                    carid = 166;
                    break;
                case 258:
                    carid = 1303;
                    break;
                case 259:
                    carid = 1305;
                    break;
                case 260:
                    carid = 275;
                    break;
                case 261:
                    carid = 1258;
                    break;
                case 262:
                    carid = 676;
                    break;
                case 263:
                    carid = 252;
                    break;
                case 264:
                    carid = 171;
                    break;
                case 265:
                    carid = 664;
                    break;
                case 266:
                    carid = 153;
                    break;
                case 267:
                    carid = 352;
                    break;
                case 268:
                    carid = 1024;
                    break;
                case 269:
                    carid = 1117;
                    break;
                case 270:
                    carid = 1025;
                    break;
                case 271:
                    carid = 244;
                    break;
                case 272:
                    carid = 1383;
                    break;
                case 273:
                    carid = 650;
                    break;
                case 274:
                    carid = 464;
                    break;
                case 275:
                    carid = 375;
                    break;
                case 276:
                    carid = 272;
                    break;
                case 277:
                    carid = 304;
                    break;
                case 278:
                    carid = 297;
                    break;
                case 279:
                    carid = 1377;
                    break;
                case 280:
                    carid = 614;
                    break;
                case 281:
                    carid = 1368;
                    break;
                case 282:
                    carid = 1144;
                    break;
                case 283:
                    carid = 1443;
                    break;
                case 284:
                    carid = 409;
                    break;
                case 285:
                    carid = 1418;
                    break;
                case 286:
                    carid = 282;
                    break;
                case 287:
                    carid = 313;
                    break;
                case 288:
                    carid = 274;
                    break;
                case 289:
                    carid = 575;
                    break;
                default:
                    break;
            }
            return carid;
        }

        private int Identify5Car(int a)
        {
            int carid = 0;
            switch (a)
            {
                case 1:
                    carid = 757;
                    break;
                case 2:
                    carid = 1068;
                    break;
                case 3:
                    carid = 1276;
                    break;
                case 4:
                    carid = 848;
                    break;
                case 5:
                    carid = 256;
                    break;
                case 6:
                    carid = 996;
                    break;
                case 7:
                    carid = 850;
                    break;
                case 8:
                    carid = 838;
                    break;
                case 9:
                    carid = 760;
                    break;
                case 10:
                    carid = 151;
                    break;
                case 11:
                    carid = 175;
                    break;
                case 12:
                    carid = 785;
                    break;
                case 13:
                    carid = 1079;
                    break;
                case 14:
                    carid = 183;
                    break;
                case 15:
                    carid = 322;
                    break;
                case 16:
                    carid = 1356;
                    break;
                case 17:
                    carid = 646;
                    break;
                case 18:
                    carid = 141;
                    break;
                case 19:
                    carid = 29;
                    break;
                case 20:
                    carid = 1379;
                    break;
                case 21:
                    carid = 851;
                    break;
                case 22:
                    carid = 1398;
                    break;
                case 23:
                    carid = 1075;
                    break;
                case 24:
                    carid = 171;
                    break;
                case 25:
                    carid = 805;
                    break;
                case 26:
                    carid = 835;
                    break;
                case 27:
                    carid = 1327;
                    break;
                case 28:
                    carid = 517;
                    break;
                case 29:
                    carid = 749;
                    break;
                case 30:
                    carid = 641;
                    break;
                case 31:
                    carid = 185;
                    break;
                case 32:
                    carid = 587;
                    break;
                case 33:
                    carid = 496;
                    break;
                case 34:
                    carid = 1418;
                    break;
                case 35:
                    carid = 32;
                    break;
                case 36:
                    carid = 1368;
                    break;
                case 37:
                    carid = 1371;
                    break;
                case 38:
                    carid = 410;
                    break;
                case 39:
                    carid = 807;
                    break;
                case 40:
                    carid = 808;
                    break;
                case 41:
                    carid = 1061;
                    break;
                case 42:
                    carid = 817;
                    break;
                case 43:
                    carid = 1015;
                    break;
                case 44:
                    carid = 837;
                    break;
                case 45:
                    carid = 438;
                    break;
                case 46:
                    carid = 440;
                    break;
                case 47:
                    carid = 534;
                    break;
                case 48:
                    carid = 728;
                    break;
                case 49:
                    carid = 288;
                    break;
                case 50:
                    carid = 997;
                    break;
                case 51:
                    carid = 1026;
                    break;
                case 52:
                    carid = 362;
                    break;
                case 53:
                    carid = 325;
                    break;
                case 54:
                    carid = 445;
                    break;
                case 55:
                    carid = 1117;
                    break;
                case 56:
                    carid = 277;
                    break;
                case 57:
                    carid = 992;
                    break;
                case 58:
                    carid = 366;
                    break;
                case 59:
                    carid = 310;
                    break;
                case 60:
                    carid = 990;
                    break;
                case 61:
                    carid = 439;
                    break;
                case 62:
                    carid = 295;
                    break;
                case 63:
                    carid = 282;
                    break;
                case 64:
                    carid = 339;
                    break;
                case 65:
                    carid = 184;
                    break;
                case 66:
                    carid = 1266;
                    break;
                case 67:
                    carid = 450;
                    break;
                case 68:
                    carid = 756;
                    break;
                case 69:
                    carid = 714;
                    break;
                case 70:
                    carid = 651;
                    break;
                case 71:
                    carid = 1281;
                    break;
                case 72:
                    carid = 544;
                    break;
                case 73:
                    carid = 1285;
                    break;
                case 74:
                    carid = 924;
                    break;
                case 75:
                    carid = 329;
                    break;
                case 76:
                    carid = 61;
                    break;
                case 77:
                    carid = 372;
                    break;
                case 78:
                    carid = 64;
                    break;
                case 79:
                    carid = 1011;
                    break;
                case 80:
                    carid = 471;
                    break;
                case 81:
                    carid = 908;
                    break;
                case 82:
                    carid = 826;
                    break;
                case 83:
                    carid = 240;
                    break;
                case 84:
                    carid = 713;
                    break;
                case 85:
                    carid = 1265;
                    break;
                case 86:
                    carid = 543;
                    break;
                case 87:
                    carid = 1287;
                    break;
                case 88:
                    carid = 1271;
                    break;
                case 89:
                    carid = 319;
                    break;
                case 90:
                    carid = 1325;
                    break;
                case 91:
                    carid = 312;
                    break;
                case 92:
                    carid = 1183;
                    break;
                case 93:
                    carid = 765;
                    break;
                case 94:
                    carid = 417;
                    break;
                case 95:
                    carid = 59;
                    break;
                case 96:
                    carid = 1145;
                    break;
                case 97:
                    carid = 253;
                    break;
                case 98:
                    carid = 21;
                    break;
                case 99:
                    carid = 963;
                    break;
                case 100:
                    carid = 1394;
                    break;
                case 101:
                    carid = 561;
                    break;
                case 102:
                    carid = 1283;
                    break;
                case 103:
                    carid = 678;
                    break;
                case 104:
                    carid = 1421;
                    break;
                case 105:
                    carid = 524;
                    break;
                case 106:
                    carid = 514;
                    break;
                case 107:
                    carid = 998;
                    break;
                case 108:
                    carid = 1318;
                    break;
                case 109:
                    carid = 1362;
                    break;
                case 110:
                    carid = 62;
                    break;
                case 111:
                    carid = 15;
                    break;
                case 112:
                    carid = 636;
                    break;
                case 113:
                    carid = 415;
                    break;
                case 114:
                    carid = 374;
                    break;
                case 115:
                    carid = 848;
                    break;
                case 116:
                    carid = 1120;
                    break;
                case 117:
                    carid = 839;
                    break;
                case 118:
                    carid = 727;
                    break;
                case 119:
                    carid = 164;
                    break;
                case 120:
                    carid = 305;
                    break;
                case 121:
                    carid = 373;
                    break;
                case 122:
                    carid = 298;
                    break;
                case 123:
                    carid = 679;
                    break;
                case 124:
                    carid = 185;
                    break;
                case 125:
                    carid = 441;
                    break;
                case 126:
                    carid = 472;
                    break;
                case 127:
                    carid = 1170;
                    break;
                case 128:
                    carid = 562;
                    break;
                case 129:
                    carid = 1333;
                    break;
                case 130:
                    carid = 350;
                    break;
                case 131:
                    carid = 349;
                    break;
                case 132:
                    carid = 165;
                    break;
                case 133:
                    carid = 174;
                    break;
                case 134:
                    carid = 521;
                    break;
                case 135:
                    carid = 150;
                    break;
                case 136:
                    carid = 1021;
                    break;
                case 137:
                    carid = 976;
                    break;
                case 138:
                    carid = 382;
                    break;
                case 139:
                    carid = 1155;
                    break;
                case 140:
                    carid = 311;
                    break;
                case 141:
                    carid = 962;
                    break;
                case 142:
                    carid = 1176;
                    break;
                case 143:
                    carid = 1142;
                    break;
                case 144:
                    carid = 1138;
                    break;
                case 145:
                    carid = 724;
                    break;
                case 146:
                    carid = 144;
                    break;
                case 147:
                    carid = 1208;
                    break;
                case 148:
                    carid = 590;
                    break;
                case 149:
                    carid = 515;
                    break;
                case 150:
                    carid = 1128;
                    break;
                case 151:
                    carid = 531;
                    break;
                case 152:
                    carid = 936;
                    break;
                case 153:
                    carid = 614;
                    break;
                case 154:
                    carid = 166;
                    break;
                case 155:
                    carid = 704;
                    break;
                case 156:
                    carid = 335;
                    break;
                case 157:
                    carid = 558;
                    break;
                case 158:
                    carid = 1443;
                    break;
                case 159:
                    carid = 675;
                    break;
                case 160:
                    carid = 690;
                    break;
                case 161:
                    carid = 729;
                    break;
                case 162:
                    carid = 1243;
                    break;
                case 163:
                    carid = 258;
                    break;
                case 164:
                    carid = 257;
                    break;
                case 165:
                    carid = 684;
                    break;
                case 166:
                    carid = 520;
                    break;
                case 167:
                    carid = 680;
                    break;
                case 168:
                    carid = 715;
                    break;
                case 169:
                    carid = 565;
                    break;
                case 170:
                    carid = 655;
                    break;
                case 171:
                    carid = 871;
                    break;
                case 172:
                    carid = 874;
                    break;
                case 173:
                    carid = 63;
                    break;
                case 174:
                    carid = 594;
                    break;
                case 175:
                    carid = 176;
                    break;
                case 176:
                    carid = 922;
                    break;
                case 177:
                    carid = 869;
                    break;
                case 178:
                    carid = 1246;
                    break;
                case 179:
                    carid = 1018;
                    break;
                case 180:
                    carid = 726;
                    break;
                case 181:
                    carid = 891;
                    break;
                case 182:
                    carid = 243;
                    break;
                case 183:
                    carid = 1080;
                    break;
                case 184:
                    carid = 181;
                    break;
                case 185:
                    carid = 912;
                    break;
                case 186:
                    carid = 686;
                    break;
                case 187:
                    carid = 426;
                    break;
                case 188:
                    carid = 304;
                    break;
                case 189:
                    carid = 435;
                    break;
                case 190:
                    carid = 535;
                    break;
                case 191:
                    carid = 276;
                    break;
                case 192:
                    carid = 820;
                    break;
                case 193:
                    carid = 278;
                    break;
                case 194:
                    carid = 1119;
                    break;
                case 195:
                    carid = 283;
                    break;
                case 196:
                    carid = 427;
                    break;
                case 197:
                    carid = 281;
                    break;
                case 198:
                    carid = 431;
                    break;
                case 199:
                    carid = 289;
                    break;
                case 200:
                    carid = 1024;
                    break;
                case 201:
                    carid = 233;
                    break;
                case 202:
                    carid = 1284;
                    break;
                case 203:
                    carid = 170;
                    break;
                case 204:
                    carid = 347;
                    break;
                case 205:
                    carid = 612;
                    break;
                case 206:
                    carid = 442;
                    break;
                case 207:
                    carid = 569;
                    break;
                case 208:
                    carid = 26;
                    break;
                case 209:
                    carid = 319;
                    break;
                case 210:
                    carid = 746;
                    break;
                case 211:
                    carid = 681;
                    break;
                case 212:
                    carid = 159;
                    break;
                case 213:
                    carid = 321;
                    break;
                case 214:
                    carid = 1383;
                    break;
                case 215:
                    carid = 352;
                    break;
                case 216:
                    carid = 203;
                    break;
                case 217:
                    carid = 241;
                    break;
                case 218:
                    carid = 229;
                    break;
                case 219:
                    carid = 1268;
                    break;
                case 220:
                    carid = 316;
                    break;
                case 221:
                    carid = 437;
                    break;
                case 222:
                    carid = 430;
                    break;
                case 223:
                    carid = 392;
                    break;
                case 224:
                    carid = 303;
                    break;
                case 225:
                    carid = 1411;
                    break;
                case 226:
                    carid = 1127;
                    break;
                case 227:
                    carid = 1407;
                    break;
                case 228:
                    carid = 615;
                    break;
                case 229:
                    carid = 224;
                    break;
                case 230:
                    carid = 916;
                    break;
                case 231:
                    carid = 0;
                    break;
                case 232:
                    carid = 510;
                    break;
                case 233:
                    carid = 313;
                    break;
                case 234:
                    carid = 335;
                    break;
                case 235:
                    carid = 504;
                    break;
                case 236:
                    carid = 204;
                    break;
                case 237:
                    carid = 577;
                    break;
                case 238:
                    carid = 302;
                    break;
                case 239:
                    carid = 474;
                    break;
                case 240:
                    carid = 791;
                    break;
                case 241:
                    carid = 1434;
                    break;
                case 242:
                    carid = 890;
                    break;
                case 243:
                    carid = 784;
                    break;
                case 244:
                    carid = 1390;
                    break;
                case 245:
                    carid = 464;
                    break;
                case 246:
                    carid = 306;
                    break;
                case 247:
                    carid = 60;
                    break;
                case 248:
                    carid = 530;
                    break;
                case 249:
                    carid = 1162;
                    break;
                case 250:
                    carid = 47;
                    break;
                case 251:
                    carid = 1248;
                    break;
                case 252:
                    carid = 458;
                    break;
                case 253:
                    carid = 961;
                    break;
                case 254:
                    carid = 1143;
                    break;
                case 255:
                    carid = 217;
                    break;
                case 256:
                    carid = 512;
                    break;
                case 257:
                    carid = 576;
                    break;
                case 258:
                    carid = 1279;
                    break;
                case 259:
                    carid = 647;
                    break;
                case 260:
                    carid = 466;
                    break;
                case 261:
                    carid = 218;
                    break;
                case 262:
                    carid = 147;
                    break;
                case 263:
                    carid = 173;
                    break;
                case 264:
                    carid = 168;
                    break;
                case 265:
                    carid = 146;
                    break;
                case 266:
                    carid = 172;
                    break;
                case 267:
                    carid = 16;
                    break;
                case 268:
                    carid = 915;
                    break;
                case 269:
                    carid = 158;
                    break;
                case 270:
                    carid = 148;
                    break;
                case 271:
                    carid = 1225;
                    break;
                case 272:
                    carid = 409;
                    break;
                case 273:
                    carid = 142;
                    break;
                case 274:
                    carid = 1370;
                    break;
                case 275:
                    carid = 1005;
                    break;
                case 276:
                    carid = 821;
                    break;
                case 277:
                    carid = 1206;
                    break;
                case 278:
                    carid = 1307;
                    break;
                case 279:
                    carid = 525;
                    break;
                case 280:
                    carid = 712;
                    break;
                case 281:
                    carid = 721;
                    break;
                case 282:
                    carid = 1312;
                    break;
                case 283:
                    carid = 507;
                    break;
                case 284:
                    carid = 518;
                    break;
                case 285:
                    carid = 1303;
                    break;
                case 286:
                    carid = 539;
                    break;
                case 287:
                    carid = 393;
                    break;
                case 288:
                    carid = 516;
                    break;
                case 289:
                    carid = 1025;
                    break;
                case 290:
                    carid = 747;
                    break;
                case 291:
                    carid = 1240;
                    break;
                case 292:
                    carid = 279;
                    break;
                case 293:
                    carid = 1014;
                    break;
                case 294:
                    carid = 299;
                    break;
                case 295:
                    carid = 738;
                    break;
                case 296:
                    carid = 505;
                    break;
                case 297:
                    carid = 1409;
                    break;
                case 298:
                    carid = 381;
                    break;
                case 299:
                    carid = 1129;
                    break;
                case 300:
                    carid = 1366;
                    break;
                case 301:
                    carid = 502;
                    break;
                case 302:
                    carid = 703;
                    break;
                case 303:
                    carid = 145;
                    break;
                case 304:
                    carid = 211;
                    break;
                case 305:
                    carid = 1313;
                    break;
                case 306:
                    carid = 1310;
                    break;
                case 307:
                    carid = 897;
                    break;
                case 308:
                    carid = 1316;
                    break;
                default:
                    break;
            }
            return carid;
        }

        private int[] TrackRank(string[] a2)
        {
            int[] a3 = new int[5];
            for(int i = 0; i < 5; i++)
            {
                switch (a2[i])
                {
                    case "Улица ср":
                        a3[i] = 1;
                        break;
                    case "Улица мал":
                        a3[i] = 2;
                        break;
                    case "Подъем на холм":
                        a3[i] = 3;
                        break;
                    case "Мотокросс":
                        a3[i] = 4;
                        break;
                    case "50-150":
                        a3[i] = 5;
                        break;
                    case "75-125":
                        a3[i] = 6;
                        break;
                    case "0-100":
                        a3[i] = 7;
                        break;
                    case "0-100-0":
                        a3[i] = 8;
                        break;
                    case "1":
                        a3[i] = 9;
                        break;
                    case "1/2":
                        a3[i] = 10;
                        break;
                    case "1/4":
                        a3[i] = 11;
                        break;
                    case "Токио трасса":
                        a3[i] = 12;
                        break;
                    case "Трасса набережная":
                        a3[i] = 13;
                        break;
                    case "Тестовый круг":
                        a3[i] = 14;
                        break;
                    case "Токио мостик":
                        a3[i] = 15;
                        break;
                    case "Токио петля":
                        a3[i] = 16;
                        break;
                    case "Замерзшее озеро":
                        a3[i] = 17;
                        break;
                    case "Извилистая дорога":
                        a3[i] = 18;
                        break;
                    case "Быстрая трасса":
                        a3[i] = 19;
                        break;
                    case "Highway":
                        a3[i] = 20;
                        break;
                    case "Монако длинные городские улицы":
                        a3[i] = 21;
                        break;
                    case "Каньон экспедиция":
                        a3[i] = 22;
                        break;
                    case "Серпантин":
                        a3[i] = 23;
                        break;
                    case "Монако серпантин":
                        a3[i] = 24;
                        break;
                    case "Извилистая трасса":
                        a3[i] = 25;
                        break;
                    case "Токио мост":
                        a3[i] = 26;
                        break;
                    case "Токио съезд":
                        a3[i] = 27;
                        break;
                    case "Монако городские":
                        a3[i] = 28;
                        break;
                    case "Обзор":
                        a3[i] = 29;
                        break;
                    case "Каньон грунтовая дорога":
                        a3[i] = 30;
                        break;
                    case "Грунтовая дорога":
                        a3[i] = 31;
                        break;
                    case "Лесная переправа":
                        a3[i] = 32;
                        break;
                    case "Ралли-кросс мал":
                        a3[i] = 33;
                        break;
                    case "Ралли кросс ср":
                        a3[i] = 34;
                        break;
                    case "Крутой холм":
                        a3[i] = 35;
                        break;
                    case "Лесная дорога":
                        a3[i] = 36;
                        break;                   
                    case "Монако узкие улицы":
                        a3[i] = 37;
                        break;
                    case "Монако тест на перегрузки":
                        a3[i] = 38;
                        break;
                    case "Токио тест на перегрузки ":
                        a3[i] = 39;
                        break;
                    case "Трасса для картинга":
                        a3[i] = 40;
                        break;
                    case "Парковка":
                        a3[i] = 41;
                        break;
                    case "Лесной слалом":
                        a3[i] = 42;
                        break;
                    case "Закрытый картинг":
                        a3[i] = 43;
                        break;
                    case "Слалом":
                        a3[i] = 44;
                        break;
                    case "Перегрузка":
                        a3[i] = 45;
                        break;
                    case "Неизвестная трасса":
                        a3[i] = 100;
                        break;
                    default:
                        DoLog("Исправить название " + a2[i]);
                        a3[i] = 100;
                        break;
                }
            }
            return a3;
        }

        private void DeleteThis()
        {
            using(StreamWriter sw = new StreamWriter(@"C:\Users\Public\test\cases.txt", false, System.Text.Encoding.Default))
            {
                for(int i = 1; i<500; i++)
                {
                    sw.WriteLine("case " + i + ":");
                    sw.WriteLine("carid = 0;");
                    sw.WriteLine("break;"); 
                }
            }
        }

        private void ReadFile()
        {            
            string[] manufacturer = new string[2000];
            string[] model = new string[2000];
            string[] carclass = new string[2000];
            string[] rq = new string[2000];
            string[] year = new string[2000];
            string[] weight = new string[2000];
            string[] tires = new string[2000];
            string[] drive = new string[2000];
            string[] clearance = new string[2000];
            string[] ms = new string[2000];
            string[] acceleration = new string[2000];
            string[] grip = new string[2000];
            string[] abs = new string[2000];
            string[] tcs = new string[2000];
            string[] torque = new string[2000];
            string[] power = new string[2000];
            int i;

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\Manufacturer.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    manufacturer[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\Models.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    model[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\Class.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    carclass[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\RQ.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    rq[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\Year.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    year[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\Weight.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    weight[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\Tires.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    tires[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\Drive.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    drive[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\Clearance.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    clearance[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\MS.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    ms[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\Acceleration.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    acceleration[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\Grip.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    grip[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\abs.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    abs[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\tcs.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    tcs[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\Torque.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    torque[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamReader sr = new StreamReader(@"C:\Users\admin\Downloads\Power.txt", System.Text.Encoding.Default))
            {
                string line;
                i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    power[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Public\test\carstats.txt", false, System.Text.Encoding.Default))//true для дописывания             
            {
                for (int j = 1; j < (i + 1); j++)
                {
                    sw.WriteLine("case " + (j) + ":");
                    sw.WriteLine("DoLog(\"" + manufacturer[j] + " " + model[j] + " " + year[j] + " " + carclass[j] + rq[j] + "\");");
                    switch (clearance[j])
                    {
                        case "low":
                            sw.WriteLine("clearance = 1;");
                            break;
                        case "mid":
                            sw.WriteLine("clearance = 2;");
                            break;
                        case "high":
                            sw.WriteLine("clearance = 3;");
                            break;
                        default:
                            sw.WriteLine("clearance = 1;");
                            break;
                    }
                    switch (tires[j])
                    {
                        case "slick":
                            sw.WriteLine("tires = 1;");
                            break;
                        case "per":
                            sw.WriteLine("tires = 2;");
                            break;
                        case "std":
                            sw.WriteLine("tires = 3;");
                            break;
                        case "all":
                            sw.WriteLine("tires = 4;");
                            break;
                        case "off":
                            sw.WriteLine("tires = 5;");
                            break;
                        default:
                            sw.WriteLine("tires = 2;");
                            break;
                    }
                    switch (drive[j])
                    {
                        case "fwd":
                            sw.WriteLine("drive = 1;");
                            break;
                        case "rwd":
                            sw.WriteLine("drive = 2;");
                            break;
                        case "4wd":
                            sw.WriteLine("drive = 4;");
                            break;
                        default:
                            sw.WriteLine("drive = 2;");
                            break;
                    }
                    sw.WriteLine("acceleration = " + acceleration[j] + ";");
                    sw.WriteLine("maxspeed = " + ms[j] + ";");
                    sw.WriteLine("grip = " + grip[j] + ";");
                    sw.WriteLine("weight = " + weight[j] + ";");
                    sw.WriteLine("break;");
                }
                sw.Close();
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Public\test\cars.txt", false, System.Text.Encoding.Default))//true для дописывания             
            {
                for (int j = 1; j < (i + 1); j++)
                {
                    sw.WriteLine(j + " " + manufacturer[j] + " " + model[j] + " " + year[j] + " " + carclass[j] + rq[j]);                    
                }
                sw.Close();
            }

            /*using (StreamReader sr = new StreamReader(@"C:\Users\Public\test\1.txt", System.Text.Encoding.Default))
            {
                string line;                
                while((line = sr.ReadLine()) != null)
                {
                    a[i] = line;
                    i++;
                }
                sr.Close();
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Public\test\2.txt", false, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.Write("");
                sw.Close();
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Public\test\3.txt", false, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.Write("");
                sw.Close();
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Public\test\3.txt", true, System.Text.Encoding.Default))//true для дописывания             
            {
                for (int j = 0; j < i; j++)
                {
                    sw.Write((j + 1) + " ");
                    char[] b = new char[a[j].Length];
                    for (int k = 0; k < a[j].Length; k++)
                    {
                        b[k] = (a[j])[k];
                        string x = b[k].ToString();
                        if (!String.IsNullOrWhiteSpace(x) && b[k] != ',') sw.Write(b[k]);
                    }
                    sw.WriteLine("");
                }
                sw.Close();
            }

            using (StreamWriter sw = new StreamWriter(@"C:\Users\Public\test\2.txt", true, System.Text.Encoding.Default))//true для дописывания             
            {
                for(int j = 0; j < i; j++)
                {
                    sw.WriteLine("case " + (j + 1) + ":");
                    sw.Write("//");
                    char[] b = new char[a[j].Length];
                    for (int k = 0; k < a[j].Length; k++)
                    {
                        b[k] = (a[j])[k];
                        string x = b[k].ToString();
                        if (!String.IsNullOrWhiteSpace(x) && b[k] != ',') sw.Write(b[k]);
                    }
                    sw.WriteLine();
                    sw.WriteLine("id =" + (j + 1) + ";");
                    sw.WriteLine("height = 1;");
                    sw.WriteLine("tires = 2;");
                    sw.WriteLine("wd = 2;");
                    sw.WriteLine("ac = 100;");
                    sw.WriteLine("ms = 150;");
                    sw.WriteLine("handling = 75;");
                    sw.WriteLine("weight = 1500;");
                    sw.WriteLine("break;");
                }               
                sw.Close();
            }*/
        }

        private double[] CarStats(int carid)
        {
            int clearance;
            int tires;
            int drive;
            double acceleration;
            int maxspeed;
            int grip;
            int weight;

            switch (carid)
            {
                case 1:
                    DoLog("Acura NSX-T 1995 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5;
                    maxspeed = 168;
                    grip = 85;
                    weight = 1402;
                    break;
                case 2:
                    DoLog("Acura Integra GS-R 1994 d13");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.1;
                    maxspeed = 133;
                    grip = 77;
                    weight = 1060;
                    break;
                case 3:
                    DoLog("Acura Legend 3.2 V6 1990 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.2;
                    maxspeed = 140;
                    grip = 75;
                    weight = 1575;
                    break;
                case 4:
                    DoLog("Acura NSX 2016 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 2.9;
                    maxspeed = 191;
                    grip = 90;
                    weight = 1725;
                    break;
                case 5:
                    DoLog("Alfa Romeo 4C 2017 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.3;
                    maxspeed = 160;
                    grip = 85;
                    weight = 995;
                    break;
                case 6:
                    DoLog("Alfa Romeo 8C Competizione 2007 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4;
                    maxspeed = 182;
                    grip = 86;
                    weight = 1585;
                    break;
                case 7:
                    DoLog("Alfa Romeo Giulia Veloce 2017 b20");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.4;
                    maxspeed = 155;
                    grip = 82;
                    weight = 1490;
                    break;
                case 8:
                    DoLog("Alfa Romeo Brera S 2005 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.7;
                    maxspeed = 155;
                    grip = 78;
                    weight = 1540;
                    break;
                case 9:
                    DoLog("Alfa Romeo 147 GTA 2002 c16");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6;
                    maxspeed = 146;
                    grip = 80;
                    weight = 1360;
                    break;
                case 10:
                    DoLog("Alfa Romeo 156 GTA 2002 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.5;
                    maxspeed = 150;
                    grip = 80;
                    weight = 1410;
                    break;
                case 11:
                    DoLog("Alfa Romeo 164 Super 1987 c17");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.5;
                    maxspeed = 137;
                    grip = 77;
                    weight = 1210;
                    break;
                case 12:
                    DoLog("Alfa Romeo GT 2003 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.4;
                    maxspeed = 151;
                    grip = 80;
                    weight = 1410;
                    break;
                case 13:
                    DoLog("Alfa Romeo SZ 1989 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 7;
                    maxspeed = 152;
                    grip = 82;
                    weight = 1256;
                    break;
                case 14:
                    DoLog("Alfa Romeo GTV 1995 c16");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.4;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1415;
                    break;
                case 15:
                    DoLog("Alfa Romeo 166 1998 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.2;
                    maxspeed = 132;
                    grip = 76;
                    weight = 1420;
                    break;
                case 16:
                    DoLog("Alfa Romeo 75 1985 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.6;
                    maxspeed = 127;
                    grip = 76;
                    weight = 1160;
                    break;
                case 17:
                    DoLog("Alfa Romeo 159 2005 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8;
                    maxspeed = 142;
                    grip = 77;
                    weight = 1630;
                    break;
                case 18:
                    DoLog("Alfa Romeo 146 1994 d13");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.6;
                    maxspeed = 130;
                    grip = 79;
                    weight = 1225;
                    break;
                case 19:
                    DoLog("Alfa Romeo 145 Cloverleaf 1994 d13");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.6;
                    maxspeed = 129;
                    grip = 79;
                    weight = 1240;
                    break;
                case 20:
                    DoLog("Alfa Romeo 33 1993 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.7;
                    maxspeed = 119;
                    grip = 75;
                    weight = 910;
                    break;
                case 21:
                    DoLog("Alfa Romeo Alfasud 1982 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.5;
                    maxspeed = 115;
                    grip = 76;
                    weight = 865;
                    break;
                case 22:
                    DoLog("Alfa Romeo Montreal 1970 d13");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.6;
                    maxspeed = 138;
                    grip = 72;
                    weight = 1312;
                    break;
                case 23:
                    DoLog("Alfa Romeo 90 1984 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.8;
                    maxspeed = 119;
                    grip = 72;
                    weight = 1080;
                    break;
                case 24:
                    DoLog("Alfa Romeo Giulietta 2017 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9;
                    maxspeed = 121;
                    grip = 76;
                    weight = 1355;
                    break;
                case 25:
                    DoLog("Alfa Romeo Alfasud Sprint 1976 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.8;
                    maxspeed = 105;
                    grip = 75;
                    weight = 838;
                    break;
                case 26:
                    DoLog("Alfa Romeo Mito 2017 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.7;
                    maxspeed = 103;
                    grip = 74;
                    weight = 1155;
                    break;
                case 27:
                    DoLog("Alfa Romeo Alfetta GTV 1976 e9");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.7;
                    maxspeed = 118;
                    grip = 75;
                    weight = 1140;
                    break;
                case 28:
                    DoLog("Alfa Romeo 155 1992 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.8;
                    maxspeed = 125;
                    grip = 74;
                    weight = 1204;
                    break;
                case 29:
                    DoLog("Alfa Romeo Spider 2006 e10");
                    clearance = 1;
                    tires = 3;
                    drive = 1;
                    acceleration = 9;
                    maxspeed = 135;
                    grip = 75;
                    weight = 1530;
                    break;
                case 30:
                    DoLog("Alfa Romeo Giulia Quadrifoglio 2017 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.7;
                    maxspeed = 191;
                    grip = 88;
                    weight = 1524;
                    break;
                case 31:
                    DoLog("Audi RS 6 Avant 2013 a29");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.7;
                    maxspeed = 174;
                    grip = 86;
                    weight = 1935;
                    break;
                case 32:
                    DoLog("Audi RS 7 Sportback 2015 a28");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.7;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1930;
                    break;
                case 33:
                    DoLog("Audi S8 plus 2015 a30");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.3;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1990;
                    break;
                case 34:
                    DoLog("Audi RS 3 Sportback 2015 a29");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.1;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1520;
                    break;
                case 35:
                    DoLog("Audi TT RS plus Coupe 2012 a29");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.1;
                    maxspeed = 174;
                    grip = 84;
                    weight = 1475;
                    break;
                case 36:
                    DoLog("Audi SQ 5 2015 a28");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 4.8;
                    maxspeed = 155;
                    grip = 81;
                    weight = 2000;
                    break;
                case 37:
                    DoLog("Audi RS 6 plus 2004 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.4;
                    maxspeed = 174;
                    grip = 82;
                    weight = 1880;
                    break;
                case 38:
                    DoLog("Audi TTS Coupe 2015 a26");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.4;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1385;
                    break;
                case 39:
                    DoLog("Audi RS 4 Avant 2006 a26");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.7;
                    maxspeed = 155;
                    grip = 84;
                    weight = 1710;
                    break;
                case 40:
                    DoLog("Audi RS 5 Cabriolet 2012 a26");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.7;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1920;
                    break;
                case 41:
                    DoLog("Audi RS Q3 2015 a26");
                    clearance = 3;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.6;
                    maxspeed = 155;
                    grip = 82;
                    weight = 1655;
                    break;
                case 42:
                    DoLog("Audi RS 4 Avant 2000 a25");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.5;
                    maxspeed = 155;
                    grip = 83;
                    weight = 1620;
                    break;
                case 43:
                    DoLog("Audi S4 2012 a25");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.8;
                    maxspeed = 155;
                    grip = 83;
                    weight = 1705;
                    break;
                case 44:
                    DoLog("Audi S5 Coupe 2008 a25");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.9;
                    maxspeed = 155;
                    grip = 84;
                    weight = 1630;
                    break;
                case 45:
                    DoLog("Audi S8 2006 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.2;
                    maxspeed = 155;
                    grip = 81;
                    weight = 1940;
                    break;
                case 46:
                    DoLog("Audi RS 2 Avant 1994 a23");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.1;
                    maxspeed = 163;
                    grip = 80;
                    weight = 1595;
                    break;
                case 47:
                    DoLog("Audi S4 Avant 2004 a23");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.3;
                    maxspeed = 155;
                    grip = 82;
                    weight = 1660;
                    break;
                case 48:
                    DoLog("Audi S3 2006 a23");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.4;
                    maxspeed = 155;
                    grip = 82;
                    weight = 1455;
                    break;
                case 49:
                    DoLog("Audi S1 2014 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.5;
                    maxspeed = 155;
                    grip = 81;
                    weight = 1315;
                    break;
                case 50:
                    DoLog("Audi S4 1998 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.3;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1510;
                    break;
                case 51:
                    DoLog("Audi S6 2003 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.5;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1790;
                    break;
                case 52:
                    DoLog("Audi S2 Coupe 1993 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.5;
                    maxspeed = 154;
                    grip = 77;
                    weight = 1420;
                    break;
                case 53:
                    DoLog("Audi quattro 1980 c15");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 6.6;
                    maxspeed = 138;
                    grip = 74;
                    weight = 1300;
                    break;
                case 54:
                    DoLog("Audi quattro 20V 1990 c18");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 6;
                    maxspeed = 143;
                    grip = 77;
                    weight = 1380;
                    break;
                case 55:
                    DoLog("Audi S6 1997 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 6.4;
                    maxspeed = 150;
                    grip = 75;
                    weight = 1685;
                    break;
                case 56:
                    DoLog("Audi R8 Coupe V10 plus 2015 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 2.9;
                    maxspeed = 205;
                    grip = 88;
                    weight = 1555;
                    break;
                case 57:
                    DoLog("Audi Sport quattro S1 1986 s30");
                    clearance = 2;
                    tires = 5;
                    drive = 4;
                    acceleration = 3;
                    maxspeed = 155;
                    grip = 89;
                    weight = 1090;
                    break;
                case 58:
                    DoLog("Audi R8 Spyder V10 2013 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.6;
                    maxspeed = 194;
                    grip = 87;
                    weight = 1720;
                    break;
                case 59:
                    DoLog("Austin 1100 1963 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 16.9;
                    maxspeed = 87;
                    grip = 69;
                    weight = 776;
                    break;
                case 60:
                    DoLog("Austin Ambassador 1982 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.8;
                    maxspeed = 101;
                    grip = 70;
                    weight = 1105;
                    break;
                case 61:
                    DoLog("Austin Healey 3000 1959 f5");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 11.4;
                    maxspeed = 114;
                    grip = 65;
                    weight = 1143;
                    break;
                case 62:
                    DoLog("Austin Allegro 1979 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 16.5;
                    maxspeed = 83;
                    grip = 67;
                    weight = 800;
                    break;
                case 63:
                    DoLog("Austin Maxi 1969 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 16.2;
                    maxspeed = 88;
                    grip = 66;
                    weight = 979;
                    break;
                case 64:
                    DoLog("Austin Healey Sprite 1958 f3");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 20.9;
                    maxspeed = 80;
                    grip = 63;
                    weight = 664;
                    break;
                case 65:
                    DoLog("BMW M3 GTS 2010 a26");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.2;
                    maxspeed = 190;
                    grip = 88;
                    weight = 1605;
                    break;
                case 66:
                    DoLog("BMW M4 2016 a26");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1590;
                    break;
                case 67:
                    DoLog("BMW X5 M50d 2016 a25");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5.3;
                    maxspeed = 155;
                    grip = 75;
                    weight = 2190;
                    break;
                case 68:
                    DoLog("BMW M3 CRT 2011 a26");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.2;
                    maxspeed = 180;
                    grip = 85;
                    weight = 1655;
                    break;
                case 69:
                    DoLog("BMW M6 2016 a25");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.2;
                    maxspeed = 155;
                    grip = 86;
                    weight = 1850;
                    break;
                case 70:
                    DoLog("BMW M6 Gran Coupe 2013 a25");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4;
                    maxspeed = 155;
                    grip = 82;
                    weight = 1850;
                    break;
                case 71:
                    DoLog("BMW 740d 2016 a25");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 5.1;
                    maxspeed = 155;
                    grip = 75;
                    weight = 1860;
                    break;
                case 72:
                    DoLog("BMW 1-series M coupe 2011 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.8;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1495;
                    break;
                case 73:
                    DoLog("BMW M3 2008 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.6;
                    maxspeed = 155;
                    grip = 84;
                    weight = 1655;
                    break;
                case 74:
                    DoLog("BMW M5 2016 a26");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.7;
                    maxspeed = 155;
                    grip = 82;
                    weight = 1870;
                    break;
                case 75:
                    DoLog("BMW M5 2004 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1730;
                    break;
                case 76:
                    DoLog("BMW 335d 2016 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.5;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1705;
                    break;
                case 77:
                    DoLog("BMW M135i 2016 a23");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.9;
                    maxspeed = 155;
                    grip = 83;
                    weight = 1405;
                    break;
                case 78:
                    DoLog("BMW M3 CSL 2003 a23");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.7;
                    maxspeed = 161;
                    grip = 87;
                    weight = 1385;
                    break;
                case 79:
                    DoLog("BMW 750d xDrive 2013 a26");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 4.7;
                    maxspeed = 155;
                    grip = 74;
                    weight = 2070;
                    break;
                case 80:
                    DoLog("BMW M3 CS 2018 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.7;
                    maxspeed = 174;
                    grip = 88;
                    weight = 1660;
                    break;
                case 81:
                    DoLog("BMW M3 GTR 2001 a26");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 3.4;
                    maxspeed = 152;
                    grip = 92;
                    weight = 1111;
                    break;
                case 82:
                    DoLog("BMW M760Li xDrive V12 2015 a26");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.5;
                    maxspeed = 155;
                    grip = 79;
                    weight = 2255;
                    break;
                case 83:
                    DoLog("BMW M850i xDrive Convertible 2019 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.7;
                    maxspeed = 155;
                    grip = 83;
                    weight = 2090;
                    break;
                case 84:
                    DoLog("BMW X3 M40i 2018 a26");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 4.6;
                    maxspeed = 155;
                    grip = 74;
                    weight = 1940;
                    break;
                case 85:
                    DoLog("BMW X6 2015 a26");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 4.6;
                    maxspeed = 155;
                    grip = 74;
                    weight = 2304;
                    break;
                case 86:
                    DoLog("BMW 750i 2016 a25");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 155;
                    grip = 75;
                    weight = 1895;
                    break;
                case 87:
                    DoLog("BMW i8 2014 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.8;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1490;
                    break;
                case 88:
                    DoLog("BMW i8 Roadster 2018 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 4;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1670;
                    break;
                case 89:
                    DoLog("BMW M1 Procar Group 4 1979 a25");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 3.5;
                    maxspeed = 193;
                    grip = 90;
                    weight = 1020;
                    break;
                case 90:
                    DoLog("BMW M2 Competition (delimited) 2019 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4;
                    maxspeed = 174;
                    grip = 87;
                    weight = 1625;
                    break;
                case 91:
                    DoLog("BMW 750Li 2009 a24");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 4.9;
                    maxspeed = 155;
                    grip = 74;
                    weight = 1940;
                    break;
                case 92:
                    DoLog("BMW M140i 2017 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.4;
                    maxspeed = 155;
                    grip = 82;
                    weight = 1520;
                    break;
                case 93:
                    DoLog("BMW M2 (delimited) 2016 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.2;
                    maxspeed = 168;
                    grip = 86;
                    weight = 1570;
                    break;
                case 94:
                    DoLog("BMW M240i 2017 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.3;
                    maxspeed = 155;
                    grip = 82;
                    weight = 1545;
                    break;
                case 95:
                    DoLog("BMW M6 2006 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1785;
                    break;
                case 96:
                    DoLog("BMW Nazca C2 1992 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 190;
                    grip = 85;
                    weight = 1000;
                    break;
                case 97:
                    DoLog("BMW X3 35d 2014 a24");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5.5;
                    maxspeed = 152;
                    grip = 73;
                    weight = 1850;
                    break;
                case 98:
                    DoLog("BMW X4 2018 a24");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6;
                    maxspeed = 149;
                    grip = 75;
                    weight = 1795;
                    break;
                case 99:
                    DoLog("BMW 535i 2010 a23");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.5;
                    maxspeed = 155;
                    grip = 77;
                    weight = 1750;
                    break;
                case 100:
                    DoLog("BMW 545i 2004 a23");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.5;
                    maxspeed = 155;
                    grip = 76;
                    weight = 1705;
                    break;
                case 101:
                    DoLog("BMW M240i Convertible 2016 a23");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.7;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1690;
                    break;
                case 102:
                    DoLog("BMW X2 2018 a23");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.4;
                    maxspeed = 147;
                    grip = 76;
                    weight = 1660;
                    break;
                case 103:
                    DoLog("BMW M5 1998 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.9;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1795;
                    break;
                case 104:
                    DoLog("BMW M Coupe 1998 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.3;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1375;
                    break;
                case 105:
                    DoLog("BMW Z8 2000 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 155;
                    grip = 77;
                    weight = 1660;
                    break;
                case 106:
                    DoLog("BMW 640d 2016 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.5;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1790;
                    break;
                case 107:
                    DoLog("BMW M3 2001 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.4;
                    maxspeed = 155;
                    grip = 77;
                    weight = 1655;
                    break;
                case 108:
                    DoLog("BMW 530d 2004 b19");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.4;
                    maxspeed = 155;
                    grip = 75;
                    weight = 1565;
                    break;
                case 109:
                    DoLog("BMW M3 1993 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.4;
                    maxspeed = 155;
                    grip = 77;
                    weight = 1460;
                    break;
                case 110:
                    DoLog("BMW X5 40e (PHEV) 2016 b20");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.8;
                    maxspeed = 130;
                    grip = 69;
                    weight = 2230;
                    break;
                case 111:
                    DoLog("BMW 540i 1993 b19");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.1;
                    maxspeed = 155;
                    grip = 73;
                    weight = 1750;
                    break;
                case 112:
                    DoLog("BMW M5 1988 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.9;
                    maxspeed = 155;
                    grip = 76;
                    weight = 1653;
                    break;
                case 113:
                    DoLog("BMW X3 xDrive 28d 2016 b19");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.7;
                    maxspeed = 131;
                    grip = 68;
                    weight = 1700;
                    break;
                case 114:
                    DoLog("BMW 330d Touring 2014 b22");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.3;
                    maxspeed = 155;
                    grip = 74;
                    weight = 1615;
                    break;
                case 115:
                    DoLog("BMW 440i 2018 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.4;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1615;
                    break;
                case 116:
                    DoLog("BMW 640i xDrive 2012 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.1;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1900;
                    break;
                case 117:
                    DoLog("BMW M6 Convertible 2006 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.6;
                    maxspeed = 155;
                    grip = 83;
                    weight = 2005;
                    break;
                case 118:
                    DoLog("BMW X1 2017 b22");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.2;
                    maxspeed = 136;
                    grip = 75;
                    weight = 1625;
                    break;
                case 119:
                    DoLog("BMW X6 2012 b22");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.5;
                    maxspeed = 147;
                    grip = 72;
                    weight = 2185;
                    break;
                case 120:
                    DoLog("BMW 535d Touring 2009 b21");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.8;
                    maxspeed = 155;
                    grip = 75;
                    weight = 1853;
                    break;
                case 121:
                    DoLog("BMW 650i Convertible 2012 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.4;
                    maxspeed = 155;
                    grip = 80;
                    weight = 2005;
                    break;
                case 122:
                    DoLog("BMW X3 2003 b21");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.2;
                    maxspeed = 137;
                    grip = 72;
                    weight = 1885;
                    break;
                case 123:
                    DoLog("BMW X5 2008 b21");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.6;
                    maxspeed = 146;
                    grip = 70;
                    weight = 2185;
                    break;
                case 124:
                    DoLog("BMW Z4M Coupe 2006 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.8;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1495;
                    break;
                case 125:
                    DoLog("BMW 130i 2007 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.7;
                    maxspeed = 155;
                    grip = 81;
                    weight = 1400;
                    break;
                case 126:
                    DoLog("BMW 328i Gran Turismo 2014 b20");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.8;
                    maxspeed = 155;
                    grip = 73;
                    weight = 1645;
                    break;
                case 127:
                    DoLog("BMW 335i 2008 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.1;
                    maxspeed = 155;
                    grip = 75;
                    weight = 1610;
                    break;
                case 128:
                    DoLog("BMW 520d xDrive 2017 b20");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 7.2;
                    maxspeed = 144;
                    grip = 76;
                    weight = 1695;
                    break;
                case 129:
                    DoLog("BMW 640d 2011 b20");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.3;
                    maxspeed = 155;
                    grip = 81;
                    weight = 1790;
                    break;
                case 130:
                    DoLog("BMW 130i 2005 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.8;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1450;
                    break;
                case 131:
                    DoLog("BMW 135i Convertible 2008 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.4;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1600;
                    break;
                case 132:
                    DoLog("BMW 330d 2005 b19");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.3;
                    maxspeed = 155;
                    grip = 73;
                    weight = 1610;
                    break;
                case 133:
                    DoLog("BMW 330e 2016 b19");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.8;
                    maxspeed = 140;
                    grip = 72;
                    weight = 1735;
                    break;
                case 134:
                    DoLog("BMW 435i 2014 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.3;
                    maxspeed = 155;
                    grip = 74;
                    weight = 1650;
                    break;
                case 135:
                    DoLog("BMW 540i 1996 b19");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.9;
                    maxspeed = 155;
                    grip = 70;
                    weight = 1680;
                    break;
                case 136:
                    DoLog("BMW 645ci 2003 b19");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.4;
                    maxspeed = 155;
                    grip = 78;
                    weight = 1690;
                    break;
                case 137:
                    DoLog("BMW 650i Convertible 2005 b19");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.5;
                    maxspeed = 155;
                    grip = 77;
                    weight = 1925;
                    break;
                case 138:
                    DoLog("BMW H2R 2004 b19");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.2;
                    maxspeed = 188;
                    grip = 80;
                    weight = 1560;
                    break;
                case 139:
                    DoLog("BMW X5 4.4i 2000 b19");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.2;
                    maxspeed = 129;
                    grip = 68;
                    weight = 2180;
                    break;
                case 140:
                    DoLog("BMW 730d 2008 c18");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.9;
                    maxspeed = 152;
                    grip = 74;
                    weight = 1840;
                    break;
                case 141:
                    DoLog("BMW Z4 sDrive28i 2016 c18");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.4;
                    maxspeed = 155;
                    grip = 77;
                    weight = 1375;
                    break;
                case 142:
                    DoLog("BMW 328i 1991 c18");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7;
                    maxspeed = 147;
                    grip = 73;
                    weight = 1320;
                    break;
                case 143:
                    DoLog("BMW M5 1981 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.2;
                    maxspeed = 156;
                    grip = 74;
                    weight = 1431;
                    break;
                case 144:
                    DoLog("BMW M1 1978 c17");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.5;
                    maxspeed = 163;
                    grip = 75;
                    weight = 1300;
                    break;
                case 145:
                    DoLog("BMW 320d 2005 c18");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.1;
                    maxspeed = 146;
                    grip = 75;
                    weight = 1405;
                    break;
                case 146:
                    DoLog("BMW 740i 1994 c17");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.1;
                    maxspeed = 155;
                    grip = 72;
                    weight = 1840;
                    break;
                case 147:
                    DoLog("BMW 520i 2016 c15");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.8;
                    maxspeed = 146;
                    grip = 75;
                    weight = 1595;
                    break;
                case 148:
                    DoLog("BMW 730d 2002 c16");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.4;
                    maxspeed = 148;
                    grip = 73;
                    weight = 1875;
                    break;
                case 149:
                    DoLog("BMW M3 1986 c15");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.4;
                    maxspeed = 146;
                    grip = 76;
                    weight = 1165;
                    break;
                case 150:
                    DoLog("BMW 530i 1996 c18");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.7;
                    maxspeed = 155;
                    grip = 74;
                    weight = 1530;
                    break;
                case 151:
                    DoLog("BMW 220d xDrive Gran Tourer 2015 c18");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 7.2;
                    maxspeed = 135;
                    grip = 70;
                    weight = 1640;
                    break;
                case 152:
                    DoLog("BMW 750Li 1995 c18");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.5;
                    maxspeed = 155;
                    grip = 72;
                    weight = 2048;
                    break;
                case 153:
                    DoLog("BMW Z4 3.0si 2006 c18");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.3;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1385;
                    break;
                case 154:
                    DoLog("BMW 850CSi 1992 c17");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.7;
                    maxspeed = 155;
                    grip = 77;
                    weight = 1975;
                    break;
                case 155:
                    DoLog("BMW 123d 2007 c16");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.7;
                    maxspeed = 148;
                    grip = 76;
                    weight = 1495;
                    break;
                case 156:
                    DoLog("BMW 325i Convertible 2009 c16");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.2;
                    maxspeed = 152;
                    grip = 73;
                    weight = 1730;
                    break;
                case 157:
                    DoLog("BMW 330i 1998 c16");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.1;
                    maxspeed = 155;
                    grip = 74;
                    weight = 1505;
                    break;
                case 158:
                    DoLog("BMW 520d Touring 2017 c16");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.6;
                    maxspeed = 143;
                    grip = 76;
                    weight = 1730;
                    break;
                case 159:
                    DoLog("BMW 520d Touring 2012 c15");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.7;
                    maxspeed = 142;
                    grip = 75;
                    weight = 1800;
                    break;
                case 160:
                    DoLog("BMW Z3 2.2l 2000 d14");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.6;
                    maxspeed = 139;
                    grip = 74;
                    weight = 1245;
                    break;
                case 161:
                    DoLog("BMW 325i 1982 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.3;
                    maxspeed = 138;
                    grip = 70;
                    weight = 1209;
                    break;
                case 162:
                    DoLog("BMW 2002 turbo 1973 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.3;
                    maxspeed = 130;
                    grip = 66;
                    weight = 1060;
                    break;
                case 163:
                    DoLog("BMW 330d 1998 d14");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.8;
                    maxspeed = 150;
                    grip = 75;
                    weight = 1515;
                    break;
                case 164:
                    DoLog("BMW 320d Touring 2010 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.7;
                    maxspeed = 139;
                    grip = 72;
                    weight = 1580;
                    break;
                case 165:
                    DoLog("BMW 323i 1995 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.1;
                    maxspeed = 141;
                    grip = 70;
                    weight = 1385;
                    break;
                case 166:
                    DoLog("BMW 325iX 1988 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 8.1;
                    maxspeed = 132;
                    grip = 66;
                    weight = 1280;
                    break;
                case 167:
                    DoLog("BMW 220d Active Tourer 2014 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.2;
                    maxspeed = 141;
                    grip = 70;
                    weight = 1480;
                    break;
                case 168:
                    DoLog("BMW 525ix 1988 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 8.7;
                    maxspeed = 137;
                    grip = 66;
                    weight = 1645;
                    break;
                case 169:
                    DoLog("BMW i3 S 2017 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.5;
                    maxspeed = 99;
                    grip = 70;
                    weight = 1340;
                    break;
                case 170:
                    DoLog("BMW X1 2010 d12");
                    clearance = 3;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.1;
                    maxspeed = 124;
                    grip = 74;
                    weight = 1545;
                    break;
                case 171:
                    DoLog("BMW Z4 sDrive18i 2013 d12");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.5;
                    maxspeed = 137;
                    grip = 80;
                    weight = 1470;
                    break;
                case 172:
                    DoLog("BMW 320Si 2005 d11");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.5;
                    maxspeed = 140;
                    grip = 74;
                    weight = 1350;
                    break;
                case 173:
                    DoLog("BMW 635CSi 1980 d11");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.9;
                    maxspeed = 140;
                    grip = 70;
                    weight = 1427;
                    break;
                case 174:
                    DoLog("BMW i3 2013 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7;
                    maxspeed = 93;
                    grip = 69;
                    weight = 1297;
                    break;
                case 175:
                    DoLog("BMW 728i 1977 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.7;
                    maxspeed = 125;
                    grip = 70;
                    weight = 1470;
                    break;
                case 176:
                    DoLog("BMW Z1 1989 e10");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.8;
                    maxspeed = 136;
                    grip = 75;
                    weight = 1250;
                    break;
                case 177:
                    DoLog("BMW 116d 2015 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.8;
                    maxspeed = 124;
                    grip = 70;
                    weight = 1380;
                    break;
                case 178:
                    DoLog("BMW 730i 1986 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.1;
                    maxspeed = 138;
                    grip = 67;
                    weight = 1620;
                    break;
                case 179:
                    DoLog("BMW 316 1975 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 13.5;
                    maxspeed = 100;
                    grip = 63;
                    weight = 1020;
                    break;
                case 180:
                    DoLog("BMW 1800 1963 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 12;
                    maxspeed = 100;
                    grip = 60;
                    weight = 1100;
                    break;
                case 181:
                    DoLog("BMW 524td 1983 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 12.8;
                    maxspeed = 112;
                    grip = 63;
                    weight = 1330;
                    break;
                case 182:
                    DoLog("BMW 507 1956 f5");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 9;
                    maxspeed = 122;
                    grip = 61;
                    weight = 1315;
                    break;
                case 183:
                    DoLog("BMW 2002 Tii 1972 f6");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 9;
                    maxspeed = 120;
                    grip = 64;
                    weight = 1026;
                    break;
                case 184:
                    DoLog("BMW 2800 CS 1968 f6");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 9.3;
                    maxspeed = 124;
                    grip = 65;
                    weight = 1359;
                    break;
                case 185:
                    DoLog("BMW 525 1973 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 10;
                    maxspeed = 119;
                    grip = 62;
                    weight = 1380;
                    break;
                case 186:
                    DoLog("BMW Isetta 250 1955 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 99;
                    maxspeed = 53;
                    grip = 35;
                    weight = 350;
                    break;
                case 187:
                    DoLog("BMW M5 2018 s30");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 3;
                    maxspeed = 155;
                    grip = 86;
                    weight = 1930;
                    break;
                case 188:
                    DoLog("BMW M5 Competition (delimited) 2018 s30");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 2.9;
                    maxspeed = 190;
                    grip = 87;
                    weight = 1940;
                    break;
                case 189:
                    DoLog("BMW 640i xDrive Gran Coupe 2017 s28");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 5.1;
                    maxspeed = 155;
                    grip = 84;
                    weight = 2000;
                    break;
                case 190:
                    DoLog("BMW M8 GTE 2018 s28");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 3;
                    maxspeed = 200;
                    grip = 98;
                    weight = 1250;
                    break;
                case 191:
                    DoLog("BMW X6 M 2009 s28");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 4.5;
                    maxspeed = 155;
                    grip = 81;
                    weight = 2380;
                    break;
                case 192:
                    DoLog("BMW M4 GTS 2016 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.5;
                    maxspeed = 190;
                    grip = 90;
                    weight = 1637;
                    break;
                case 193:
                    DoLog("BMW M850i xDrive 2018 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.5;
                    maxspeed = 155;
                    grip = 86;
                    weight = 1965;
                    break;
                case 194:
                    DoLog("BMW X5 M 2009 s27");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 4.5;
                    maxspeed = 155;
                    grip = 80;
                    weight = 2380;
                    break;
                case 195:
                    DoLog("Bugatti Chiron 2017 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 2.4;
                    maxspeed = 261;
                    grip = 91;
                    weight = 1995;
                    break;
                case 196:
                    DoLog("Bugatti Veyron 16.4 2005 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 2.4;
                    maxspeed = 253;
                    grip = 89;
                    weight = 1888;
                    break;
                case 197:
                    DoLog("Bugatti Veyron 16.4 Grand Sport 2009 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 2.4;
                    maxspeed = 253;
                    grip = 89;
                    weight = 1990;
                    break;
                case 198:
                    DoLog("Bugatti Veyron 16.4 Super Sport 2010 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 2.4;
                    maxspeed = 267;
                    grip = 90;
                    weight = 1838;
                    break;
                case 199:
                    DoLog("Bugatti EB110 GT 1992 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.4;
                    maxspeed = 212;
                    grip = 87;
                    weight = 1618;
                    break;
                case 200:
                    DoLog("Bugatti Chiron Sport 2019 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 2.4;
                    maxspeed = 261;
                    grip = 92;
                    weight = 1978;
                    break;
                case 201:
                    DoLog("Bugatti EB110 Super Sport 1992 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.1;
                    maxspeed = 220;
                    grip = 88;
                    weight = 1418;
                    break;
                case 202:
                    DoLog("Buick Enclave 2008 b21");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.9;
                    maxspeed = 108;
                    grip = 77;
                    weight = 2233;
                    break;
                case 203:
                    DoLog("Buick Regal GS 2011 c16");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.5;
                    maxspeed = 158;
                    grip = 79;
                    weight = 1683;
                    break;
                case 204:
                    DoLog("Buick Regal Turbo 2011 c17");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.1;
                    maxspeed = 142;
                    grip = 80;
                    weight = 1665;
                    break;
                case 205:
                    DoLog("Buick GNX 1987 c18");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.3;
                    maxspeed = 124;
                    grip = 79;
                    weight = 1576;
                    break;
                case 206:
                    DoLog("Buick LaCrosse CXL 2005 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.7;
                    maxspeed = 142;
                    grip = 78;
                    weight = 1823;
                    break;
                case 207:
                    DoLog("Buick LeSabre 2000 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.9;
                    maxspeed = 138;
                    grip = 76;
                    weight = 1618;
                    break;
                case 208:
                    DoLog("Buick Park Avenue 2000 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.4;
                    maxspeed = 136;
                    grip = 77;
                    weight = 1714;
                    break;
                case 209:
                    DoLog("Buick Reatta 1988 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.9;
                    maxspeed = 125;
                    grip = 77;
                    weight = 1532;
                    break;
                case 210:
                    DoLog("Buick Riviera Coupe 1965 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.6;
                    maxspeed = 120;
                    grip = 69;
                    weight = 1955;
                    break;
                case 211:
                    DoLog("Buick Rendezvous 2002 e10");
                    clearance = 3;
                    tires = 4;
                    drive = 1;
                    acceleration = 12.8;
                    maxspeed = 118;
                    grip = 77;
                    weight = 1829;
                    break;
                case 212:
                    DoLog("Buick Roadmaster 1954 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.6;
                    maxspeed = 118;
                    grip = 73;
                    weight = 1842;
                    break;
                case 213:
                    DoLog("Buick Skylark GS 1954 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.1;
                    maxspeed = 120;
                    grip = 74;
                    weight = 1337;
                    break;
                case 214:
                    DoLog("Buick Verano 2012 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.5;
                    maxspeed = 125;
                    grip = 78;
                    weight = 1497;
                    break;
                case 215:
                    DoLog("Buick Century Special Coupe 1973 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.7;
                    maxspeed = 106;
                    grip = 70;
                    weight = 1473;
                    break;
                case 216:
                    DoLog("Cadillac XT5 2016 a23");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.6;
                    maxspeed = 130;
                    grip = 77;
                    weight = 1931;
                    break;
                case 217:
                    DoLog("Cadillac CT6 2016 a26");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 5;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1983;
                    break;
                case 218:
                    DoLog("Cadillac STS-V 2005 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 155;
                    grip = 83;
                    weight = 1948;
                    break;
                case 219:
                    DoLog("Cadillac CTS Vsport 2015 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 172;
                    grip = 82;
                    weight = 1699;
                    break;
                case 220:
                    DoLog("Cadillac CTS-V 2004 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.8;
                    maxspeed = 163;
                    grip = 83;
                    weight = 1745;
                    break;
                case 221:
                    DoLog("Cadillac Escalade 2011 b19");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.3;
                    maxspeed = 112;
                    grip = 65;
                    weight = 2527;
                    break;
                case 222:
                    DoLog("Cadillac CTS Coupe 2016 b22");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 6.7;
                    maxspeed = 155;
                    grip = 78;
                    weight = 1858;
                    break;
                case 223:
                    DoLog("Cadillac STS 2005 b22");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.9;
                    maxspeed = 155;
                    grip = 78;
                    weight = 1779;
                    break;
                case 224:
                    DoLog("Cadillac XLR-V 2006 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.6;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1726;
                    break;
                case 225:
                    DoLog("Cadillac Escalade EXT 2011 b21");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5.7;
                    maxspeed = 112;
                    grip = 68;
                    weight = 2650;
                    break;
                case 226:
                    DoLog("Cadillac Escalade ESV 2016 b20");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5.7;
                    maxspeed = 112;
                    grip = 68;
                    weight = 2740;
                    break;
                case 227:
                    DoLog("Cadillac CTS Sport Wagon 2014 b19");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.8;
                    maxspeed = 155;
                    grip = 77;
                    weight = 1885;
                    break;
                case 228:
                    DoLog("Cadillac Elmiraj 2013 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.7;
                    maxspeed = 165;
                    grip = 80;
                    weight = 1814;
                    break;
                case 229:
                    DoLog("Cadillac CTS 2016 c18");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.5;
                    maxspeed = 139;
                    grip = 74;
                    weight = 1751;
                    break;
                case 230:
                    DoLog("Cadillac XLR roadster 2004 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.8;
                    maxspeed = 155;
                    grip = 75;
                    weight = 1653;
                    break;
                case 231:
                    DoLog("Cadillac DTS 2006 c15");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 6.9;
                    maxspeed = 125;
                    grip = 75;
                    weight = 1818;
                    break;
                case 232:
                    DoLog("Cadillac SRX 2006 c16");
                    clearance = 3;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.6;
                    maxspeed = 140;
                    grip = 76;
                    weight = 1889;
                    break;
                case 233:
                    DoLog("Cadillac ELR 2016 c16");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 6.4;
                    maxspeed = 106;
                    grip = 80;
                    weight = 1844;
                    break;
                case 234:
                    DoLog("Cadillac Escalade 2002 d13");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 7.8;
                    maxspeed = 108;
                    grip = 65;
                    weight = 2635;
                    break;
                case 235:
                    DoLog("Cadillac Allante 1987 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.5;
                    maxspeed = 115;
                    grip = 69;
                    weight = 1610;
                    break;
                case 236:
                    DoLog("Cadillac Eldorado 1979 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.5;
                    maxspeed = 121;
                    grip = 66;
                    weight = 2240;
                    break;
                case 237:
                    DoLog("Cadillac Eldorado 1986 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.5;
                    maxspeed = 120;
                    grip = 68;
                    weight = 1635;
                    break;
                case 238:
                    DoLog("Cadillac Eldorado 1992 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.4;
                    maxspeed = 112;
                    grip = 69;
                    weight = 1743;
                    break;
                case 239:
                    DoLog("Cadillac Sedan De Ville 2000 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8;
                    maxspeed = 112;
                    grip = 69;
                    weight = 1804;
                    break;
                case 240:
                    DoLog("Cadillac Escalade 1999 e10");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 10.5;
                    maxspeed = 110;
                    grip = 65;
                    weight = 2218;
                    break;
                case 241:
                    DoLog("Cadillac Seville 1980 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.2;
                    maxspeed = 111;
                    grip = 68;
                    weight = 1822;
                    break;
                case 242:
                    DoLog("Cadillac Cimarron 1982 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 15.8;
                    maxspeed = 104;
                    grip = 66;
                    weight = 1145;
                    break;
                case 243:
                    DoLog("Cadillac DeVille 1977 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.6;
                    maxspeed = 108;
                    grip = 64;
                    weight = 2000;
                    break;
                case 244:
                    DoLog("Cadillac CTS-V 2016 s27");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.7;
                    maxspeed = 200;
                    grip = 84;
                    weight = 1880;
                    break;
                case 245:
                    DoLog("Cadillac ATS-V 2016 s27");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.8;
                    maxspeed = 189;
                    grip = 88;
                    weight = 1636;
                    break;
                case 246:
                    DoLog("Cadillac CTS-V Sport Wagon 2010 s27");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4;
                    maxspeed = 190;
                    grip = 86;
                    weight = 1995;
                    break;
                case 247:
                    DoLog("Cadillac Cien 2002 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.6;
                    maxspeed = 217;
                    grip = 87;
                    weight = 1500;
                    break;
                case 248:
                    DoLog("Cadillac Sixteen 2003 s28");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 4.1;
                    maxspeed = 205;
                    grip = 78;
                    weight = 2270;
                    break;
                case 249:
                    DoLog("Caterham Superlight R500 2008 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.9;
                    maxspeed = 150;
                    grip = 90;
                    weight = 506;
                    break;
                case 250:
                    DoLog("Caterham JPE 1992 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.5;
                    maxspeed = 150;
                    grip = 88;
                    weight = 530;
                    break;
                case 251:
                    DoLog("Caterham CSR 2005 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.1;
                    maxspeed = 155;
                    grip = 86;
                    weight = 570;
                    break;
                case 252:
                    DoLog("Caterham Seven 420 2015 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.8;
                    maxspeed = 136;
                    grip = 85;
                    weight = 560;
                    break;
                case 253:
                    DoLog("Caterham Seven 270 2015 b20");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 5;
                    maxspeed = 122;
                    grip = 77;
                    weight = 540;
                    break;
                case 254:
                    DoLog("Caterham Seven 360 2015 b20");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.8;
                    maxspeed = 130;
                    grip = 84;
                    weight = 560;
                    break;
                case 255:
                    DoLog("Caterham 21 1995 d12");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.7;
                    maxspeed = 127;
                    grip = 75;
                    weight = 665;
                    break;
                case 256:
                    DoLog("Caterham Seven 160 2013 e8");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.9;
                    maxspeed = 100;
                    grip = 70;
                    weight = 490;
                    break;
                case 257:
                    DoLog("Caterham RS Levante 2008 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.9;
                    maxspeed = 150;
                    grip = 90;
                    weight = 520;
                    break;
                case 258:
                    DoLog("Caterham Seven 620R 2013 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.8;
                    maxspeed = 155;
                    grip = 91;
                    weight = 572;
                    break;
                case 259:
                    DoLog("Chevrolet Corvette Z06 2005 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 199;
                    grip = 88;
                    weight = 1453;
                    break;
                case 260:
                    DoLog("Chevrolet Corvette Z06 Lingenfelter 2006 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.8;
                    maxspeed = 200;
                    grip = 87;
                    weight = 1434;
                    break;
                case 261:
                    DoLog("Chevrolet Corvette Stingray Z51 2016 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 181;
                    grip = 88;
                    weight = 1496;
                    break;
                case 262:
                    DoLog("Chevrolet Camaro ZL1 1LE 2018 a28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.5;
                    maxspeed = 198;
                    grip = 90;
                    weight = 1761;
                    break;
                case 263:
                    DoLog("Chevrolet Camaro Z/28 2016 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4;
                    maxspeed = 187;
                    grip = 87;
                    weight = 1702;
                    break;
                case 264:
                    DoLog("Chevrolet Corvette 2009 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 190;
                    grip = 86;
                    weight = 1459;
                    break;
                case 265:
                    DoLog("Chevrolet Corvette Grand Sport 2017 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.6;
                    maxspeed = 181;
                    grip = 88;
                    weight = 1555;
                    break;
                case 266:
                    DoLog("Chevrolet Camaro SS 2019 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.1;
                    maxspeed = 165;
                    grip = 85;
                    weight = 1671;
                    break;
                case 267:
                    DoLog("Chevrolet Camaro ZL1 2015 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.3;
                    maxspeed = 184;
                    grip = 86;
                    weight = 1869;
                    break;
                case 268:
                    DoLog("Chevrolet Camaro ZL1 2012 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 184;
                    grip = 86;
                    weight = 1869;
                    break;
                case 269:
                    DoLog("Chevrolet Copo Camaro 2018 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.1;
                    maxspeed = 185;
                    grip = 60;
                    weight = 1500;
                    break;
                case 270:
                    DoLog("Chevrolet Corvette Z06 2001 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.6;
                    maxspeed = 171;
                    grip = 85;
                    weight = 1409;
                    break;
                case 271:
                    DoLog("Chevrolet Camaro SS 2017 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.3;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1783;
                    break;
                case 272:
                    DoLog("Chevrolet Corvette ZR1 1993 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.7;
                    maxspeed = 181;
                    grip = 86;
                    weight = 1589;
                    break;
                case 273:
                    DoLog("Chevrolet Camaro SS Coupe 2010 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.6;
                    maxspeed = 155;
                    grip = 84;
                    weight = 1751;
                    break;
                case 274:
                    DoLog("Chevrolet Camaro Convertible 2012 b20");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.3;
                    maxspeed = 165;
                    grip = 82;
                    weight = 1867;
                    break;
                case 275:
                    DoLog("Chevrolet Corvette C5 1997 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.8;
                    maxspeed = 172;
                    grip = 80;
                    weight = 1460;
                    break;
                case 276:
                    DoLog("Chevrolet Aerovette 1977 b20");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 175;
                    grip = 75;
                    weight = 1180;
                    break;
                case 277:
                    DoLog("Chevrolet Corvette Grand Sport 1996 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.2;
                    maxspeed = 165;
                    grip = 85;
                    weight = 1520;
                    break;
                case 278:
                    DoLog("Chevrolet Tahoe Custom 2018 b21");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.1;
                    maxspeed = 105;
                    grip = 75;
                    weight = 2010;
                    break;
                case 279:
                    DoLog("Chevrolet Trailblazer SS 2006 b20");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5.6;
                    maxspeed = 142;
                    grip = 62;
                    weight = 2145;
                    break;
                case 280:
                    DoLog("Chevrolet Camaro Z28 SS 1999 b19");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.1;
                    maxspeed = 160;
                    grip = 79;
                    weight = 1550;
                    break;
                case 281:
                    DoLog("Chevrolet Cobalt SS S/C 2006 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.9;
                    maxspeed = 158;
                    grip = 79;
                    weight = 1273;
                    break;
                case 282:
                    DoLog("Chevrolet Cobalt SS Turbo 2009 b21");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.5;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1349;
                    break;
                case 283:
                    DoLog("Chevrolet Colorado ZR2 2018 b22");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 7.1;
                    maxspeed = 100;
                    grip = 76;
                    weight = 2005;
                    break;
                case 284:
                    DoLog("Chevrolet COPO Camaro 2012 b22");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 2.2;
                    maxspeed = 180;
                    grip = 60;
                    weight = 1550;
                    break;
                case 285:
                    DoLog("Chevrolet Miray 2011 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 4;
                    maxspeed = 110;
                    grip = 86;
                    weight = 1600;
                    break;
                case 286:
                    DoLog("Chevrolet Suburban 2016 c18");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.1;
                    maxspeed = 113;
                    grip = 64;
                    weight = 2534;
                    break;
                case 287:
                    DoLog("Chevrolet Corvette ZR2 1981 c17");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.9;
                    maxspeed = 165;
                    grip = 72;
                    weight = 1520;
                    break;
                case 288:
                    DoLog("Chevrolet Monte Carlo SS 2006 c18");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6;
                    maxspeed = 145;
                    grip = 77;
                    weight = 1583;
                    break;
                case 289:
                    DoLog("Chevrolet Camaro IROC Z/28 1990 c16");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.7;
                    maxspeed = 146;
                    grip = 77;
                    weight = 1520;
                    break;
                case 290:
                    DoLog("Chevrolet HHR SS Turbocharged 2008 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.7;
                    maxspeed = 150;
                    grip = 77;
                    weight = 1491;
                    break;
                case 291:
                    DoLog("Chevrolet Silverado SS 2006 c16");
                    clearance = 3;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.7;
                    maxspeed = 110;
                    grip = 75;
                    weight = 1690;
                    break;
                case 292:
                    DoLog("Chevrolet Camaro Z/28 1993 c15");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.4;
                    maxspeed = 146;
                    grip = 71;
                    weight = 1520;
                    break;
                case 293:
                    DoLog("Chevrolet Captiva LTX 2008 c16");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 11.1;
                    maxspeed = 111;
                    grip = 76;
                    weight = 1820;
                    break;
                case 294:
                    DoLog("Chevrolet Silverado 2016 c16");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 8.8;
                    maxspeed = 105;
                    grip = 65;
                    weight = 2422;
                    break;
                case 295:
                    DoLog("Chevrolet Camaro IROC-Z 1984 c16");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.3;
                    maxspeed = 130;
                    grip = 76;
                    weight = 1350;
                    break;
                case 296:
                    DoLog("Chevrolet K5 Blazer 5.7L 1972 c16");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 9.5;
                    maxspeed = 96;
                    grip = 62;
                    weight = 1700;
                    break;
                case 297:
                    DoLog("Chevrolet Corvette C4 1984 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.9;
                    maxspeed = 140;
                    grip = 69;
                    weight = 1415;
                    break;
                case 298:
                    DoLog("Chevrolet El Camino SS 454 1970 c15");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5;
                    maxspeed = 142;
                    grip = 57;
                    weight = 1681;
                    break;
                case 299:
                    DoLog("Chevrolet SSR 6.0L 2007 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.5;
                    maxspeed = 131;
                    grip = 78;
                    weight = 2159;
                    break;
                case 300:
                    DoLog("Chevrolet Beretta GTZ 1991 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.5;
                    maxspeed = 131;
                    grip = 77;
                    weight = 1268;
                    break;
                case 301:
                    DoLog("Chevrolet Orlando LTZ 2010 d11");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.7;
                    maxspeed = 121;
                    grip = 78;
                    weight = 1655;
                    break;
                case 302:
                    DoLog("Chevrolet Lumina Z34 1991 d13");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.9;
                    maxspeed = 130;
                    grip = 74;
                    weight = 1541;
                    break;
                case 303:
                    DoLog("Chevrolet Malibu 2019 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.8;
                    maxspeed = 115;
                    grip = 78;
                    weight = 1400;
                    break;
                case 304:
                    DoLog("Chevrolet Monte Carlo SS Jeff Gordon Edition 2003 d14");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.1;
                    maxspeed = 135;
                    grip = 78;
                    weight = 1538;
                    break;
                case 305:
                    DoLog("Chevrolet Corvette 396 1965 d13");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.8;
                    maxspeed = 148;
                    grip = 61;
                    weight = 1524;
                    break;
                case 306:
                    DoLog("Chevrolet Camaro Z/28 1970 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.3;
                    maxspeed = 140;
                    grip = 62;
                    weight = 1650;
                    break;
                case 307:
                    DoLog("Chevrolet Corvette LT-1 1970 d11");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6;
                    maxspeed = 137;
                    grip = 61;
                    weight = 1529;
                    break;
                case 308:
                    DoLog("Chevrolet Corvette ZR1 1971 d12");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6;
                    maxspeed = 140;
                    grip = 62;
                    weight = 1529;
                    break;
                case 309:
                    DoLog("Chevrolet Impala SS 1996 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.1;
                    maxspeed = 145;
                    grip = 65;
                    weight = 1842;
                    break;
                case 310:
                    DoLog("Chevrolet Monte Carlo 1970 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.3;
                    maxspeed = 150;
                    grip = 58;
                    weight = 1719;
                    break;
                case 311:
                    DoLog("Chevrolet SSR 2003 d12");
                    clearance = 3;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.7;
                    maxspeed = 125;
                    grip = 76;
                    weight = 2159;
                    break;
                case 312:
                    DoLog("Chevrolet Chevelle SS 454 1970 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.3;
                    maxspeed = 130;
                    grip = 57;
                    weight = 1786;
                    break;
                case 313:
                    DoLog("Chevrolet Captiva 2007 d14");
                    clearance = 3;
                    tires = 4;
                    drive = 1;
                    acceleration = 10.1;
                    maxspeed = 117;
                    grip = 76;
                    weight = 1778;
                    break;
                case 314:
                    DoLog("Chevrolet Blazer 2000 d11");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 10.7;
                    maxspeed = 102;
                    grip = 65;
                    weight = 1825;
                    break;
                case 315:
                    DoLog("Chevrolet Impala 1959 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7;
                    maxspeed = 119;
                    grip = 65;
                    weight = 1700;
                    break;
                case 316:
                    DoLog("Chevrolet Tru 140S 2012 d12");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 8;
                    maxspeed = 135;
                    grip = 80;
                    weight = 1280;
                    break;
                case 317:
                    DoLog("Chevrolet Code 130R 2012 d14");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.1;
                    maxspeed = 130;
                    grip = 81;
                    weight = 1300;
                    break;
                case 318:
                    DoLog("Chevrolet Caprice 1991 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.5;
                    maxspeed = 118;
                    grip = 70;
                    weight = 1850;
                    break;
                case 319:
                    DoLog("Chevrolet Tahoe 1995 e7");
                    clearance = 3;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.3;
                    maxspeed = 106;
                    grip = 59;
                    weight = 2419;
                    break;
                case 320:
                    DoLog("Chevrolet Camaro berlinetta 1983 e8");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 10;
                    maxspeed = 123;
                    grip = 70;
                    weight = 1388;
                    break;
                case 321:
                    DoLog("Chevrolet Camaro Z/28 1977 e9");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.7;
                    maxspeed = 119;
                    grip = 63;
                    weight = 1557;
                    break;
                case 322:
                    DoLog("Chevrolet Impala SS427 1967 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.5;
                    maxspeed = 149;
                    grip = 59;
                    weight = 1857;
                    break;
                case 323:
                    DoLog("Chevrolet El Camino 1963 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.1;
                    maxspeed = 116;
                    grip = 66;
                    weight = 1388;
                    break;
                case 324:
                    DoLog("Chevrolet Impala SS 1964 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.2;
                    maxspeed = 130;
                    grip = 68;
                    weight = 1740;
                    break;
                case 325:
                    DoLog("Chevrolet S-10 Blazer Xtreme 1999 e9");
                    clearance = 3;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.7;
                    maxspeed = 105;
                    grip = 74;
                    weight = 1459;
                    break;
                case 326:
                    DoLog("Chevrolet Aveo 2011 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.2;
                    maxspeed = 105;
                    grip = 77;
                    weight = 1065;
                    break;
                case 327:
                    DoLog("Chevrolet 454 SS 1990 e8");
                    clearance = 3;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.2;
                    maxspeed = 110;
                    grip = 68;
                    weight = 2005;
                    break;
                case 328:
                    DoLog("Chevrolet Cruze LS 2009 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.6;
                    maxspeed = 118;
                    grip = 77;
                    weight = 1285;
                    break;
                case 329:
                    DoLog("Chevrolet Blazer S-10 1983 e8");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 18.2;
                    maxspeed = 84;
                    grip = 52;
                    weight = 1540;
                    break;
                case 330:
                    DoLog("Chevrolet El Camino 1981 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.1;
                    maxspeed = 95;
                    grip = 66;
                    weight = 1462;
                    break;
                case 331:
                    DoLog("Chevrolet Lacetti 2004 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.6;
                    maxspeed = 109;
                    grip = 75;
                    weight = 1170;
                    break;
                case 332:
                    DoLog("Chevrolet Cruze LT 2012 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.6;
                    maxspeed = 111;
                    grip = 78;
                    weight = 1429;
                    break;
                case 333:
                    DoLog("Chevrolet Cruze SW 2012 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12;
                    maxspeed = 115;
                    grip = 78;
                    weight = 1475;
                    break;
                case 334:
                    DoLog("Chevrolet Monte Carlo SS 1983 e7");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.9;
                    maxspeed = 112;
                    grip = 62;
                    weight = 1355;
                    break;
                case 335:
                    DoLog("Chevrolet Volt 2012 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.7;
                    maxspeed = 99;
                    grip = 78;
                    weight = 1715;
                    break;
                case 336:
                    DoLog("Chevrolet Spark 2009 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 15;
                    maxspeed = 96;
                    grip = 76;
                    weight = 864;
                    break;
                case 337:
                    DoLog("Chevrolet Bel Air 1957 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.1;
                    maxspeed = 110;
                    grip = 62;
                    weight = 1548;
                    break;
                case 338:
                    DoLog("Chevrolet Chevette 1976 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 15;
                    maxspeed = 91;
                    grip = 66;
                    weight = 923;
                    break;
                case 339:
                    DoLog("Chevrolet Corvette 1953 f5");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 11.5;
                    maxspeed = 105;
                    grip = 65;
                    weight = 1293;
                    break;
                case 340:
                    DoLog("Chevrolet Matiz 2005 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 17.6;
                    maxspeed = 90;
                    grip = 74;
                    weight = 775;
                    break;
                case 341:
                    DoLog("Chevrolet Fleetline 1948 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 15.4;
                    maxspeed = 85;
                    grip = 59;
                    weight = 1431;
                    break;
                case 342:
                    DoLog("Chevrolet Corvette ZR1 2019 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.9;
                    maxspeed = 210;
                    grip = 90;
                    weight = 1598;
                    break;
                case 343:
                    DoLog("Chevrolet Corvette Z06 2016 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.1;
                    maxspeed = 185;
                    grip = 89;
                    weight = 1598;
                    break;
                case 344:
                    DoLog("Chrysler 300 SRT8 2012 a23");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 175;
                    grip = 79;
                    weight = 1991;
                    break;
                case 345:
                    DoLog("Chrysler Crossfire SRT-6 Coupe 2004 b19");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.1;
                    maxspeed = 158;
                    grip = 79;
                    weight = 1469;
                    break;
                case 346:
                    DoLog("Chrysler 300 SRT-8 2005 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.9;
                    maxspeed = 165;
                    grip = 78;
                    weight = 1888;
                    break;
                case 347:
                    DoLog("Chrysler Aspen Hybrid 2009 b21");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.1;
                    maxspeed = 112;
                    grip = 74;
                    weight = 2519;
                    break;
                case 348:
                    DoLog("Chrysler Crossfire Roadster 2004 c15");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.1;
                    maxspeed = 143;
                    grip = 75;
                    weight = 1424;
                    break;
                case 349:
                    DoLog("Chrysler 200 2017 c16");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 5.7;
                    maxspeed = 121;
                    grip = 70;
                    weight = 1608;
                    break;
                case 350:
                    DoLog("Chrysler 300 2018 c17");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.3;
                    maxspeed = 131;
                    grip = 71;
                    weight = 1820;
                    break;
                case 351:
                    DoLog("Chrysler Crossfire Coupe 2004 c16");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 7;
                    maxspeed = 146;
                    grip = 76;
                    weight = 1388;
                    break;
                case 352:
                    DoLog("Chrysler Prowler 2001 d12");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.8;
                    maxspeed = 151;
                    grip = 70;
                    weight = 1287;
                    break;
                case 353:
                    DoLog("Chrysler 300 Touring 2005 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.5;
                    maxspeed = 130;
                    grip = 72;
                    weight = 1710;
                    break;
                case 354:
                    DoLog("Chrysler LeBaron GTS Turbo 1985 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.1;
                    maxspeed = 125;
                    grip = 73;
                    weight = 1215;
                    break;
                case 355:
                    DoLog("Chrysler Sebring 2001 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11;
                    maxspeed = 135;
                    grip = 70;
                    weight = 1421;
                    break;
                case 356:
                    DoLog("Chrysler Sebring 1995 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.3;
                    maxspeed = 132;
                    grip = 68;
                    weight = 1310;
                    break;
                case 357:
                    DoLog("Chrysler Town and Country 2008 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.8;
                    maxspeed = 116;
                    grip = 68;
                    weight = 2115;
                    break;
                case 358:
                    DoLog("Chrysler Newport 1968 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.9;
                    maxspeed = 131;
                    grip = 60;
                    weight = 1905;
                    break;
                case 359:
                    DoLog("Chrysler Pacifica 2018 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.3;
                    maxspeed = 108;
                    grip = 65;
                    weight = 1964;
                    break;
                case 360:
                    DoLog("Chrysler PT Cruiser 2004 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.9;
                    maxspeed = 115;
                    grip = 68;
                    weight = 1418;
                    break;
                case 361:
                    DoLog("Chrysler Sebring 2007 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10;
                    maxspeed = 140;
                    grip = 71;
                    weight = 1491;
                    break;
                case 362:
                    DoLog("Chrysler 300H 1962 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.2;
                    maxspeed = 103;
                    grip = 51;
                    weight = 1915;
                    break;
                case 363:
                    DoLog("Chrysler Sebring Convertible 1996 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.1;
                    maxspeed = 122;
                    grip = 67;
                    weight = 1569;
                    break;
                case 364:
                    DoLog("Chrysler LHS 1994 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.5;
                    maxspeed = 135;
                    grip = 67;
                    weight = 1628;
                    break;
                case 365:
                    DoLog("Chrysler 300M Special Edition 2002 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.9;
                    maxspeed = 138;
                    grip = 74;
                    weight = 1683;
                    break;
                case 366:
                    DoLog("Chrysler Laser XT 1984 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.2;
                    maxspeed = 115;
                    grip = 78;
                    weight = 1246;
                    break;
                case 367:
                    DoLog("Chrysler Town and Country 2001 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.2;
                    maxspeed = 112;
                    grip = 65;
                    weight = 1769;
                    break;
                case 368:
                    DoLog("Chrysler Imperial 1990 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.9;
                    maxspeed = 103;
                    grip = 63;
                    weight = 1596;
                    break;
                case 369:
                    DoLog("Chrysler Town and Country 1990 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.5;
                    maxspeed = 103;
                    grip = 60;
                    weight = 1685;
                    break;
                case 370:
                    DoLog("Chrysler Town and Country 1996 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.8;
                    maxspeed = 108;
                    grip = 61;
                    weight = 1884;
                    break;
                case 371:
                    DoLog("Chrysler Town and Country 1991 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.5;
                    maxspeed = 105;
                    grip = 60;
                    weight = 1690;
                    break;
                case 372:
                    DoLog("Chrysler Turbine Car 1963 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 12;
                    maxspeed = 112;
                    grip = 61;
                    weight = 1793;
                    break;
                case 373:
                    DoLog("Chrysler Drifter 1977 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.8;
                    maxspeed = 114;
                    grip = 55;
                    weight = 1475;
                    break;
                case 374:
                    DoLog("Chrysler TC by Maserati 1990 f6");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 10.7;
                    maxspeed = 121;
                    grip = 73;
                    weight = 1486;
                    break;
                case 375:
                    DoLog("Chrysler ME Four-Twelve 2004 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.9;
                    maxspeed = 248;
                    grip = 88;
                    weight = 1310;
                    break;
                case 376:
                    DoLog("Citroen CXperience 2016 a24");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 5.5;
                    maxspeed = 145;
                    grip = 72;
                    weight = 1500;
                    break;
                case 377:
                    DoLog("Citroen BX 4TC Group B 1986 a26");
                    clearance = 2;
                    tires = 5;
                    drive = 4;
                    acceleration = 4.5;
                    maxspeed = 145;
                    grip = 84;
                    weight = 1150;
                    break;
                case 378:
                    DoLog("Citroen Metropolis 2010 b22");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 5.6;
                    maxspeed = 155;
                    grip = 72;
                    weight = 2100;
                    break;
                case 379:
                    DoLog("Citroen BX 4TC 1982 c18");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 7.5;
                    maxspeed = 138;
                    grip = 85;
                    weight = 1280;
                    break;
                case 380:
                    DoLog("Citroen C-Crosser 2.2 L HDi 2007 c17");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 9.6;
                    maxspeed = 124;
                    grip = 70;
                    weight = 1747;
                    break;
                case 381:
                    DoLog("Citroen C2-R2 Max 2008 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6;
                    maxspeed = 110;
                    grip = 85;
                    weight = 1030;
                    break;
                case 382:
                    DoLog("Citroen C2 VTS 2003 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.9;
                    maxspeed = 126;
                    grip = 78;
                    weight = 1083;
                    break;
                case 383:
                    DoLog("Citroen C4 2.0 16v VTS 2004 d13");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8;
                    maxspeed = 141;
                    grip = 79;
                    weight = 1337;
                    break;
                case 384:
                    DoLog("Citroen BX 16v 1982 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.4;
                    maxspeed = 135;
                    grip = 77;
                    weight = 1073;
                    break;
                case 385:
                    DoLog("Citroen C5 Tourer 3.0 L 2016 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.2;
                    maxspeed = 136;
                    grip = 77;
                    weight = 1655;
                    break;
                case 386:
                    DoLog("Citroen C4 Picasso THP 165 2016 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.2;
                    maxspeed = 131;
                    grip = 75;
                    weight = 1310;
                    break;
                case 387:
                    DoLog("Citroen C6 3.0 L V6 HDi 2005 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.1;
                    maxspeed = 149;
                    grip = 72;
                    weight = 1948;
                    break;
                case 388:
                    DoLog("Citroen Grand C4 Picasso 2015 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.3;
                    maxspeed = 127;
                    grip = 76;
                    weight = 1430;
                    break;
                case 389:
                    DoLog("Citroen Saxo VTS 16V 1996 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.7;
                    maxspeed = 127;
                    grip = 79;
                    weight = 935;
                    break;
                case 390:
                    DoLog("Citroen Xsara VTS 1997 d11");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.7;
                    maxspeed = 137;
                    grip = 76;
                    weight = 1190;
                    break;
                case 391:
                    DoLog("Citroen XM V6 24V 1989 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.4;
                    maxspeed = 145;
                    grip = 70;
                    weight = 1550;
                    break;
                case 392:
                    DoLog("Citroen C5 V6 2003 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.4;
                    maxspeed = 149;
                    grip = 68;
                    weight = 1480;
                    break;
                case 393:
                    DoLog("Citroen Xantia Activia V6 1997 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.6;
                    maxspeed = 143;
                    grip = 70;
                    weight = 1468;
                    break;
                case 394:
                    DoLog("Citroen CX GTi Turbo 1974 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.8;
                    maxspeed = 139;
                    grip = 66;
                    weight = 1370;
                    break;
                case 395:
                    DoLog("Citroen Xantia VSX 1993 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9;
                    maxspeed = 132;
                    grip = 71;
                    weight = 1350;
                    break;
                case 396:
                    DoLog("Citroen SM 2.7 Injection 1970 e9");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.3;
                    maxspeed = 142;
                    grip = 65;
                    weight = 1500;
                    break;
                case 397:
                    DoLog("Citroen AX GTi 1993 e8");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.7;
                    maxspeed = 118;
                    grip = 70;
                    weight = 795;
                    break;
                case 398:
                    DoLog("Citroen C3 PureTech 110 2016 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.8;
                    maxspeed = 118;
                    grip = 69;
                    weight = 1070;
                    break;
                case 399:
                    DoLog("Citroen C5 Saloon 1.6 L 2004 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.2;
                    maxspeed = 114;
                    grip = 75;
                    weight = 1424;
                    break;
                case 400:
                    DoLog("Citroen C1 VTi 68 2015 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.3;
                    maxspeed = 96;
                    grip = 74;
                    weight = 840;
                    break;
                case 401:
                    DoLog("Citroen C4 Cactus 2.0 HDi 16v 2014 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.1;
                    maxspeed = 114;
                    grip = 71;
                    weight = 1070;
                    break;
                case 402:
                    DoLog("Citroen Visa GTi 1978 e7");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 9.1;
                    maxspeed = 109;
                    grip = 69;
                    weight = 890;
                    break;
                case 403:
                    DoLog("Citroen C3 Picasso 2016 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.6;
                    maxspeed = 111;
                    grip = 70;
                    weight = 1240;
                    break;
                case 404:
                    DoLog("Citroen C3 Aircross 2018 e8");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.6;
                    maxspeed = 124;
                    grip = 68;
                    weight = 1387;
                    break;
                case 405:
                    DoLog("Citroen C3-XR 2014 e8");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.8;
                    maxspeed = 115;
                    grip = 67;
                    weight = 1350;
                    break;
                case 406:
                    DoLog("Citroen C5 HPi 2001 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.3;
                    maxspeed = 130;
                    grip = 67;
                    weight = 1595;
                    break;
                case 407:
                    DoLog("Citroen C5 Aircross 2018 e10");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.6;
                    maxspeed = 131;
                    grip = 69;
                    weight = 1530;
                    break;
                case 408:
                    DoLog("Citroen C5 Crosstourer 2014 e10");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.4;
                    maxspeed = 131;
                    grip = 70;
                    weight = 1650;
                    break;
                case 409:
                    DoLog("Citroen BX 17 D Turbo Break 1982 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.5;
                    maxspeed = 108;
                    grip = 69;
                    weight = 1062;
                    break;
                case 410:
                    DoLog("Citroen Mehari 4x4 1980 f4");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 26.7;
                    maxspeed = 75;
                    grip = 49;
                    weight = 630;
                    break;
                case 411:
                    DoLog("Citroen 2CV 6 1979 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 31.4;
                    maxspeed = 65;
                    grip = 45;
                    weight = 595;
                    break;
                case 412:
                    DoLog("Citroen Ami Super 1973 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 17.1;
                    maxspeed = 88;
                    grip = 55;
                    weight = 815;
                    break;
                case 413:
                    DoLog("Citroen Axel 12 TRS 1984 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.4;
                    maxspeed = 98;
                    grip = 60;
                    weight = 875;
                    break;
                case 414:
                    DoLog("Citroen C-Zero 2016 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 15.4;
                    maxspeed = 80;
                    grip = 58;
                    weight = 1120;
                    break;
                case 415:
                    DoLog("Citroen GSA 1970 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.9;
                    maxspeed = 100;
                    grip = 61;
                    weight = 920;
                    break;
                case 416:
                    DoLog("Citroen Xsara Picasso 1997 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 16.5;
                    maxspeed = 106;
                    grip = 65;
                    weight = 1240;
                    break;
                case 417:
                    DoLog("Citroen ZX Volcane TD 1991 f6");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 10.6;
                    maxspeed = 111;
                    grip = 75;
                    weight = 1102;
                    break;
                case 418:
                    DoLog("Citroen GZ 1973 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.3;
                    maxspeed = 109;
                    grip = 66;
                    weight = 1140;
                    break;
                case 419:
                    DoLog("Citroen M35 1969 f3");
                    clearance = 1;
                    tires = 3;
                    drive = 1;
                    acceleration = 19;
                    maxspeed = 90;
                    grip = 62;
                    weight = 725;
                    break;
                case 420:
                    DoLog("Citroen Traction Avant 1934 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 25;
                    maxspeed = 65;
                    grip = 57;
                    weight = 1400;
                    break;
                case 421:
                    DoLog("Citroen GT 2008 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 200;
                    grip = 89;
                    weight = 1400;
                    break;
                case 422:
                    DoLog("Dodge Challenger SRT Hellcat 2015 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.7;
                    maxspeed = 200;
                    grip = 83;
                    weight = 1892;
                    break;
                case 423:
                    DoLog("Dodge Challenger SRT Hellcat Widebody 2018 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.7;
                    maxspeed = 200;
                    grip = 85;
                    weight = 1892;
                    break;
                case 424:
                    DoLog("Dodge Charger R/T Scat Pack 2015 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.1;
                    maxspeed = 175;
                    grip = 83;
                    weight = 1971;
                    break;
                case 425:
                    DoLog("Dodge Charger SRT Hellcat 2015 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.4;
                    maxspeed = 204;
                    grip = 81;
                    weight = 2083;
                    break;
                case 426:
                    DoLog("Dodge SRT-4 2004 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.3;
                    maxspeed = 153;
                    grip = 78;
                    weight = 1347;
                    break;
                case 427:
                    DoLog("Dodge Charger Daytona 2017 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.6;
                    maxspeed = 155;
                    grip = 84;
                    weight = 1937;
                    break;
                case 428:
                    DoLog("Dodge Charger SRT-8 2006 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.7;
                    maxspeed = 160;
                    grip = 80;
                    weight = 1887;
                    break;
                case 429:
                    DoLog("Dodge Magnum SRT-8 2006 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.1;
                    maxspeed = 161;
                    grip = 82;
                    weight = 1932;
                    break;
                case 430:
                    DoLog("Dodge Viper RT/10 1992 b20");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.6;
                    maxspeed = 165;
                    grip = 80;
                    weight = 1588;
                    break;
                case 431:
                    DoLog("Dodge Challenger GT AWD 2018 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 6.5;
                    maxspeed = 130;
                    grip = 84;
                    weight = 1863;
                    break;
                case 432:
                    DoLog("Dodge Caliber SRT4 2008 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.9;
                    maxspeed = 155;
                    grip = 84;
                    weight = 1466;
                    break;
                case 433:
                    DoLog("Dodge Nitro R/T 2007 b20");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.9;
                    maxspeed = 114;
                    grip = 69;
                    weight = 1879;
                    break;
                case 434:
                    DoLog("Dodge Stealth R/T Twin Turbo 1990 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.9;
                    maxspeed = 160;
                    grip = 80;
                    weight = 1722;
                    break;
                case 435:
                    DoLog("Dodge Durango GT 2018 c17");
                    clearance = 3;
                    tires = 4;
                    drive = 2;
                    acceleration = 7.8;
                    maxspeed = 125;
                    grip = 75;
                    weight = 2123;
                    break;
                case 436:
                    DoLog("Dodge Caliber R/T AWD 2007 c15");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 8.9;
                    maxspeed = 120;
                    grip = 74;
                    weight = 1501;
                    break;
                case 437:
                    DoLog("Dodge Spirit R/T 1991 c16");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.8;
                    maxspeed = 142;
                    grip = 78;
                    weight = 1388;
                    break;
                case 438:
                    DoLog("Dodge Daytona IROC R/T 1992 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.6;
                    maxspeed = 148;
                    grip = 82;
                    weight = 1334;
                    break;
                case 439:
                    DoLog("Dodge Stealth 1995 d13");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.7;
                    maxspeed = 139;
                    grip = 78;
                    weight = 1435;
                    break;
                case 440:
                    DoLog("Dodge Challenger T/A 1970 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6;
                    maxspeed = 146;
                    grip = 68;
                    weight = 1794;
                    break;
                case 441:
                    DoLog("Dodge Grand Caravan 2018 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 6.7;
                    maxspeed = 127;
                    grip = 72;
                    weight = 2046;
                    break;
                case 442:
                    DoLog("Dodge Dart 2017 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.4;
                    maxspeed = 129;
                    grip = 76;
                    weight = 1436;
                    break;
                case 443:
                    DoLog("Dodge Coronet Super Bee 1968 d11");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.8;
                    maxspeed = 137;
                    grip = 62;
                    weight = 1612;
                    break;
                case 444:
                    DoLog("Dodge Neon R/T Coupe 1998 d11");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.6;
                    maxspeed = 133;
                    grip = 75;
                    weight = 1119;
                    break;
                case 445:
                    DoLog("Dodge Journey 2018 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.2;
                    maxspeed = 125;
                    grip = 72;
                    weight = 1732;
                    break;
                case 446:
                    DoLog("Dodge Intrepid 1993 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.9;
                    maxspeed = 128;
                    grip = 72;
                    weight = 1453;
                    break;
                case 447:
                    DoLog("Dodge Caravan Turbo 1989 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9;
                    maxspeed = 113;
                    grip = 67;
                    weight = 1400;
                    break;
                case 448:
                    DoLog("Dodge Avenger 1995 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.3;
                    maxspeed = 133;
                    grip = 69;
                    weight = 1417;
                    break;
                case 449:
                    DoLog("Dodge Dakota R/T 1998 e10");
                    clearance = 3;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.1;
                    maxspeed = 117;
                    grip = 70;
                    weight = 1746;
                    break;
                case 450:
                    DoLog("Dodge Monaco 1974 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 11.1;
                    maxspeed = 120;
                    grip = 55;
                    weight = 2069;
                    break;
                case 451:
                    DoLog("Dodge Challenger SRT Demon 2017 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.3;
                    maxspeed = 203;
                    grip = 82;
                    weight = 1941;
                    break;
                case 452:
                    DoLog("Dodge SRT Viper 2013 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.4;
                    maxspeed = 206;
                    grip = 89;
                    weight = 1521;
                    break;
                case 453:
                    DoLog("Dodge Viper ACR 2016 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.4;
                    maxspeed = 177;
                    grip = 92;
                    weight = 1539;
                    break;
                case 454:
                    DoLog("Dodge Viper GTS-R 1996 s28");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 3.2;
                    maxspeed = 200;
                    grip = 95;
                    weight = 1250;
                    break;
                case 455:
                    DoLog("DS DS Numero 9 2012 a25");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 4.5;
                    maxspeed = 152;
                    grip = 78;
                    weight = 1500;
                    break;
                case 456:
                    DoLog("DS Survolt 2010 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.7;
                    maxspeed = 162;
                    grip = 89;
                    weight = 1400;
                    break;
                case 457:
                    DoLog("DS 3 Perfomance 2016 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.3;
                    maxspeed = 143;
                    grip = 85;
                    weight = 1175;
                    break;
                case 458:
                    DoLog("DS DS 7 Crossback E-Tense 4x4 PHEV 2018 b19");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 6.4;
                    maxspeed = 136;
                    grip = 68;
                    weight = 1725;
                    break;
                case 459:
                    DoLog("DS DS3 Racing 2011 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.2;
                    maxspeed = 146;
                    grip = 82;
                    weight = 1240;
                    break;
                case 460:
                    DoLog("DS Wild Rubis 2013 c18");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 7.2;
                    maxspeed = 145;
                    grip = 69;
                    weight = 1800;
                    break;
                case 461:
                    DoLog("DS 3 DSport HDi 2016 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9;
                    maxspeed = 118;
                    grip = 79;
                    weight = 1150;
                    break;
                case 462:
                    DoLog("DS 3 Convertible 2016 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.5;
                    maxspeed = 118;
                    grip = 79;
                    weight = 1090;
                    break;
                case 463:
                    DoLog("DS DS 6 2015 d12");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.1;
                    maxspeed = 140;
                    grip = 68;
                    weight = 1550;
                    break;
                case 464:
                    DoLog("DS DS 7 Crossback 2018 d14");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 6.6;
                    maxspeed = 141;
                    grip = 69;
                    weight = 1425;
                    break;
                case 465:
                    DoLog("DS 4 2011 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.8;
                    maxspeed = 118;
                    grip = 79;
                    weight = 1365;
                    break;
                case 466:
                    DoLog("DS 5 2012 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.8;
                    maxspeed = 119;
                    grip = 80;
                    weight = 1495;
                    break;
                case 467:
                    DoLog("DS DS Convertible 1958 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 19.1;
                    maxspeed = 103;
                    grip = 63;
                    weight = 1275;
                    break;
                case 468:
                    DoLog("Fiat Abarth 695 Biposto 2017 c18");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.6;
                    maxspeed = 143;
                    grip = 80;
                    weight = 997;
                    break;
                case 469:
                    DoLog("Fiat Abarth 124 Spider 2017 c16");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.5;
                    maxspeed = 144;
                    grip = 83;
                    weight = 1060;
                    break;
                case 470:
                    DoLog("Fiat Coupe 20v Turbo 1993 c17");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1310;
                    break;
                case 471:
                    DoLog("Fiat Abarth 131 Rally 1976 c18");
                    clearance = 2;
                    tires = 5;
                    drive = 2;
                    acceleration = 7.8;
                    maxspeed = 118;
                    grip = 78;
                    weight = 980;
                    break;
                case 472:
                    DoLog("Fiat 124 Sport Spider 1966 d13");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.5;
                    maxspeed = 118;
                    grip = 75;
                    weight = 939;
                    break;
                case 473:
                    DoLog("Fiat 124 Spider 2017 d14");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.3;
                    maxspeed = 133;
                    grip = 80;
                    weight = 1105;
                    break;
                case 474:
                    DoLog("Fiat Panda 100hp 2006 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9;
                    maxspeed = 115;
                    grip = 78;
                    weight = 975;
                    break;
                case 475:
                    DoLog("Fiat Punto 1.4 GT 1993 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.2;
                    maxspeed = 123;
                    grip = 78;
                    weight = 982;
                    break;
                case 476:
                    DoLog("Fiat Strada Abarth 130TC 1982 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.9;
                    maxspeed = 122;
                    grip = 77;
                    weight = 950;
                    break;
                case 477:
                    DoLog("Fiat Punto HGT 1999 d11");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.6;
                    maxspeed = 127;
                    grip = 79;
                    weight = 1040;
                    break;
                case 478:
                    DoLog("Fiat Dino Coupe 1966 d11");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 8;
                    maxspeed = 130;
                    grip = 70;
                    weight = 1220;
                    break;
                case 479:
                    DoLog("Fiat Dino Spider 1966 e10");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 8;
                    maxspeed = 130;
                    grip = 67;
                    weight = 1180;
                    break;
                case 480:
                    DoLog("Fiat 500X 2017 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.3;
                    maxspeed = 118;
                    grip = 72;
                    weight = 1320;
                    break;
                case 481:
                    DoLog("Fiat Panda 2017 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.7;
                    maxspeed = 111;
                    grip = 74;
                    weight = 975;
                    break;
                case 482:
                    DoLog("Fiat X1/9 1972 e7");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 11.8;
                    maxspeed = 105;
                    grip = 73;
                    weight = 880;
                    break;
                case 483:
                    DoLog("Fiat 500 2017 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.4;
                    maxspeed = 107;
                    grip = 72;
                    weight = 1005;
                    break;
                case 484:
                    DoLog("Fiat Tipo 2017 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.1;
                    maxspeed = 112;
                    grip = 74;
                    weight = 1365;
                    break;
                case 485:
                    DoLog("Fiat Barchetta 1995 e10");
                    clearance = 1;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.7;
                    maxspeed = 118;
                    grip = 77;
                    weight = 1056;
                    break;
                case 486:
                    DoLog("Fiat Uno Turbo 1985 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.3;
                    maxspeed = 122;
                    grip = 74;
                    weight = 845;
                    break;
                case 487:
                    DoLog("Fiat Bravo 2007 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.9;
                    maxspeed = 111;
                    grip = 74;
                    weight = 1205;
                    break;
                case 488:
                    DoLog("Fiat Cinquecento Sporting 1994 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.5;
                    maxspeed = 93;
                    grip = 72;
                    weight = 727;
                    break;
                case 489:
                    DoLog("Fiat Punto 2017 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.1;
                    maxspeed = 107;
                    grip = 73;
                    weight = 1075;
                    break;
                case 490:
                    DoLog("Fiat Qubo 2009 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.2;
                    maxspeed = 100;
                    grip = 73;
                    weight = 1350;
                    break;
                case 491:
                    DoLog("Fiat Punto Cabrio 1993 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.6;
                    maxspeed = 105;
                    grip = 69;
                    weight = 1070;
                    break;
                case 492:
                    DoLog("Fiat 500L 2012 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 14.1;
                    maxspeed = 103;
                    grip = 73;
                    weight = 1315;
                    break;
                case 493:
                    DoLog("Fiat Multipla 1998 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12;
                    maxspeed = 106;
                    grip = 68;
                    weight = 1300;
                    break;
                case 494:
                    DoLog("Fiat Panda 1980 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 21.3;
                    maxspeed = 78;
                    grip = 65;
                    weight = 715;
                    break;
                case 495:
                    DoLog("Fiat 500 1957 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 99;
                    maxspeed = 59;
                    grip = 50;
                    weight = 470;
                    break;
                case 496:
                    DoLog("Fiat Panda 4x4 1983 f6");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 16.8;
                    maxspeed = 83;
                    grip = 66;
                    weight = 761;
                    break;
                case 497:
                    DoLog("Ford Mustang BOSS 302 2012 a25");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4;
                    maxspeed = 161;
                    grip = 84;
                    weight = 1647;
                    break;
                case 498:
                    DoLog("Ford F-150 SVT Raptor 2014 a24");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 6.3;
                    maxspeed = 100;
                    grip = 73;
                    weight = 2631;
                    break;
                case 499:
                    DoLog("Ford Mustang GT Power Pack 2016 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.4;
                    maxspeed = 155;
                    grip = 84;
                    weight = 1720;
                    break;
                case 500:
                    DoLog("Ford GT40 1965 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.2;
                    maxspeed = 185;
                    grip = 80;
                    weight = 864;
                    break;
                case 501:
                    DoLog("Ford Mustang GT 2016 a23");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.8;
                    maxspeed = 155;
                    grip = 82;
                    weight = 1691;
                    break;
                case 502:
                    DoLog("Ford Focus ST 2012 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.2;
                    maxspeed = 154;
                    grip = 84;
                    weight = 1317;
                    break;
                case 503:
                    DoLog("Ford RS200 1984 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.8;
                    maxspeed = 142;
                    grip = 81;
                    weight = 1180;
                    break;
                case 504:
                    DoLog("Ford Focus RS500 2010 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.3;
                    maxspeed = 165;
                    grip = 85;
                    weight = 1468;
                    break;
                case 505:
                    DoLog("Ford Focus RS 2009 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.6;
                    maxspeed = 163;
                    grip = 85;
                    weight = 1468;
                    break;
                case 506:
                    DoLog("Ford Sierra RS Cosworth 4x4 1990 b21");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.6;
                    maxspeed = 143;
                    grip = 81;
                    weight = 1302;
                    break;
                case 507:
                    DoLog("Ford Escort Rally Spec 1979 b22");
                    clearance = 2;
                    tires = 5;
                    drive = 2;
                    acceleration = 4.9;
                    maxspeed = 120;
                    grip = 82;
                    weight = 810;
                    break;
                case 508:
                    DoLog("Ford Focus ST Mountune 2012 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.7;
                    maxspeed = 154;
                    grip = 85;
                    weight = 1386;
                    break;
                case 509:
                    DoLog("Ford Mustang 2005 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5;
                    maxspeed = 150;
                    grip = 79;
                    weight = 1580;
                    break;
                case 510:
                    DoLog("Ford Mustang 2.3 2016 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.5;
                    maxspeed = 145;
                    grip = 83;
                    weight = 1653;
                    break;
                case 511:
                    DoLog("Ford Sierra RS500 1987 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.1;
                    maxspeed = 154;
                    grip = 83;
                    weight = 1207;
                    break;
                case 512:
                    DoLog("Ford Taurus SHO 2017 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.5;
                    maxspeed = 134;
                    grip = 76;
                    weight = 1970;
                    break;
                case 513:
                    DoLog("Ford Escort RS Cosworth 1992 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 6.2;
                    maxspeed = 137;
                    grip = 83;
                    weight = 1275;
                    break;
                case 514:
                    DoLog("Ford Edge 2016 c18");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.8;
                    maxspeed = 129;
                    grip = 68;
                    weight = 1874;
                    break;
                case 515:
                    DoLog("Ford Focus RS 2002 c18");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.3;
                    maxspeed = 144;
                    grip = 84;
                    weight = 1278;
                    break;
                case 516:
                    DoLog("Ford Focus ST Superchips 2005 c18");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.2;
                    maxspeed = 155;
                    grip = 83;
                    weight = 1317;
                    break;
                case 517:
                    DoLog("Ford Mustang 2005 c18");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.8;
                    maxspeed = 145;
                    grip = 78;
                    weight = 1639;
                    break;
                case 518:
                    DoLog("Ford Ranger Wildtrak 2012 c18");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 9.2;
                    maxspeed = 108;
                    grip = 73;
                    weight = 2148;
                    break;
                case 519:
                    DoLog("Ford Sierra RS Cosworth 1986 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.2;
                    maxspeed = 143;
                    grip = 78;
                    weight = 1220;
                    break;
                case 520:
                    DoLog("Ford Fiesta ST 2016 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.6;
                    maxspeed = 137;
                    grip = 80;
                    weight = 1163;
                    break;
                case 521:
                    DoLog("Ford Galaxy 2015 c17");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 8.5;
                    maxspeed = 133;
                    grip = 74;
                    weight = 1779;
                    break;
                case 522:
                    DoLog("Ford Thunderbird 3.9l V8 2002 c18");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7;
                    maxspeed = 145;
                    grip = 75;
                    weight = 1699;
                    break;
                case 523:
                    DoLog("Ford Mondeo ST220 2000 c15");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.1;
                    maxspeed = 151;
                    grip = 75;
                    weight = 1506;
                    break;
                case 524:
                    DoLog("Ford Scorpio 24-valve 1991 c16");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 8.4;
                    maxspeed = 137;
                    grip = 69;
                    weight = 1422;
                    break;
                case 525:
                    DoLog("Ford Ranger 2016 c15");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 11.2;
                    maxspeed = 108;
                    grip = 73;
                    weight = 2006;
                    break;
                case 526:
                    DoLog("Ford Mondeo 2013 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.3;
                    maxspeed = 139;
                    grip = 79;
                    weight = 1613;
                    break;
                case 527:
                    DoLog("Ford Focus ST170 2002 d14");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.9;
                    maxspeed = 134;
                    grip = 82;
                    weight = 1208;
                    break;
                case 528:
                    DoLog("Ford Mondeo ST200 1998 d14");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.5;
                    maxspeed = 141;
                    grip = 80;
                    weight = 1337;
                    break;
                case 529:
                    DoLog("Ford Focus ST TDCi Estate 2016 d14");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.7;
                    maxspeed = 135;
                    grip = 79;
                    weight = 1464;
                    break;
                case 530:
                    DoLog("Ford Kuga 2016 d14");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 11.9;
                    maxspeed = 112;
                    grip = 70;
                    weight = 1504;
                    break;
                case 531:
                    DoLog("Ford Mondeo 2017 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.3;
                    maxspeed = 135;
                    grip = 80;
                    weight = 1609;
                    break;
                case 532:
                    DoLog("Ford Ranger 2012 d14");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 11.9;
                    maxspeed = 108;
                    grip = 73;
                    weight = 2123;
                    break;
                case 533:
                    DoLog("Ford Racing Puma 2000 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.9;
                    maxspeed = 126;
                    grip = 80;
                    weight = 1174;
                    break;
                case 534:
                    DoLog("Ford Escort Rally Spec 1970 d14");
                    clearance = 2;
                    tires = 5;
                    drive = 2;
                    acceleration = 8.9;
                    maxspeed = 113;
                    grip = 73;
                    weight = 785;
                    break;
                case 535:
                    DoLog("Ford Escort RS2000 1974 d14");
                    clearance = 2;
                    tires = 5;
                    drive = 2;
                    acceleration = 9;
                    maxspeed = 110;
                    grip = 72;
                    weight = 914;
                    break;
                case 536:
                    DoLog("Ford Focus 2006 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.9;
                    maxspeed = 126;
                    grip = 79;
                    weight = 1378;
                    break;
                case 537:
                    DoLog("Ford Escort RS2000 1996 d11");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.9;
                    maxspeed = 130;
                    grip = 76;
                    weight = 1165;
                    break;
                case 538:
                    DoLog("Ford Puma 1.7 1997 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.6;
                    maxspeed = 123;
                    grip = 73;
                    weight = 1039;
                    break;
                case 539:
                    DoLog("Ford Ecosport 2016 e7");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.1;
                    maxspeed = 112;
                    grip = 68;
                    weight = 1350;
                    break;
                case 540:
                    DoLog("Ford Focus 2015 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.3;
                    maxspeed = 120;
                    grip = 79;
                    weight = 1316;
                    break;
                case 541:
                    DoLog("Ford Focus Bioenthanol 2006 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.8;
                    maxspeed = 123;
                    grip = 77;
                    weight = 1333;
                    break;
                case 542:
                    DoLog("Ford Mondeo 2004 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.7;
                    maxspeed = 124;
                    grip = 78;
                    weight = 1356;
                    break;
                case 543:
                    DoLog("Ford Ranger 2006 e8");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 17;
                    maxspeed = 98;
                    grip = 71;
                    weight = 1845;
                    break;
                case 544:
                    DoLog("Ford Ranger 2016 e8");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 11.2;
                    maxspeed = 109;
                    grip = 60;
                    weight = 2177;
                    break;
                case 545:
                    DoLog("Ford Mustang 289 1966 e9");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 8.1;
                    maxspeed = 124;
                    grip = 71;
                    weight = 1390;
                    break;
                case 546:
                    DoLog("Ford Mondeo 2.0tdci 2016 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.9;
                    maxspeed = 134;
                    grip = 71;
                    weight = 1578;
                    break;
                case 547:
                    DoLog("Ford Mondeo Hybrid 2016 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.7;
                    maxspeed = 116;
                    grip = 71;
                    weight = 1504;
                    break;
                case 548:
                    DoLog("Ford Sierra XR4i 1983 e9");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 8;
                    maxspeed = 130;
                    grip = 67;
                    weight = 1205;
                    break;
                case 549:
                    DoLog("Ford Capri 3.0 S 1978 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.6;
                    maxspeed = 123;
                    grip = 65;
                    weight = 1116;
                    break;
                case 550:
                    DoLog("Ford Fiesta 2007 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.3;
                    maxspeed = 109;
                    grip = 75;
                    weight = 1143;
                    break;
                case 551:
                    DoLog("Ford S-Max 2016 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9;
                    maxspeed = 131;
                    grip = 69;
                    weight = 1743;
                    break;
                case 552:
                    DoLog("Ford Fiesta XR2 1988 e7");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 9.4;
                    maxspeed = 111;
                    grip = 72;
                    weight = 860;
                    break;
                case 553:
                    DoLog("Ford Granada 2.8i S 1977 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.1;
                    maxspeed = 116;
                    grip = 64;
                    weight = 1417;
                    break;
                case 554:
                    DoLog("Ford Escort Mexico 1972 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.5;
                    maxspeed = 100;
                    grip = 69;
                    weight = 851;
                    break;
                case 555:
                    DoLog("Ford Escort RS1600 1968 e7");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 8.5;
                    maxspeed = 119;
                    grip = 65;
                    weight = 940;
                    break;
                case 556:
                    DoLog("Ford Focus 2004 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11;
                    maxspeed = 115;
                    grip = 73;
                    weight = 1091;
                    break;
                case 557:
                    DoLog("Ford Focus 1.0 2016 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.5;
                    maxspeed = 121;
                    grip = 70;
                    weight = 1306;
                    break;
                case 558:
                    DoLog("Ford Escort RS Turbo 1984 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.8;
                    maxspeed = 122;
                    grip = 71;
                    weight = 1080;
                    break;
                case 559:
                    DoLog("Ford Fiesta 1997 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.4;
                    maxspeed = 104;
                    grip = 74;
                    weight = 912;
                    break;
                case 560:
                    DoLog("Ford Fiesta 1.0 2016 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.7;
                    maxspeed = 112;
                    grip = 69;
                    weight = 1091;
                    break;
                case 561:
                    DoLog("Ford Fiesta XR2 1981 f5");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 9.6;
                    maxspeed = 106;
                    grip = 68;
                    weight = 800;
                    break;
                case 562:
                    DoLog("Ford Focus Coupe-Cabriolet 2007 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.9;
                    maxspeed = 113;
                    grip = 77;
                    weight = 1398;
                    break;
                case 563:
                    DoLog("Ford Fiesta 1993 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.7;
                    maxspeed = 109;
                    grip = 72;
                    weight = 963;
                    break;
                case 564:
                    DoLog("Ford C-Max 2015 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.3;
                    maxspeed = 108;
                    grip = 71;
                    weight = 1391;
                    break;
                case 565:
                    DoLog("Ford Escort XR3i 1982 f5");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 10.2;
                    maxspeed = 114;
                    grip = 69;
                    weight = 980;
                    break;
                case 566:
                    DoLog("Ford Fiesta 1983 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.2;
                    maxspeed = 100;
                    grip = 69;
                    weight = 775;
                    break;
                case 567:
                    DoLog("Ford Ka 2011 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.6;
                    maxspeed = 105;
                    grip = 70;
                    weight = 1055;
                    break;
                case 568:
                    DoLog("Ford B-Max 2012 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.5;
                    maxspeed = 109;
                    grip = 70;
                    weight = 1279;
                    break;
                case 569:
                    DoLog("Ford Transit 2.2 TDCi 2013 f5");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.8;
                    maxspeed = 100;
                    grip = 59;
                    weight = 1800;
                    break;
                case 570:
                    DoLog("Ford Cortina 1974 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 16;
                    maxspeed = 92;
                    grip = 60;
                    weight = 960;
                    break;
                case 571:
                    DoLog("Ford Fiesta 1976 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 17;
                    maxspeed = 88;
                    grip = 62;
                    weight = 755;
                    break;
                case 572:
                    DoLog("Ford GT 2017 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.1;
                    maxspeed = 216;
                    grip = 93;
                    weight = 1385;
                    break;
                case 573:
                    DoLog("Ford GT90 1995 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.1;
                    maxspeed = 235;
                    grip = 87;
                    weight = 1451;
                    break;
                case 574:
                    DoLog("Ford GT 2004 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.5;
                    maxspeed = 205;
                    grip = 89;
                    weight = 1538;
                    break;
                case 575:
                    DoLog("GMC Yukon 2010 a23");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5.8;
                    maxspeed = 112;
                    grip = 75;
                    weight = 2552;
                    break;
                case 576:
                    DoLog("GMC Acadia Denali 2018 a23");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.1;
                    maxspeed = 130;
                    grip = 76;
                    weight = 1805;
                    break;
                case 577:
                    DoLog("GMC Syclone 1991 a24");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 5.3;
                    maxspeed = 126;
                    grip = 78;
                    weight = 1708;
                    break;
                case 578:
                    DoLog("GMC Typhoon 1993 a24");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 5.6;
                    maxspeed = 128;
                    grip = 78;
                    weight = 1734;
                    break;
                case 579:
                    DoLog("GMC Terrain 2010 b22");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.7;
                    maxspeed = 118;
                    grip = 76;
                    weight = 1748;
                    break;
                case 580:
                    DoLog("GMC Yukon XL 2014 b20");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.1;
                    maxspeed = 112;
                    grip = 75;
                    weight = 3876;
                    break;
                case 581:
                    DoLog("GMC Sierra All Terrain X 2017 b22");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 6.6;
                    maxspeed = 99;
                    grip = 68;
                    weight = 2580;
                    break;
                case 582:
                    DoLog("GMC Acadia 2016 c17");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 9.2;
                    maxspeed = 118;
                    grip = 71;
                    weight = 1794;
                    break;
                case 583:
                    DoLog("GMC Yukon Denali 2004 c18");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.6;
                    maxspeed = 120;
                    grip = 62;
                    weight = 2461;
                    break;
                case 584:
                    DoLog("GMC Envoy 1998 d12");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 9.4;
                    maxspeed = 109;
                    grip = 64;
                    weight = 1850;
                    break;
                case 585:
                    DoLog("GMC Denali XT 2008 d13");
                    clearance = 3;
                    tires = 2;
                    drive = 2;
                    acceleration = 6;
                    maxspeed = 125;
                    grip = 75;
                    weight = 1756;
                    break;
                case 586:
                    DoLog("GMC Granite 2010 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.4;
                    maxspeed = 125;
                    grip = 72;
                    weight = 1458;
                    break;
                case 587:
                    DoLog("GMC Caballero Diablo 1984 f3");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 9.9;
                    maxspeed = 103;
                    grip = 60;
                    weight = 1471;
                    break;
                case 588:
                    DoLog("GMC Safari 1996 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 13.1;
                    maxspeed = 106;
                    grip = 62;
                    weight = 2025;
                    break;
                case 589:
                    DoLog("Honda NSX-R 2002 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.7;
                    maxspeed = 174;
                    grip = 86;
                    weight = 1270;
                    break;
                case 590:
                    DoLog("Honda Civic Type R 2016 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.4;
                    maxspeed = 168;
                    grip = 86;
                    weight = 1382;
                    break;
                case 591:
                    DoLog("Honda Legend 3.7 SH-AWD 2004 b22");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 6.6;
                    maxspeed = 155;
                    grip = 77;
                    weight = 1850;
                    break;
                case 592:
                    DoLog("Honda Pilot 4WD 2016 b22");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.1;
                    maxspeed = 114;
                    grip = 70;
                    weight = 1914;
                    break;
                case 593:
                    DoLog("Honda NSX 1990 b20");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.7;
                    maxspeed = 168;
                    grip = 84;
                    weight = 1365;
                    break;
                case 594:
                    DoLog("Honda S2000 1999 c17");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.9;
                    maxspeed = 150;
                    grip = 80;
                    weight = 1260;
                    break;
                case 595:
                    DoLog("Honda S2000 Type S 2004 c17");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.2;
                    maxspeed = 150;
                    grip = 80;
                    weight = 1260;
                    break;
                case 596:
                    DoLog("Honda Civic Type R 2005 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.3;
                    maxspeed = 146;
                    grip = 81;
                    weight = 1301;
                    break;
                case 597:
                    DoLog("Honda Pilot 4WD 2009 c18");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 8.6;
                    maxspeed = 119;
                    grip = 69;
                    weight = 2044;
                    break;
                case 598:
                    DoLog("Honda Ridgeline 2016 c16");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 6.6;
                    maxspeed = 112;
                    grip = 65;
                    weight = 1924;
                    break;
                case 599:
                    DoLog("Honda Civic Type R 2000 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.7;
                    maxspeed = 146;
                    grip = 80;
                    weight = 1270;
                    break;
                case 600:
                    DoLog("Honda CR-V 1.6 i-DTEC 2016 c17");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 9.6;
                    maxspeed = 125;
                    grip = 70;
                    weight = 1718;
                    break;
                case 601:
                    DoLog("Honda Accord Type R 1997 c16");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.9;
                    maxspeed = 142;
                    grip = 81;
                    weight = 1405;
                    break;
                case 602:
                    DoLog("Honda Integra Type R 1995 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.6;
                    maxspeed = 145;
                    grip = 80;
                    weight = 1100;
                    break;
                case 603:
                    DoLog("Honda Pilot 4WD 2003 c16");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 9.3;
                    maxspeed = 112;
                    grip = 68;
                    weight = 2014;
                    break;
                case 604:
                    DoLog("Honda CR-V 2.0 i-VTEC 2002 c16");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 10.3;
                    maxspeed = 110;
                    grip = 70;
                    weight = 1502;
                    break;
                case 605:
                    DoLog("Honda CR-V 2.2 i-DTEC 2007 c16");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 10.7;
                    maxspeed = 113;
                    grip = 72;
                    weight = 1541;
                    break;
                case 606:
                    DoLog("Honda Accord Euro-R 2002 c15");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.9;
                    maxspeed = 144;
                    grip = 80;
                    weight = 1390;
                    break;
                case 607:
                    DoLog("Honda Civic Type R 1997 c15");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.8;
                    maxspeed = 142;
                    grip = 78;
                    weight = 1040;
                    break;
                case 608:
                    DoLog("Honda Integra Type R 2002 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.1;
                    maxspeed = 140;
                    grip = 82;
                    weight = 1170;
                    break;
                case 609:
                    DoLog("Honda Accord 3.5l V6 2016 c18");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 6.1;
                    maxspeed = 131;
                    grip = 74;
                    weight = 1607;
                    break;
                case 610:
                    DoLog("Honda HR-V 1.8 4WD 2016 d14");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 10.1;
                    maxspeed = 121;
                    grip = 73;
                    weight = 1410;
                    break;
                case 611:
                    DoLog("Honda Prelude Type S 1996 d13");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.9;
                    maxspeed = 144;
                    grip = 74;
                    weight = 1310;
                    break;
                case 612:
                    DoLog("Honda Accord Hybrid 2016 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 6.9;
                    maxspeed = 112;
                    grip = 70;
                    weight = 1580;
                    break;
                case 613:
                    DoLog("Honda Civic Si 1995 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.2;
                    maxspeed = 135;
                    grip = 75;
                    weight = 1050;
                    break;
                case 614:
                    DoLog("Honda Prelude VTEC 1991 d13");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.8;
                    maxspeed = 140;
                    grip = 74;
                    weight = 1315;
                    break;
                case 615:
                    DoLog("Honda CR-V 1997 d13");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 11.8;
                    maxspeed = 108;
                    grip = 66;
                    weight = 1452;
                    break;
                case 616:
                    DoLog("Honda CRX VTEC 1988 d11");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 8;
                    maxspeed = 130;
                    grip = 76;
                    weight = 1025;
                    break;
                case 617:
                    DoLog("Honda Odyssey 2016 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.7;
                    maxspeed = 120;
                    grip = 72;
                    weight = 2028;
                    break;
                case 618:
                    DoLog("Honda Legend 2.7 V6 1985 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.6;
                    maxspeed = 126;
                    grip = 74;
                    weight = 1418;
                    break;
                case 619:
                    DoLog("Honda Prelude 2.0Si 4WS 1987 d12");
                    clearance = 1;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.6;
                    maxspeed = 132;
                    grip = 72;
                    weight = 1145;
                    break;
                case 620:
                    DoLog("Honda Capa 4WD 1998 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 11.3;
                    maxspeed = 104;
                    grip = 68;
                    weight = 1180;
                    break;
                case 621:
                    DoLog("Honda Legend 3.5 V6 1995 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.1;
                    maxspeed = 134;
                    grip = 75;
                    weight = 1725;
                    break;
                case 622:
                    DoLog("Honda Civic 1500 1979 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.9;
                    maxspeed = 100;
                    grip = 67;
                    weight = 745;
                    break;
                case 623:
                    DoLog("Honda CR-X 1.6i-16 1983 e10");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 8;
                    maxspeed = 121;
                    grip = 75;
                    weight = 900;
                    break;
                case 624:
                    DoLog("Honda Civic 1.8 2016 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.1;
                    maxspeed = 134;
                    grip = 73;
                    weight = 1268;
                    break;
                case 625:
                    DoLog("Honda Civic Hybrid 2016 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.3;
                    maxspeed = 116;
                    grip = 74;
                    weight = 1294;
                    break;
                case 626:
                    DoLog("Honda Clarity 2016 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.9;
                    maxspeed = 100;
                    grip = 77;
                    weight = 1625;
                    break;
                case 627:
                    DoLog("Honda S-MX 4WD 1996 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 10.9;
                    maxspeed = 114;
                    grip = 66;
                    weight = 1350;
                    break;
                case 628:
                    DoLog("Honda Civic Tourer 1.6d 2016 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.8;
                    maxspeed = 121;
                    grip = 76;
                    weight = 1440;
                    break;
                case 629:
                    DoLog("Honda CR-Z 2016 e10");
                    clearance = 1;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.1;
                    maxspeed = 130;
                    grip = 75;
                    weight = 1214;
                    break;
                case 630:
                    DoLog("Honda Civic CRX Si 1983 e7");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 9;
                    maxspeed = 112;
                    grip = 74;
                    weight = 800;
                    break;
                case 631:
                    DoLog("Honda FR-V 2.2 i-CTDi 2004 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.8;
                    maxspeed = 116;
                    grip = 70;
                    weight = 1695;
                    break;
                case 632:
                    DoLog("Honda Odyssey 3.5 V6 2005 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.8;
                    maxspeed = 115;
                    grip = 69;
                    weight = 1600;
                    break;
                case 633:
                    DoLog("Honda Jazz 2016 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.7;
                    maxspeed = 118;
                    grip = 71;
                    weight = 1066;
                    break;
                case 634:
                    DoLog("Honda City Turbo 1981 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.1;
                    maxspeed = 106;
                    grip = 72;
                    weight = 690;
                    break;
                case 635:
                    DoLog("Honda Insight 2000 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.4;
                    maxspeed = 112;
                    grip = 71;
                    weight = 820;
                    break;
                case 636:
                    DoLog("Honda Prelude 2.0l 1982 f6");
                    clearance = 1;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.1;
                    maxspeed = 112;
                    grip = 69;
                    weight = 965;
                    break;
                case 637:
                    DoLog("Honda Jazz Hybrid 2007 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.6;
                    maxspeed = 110;
                    grip = 70;
                    weight = 1162;
                    break;
                case 638:
                    DoLog("Honda Jazz 2001 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.7;
                    maxspeed = 106;
                    grip = 70;
                    weight = 999;
                    break;
                case 639:
                    DoLog("Honda Odyssey 2.3 1995 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11;
                    maxspeed = 109;
                    grip = 66;
                    weight = 1532;
                    break;
                case 640:
                    DoLog("Honda S800 1967 f4");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 13.6;
                    maxspeed = 97;
                    grip = 65;
                    weight = 771;
                    break;
                case 641:
                    DoLog("Honda Beat 1991 f4");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 13.4;
                    maxspeed = 83;
                    grip = 77;
                    weight = 760;
                    break;
                case 642:
                    DoLog("Honda Accord 1.8 1976 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.6;
                    maxspeed = 99;
                    grip = 61;
                    weight = 960;
                    break;
                case 643:
                    DoLog("Honda City Cabriolet 1981 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 17.4;
                    maxspeed = 81;
                    grip = 66;
                    weight = 810;
                    break;
                case 644:
                    DoLog("Honda EV Plus 1997 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 16.5;
                    maxspeed = 81;
                    grip = 68;
                    weight = 1628;
                    break;
                case 645:
                    DoLog("Honda Prelude 1978 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.9;
                    maxspeed = 96;
                    grip = 64;
                    weight = 950;
                    break;
                case 646:
                    DoLog("Honda Vamos 4WD Turbo 2016 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 16.9;
                    maxspeed = 91;
                    grip = 68;
                    weight = 1070;
                    break;
                case 647:
                    DoLog("Hummer H3 2006 b19");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 9.3;
                    maxspeed = 97;
                    grip = 65;
                    weight = 2100;
                    break;
                case 648:
                    DoLog("Hummer H3T 2009 b19");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 9.3;
                    maxspeed = 97;
                    grip = 65;
                    weight = 2100;
                    break;
                case 649:
                    DoLog("Hummer H2 SUT 2005 c15");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 10.9;
                    maxspeed = 112;
                    grip = 60;
                    weight = 3000;
                    break;
                case 650:
                    DoLog("Hummer H2 SUV 2003 c15");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 10.9;
                    maxspeed = 112;
                    grip = 60;
                    weight = 3000;
                    break;
                case 651:
                    DoLog("Hummer H1 1992 e8");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 21.8;
                    maxspeed = 81;
                    grip = 55;
                    weight = 2727;
                    break;
                case 652:
                    DoLog("Infiniti Q60 2016 a25");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.8;
                    maxspeed = 155;
                    grip = 83;
                    weight = 1874;
                    break;
                case 653:
                    DoLog("Infiniti M45 2006 a24");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.1;
                    maxspeed = 155;
                    grip = 78;
                    weight = 1791;
                    break;
                case 654:
                    DoLog("Infiniti Q70 2016 a24");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.7;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1754;
                    break;
                case 655:
                    DoLog("Infiniti G35 2007 a24");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.1;
                    maxspeed = 155;
                    grip = 77;
                    weight = 1586;
                    break;
                case 656:
                    DoLog("Infiniti QX70 2016 a23");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.7;
                    maxspeed = 145;
                    grip = 79;
                    weight = 2012;
                    break;
                case 657:
                    DoLog("Infiniti FX35 2003 b22");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.9;
                    maxspeed = 143;
                    grip = 77;
                    weight = 1907;
                    break;
                case 658:
                    DoLog("Infiniti M45 2003 b22");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.3;
                    maxspeed = 155;
                    grip = 75;
                    weight = 1747;
                    break;
                case 659:
                    DoLog("Infiniti G37 2009 b21");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.6;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1857;
                    break;
                case 660:
                    DoLog("Infiniti QX30 2017 b22");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.8;
                    maxspeed = 134;
                    grip = 78;
                    weight = 1610;
                    break;
                case 661:
                    DoLog("Infiniti M35 2009 b21");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.7;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1758;
                    break;
                case 662:
                    DoLog("Infiniti G35 2002 b20");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.7;
                    maxspeed = 142;
                    grip = 76;
                    weight = 1513;
                    break;
                case 663:
                    DoLog("Infiniti QX50 2016 b19");
                    clearance = 3;
                    tires = 4;
                    drive = 2;
                    acceleration = 6.4;
                    maxspeed = 137;
                    grip = 79;
                    weight = 1823;
                    break;
                case 664:
                    DoLog("Infiniti Q50 2014 c15");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.4;
                    maxspeed = 144;
                    grip = 79;
                    weight = 1676;
                    break;
                case 665:
                    DoLog("Infiniti Q30 2016 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12;
                    maxspeed = 118;
                    grip = 78;
                    weight = 1434;
                    break;
                case 666:
                    DoLog("Jaguar XJ220 1992 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4;
                    maxspeed = 212;
                    grip = 85;
                    weight = 1560;
                    break;
                case 667:
                    DoLog("Jaguar F-Type R Convertible 2016 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4;
                    maxspeed = 186;
                    grip = 82;
                    weight = 1665;
                    break;
                case 668:
                    DoLog("Jaguar XJ13 1966 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.6;
                    maxspeed = 200;
                    grip = 85;
                    weight = 998;
                    break;
                case 669:
                    DoLog("Jaguar XKR-S GT 2014 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 186;
                    grip = 84;
                    weight = 1713;
                    break;
                case 670:
                    DoLog("Jaguar XKR-S Convertible 2011 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.2;
                    maxspeed = 186;
                    grip = 82;
                    weight = 1795;
                    break;
                case 671:
                    DoLog("Jaguar F-Pace 3.0 D 2016 a25");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5.9;
                    maxspeed = 150;
                    grip = 77;
                    weight = 1884;
                    break;
                case 672:
                    DoLog("Jaguar XFR-S Sportbrake 2016 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.6;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1967;
                    break;
                case 673:
                    DoLog("Jaguar XE S 2016 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.9;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1665;
                    break;
                case 674:
                    DoLog("Jaguar XF S 2016 b21");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.1;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1710;
                    break;
                case 675:
                    DoLog("Jaguar XJ 3.0 V6 2016 b21");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.1;
                    maxspeed = 155;
                    grip = 75;
                    weight = 1775;
                    break;
                case 676:
                    DoLog("Jaguar F-Type Coupe 2016 b20");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.5;
                    maxspeed = 162;
                    grip = 81;
                    weight = 1567;
                    break;
                case 677:
                    DoLog("Jaguar XJR 2003 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.6;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1665;
                    break;
                case 678:
                    DoLog("Jaguar XK8 1997 c16");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.4;
                    maxspeed = 156;
                    grip = 79;
                    weight = 1653;
                    break;
                case 679:
                    DoLog("Jaguar XKSS 1957 c16");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.1;
                    maxspeed = 150;
                    grip = 73;
                    weight = 890;
                    break;
                case 680:
                    DoLog("Jaguar XJ-S Trans-Am 1978 c17");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 6.5;
                    maxspeed = 160;
                    grip = 88;
                    weight = 1800;
                    break;
                case 681:
                    DoLog("Jaguar D-Type 1954 c18");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.7;
                    maxspeed = 162;
                    grip = 74;
                    weight = 864;
                    break;
                case 682:
                    DoLog("Jaguar XJ12 1968 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.5;
                    maxspeed = 140;
                    grip = 69;
                    weight = 1880;
                    break;
                case 683:
                    DoLog("Jaguar XJ6 1986 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.6;
                    maxspeed = 138;
                    grip = 72;
                    weight = 1825;
                    break;
                case 684:
                    DoLog("Jaguar E-Type 1961 d12");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.9;
                    maxspeed = 150;
                    grip = 62;
                    weight = 1234;
                    break;
                case 685:
                    DoLog("Jaguar XJS 1988 d12");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.1;
                    maxspeed = 143;
                    grip = 72;
                    weight = 1920;
                    break;
                case 686:
                    DoLog("Jaguar C-Type 1951 e10");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 8.1;
                    maxspeed = 141;
                    grip = 70;
                    weight = 965;
                    break;
                case 687:
                    DoLog("Jaguar XE SV Project 8 2017 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.3;
                    maxspeed = 200;
                    grip = 88;
                    weight = 1745;
                    break;
                case 688:
                    DoLog("Jaguar F-Type SVR Coupe 2017 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.5;
                    maxspeed = 200;
                    grip = 84;
                    weight = 1705;
                    break;
                case 689:
                    DoLog("Jaguar F-Type R Coupe AWD 2016 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.9;
                    maxspeed = 186;
                    grip = 82;
                    weight = 1730;
                    break;
                case 690:
                    DoLog("Jaguar XJR-15 1990 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 210;
                    grip = 87;
                    weight = 1048;
                    break;
                case 691:
                    DoLog("KTM X-Bow RR 2016 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.7;
                    maxspeed = 144;
                    grip = 89;
                    weight = 810;
                    break;
                case 692:
                    DoLog("KTM X-Bow R 2016 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.7;
                    maxspeed = 144;
                    grip = 88;
                    weight = 790;
                    break;
                case 693:
                    DoLog("KTM X-Bow GT 2016 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 144;
                    grip = 87;
                    weight = 847;
                    break;
                case 694:
                    DoLog("KTM X-Bow GT4 2016 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.6;
                    maxspeed = 160;
                    grip = 90;
                    weight = 1000;
                    break;
                case 695:
                    DoLog("Lancia Delta Integrale Evoluzione II 1993 b21");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.7;
                    maxspeed = 137;
                    grip = 83;
                    weight = 1300;
                    break;
                case 696:
                    DoLog("Lancia Delta Integrale Evoluzione 1991 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 6;
                    maxspeed = 134;
                    grip = 83;
                    weight = 1300;
                    break;
                case 697:
                    DoLog("Lancia Delta Integrale 16v 1989 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 6.1;
                    maxspeed = 132;
                    grip = 81;
                    weight = 1291;
                    break;
                case 698:
                    DoLog("Lancia Delta Integrale 8v 1989 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 7.1;
                    maxspeed = 132;
                    grip = 81;
                    weight = 1250;
                    break;
                case 699:
                    DoLog("Lancia Lancia Rally 037 Stradale 1982 c18");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.9;
                    maxspeed = 137;
                    grip = 85;
                    weight = 1170;
                    break;
                case 700:
                    DoLog("Lancia Stratos 1973 c17");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6;
                    maxspeed = 143;
                    grip = 80;
                    weight = 980;
                    break;
                case 701:
                    DoLog("Lancia Thema 8.32 1986 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.8;
                    maxspeed = 149;
                    grip = 79;
                    weight = 1400;
                    break;
                case 702:
                    DoLog("Lancia Delta HF 4WD 1986 c15");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 7.5;
                    maxspeed = 130;
                    grip = 78;
                    weight = 1188;
                    break;
                case 703:
                    DoLog("Lancia Beta Montecarlo 1975 e8");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 9.3;
                    maxspeed = 118;
                    grip = 78;
                    weight = 1040;
                    break;
                case 704:
                    DoLog("Lancia Fulvia Coupe 1965 e8");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.4;
                    maxspeed = 108;
                    grip = 75;
                    weight = 795;
                    break;
                case 705:
                    DoLog("Lancia Beta HPE 1978 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.1;
                    maxspeed = 108;
                    grip = 75;
                    weight = 1060;
                    break;
                case 706:
                    DoLog("Lancia Beta Coupe 1982 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.6;
                    maxspeed = 124;
                    grip = 77;
                    weight = 1095;
                    break;
                case 707:
                    DoLog("Lancia Ypsilon 2017 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.7;
                    maxspeed = 101;
                    grip = 72;
                    weight = 965;
                    break;
                case 708:
                    DoLog("Land Rover Range Rover 5.0 V8 2016 a23");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5.1;
                    maxspeed = 155;
                    grip = 69;
                    weight = 2330;
                    break;
                case 709:
                    DoLog("Land Rover Range Rover Sport SVR 2016 a26");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 4.5;
                    maxspeed = 162;
                    grip = 75;
                    weight = 2335;
                    break;
                case 710:
                    DoLog("Land Rover Range Rover Evoque 2016 b19");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 8.2;
                    maxspeed = 130;
                    grip = 72;
                    weight = 1936;
                    break;
                case 711:
                    DoLog("Land Rover Discovery Sport 2016 c18");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 8.4;
                    maxspeed = 117;
                    grip = 70;
                    weight = 1863;
                    break;
                case 712:
                    DoLog("Land Rover Discovery 2016 c16");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 9.9;
                    maxspeed = 112;
                    grip = 68;
                    weight = 2583;
                    break;
                case 713:
                    DoLog("Land Rover Defender 90 2011 d11");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 17.2;
                    maxspeed = 81;
                    grip = 59;
                    weight = 1795;
                    break;
                case 714:
                    DoLog("Land Rover Freelander 2 TD4 2012 d14");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 10.9;
                    maxspeed = 112;
                    grip = 64;
                    weight = 1770;
                    break;
                case 715:
                    DoLog("Land Rover Range Rover Mk 1 1970 d13");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 14;
                    maxspeed = 96;
                    grip = 61;
                    weight = 1724;
                    break;
                case 716:
                    DoLog("Lotus 2-Eleven GT4 2009 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.5;
                    maxspeed = 150;
                    grip = 92;
                    weight = 750;
                    break;
                case 717:
                    DoLog("Lotus 2-Eleven S'charged 2007 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.6;
                    maxspeed = 156;
                    grip = 90;
                    weight = 745;
                    break;
                case 718:
                    DoLog("Lotus Esprit Sport 350 1999 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.7;
                    maxspeed = 175;
                    grip = 85;
                    weight = 1300;
                    break;
                case 719:
                    DoLog("Lotus Carlton 1991 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.1;
                    maxspeed = 176;
                    grip = 78;
                    weight = 1663;
                    break;
                case 720:
                    DoLog("Lotus Esprit S4 1993 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.8;
                    maxspeed = 168;
                    grip = 83;
                    weight = 1338;
                    break;
                case 721:
                    DoLog("Lotus 340R 2000 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 132;
                    grip = 87;
                    weight = 675;
                    break;
                case 722:
                    DoLog("Lotus Elise Sport 135 2003 b19");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.1;
                    maxspeed = 129;
                    grip = 85;
                    weight = 756;
                    break;
                case 723:
                    DoLog("Lotus Esprit 1976 c16");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.5;
                    maxspeed = 137;
                    grip = 79;
                    weight = 900;
                    break;
                case 724:
                    DoLog("Lotus Elise 1996 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.6;
                    maxspeed = 124;
                    grip = 78;
                    weight = 755;
                    break;
                case 725:
                    DoLog("Lotus Elan SE 1989 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.5;
                    maxspeed = 137;
                    grip = 81;
                    weight = 1020;
                    break;
                case 726:
                    DoLog("Lotus Elise 111S 2002 c18");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.8;
                    maxspeed = 132;
                    grip = 80;
                    weight = 806;
                    break;
                case 727:
                    DoLog("Lotus Elan 1962 d11");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.7;
                    maxspeed = 115;
                    grip = 75;
                    weight = 585;
                    break;
                case 728:
                    DoLog("Lotus Elise 1.6 2015 d14");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6;
                    maxspeed = 127;
                    grip = 79;
                    weight = 876;
                    break;
                case 729:
                    DoLog("Lotus Exige S 2015 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.6;
                    maxspeed = 170;
                    grip = 88;
                    weight = 1080;
                    break;
                case 730:
                    DoLog("Mazda Furai 2007 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.5;
                    maxspeed = 180;
                    grip = 92;
                    weight = 675;
                    break;
                case 731:
                    DoLog("Mazda BBR MX-5 GT270 2013 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.9;
                    maxspeed = 150;
                    grip = 85;
                    weight = 1350;
                    break;
                case 732:
                    DoLog("Mazda 6 MPS 2005 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 6;
                    maxspeed = 155;
                    grip = 84;
                    weight = 1465;
                    break;
                case 733:
                    DoLog("Mazda Cosmo 1990 b20");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.7;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1600;
                    break;
                case 734:
                    DoLog("Mazda CX-9 2018 b19");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 7.1;
                    maxspeed = 140;
                    grip = 73;
                    weight = 1978;
                    break;
                case 735:
                    DoLog("Mazda RX-7 Spirit R 1992 b19");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.5;
                    maxspeed = 160;
                    grip = 85;
                    weight = 1260;
                    break;
                case 736:
                    DoLog("Mazda RX-7 Type RS 1992 b19");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.5;
                    maxspeed = 160;
                    grip = 85;
                    weight = 1280;
                    break;
                case 737:
                    DoLog("Mazda RX-7 Type RZ 1992 b19");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.5;
                    maxspeed = 160;
                    grip = 85;
                    weight = 1270;
                    break;
                case 738:
                    DoLog("Mazda RX-8 Spirit R 2012 c16");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.5;
                    maxspeed = 150;
                    grip = 86;
                    weight = 1306;
                    break;
                case 739:
                    DoLog("Mazda Jota MX-5 GT 2013 c16");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.4;
                    maxspeed = 140;
                    grip = 85;
                    weight = 1280;
                    break;
                case 740:
                    DoLog("Mazda RX-7 Turbo 1985 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.7;
                    maxspeed = 149;
                    grip = 80;
                    weight = 1285;
                    break;
                case 741:
                    DoLog("Mazda RX-8 PZ 2006 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.1;
                    maxspeed = 142;
                    grip = 84;
                    weight = 1350;
                    break;
                case 742:
                    DoLog("Mazda RX-7 1992 c18");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.5;
                    maxspeed = 156;
                    grip = 84;
                    weight = 1310;
                    break;
                case 743:
                    DoLog("Mazda 6 2018 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9;
                    maxspeed = 129;
                    grip = 75;
                    weight = 1465;
                    break;
                case 744:
                    DoLog("Mazda RX-8 2002 d14");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.1;
                    maxspeed = 142;
                    grip = 82;
                    weight = 1350;
                    break;
                case 745:
                    DoLog("Mazda MX-5 2018 d14");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.9;
                    maxspeed = 133;
                    grip = 80;
                    weight = 1075;
                    break;
                case 746:
                    DoLog("Mazda RX-7 Turbo 1983 d14");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.8;
                    maxspeed = 143;
                    grip = 79;
                    weight = 995;
                    break;
                case 747:
                    DoLog("Mazda MX-5 1989 d12");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.5;
                    maxspeed = 117;
                    grip = 79;
                    weight = 970;
                    break;
                case 748:
                    DoLog("Mazda MX-5 2005 d12");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.1;
                    maxspeed = 130;
                    grip = 79;
                    weight = 1075;
                    break;
                case 749:
                    DoLog("Mazda MX-5 BBR Turbo 1990 d13");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.2;
                    maxspeed = 131;
                    grip = 83;
                    weight = 985;
                    break;
                case 750:
                    DoLog("Mazda RX-7 Convertible 1988 d12");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.9;
                    maxspeed = 145;
                    grip = 77;
                    weight = 1320;
                    break;
                case 751:
                    DoLog("Mazda 3 2018 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.5;
                    maxspeed = 121;
                    grip = 76;
                    weight = 1351;
                    break;
                case 752:
                    DoLog("Mazda BT-50 2018 d11");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 10.1;
                    maxspeed = 110;
                    grip = 65;
                    weight = 1865;
                    break;
                case 753:
                    DoLog("Mazda MX-5 RF 2018 d11");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 8.2;
                    maxspeed = 126;
                    grip = 79;
                    weight = 1090;
                    break;
                case 754:
                    DoLog("Mazda CX-3 2018 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.6;
                    maxspeed = 119;
                    grip = 74;
                    weight = 1230;
                    break;
                case 755:
                    DoLog("Mazda MX-5 1998 d11");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.7;
                    maxspeed = 119;
                    grip = 80;
                    weight = 1035;
                    break;
                case 756:
                    DoLog("Mazda RX-7 1978 e10");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.5;
                    maxspeed = 115;
                    grip = 77;
                    weight = 1024;
                    break;
                case 757:
                    DoLog("Mazda RX-7 1985 e9");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 8.6;
                    maxspeed = 130;
                    grip = 78;
                    weight = 1223;
                    break;
                case 758:
                    DoLog("Mazda Cosmo 1967 e9");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.3;
                    maxspeed = 120;
                    grip = 72;
                    weight = 930;
                    break;
                case 759:
                    DoLog("Mazda Cosmo 1975 e9");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.1;
                    maxspeed = 123;
                    grip = 72;
                    weight = 980;
                    break;
                case 760:
                    DoLog("Mazda Autozam AZ-1 1992 e7");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 13.5;
                    maxspeed = 91;
                    grip = 79;
                    weight = 720;
                    break;
                case 761:
                    DoLog("Mazda 2 2018 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.8;
                    maxspeed = 117;
                    grip = 75;
                    weight = 1035;
                    break;
                case 762:
                    DoLog("Mazda CX-5 2018 e9");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.9;
                    maxspeed = 125;
                    grip = 73;
                    weight = 1574;
                    break;
                case 763:
                    DoLog("Mazda Cosmo 1981 e7");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.9;
                    maxspeed = 109;
                    grip = 74;
                    weight = 1120;
                    break;
                case 764:
                    DoLog("Mazda RX-3 1971 e8");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.8;
                    maxspeed = 115;
                    grip = 70;
                    weight = 884;
                    break;
                case 765:
                    DoLog("Mazda Eunos Roadster RS-Limited 1994 e10");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.1;
                    maxspeed = 116;
                    grip = 81;
                    weight = 983;
                    break;
                case 766:
                    DoLog("Mazda Carol 1962 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 16;
                    maxspeed = 78;
                    grip = 69;
                    weight = 580;
                    break;
                case 767:
                    DoLog("Mazda 787b 1990 s29");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 2.8;
                    maxspeed = 220;
                    grip = 95;
                    weight = 830;
                    break;
                case 768:
                    DoLog("McLaren Mercedes-Benz SLR McLaren 2003 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.6;
                    maxspeed = 207;
                    grip = 87;
                    weight = 1628;
                    break;
                case 769:
                    DoLog("McLaren Mercedes-Benz SLR McLaren Roadster 2007 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.6;
                    maxspeed = 206;
                    grip = 86;
                    weight = 1825;
                    break;
                case 770:
                    DoLog("McLaren 720S 2018 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.5;
                    maxspeed = 212;
                    grip = 93;
                    weight = 1419;
                    break;
                case 771:
                    DoLog("McLaren P1 GTR 2015 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.3;
                    maxspeed = 217;
                    grip = 97;
                    weight = 1345;
                    break;
                case 772:
                    DoLog("McLaren 675LT 2015 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.8;
                    maxspeed = 205;
                    grip = 93;
                    weight = 1358;
                    break;
                case 773:
                    DoLog("McLaren P1 2014 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.7;
                    maxspeed = 217;
                    grip = 95;
                    weight = 1450;
                    break;
                case 774:
                    DoLog("McLaren F1 LM 1995 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.9;
                    maxspeed = 225;
                    grip = 91;
                    weight = 1062;
                    break;
                case 775:
                    DoLog("McLaren F1 GT 1997 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.3;
                    maxspeed = 240;
                    grip = 90;
                    weight = 1120;
                    break;
                case 776:
                    DoLog("McLaren 650S 2014 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.9;
                    maxspeed = 207;
                    grip = 90;
                    weight = 1428;
                    break;
                case 777:
                    DoLog("McLaren 12C 2011 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3;
                    maxspeed = 207;
                    grip = 89;
                    weight = 1434;
                    break;
                case 778:
                    DoLog("McLaren 570S Coupe 2015 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.9;
                    maxspeed = 204;
                    grip = 88;
                    weight = 1313;
                    break;
                case 779:
                    DoLog("McLaren F1 1994 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.2;
                    maxspeed = 240;
                    grip = 87;
                    weight = 1138;
                    break;
                case 780:
                    DoLog("McLaren Mercedes-Benz SLR McLaren 722 2006 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.4;
                    maxspeed = 210;
                    grip = 88;
                    weight = 1724;
                    break;
                case 781:
                    DoLog("Mercedes-Benz AMG A 45 2016 a26");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1555;
                    break;
                case 782:
                    DoLog("Mercedes-Benz AMG GT 2016 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.8;
                    maxspeed = 189;
                    grip = 85;
                    weight = 1615;
                    break;
                case 783:
                    DoLog("Mercedes-Benz AMG GLE 63 S 2015 a25");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 4;
                    maxspeed = 155;
                    grip = 71;
                    weight = 2345;
                    break;
                case 784:
                    DoLog("Mercedes-Benz AMG C 63 2015 a25");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4;
                    maxspeed = 155;
                    grip = 82;
                    weight = 1785;
                    break;
                case 785:
                    DoLog("Mercedes-Benz AMG CLK 63 Black Series 2007 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.1;
                    maxspeed = 188;
                    grip = 84;
                    weight = 1760;
                    break;
                case 786:
                    DoLog("Mercedes-Benz AMG CLK DTM 2007 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.7;
                    maxspeed = 186;
                    grip = 82;
                    weight = 1840;
                    break;
                case 787:
                    DoLog("Mercedes-Benz AMG ML 63 2016 a25");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 4.5;
                    maxspeed = 155;
                    grip = 70;
                    weight = 2345;
                    break;
                case 788:
                    DoLog("Mercedes-Benz AMG C 63 2012 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.3;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1730;
                    break;
                case 789:
                    DoLog("Mercedes-Benz AMG E 63 2011 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.3;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1840;
                    break;
                case 790:
                    DoLog("Mercedes-Benz AMG E 63 S 2015 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1870;
                    break;
                case 791:
                    DoLog("Mercedes-Benz CLA 250 4MATIC 2015 a24");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 6.3;
                    maxspeed = 155;
                    grip = 77;
                    weight = 1540;
                    break;
                case 792:
                    DoLog("Mercedes-Benz CLS 400 2015 a25");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.1;
                    maxspeed = 155;
                    grip = 78;
                    weight = 1775;
                    break;
                case 793:
                    DoLog("Mercedes-Benz AMG G 63 6x6 2013 a23");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 5.6;
                    maxspeed = 100;
                    grip = 64;
                    weight = 3775;
                    break;
                case 794:
                    DoLog("Mercedes-Benz 57S Maybach 2012 a23");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 4.7;
                    maxspeed = 171;
                    grip = 70;
                    weight = 2735;
                    break;
                case 795:
                    DoLog("Mercedes-Benz AMG E 55 2003 a23");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1735;
                    break;
                case 796:
                    DoLog("Mercedes-Benz AMG S 65 2006 a23");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.2;
                    maxspeed = 155;
                    grip = 77;
                    weight = 2270;
                    break;
                case 797:
                    DoLog("Mercedes-Benz AMG S 65 Coupe 2016 a23");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.1;
                    maxspeed = 155;
                    grip = 77;
                    weight = 2270;
                    break;
                case 798:
                    DoLog("Mercedes-Benz SL 500 2016 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.1;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1785;
                    break;
                case 799:
                    DoLog("Mercedes-Benz C 350 4MATIC 2009 a23");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 6.1;
                    maxspeed = 155;
                    grip = 73;
                    weight = 1760;
                    break;
                case 800:
                    DoLog("Mercedes-Benz AMG SLS Roadster 2012 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.6;
                    maxspeed = 197;
                    grip = 86;
                    weight = 1735;
                    break;
                case 801:
                    DoLog("Mercedes-Benz AMG S 55 2003 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.6;
                    maxspeed = 155;
                    grip = 76;
                    weight = 1885;
                    break;
                case 802:
                    DoLog("Mercedes-Benz AMG SLC 43 2016 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 155;
                    grip = 81;
                    weight = 1595;
                    break;
                case 803:
                    DoLog("Mercedes-Benz C 350e 2015 b22");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5.6;
                    maxspeed = 155;
                    grip = 75;
                    weight = 1780;
                    break;
                case 804:
                    DoLog("Mercedes-Benz AMG C 55 2007 b21");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5;
                    maxspeed = 155;
                    grip = 77;
                    weight = 1635;
                    break;
                case 805:
                    DoLog("Mercedes-Benz AMG SL 73 1999 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 186;
                    grip = 78;
                    weight = 2050;
                    break;
                case 806:
                    DoLog("Mercedes-Benz AMG SLK 32 2004 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1395;
                    break;
                case 807:
                    DoLog("Mercedes-Benz AMG G 63 2015 b21");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5.2;
                    maxspeed = 131;
                    grip = 65;
                    weight = 2550;
                    break;
                case 808:
                    DoLog("Mercedes-Benz 62 Landaulet Maybach 2010 b20");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 5;
                    maxspeed = 155;
                    grip = 65;
                    weight = 2855;
                    break;
                case 809:
                    DoLog("Mercedes-Benz AMG G 55 2006 b20");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5.3;
                    maxspeed = 131;
                    grip = 64;
                    weight = 2450;
                    break;
                case 810:
                    DoLog("Mercedes-Benz C 250d 2015 b20");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.3;
                    maxspeed = 154;
                    grip = 75;
                    weight = 1595;
                    break;
                case 811:
                    DoLog("Mercedes-Benz E 430 1999 b20");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.3;
                    maxspeed = 155;
                    grip = 72;
                    weight = 1580;
                    break;
                case 812:
                    DoLog("Mercedes-Benz G 500 2012 b20");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5.6;
                    maxspeed = 131;
                    grip = 63;
                    weight = 2380;
                    break;
                case 813:
                    DoLog("Mercedes-Benz E 500 1994 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.8;
                    maxspeed = 155;
                    grip = 74;
                    weight = 1710;
                    break;
                case 814:
                    DoLog("Mercedes-Benz GLC 250d 2015 b20");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.3;
                    maxspeed = 138;
                    grip = 69;
                    weight = 1735;
                    break;
                case 815:
                    DoLog("Mercedes-Benz S 350 4MATIC 2007 b19");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 7.5;
                    maxspeed = 152;
                    grip = 71;
                    weight = 2030;
                    break;
                case 816:
                    DoLog("Mercedes-Benz GL 350 2015 b19");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.6;
                    maxspeed = 137;
                    grip = 69;
                    weight = 2455;
                    break;
                case 817:
                    DoLog("Mercedes-Benz S 400h L 2016 b19");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.5;
                    maxspeed = 155;
                    grip = 72;
                    weight = 1945;
                    break;
                case 818:
                    DoLog("Mercedes-Benz AMG S 63 2009 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.3;
                    maxspeed = 155;
                    grip = 76;
                    weight = 2120;
                    break;
                case 819:
                    DoLog("Mercedes-Benz AMG SLK Black Series 2007 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 174;
                    grip = 82;
                    weight = 1506;
                    break;
                case 820:
                    DoLog("Mercedes-Benz E 320 CDI 2005 c18");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7;
                    maxspeed = 149;
                    grip = 74;
                    weight = 1785;
                    break;
                case 821:
                    DoLog("Mercedes-Benz GLA 220d 2015 c18");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 7.4;
                    maxspeed = 135;
                    grip = 67;
                    weight = 1595;
                    break;
                case 822:
                    DoLog("Mercedes-Benz AMG C 43 1999 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.2;
                    maxspeed = 155;
                    grip = 74;
                    weight = 1470;
                    break;
                case 823:
                    DoLog("Mercedes-Benz SLK 200 2016 c16");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.7;
                    maxspeed = 149;
                    grip = 79;
                    weight = 1455;
                    break;
                case 824:
                    DoLog("Mercedes-Benz 190 E Evo II 1990 c15");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.5;
                    maxspeed = 155;
                    grip = 75;
                    weight = 1340;
                    break;
                case 825:
                    DoLog("Mercedes-Benz E 320 1994 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.8;
                    maxspeed = 146;
                    grip = 64;
                    weight = 1690;
                    break;
                case 826:
                    DoLog("Mercedes-Benz 280 GE 1979 d14");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 11.1;
                    maxspeed = 124;
                    grip = 60;
                    weight = 1460;
                    break;
                case 827:
                    DoLog("Mercedes-Benz E 220 2015 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.4;
                    maxspeed = 137;
                    grip = 75;
                    weight = 1735;
                    break;
                case 828:
                    DoLog("Mercedes-Benz 190 E 2.3-16 1984 d13");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.7;
                    maxspeed = 143;
                    grip = 73;
                    weight = 1220;
                    break;
                case 829:
                    DoLog("Mercedes-Benz CLK 230 K 1999 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8;
                    maxspeed = 145;
                    grip = 71;
                    weight = 1325;
                    break;
                case 830:
                    DoLog("Mercedes-Benz A 200 2012 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8;
                    maxspeed = 139;
                    grip = 70;
                    weight = 1370;
                    break;
                case 831:
                    DoLog("Mercedes-Benz C 200 K 2002 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.5;
                    maxspeed = 143;
                    grip = 70;
                    weight = 1390;
                    break;
                case 832:
                    DoLog("Mercedes-Benz 190 E 2.0 1985 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 10;
                    maxspeed = 121;
                    grip = 61;
                    weight = 1100;
                    break;
                case 833:
                    DoLog("Mercedes-Benz A 180d 2012 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.8;
                    maxspeed = 118;
                    grip = 70;
                    weight = 1395;
                    break;
                case 834:
                    DoLog("Mercedes-Benz A 200 CDI 2004 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.7;
                    maxspeed = 125;
                    grip = 68;
                    weight = 1365;
                    break;
                case 835:
                    DoLog("Mercedes-Benz 300 SL 1963 e7");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.6;
                    maxspeed = 146;
                    grip = 60;
                    weight = 1329;
                    break;
                case 836:
                    DoLog("Mercedes-Benz S 280 1995 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.3;
                    maxspeed = 134;
                    grip = 65;
                    weight = 1850;
                    break;
                case 837:
                    DoLog("Mercedes-Benz V 250d 2015 e7");
                    clearance = 3;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.5;
                    maxspeed = 129;
                    grip = 55;
                    weight = 2105;
                    break;
                case 838:
                    DoLog("Mercedes-Benz 600 1964 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.2;
                    maxspeed = 127;
                    grip = 55;
                    weight = 2475;
                    break;
                case 839:
                    DoLog("Mercedes-Benz A 160 1997 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.2;
                    maxspeed = 113;
                    grip = 64;
                    weight = 1040;
                    break;
                case 840:
                    DoLog("Mercedes-Benz AMG SLS Black Series 2013 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.5;
                    maxspeed = 196;
                    grip = 89;
                    weight = 1550;
                    break;
                case 841:
                    DoLog("Mercedes-Benz AMG SLS Electric 2013 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.7;
                    maxspeed = 155;
                    grip = 86;
                    weight = 2110;
                    break;
                case 842:
                    DoLog("Mercedes-Benz AMG SLS GT 2012 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.6;
                    maxspeed = 199;
                    grip = 88;
                    weight = 1320;
                    break;
                case 843:
                    DoLog("Mercedes-Benz AMG GT S 2016 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.7;
                    maxspeed = 193;
                    grip = 86;
                    weight = 1645;
                    break;
                case 844:
                    DoLog("Mercedes-Benz AMG SLS GT3 2016 s27");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 3.4;
                    maxspeed = 190;
                    grip = 97;
                    weight = 1300;
                    break;
                case 845:
                    DoLog("Mercedes-Benz AMG SLS 2010 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.6;
                    maxspeed = 197;
                    grip = 86;
                    weight = 1695;
                    break;
                case 846:
                    DoLog("MG Metro 6R4 1984 a25");
                    clearance = 1;
                    tires = 5;
                    drive = 4;
                    acceleration = 4.8;
                    maxspeed = 140;
                    grip = 85;
                    weight = 1030;
                    break;
                case 847:
                    DoLog("MG Maestro Turbo 1983 c15");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.8;
                    maxspeed = 129;
                    grip = 82;
                    weight = 1087;
                    break;
                case 848:
                    DoLog("MG Montego Turbo 1985 d13");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.5;
                    maxspeed = 129;
                    grip = 80;
                    weight = 1098;
                    break;
                case 849:
                    DoLog("MG MGB GT V8 1973 d11");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.7;
                    maxspeed = 125;
                    grip = 70;
                    weight = 1084;
                    break;
                case 850:
                    DoLog("MG MGC GT 1967 e7");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 10;
                    maxspeed = 120;
                    grip = 67;
                    weight = 1116;
                    break;
                case 851:
                    DoLog("MG Metro Turbo 1982 e8");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 9.4;
                    maxspeed = 110;
                    grip = 78;
                    weight = 840;
                    break;
                case 852:
                    DoLog("MG Midget 1961 f5");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 12.5;
                    maxspeed = 95;
                    grip = 68;
                    weight = 685;
                    break;
                case 853:
                    DoLog("MG MGB 1962 f5");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 12.2;
                    maxspeed = 103;
                    grip = 69;
                    weight = 920;
                    break;
                case 854:
                    DoLog("Mini JCW ALL4 Countryman 2016 b22");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.6;
                    maxspeed = 142;
                    grip = 71;
                    weight = 1480;
                    break;
                case 855:
                    DoLog("Mini John Cooper Works 2016 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6;
                    maxspeed = 153;
                    grip = 80;
                    weight = 1280;
                    break;
                case 856:
                    DoLog("Mini JCW Convertible 2016 c18");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.3;
                    maxspeed = 150;
                    grip = 77;
                    weight = 1385;
                    break;
                case 857:
                    DoLog("Mini JCW Coupe 2016 c18");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.1;
                    maxspeed = 149;
                    grip = 79;
                    weight = 1250;
                    break;
                case 858:
                    DoLog("Mini Cooper S Works GP 2006 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.2;
                    maxspeed = 149;
                    grip = 77;
                    weight = 1120;
                    break;
                case 859:
                    DoLog("Mini Cooper S 2016 c16");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.6;
                    maxspeed = 144;
                    grip = 78;
                    weight = 1295;
                    break;
                case 860:
                    DoLog("Mini Cooper 2016 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.8;
                    maxspeed = 129;
                    grip = 75;
                    weight = 1220;
                    break;
                case 861:
                    DoLog("Mini Cooper SD 2011 d13");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.7;
                    maxspeed = 134;
                    grip = 74;
                    weight = 1225;
                    break;
                case 862:
                    DoLog("Mini Cooper Convertible 2016 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.4;
                    maxspeed = 129;
                    grip = 75;
                    weight = 1280;
                    break;
                case 863:
                    DoLog("Mini One 2016 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.4;
                    maxspeed = 121;
                    grip = 70;
                    weight = 1165;
                    break;
                case 864:
                    DoLog("Mini Cooper S 1971 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.2;
                    maxspeed = 96;
                    grip = 60;
                    weight = 650;
                    break;
                case 865:
                    DoLog("Mitsubishi Lancer Evo VIII FQ-400 2004 a30");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.3;
                    maxspeed = 175;
                    grip = 87;
                    weight = 1410;
                    break;
                case 866:
                    DoLog("Mitsubishi Lancer Evo IX MR FQ-360 2007 a26");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.9;
                    maxspeed = 160;
                    grip = 87;
                    weight = 1410;
                    break;
                case 867:
                    DoLog("Mitsubishi Lancer Evo X FQ-360 2009 a26");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.9;
                    maxspeed = 155;
                    grip = 88;
                    weight = 1560;
                    break;
                case 868:
                    DoLog("Mitsubishi Lancer Evo VI T.M. Edition 2000 a25");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.5;
                    maxspeed = 149;
                    grip = 86;
                    weight = 1360;
                    break;
                case 869:
                    DoLog("Mitsubishi Lancer Evo VIII MR FQ-340 2005 a26");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.7;
                    maxspeed = 157;
                    grip = 87;
                    weight = 1400;
                    break;
                case 870:
                    DoLog("Mitsubishi Lancer Evo X FQ-300 SST 2007 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.2;
                    maxspeed = 150;
                    grip = 87;
                    weight = 1540;
                    break;
                case 871:
                    DoLog("Mitsubishi Lancer Evo VIII 260 2004 a23");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.8;
                    maxspeed = 152;
                    grip = 86;
                    weight = 1470;
                    break;
                case 872:
                    DoLog("Mitsubishi Lancer Evo I 1992 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.2;
                    maxspeed = 112;
                    grip = 81;
                    weight = 1240;
                    break;
                case 873:
                    DoLog("Mitsubishi Outlander PHEV 2016 b19");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 8.6;
                    maxspeed = 106;
                    grip = 76;
                    weight = 1845;
                    break;
                case 874:
                    DoLog("Mitsubishi Lancer Evo IV 1996 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.9;
                    maxspeed = 112;
                    grip = 85;
                    weight = 1350;
                    break;
                case 875:
                    DoLog("Mitsubishi ASX 2015 c17");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 11.1;
                    maxspeed = 111;
                    grip = 78;
                    weight = 1450;
                    break;
                case 876:
                    DoLog("Mitsubishi Montero Black Edition 2011 c16");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 10.7;
                    maxspeed = 111;
                    grip = 75;
                    weight = 2300;
                    break;
                case 877:
                    DoLog("Mitsubishi Montero SG4 2011 c16");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 10.7;
                    maxspeed = 111;
                    grip = 75;
                    weight = 2300;
                    break;
                case 878:
                    DoLog("Mitsubishi Colt Ralliart Version-R 2009 c15");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.7;
                    maxspeed = 131;
                    grip = 83;
                    weight = 1110;
                    break;
                case 879:
                    DoLog("Mitsubishi L200 2016 c15");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 11.6;
                    maxspeed = 105;
                    grip = 72;
                    weight = 1805;
                    break;
                case 880:
                    DoLog("Mitsubishi Outlander 2012 c18");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 9.9;
                    maxspeed = 120;
                    grip = 77;
                    weight = 1555;
                    break;
                case 881:
                    DoLog("Mitsubishi Lancer GS4 2007 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.3;
                    maxspeed = 129;
                    grip = 76;
                    weight = 1450;
                    break;
                case 882:
                    DoLog("Mitsubishi ASX 2010 d14");
                    clearance = 3;
                    tires = 4;
                    drive = 1;
                    acceleration = 10.9;
                    maxspeed = 114;
                    grip = 78;
                    weight = 1270;
                    break;
                case 883:
                    DoLog("Mitsubishi Colt CZC 2006 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.2;
                    maxspeed = 114;
                    grip = 77;
                    weight = 1110;
                    break;
                case 884:
                    DoLog("Mitsubishi Lancer Sportback 2008 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.9;
                    maxspeed = 122;
                    grip = 76;
                    weight = 1355;
                    break;
                case 885:
                    DoLog("Mitsubishi Grandis 2006 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.3;
                    maxspeed = 121;
                    grip = 76;
                    weight = 1725;
                    break;
                case 886:
                    DoLog("Mitsubishi Colt 2009 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.4;
                    maxspeed = 101;
                    grip = 75;
                    weight = 930;
                    break;
                case 887:
                    DoLog("Mitsubishi Colt 2004 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.5;
                    maxspeed = 103;
                    grip = 73;
                    weight = 930;
                    break;
                case 888:
                    DoLog("Mitsubishi i 2007 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 15.1;
                    maxspeed = 81;
                    grip = 70;
                    weight = 1110;
                    break;
                case 889:
                    DoLog("Mitsubishi Mirage 2013 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.2;
                    maxspeed = 107;
                    grip = 76;
                    weight = 845;
                    break;
                case 890:
                    DoLog("Nissan Patrol Nismo 2016 a23");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6;
                    maxspeed = 155;
                    grip = 74;
                    weight = 2722;
                    break;
                case 891:
                    DoLog("Nissan Skyline GT-R (R34) 1999 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.9;
                    maxspeed = 170;
                    grip = 83;
                    weight = 1560;
                    break;
                case 892:
                    DoLog("Nissan Juke Nismo 2016 b19");
                    clearance = 3;
                    tires = 4;
                    drive = 1;
                    acceleration = 7.6;
                    maxspeed = 134;
                    grip = 83;
                    weight = 1338;
                    break;
                case 893:
                    DoLog("Nissan Skyline GT-R (R33) 1997 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 5;
                    maxspeed = 155;
                    grip = 82;
                    weight = 1530;
                    break;
                case 894:
                    DoLog("Nissan Skyline GT-R (R32) 1989 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.6;
                    maxspeed = 156;
                    grip = 81;
                    weight = 1430;
                    break;
                case 895:
                    DoLog("Nissan Murano 2008 b21");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.6;
                    maxspeed = 130;
                    grip = 76;
                    weight = 1790;
                    break;
                case 896:
                    DoLog("Nissan Murano GT-C 2002 b22");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.7;
                    maxspeed = 140;
                    grip = 77;
                    weight = 1890;
                    break;
                case 897:
                    DoLog("Nissan Silvia 240RS 1983 b22");
                    clearance = 2;
                    tires = 5;
                    drive = 2;
                    acceleration = 4.9;
                    maxspeed = 142;
                    grip = 81;
                    weight = 1105;
                    break;
                case 898:
                    DoLog("Nissan 370Z 2011 b20");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.9;
                    maxspeed = 155;
                    grip = 83;
                    weight = 1466;
                    break;
                case 899:
                    DoLog("Nissan Murano 2002 b20");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 8;
                    maxspeed = 124;
                    grip = 75;
                    weight = 1865;
                    break;
                case 900:
                    DoLog("Nissan Pathfinder 2016 b20");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 8.7;
                    maxspeed = 116;
                    grip = 77;
                    weight = 2010;
                    break;
                case 901:
                    DoLog("Nissan Pathfinder 2006 b20");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 8.4;
                    maxspeed = 110;
                    grip = 76;
                    weight = 1900;
                    break;
                case 902:
                    DoLog("Nissan Pathfinder 2010 b20");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 8.5;
                    maxspeed = 118;
                    grip = 76;
                    weight = 2132;
                    break;
                case 903:
                    DoLog("Nissan Murano CrossCabriolet 2008 b19");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 8.8;
                    maxspeed = 130;
                    grip = 75;
                    weight = 2013;
                    break;
                case 904:
                    DoLog("Nissan 350Z Roadster 2005 c17");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.1;
                    maxspeed = 155;
                    grip = 82;
                    weight = 1635;
                    break;
                case 905:
                    DoLog("Nissan Qashqai 2008 c18");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 10.4;
                    maxspeed = 118;
                    grip = 77;
                    weight = 1582;
                    break;
                case 906:
                    DoLog("Nissan X-Trail 2016 c18");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 10.5;
                    maxspeed = 116;
                    grip = 78;
                    weight = 1580;
                    break;
                case 907:
                    DoLog("Nissan X-Trail 2010 c17");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 10.7;
                    maxspeed = 117;
                    grip = 77;
                    weight = 1625;
                    break;
                case 908:
                    DoLog("Nissan Datsun 240Z Rally Car 1969 c18");
                    clearance = 1;
                    tires = 5;
                    drive = 2;
                    acceleration = 6.3;
                    maxspeed = 144;
                    grip = 80;
                    weight = 995;
                    break;
                case 909:
                    DoLog("Nissan X-Trail 2001 c17");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 10.7;
                    maxspeed = 110;
                    grip = 76;
                    weight = 1415;
                    break;
                case 910:
                    DoLog("Nissan Navara 2016 c16");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 10.8;
                    maxspeed = 106;
                    grip = 73;
                    weight = 2050;
                    break;
                case 911:
                    DoLog("Nissan Almera GTI 1997 c16");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.9;
                    maxspeed = 131;
                    grip = 79;
                    weight = 1155;
                    break;
                case 912:
                    DoLog("Nissan 200SX 1993 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.9;
                    maxspeed = 140;
                    grip = 80;
                    weight = 1185;
                    break;
                case 913:
                    DoLog("Nissan Navara 2017 c15");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 11.4;
                    maxspeed = 107;
                    grip = 75;
                    weight = 1961;
                    break;
                case 914:
                    DoLog("Nissan 350Z 2002 c18");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.6;
                    maxspeed = 155;
                    grip = 83;
                    weight = 1525;
                    break;
                case 915:
                    DoLog("Nissan Pathfinder 1985 d14");
                    clearance = 3;
                    tires = 4;
                    drive = 2;
                    acceleration = 10;
                    maxspeed = 112;
                    grip = 74;
                    weight = 1630;
                    break;
                case 916:
                    DoLog("Nissan Qashqai 2016 d13");
                    clearance = 3;
                    tires = 4;
                    drive = 1;
                    acceleration = 11.5;
                    maxspeed = 113;
                    grip = 77;
                    weight = 1365;
                    break;
                case 917:
                    DoLog("Nissan Primera eGT 1990 d14");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8;
                    maxspeed = 137;
                    grip = 81;
                    weight = 1245;
                    break;
                case 918:
                    DoLog("Nissan Terrano II 2002 d14");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 12.9;
                    maxspeed = 103;
                    grip = 76;
                    weight = 1760;
                    break;
                case 919:
                    DoLog("Nissan Patrol 2000 d11");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 14.7;
                    maxspeed = 90;
                    grip = 69;
                    weight = 1945;
                    break;
                case 920:
                    DoLog("Nissan Juke 2013 d14");
                    clearance = 3;
                    tires = 4;
                    drive = 1;
                    acceleration = 10.5;
                    maxspeed = 111;
                    grip = 78;
                    weight = 1236;
                    break;
                case 921:
                    DoLog("Nissan Primera 2004 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.3;
                    maxspeed = 126;
                    grip = 76;
                    weight = 1300;
                    break;
                case 922:
                    DoLog("Nissan Skyline Hardtop 2000 GT-R (C10) 1971 d14");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.6;
                    maxspeed = 124;
                    grip = 76;
                    weight = 1100;
                    break;
                case 923:
                    DoLog("Nissan Patrol 1986 e9");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 16.1;
                    maxspeed = 90;
                    grip = 68;
                    weight = 2040;
                    break;
                case 924:
                    DoLog("Nissan Patrol 1997 e9");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 16.9;
                    maxspeed = 96;
                    grip = 71;
                    weight = 2070;
                    break;
                case 925:
                    DoLog("Nissan Pulsar 1995 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.5;
                    maxspeed = 114;
                    grip = 76;
                    weight = 1050;
                    break;
                case 926:
                    DoLog("Nissan Cube 2010 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.7;
                    maxspeed = 110;
                    grip = 76;
                    weight = 1265;
                    break;
                case 927:
                    DoLog("Nissan Note 2013 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.7;
                    maxspeed = 113;
                    grip = 75;
                    weight = 1095;
                    break;
                case 928:
                    DoLog("Nissan Pulsar 2015 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.5;
                    maxspeed = 118;
                    grip = 78;
                    weight = 1245;
                    break;
                case 929:
                    DoLog("Nissan Cube 1998 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.1;
                    maxspeed = 102;
                    grip = 75;
                    weight = 1010;
                    break;
                case 930:
                    DoLog("Nissan Patrol (type 60) 1959 e8");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 99;
                    maxspeed = 56;
                    grip = 65;
                    weight = 1520;
                    break;
                case 931:
                    DoLog("Nissan S-Cargo 1989 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.9;
                    maxspeed = 91;
                    grip = 72;
                    weight = 950;
                    break;
                case 932:
                    DoLog("Nissan Silvia 1975 e8");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.5;
                    maxspeed = 110;
                    grip = 74;
                    weight = 990;
                    break;
                case 933:
                    DoLog("Nissan Datsun 240Z 1969 e7");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 9.8;
                    maxspeed = 115;
                    grip = 75;
                    weight = 1085;
                    break;
                case 934:
                    DoLog("Nissan Leaf 2016 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.2;
                    maxspeed = 89;
                    grip = 75;
                    weight = 1525;
                    break;
                case 935:
                    DoLog("Nissan Silvia 1965 e7");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.3;
                    maxspeed = 103;
                    grip = 72;
                    weight = 980;
                    break;
                case 936:
                    DoLog("Nissan Primera 1999 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.4;
                    maxspeed = 112;
                    grip = 75;
                    weight = 1170;
                    break;
                case 937:
                    DoLog("Nissan Patrol 1987 e10");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 15.5;
                    maxspeed = 80;
                    grip = 66;
                    weight = 1660;
                    break;
                case 938:
                    DoLog("Nissan Almera 1998 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.2;
                    maxspeed = 107;
                    grip = 75;
                    weight = 1045;
                    break;
                case 939:
                    DoLog("Nissan Figaro 1991 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.2;
                    maxspeed = 92;
                    grip = 71;
                    weight = 810;
                    break;
                case 940:
                    DoLog("Nissan Note 2006 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.1;
                    maxspeed = 103;
                    grip = 74;
                    weight = 1092;
                    break;
                case 941:
                    DoLog("Nissan Micra 2004 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 15.5;
                    maxspeed = 93;
                    grip = 74;
                    weight = 780;
                    break;
                case 942:
                    DoLog("Nissan Micra 1991 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.9;
                    maxspeed = 89;
                    grip = 70;
                    weight = 675;
                    break;
                case 943:
                    DoLog("Nissan Micra 2011 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 14.8;
                    maxspeed = 96;
                    grip = 75;
                    weight = 940;
                    break;
                case 944:
                    DoLog("Nissan Pulsar 1986 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 14.9;
                    maxspeed = 91;
                    grip = 73;
                    weight = 870;
                    break;
                case 945:
                    DoLog("Nissan Pulsar 1982 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.9;
                    maxspeed = 98;
                    grip = 72;
                    weight = 755;
                    break;
                case 946:
                    DoLog("Nissan Pulsar 1978 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.6;
                    maxspeed = 96;
                    grip = 71;
                    weight = 870;
                    break;
                case 947:
                    DoLog("Nissan Pixo 2009 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.2;
                    maxspeed = 96;
                    grip = 76;
                    weight = 885;
                    break;
                case 948:
                    DoLog("Nissan Micra 2016 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13;
                    maxspeed = 106;
                    grip = 75;
                    weight = 910;
                    break;
                case 949:
                    DoLog("Nissan GT-R Nismo 2016 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 2.8;
                    maxspeed = 196;
                    grip = 87;
                    weight = 1762;
                    break;
                case 950:
                    DoLog("Nissan GT-R 2014 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 2.7;
                    maxspeed = 196;
                    grip = 86;
                    weight = 1779;
                    break;
                case 951:
                    DoLog("Nissan Juke-R 2011 s29");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.5;
                    maxspeed = 160;
                    grip = 86;
                    weight = 1806;
                    break;
                case 952:
                    DoLog("Nissan R390 GT1 Road Car 1998 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 215;
                    grip = 90;
                    weight = 1098;
                    break;
                case 953:
                    DoLog("Pagani Huayra 2016 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.2;
                    maxspeed = 224;
                    grip = 92;
                    weight = 1350;
                    break;
                case 954:
                    DoLog("Pagani Zonda 760RS 2012 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.8;
                    maxspeed = 217;
                    grip = 91;
                    weight = 1280;
                    break;
                case 955:
                    DoLog("Pagani Zonda Cinque Roadster 2009 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.3;
                    maxspeed = 225;
                    grip = 90;
                    weight = 1210;
                    break;
                case 956:
                    DoLog("Pagani Zonda F 2005 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.4;
                    maxspeed = 220;
                    grip = 89;
                    weight = 1230;
                    break;
                case 957:
                    DoLog("Pagani Zonda S 7.3 2002 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.5;
                    maxspeed = 220;
                    grip = 88;
                    weight = 1250;
                    break;
                case 958:
                    DoLog("Peugeot 3008 DKR 2017 a25");
                    clearance = 3;
                    tires = 5;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 124;
                    grip = 76;
                    weight = 950;
                    break;
                case 959:
                    DoLog("Peugeot 208 GTi 2018 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.2;
                    maxspeed = 143;
                    grip = 83;
                    weight = 1185;
                    break;
                case 960:
                    DoLog("Peugeot 205 T16 1984 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.7;
                    maxspeed = 130;
                    grip = 81;
                    weight = 1145;
                    break;
                case 961:
                    DoLog("Peugeot 308 GTi 2018 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.7;
                    maxspeed = 155;
                    grip = 81;
                    weight = 1205;
                    break;
                case 962:
                    DoLog("Peugeot RCZ R 2013 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.9;
                    maxspeed = 155;
                    grip = 83;
                    weight = 1280;
                    break;
                case 963:
                    DoLog("Peugeot 205 GTi 1.9 1986 d11");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.6;
                    maxspeed = 123;
                    grip = 75;
                    weight = 875;
                    break;
                case 964:
                    DoLog("Peugeot 306 GTi-6 1996 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.9;
                    maxspeed = 130;
                    grip = 79;
                    weight = 1214;
                    break;
                case 965:
                    DoLog("Peugeot 407 Coupe 2006 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8;
                    maxspeed = 143;
                    grip = 72;
                    weight = 1724;
                    break;
                case 966:
                    DoLog("Peugeot 605 1989 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.4;
                    maxspeed = 146;
                    grip = 69;
                    weight = 1475;
                    break;
                case 967:
                    DoLog("Peugeot 306 Rallye 1998 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.8;
                    maxspeed = 130;
                    grip = 79;
                    weight = 1163;
                    break;
                case 968:
                    DoLog("Peugeot 508 2018 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 6.8;
                    maxspeed = 143;
                    grip = 70;
                    weight = 1530;
                    break;
                case 969:
                    DoLog("Peugeot 607 1999 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 6.7;
                    maxspeed = 149;
                    grip = 70;
                    weight = 1560;
                    break;
                case 970:
                    DoLog("Peugeot 504 Coupe 1968 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 10;
                    maxspeed = 116;
                    grip = 67;
                    weight = 1270;
                    break;
                case 971:
                    DoLog("Peugeot 106 Rallye (S1) 1993 e8");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 9.3;
                    maxspeed = 116;
                    grip = 77;
                    weight = 810;
                    break;
                case 972:
                    DoLog("Peugeot 2008 2018 e9");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.6;
                    maxspeed = 112;
                    grip = 68;
                    weight = 1155;
                    break;
                case 973:
                    DoLog("Peugeot 205 Rallye 1988 e8");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 9.1;
                    maxspeed = 118;
                    grip = 75;
                    weight = 790;
                    break;
                case 974:
                    DoLog("Peugeot 3008 2018 e8");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 9;
                    maxspeed = 117;
                    grip = 67;
                    weight = 1320;
                    break;
                case 975:
                    DoLog("Peugeot 308 2018 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.3;
                    maxspeed = 127;
                    grip = 69;
                    weight = 1204;
                    break;
                case 976:
                    DoLog("Peugeot 205 GTi 1.6 1984 e9");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.6;
                    maxspeed = 120;
                    grip = 74;
                    weight = 850;
                    break;
                case 977:
                    DoLog("Peugeot 5008 2018 e9");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.6;
                    maxspeed = 128;
                    grip = 68;
                    weight = 1440;
                    break;
                case 978:
                    DoLog("Peugeot 106 Rallye (S2) 1997 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.5;
                    maxspeed = 121;
                    grip = 77;
                    weight = 865;
                    break;
                case 979:
                    DoLog("Peugeot 206 CC 2000 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.5;
                    maxspeed = 127;
                    grip = 69;
                    weight = 1227;
                    break;
                case 980:
                    DoLog("Peugeot 309 GTi 1986 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.4;
                    maxspeed = 128;
                    grip = 74;
                    weight = 930;
                    break;
                case 981:
                    DoLog("Peugeot 406 Coupe 1997 e10");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.5;
                    maxspeed = 146;
                    grip = 75;
                    weight = 1450;
                    break;
                case 982:
                    DoLog("Peugeot 405 Mi16 1987 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.2;
                    maxspeed = 137;
                    grip = 74;
                    weight = 1108;
                    break;
                case 983:
                    DoLog("Peugeot 204 Coupe 1965 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 18.2;
                    maxspeed = 91;
                    grip = 63;
                    weight = 838;
                    break;
                case 984:
                    DoLog("Peugeot 404 Coupe 1960 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 12.1;
                    maxspeed = 100;
                    grip = 62;
                    weight = 1075;
                    break;
                case 985:
                    DoLog("Peugeot 505 Break 1982 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 12.5;
                    maxspeed = 101;
                    grip = 65;
                    weight = 1270;
                    break;
                case 986:
                    DoLog("Peugeot 108 2018 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.5;
                    maxspeed = 99;
                    grip = 68;
                    weight = 915;
                    break;
                case 987:
                    DoLog("Peugeot 208 2018 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.8;
                    maxspeed = 109;
                    grip = 70;
                    weight = 975;
                    break;
                case 988:
                    DoLog("Peugeot iOn 2018 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 15.4;
                    maxspeed = 81;
                    grip = 66;
                    weight = 1120;
                    break;
                case 989:
                    DoLog("Peugeot 405 T16 Pikes Peak 1988 s27");
                    clearance = 1;
                    tires = 4;
                    drive = 4;
                    acceleration = 2.8;
                    maxspeed = 120;
                    grip = 89;
                    weight = 880;
                    break;
                case 990:
                    DoLog("Plymouth Superbird 1970 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.8;
                    maxspeed = 185;
                    grip = 68;
                    weight = 1742;
                    break;
                case 991:
                    DoLog("Plymouth HEMI 'Cuda 1970 c15");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 6;
                    maxspeed = 145;
                    grip = 68;
                    weight = 1720;
                    break;
                case 992:
                    DoLog("Plymouth Barracuda Fastback 1968 d14");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.3;
                    maxspeed = 140;
                    grip = 68;
                    weight = 1472;
                    break;
                case 993:
                    DoLog("Plymouth Roadrunner 383 1968 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.1;
                    maxspeed = 140;
                    grip = 66;
                    weight = 1558;
                    break;
                case 994:
                    DoLog("Plymouth Duster 340 1972 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.2;
                    maxspeed = 129;
                    grip = 66;
                    weight = 1445;
                    break;
                case 995:
                    DoLog("Plymouth Fury 1958 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.8;
                    maxspeed = 127;
                    grip = 65;
                    weight = 1656;
                    break;
                case 996:
                    DoLog("Plymouth GTX 1968 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.3;
                    maxspeed = 123;
                    grip = 57;
                    weight = 1715;
                    break;
                case 997:
                    DoLog("Plymouth Reliant 1981 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.9;
                    maxspeed = 104;
                    grip = 55;
                    weight = 1087;
                    break;
                case 998:
                    DoLog("Plymouth Scamp 1982 f6");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.9;
                    maxspeed = 103;
                    grip = 61;
                    weight = 1061;
                    break;
                case 999:
                    DoLog("Pontiac G8 GXP 2010 a25");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 175;
                    grip = 82;
                    weight = 1825;
                    break;
                case 1000:
                    DoLog("Pontiac Solstice GXP Coupe 2009 b19");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.4;
                    maxspeed = 142;
                    grip = 83;
                    weight = 1369;
                    break;
                case 1001:
                    DoLog("Pontiac Trans Am 35th Anniversary 2002 b19");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.1;
                    maxspeed = 163;
                    grip = 79;
                    weight = 1541;
                    break;
                case 1002:
                    DoLog("Pontiac Trans Am 30th Anniversary 1999 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.3;
                    maxspeed = 163;
                    grip = 78;
                    weight = 1541;
                    break;
                case 1003:
                    DoLog("Pontiac GTO 2006 b21");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.8;
                    maxspeed = 158;
                    grip = 80;
                    weight = 1690;
                    break;
                case 1004:
                    DoLog("Pontiac Torrent GXP 2008 b22");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7;
                    maxspeed = 125;
                    grip = 76;
                    weight = 1842;
                    break;
                case 1005:
                    DoLog("Pontiac Bonneville Special 1954 c15");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 6.4;
                    maxspeed = 130;
                    grip = 70;
                    weight = 1981;
                    break;
                case 1006:
                    DoLog("Pontiac Grand Prix GTP 1997 c16");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 6.6;
                    maxspeed = 126;
                    grip = 75;
                    weight = 1588;
                    break;
                case 1007:
                    DoLog("Pontiac Grand Prix GXP 2006 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.7;
                    maxspeed = 143;
                    grip = 78;
                    weight = 1647;
                    break;
                case 1008:
                    DoLog("Pontiac G6 2005 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.2;
                    maxspeed = 130;
                    grip = 75;
                    weight = 1554;
                    break;
                case 1009:
                    DoLog("Pontiac Trans Am 20th Anniversary 1989 d12");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.5;
                    maxspeed = 140;
                    grip = 70;
                    weight = 1518;
                    break;
                case 1010:
                    DoLog("Pontiac Fiero GT 1988 d13");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.5;
                    maxspeed = 135;
                    grip = 79;
                    weight = 1212;
                    break;
                case 1011:
                    DoLog("Pontiac Firebird Trans Am 1970 d13");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.6;
                    maxspeed = 152;
                    grip = 62;
                    weight = 1663;
                    break;
                case 1012:
                    DoLog("Pontiac GTO Judge Ram Air IV 1970 d13");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.1;
                    maxspeed = 135;
                    grip = 70;
                    weight = 1715;
                    break;
                case 1013:
                    DoLog("Pontiac Vibe GT 2003 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.6;
                    maxspeed = 121;
                    grip = 74;
                    weight = 1270;
                    break;
                case 1014:
                    DoLog("Pontiac Bonneville SSEi 2000 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.5;
                    maxspeed = 126;
                    grip = 75;
                    weight = 1719;
                    break;
                case 1015:
                    DoLog("Pontiac Grand Am GT 1992 d13");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7;
                    maxspeed = 130;
                    grip = 78;
                    weight = 1237;
                    break;
                case 1016:
                    DoLog("Pontiac Fiero 1984 e7");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 11.2;
                    maxspeed = 105;
                    grip = 76;
                    weight = 1136;
                    break;
                case 1017:
                    DoLog("Pontiac Sunbird GT 1986 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.8;
                    maxspeed = 115;
                    grip = 70;
                    weight = 1225;
                    break;
                case 1018:
                    DoLog("Pontiac Aztek 2001 e9");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.4;
                    maxspeed = 108;
                    grip = 73;
                    weight = 1714;
                    break;
                case 1019:
                    DoLog("Pontiac Grand Prix 2+2 1986 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.7;
                    maxspeed = 109;
                    grip = 73;
                    weight = 1456;
                    break;
                case 1020:
                    DoLog("Pontiac Montana 2005 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.9;
                    maxspeed = 115;
                    grip = 70;
                    weight = 1725;
                    break;
                case 1021:
                    DoLog("Pontiac Trans Am 1978 e8");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.9;
                    maxspeed = 128;
                    grip = 66;
                    weight = 1640;
                    break;
                case 1022:
                    DoLog("Pontiac Grand Am 1985 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.6;
                    maxspeed = 112;
                    grip = 78;
                    weight = 1406;
                    break;
                case 1023:
                    DoLog("Pontiac Sunfire 1995 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.1;
                    maxspeed = 112;
                    grip = 76;
                    weight = 1257;
                    break;
                case 1024:
                    DoLog("Pontiac Firebird Trans Am 1985 f4");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 11.5;
                    maxspeed = 100;
                    grip = 76;
                    weight = 1301;
                    break;
                case 1025:
                    DoLog("Pontiac 6000 STE AWD 1988 f6");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 11;
                    maxspeed = 110;
                    grip = 72;
                    weight = 1497;
                    break;
                case 1026:
                    DoLog("Pontiac Tempest Le Mans GTO 1965 f6");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 10;
                    maxspeed = 113;
                    grip = 73;
                    weight = 1551;
                    break;
                case 1027:
                    DoLog("Porsche 911 Carrera S 2015 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.1;
                    maxspeed = 191;
                    grip = 89;
                    weight = 1440;
                    break;
                case 1028:
                    DoLog("Porsche 911 GT2 2001 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 196;
                    grip = 87;
                    weight = 1440;
                    break;
                case 1029:
                    DoLog("Porsche 911 GT3 RS 2006 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4;
                    maxspeed = 193;
                    grip = 90;
                    weight = 1375;
                    break;
                case 1030:
                    DoLog("Porsche 911 Turbo 1995 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.3;
                    maxspeed = 180;
                    grip = 85;
                    weight = 1500;
                    break;
                case 1031:
                    DoLog("Porsche 911 Carrera GTS 2016 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.2;
                    maxspeed = 190;
                    grip = 88;
                    weight = 1425;
                    break;
                case 1032:
                    DoLog("Porsche 911 GT3 2006 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.1;
                    maxspeed = 193;
                    grip = 89;
                    weight = 1395;
                    break;
                case 1033:
                    DoLog("Porsche 911 Targa 4S 2015 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.6;
                    maxspeed = 184;
                    grip = 86;
                    weight = 1555;
                    break;
                case 1034:
                    DoLog("Porsche Cayenne Turbo 2002 a26");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5.3;
                    maxspeed = 165;
                    grip = 80;
                    weight = 2355;
                    break;
                case 1035:
                    DoLog("Porsche 718 Boxster S 2017 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 177;
                    grip = 85;
                    weight = 1355;
                    break;
                case 1036:
                    DoLog("Porsche 911 GT3 RS 2004 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.2;
                    maxspeed = 190;
                    grip = 88;
                    weight = 1360;
                    break;
                case 1037:
                    DoLog("Porsche 911 Targa 4S 2004 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.7;
                    maxspeed = 179;
                    grip = 85;
                    weight = 1535;
                    break;
                case 1038:
                    DoLog("Porsche Boxster Spyder 2016 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.3;
                    maxspeed = 180;
                    grip = 86;
                    weight = 1315;
                    break;
                case 1039:
                    DoLog("Porsche Cayman GT4 2015 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.2;
                    maxspeed = 183;
                    grip = 87;
                    weight = 1415;
                    break;
                case 1040:
                    DoLog("Porsche 911 Carrera 4 2000 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 5;
                    maxspeed = 174;
                    grip = 84;
                    weight = 1375;
                    break;
                case 1041:
                    DoLog("Porsche 911 Carrera S Cabriolet 2016 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 187;
                    grip = 86;
                    weight = 1465;
                    break;
                case 1042:
                    DoLog("Porsche 911 Carrera RSR 3.0 1974 a24");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 179;
                    grip = 89;
                    weight = 900;
                    break;
                case 1043:
                    DoLog("Porsche 911 Carrera 2016 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.6;
                    maxspeed = 180;
                    grip = 87;
                    weight = 1455;
                    break;
                case 1044:
                    DoLog("Porsche 911 GT3 1999 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.6;
                    maxspeed = 188;
                    grip = 86;
                    weight = 1350;
                    break;
                case 1045:
                    DoLog("Porsche Boxster GTS 2015 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.8;
                    maxspeed = 175;
                    grip = 85;
                    weight = 1345;
                    break;
                case 1046:
                    DoLog("Porsche Boxster S 2015 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.9;
                    maxspeed = 173;
                    grip = 85;
                    weight = 1320;
                    break;
                case 1047:
                    DoLog("Porsche 911 Carrera S 2004 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 182;
                    grip = 86;
                    weight = 1495;
                    break;
                case 1048:
                    DoLog("Porsche 911 Turbo 1990 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 174;
                    grip = 83;
                    weight = 1470;
                    break;
                case 1049:
                    DoLog("Porsche 911 Carrera 2004 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.8;
                    maxspeed = 177;
                    grip = 85;
                    weight = 1470;
                    break;
                case 1050:
                    DoLog("Porsche Boxster Spyder 2009 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.7;
                    maxspeed = 166;
                    grip = 84;
                    weight = 1350;
                    break;
                case 1051:
                    DoLog("Porsche 718 Boxster 2017 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.9;
                    maxspeed = 171;
                    grip = 85;
                    weight = 1335;
                    break;
                case 1052:
                    DoLog("Porsche 718 Cayman 2016 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.9;
                    maxspeed = 171;
                    grip = 85;
                    weight = 1335;
                    break;
                case 1053:
                    DoLog("Porsche 911 RS 1992 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.1;
                    maxspeed = 161;
                    grip = 84;
                    weight = 1220;
                    break;
                case 1054:
                    DoLog("Porsche 911 Turbo Martini 1978 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.2;
                    maxspeed = 161;
                    grip = 83;
                    weight = 1300;
                    break;
                case 1055:
                    DoLog("Porsche Cayman 2012 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.5;
                    maxspeed = 165;
                    grip = 85;
                    weight = 1310;
                    break;
                case 1056:
                    DoLog("Porsche 911 Carrera 4 1989 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.4;
                    maxspeed = 161;
                    grip = 82;
                    weight = 1450;
                    break;
                case 1057:
                    DoLog("Porsche Cayman 2009 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.6;
                    maxspeed = 165;
                    grip = 84;
                    weight = 1330;
                    break;
                case 1058:
                    DoLog("Porsche 911 Carrera Cabriolet 2000 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.2;
                    maxspeed = 174;
                    grip = 83;
                    weight = 1395;
                    break;
                case 1059:
                    DoLog("Porsche 911 Turbo 1975 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.3;
                    maxspeed = 155;
                    grip = 81;
                    weight = 1140;
                    break;
                case 1060:
                    DoLog("Porsche Boxster 2015 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.6;
                    maxspeed = 164;
                    grip = 84;
                    weight = 1410;
                    break;
                case 1061:
                    DoLog("Porsche 924 Carrera GTS Rally Spec 1981 b21");
                    clearance = 1;
                    tires = 5;
                    drive = 2;
                    acceleration = 5.8;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1120;
                    break;
                case 1062:
                    DoLog("Porsche 911 Carrera 1994 b20");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.4;
                    maxspeed = 167;
                    grip = 82;
                    weight = 1370;
                    break;
                case 1063:
                    DoLog("Porsche 911 Carrera 2 Targa 1989 b20");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.4;
                    maxspeed = 161;
                    grip = 82;
                    weight = 1350;
                    break;
                case 1064:
                    DoLog("Porsche 911 Carrera 2.7 RS 1973 b21");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.6;
                    maxspeed = 152;
                    grip = 80;
                    weight = 960;
                    break;
                case 1065:
                    DoLog("Porsche Cayman 2005 b19");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.8;
                    maxspeed = 162;
                    grip = 83;
                    weight = 1300;
                    break;
                case 1066:
                    DoLog("Porsche 968 Turbo S 1993 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.8;
                    maxspeed = 174;
                    grip = 83;
                    weight = 1300;
                    break;
                case 1067:
                    DoLog("Porsche Cayman GTS 2014 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.7;
                    maxspeed = 177;
                    grip = 85;
                    weight = 1345;
                    break;
                case 1068:
                    DoLog("Porsche Boxster 2005 c18");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.9;
                    maxspeed = 159;
                    grip = 82;
                    weight = 1370;
                    break;
                case 1069:
                    DoLog("Porsche 924 Carrera GTS 1981 c17");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.9;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1121;
                    break;
                case 1070:
                    DoLog("Porsche 968 1992 c16");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.2;
                    maxspeed = 157;
                    grip = 79;
                    weight = 1370;
                    break;
                case 1071:
                    DoLog("Porsche 968 Clubsport 1993 c17");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.2;
                    maxspeed = 157;
                    grip = 81;
                    weight = 1320;
                    break;
                case 1072:
                    DoLog("Porsche Boxster 1996 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.6;
                    maxspeed = 149;
                    grip = 81;
                    weight = 1250;
                    break;
                case 1073:
                    DoLog("Porsche 924 Turbo 1979 c16");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.3;
                    maxspeed = 143;
                    grip = 76;
                    weight = 1180;
                    break;
                case 1074:
                    DoLog("Porsche 928 S 1980 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.3;
                    maxspeed = 155;
                    grip = 76;
                    weight = 1450;
                    break;
                case 1075:
                    DoLog("Porsche 911S 2.7 1973 c17");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.3;
                    maxspeed = 140;
                    grip = 75;
                    weight = 1075;
                    break;
                case 1076:
                    DoLog("Porsche 928 1977 d14");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.6;
                    maxspeed = 143;
                    grip = 75;
                    weight = 1450;
                    break;
                case 1077:
                    DoLog("Porsche 911S 2.4 Targa 1972 d13");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.7;
                    maxspeed = 140;
                    grip = 73;
                    weight = 1090;
                    break;
                case 1078:
                    DoLog("Porsche 944 1982 d11");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 8;
                    maxspeed = 137;
                    grip = 75;
                    weight = 1180;
                    break;
                case 1079:
                    DoLog("Porsche 550 Spyder 1955 d14");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 7;
                    maxspeed = 140;
                    grip = 75;
                    weight = 550;
                    break;
                case 1080:
                    DoLog("Porsche 924 1976 e10");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.1;
                    maxspeed = 124;
                    grip = 74;
                    weight = 1080;
                    break;
                case 1081:
                    DoLog("Porsche 911 1965 e8");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.7;
                    maxspeed = 130;
                    grip = 65;
                    weight = 1080;
                    break;
                case 1082:
                    DoLog("Porsche 914 1969 e7");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 12.3;
                    maxspeed = 110;
                    grip = 72;
                    weight = 900;
                    break;
                case 1083:
                    DoLog("Porsche 356 Speedster 1955 f4");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 16.1;
                    maxspeed = 99;
                    grip = 67;
                    weight = 760;
                    break;
                case 1084:
                    DoLog("Porsche 356 1955 f3");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 20.8;
                    maxspeed = 90;
                    grip = 60;
                    weight = 850;
                    break;
                case 1085:
                    DoLog("Porsche 356 1948 f3");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 23;
                    maxspeed = 84;
                    grip = 60;
                    weight = 585;
                    break;
                case 1086:
                    DoLog("Porsche 356 B Convertible 1600 1965 f3");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 16.5;
                    maxspeed = 96;
                    grip = 62;
                    weight = 935;
                    break;
                case 1087:
                    DoLog("Porsche 911 GT1 race car 1997 s27");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 3.1;
                    maxspeed = 205;
                    grip = 95;
                    weight = 1180;
                    break;
                case 1088:
                    DoLog("Porsche 911 Turbo 2013 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.2;
                    maxspeed = 196;
                    grip = 90;
                    weight = 1670;
                    break;
                case 1089:
                    DoLog("Porsche 911 Turbo S 2013 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3;
                    maxspeed = 198;
                    grip = 90;
                    weight = 1680;
                    break;
                case 1090:
                    DoLog("Porsche 918 Spyder 2013 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 2.5;
                    maxspeed = 211;
                    grip = 94;
                    weight = 1640;
                    break;
                case 1091:
                    DoLog("Porsche 911 Turbo 2006 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.5;
                    maxspeed = 193;
                    grip = 88;
                    weight = 1585;
                    break;
                case 1092:
                    DoLog("Porsche Macan Turbo Performance Pack 2017 s29");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 4.2;
                    maxspeed = 169;
                    grip = 83;
                    weight = 1895;
                    break;
                case 1093:
                    DoLog("Porsche Macan Turbo 2016 s28");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 4.4;
                    maxspeed = 165;
                    grip = 83;
                    weight = 1925;
                    break;
                case 1094:
                    DoLog("Porsche Panamera Turbo 2017 s28");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.6;
                    maxspeed = 190;
                    grip = 82;
                    weight = 1995;
                    break;
                case 1095:
                    DoLog("Porsche 911 GT2 RS 2018 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.7;
                    maxspeed = 211;
                    grip = 93;
                    weight = 1545;
                    break;
                case 1096:
                    DoLog("Porsche 911 GT2 RS 2007 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.4;
                    maxspeed = 205;
                    grip = 91;
                    weight = 1370;
                    break;
                case 1097:
                    DoLog("Porsche 911 GT3 2013 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.4;
                    maxspeed = 196;
                    grip = 92;
                    weight = 1430;
                    break;
                case 1098:
                    DoLog("Porsche 911 GT3 RS 2015 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.2;
                    maxspeed = 193;
                    grip = 92;
                    weight = 1420;
                    break;
                case 1099:
                    DoLog("Porsche Carrera GT 2003 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.7;
                    maxspeed = 205;
                    grip = 92;
                    weight = 1380;
                    break;
                case 1100:
                    DoLog("Porsche 911 GT1 road car 1997 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.5;
                    maxspeed = 193;
                    grip = 91;
                    weight = 1250;
                    break;
                case 1101:
                    DoLog("Porsche 911 R 2016 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.6;
                    maxspeed = 201;
                    grip = 92;
                    weight = 1370;
                    break;
                case 1102:
                    DoLog("Porsche Cayenne Turbo 2017 s28");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 4.5;
                    maxspeed = 173;
                    grip = 81;
                    weight = 2170;
                    break;
                case 1103:
                    DoLog("Porsche Macan GTS 2015 s27");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 4.8;
                    maxspeed = 159;
                    grip = 83;
                    weight = 1895;
                    break;
                case 1104:
                    DoLog("Porsche Cayenne GTS 2014 s27");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5;
                    maxspeed = 163;
                    grip = 81;
                    weight = 2110;
                    break;
                case 1105:
                    DoLog("Porsche 911 GT3 RS 2018 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.1;
                    maxspeed = 193;
                    grip = 93;
                    weight = 1505;
                    break;
                case 1106:
                    DoLog("Porsche 959 1986 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.6;
                    maxspeed = 196;
                    grip = 83;
                    weight = 1450;
                    break;
                case 1107:
                    DoLog("Porsche 911 GT2 2007 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.4;
                    maxspeed = 204;
                    grip = 89;
                    weight = 1440;
                    break;
                case 1108:
                    DoLog("Porsche 911 GT3 RS 4.0 2011 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.7;
                    maxspeed = 193;
                    grip = 91;
                    weight = 1435;
                    break;
                case 1109:
                    DoLog("Porsche 911 Targa 4S 2016 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.2;
                    maxspeed = 188;
                    grip = 87;
                    weight = 1580;
                    break;
                case 1110:
                    DoLog("Porsche 911 Turbo 2001 s27");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 4;
                    maxspeed = 190;
                    grip = 86;
                    weight = 1540;
                    break;
                case 1111:
                    DoLog("Porsche 959 Dakar 1986 s28");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 3.3;
                    maxspeed = 130;
                    grip = 80;
                    weight = 1320;
                    break;
                case 1112:
                    DoLog("Porsche Panamera Turbo 2010 s27");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4;
                    maxspeed = 188;
                    grip = 81;
                    weight = 1970;
                    break;
                case 1113:
                    DoLog("Porsche 917 1970 s27");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 3.2;
                    maxspeed = 220;
                    grip = 90;
                    weight = 800;
                    break;
                case 1114:
                    DoLog("Porsche 935 'Moby Dick' 1978 s28");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 2.6;
                    maxspeed = 227;
                    grip = 91;
                    weight = 1025;
                    break;
                case 1115:
                    DoLog("Porsche 962 C 1985 s28");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 2.8;
                    maxspeed = 211;
                    grip = 95;
                    weight = 900;
                    break;
                case 1116:
                    DoLog("Ram 1500 Rebel 2019 b21");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 6.5;
                    maxspeed = 110;
                    grip = 63;
                    weight = 2010;
                    break;
                case 1117:
                    DoLog("Ram Dodge Ramcharger 1974 c15");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 9.4;
                    maxspeed = 104;
                    grip = 59;
                    weight = 1920;
                    break;
                case 1118:
                    DoLog("Ram Dodge Ramcharger 1981 c16");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 10.5;
                    maxspeed = 104;
                    grip = 62;
                    weight = 2075;
                    break;
                case 1119:
                    DoLog("Ram 1st Gen 1981 d13");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 11.5;
                    maxspeed = 97;
                    grip = 58;
                    weight = 1980;
                    break;
                case 1120:
                    DoLog("Ram Dodge Li'l Red Express Truck 1978 d11");
                    clearance = 3;
                    tires = 4;
                    drive = 2;
                    acceleration = 6.6;
                    maxspeed = 118;
                    grip = 58;
                    weight = 1730;
                    break;
                case 1121:
                    DoLog("Renault R5 MAXI TURBO 1987 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.1;
                    maxspeed = 145;
                    grip = 84;
                    weight = 990;
                    break;
                case 1122:
                    DoLog("Renault Sport Laguna BTCC 1999 a23");
                    clearance = 1;
                    tires = 1;
                    drive = 1;
                    acceleration = 4.5;
                    maxspeed = 160;
                    grip = 92;
                    weight = 975;
                    break;
                case 1123:
                    DoLog("Renault Sport Megane Trophy 2009 a25");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 3.7;
                    maxspeed = 175;
                    grip = 89;
                    weight = 955;
                    break;
                case 1124:
                    DoLog("Renault Trezor 2016 a25");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.9;
                    maxspeed = 155;
                    grip = 84;
                    weight = 1600;
                    break;
                case 1125:
                    DoLog("Renault Sport R.S. 01 2015 a26");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 3.5;
                    maxspeed = 186;
                    grip = 90;
                    weight = 1145;
                    break;
                case 1126:
                    DoLog("Renault Alpine A310 V6 Turbo 1983 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 155;
                    grip = 82;
                    weight = 1180;
                    break;
                case 1127:
                    DoLog("Renault Sport Megane 275 Trophy-R 2016 b21");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.5;
                    maxspeed = 158;
                    grip = 88;
                    weight = 1297;
                    break;
                case 1128:
                    DoLog("Renault Sport Megane R26.R 2008 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.7;
                    maxspeed = 147;
                    grip = 87;
                    weight = 1252;
                    break;
                case 1129:
                    DoLog("Renault Sport Clio 220 Trophy 2016 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.4;
                    maxspeed = 143;
                    grip = 85;
                    weight = 1204;
                    break;
                case 1130:
                    DoLog("Renault Sport Clio Cup Car 2014 b19");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6;
                    maxspeed = 145;
                    grip = 88;
                    weight = 1065;
                    break;
                case 1131:
                    DoLog("Renault Sport Clio R.S. 16 2008 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.2;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1200;
                    break;
                case 1132:
                    DoLog("Renault Sport Clio 200 2009 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.7;
                    maxspeed = 134;
                    grip = 85;
                    weight = 1240;
                    break;
                case 1133:
                    DoLog("Renault Sport Megane 2002 c18");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.2;
                    maxspeed = 147;
                    grip = 84;
                    weight = 1375;
                    break;
                case 1134:
                    DoLog("Renault Sport Clio V6 2003 c17");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6;
                    maxspeed = 144;
                    grip = 82;
                    weight = 1400;
                    break;
                case 1135:
                    DoLog("Renault Sport Clio 182 Trophy 2005 c16");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.1;
                    maxspeed = 138;
                    grip = 84;
                    weight = 1090;
                    break;
                case 1136:
                    DoLog("Renault Alpine GTA V6 Turbo Le Mans 1990 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.8;
                    maxspeed = 146;
                    grip = 78;
                    weight = 1210;
                    break;
                case 1137:
                    DoLog("Renault Sport Clio 172 Cup 1999 c15");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.1;
                    maxspeed = 137;
                    grip = 81;
                    weight = 1059;
                    break;
                case 1138:
                    DoLog("Renault Alpine A110 1971 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.3;
                    maxspeed = 127;
                    grip = 76;
                    weight = 625;
                    break;
                case 1139:
                    DoLog("Renault 5 Turbo 1980 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.3;
                    maxspeed = 130;
                    grip = 76;
                    weight = 970;
                    break;
                case 1140:
                    DoLog("Renault Sport Clio V6 2001 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.6;
                    maxspeed = 145;
                    grip = 80;
                    weight = 1410;
                    break;
                case 1141:
                    DoLog("Renault R21 Turbo Europa Cup 1988 c17");
                    clearance = 1;
                    tires = 1;
                    drive = 1;
                    acceleration = 5.8;
                    maxspeed = 160;
                    grip = 85;
                    weight = 1050;
                    break;
                case 1142:
                    DoLog("Renault DeZir 2010 c18");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5;
                    maxspeed = 112;
                    grip = 86;
                    weight = 830;
                    break;
                case 1143:
                    DoLog("Renault R20 Turbo 4x4 1979 c18");
                    clearance = 3;
                    tires = 5;
                    drive = 4;
                    acceleration = 8.6;
                    maxspeed = 130;
                    grip = 66;
                    weight = 1200;
                    break;
                case 1144:
                    DoLog("Renault Sport Megane IV R.S. 2018 c18");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.3;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1407;
                    break;
                case 1145:
                    DoLog("Renault Kadjar 2016 d12");
                    clearance = 3;
                    tires = 4;
                    drive = 1;
                    acceleration = 11.3;
                    maxspeed = 113;
                    grip = 73;
                    weight = 1395;
                    break;
                case 1146:
                    DoLog("Renault Safrane Biturbo 1992 d13");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 7.2;
                    maxspeed = 155;
                    grip = 71;
                    weight = 1724;
                    break;
                case 1147:
                    DoLog("Renault 21 2.0l Turbo Quadra 1986 d13");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 7.8;
                    maxspeed = 138;
                    grip = 75;
                    weight = 1345;
                    break;
                case 1148:
                    DoLog("Renault Megane 1995 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.1;
                    maxspeed = 140;
                    grip = 74;
                    weight = 1170;
                    break;
                case 1149:
                    DoLog("Renault 19 16S 1988 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.4;
                    maxspeed = 140;
                    grip = 73;
                    weight = 1060;
                    break;
                case 1150:
                    DoLog("Renault 25 V6 Turbo 1983 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.3;
                    maxspeed = 137;
                    grip = 71;
                    weight = 1340;
                    break;
                case 1151:
                    DoLog("Renault Sport Twingo 133 Cup 2008 d11");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.3;
                    maxspeed = 125;
                    grip = 75;
                    weight = 1049;
                    break;
                case 1152:
                    DoLog("Renault Espace 2016 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.2;
                    maxspeed = 131;
                    grip = 70;
                    weight = 1609;
                    break;
                case 1153:
                    DoLog("Renault Wind 2010 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.8;
                    maxspeed = 125;
                    grip = 73;
                    weight = 1173;
                    break;
                case 1154:
                    DoLog("Renault Avantime 3.0 V6 2012 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.6;
                    maxspeed = 137;
                    grip = 68;
                    weight = 1741;
                    break;
                case 1155:
                    DoLog("Renault 5 GT Turbo 1985 d11");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.1;
                    maxspeed = 123;
                    grip = 75;
                    weight = 820;
                    break;
                case 1156:
                    DoLog("Renault Koleos 2008 d13");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 9.4;
                    maxspeed = 117;
                    grip = 65;
                    weight = 1655;
                    break;
                case 1157:
                    DoLog("Renault Fluence 2013 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 6.8;
                    maxspeed = 137;
                    grip = 69;
                    weight = 1341;
                    break;
                case 1158:
                    DoLog("Renault Laguna Coupe 2010 d14");
                    clearance = 1;
                    tires = 3;
                    drive = 1;
                    acceleration = 7;
                    maxspeed = 130;
                    grip = 75;
                    weight = 1522;
                    break;
                case 1159:
                    DoLog("Renault Talisman 2015 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7;
                    maxspeed = 147;
                    grip = 69;
                    weight = 1430;
                    break;
                case 1160:
                    DoLog("Renault 3.5l V6 Espace MK4 2002 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 6.1;
                    maxspeed = 140;
                    grip = 67;
                    weight = 1770;
                    break;
                case 1161:
                    DoLog("Renault Alaskan 2015 d14");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 9.7;
                    maxspeed = 112;
                    grip = 62;
                    weight = 1950;
                    break;
                case 1162:
                    DoLog("Renault Sport Spider 1996 d14");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.2;
                    maxspeed = 131;
                    grip = 80;
                    weight = 930;
                    break;
                case 1163:
                    DoLog("Renault Captur 2016 e8");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.2;
                    maxspeed = 106;
                    grip = 72;
                    weight = 1101;
                    break;
                case 1164:
                    DoLog("Renault Laguna 1994 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11;
                    maxspeed = 121;
                    grip = 69;
                    weight = 1305;
                    break;
                case 1165:
                    DoLog("Renault Laguna 2007 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.5;
                    maxspeed = 119;
                    grip = 72;
                    weight = 1386;
                    break;
                case 1166:
                    DoLog("Renault 9 Turbo 1981 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.7;
                    maxspeed = 116;
                    grip = 72;
                    weight = 905;
                    break;
                case 1167:
                    DoLog("Renault Megane 2008 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.2;
                    maxspeed = 124;
                    grip = 71;
                    weight = 1205;
                    break;
                case 1168:
                    DoLog("Renault Sport Twingo GT 2016 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.3;
                    maxspeed = 117;
                    grip = 72;
                    weight = 980;
                    break;
                case 1169:
                    DoLog("Renault Twingo 2016 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.2;
                    maxspeed = 103;
                    grip = 72;
                    weight = 943;
                    break;
                case 1170:
                    DoLog("Renault Vel Satis 2002 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.2;
                    maxspeed = 130;
                    grip = 70;
                    weight = 1640;
                    break;
                case 1171:
                    DoLog("Renault Laguna 2001 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.3;
                    maxspeed = 125;
                    grip = 71;
                    weight = 1315;
                    break;
                case 1172:
                    DoLog("Renault Scenic 2016 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.8;
                    maxspeed = 121;
                    grip = 71;
                    weight = 1430;
                    break;
                case 1173:
                    DoLog("Renault 30 1975 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.7;
                    maxspeed = 116;
                    grip = 68;
                    weight = 1320;
                    break;
                case 1174:
                    DoLog("Renault 21 Savanna 1986 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.5;
                    maxspeed = 120;
                    grip = 69;
                    weight = 1135;
                    break;
                case 1175:
                    DoLog("Renault Koleos 2018 e8");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.2;
                    maxspeed = 127;
                    grip = 68;
                    weight = 1698;
                    break;
                case 1176:
                    DoLog("Renault Twizy F1 2013 e9");
                    clearance = 1;
                    tires = 1;
                    drive = 2;
                    acceleration = 6;
                    maxspeed = 68;
                    grip = 70;
                    weight = 474;
                    break;
                case 1177:
                    DoLog("Renault Sport Megane 2.0 dCi 175 2008 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.8;
                    maxspeed = 137;
                    grip = 74;
                    weight = 1450;
                    break;
                case 1178:
                    DoLog("Renault Clio 2005 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.5;
                    maxspeed = 109;
                    grip = 70;
                    weight = 1135;
                    break;
                case 1179:
                    DoLog("Renault Espace 1997 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11;
                    maxspeed = 115;
                    grip = 69;
                    weight = 1565;
                    break;
                case 1180:
                    DoLog("Renault R8 Gordini 1964 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 12.3;
                    maxspeed = 106;
                    grip = 68;
                    weight = 853;
                    break;
                case 1181:
                    DoLog("Renault Scenic 2003 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.9;
                    maxspeed = 112;
                    grip = 70;
                    weight = 1445;
                    break;
                case 1182:
                    DoLog("Renault Twingo 2007 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.7;
                    maxspeed = 94;
                    grip = 70;
                    weight = 820;
                    break;
                case 1183:
                    DoLog("Renault Twizy 2016 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 99;
                    maxspeed = 50;
                    grip = 69;
                    weight = 450;
                    break;
                case 1184:
                    DoLog("Renault Zoe 2016 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.6;
                    maxspeed = 84;
                    grip = 71;
                    weight = 1468;
                    break;
                case 1185:
                    DoLog("Renault Twingo 1993 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.4;
                    maxspeed = 93;
                    grip = 69;
                    weight = 812;
                    break;
                case 1186:
                    DoLog("Renault 16 1965 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12;
                    maxspeed = 100;
                    grip = 66;
                    weight = 1060;
                    break;
                case 1187:
                    DoLog("Renault 17 Coupe 1976 f4");
                    clearance = 1;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.8;
                    maxspeed = 105;
                    grip = 67;
                    weight = 1015;
                    break;
                case 1188:
                    DoLog("Renault 18 1978 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13;
                    maxspeed = 101;
                    grip = 68;
                    weight = 920;
                    break;
                case 1189:
                    DoLog("Renault Clio 1990 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 14.3;
                    maxspeed = 93;
                    grip = 68;
                    weight = 825;
                    break;
                case 1190:
                    DoLog("Renault Clio 1998 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 14.2;
                    maxspeed = 99;
                    grip = 69;
                    weight = 880;
                    break;
                case 1191:
                    DoLog("Renault Clio 2016 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 15.4;
                    maxspeed = 104;
                    grip = 71;
                    weight = 980;
                    break;
                case 1192:
                    DoLog("Renault Espace 1984 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.2;
                    maxspeed = 109;
                    grip = 68;
                    weight = 1200;
                    break;
                case 1193:
                    DoLog("Renault Espace 2002 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.9;
                    maxspeed = 115;
                    grip = 69;
                    weight = 1665;
                    break;
                case 1194:
                    DoLog("Renault Megane 2002 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.8;
                    maxspeed = 106;
                    grip = 70;
                    weight = 1240;
                    break;
                case 1195:
                    DoLog("Renault Scenic 1996 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.9;
                    maxspeed = 101;
                    grip = 68;
                    weight = 1295;
                    break;
                case 1196:
                    DoLog("Renault Espace 1991 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.8;
                    maxspeed = 107;
                    grip = 68;
                    weight = 1320;
                    break;
                case 1197:
                    DoLog("Renault 12 1969 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 16.5;
                    maxspeed = 89;
                    grip = 67;
                    weight = 840;
                    break;
                case 1198:
                    DoLog("Renault 14 1976 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 14.8;
                    maxspeed = 98;
                    grip = 67;
                    weight = 865;
                    break;
                case 1199:
                    DoLog("Renault 4 1961 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 30;
                    maxspeed = 68;
                    grip = 56;
                    weight = 600;
                    break;
                case 1200:
                    DoLog("Renault 5 1972 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 18.5;
                    maxspeed = 79;
                    grip = 65;
                    weight = 785;
                    break;
                case 1201:
                    DoLog("Renault 5 1984 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 16.9;
                    maxspeed = 91;
                    grip = 68;
                    weight = 775;
                    break;
                case 1202:
                    DoLog("Renault 6 1968 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 18.2;
                    maxspeed = 75;
                    grip = 65;
                    weight = 750;
                    break;
                case 1203:
                    DoLog("Renault R12 Gordini 1973 f5");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 9.8;
                    maxspeed = 115;
                    grip = 66;
                    weight = 980;
                    break;
                case 1204:
                    DoLog("Renault R17 Gordini 1979 f5");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 9.8;
                    maxspeed = 111;
                    grip = 65;
                    weight = 1055;
                    break;
                case 1205:
                    DoLog("Renault Fuego Turbo 1982 f6");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.9;
                    maxspeed = 120;
                    grip = 66;
                    weight = 1050;
                    break;
                case 1206:
                    DoLog("Rover 220 Coupe Turbo 1992 c15");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.1;
                    maxspeed = 146;
                    grip = 82;
                    weight = 1185;
                    break;
                case 1207:
                    DoLog("Rover 216 1984 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.5;
                    maxspeed = 121;
                    grip = 79;
                    weight = 1080;
                    break;
                case 1208:
                    DoLog("Rover 220 GSi 1989 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.1;
                    maxspeed = 126;
                    grip = 77;
                    weight = 1200;
                    break;
                case 1209:
                    DoLog("Rover SD1 1976 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 8.6;
                    maxspeed = 126;
                    grip = 73;
                    weight = 1372;
                    break;
                case 1210:
                    DoLog("Rover 623 1993 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.2;
                    maxspeed = 124;
                    grip = 78;
                    weight = 1240;
                    break;
                case 1211:
                    DoLog("Rover 800 1986 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.8;
                    maxspeed = 126;
                    grip = 75;
                    weight = 1290;
                    break;
                case 1212:
                    DoLog("Rover 400 1995 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.5;
                    maxspeed = 110;
                    grip = 77;
                    weight = 1102;
                    break;
                case 1213:
                    DoLog("Rover P6 1963 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.8;
                    maxspeed = 115;
                    grip = 68;
                    weight = 1272;
                    break;
                case 1214:
                    DoLog("Rover 200 1995 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.5;
                    maxspeed = 103;
                    grip = 76;
                    weight = 1020;
                    break;
                case 1215:
                    DoLog("RUF 3800S 2013 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.1;
                    maxspeed = 186;
                    grip = 87;
                    weight = 1375;
                    break;
                case 1216:
                    DoLog("RUF BTR2 1993 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 191;
                    grip = 85;
                    weight = 1420;
                    break;
                case 1217:
                    DoLog("RUF CTR \"Yellowbird\" 1987 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4;
                    maxspeed = 213;
                    grip = 84;
                    weight = 1150;
                    break;
                case 1218:
                    DoLog("RUF R Kompressor 2006 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 189;
                    grip = 86;
                    weight = 1495;
                    break;
                case 1219:
                    DoLog("RUF RK Coupe 2006 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.8;
                    maxspeed = 190;
                    grip = 87;
                    weight = 1450;
                    break;
                case 1220:
                    DoLog("RUF RCT 1991 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.3;
                    maxspeed = 190;
                    grip = 83;
                    weight = 1470;
                    break;
                case 1221:
                    DoLog("RUF RGT 2000 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.6;
                    maxspeed = 190;
                    grip = 85;
                    weight = 1320;
                    break;
                case 1222:
                    DoLog("RUF 3400S 1999 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5;
                    maxspeed = 173;
                    grip = 86;
                    weight = 1300;
                    break;
                case 1223:
                    DoLog("RUF BTR 1983 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.3;
                    maxspeed = 190;
                    grip = 81;
                    weight = 1350;
                    break;
                case 1224:
                    DoLog("RUF Turbo 3.3 1977 b20");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5;
                    maxspeed = 160;
                    grip = 80;
                    weight = 1350;
                    break;
                case 1225:
                    DoLog("RUF R56.11 2018 c18");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 6;
                    maxspeed = 140;
                    grip = 74;
                    weight = 850;
                    break;
                case 1226:
                    DoLog("RUF SCR 1978 c17");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.4;
                    maxspeed = 159;
                    grip = 79;
                    weight = 1120;
                    break;
                case 1227:
                    DoLog("RUF CTR2 1995 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.3;
                    maxspeed = 217;
                    grip = 86;
                    weight = 1358;
                    break;
                case 1228:
                    DoLog("RUF CTR3 Clubsport 2012 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3;
                    maxspeed = 236;
                    grip = 91;
                    weight = 1400;
                    break;
                case 1229:
                    DoLog("RUF Rt 12 S 2009 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3;
                    maxspeed = 219;
                    grip = 87;
                    weight = 1500;
                    break;
                case 1230:
                    DoLog("RUF RTR 2016 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 2.8;
                    maxspeed = 225;
                    grip = 88;
                    weight = 1595;
                    break;
                case 1231:
                    DoLog("RUF Turbo Florio 2015 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3;
                    maxspeed = 205;
                    grip = 87;
                    weight = 1700;
                    break;
                case 1232:
                    DoLog("RUF CTR3 2007 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.1;
                    maxspeed = 233;
                    grip = 90;
                    weight = 1400;
                    break;
                case 1233:
                    DoLog("RUF R Turbo 2001 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.6;
                    maxspeed = 212;
                    grip = 87;
                    weight = 1540;
                    break;
                case 1234:
                    DoLog("RUF Rt 35 2012 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3;
                    maxspeed = 210;
                    grip = 89;
                    weight = 1585;
                    break;
                case 1235:
                    DoLog("RUF Turbo R Limited 2016 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.6;
                    maxspeed = 212;
                    grip = 85;
                    weight = 1450;
                    break;
                case 1236:
                    DoLog("RUF SCR 4.2 2016 s28");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.4;
                    maxspeed = 199;
                    grip = 86;
                    weight = 1295;
                    break;
                case 1237:
                    DoLog("RUF Dakara 2009 s27");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 4.8;
                    maxspeed = 180;
                    grip = 80;
                    weight = 2355;
                    break;
                case 1238:
                    DoLog("Scuderia Cameron Glickenhaus SCG003S 2018 s30");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.8;
                    maxspeed = 217;
                    grip = 95;
                    weight = 1300;
                    break;
                case 1239:
                    DoLog("Smart Fortwo Coupe T 2016 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.3;
                    maxspeed = 96;
                    grip = 63;
                    weight = 900;
                    break;
                case 1240:
                    DoLog("Smart Brabus Roadster 2005 e7");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 9.3;
                    maxspeed = 118;
                    grip = 70;
                    weight = 820;
                    break;
                case 1241:
                    DoLog("Smart Fortwo 2004 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 12.2;
                    maxspeed = 90;
                    grip = 60;
                    weight = 750;
                    break;
                case 1242:
                    DoLog("Smart Fortwo Cabrio 2016 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 13.8;
                    maxspeed = 94;
                    grip = 62;
                    weight = 840;
                    break;
                case 1243:
                    DoLog("Smart Fortwo EV 2008 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 10.5;
                    maxspeed = 78;
                    grip = 59;
                    weight = 940;
                    break;
                case 1244:
                    DoLog("Smart Crossblade 2002 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 15.4;
                    maxspeed = 84;
                    grip = 60;
                    weight = 700;
                    break;
                case 1245:
                    DoLog("Smart Forfour 2016 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 15.8;
                    maxspeed = 94;
                    grip = 63;
                    weight = 975;
                    break;
                case 1246:
                    DoLog("Subaru Impreza 22B 1998 a25");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.1;
                    maxspeed = 154;
                    grip = 85;
                    weight = 1270;
                    break;
                case 1247:
                    DoLog("Subaru Impreza WRX STI 2010 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.2;
                    maxspeed = 158;
                    grip = 85;
                    weight = 1535;
                    break;
                case 1248:
                    DoLog("Subaru WRX STI 2014 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.2;
                    maxspeed = 159;
                    grip = 85;
                    weight = 1545;
                    break;
                case 1249:
                    DoLog("Subaru Impreza WRX STI 2005 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.3;
                    maxspeed = 155;
                    grip = 85;
                    weight = 1496;
                    break;
                case 1250:
                    DoLog("Subaru Impreza WRX 1993 b22");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 6;
                    maxspeed = 150;
                    grip = 81;
                    weight = 1200;
                    break;
                case 1251:
                    DoLog("Subaru Tribeca 2006 b20");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 8.5;
                    maxspeed = 129;
                    grip = 76;
                    weight = 1908;
                    break;
                case 1252:
                    DoLog("Subaru Forester 1997 c15");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 9.8;
                    maxspeed = 106;
                    grip = 77;
                    weight = 1360;
                    break;
                case 1253:
                    DoLog("Subaru Legacy 2016 c18");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 8.2;
                    maxspeed = 141;
                    grip = 75;
                    weight = 1573;
                    break;
                case 1254:
                    DoLog("Subaru Forester 2016 c17");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 8.9;
                    maxspeed = 120;
                    grip = 78;
                    weight = 1474;
                    break;
                case 1255:
                    DoLog("Subaru Levorg 2016 c17");
                    clearance = 2;
                    tires = 4;
                    drive = 4;
                    acceleration = 8.9;
                    maxspeed = 130;
                    grip = 78;
                    weight = 1554;
                    break;
                case 1256:
                    DoLog("Subaru Outback 2016 c16");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 9.2;
                    maxspeed = 124;
                    grip = 78;
                    weight = 1649;
                    break;
                case 1257:
                    DoLog("Subaru Legacy 2003 c16");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 8.8;
                    maxspeed = 133;
                    grip = 74;
                    weight = 1370;
                    break;
                case 1258:
                    DoLog("Subaru BRZ 2016 c16");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 6.4;
                    maxspeed = 143;
                    grip = 79;
                    weight = 1253;
                    break;
                case 1259:
                    DoLog("Subaru Baja Turbo 2003 c17");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 8.5;
                    maxspeed = 135;
                    grip = 72;
                    weight = 1588;
                    break;
                case 1260:
                    DoLog("Subaru Forester 2008 c15");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 9.5;
                    maxspeed = 111;
                    grip = 77;
                    weight = 1440;
                    break;
                case 1261:
                    DoLog("Subaru Legacy 2009 c16");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 9.1;
                    maxspeed = 130;
                    grip = 75;
                    weight = 1420;
                    break;
                case 1262:
                    DoLog("Subaru Legacy 1998 c16");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 8.9;
                    maxspeed = 133;
                    grip = 73;
                    weight = 1360;
                    break;
                case 1263:
                    DoLog("Subaru Forester 2002 c15");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 9.7;
                    maxspeed = 107;
                    grip = 77;
                    weight = 1320;
                    break;
                case 1264:
                    DoLog("Subaru XV 2016 c15");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 10.5;
                    maxspeed = 116;
                    grip = 77;
                    weight = 1355;
                    break;
                case 1265:
                    DoLog("Subaru XT 1985 d14");
                    clearance = 1;
                    tires = 3;
                    drive = 4;
                    acceleration = 8.7;
                    maxspeed = 119;
                    grip = 75;
                    weight = 1130;
                    break;
                case 1266:
                    DoLog("Subaru Alcyone SVX 1991 d13");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 7.3;
                    maxspeed = 154;
                    grip = 74;
                    weight = 1580;
                    break;
                case 1267:
                    DoLog("Subaru Legacy 1993 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 10.3;
                    maxspeed = 120;
                    grip = 69;
                    weight = 1309;
                    break;
                case 1268:
                    DoLog("Subaru Leone 1984 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 10.9;
                    maxspeed = 103;
                    grip = 73;
                    weight = 1105;
                    break;
                case 1269:
                    DoLog("Subaru Justy 1984 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 10.9;
                    maxspeed = 94;
                    grip = 65;
                    weight = 670;
                    break;
                case 1270:
                    DoLog("Subaru Brat 1978 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 13.5;
                    maxspeed = 91;
                    grip = 68;
                    weight = 935;
                    break;
                case 1271:
                    DoLog("Subaru Legacy 1989 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 12.9;
                    maxspeed = 109;
                    grip = 68;
                    weight = 1150;
                    break;
                case 1272:
                    DoLog("Subaru Leone 1971 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.1;
                    maxspeed = 106;
                    grip = 70;
                    weight = 775;
                    break;
                case 1273:
                    DoLog("Subaru Leone 1979 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.6;
                    maxspeed = 96;
                    grip = 72;
                    weight = 917;
                    break;
                case 1274:
                    DoLog("Subaru Rex 1986 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 19.8;
                    maxspeed = 72;
                    grip = 65;
                    weight = 590;
                    break;
                case 1275:
                    DoLog("Subaru Rex 1972 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 20;
                    maxspeed = 68;
                    grip = 60;
                    weight = 570;
                    break;
                case 1276:
                    DoLog("Subaru Rex 1981 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 18.7;
                    maxspeed = 78;
                    grip = 65;
                    weight = 565;
                    break;
                case 1277:
                    DoLog("Suzuki Kizashi 4x4 2010 b19");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 7.4;
                    maxspeed = 124;
                    grip = 77;
                    weight = 1470;
                    break;
                case 1278:
                    DoLog("Suzuki XL-7 1998 c18");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 9.5;
                    maxspeed = 114;
                    grip = 73;
                    weight = 1735;
                    break;
                case 1279:
                    DoLog("Suzuki Ignis 2016 c17");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 10.9;
                    maxspeed = 103;
                    grip = 75;
                    weight = 920;
                    break;
                case 1280:
                    DoLog("Suzuki SX4 2006 c17");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 10.9;
                    maxspeed = 106;
                    grip = 74;
                    weight = 1265;
                    break;
                case 1281:
                    DoLog("Suzuki Vitara S 2016 c16");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 11.4;
                    maxspeed = 112;
                    grip = 76;
                    weight = 1160;
                    break;
                case 1282:
                    DoLog("Suzuki SX4 S-Cross 2016 c16");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 11.6;
                    maxspeed = 111;
                    grip = 75;
                    weight = 1305;
                    break;
                case 1283:
                    DoLog("Suzuki Swift Rally Spec 2008 c18");
                    clearance = 2;
                    tires = 5;
                    drive = 1;
                    acceleration = 7.7;
                    maxspeed = 124;
                    grip = 80;
                    weight = 975;
                    break;
                case 1284:
                    DoLog("Suzuki Ignis Sport 2004 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.5;
                    maxspeed = 115;
                    grip = 80;
                    weight = 935;
                    break;
                case 1285:
                    DoLog("Suzuki Jimny 2007 d14");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 13.3;
                    maxspeed = 87;
                    grip = 73;
                    weight = 1025;
                    break;
                case 1286:
                    DoLog("Suzuki Swift 2011 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.5;
                    maxspeed = 124;
                    grip = 79;
                    weight = 1060;
                    break;
                case 1287:
                    DoLog("Suzuki Vitara 2005 d13");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 13.6;
                    maxspeed = 99;
                    grip = 75;
                    weight = 1490;
                    break;
                case 1288:
                    DoLog("Suzuki X-90 1995 d14");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 10.8;
                    maxspeed = 94;
                    grip = 73;
                    weight = 1043;
                    break;
                case 1289:
                    DoLog("Suzuki Swift 2016 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.9;
                    maxspeed = 119;
                    grip = 75;
                    weight = 970;
                    break;
                case 1290:
                    DoLog("Suzuki Ertiga 2016 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.4;
                    maxspeed = 109;
                    grip = 74;
                    weight = 1160;
                    break;
                case 1291:
                    DoLog("Suzuki Baleno 2016 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11;
                    maxspeed = 124;
                    grip = 76;
                    weight = 950;
                    break;
                case 1292:
                    DoLog("Suzuki Alto 2004 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.2;
                    maxspeed = 96;
                    grip = 75;
                    weight = 855;
                    break;
                case 1293:
                    DoLog("Suzuki Celerio 2016 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.1;
                    maxspeed = 96;
                    grip = 75;
                    weight = 835;
                    break;
                case 1294:
                    DoLog("Suzuki Splash 2008 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.9;
                    maxspeed = 99;
                    grip = 75;
                    weight = 975;
                    break;
                case 1295:
                    DoLog("Suzuki Splash 2012 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 14.2;
                    maxspeed = 99;
                    grip = 75;
                    weight = 1030;
                    break;
                case 1296:
                    DoLog("Suzuki SC100 1977 f5");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 16.5;
                    maxspeed = 85;
                    grip = 71;
                    weight = 655;
                    break;
                case 1297:
                    DoLog("Suzuki Wagon R 1993 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 14.9;
                    maxspeed = 87;
                    grip = 72;
                    weight = 845;
                    break;
                case 1298:
                    DoLog("Suzuki Liana 2001 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 14.1;
                    maxspeed = 103;
                    grip = 74;
                    weight = 1170;
                    break;
                case 1299:
                    DoLog("Suzuki Pikes Peak XL7 2007 s30");
                    clearance = 1;
                    tires = 4;
                    drive = 4;
                    acceleration = 2.1;
                    maxspeed = 150;
                    grip = 90;
                    weight = 1100;
                    break;
                case 1300:
                    DoLog("TVR Sagaris 2005 a24");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 185;
                    grip = 80;
                    weight = 1078;
                    break;
                case 1301:
                    DoLog("TVR Tuscan S 2005 a23");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 3.9;
                    maxspeed = 195;
                    grip = 78;
                    weight = 1100;
                    break;
                case 1302:
                    DoLog("TVR Tamora 2001 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.2;
                    maxspeed = 175;
                    grip = 77;
                    weight = 1060;
                    break;
                case 1303:
                    DoLog("TVR Tuscan Convertible 2005 b22");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.1;
                    maxspeed = 180;
                    grip = 77;
                    weight = 1100;
                    break;
                case 1304:
                    DoLog("TVR Cerbera Speed Six 1998 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.4;
                    maxspeed = 160;
                    grip = 77;
                    weight = 1130;
                    break;
                case 1305:
                    DoLog("TVR Griffith 500 1993 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.6;
                    maxspeed = 157;
                    grip = 76;
                    weight = 1060;
                    break;
                case 1306:
                    DoLog("TVR Chimaera 5.0 1993 b20");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.1;
                    maxspeed = 167;
                    grip = 75;
                    weight = 1060;
                    break;
                case 1307:
                    DoLog("TVR Griffith 4.3 1992 b19");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.4;
                    maxspeed = 155;
                    grip = 75;
                    weight = 1040;
                    break;
                case 1308:
                    DoLog("TVR Cerbera Speed 12 2000 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 2.9;
                    maxspeed = 240;
                    grip = 88;
                    weight = 1070;
                    break;
                case 1309:
                    DoLog("Vauxhall VXR8 GTS 2016 a23");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4;
                    maxspeed = 155;
                    grip = 81;
                    weight = 1881;
                    break;
                case 1310:
                    DoLog("Vauxhall Maloo R8 LSA 2016 b21");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.5;
                    maxspeed = 155;
                    grip = 77;
                    weight = 1869;
                    break;
                case 1311:
                    DoLog("Vauxhall VX220 Turbo 2003 b21");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 4.7;
                    maxspeed = 151;
                    grip = 84;
                    weight = 1005;
                    break;
                case 1312:
                    DoLog("Vauxhall Insignia VXR S'sport 2016 b21");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.7;
                    maxspeed = 168;
                    grip = 78;
                    weight = 1825;
                    break;
                case 1313:
                    DoLog("Vauxhall Calibra Turbo 1992 b20");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 6.1;
                    maxspeed = 152;
                    grip = 80;
                    weight = 1405;
                    break;
                case 1314:
                    DoLog("Vauxhall GTC VXR 2016 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.7;
                    maxspeed = 155;
                    grip = 83;
                    weight = 1550;
                    break;
                case 1315:
                    DoLog("Vauxhall Antara 2.2CDTi 2016 c17");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 9.4;
                    maxspeed = 117;
                    grip = 70;
                    weight = 1885;
                    break;
                case 1316:
                    DoLog("Vauxhall Corsa VXR 2016 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.5;
                    maxspeed = 143;
                    grip = 82;
                    weight = 1278;
                    break;
                case 1317:
                    DoLog("Vauxhall Vectra VXR 2006 c16");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.6;
                    maxspeed = 159;
                    grip = 74;
                    weight = 1563;
                    break;
                case 1318:
                    DoLog("Vauxhall VX220 2000 c18");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 5.6;
                    maxspeed = 135;
                    grip = 80;
                    weight = 850;
                    break;
                case 1319:
                    DoLog("Vauxhall Mokka 4x4 2016 d11");
                    clearance = 3;
                    tires = 3;
                    drive = 4;
                    acceleration = 11.9;
                    maxspeed = 111;
                    grip = 68;
                    weight = 1429;
                    break;
                case 1320:
                    DoLog("Vauxhall Astra GTE 1988 d11");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.4;
                    maxspeed = 134;
                    grip = 71;
                    weight = 1007;
                    break;
                case 1321:
                    DoLog("Vauxhall Cascada 2016 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.2;
                    maxspeed = 146;
                    grip = 73;
                    weight = 1658;
                    break;
                case 1322:
                    DoLog("Vauxhall Vectra 2.5 V6 1995 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8;
                    maxspeed = 143;
                    grip = 70;
                    weight = 1316;
                    break;
                case 1323:
                    DoLog("Vauxhall Chevette HSR 1980 d14");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 7.5;
                    maxspeed = 125;
                    grip = 82;
                    weight = 980;
                    break;
                case 1324:
                    DoLog("Vauxhall Tigra 1994 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11;
                    maxspeed = 118;
                    grip = 70;
                    weight = 1070;
                    break;
                case 1325:
                    DoLog("Vauxhall Frontera 1989 e10");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 14.4;
                    maxspeed = 98;
                    grip = 60;
                    weight = 1575;
                    break;
                case 1326:
                    DoLog("Vauxhall Astra 2016 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.6;
                    maxspeed = 127;
                    grip = 70;
                    weight = 1360;
                    break;
                case 1327:
                    DoLog("Vauxhall Opel Vectra GSi 1988 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 9.1;
                    maxspeed = 129;
                    grip = 73;
                    weight = 1310;
                    break;
                case 1328:
                    DoLog("Vauxhall Opel Manta GTE 1988 e8");
                    clearance = 2;
                    tires = 2;
                    drive = 2;
                    acceleration = 8.5;
                    maxspeed = 120;
                    grip = 68;
                    weight = 1065;
                    break;
                case 1329:
                    DoLog("Vauxhall Insignia 2.0 CDTi 2016 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10;
                    maxspeed = 127;
                    grip = 71;
                    weight = 1613;
                    break;
                case 1330:
                    DoLog("Vauxhall Nova GTE 1987 e7");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 9.1;
                    maxspeed = 117;
                    grip = 68;
                    weight = 820;
                    break;
                case 1331:
                    DoLog("Vauxhall Cavalier SRi 1981 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.1;
                    maxspeed = 121;
                    grip = 66;
                    weight = 1060;
                    break;
                case 1332:
                    DoLog("Vauxhall Astra 1.6 CDTi 2009 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.1;
                    maxspeed = 117;
                    grip = 69;
                    weight = 1393;
                    break;
                case 1333:
                    DoLog("Vauxhall Tigra TwinTop 2004 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.8;
                    maxspeed = 112;
                    grip = 72;
                    weight = 1235;
                    break;
                case 1334:
                    DoLog("Vauxhall Astra 1.6i 2004 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.1;
                    maxspeed = 119;
                    grip = 65;
                    weight = 1165;
                    break;
                case 1335:
                    DoLog("Vauxhall Adam 1.2 2016 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 14.1;
                    maxspeed = 102;
                    grip = 68;
                    weight = 1086;
                    break;
                case 1336:
                    DoLog("Vauxhall Cavalier 1.6 1988 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.3;
                    maxspeed = 109;
                    grip = 65;
                    weight = 990;
                    break;
                case 1337:
                    DoLog("Vauxhall Corsa 1.4 2016 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.5;
                    maxspeed = 101;
                    grip = 68;
                    weight = 1141;
                    break;
                case 1338:
                    DoLog("Vauxhall Cavalier 1600L 1975 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 13;
                    maxspeed = 100;
                    grip = 61;
                    weight = 980;
                    break;
                case 1339:
                    DoLog("Vauxhall Astra 1.2 1984 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 17;
                    maxspeed = 96;
                    grip = 62;
                    weight = 850;
                    break;
                case 1340:
                    DoLog("Vauxhall Astra 1.4i 1991 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 15.9;
                    maxspeed = 99;
                    grip = 63;
                    weight = 930;
                    break;
                case 1341:
                    DoLog("Vauxhall Astra 1.4i 1998 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.8;
                    maxspeed = 106;
                    grip = 65;
                    weight = 1055;
                    break;
                case 1342:
                    DoLog("Vauxhall Astra 1.6 1979 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.6;
                    maxspeed = 106;
                    grip = 61;
                    weight = 940;
                    break;
                case 1343:
                    DoLog("Volkswagen W12 Roadster 1997 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.1;
                    maxspeed = 175;
                    grip = 86;
                    weight = 1150;
                    break;
                case 1344:
                    DoLog("Volkswagen W12 Syncro 1997 a26");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.2;
                    maxspeed = 180;
                    grip = 86;
                    weight = 1200;
                    break;
                case 1345:
                    DoLog("Volkswagen Arteon 2017 a25");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 5;
                    maxspeed = 155;
                    grip = 78;
                    weight = 1716;
                    break;
                case 1346:
                    DoLog("Volkswagen CC 2008 a24");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 5.5;
                    maxspeed = 155;
                    grip = 79;
                    weight = 1632;
                    break;
                case 1347:
                    DoLog("Volkswagen Golf R 2015 a24");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.9;
                    maxspeed = 155;
                    grip = 82;
                    weight = 1515;
                    break;
                case 1348:
                    DoLog("Volkswagen Phaeton 2002 a24");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 5.7;
                    maxspeed = 166;
                    grip = 76;
                    weight = 2297;
                    break;
                case 1349:
                    DoLog("Volkswagen Golf R 2012 a23");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.2;
                    maxspeed = 155;
                    grip = 81;
                    weight = 1508;
                    break;
                case 1350:
                    DoLog("Volkswagen Touareg 2018 a23");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5.8;
                    maxspeed = 146;
                    grip = 73;
                    weight = 1995;
                    break;
                case 1351:
                    DoLog("Volkswagen Golf GTI TCR 2018 b21");
                    clearance = 1;
                    tires = 1;
                    drive = 1;
                    acceleration = 5;
                    maxspeed = 165;
                    grip = 86;
                    weight = 1285;
                    break;
                case 1352:
                    DoLog("Volkswagen Golf R32 2005 b21");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 5.8;
                    maxspeed = 155;
                    grip = 80;
                    weight = 1541;
                    break;
                case 1353:
                    DoLog("Volkswagen Touareg 2002 b21");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 6.6;
                    maxspeed = 142;
                    grip = 70;
                    weight = 2524;
                    break;
                case 1354:
                    DoLog("Volkswagen Golf GTI 2013 b19");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.2;
                    maxspeed = 153;
                    grip = 80;
                    weight = 1351;
                    break;
                case 1355:
                    DoLog("Volkswagen Phaeton 2014 c18");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 8.2;
                    maxspeed = 148;
                    grip = 75;
                    weight = 2325;
                    break;
                case 1356:
                    DoLog("Volkswagen Scirocco R 2009 c18");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 5.7;
                    maxspeed = 155;
                    grip = 81;
                    weight = 1344;
                    break;
                case 1357:
                    DoLog("Volkswagen Tiguan 2017 c18");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 9;
                    maxspeed = 125;
                    grip = 72;
                    weight = 1585;
                    break;
                case 1358:
                    DoLog("Volkswagen Touareg 2007 c18");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 8.4;
                    maxspeed = 127;
                    grip = 71;
                    weight = 2301;
                    break;
                case 1359:
                    DoLog("Volkswagen Golf GTI 2009 c17");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.6;
                    maxspeed = 149;
                    grip = 79;
                    weight = 1318;
                    break;
                case 1360:
                    DoLog("Volkswagen New Beetle RSi 2000 c17");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 6.1;
                    maxspeed = 140;
                    grip = 77;
                    weight = 1515;
                    break;
                case 1361:
                    DoLog("Volkswagen Tiguan 2011 c17");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 10;
                    maxspeed = 116;
                    grip = 71;
                    weight = 1590;
                    break;
                case 1362:
                    DoLog("Volkswagen Beetle 2011 c16");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.1;
                    maxspeed = 140;
                    grip = 75;
                    weight = 1439;
                    break;
                case 1363:
                    DoLog("Volkswagen Corrado VR6 1992 c16");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.3;
                    maxspeed = 145;
                    grip = 78;
                    weight = 1240;
                    break;
                case 1364:
                    DoLog("Volkswagen Golf GTI 2004 c16");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7;
                    maxspeed = 146;
                    grip = 79;
                    weight = 1336;
                    break;
                case 1365:
                    DoLog("Volkswagen Polo GTI 2018 c16");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.4;
                    maxspeed = 147;
                    grip = 77;
                    weight = 1355;
                    break;
                case 1366:
                    DoLog("Volkswagen Atlas 2018 c15");
                    clearance = 3;
                    tires = 4;
                    drive = 1;
                    acceleration = 7.2;
                    maxspeed = 113;
                    grip = 71;
                    weight = 1915;
                    break;
                case 1367:
                    DoLog("Volkswagen Golf 2009 c15");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.7;
                    maxspeed = 138;
                    grip = 76;
                    weight = 1329;
                    break;
                case 1368:
                    DoLog("Volkswagen Lupo GTI 2001 c15");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.8;
                    maxspeed = 127;
                    grip = 78;
                    weight = 975;
                    break;
                case 1369:
                    DoLog("Volkswagen Scirocco 2008 c15");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.9;
                    maxspeed = 146;
                    grip = 79;
                    weight = 1298;
                    break;
                case 1370:
                    DoLog("Volkswagen Passat 2018 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.4;
                    maxspeed = 147;
                    grip = 74;
                    weight = 1505;
                    break;
                case 1371:
                    DoLog("Volkswagen Polo GTI 2010 d14");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.4;
                    maxspeed = 142;
                    grip = 76;
                    weight = 1194;
                    break;
                case 1372:
                    DoLog("Volkswagen Golf 2017 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8;
                    maxspeed = 132;
                    grip = 73;
                    weight = 1270;
                    break;
                case 1373:
                    DoLog("Volkswagen Golf GTI 1997 d13");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.5;
                    maxspeed = 134;
                    grip = 76;
                    weight = 1249;
                    break;
                case 1374:
                    DoLog("Volkswagen Golf VR6 1991 d13");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.1;
                    maxspeed = 137;
                    grip = 75;
                    weight = 1155;
                    break;
                case 1375:
                    DoLog("Volkswagen Jetta 2004 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 7.7;
                    maxspeed = 130;
                    grip = 73;
                    weight = 1440;
                    break;
                case 1376:
                    DoLog("Volkswagen Jetta 2019 d13");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.3;
                    maxspeed = 140;
                    grip = 76;
                    weight = 1342;
                    break;
                case 1377:
                    DoLog("Volkswagen Jetta VR6 1992 d13");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.1;
                    maxspeed = 137;
                    grip = 75;
                    weight = 1155;
                    break;
                case 1378:
                    DoLog("Volkswagen Beetle Cabriolet 2012 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.2;
                    maxspeed = 128;
                    grip = 74;
                    weight = 1454;
                    break;
                case 1379:
                    DoLog("Volkswagen Jetta GTI 1988 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.2;
                    maxspeed = 125;
                    grip = 74;
                    weight = 950;
                    break;
                case 1380:
                    DoLog("Volkswagen Passat 2006 d12");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.2;
                    maxspeed = 139;
                    grip = 73;
                    weight = 1457;
                    break;
                case 1381:
                    DoLog("Volkswagen Polo GTI 2006 d12");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.8;
                    maxspeed = 134;
                    grip = 75;
                    weight = 1164;
                    break;
                case 1382:
                    DoLog("Volkswagen Golf G60 Rallye 1988 d11");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.2;
                    maxspeed = 130;
                    grip = 77;
                    weight = 1195;
                    break;
                case 1383:
                    DoLog("Volkswagen Jetta 2011 d11");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9;
                    maxspeed = 130;
                    grip = 75;
                    weight = 1336;
                    break;
                case 1384:
                    DoLog("Volkswagen Corrado 16v G60 1988 e10");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 8;
                    maxspeed = 140;
                    grip = 76;
                    weight = 1115;
                    break;
                case 1385:
                    DoLog("Volkswagen Golf GTI G60 1990 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.3;
                    maxspeed = 134;
                    grip = 75;
                    weight = 1077;
                    break;
                case 1386:
                    DoLog("Volkswagen Jetta 2008 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.2;
                    maxspeed = 127;
                    grip = 75;
                    weight = 1410;
                    break;
                case 1387:
                    DoLog("Volkswagen Polo 2003 e10");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.9;
                    maxspeed = 128;
                    grip = 72;
                    weight = 1155;
                    break;
                case 1388:
                    DoLog("Volkswagen Polo GTI 1999 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.3;
                    maxspeed = 127;
                    grip = 74;
                    weight = 984;
                    break;
                case 1389:
                    DoLog("Volkswagen Scirocco GTI 1986 e10");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.9;
                    maxspeed = 127;
                    grip = 74;
                    weight = 970;
                    break;
                case 1390:
                    DoLog("Volkswagen up! GTI 2018 e10");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.3;
                    maxspeed = 122;
                    grip = 77;
                    weight = 1070;
                    break;
                case 1391:
                    DoLog("Volkswagen Corrado 1988 e9");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.6;
                    maxspeed = 132;
                    grip = 75;
                    weight = 1090;
                    break;
                case 1392:
                    DoLog("Volkswagen Golf GTI 1985 e9");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.1;
                    maxspeed = 118;
                    grip = 73;
                    weight = 907;
                    break;
                case 1393:
                    DoLog("Volkswagen Passat 2003 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.3;
                    maxspeed = 131;
                    grip = 72;
                    weight = 1445;
                    break;
                case 1394:
                    DoLog("Volkswagen Polo GT G40 1987 e9");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 9;
                    maxspeed = 121;
                    grip = 73;
                    weight = 720;
                    break;
                case 1395:
                    DoLog("Volkswagen T-Roc 2017 e9");
                    clearance = 3;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.6;
                    maxspeed = 116;
                    grip = 72;
                    weight = 1270;
                    break;
                case 1396:
                    DoLog("Volkswagen Golf 2003 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.3;
                    maxspeed = 119;
                    grip = 72;
                    weight = 1184;
                    break;
                case 1397:
                    DoLog("Volkswagen Golf GTI 1991 e8");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 9.6;
                    maxspeed = 122;
                    grip = 73;
                    weight = 1140;
                    break;
                case 1398:
                    DoLog("Volkswagen Golf GTI 1982 e8");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.8;
                    maxspeed = 114;
                    grip = 71;
                    weight = 860;
                    break;
                case 1399:
                    DoLog("Volkswagen New Beetle 1999 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.4;
                    maxspeed = 115;
                    grip = 73;
                    weight = 1231;
                    break;
                case 1400:
                    DoLog("Volkswagen Polo 2018 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.3;
                    maxspeed = 116;
                    grip = 71;
                    weight = 1145;
                    break;
                case 1401:
                    DoLog("Volkswagen Sharan 2015 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.8;
                    maxspeed = 123;
                    grip = 70;
                    weight = 1793;
                    break;
                case 1402:
                    DoLog("Volkswagen Touran 2003 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.1;
                    maxspeed = 122;
                    grip = 73;
                    weight = 1561;
                    break;
                case 1403:
                    DoLog("Volkswagen Touran 2015 e8");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.9;
                    maxspeed = 117;
                    grip = 74;
                    weight = 1361;
                    break;
                case 1404:
                    DoLog("Volkswagen Golf 1997 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 10.4;
                    maxspeed = 117;
                    grip = 70;
                    weight = 1092;
                    break;
                case 1405:
                    DoLog("Volkswagen Passat 1983 e7");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 9.6;
                    maxspeed = 116;
                    grip = 68;
                    weight = 1062;
                    break;
                case 1406:
                    DoLog("Volkswagen Scirocco 1982 e7");
                    clearance = 1;
                    tires = 2;
                    drive = 1;
                    acceleration = 8.5;
                    maxspeed = 113;
                    grip = 70;
                    weight = 800;
                    break;
                case 1407:
                    DoLog("Volkswagen Golf 1991 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.3;
                    maxspeed = 104;
                    grip = 69;
                    weight = 1005;
                    break;
                case 1408:
                    DoLog("Volkswagen Golf 1983 f5");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.5;
                    maxspeed = 104;
                    grip = 69;
                    weight = 870;
                    break;
                case 1409:
                    DoLog("Volkswagen up! 2013 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.4;
                    maxspeed = 106;
                    grip = 72;
                    weight = 929;
                    break;
                case 1410:
                    DoLog("Volkswagen New Beetle Cabriolet 2003 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.4;
                    maxspeed = 111;
                    grip = 72;
                    weight = 1385;
                    break;
                case 1411:
                    DoLog("Volkswagen Polo 2009 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 11.5;
                    maxspeed = 110;
                    grip = 71;
                    weight = 996;
                    break;
                case 1412:
                    DoLog("Volkswagen Fox 2005 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.3;
                    maxspeed = 104;
                    grip = 70;
                    weight = 1012;
                    break;
                case 1413:
                    DoLog("Volkswagen Golf 1974 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 14.8;
                    maxspeed = 87;
                    grip = 68;
                    weight = 780;
                    break;
                case 1414:
                    DoLog("Volkswagen Jetta 1980 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.5;
                    maxspeed = 97;
                    grip = 65;
                    weight = 845;
                    break;
                case 1415:
                    DoLog("Volkswagen Passat 1988 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13.2;
                    maxspeed = 110;
                    grip = 69;
                    weight = 1130;
                    break;
                case 1416:
                    DoLog("Volkswagen Passat 1975 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.5;
                    maxspeed = 91;
                    grip = 66;
                    weight = 900;
                    break;
                case 1417:
                    DoLog("Volkswagen Polo 1994 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 15.4;
                    maxspeed = 97;
                    grip = 69;
                    weight = 955;
                    break;
                case 1418:
                    DoLog("Volkswagen Polo 1984 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.7;
                    maxspeed = 95;
                    grip = 66;
                    weight = 725;
                    break;
                case 1419:
                    DoLog("Volkswagen Polo 1976 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.6;
                    maxspeed = 95;
                    grip = 65;
                    weight = 725;
                    break;
                case 1420:
                    DoLog("Volkswagen Sharan 2008 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 13;
                    maxspeed = 112;
                    grip = 69;
                    weight = 1706;
                    break;
                case 1421:
                    DoLog("Volkswagen Transporter 2016 f4");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 12.5;
                    maxspeed = 105;
                    grip = 64;
                    weight = 1680;
                    break;
                case 1422:
                    DoLog("Volkswagen Beetle 1970 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 22;
                    maxspeed = 78;
                    grip = 55;
                    weight = 870;
                    break;
                case 1423:
                    DoLog("Volkswagen Beetle Cabriolet 1970 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 22.6;
                    maxspeed = 76;
                    grip = 54;
                    weight = 850;
                    break;
                case 1424:
                    DoLog("Volkswagen Karmann Ghia 1970 f3");
                    clearance = 1;
                    tires = 3;
                    drive = 2;
                    acceleration = 22;
                    maxspeed = 86;
                    grip = 65;
                    weight = 870;
                    break;
                case 1425:
                    DoLog("Volkswagen Transporter 1996 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 17.8;
                    maxspeed = 88;
                    grip = 59;
                    weight = 1588;
                    break;
                case 1426:
                    DoLog("Volkswagen Transporter 2004 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 15;
                    maxspeed = 98;
                    grip = 60;
                    weight = 1650;
                    break;
                case 1427:
                    DoLog("Volkswagen Type 2 1970 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 35;
                    maxspeed = 68;
                    grip = 51;
                    weight = 1162;
                    break;
                case 1428:
                    DoLog("Volkswagen Type 2 1979 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 18;
                    maxspeed = 80;
                    grip = 55;
                    weight = 1385;
                    break;
                case 1429:
                    DoLog("Volkswagen Type 2 1966 f3");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 99;
                    maxspeed = 50;
                    grip = 50;
                    weight = 1070;
                    break;
                case 1430:
                    DoLog("Volkswagen I.D. R Pikes Peak 2018 s30");
                    clearance = 1;
                    tires = 4;
                    drive = 4;
                    acceleration = 2.2;
                    maxspeed = 149;
                    grip = 92;
                    weight = 1100;
                    break;
                case 1431:
                    DoLog("Volkswagen Golf GTI W12 2007 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.5;
                    maxspeed = 202;
                    grip = 84;
                    weight = 1600;
                    break;
                case 1432:
                    DoLog("Volkswagen W12 Nardo 2001 s29");
                    clearance = 1;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.5;
                    maxspeed = 222;
                    grip = 87;
                    weight = 1200;
                    break;
                case 1433:
                    DoLog("Volkswagen Golf R400 2015 s27");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 3.7;
                    maxspeed = 174;
                    grip = 82;
                    weight = 1515;
                    break;
                case 1434:
                    DoLog("Volvo V60 Polestar 2015 a25");
                    clearance = 2;
                    tires = 2;
                    drive = 4;
                    acceleration = 4.8;
                    maxspeed = 155;
                    grip = 84;
                    weight = 1834;
                    break;
                case 1435:
                    DoLog("Volvo 850 BTCC 1994 a24");
                    clearance = 1;
                    tires = 1;
                    drive = 1;
                    acceleration = 4;
                    maxspeed = 150;
                    grip = 95;
                    weight = 975;
                    break;
                case 1436:
                    DoLog("Volvo XC90 T8 Twin Engine 2016 a25");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 5.6;
                    maxspeed = 140;
                    grip = 78;
                    weight = 2343;
                    break;
                case 1437:
                    DoLog("Volvo XC90 V8 2010 b19");
                    clearance = 3;
                    tires = 4;
                    drive = 4;
                    acceleration = 7.8;
                    maxspeed = 130;
                    grip = 70;
                    weight = 2102;
                    break;
                case 1438:
                    DoLog("Volvo C70 T5 2013 c15");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 6.9;
                    maxspeed = 149;
                    grip = 73;
                    weight = 1711;
                    break;
                case 1439:
                    DoLog("Volvo 850 AWD 1997 c18");
                    clearance = 2;
                    tires = 3;
                    drive = 4;
                    acceleration = 7.2;
                    maxspeed = 137;
                    grip = 73;
                    weight = 1575;
                    break;
                case 1440:
                    DoLog("Volvo 850 R 1997 c16");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.5;
                    maxspeed = 155;
                    grip = 81;
                    weight = 1545;
                    break;
                case 1441:
                    DoLog("Volvo C30 T5 R-Design 2008 c16");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 6.4;
                    maxspeed = 149;
                    grip = 79;
                    weight = 1429;
                    break;
                case 1442:
                    DoLog("Volvo C70 T5 2.3 2003 d14");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 6.9;
                    maxspeed = 149;
                    grip = 70;
                    weight = 1544;
                    break;
                case 1443:
                    DoLog("Volvo 850 T-5R 1995 d14");
                    clearance = 2;
                    tires = 2;
                    drive = 1;
                    acceleration = 7.2;
                    maxspeed = 140;
                    grip = 81;
                    weight = 1450;
                    break;
                case 1444:
                    DoLog("Volvo 740 Turbo 1990 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 7.9;
                    maxspeed = 124;
                    grip = 63;
                    weight = 1269;
                    break;
                case 1445:
                    DoLog("Volvo 480 Turbo 1988 e9");
                    clearance = 2;
                    tires = 3;
                    drive = 1;
                    acceleration = 8.5;
                    maxspeed = 124;
                    grip = 67;
                    weight = 1040;
                    break;
                case 1446:
                    DoLog("Volvo 240 GLT 1988 f6");
                    clearance = 2;
                    tires = 3;
                    drive = 2;
                    acceleration = 9.4;
                    maxspeed = 112;
                    grip = 60;
                    weight = 1393;
                    break;                

                default:
                    DoLog("Неизвестная тачка");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 30;
                    maxspeed = 100;
                    grip = 75;
                    weight = 1500;
                    break;
            }

            double[] stats = { clearance, tires, drive, acceleration, maxspeed, grip, weight};
            return stats;
        }
    }
}