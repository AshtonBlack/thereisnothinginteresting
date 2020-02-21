using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace BotForDima
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Opacity = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0); //локация формы(невидимая)
            
            Loading();

            BranchClubs();

            Application.Exit();
        }

        [DllImport("User32.dll")]
        public static extern void mouse_event(int dsFlag, int x, int y, int cButton, int dsExtraInfo);

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

        public const int MOUSEEVENTF_LEFTDOWN = 0X02;
        public const int MOUSEEVENTF_LEFTUP = 0X04;

        static void DoMouseLeftClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        public void MoveMouse(int x, int y)
        {
            POINT p = new POINT();
            p.x = x;
            p.y = y;
            ClientToScreen(Handle, ref p);
            SetCursorPos(p.x, p.y);
        }

        public void Clk(int dox, int doy)
        {
            MoveMouse(dox, doy);
            Thread.Sleep(200);
            DoMouseLeftClick(dox, doy);
            Thread.Sleep(100);
        }

        public void Clk1(Point p)
        {
            int dox = p.X;
            int doy = p.Y;
            MoveMouse(dox, doy);
            Thread.Sleep(200);
            DoMouseLeftClick(dox, doy);
            Thread.Sleep(100);
        }

        public void LMBdown(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
        }

        public void LMBup(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
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

        public void DragnDrop(Point xy1, Point xy2)
        {
            SpecialEvents se = new SpecialEvents();
            bool criterror = false;
            int error = 0;
            int dox1 = xy1.X;
            int doy1 = xy1.Y;
            int dox2 = xy2.X;
            int doy2 = xy2.Y;
            string x1;
            string x2;
            do
            {
                if (error == 3)
                {
                    Clk(1205, 210);
                    Thread.Sleep(500);
                    criterror = true;
                    break;
                }
                x1 = MasterOfPictures.PixelIndicator(xy1);
                MoveMouse(dox1, doy1);
                Thread.Sleep(100);
                mouse_event(MOUSEEVENTF_LEFTDOWN, dox1, doy1, 0, 0);
                Thread.Sleep(1000);
                MoveMouse(dox2, doy2);
                Thread.Sleep(2500);
                mouse_event(MOUSEEVENTF_LEFTUP, dox2, doy2, 0, 0);
                Thread.Sleep(500);
                x2 = MasterOfPictures.PixelIndicator(xy1);
                error++;
            } while (x1 == x2);

            if (criterror == true)
            {
                se.RestartBot();
            }
        }

        public int DragnDpopHand(int n, int uhl)
        {
            FastCheck fc = new FastCheck();
            HandMaking hm = new HandMaking();
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
            int newN;
            int x = 0;
            int h = 0;
            int drag = 0;
            int usefullcars = 0;
            for (int number = 0; number < 6; number++)//для начала научимся проверять первые 6 слотов
            {
                if (!fc.EmptyGarageSlot(number)) break;//не удается отладить проверку далее 6 слота
                else usefullcars = number + 1;
            }
            NotePad.DoLog("Подходят " + usefullcars + " авто");
            if (n > usefullcars)
            {
                newN = usefullcars;
                emptyCars = n - usefullcars;
            }
            else
            {
                newN = n;
            }

            while (x < newN) //x имеет значение и при нуле
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

                if (hm.CarFixed(x))
                {
                    NotePad.DoLog("Тачка " + (x + 1) + " исправна");
                    while (!fc.ItsGarage()) Thread.Sleep(2000);
                    DragnDropGarage(b[x], a[h + uhl]);
                    x++;
                    h++;
                }
                else
                {
                    NotePad.DoLog("Тачка " + x + " не готова");
                    x++;
                    newN++;
                }
            }

            return emptyCars;
        }

        public void SlowDragnDrop(Point xy1, Point xy2)
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

        private void Loading()//for dima
        {
            Waiting wait = new Waiting();
            NotePad.ClearLog();
            Process.Start(@"C:\Program Files (x86)\Nox\bin\Nox.exe", "-clone:Nox_0");

            Thread.Sleep(10000);

            wait.StartIcon();//for dima

            Clk(1000, 300);//Icon for dima

            Thread.Sleep(10000);

            wait.StartButton();//for dima

            Clk(480, 580);//Start game for dima

            Thread.Sleep(3000);

        }

        private void BranchClubs()
        {
            SpecialEvents se = new SpecialEvents();
            FastCheck fc = new FastCheck();
            ChooseEvent ce = new ChooseEvent();
            Waiting wait = new Waiting();
            wait.HeadPage();//for dima

            Clk(800, 300);//Events for dima

            wait.EventPage();//for dima

            Clk(400, 420);//Clubs for dima

            Thread.Sleep(15000);

            wait.ClubMap();//for dima

            se.DragMap();//for dima

            while (true)
            {
                Thread.Sleep(2000);
                int i = 0;
                /*
                if (fc.ActiveEvent())
                {
                    NotePad.DoLog("вхожу в активный эвент");
                    i = 1;
                    Clk(1060, 800);
                    int[] a = NotePad.ReadSaves();
                    int[] b = new int[5];
                    Array.Copy(a, 3, b, 0, 5);
                    while (i < 100)
                    {
                        i++;
                        if (!PlayClubs(a[0], a[1], a[2], b, i)) break;
                    }
                }
                */
                /*
                else
                {
                    */
                    NotePad.DoLog("Подбираю эвент с одним условием");
                /*
                    int condition = ce.ChooseNormalEvent();
                    NotePad.DoLog("Вычисляю РК эвента");
                    int rq = ce.GotRQ();
                    int eventname = ce.WhichEvent();
                */
                /*
                    NotePad.DoLog("Вхожу в эвент  " + rq + " рк");
                    Clk(1060, 800);//ClubEventEnter   
                
                    while (i < 100)
                    {
                        int[] b = { 0, 0, 0, 0, 0 };
                        i++;
                        if (!PlayClubs(rq, condition, eventname, b, i)) break;
                    }
                    */
                    Thread.Sleep(2000);
                /*
                }
            */
            }

        }

        private bool PlayClubs(int rq, int condition, int eventname, int[] b, int i)
        {
            SpecialEvents se = new SpecialEvents();
            Waiting wait = new Waiting();
            FastCheck fc = new FastCheck();
            PlayClubsPositions pcp = new PlayClubsPositions();

            bool eventisactive = pcp.PathToGarage();
            if (eventisactive)
            {
                pcp.PrepareToRace(rq, condition, eventname, i);
                wait.ReadytoRace();
                Clk(1120, 800);//GarageRaceButton
                Thread.Sleep(3000);

                bool foundplace = false;
                do
                {
                    se.UniversalErrorDefense();
                    se.UnavailableEvent();

                    if (fc.EnemyIsReady())
                    {
                        eventisactive = true;
                        foundplace = true;
                        Thread.Sleep(1000);
                    }

                    if (fc.Bounty())
                    {
                        NotePad.DoLog("эвент закончен");
                        eventisactive = false;
                        foundplace = true;
                        Thread.Sleep(1000);
                    }

                    if (fc.ClubMap())
                    {
                        NotePad.DoLog("эвент закончен");
                        eventisactive = false;
                        foundplace = true;
                        Thread.Sleep(1000);
                    }
                } while (foundplace == false);//ожидание противника

                if (eventisactive)
                {
                    pcp.TimeToRace();

                    Thread.Sleep(5000);
                    Clk(640, 215); //кнопка "пропустить"
                    Thread.Sleep(4000);
                    Clk(890, 625);//подтвержение "пропуска"
                    Thread.Sleep(5000);
                    Clk(635, 570);//звезды  

                    foundplace = false;
                    do
                    {
                        se.UniversalErrorDefense();

                        if (fc.Upgrade())
                        {
                            NotePad.DoLog("реклама на апгрейд");
                            se.UpgradeAdsKiller();
                            Thread.Sleep(1000);
                        }

                        if (fc.Ending())
                        {
                            Clk(820, 730);//Table
                            Thread.Sleep(1000);
                        }

                        if (fc.Bounty())
                        {
                            eventisactive = false;
                            foundplace = true;
                            Thread.Sleep(1000);
                        }

                        if (fc.ControlScreen())
                        {
                            foundplace = true;
                            Thread.Sleep(1000);
                        }

                        if (fc.ClubMap())
                        {
                            eventisactive = false;
                            foundplace = true;
                            Thread.Sleep(1000);
                        }
                    } while (foundplace == false);//переход на экран контроля
                }
            }

            return eventisactive;
        }
    }

    public class PlayClubsPositions
    {
        public bool PathToGarage()
        {
            Form1 f1 = new Form1();
            FastCheck fc = new FastCheck();
            bool positionflag = false;
            bool continuegame = false;
            do
            {
                if (fc.Bounty())
                {
                    NotePad.DoLog("получил награду");
                    positionflag = true;
                }

                if (fc.ClubMap())
                {
                    Thread.Sleep(2000);

                    if (fc.ClubMap())
                    {
                        NotePad.DoLog("выкинуло на карту");
                        positionflag = true;
                    }
                }

                if (fc.EventEnds())
                {
                    NotePad.DoLog("эвент окончен");
                    f1.Clk(640, 590);//Accept Message                    
                    Thread.Sleep(3000);
                    positionflag = true;
                }

                if (fc.ControlScreen())
                {
                    Thread.Sleep(2000);
                    NotePad.DoLog("Перехожу в гараж");
                    f1.Clk(820, 790);//Play
                    Thread.Sleep(1000);
                }

                if (fc.ItsGarage())
                {
                    positionflag = true;
                    NotePad.DoLog("Нахожусь в гараже");
                    continuegame = true;
                }
            } while (!positionflag);

            return continuegame;
        }

        public void PrepareToRace(int rq, int condition, int eventname, int i)
        {
            SpecialEvents se = new SpecialEvents();
            HandMaking hm = new HandMaking();
            NotePad.DoLog("Rq = " + rq + ", условие: " + condition + ", название эвента: " + eventname + " заезд: " + i);

            int wronghandnumber = 0;//счетчик неправильного сбора руки
            do
            {
                if (wronghandnumber == 3)
                {
                    se.RestartBot();
                }
                else
                {
                    wronghandnumber++;

                    if (i == 1)
                    {
                        se.ClearHand();
                        Thread.Sleep(500);
                        NotePad.DoLog("Собираю пробную руку");
                        string weather = "с прояснением";
                        hm.MakingHandwith1Condition(rq, condition, eventname, weather);
                    }

                    if (i == 2)//пересборка по покрытию
                    {
                        if (eventname == 1 ||
                            eventname == 3 ||
                            eventname == 4 ||
                            eventname == 5 ||
                            eventname == 8 ||
                            eventname == 9 ||
                            eventname == 10 ||
                            eventname == 11 ||
                            eventname == 12 ||
                            eventname == 13 ||
                            eventname == 15 ||
                            eventname == 17 ||
                            eventname == 18)
                        {
                            if (condition != 34 //недостаточное разнообразие покрышек
                                && condition != 29
                                && condition != 8
                                && condition != 24
                                && condition != 22
                                && condition != 20
                                && condition != 21
                                && condition != 4
                                && condition != 18
                                && condition != 15
                                && condition != 14
                                && condition != 13
                                && condition != 12
                                && condition != 39
                                && condition != 44
                                && condition != 45
                                && condition != 46
                                && condition != 47
                                && condition != 48)
                            {
                                if (NotePad.FindWeather() != "с прояснениями")
                                {
                                    if (rq > 29)
                                    {
                                        se.ClearHand();
                                        Thread.Sleep(500);
                                        NotePad.DoLog("Меняю руку с учетом покрытия");
                                        string weather = NotePad.FindWeather();
                                        hm.MakingHandwith1Condition(rq, condition, eventname, weather);
                                    }
                                }
                            }

                        }
                    }

                    if (!hm.HandCarFixed() || !hm.VerifyHand())
                    {
                        se.ClearHand();
                        Thread.Sleep(500);
                        NotePad.DoLog("Меняю руку");
                        string weather = NotePad.FindWeather();
                        hm.MakingHandwith1Condition(rq, condition, eventname, weather);
                    }
                }
            } while (!hm.VerifyHand() || !hm.VerifyHand());

        }

        public void TimeToRace()
        {
            Form1 f1 = new Form1();
            Waiting wait = new Waiting();
            TrackInfo ti = new TrackInfo();
            GrandArrangement ga = new GrandArrangement();

            int[] a1 = ti.Tracks();//Track info
            int[] b1 = ti.Grounds();//Ground info
            int[] c1 = ti.Weathers();//Weather info

            f1.Clk(640, 705);//ChooseanEnemy
            NotePad.DoLog("противник выбран");
            Thread.Sleep(1000);
            wait.ArrangementWindow();
            NotePad.DoLog("загрузился экран расстановки");
            Thread.Sleep(1000);
            ga.Arrangement(a1, b1, c1);
            wait.RaceOn();
            Thread.Sleep(2000);
            f1.Clk(180, 580); //ускорить заезд, клик в пусой области
            wait.RaceOff();
        }
    }

    public class SpecialEvents
    {
        Form1 f1 = new Form1();

        public void UpgradeAdsKiller()
        {
            NotePad.DoLog("Смотрю рекламу на прокачку");
            f1.Clk(965, 745); //ИСПРАВИТЬ
            Thread.Sleep(3000);
        }
                
        public void DragMap()//for dima
        {
            FastCheck fc = new FastCheck();
            fc.Bounty();
            f1.MoveMouse(1010, 650);
            Thread.Sleep(100);
            f1.LMBdown(1010, 650);
            Thread.Sleep(2000);
            for (int drag = 1010; drag > 270; drag -= 8)
            {
                f1.MoveMouse(drag, 650);
                Thread.Sleep(60);
            }
            Thread.Sleep(1000);
            f1.MoveMouse(270, 650);
            Thread.Sleep(2000);
            f1.LMBup(270, 650);
            Thread.Sleep(1000);
        }

        public void RestartBot()
        {
            f1.Clk(1230, 150);//close Nox
            Thread.Sleep(1000);
            f1.Clk(670, 560);// accept Nox close
            Thread.Sleep(2000);

            Process.Start(@"C:\Bot\BotRestarter\BotRestarter\bin\Debug\BotRestarter.exe");
        }

        public void UniversalErrorDefense()
        {
            FastCheck fc = new FastCheck();
            if (fc.ServerError())
            {
                Thread.Sleep(5000);
                if (fc.ServerError())
                {
                    RestartBot();
                }
            }
        }

        public void ClearHand()
        {
            Point HandSlot1 = new Point(160, 775);
            Point HandSlot2 = new Point(355, 775);
            Point HandSlot3 = new Point(545, 775);
            Point HandSlot4 = new Point(740, 775);
            Point HandSlot5 = new Point(930, 775);

            Point[] a = new Point[] { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };
            for (int i = 0; i < 5; i++)
            {
                f1.MoveMouse(a[i].X, a[i].Y);
                Thread.Sleep(100);
                f1.LMBdown(a[i].X, a[i].Y);
                Thread.Sleep(1500);
                for (int l = a[i].Y; l > 500; l -= 10)
                {
                    f1.MoveMouse(a[i].X, l);
                    Thread.Sleep(80);
                }
                Thread.Sleep(1000);
                f1.MoveMouse(a[i].X, 500);
                Thread.Sleep(2000);
                f1.LMBup(a[i].X, 500);
                Thread.Sleep(1000);
            }
        }

        public bool UnavailableEvent()
        {
            FastCheck fc = new FastCheck();
            bool x = true;

            if (fc.EventEnds())
            {
                NotePad.DoLog("эвент окончен");
                f1.Clk(640, 590);//Accept Message
                Thread.Sleep(3000);
                x = false;
            }

            if (fc.EventisFull())
            {
                NotePad.DoLog("эвент заполнен");
                f1.Clk(645, 575);//Accept Message

                if (fc.ItsGarage())
                {
                    f1.Clk(85, 215);//back
                    Thread.Sleep(2000);
                    f1.Clk(85, 215);//back to club map
                }
                Thread.Sleep(3000);
                x = false;
            }
            return x;
        }
    }

    public class TrackInfo
    {
        public int[] Tracks()
        {
            Rectangle Track1 = new Rectangle(150, 525, 165, 35);
            Rectangle Track2 = new Rectangle(355, 525, 165, 35);
            Rectangle Track3 = new Rectangle(555, 525, 165, 35);
            Rectangle Track4 = new Rectangle(760, 525, 165, 35);
            Rectangle Track5 = new Rectangle(965, 525, 165, 35);

            int n;
            bool flag;
            Rectangle[] a = { Track1, Track2, Track3, Track4, Track5 };
            int[] a1 = new int[5];

            for (int i = 0; i < 5; i++)
            {
                flag = true;
                MasterOfPictures.TrackCapture(a[i], ("Track" + (i + 1) + "\\test"));
                n = 0;
                for (int i1 = 1; i1 < 100; i1++)
                {
                    if (File.Exists("C:\\Bot\\Track" + (i + 1) + "\\" + i1 + ".jpg"))
                    {
                        n = i1;
                    }
                    else break;
                }

                for (int i2 = 1; i2 < (n + 1); i2++)
                {
                    if (MasterOfPictures.VerifyBW(("Track" + (i + 1) + "\\" + i2), ("Track" + (i + 1) + "\\test"), 120))
                    {
                        a1[i] = i2;
                        File.Delete("C:\\Bot\\Track" + (i + 1) + "\\test.jpg");
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    a1[i] = 0;
                    NotePad.DoLog("Добавляю новый трэк");
                    File.Move("C:\\Bot\\Track" + (i + 1) + "\\test.jpg", "C:\\Bot\\Track" + (i + 1) + "\\" + (n + 1) + ".jpg");
                }
            }

            return a1;
        }

        public int[] Grounds()
        {
            Rectangle Ground1 = new Rectangle(198, 605, 115, 30);
            Rectangle Ground2 = new Rectangle(401, 605, 115, 30);
            Rectangle Ground3 = new Rectangle(605, 605, 115, 30);
            Rectangle Ground4 = new Rectangle(808, 605, 115, 30);
            Rectangle Ground5 = new Rectangle(1013, 605, 115, 30);

            Rectangle[] b = { Ground1, Ground2, Ground3, Ground4, Ground5 };
            int n;
            bool flag;
            int[] b1 = new int[5];
            for (int i = 0; i < 5; i++)
            {
                flag = true;
                MasterOfPictures.BW2Capture(b[i], ("Ground" + (i + 1) + "\\test"));
                n = 0;
                for (int i1 = 1; i1 < 100; i1++)
                {
                    if (File.Exists("C:\\Bot\\Ground" + (i + 1) + "\\" + i1 + ".jpg"))
                    {
                        n = i1;
                    }
                    else break;
                }

                for (int i2 = 1; i2 < (n + 1); i2++)
                {
                    if (MasterOfPictures.VerifyBW(("Ground" + (i + 1) + "\\" + i2), ("Ground" + (i + 1) + "\\test"), 150))
                    {
                        b1[i] = i2;
                        File.Delete("C:\\Bot\\Ground" + (i + 1) + "\\test.jpg");
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    b1[i] = 0;
                    NotePad.DoLog("Добавляю новое покрытие");
                    File.Move("C:\\Bot\\Ground" + (i + 1) + "\\test.jpg", "C:\\Bot\\Ground" + (i + 1) + "\\" + (n + 1) + ".jpg");
                }
            }

            return b1;
        }

        public int[] Weathers()
        {
            Rectangle Weather1 = new Rectangle(198, 562, 75, 34);
            Rectangle Weather2 = new Rectangle(401, 562, 75, 34);
            Rectangle Weather3 = new Rectangle(605, 562, 75, 34);
            Rectangle Weather4 = new Rectangle(808, 562, 75, 34);
            Rectangle Weather5 = new Rectangle(1013, 562, 75, 34);

            Rectangle[] c = { Weather1, Weather2, Weather3, Weather4, Weather5 };
            int n;
            bool flag;
            int[] c1 = new int[5];

            for (int i = 0; i < 5; i++)
            {
                flag = true;
                MasterOfPictures.BW2Capture(c[i], ("Weather" + (i + 1) + "\\test"));
                n = 0;
                for (int i1 = 1; i1 < 10; i1++)
                {
                    if (File.Exists("C:\\Bot\\Weather" + (i + 1) + "\\" + i1 + ".jpg"))
                    {
                        n = i1;
                    }
                    else break;
                }

                for (int i2 = 1; i2 < (n + 1); i2++)
                {
                    if (MasterOfPictures.VerifyBW(("Weather" + (i + 1) + "\\" + i2), ("Weather" + (i + 1) + "\\test"), 30))
                    {
                        c1[i] = i2;
                        File.Delete("C:\\Bot\\Weather" + (i + 1) + "\\test.jpg");
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    c1[i] = 0;
                    NotePad.DoLog("Добавляю новую погоду");
                    File.Move("C:\\Bot\\Weather" + (i + 1) + "\\test.jpg", "C:\\Bot\\Weather" + (i + 1) + "\\" + (n + 1) + ".jpg");
                }
            }

            return c1;
        }

        public string[,] TrackPackage(string[] a2, string[] b2, string[] c2)//for dima
        {
            string[,] d = new string[3, 5];
            for (int i = 0; i < 5; i++)
            {
                d[0, i] = a2[i];
                d[1, i] = b2[i];
                d[2, i] = c2[i];
            }
            for (int i = 0; i < 5; i++)
            {
                NotePad.DoLog((i + 1) + " Трэк: " + d[0, i] + " " + d[1, i] + " " + d[2, i]);
            }

            return d;
        }

        public string[] IdentifyGround(int[] b1)//for dima
        {
            string[] b2 = new string[5];
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        switch (b1[i])
                        {                            
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                    case 1:
                        switch (b1[i])
                        {
                           
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                    case 2:
                        switch (b1[i])
                        {
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                    case 3:
                        switch (b1[i])
                        {                            
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                    case 4:
                        switch (b1[i])
                        {                            
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                }
            }
            return b2;
        }

        public string[] IdentifyWeather(int[] c1)//for dima
        {
            string[] c2 = new string[5];
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        switch (c1[i])
                        {                            
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
                    case 1:
                        switch (c1[i])
                        {                            
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
                    case 2:
                        switch (c1[i])
                        {                            
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
                    case 3:
                        switch (c1[i])
                        {                           
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
                    case 4:
                        switch (c1[i])
                        {                            
                            default:
                                c2[i] = "неопределенная погода";
                                break;
                        }
                        break;
                }
            }

            bool dry = false;
            bool wet = false;

            foreach (string x in c2)
            {
                if (x == "Дождь")
                {
                    wet = true;
                }

                if (x == "Солнечно")
                {
                    dry = true;
                }
            }

            string weather = "солнечно";
            if (wet)
            {
                if (dry) weather = "с прояснениями";
                else weather = "мокро";
            }
            NotePad.LastWeather(weather);

            return c2;
        }

        public string[] IdentifyTracks(int[] a1)//for dima
        {
            string[] a2 = new string[5];
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        switch (a1[i])
                        {
                            case 1:
                                a2[i] = "Улица мал";
                                break;
                            case 2:
                                a2[i] = "Лесной слалом";
                                break;
                            case 3:
                                a2[i] = "0-100";
                                break;
                            case 4:
                                a2[i] = "1/2";
                                break;
                            case 5:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 6:
                                a2[i] = "Серпантин";
                                break;
                            case 7:
                                a2[i] = "Слалом";
                                break;
                            case 8:
                                a2[i] = "Подъем на холм";
                                break;
                            case 9:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 10:
                                a2[i] = "1";
                                break;
                            case 11:
                                a2[i] = "0-100-0";
                                break;
                            case 12:
                                a2[i] = "Парковка";
                                break;
                            case 13:
                                a2[i] = "Улица ср";
                                break;
                            case 14:
                                a2[i] = "Highway";
                                break;
                            case 15:
                                a2[i] = "Перегрузка";
                                break;
                            case 16:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 17:
                                a2[i] = "Тестовый круг";
                                break;
                            case 18:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 19:
                                a2[i] = "Мотокросс";
                                break;
                            case 20:
                                a2[i] = "Токио тест на перегрузки";
                                break;
                            case 21:
                                a2[i] = "Токио петля";
                                break;
                            case 22:
                                a2[i] = "Каньон экспедиция";
                                break;
                            case 23:
                                a2[i] = "Обзор";
                                break;
                            case 24:
                                a2[i] = "Лесная дорога";
                                break;
                            case 25:
                                a2[i] = "Трасса набережная";
                                break;
                            case 26:
                                a2[i] = "Токио мостик";
                                break;
                            case 27:
                                a2[i] = "Токио трасса";
                                break;
                            case 28:
                                a2[i] = "Токио мост";
                                break;
                            case 29:
                                a2[i] = "Ралли-кросс мал";
                                break;
                            case 30:
                                a2[i] = "Монако городские";
                                break;
                            case 31:
                                a2[i] = "Монако серпантин";
                                break;
                            case 32:
                                a2[i] = "Ралли-кросс ср";
                                break;
                            case 33:
                                a2[i] = "Каньон крутой холм";
                                break;
                            case 34:
                                a2[i] = "Лесная переправа";
                                break;
                            case 35:
                                a2[i] = "Монако узкие улицы";
                                break;
                            case 36:
                                a2[i] = "Горная экспедиция";
                                break;
                            case 37:
                                a2[i] = "Горы извилистая дорога";
                                break;
                            case 38:
                                a2[i] = "Нюрбург 1";
                                break;
                            case 39:
                                a2[i] = "Горы извилистая дорога";
                                break;
                            case 40:
                                a2[i] = "Горы слалом";
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
                                a2[i] = "0-100";
                                break;
                            case 2:
                                a2[i] = "1/2";
                                break;
                            case 3:
                                a2[i] = "Лесная дорога";
                                break;
                            case 4:
                                a2[i] = "Лесной слалом";
                                break;
                            case 5:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 6:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 7:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 8:
                                a2[i] = "Улица мал";
                                break;
                            case 9:
                                a2[i] = "Улица ср";
                                break;
                            case 10:
                                a2[i] = "1";
                                break;
                            case 11:
                                a2[i] = "Мотокросс";
                                break;
                            case 12:
                                a2[i] = "Слалом";
                                break;
                            case 13:
                                a2[i] = "Перегрузка";
                                break;
                            case 14:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 15:
                                a2[i] = "Серпантин";
                                break;
                            case 16:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 17:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 18:
                                a2[i] = "Слалом";
                                break;
                            case 19:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 20:
                                a2[i] = "Замерзшее озеро";
                                break;
                            case 21:
                                a2[i] = "Подъем на холм";
                                break;
                            case 22:
                                a2[i] = "0-100-0";
                                break;
                            case 23:
                                a2[i] = "Тестовый круг";
                                break;
                            case 24:
                                a2[i] = "Ралли-кросс мал";
                                break;
                            case 25:
                                a2[i] = "Токио тест на перегрузки";
                                break;
                            case 26:
                                a2[i] = "Токио мост";
                                break;
                            case 27:
                                a2[i] = "Каньон грунтовая дорога";
                                break;
                            case 28:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 29:
                                a2[i] = "Грунтовая дорога";
                                break;
                            case 30:
                                a2[i] = "1/2";
                                break;
                            case 31:
                                a2[i] = "Токио съезд";
                                break;
                            case 32:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 33:
                                a2[i] = "Highway";
                                break;
                            case 34:
                                a2[i] = "Подъем на холм";
                                break;
                            case 35:
                                a2[i] = "Монако тест на перегрузки";
                                break;
                            case 36:
                                a2[i] = "Монако серпантин";
                                break;
                            case 37:
                                a2[i] = "Парковка";
                                break;
                            case 38:
                                a2[i] = "Монако узкие улицы";
                                break;
                            case 39:
                                a2[i] = "Трасса набережная";
                                break;
                            case 40:
                                a2[i] = "Перегрузка";
                                break;
                            case 41:
                                a2[i] = "Ралли-кросс ср";
                                break;
                            case 42:
                                a2[i] = "Замерзшее озеро";
                                break;
                            case 43:
                                a2[i] = "Лесная переправа";
                                break;
                            case 44:
                                a2[i] = "Горы слалом";
                                break;
                            case 45:
                                a2[i] = "Нюрбург 2";
                                break;
                            case 46:
                                a2[i] = "Горы серпантин";
                                break;
                            case 47:
                                a2[i] = "Горы извилистая дорога";
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
                                a2[i] = "Перегрузка";
                                break;
                            case 2:
                                a2[i] = "Лесная дорога";
                                break;
                            case 3:
                                a2[i] = "Лесной слалом";
                                break;
                            case 4:
                                a2[i] = "Серпантин";
                                break;
                            case 5:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 6:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 7:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 8:
                                a2[i] = "1/2";
                                break;
                            case 9:
                                a2[i] = "Слалом";
                                break;
                            case 10:
                                a2[i] = "Подъем на холм";
                                break;
                            case 11:
                                a2[i] = "1";
                                break;
                            case 12:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 13:
                                a2[i] = "Улица мал";
                                break;
                            case 14:
                                a2[i] = "Парковка";
                                break;
                            case 15:
                                a2[i] = "Слалом";
                                break;
                            case 16:
                                a2[i] = "Улица ср";
                                break;
                            case 17:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 18:
                                a2[i] = "Highway";
                                break;
                            case 19:
                                a2[i] = "0-100-0";
                                break;
                            case 20:
                                a2[i] = "Токио тест на перегрузки";
                                break;
                            case 21:
                                a2[i] = "0-100";
                                break;
                            case 22:
                                a2[i] = "1/4";
                                break;
                            case 23:
                                a2[i] = "Тестовый круг";
                                break;
                            case 24:
                                a2[i] = "Токио мост";
                                break;
                            case 25:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 26:
                                a2[i] = "Крутой холм";
                                break;
                            case 27:
                                a2[i] = "Грунтовая дорога";
                                break;
                            case 28:
                                a2[i] = "Монако узкие улицы";
                                break;
                            case 29:
                                a2[i] = "75-125";
                                break;
                            case 30:
                                a2[i] = "Мотокросс";
                                break;
                            case 31:
                                a2[i] = "Токио мостик";
                                break;
                            case 32:
                                a2[i] = "Трасса набережная";
                                break;
                            case 33:
                                a2[i] = "Ралли-кросс мал";
                                break;
                            case 34:
                                a2[i] = "Ралли-кросс ср";
                                break;
                            case 35:
                                a2[i] = "Монако длинные городские улицы";
                                break;
                            case 36:
                                a2[i] = "Каньон грунтовая дорога";
                                break;
                            case 37:
                                a2[i] = "Лесная переправа";
                                break;
                            case 38:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 39:
                                a2[i] = "Монако городские";
                                break;
                            case 40:
                                a2[i] = "Горы слалом";
                                break;
                            case 41:
                                a2[i] = "Нюрбург 3";
                                break;
                            case 42:
                                a2[i] = "1/4";
                                break;
                            case 43:
                                a2[i] = "Горы извилистая дорога";
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
                                a2[i] = "Лесной слалом";
                                break;
                            case 3:
                                a2[i] = "1/4";
                                break;
                            case 4:
                                a2[i] = "Лесная дорога";
                                break;
                            case 5:
                                a2[i] = "Перегрузка";
                                break;
                            case 6:
                                a2[i] = "Слалом";
                                break;
                            case 7:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 8:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 9:
                                a2[i] = "1";
                                break;
                            case 10:
                                a2[i] = "Улица мал";
                                break;
                            case 11:
                                a2[i] = "Замерзшее озеро";
                                break;
                            case 12:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 13:
                                a2[i] = "Серпантин";
                                break;
                            case 14:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 15:
                                a2[i] = "Парковка";
                                break;
                            case 16:
                                a2[i] = "0-100-0";
                                break;
                            case 17:
                                a2[i] = "Слалом";
                                break;
                            case 18:
                                a2[i] = "Тестовый круг";
                                break;
                            case 19:
                                a2[i] = "1/2";
                                break;
                            case 20:
                                a2[i] = "Ралли-кросс ср";
                                break;
                            case 21:
                                a2[i] = "Токио петля";
                                break;
                            case 22:
                                a2[i] = "Подъем на холм";
                                break;
                            case 23:
                                a2[i] = "Токио съезд";
                                break;
                            case 24:
                                a2[i] = "Токио тест на перегрузки";
                                break;
                            case 25:
                                a2[i] = "Каньон экспедиция";
                                break;
                            case 26:
                                a2[i] = "0-100";
                                break;
                            case 27:
                                a2[i] = "Грунтовая дорога";
                                break;
                            case 28:
                                a2[i] = "Лесная дорога";
                                break;
                            case 29:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 30:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 31:
                                a2[i] = "Токио трасса";
                                break;
                            case 32:
                                a2[i] = "Монако серпантин";
                                break;
                            case 33:
                                a2[i] = "Трасса набережная";
                                break;
                            case 34:
                                a2[i] = "Монако узкие улицы";
                                break;
                            case 35:
                                a2[i] = "Мотокросс";
                                break;
                            case 36:
                                a2[i] = "75-125";
                                break;
                            case 37:
                                a2[i] = "Слалом";
                                break;
                            case 38:
                                a2[i] = "Перегрузка";
                                break;
                            case 39:
                                a2[i] = "Горы серпантин";
                                break;
                            case 40:
                                a2[i] = "Нюрбург 4";
                                break;
                            case 41:
                                a2[i] = "Горы слалом";
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
                                a2[i] = "1/2";
                                break;
                            case 2:
                                a2[i] = "Серпантин";
                                break;
                            case 3:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 4:
                                a2[i] = "Извилистая дорога";
                                break;
                            case 5:
                                a2[i] = "Лесная дорога";
                                break;
                            case 6:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 7:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 8:
                                a2[i] = "Улица ср";
                                break;
                            case 9:
                                a2[i] = "Улица мал";
                                break;
                            case 10:
                                a2[i] = "Подъем на холм";
                                break;
                            case 11:
                                a2[i] = "Тестовый круг";
                                break;
                            case 12:
                                a2[i] = "0-100-0";
                                break;
                            case 13:
                                a2[i] = "Парковка";
                                break;
                            case 14:
                                a2[i] = "50-150";
                                break;
                            case 15:
                                a2[i] = "1";
                                break;
                            case 16:
                                a2[i] = "Highway";
                                break;
                            case 17:
                                a2[i] = "Слалом";
                                break;
                            case 18:
                                a2[i] = "Перегрузка";
                                break;
                            case 19:
                                a2[i] = "Перегрузка";
                                break;
                            case 20:
                                a2[i] = "Токио мост";
                                break;
                            case 21:
                                a2[i] = "Закрытый картинг";
                                break;
                            case 22:
                                a2[i] = "Слалом";
                                break;
                            case 23:
                                a2[i] = "Токио съезд";
                                break;
                            case 24:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 25:
                                a2[i] = "Обзор";
                                break;
                            case 26:
                                a2[i] = "Крутой холм";
                                break;
                            case 27:
                                a2[i] = "Лесной слалом";
                                break;
                            case 28:
                                a2[i] = "Токио трасса";
                                break;
                            case 29:
                                a2[i] = "Быстрая трасса";
                                break;
                            case 30:
                                a2[i] = "Токио петля";
                                break;
                            case 31:
                                a2[i] = "Токио тест на перегрузки";
                                break;
                            case 32:
                                a2[i] = "Монако серпантин";
                                break;
                            case 33:
                                a2[i] = "Монако городские";
                                break;
                            case 34:
                                a2[i] = "Монако тест на перегрузки";
                                break;
                            case 35:
                                a2[i] = "Трасса набережная";
                                break;
                            case 36:
                                a2[i] = "0-100";
                                break;
                            case 37:
                                a2[i] = "Ралли-кросс мал";
                                break;
                            case 38:
                                a2[i] = "Трасса для картинга";
                                break;
                            case 39:
                                a2[i] = "Мотокросс";
                                break;
                            case 40:
                                a2[i] = "Обзор";
                                break;
                            case 41:
                                a2[i] = "Извилистая трасса";
                                break;
                            case 42:
                                a2[i] = "Лесная переправа";
                                break;
                            case 43:
                                a2[i] = "Монако длинные городские улицы";
                                break;
                            case 44:
                                a2[i] = "Лесная переправа";
                                break;
                            case 45:
                                a2[i] = "Подъем на холм";
                                break;
                            case 46:
                                a2[i] = "Горы извилистая дорога";
                                break;
                            case 47:
                                a2[i] = "Горы слалом";
                                break;
                            case 48:
                                a2[i] = "Нюрбург 5";
                                break;
                            case 49:
                                a2[i] = "1";
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

        public int[] TrackRank(string[] a2)//for dima
        {
            int[] a3 = new int[5];
            string[] ar = {"Улица ср",
                            "Улица мал",
                            "Подъем на холм",
                            "Мотокросс",
                            "50-150",
                            "75-125",
                            "0-100",
                            "0-100-0",
                            "1",
                            "1/2",
                            "1/4",
                            "Токио трасса",
                            "Трасса набережная",
                            "Тестовый круг",
                            "Токио мостик",
                            "Нюрбург 1",
                            "Нюрбург 2",
                            "Нюрбург 3",
                            "Нюрбург 4",
                            "Нюрбург 5",
                            "Токио петля",
                            "Горная экспедиция",
                            "Замерзшее озеро",
                            "Горы серпантин",
                            "Горы извилистая дорога",
                            "Извилистая дорога",
                            "Быстрая трасса",
                            "Highway",
                            "Монако длинные городские улицы",
                            "Каньон экспедиция",
                            "Серпантин",
                            "Монако серпантин",
                            "Извилистая трасса",
                            "Токио мост",
                            "Токио съезд",
                            "Монако городские",
                            "Обзор",
                            "Каньон грунтовая дорога",
                            "Грунтовая дорога",
                            "Каньон крутой холм",
                            "Лесная переправа",
                            "Ралли-кросс мал",
                            "Ралли-кросс ср",
                            "Крутой холм",
                            "Лесная дорога",
                            "Монако узкие улицы",
                            "Монако тест на перегрузки",
                            "Токио тест на перегрузки",
                            "Трасса для картинга",
                            "Парковка",
                            "Лесной слалом",
                            "Закрытый картинг",
                            "Горы слалом",
                            "Слалом",
                            "Перегрузка",
                            "Неизвестная трасса"
        };
            for (int i = 0; i < 5; ++i)
            {
                int flag = 0;
                for (int j = 0; j < ar.Length; ++j)
                {
                    if (a2[i] == ar[j])
                    {
                        a3[i] = j + 1;
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    NotePad.DoErrorLog("Исправить название " + a2[i]);
                    a3[i] = 100;
                }
            }
            return a3;
        }
    }

    public class Algorithms//ForDima
    {
        public double CalculateCompatibility(string track, string coverage, string weather, double[] carstats)
        {
            //carstats[0клиренс, 1резина, 2привод, 3разгон до сотки, 4максималка, 5управление, 6масса]
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
                case "Мотокросс":
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
                case "Нюрбург 1":
                    x -= carstats[3] * 60;
                    x += carstats[4] * 3;
                    x += carstats[5];
                    break;
                case "Нюрбург 2":
                    x -= carstats[3] * 60;
                    x += carstats[4] * 3;
                    x += carstats[5];
                    break;
                case "Нюрбург 3":
                    x -= carstats[3] * 60;
                    x += carstats[4] * 3;
                    x += carstats[5];
                    break;
                case "Нюрбург 4":
                    x -= carstats[3] * 60;
                    x += carstats[4] * 3;
                    x += carstats[5];
                    break;
                case "Нюрбург 5":
                    x -= carstats[3] * 60;
                    x += carstats[4] * 3;
                    x += carstats[5];
                    break;
                case "Токио петля":
                    x += carstats[4] * 2;
                    x -= carstats[3] * 80;
                    break;
                case "Замерзшее озеро":
                    break;
                case "Горы серпантин":
                    if (carstats[2] == 4) x += 100;
                    break;
                case "Горы извилистая дорога":
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
                case "Каньон крутой холм":
                    break;
                case "Лесная переправа":
                    break;
                case "Ралли-кросс мал":
                    break;
                case "Ралли-кросс ср":
                    break;
                case "Крутой холм":
                    break;
                case "Лесная дорога":
                    break;
                case "Монако узкие улицы":
                    break;
                case "Монако тест на перегрузки":
                    break;
                case "Токио тест на перегрузки":
                    break;
                case "Трасса для картинга":
                    break;
                case "Парковка":
                    break;
                case "Лесной слалом":
                    break;
                case "Закрытый картинг":
                    break;
                case "Горы слалом":
                    break;
                case "Слалом":
                    break;
                case "Перегрузка":
                    break;
                case "Неизвестная трасса":
                    break;
                default:
                    NotePad.DoErrorLog("Написать логику для " + track);
                    break;
            }

            return x;
        }
    }

    public class GrandArrangement
    {
        public void Arrangement(int[] a1, int[] b1, int[] c1)//величины не менялись с версии 0.04
        {
            Algorithms al = new Algorithms();
            TrackInfo ti = new TrackInfo();
            Form1 f = new Form1();
            IdentifyCar idcar = new IdentifyCar();
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

            int[] saves = NotePad.ReadSaves();
            int[] carsid = new int[5];
            Array.Copy(saves, 3, carsid, 0, 5);
            carsid[0] = idcar.Identify1Car(carsid[0]);//converting picture id to car id
            carsid[1] = idcar.Identify1Car(carsid[1]);
            carsid[2] = idcar.Identify1Car(carsid[2]);
            carsid[3] = idcar.Identify1Car(carsid[3]);
            carsid[4] = idcar.Identify1Car(carsid[4]);
            double[] emptycar = { 0, 0, 0, 0, 0, 0, 0 };

            double[][] carstats = new double[5][];
            for (int m = 0; m < 5; m++)
            {
                carstats[m] = idcar.CarStats(carsid[m]);
            }

            string[] a2 = ti.IdentifyTracks(a1);//Track name                        
            string[] b2 = ti.IdentifyGround(b1);//Coverage            
            string[] c2 = ti.IdentifyWeather(c1);//Weather
            string[,] d = ti.TrackPackage(a2, b2, c2);//race full info
            int[] a3 = ti.TrackRank(a2);//Track Rank

            for (int i = 0; i < 4; i++)//track priority
            {
                for (int i1 = (i + 1); i1 < 5; i1++)
                {
                    if (a3[i] > a3[i1])
                    {
                        int f1 = a3[i];
                        a3[i] = a3[i1];
                        a3[i1] = f1;
                        Point f2 = b[i];
                        b[i] = b[i1];
                        b[i1] = f2;
                        for (int j = 0; j < 3; j++)
                        {
                            string var = d[j, i];
                            d[j, i] = d[j, i1];
                            d[j, i1] = var;
                        }
                    }
                }
            }

            for (int j = 0; j < 5; j++)//logic for dragndrop
            {
                Thread.Sleep(1000);
                double emptycarpoints = -50000;
                double x;
                int usingfinger = 0;
                double maxpoints = emptycarpoints;
                for (int n = 0; n < 5; n++)
                {
                    if (carstats[n] == emptycar)
                    {
                        x = emptycarpoints;
                    }
                    else
                    {
                        x = al.CalculateCompatibility(d[0, j], d[1, j], d[2, j], carstats[n]);
                    }

                    if (x > maxpoints)
                    {
                        usingfinger = n;//choose the best car for track
                        maxpoints = x;
                    }
                }
                f.DragnDrop(a[usingfinger], b[j]);//set choosen car on track
                carstats[usingfinger] = emptycar;//set used finger as empty
            }
        }
    }

    public class HandMaking
    {
        private void ChooseTires(int eventname, char cls, int condition, string weather)
        {
            Point tires = new Point(200, 635);

            Point dynamic = new Point(490, 450);
            Point standart = new Point(700, 450);
            Point allsurface = new Point(910, 450);
            Point offroad = new Point(1120, 450);
            Point slik = new Point(490, 600);

            Point fwd = new Point(700, 600);
            Point rwd = new Point(910, 600);
            Point awd = new Point(1120, 600);

            Form1 f1 = new Form1();

            if (condition != 0)//перечислить исключения
            {
                Thread.Sleep(500);
                f1.Clk1(tires);
                switch (weather)
                {
                    case "с прояснениями":
                        switch (eventname)
                        {
                            case 1://twists n turns
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 2://off-road outlaws
                                switch (cls)
                                {
                                    case 'f':
                                        f1.Clk1(offroad);
                                        f1.Clk1(standart);
                                        break;
                                    default:
                                        f1.Clk1(allsurface);
                                        f1.Clk1(offroad);
                                        break;
                                }
                                break;
                            case 3://drag n city
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 4://goldem sun
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 5://black forest
                                break;
                            case 6://winter warriors
                                switch (cls)
                                {
                                    case 'f':
                                        f1.Clk1(offroad);
                                        f1.Clk1(standart);
                                        break;
                                    default:
                                        f1.Clk1(allsurface);
                                        f1.Clk1(offroad);
                                        break;
                                }
                                break;
                            case 7://stormchaser
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 8://speed of light
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                break;
                            case 9://city living
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 10://rising sun
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 11://circut breaker
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 12://scenic route
                                break;
                            case 13://monte carlo
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 15://the road less taken
                                break;
                            case 16://california storm
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 17://mountain pass                        
                                break;
                            case 18://scattered showers              
                                break;
                            case 19://rising storm
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "солнечно":
                        switch (eventname)
                        {
                            case 1://twists n turns
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                break;
                            case 2://off-road outlaws
                                switch (cls)
                                {
                                    case 'f':
                                        f1.Clk1(offroad);
                                        f1.Clk1(standart);
                                        break;
                                    default:
                                        f1.Clk1(allsurface);
                                        f1.Clk1(offroad);
                                        break;
                                }
                                break;
                            case 3://drag n city
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                break;
                            case 4://goldem sun
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                break;
                            case 5://black forest
                                break;
                            case 6://winter warriors
                                switch (cls)
                                {
                                    case 'f':
                                        f1.Clk1(offroad);
                                        f1.Clk1(standart);
                                        break;
                                    default:
                                        f1.Clk1(allsurface);
                                        f1.Clk1(offroad);
                                        break;
                                }
                                break;
                            case 7://stormchaser
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 8://speed of light
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                break;
                            case 9://city living
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                break;
                            case 10://rising sun
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                break;
                            case 11://circut breaker
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                break;
                            case 12://scenic route
                                break;
                            case 13://monte carlo
                                f1.Clk1(slik);
                                f1.Clk1(dynamic);
                                break;
                            case 15://the road less taken
                                break;
                            case 16://california storm
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 17://mountain pass                        
                                break;
                            case 18://scattered showers              
                                break;
                            case 19://rising storm
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            default:
                                break;
                        }
                        break;
                    case "мокро":
                        switch (eventname)
                        {
                            case 1://twists n turns
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 2://off-road outlaws
                                switch (cls)
                                {
                                    case 'f':
                                        f1.Clk1(offroad);
                                        f1.Clk1(standart);
                                        break;
                                    default:
                                        f1.Clk1(allsurface);
                                        f1.Clk1(offroad);
                                        break;
                                }
                                break;
                            case 3://drag n city
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 4://goldem sun
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 5://black forest
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                f1.Clk1(allsurface);
                                f1.Clk1(offroad);
                                break;
                            case 6://winter warriors
                                switch (cls)
                                {
                                    case 'f':
                                        f1.Clk1(offroad);
                                        f1.Clk1(standart);
                                        break;
                                    default:
                                        f1.Clk1(allsurface);
                                        f1.Clk1(offroad);
                                        break;
                                }
                                break;
                            case 7://stormchaser
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 8://speed of light
                                f1.Clk1(dynamic);
                                break;
                            case 9://city living
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 10://rising sun
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 11://circut breaker
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 12://scenic route
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                f1.Clk1(allsurface);
                                f1.Clk1(offroad);
                                break;
                            case 13://monte carlo
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 15://the road less taken
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                f1.Clk1(allsurface);
                                f1.Clk1(offroad);
                                break;
                            case 16://california storm
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            case 17://mountain pass 
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                f1.Clk1(allsurface);
                                f1.Clk1(offroad);
                                break;
                            case 18://scattered showers   
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                f1.Clk1(allsurface);
                                f1.Clk1(offroad);
                                break;
                            case 19://rising storm
                                f1.Clk1(dynamic);
                                f1.Clk1(standart);
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
        }

        public int[] ConditionHandling(int condition, int rq, int[,] hand)
        {
            int n;
            int[] finger = new int[5];
            Random r = new Random();
            int handrq = 0;
            switch (condition)
            {
                default:
                    finger[0] = 0;
                    finger[1] = 0;
                    finger[2] = 0;
                    finger[3] = 0;
                    finger[4] = 0;
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
                        handrq += 4;
                    }
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
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

            int f = 0;
            int e = 0;
            int d = 0;
            int c = 0;
            int b = 0;
            int a = 0;
            int s = 0;

            for (int k = 0; k < 5; k++)
            {
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
            int[] ar = { s, a, b, c, d, e, f };
            return ar;
        }

        public void MakingHandwith1Condition(int rq, int condition, int eventname, string weather)
        {
            FastCheck fc = new FastCheck();
            Form1 f1 = new Form1();
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

            int[] ar = ConditionHandling(condition, rq, hand);

            int var; //недобор
            int usedhandslots = 0;
            Thread.Sleep(1000);
            if (condition != 0 && condition != 3 && condition != 36 && !fc.ConditionActivated()) f1.Clk(640, 265); //включить фильтр условия события. Исключения: нет условий, 3 машины одной редкости, фильтр включен                                   
            char[] lit = { 's', 'a', 'b', 'c', 'd', 'e', 'f' };

            for (int it = 0; it < 7; it++)
            {
                if (ar[it] > 0)
                {
                    if (it == 6)
                    {
                        Randomizer(condition, rq);
                        UseFilter(lit[it], ar[it], usedhandslots, eventname, condition, weather);
                    }
                    else
                    {
                        Randomizer(condition, rq);
                        var = UseFilter(lit[it], ar[it], usedhandslots, eventname, condition, weather);
                        usedhandslots += ar[it] - var;
                        ar[it + 1] += var;
                    }
                }
            }

            if (VerifyHand())//проверка руки, чтобы не сохранял пустые картинки
            {
                int[] carsid = RememberHand();
                NotePad.Saves(rq, condition, eventname, carsid);
            }
        }

        public bool CarFixed(int slot)
        {
            string path = "Check//";
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
            MasterOfPictures.MakePicture(bounds[slot], path + n[slot] + "0");
            Thread.Sleep(2000);
            MasterOfPictures.MakePicture(bounds[slot], path + n[slot] + "1");
            return MasterOfPictures.Verify(path + n[slot] + "0", path + n[slot] + "1");
        }

        public bool HandCarFixed()
        {
            string path = "Check//";
            Rectangle finger1Bounds = new Rectangle(85, 725, 115, 65);
            Rectangle finger2Bounds = new Rectangle(280, 725, 115, 65);
            Rectangle finger3Bounds = new Rectangle(470, 725, 115, 65);
            Rectangle finger4Bounds = new Rectangle(660, 725, 115, 65);
            Rectangle finger5Bounds = new Rectangle(850, 725, 115, 65);
            bool x = true;
            Rectangle[] bounds = new Rectangle[] { finger1Bounds, finger2Bounds, finger3Bounds, finger4Bounds, finger5Bounds };
            string[] n = new string[] { "finger1", "finger2", "finger3", "finger4", "finger5" };
            for (int i = 0; i < 5; i++)
            {
                MasterOfPictures.MakePicture(bounds[i], path + n[i] + "0");
            }
            Thread.Sleep(1700);
            for (int j = 0; j < 5; j++)
            {
                MasterOfPictures.MakePicture(bounds[j], path + n[j] + "1");
            }

            for (int k = 0; k < 5; k++)
            {
                if (!MasterOfPictures.Verify(path + n[k] + "0", path + n[k] + "1"))
                {
                    NotePad.DoLog("Тачка на " + (k + 1) + " месте неисправна");
                    x = false;
                    break;
                }
            }
            return x;
        }

        public bool VerifyHand()
        {
            FastCheck fc = new FastCheck();

            Point HandSlot1 = new Point(160, 775);
            Point HandSlot2 = new Point(355, 775);
            Point HandSlot3 = new Point(545, 775);
            Point HandSlot4 = new Point(740, 775);
            Point HandSlot5 = new Point(930, 775);
            Point[] a = { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };
            bool x = true;
            string emptyslot = "Color [A=255, R=200, G=200, B=200]";
            Thread.Sleep(2000);

            for (int i = 0; i < 5; i++)
            {
                if (MasterOfPictures.PixelIndicator(a[i]) == emptyslot)
                {
                    NotePad.DoLog("Тачка на " + a[i] + " позиции отсутствует");
                    x = false;
                    break;
                }
            }

            if (fc.RedReadytoRace())
            {
                NotePad.DoLog("Рука не соответствует условию");
                x = false;
            }

            return x;
        }

        public int[] RememberHand()
        {
            Rectangle HandSlot1 = new Rectangle(85, 725, 115, 65);
            Rectangle HandSlot2 = new Rectangle(277, 725, 115, 65);
            Rectangle HandSlot3 = new Rectangle(469, 725, 115, 65);
            Rectangle HandSlot4 = new Rectangle(661, 725, 115, 65);
            Rectangle HandSlot5 = new Rectangle(853, 725, 115, 65);
            string carsDB = "Finger";
            int lastcar = 1000;
            int[] carsid = new int[5];
            bool flag;
            Rectangle[] b = { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };

            for (int i = 0; i < 5; i++)
            {
                MasterOfPictures.MakePicture(b[i], (carsDB + (i + 1) + "\\test"));
                flag = true;

                if (i == 0)//для первого пальца
                {
                    int maxknowncar = 0;
                    for (int i2 = 1; i2 < lastcar + 1; i2++)
                    {
                        if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\" + i2 + ".jpg"))
                        {
                            maxknowncar = i2;
                            if (MasterOfPictures.Verify(("Finger" + (i + 1) + "\\" + i2), ("Finger" + (i + 1) + "\\test")))
                            {
                                NotePad.DoLog("На " + (i + 1) + " месте " + i2 + " тачка");
                                carsid[i] = i2;
                                File.Delete("C:\\Bot\\Finger" + (i + 1) + "\\test.jpg");
                                flag = false;
                                break;
                            }
                        }
                    }
                    if (flag == true)
                    {
                        NotePad.DoLog("Добавляю новую тачку");
                        carsid[i] = maxknowncar + 1;
                        File.Move("C:\\Bot\\Finger" + (i + 1) + "\\test.jpg", "C:\\Bot\\Finger" + (i + 1) + "\\" + carsid[i] + ".jpg");
                    }
                }
                else
                {
                    for (int i2 = 1; i2 < lastcar; i2++)
                    {
                        if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\" + i2 + ".jpg")) //поиск в сортированных
                        {
                            if (MasterOfPictures.Verify(("Finger" + (i + 1) + "\\" + i2), ("Finger" + (i + 1) + "\\test")))
                            {
                                NotePad.DoLog("На " + (i + 1) + " месте " + i2 + " тачка");
                                carsid[i] = i2;
                                File.Delete("C:\\Bot\\Finger" + (i + 1) + "\\test.jpg");
                                flag = false;
                                break;
                            }
                        }
                    }

                    if (flag == true)
                    {
                        int emptySpaceForCar = 0;
                        for (int i2 = 1; i2 < lastcar; i2++)
                        {
                            if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\unsorted" + i2 + ".jpg")) //поиск в сортированных
                            {
                                if (MasterOfPictures.Verify(("Finger" + (i + 1) + "\\unsorted" + i2), ("Finger" + (i + 1) + "\\test")))
                                {
                                    NotePad.DoLog("На " + (i + 1) + " месте " + i2 + " неотсортированная тачка");
                                    carsid[i] = 10000; //неотсортированная
                                    File.Delete("C:\\Bot\\Finger" + (i + 1) + "\\test.jpg");
                                    flag = false;
                                    break;
                                }
                            }
                            else if (emptySpaceForCar == 0) emptySpaceForCar = i2;
                        }
                        if (flag == true)
                        {
                            NotePad.DoLog("Добавляю новую тачку");
                            carsid[i] = 10000; //неотсортированная
                            File.Move("C:\\Bot\\Finger" + (i + 1) + "\\test.jpg", "C:\\Bot\\Finger" + (i + 1) + "\\unsorted" + emptySpaceForCar + ".jpg");
                        }
                    }
                }
            }

            return carsid;
        }

        private int UseFilter(char cls, int n, int uhl, int eventname, int condition, string weather)
        {
            Waiting wait = new Waiting();

            Point filter = new Point(945, 265);
            Point clear = new Point(340, 785);
            Point accept = new Point(940, 785);
            Point rarity = new Point(200, 415);

            Point f = new Point(490, 450);
            Point e = new Point(700, 450);
            Point d = new Point(910, 450);
            Point c = new Point(1120, 450);
            Point b = new Point(490, 600);
            Point a = new Point(700, 600);
            Point s = new Point(910, 600);

            Form1 f1 = new Form1();
            f1.Clk1(filter);
            wait.Filter();
            f1.Clk1(clear);
            Thread.Sleep(1000);
            f1.Clk1(rarity);
            Thread.Sleep(1000);
            switch (cls)
            {
                case 'f':
                    f1.Clk1(f);//выбрать класс                    
                    break;

                case 'e':
                    f1.Clk1(e);//выбрать класс                    
                    break;

                case 'd':
                    f1.Clk1(d);//выбрать класс                    
                    break;

                case 'c':
                    f1.Clk1(c);//выбрать класс                    
                    break;

                case 'b':
                    f1.Clk1(b);//выбрать класс                    
                    break;

                case 'a':
                    f1.Clk1(a);//выбрать класс                    
                    break;

                case 's':
                    f1.Clk1(s);//выбрать класс
                    break;
            }

            Thread.Sleep(500);
            ChooseTires(eventname, cls, condition, weather);
            Thread.Sleep(1000);
            f1.Clk1(accept);
            Thread.Sleep(2000);
            int emptycars = f1.DragnDpopHand(n, uhl);

            return emptycars;
        }

        private void Randomizer(int condition, int rq)
        {
            Waiting wait = new Waiting();
            Form1 f1 = new Form1();
            FastCheck fc = new FastCheck();
            Point r1 = new Point(100, 410);//rarity
            Point r2 = new Point(100, 475);//rq
            Point r3 = new Point(100, 545);//max speed
            Point r4 = new Point(100, 615);//0-60
            Point r5 = new Point(430, 410);//handling
            Point r6 = new Point(430, 475);//wheels drive
            Point r7 = new Point(430, 545);//country
            Point r8 = new Point(430, 615);//width
            Point r9 = new Point(765, 410);//height
            Point r10 = new Point(765, 475);//weight
            Point[] a = new Point[] { r1, r2, r3, r4, r5, r6, r7, r8, r9, r10 };
            Random rand = new Random();
            Point p = new Point();
            while (!fc.ItsGarage()) Thread.Sleep(2000);

            if ((condition == 11 && rq < 110)
                || (condition == 10 && rq < 70)
                || (condition == 6 && rq < 50)
                || (condition == 40 && rq < 90)
                || rq < 30)
            {
                NotePad.DoLog("сортирую по рк");
                Thread.Sleep(200);
                f1.Clk(1090, 265);//сортировка
                Thread.Sleep(1000);
                f1.Clk(240, 795);//сброс
                Thread.Sleep(1000);
                f1.Clk(1090, 265);//сортировка
                Thread.Sleep(1000);
                f1.Clk(100, 475);//сортировка по рк  
            }
            else
            {
                Thread.Sleep(200);
                f1.Clk(1090, 265);//сортировка
                wait.Type();
                int r = rand.Next(10);
                p = a[r];
                if (rand.Next(2) == 1)
                {
                    f1.Clk(p.X, p.Y);//выбрать условие
                    Thread.Sleep(200);
                }
                f1.Clk(p.X, p.Y);//выбрать условие 
            }

            Thread.Sleep(500);
            f1.Clk(840, 790);//закрыть сортировку
            Thread.Sleep(4000);
        }
    }

    public class NotePad//ForDima
    {
        public static void DoErrorLog(string text)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\BotForDima\Errors.txt", true, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine(text);
                sw.Close();
            }
        }

        public static void DoLog(string text)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\BotForDima\Log.txt", true, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine(text + "  " + DateTime.Now.ToLongTimeString());
                sw.Close();
            }
        }

        public static void Saves(int rq, int condition, int tires, int[] carsid)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\BotForDima\Saves.txt", false, System.Text.Encoding.Default))//true для дописывания 
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

        public static int[] ReadSaves()
        {
            int[] a = new int[8];
            using (StreamReader sr = new StreamReader(@"C:\BotForDima\Saves.txt", System.Text.Encoding.Default))
            {
                for (int i = 0; i < 8; i++)
                {
                    a[i] = Convert.ToInt32(sr.ReadLine());//rq, condition, tires, carsid(5)
                }
                sr.Close();
            }
            return a;
        }

        public static void ClearLog()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\BotForDima\Log.txt", false, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine("Начинаю новую сессию");
                sw.Close();
            }
        }

        public static void LastWeather(string weather)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\BotForDima\Weather.txt", false, System.Text.Encoding.Default))
            {
                sw.WriteLine(weather);
                sw.Close();
            }
        }

        public static string FindWeather()
        {
            string weather;
            using (StreamReader sr = new StreamReader(@"C:\BotForDima\Weather.txt", System.Text.Encoding.Default))
            {
                weather = sr.ReadLine();
                sr.Close();
            }
            return weather;
        }
    }

    public class MasterOfPictures//for dima
    {
        private static Bitmap captured;

        public static string PixelIndicator(Point p)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            Bitmap indicator = new Bitmap(1, 1, format);
            Graphics gdi = Graphics.FromImage(indicator);
            gdi.CopyFromScreen(p.X, p.Y, 0, 0, new Size(1, 1));
            string pix = indicator.GetPixel(0, 0).ToString();
            Console.WriteLine(pix);//для проверок
            gdi.Dispose();
            indicator.Dispose();
            return pix;
        }

        public static void MakePicture(Rectangle bounds, string PATH)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            captured = new Bitmap(bounds.Width, bounds.Height, format);
            Graphics gdi = Graphics.FromImage(captured);
            gdi.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
            if (captured != null)
            {
                captured.Save("C:\\BotForDima\\" + PATH + ".jpg", ImageFormat.Jpeg);
            }
            gdi.Dispose();
            captured.Dispose();
        }

        public static bool Verify(string PATH, string ORIGINALPATH)
        {
            bool flag1 = false; 
            string originalpath = @"C:\\BotForDima\\" + ORIGINALPATH + ".jpg";
            if (File.Exists(originalpath))
            {
                Bitmap picturetest = new Bitmap("C:\\BotForDima\\" + PATH + ".jpg");
                Bitmap picture = new Bitmap("C:\\BotForDima\\" + ORIGINALPATH + ".jpg");
                flag1 = true;
                for (int x = 0; x < picturetest.Width; x++)
                {
                    if (flag1 == true)
                    {
                        for (int y = 0; y < picturetest.Height; y++)
                        {
                            if (picturetest.GetPixel(x, y) != picture.GetPixel(x, y))
                            {
                                flag1 = false;
                                break;
                            }
                        }
                    }
                }
                picturetest.Dispose();
                picture.Dispose();
            }
            else
            {
                NotePad.DoErrorLog("Отсутствует " + originalpath);
            }

            return flag1;
        }

        public static void TrackCapture(Rectangle bounds, string PATH)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            captured = new Bitmap(bounds.Width, bounds.Height, format);
            Bitmap BW = new Bitmap(bounds.Width, bounds.Height, format);
            Graphics gdi = Graphics.FromImage(captured);
            gdi.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
            for (int row = 0; row < captured.Width; row++) // Indicates row number
            {
                for (int column = 0; column < captured.Height; column++) // Indicate column number
                {
                    var colorValue = captured.GetPixel(row, column); // Get the color pixel                    
                    var averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G) / 3; // get the average for black and white
                    if (averageValue > 220) averageValue = 255;
                    else averageValue = 0;
                    BW.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel
                }
            }

            BW.Save("C:\\BotForDima\\" + PATH + ".jpg", ImageFormat.Jpeg); // Save the black and white image         

            gdi.Dispose();
            captured.Dispose();
            BW.Dispose();
        }

        public static void BW2Capture(Rectangle bounds, string PATH)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            captured = new Bitmap(bounds.Width, bounds.Height, format);
            Bitmap BW = new Bitmap(bounds.Width, bounds.Height, format);
            Graphics gdi = Graphics.FromImage(captured);
            gdi.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
            for (int row = 0; row < captured.Width; row++) // Indicates row number
            {
                for (int column = 0; column < captured.Height; column++) // Indicate column number
                {
                    var colorValue = captured.GetPixel(row, column); // Get the color pixel
                    var averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G) / 3; // get the average for black and white
                    if (averageValue > 200) averageValue = 255;
                    else averageValue = 0;
                    BW.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel
                }
            }

            BW.Save("C:\\BotForDima\\" + PATH + ".jpg", ImageFormat.Jpeg); // Save the black ad white image            

            gdi.Dispose();
            captured.Dispose();
            BW.Dispose();
        }

        public static bool VerifyBW(string PATH, string ORIGINALPATH, int maxdiffernces)
        {
            bool flag1 = false;
            string originalpath = @"C:\\BotForDima\\" + ORIGINALPATH + ".jpg";
            if (File.Exists(originalpath))
            {
                Bitmap picturetest = new Bitmap("C:\\BotForDima\\" + PATH + ".jpg");
                Bitmap picture = new Bitmap("C:\\BotForDima\\" + ORIGINALPATH + ".jpg");
                flag1 = true;
                int differences = 0;
                for (int x = 0; x < picturetest.Width; x++)
                {
                    if (flag1 == true)
                    {
                        for (int y = 0; y < picturetest.Height; y++)
                        {                            
                            if (Math.Abs((int)picturetest.GetPixel(x, y).R - (int)picture.GetPixel(x, y).R) >= 200)
                            {                             
                                differences++;
                                if (differences == maxdiffernces)
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
            }
            else
            {
                NotePad.DoErrorLog("Отсутствует " + originalpath);
            }
            
            return flag1;
        }
    }

    public class FastCheck
    {
        Form1 f1 = new Form1();
        SpecialEvents se = new SpecialEvents();
        
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

        public bool EventPage()//for dima
        {
            bool x = false;
            string EventPath = "HeadPictures\\TestEvent";
            string EventOriginal = "HeadPictures\\OriginalEvent";
            Rectangle EventBounds = new Rectangle(366, 140, 139, 32);
            MasterOfPictures.MakePicture(EventBounds, EventPath);
            if (MasterOfPictures.Verify(EventPath, EventOriginal))
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
                f1.Clk(1150, 240);
                x = true;
            }

            return x;
        }

        public bool Bounty()
        {
            bool x = false;
            string ClubBounty = "HeadPictures\\TestClubBounty";
            string ClubBountyOriginal = "HeadPictures\\OriginalClubBounty";
            Rectangle ClubBountyBounds = new Rectangle(668, 684, 261, 28);
            MasterOfPictures.MakePicture(ClubBountyBounds, ClubBounty);
            if (MasterOfPictures.Verify(ClubBountyOriginal, ClubBounty))
            {
                Thread.Sleep(200);
                f1.Clk(800, 700);
                x = true;
            }
            return x;
        }// for dima

        public bool ActiveEvent()//for dima
        {
            bool x = false;
            string ButtonToEventTest = "HeadPictures\\TestButtonToEvent";
            string ButtonToEventOriginal = "HeadPictures\\OriginalButtonToEvent";
            Rectangle ButtonToEventBounds = new Rectangle(1239, 743, 20, 20);
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
                "Color [A=255, R=92, G=163, B=200]",//PL11
                "Color [A=255, R=87, G=153, B=186]",//PL11
                "Color [A=255, R=88, G=154, B=187]",//PL11
                "Color [A=255, R=92, G=150, B=183]"//PL11
            };

            if (MasterOfPictures.PixelIndicator(a[n]) == b[n] || MasterOfPictures.PixelIndicator(a[n]) == c[n])
            {
                x = false;
            }
            return x;
        }

        public bool ControlScreen()//for dima
        {
            string ControlScreenPath = "HeadPictures\\TestControlScreen";
            string ControlScreenOriginal = "HeadPictures\\OriginalControlScreen";
            Rectangle ControlScreenBounds = new Rectangle(952, 734, 99, 31);
            bool x = false;
            MasterOfPictures.MakePicture(ControlScreenBounds, ControlScreenPath);
            if (MasterOfPictures.Verify(ControlScreenPath, ControlScreenOriginal)) x = true;
            return x;
        }

        public bool ClubMap()//for dima
        {
            string ClubMapPath = "HeadPictures\\TestClubMap";
            string ClubMapOriginal = "HeadPictures\\OriginalClubMap";
            Rectangle ClubMapBounds = new Rectangle(1011, 755, 29, 28);
            bool x = false;
            MasterOfPictures.MakePicture(ClubMapBounds, ClubMapPath);
            if (MasterOfPictures.Verify(ClubMapPath, ClubMapOriginal))
            {
                NotePad.DoLog("карта клубов");
                x = true;
            }

            return x;
        }

        public bool RaceOn()//for dima
        {
            bool x = false;
            string RacePath = "HeadPictures\\TestRace";
            string RaceOriginal = "HeadPictures\\OriginalRace";
            Rectangle RaceBounds = new Rectangle(179, 100, 64, 67);
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

        public bool ItsGarage()//for dima
        {
            bool x = false;
            string InGaragePath = "HeadPictures\\TestInGarage";
            string InGarageOriginal = "HeadPictures\\OriginalInGarage";
            Rectangle InGarageBounds = new Rectangle(331, 106, 101, 35);
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
            ;
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
    }

    public class Waiting
    {
        SpecialEvents se = new SpecialEvents();
        FastCheck fc = new FastCheck();

        public void StartIcon()//for dima
        {
            Rectangle IcBounds = new Rectangle(979, 278, 48, 42);
            string IcPath = "HeadPictures\\TestIcon";
            string IcOriginal = "HeadPictures\\OriginalIcon";
            do
            {
                MasterOfPictures.MakePicture(IcBounds, IcPath);
                Thread.Sleep(2000);
            } while (!MasterOfPictures.Verify(IcPath, IcOriginal));
        }

        public void StartButton()//for dima
        {
            string AlcPath = "HeadPictures\\TestStart";
            string AlcOriginal = "HeadPictures\\OriginalStart";
            Rectangle AlcBounds = new Rectangle(431, 566, 92, 27);
            do
            {
                MasterOfPictures.MakePicture(AlcBounds, AlcPath);
                Thread.Sleep(2000);
            } while (!MasterOfPictures.Verify(AlcPath, AlcOriginal));
        }

        public void Type()
        {
            do
            {
                Thread.Sleep(500);
            } while (!fc.TypeIsOpenned());
        }

        public void Filter()
        {
            do
            {
                Thread.Sleep(500);
            } while (!fc.FilterIsOpenned());
        }

        public void HeadPage()//for dima
        {
            string HeadPath = "HeadPictures\\TestHead";
            string HeadOriginal = "HeadPictures\\OriginalHead";
            Rectangle HeadBounds = new Rectangle(330, 106, 131, 31);
            do
            {
                MasterOfPictures.MakePicture(HeadBounds, HeadPath);
                Thread.Sleep(2000);
            } while (!MasterOfPictures.Verify(HeadPath, HeadOriginal));
        }

        public void EventPage()//for dima
        {
            string EventPath = "HeadPictures\\TestEvent";
            string EventOriginal = "HeadPictures\\OriginalEvent";
            Rectangle EventBounds = new Rectangle(366, 140, 139, 32);
            do
            {
                fc.Bounty();
                MasterOfPictures.MakePicture(EventBounds, EventPath);
                Thread.Sleep(2000);
            } while (!MasterOfPictures.Verify(EventPath, EventOriginal));
        }

        public void ClubMap()//for dima
        {
            string ClubMapPath = "HeadPictures\\TestClubMap";
            string ClubMapOriginal = "HeadPictures\\OriginalClubMap";
            Rectangle ClubMapBounds = new Rectangle(1011, 755, 29, 28);
            do
            {
                se.UniversalErrorDefense();
                fc.Bounty();
                MasterOfPictures.MakePicture(ClubMapBounds, ClubMapPath);
                Thread.Sleep(2000);
            } while (!MasterOfPictures.Verify(ClubMapPath, ClubMapOriginal));
        }

        public void ReadytoRace()//for dima
        {
            string GarageRaceButtonPath = "HeadPictures\\TestGarageRaceButton";
            string GarageRaceButtonOriginal = "HeadPictures\\OriginalGarageRaceButton";
            Rectangle GarageRaceButtonBounds = new Rectangle(1258, 743, 102, 22);
            do
            {
                se.UniversalErrorDefense();
                MasterOfPictures.MakePicture(GarageRaceButtonBounds, GarageRaceButtonPath);
                Thread.Sleep(500);
            } while (!MasterOfPictures.Verify(GarageRaceButtonPath, GarageRaceButtonOriginal));
        }

        public void ArrangementWindow()
        {
            string ArrangementPath = "HeadPictures\\TestArrangement";
            string ArrangementOriginal = "HeadPictures\\OriginalArrangement";
            Rectangle ArrangementBounds = new Rectangle(75, 515, 5, 5);
            do
            {
                se.UniversalErrorDefense();
                MasterOfPictures.MakePicture(ArrangementBounds, ArrangementPath);
                Thread.Sleep(1000);
            } while (!MasterOfPictures.Verify(ArrangementPath, ArrangementOriginal));
        }

        public void RaceOn()//for dima
        {
            string RacePath = "HeadPictures\\TestRace";
            string RaceOriginal = "HeadPictures\\OriginalRace";
            Rectangle RaceBounds = new Rectangle(179, 100, 64, 67);
            do
            {
                se.UniversalErrorDefense();
                MasterOfPictures.MakePicture(RaceBounds, RacePath);
                Thread.Sleep(500);
            } while (!MasterOfPictures.Verify(RacePath, RaceOriginal));
        }

        public void PointsForRace()
        {
            string RacePointsPath = "HeadPictures\\TestRace";
            string RacePointsOriginal = "HeadPictures\\OriginalRace";
            Rectangle RaceBounds = new Rectangle(60, 185, 40, 40);
            do
            {
                MasterOfPictures.MakePicture(RaceBounds, RacePointsPath);
                Thread.Sleep(500);
            } while (!MasterOfPictures.Verify(RacePointsPath, RacePointsOriginal));
        }

        public void RaceOff()//for dima
        {
            string RacePath = "HeadPictures\\TestRace";
            string RaceOriginal = "HeadPictures\\OriginalRace";
            Rectangle RaceBounds = new Rectangle(179, 100, 64, 67);
            do
            {
                MasterOfPictures.MakePicture(RaceBounds, RacePath);
                Thread.Sleep(500);
            } while (MasterOfPictures.Verify(RacePath, RaceOriginal));
        }

        public void Table()
        {
            FastCheck fc = new FastCheck();
            do
            {
                se.UniversalErrorDefense();
                Thread.Sleep(2000);
            } while (!fc.Ending());
        }
    }

    public class ChooseEvent
    {
        FastCheck fc = new FastCheck();
        Form1 f1 = new Form1();

        Rectangle Condition1Bounds = new Rectangle(990, 395, 205, 20);
        Rectangle Condition2Bounds = new Rectangle(990, 420, 205, 20);
        string Condition1 = "Condition1\\test";
        string Condition2 = "Condition2\\test";

        Rectangle EventNameBounds = new Rectangle(985, 286, 235, 22);
        string EventNamePath = "Events\\Test";

        Rectangle RQBounds = new Rectangle(1135, 370, 85, 18);
        string RQPath = "RQ\\test";

        public int Selection(int eventN)
        {
            Point n1 = new Point(960, 570);
            Point n2 = new Point(960, 660);
            Point n3 = new Point(960, 750);
            Point n4 = new Point(960, 830);

            int c = 0;
            for (int i = 0; i < 100; i++)
            {
                if (File.Exists(@"C:\Bot\Condition1\C" + i + ".jpg"))
                {
                    c = i;
                }
                else break;
            }

            int x = 500;
            bool flag;

            do
            {
                flag = true;
                switch (eventN)
                {
                    case 1:
                        f1.Clk(n1.X, n1.Y);
                        break;
                    case 2:
                        f1.Clk(n2.X, n2.Y);
                        break;
                    case 3:
                        f1.Clk(n3.X, n3.Y);
                        break;
                    case 4:
                        f1.Clk(n4.X, n4.Y);
                        break;
                }
                Thread.Sleep(4000);
                if (fc.MissClick())
                {
                    f1.Clk(1150, 240);
                    flag = false;
                    Thread.Sleep(1000);
                }
                if (fc.EventPage())
                {
                    f1.Clk(240, 500);//Clubs
                    flag = false;
                    Thread.Sleep(15000);
                }
                Thread.Sleep(2000);
            } while (flag == false);

            MasterOfPictures.MakePicture(Condition1Bounds, Condition1);
            MasterOfPictures.MakePicture(Condition2Bounds, Condition2);
            if (MasterOfPictures.Verify(Condition2, "Condition2\\CC0"))
            {
                for (x = 0; x < (c + 1); x++)
                {
                    if (MasterOfPictures.Verify(Condition1, ("Condition1\\C" + x)))
                    {
                        break;
                    }
                }
                if (x == (c + 1))
                {
                    NotePad.DoLog("Неизвестное условие");
                    for (x = 1; x < 100; x++)
                    {
                        if (File.Exists("C:\\Bot\\Condition1\\UnknownCondition" + x + ".jpg"))
                        {
                            if (MasterOfPictures.Verify(Condition1, ("Condition1\\UnknownCondition" + x)))
                            {
                                break;
                            }
                        }
                        else
                        {
                            File.Move("C:\\Bot\\" + Condition1 + ".jpg", "C:\\Bot\\Condition1\\UnknownCondition" + x + ".jpg");
                            NotePad.DoLog("Сделал скрин");
                            break;
                        }
                    }
                    x = 500;
                }

                if (x != 500)//Исключаю неизвестный
                {
                    int rq = GotRQ();
                    if (rq > 17)
                    {
                        NotePad.DoLog(eventN + " событие подходит");
                        NotePad.DoLog("1 условие = " + x);
                        if (x == 4 && rq < 94)
                        {
                            NotePad.DoLog("выпало исключение Audi");
                            x = 500;
                        }
                        if (x == 8 && rq < 70)
                        {
                            NotePad.DoLog("выпало исключение Jaguar");
                            x = 500;
                        }
                        if (x == 13 && rq < 32)
                        {
                            NotePad.DoLog("выпало исключение пикап");
                            x = 500;
                        }
                        if (x == 14 && rq < 33)
                        {
                            NotePad.DoLog("выпало исключение Mercedes");
                            x = 500;
                        }
                        if (x == 15 && rq < 38)
                        {
                            NotePad.DoLog("выпало исключение Renault");
                            x = 500;
                        }
                        if (x == 16 && rq < 32)
                        {
                            NotePad.DoLog("выпало исключение полный привод");
                            x = 500;
                        }
                        if (x == 18 && rq < 38)
                        {
                            NotePad.DoLog("выпало исключение Chrysler");
                            x = 500;
                        }
                        if (x == 19)//очень мало машин
                        {
                            NotePad.DoLog("выпало исключение Peugeot");
                            x = 500;
                        }
                        if (x == 22 && rq < 50)
                        {
                            NotePad.DoLog("выпало исключение French Renaissance");
                            x = 500;
                        }
                        if (x == 24 && rq < 58)
                        {
                            NotePad.DoLog("выпало исключение всесезон");
                            x = 500;
                        }
                        if (x == 25 && rq < 34)
                        {
                            NotePad.DoLog("выпало исключение ford");
                            x = 500;
                        }
                        if (x == 26 && rq < 34)
                        {
                            NotePad.DoLog("выпало исключение bmw");
                            x = 500;
                        }
                        if (x == 29 && rq < 54)
                        {
                            NotePad.DoLog("выпало исключение mazda");
                            x = 500;
                        }
                        if (x == 34 && rq < 54)
                        {
                            NotePad.DoLog("выпало исключение dodge");
                            x = 500;
                        }
                        if (x == 38 && rq < 74)
                        {
                            NotePad.DoLog("выпало исключение porsche");
                            x = 500;
                        }
                        if (x == 39 && rq < 61)
                        {
                            NotePad.DoLog("выпало исключение opel");
                            x = 500;
                        }
                        if (x == 42 && rq < 76)
                        {
                            NotePad.DoLog("выпало исключение 2000 4wd");
                            x = 500;
                        }
                        if (x == 44 && rq < 42)
                        {
                            NotePad.DoLog("выпало исключение hot hutch");
                            x = 500;
                        }
                        if (x == 45 && rq < 46)
                        {
                            NotePad.DoLog("выпало исключение Экологичная");
                            x = 500;
                        }
                        if (x == 47 && rq < 62)
                        {
                            NotePad.DoLog("выпало исключение cadillac");
                            x = 500;
                        }
                        if (x == 48 && rq < 25)
                        {
                            NotePad.DoLog("выпало исключение citroen");
                            x = 500;
                        }
                    }
                    else x = 500;
                }
            }
           
            return x;
        }

        public int ChooseNormalEvent()
        {
            int x = 500;
            while (x == 500)
            {
                for (int i = 1; i < 5; i++)
                {
                    do
                    {
                        fc.MissClick();
                        Thread.Sleep(100);
                        fc.Bounty();
                        if (fc.EventPage()) f1.Clk(240, 500);
                    } while (!fc.ClubMap());

                    x = Selection(i);
                    if (x == 500)
                    {
                        f1.Clk(920, 270);//Back
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

        public int GotRQ()
        {
            int rq = 0;
            MasterOfPictures.MakePicture(RQBounds, RQPath);
            for (int i = 15; i < 151; i++)
            {
                if (MasterOfPictures.Verify(RQPath, "RQ\\" + i.ToString()))
                {
                    rq = i;
                    NotePad.DoLog("рк =  " + rq);
                    break;
                }
            }

            if (rq == 0)
            {
                NotePad.DoLog("неизвестное рк");

                for (int x = 1; x < 100; x++)
                {
                    if (File.Exists("C:\\Bot\\RQ\\UnknownRQ" + x + ".jpg"))
                    {
                        if (MasterOfPictures.Verify(RQPath, ("RQ\\UnknownRQ" + x)))
                        {
                            break;
                        }
                    }
                    else
                    {
                        File.Move("C:\\Bot\\" + RQPath + ".jpg", "C:\\Bot\\RQ\\UnknownRQ" + x + ".jpg");
                        NotePad.DoLog("Сделал скрин");
                        break;
                    }
                }
            }

            return rq;
        }

        public int WhichEvent()
        {
            int eventName = 0;
            MasterOfPictures.BW2Capture(EventNameBounds, EventNamePath);
            for (int i = 1; i < 40; i++)
            {
                if (File.Exists("C:\\Bot\\Events\\" + i.ToString() + ".jpg"))
                {
                    if (MasterOfPictures.VerifyBW(EventNamePath, "Events\\" + i.ToString(), 50))
                    {
                        eventName = i;
                        NotePad.DoLog("Название эвента =  " + i);
                        break;
                    }
                }
                else
                {
                    NotePad.DoLog("Неизвестный эвент");
                    File.Move("C:\\Bot\\" + EventNamePath + ".jpg", "C:\\Bot\\Events\\" + i.ToString() + ".jpg");
                    NotePad.DoLog("Сделал скрин");
                    break;
                }
            }

            return eventName;
        }
    }

    public class IdentifyCar//for dima
    {
        public int Identify1Car(int a)
        {
            int carid = 0;
            switch (a)
            {                
                default:
                    break;
            }
            return carid;
        }

        public double[] CarStats(int carid)
        {
            int clearance;
            int tires;
            int drive;
            double acceleration;
            int maxspeed;
            int grip;
            int weight;
            int power;
            int torque;
            int abs;
            int tcs;
            double MRA;

            switch (carid)
            {
                default:
                    NotePad.DoLog("Неизвестная тачка");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 36;
                    maxspeed = 100;
                    grip = 45;
                    weight = 2500;
                    power = 50;
                    torque = 50;
                    abs = 0;
                    tcs = 0;
                    MRA = 5;
                    break;
            }
            double[] stats = { clearance, tires, drive, acceleration, maxspeed, grip, weight, power, torque, abs, tcs, MRA };
            return stats;
        }
    }
}