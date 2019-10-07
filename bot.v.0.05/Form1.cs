using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace bot.v._0._05
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
            Thread.Sleep(1000);
            Clk(1165, 20); //Свернуть VS
            Thread.Sleep(2000);

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

        private void DragnDropGarage(Point xy1, Point xy2)//перепроверить, сравнить со SlowDragnDrop
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
            int dox1 = xy1.X;
            int doy1 = xy1.Y;
            int dox2 = xy2.X;
            int doy2 = xy2.Y;
            string x1;
            string x2;
            do
            {
                x1 = MasterOfPictures.PixelIndicator(xy1);
                MoveMouse(dox1, doy1);
                Thread.Sleep(100);
                mouse_event(MOUSEEVENTF_LEFTDOWN, dox1, doy1, 0, 0);
                Thread.Sleep(1000);
                MoveMouse(dox2, doy2);
                Thread.Sleep(2000);
                mouse_event(MOUSEEVENTF_LEFTUP, dox2, doy2, 0, 0);
                Thread.Sleep(500);
                x2 = MasterOfPictures.PixelIndicator(xy1);
            } while (x1 == x2);

        }

        public int DragnDpopHand(int n, int uhl)//величины не исправлены с версии 0.04
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
            int newN = 0;
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
                    while (!fc.InGarage()) Thread.Sleep(2000);
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

        private void Loading()
        {
            Waiting wait = new Waiting();
            NotePad.ClearLog();
            Process.Start(@"C:\Program Files (x86)\Nox\bin\Nox.exe");
            Thread.Sleep(10000);

            wait.StartIcon();

            Clk(830, 375);//Icon

            Thread.Sleep(10000);

            wait.StartButton();

            Clk(340, 630);//Start game

            Thread.Sleep(3000);

            //отсутствует блок проверки рекламы
            
        }

        private void BranchClubs()
        {
            SpecialEvents se = new SpecialEvents();
            FastCheck fc = new FastCheck();
            ChooseEvent ce = new ChooseEvent();
            Waiting wait = new Waiting();
            wait.HeadPage();

            Clk(630, 390);//Events

            wait.EventPage();

            Clk(240, 500);//Clubs

            Thread.Sleep(15000);

            wait.ClubMap();

            se.DragMap();  

            while (true)
            {
                Thread.Sleep(2000);
                int i = 0;
                if (fc.ActiveEvent())
                {
                    NotePad.DoLog("вхожу в активный эвент");
                    i = 1;
                    Clk(1060, 800);
                    int[] a = NotePad.ReadSaves();
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
                    NotePad.DoLog("Подбираю эвент с одним условием");
                    int condition = ce.ChooseNormalEvent();

                    NotePad.DoLog("Вычисляю РК эвента");
                    int rq = ce.GotRQ();

                    int eventname = ce.WhichEvent();

                    NotePad.DoLog("Вхожу в эвент  " + rq + " рк");
                    Clk(1060, 800);//ClubEventEnter   

                    while (i < 50)
                    {
                        int[] b = { 0, 0, 0, 0, 0 };
                        i++;
                        if (!PlayClubs(rq, condition, eventname, b, i)) break;
                    }

                    Thread.Sleep(2000);
                }
            }

        }
        
        private bool PlayClubs(int rq, int condition, int tires, int[] b, int i)
        {
            SpecialEvents se = new SpecialEvents();
            GrandArrangement ga = new GrandArrangement();
            TrackInfo ti = new TrackInfo();
            HandMaking hm = new HandMaking();
            Waiting wait = new Waiting();
            FastCheck fc = new FastCheck();
            bool x = true;
            bool y = false;

            Thread.Sleep(2000);
            NotePad.DoLog("начинаю играть");

            do
            {
                if (fc.Bounty())
                {
                    x = false;
                    y = true;
                }

                if (fc.EventEnds())
                {
                    NotePad.DoLog("эвент окончен");
                    Clk(640, 590);//Accept Message                    
                    Thread.Sleep(3000);
                    x = false;
                    y = true;
                }
                
                if (fc.ControlScreen())
                {
                    NotePad.DoLog("Перехожу в гараж");
                    Clk(820, 790);//Play
                    Thread.Sleep(5000);

                    do
                    {
                        if (i == 1)
                        {
                            se.ClearHand();
                            Thread.Sleep(500);
                            NotePad.DoLog("Собираю пробную руку c 1 условием");
                            hm.MakingTryHandwith1Condition(rq, condition, tires);
                        }

                        if (i != 1)
                        {
                            if (!hm.HandCarFixed() || !hm.VerifyHand())
                            {
                                if (rq != 0)
                                {
                                    se.ClearHand();
                                    Thread.Sleep(500);
                                    NotePad.DoLog("Меняю руку");
                                    hm.MakingTryHandwith1Condition(rq, condition, tires);
                                }
                            }
                        }
                    } while (!hm.VerifyHand());

                    wait.ReadytoRace();
                    Clk(1120, 800);//GarageRaceButton

                    Thread.Sleep(3000);
                    
                    if (fc.EventEnds())
                    {
                        NotePad.DoLog("эвент окончен");
                        Clk(640, 590);//Accept Message
                        Thread.Sleep(3000);
                        x = false;
                    }

                    /*
                    UniversalCapture(FullEventBounds, FullEventPath);//проверка сообщения "эвент заполнен"
                    if (Verify(FullEventPath, FullEventOriginal))
                    {
                        NotePad.DoLog("эвент заполнен");
                        Clk(640, 570);//Accept Message

                        if (fc.InGarage())
                        {
                            Clk(85, 215);//back
                            Thread.Sleep(2000);
                            Clk(85, 215);//back to club map
                        }
                        Thread.Sleep(3000);
                        x = false;
                    }*/                    

                    if (x)
                    {                        
                        wait.ForEnemy();
                        
                        int[] a1 = ti.Tracks();//Track info
                        int[] b1 = ti.Grounds();//Ground info
                        int[] c1 = ti.Weathers();//Weather info

                        Clk(640, 705);//ChooseanEnemy
                        NotePad.DoLog("Выбрал противника");
                        Thread.Sleep(1000);

                        wait.ArrangementWindow();
                        Thread.Sleep(1000);
                        ga.Arrangement(a1, b1, c1);

                        wait.RaceOn();

                        Thread.Sleep(2000);
                        Clk(180, 580); //ускорить заезд, клик в пусой области
                        NotePad.DoLog ("ускорил");

                        wait.RaceOff();

                        Thread.Sleep(2000);
                        Clk(640, 215); //кнопка "пропустить"
                        NotePad.DoLog("пропустить");

                        Thread.Sleep(2000);
                        Clk(890, 625);//подтвержение "пропуска"
                        NotePad.DoLog("подтвержение пропуска");

                        Thread.Sleep(4000);
                        Clk(635, 570);//звезды  

                        bool newflag = false;
                        
                        do
                        {
                            Thread.Sleep(2500); 
                            if (fc.Upgrade())
                            {
                                NotePad.DoLog("Смотрю рекламу на прокачку");
                                Clk(965, 745); //начать просмотр
                                Thread.Sleep(60000);
                                Clk(1205, 200);
                                //AdsKiller();
                                Thread.Sleep(12000);
                                Clk(635, 720); //подтвердить проркачку
                                Thread.Sleep(5000);
                                newflag = true;
                            }

                            if (fc.Ending())
                            {
                                newflag = true;
                            }
                        } while (!newflag);

                        NotePad.DoLog("Просматриваю таблицу результатов");
                        Clk(820, 730);//Table
                        Thread.Sleep(5000);
                        bool flag1 = false;

                        do
                        {
                            Thread.Sleep(2000);
                            if (fc.Bounty())
                            {
                                x = false;
                                flag1 = true;
                            }
                            
                            if (fc.ControlScreen())
                            {
                                flag1 = true;
                            }
                            
                            if (fc.ClubMap())
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

        public Rectangle FullEventBounds = new Rectangle(565, 560, 150, 20);
        public Rectangle GoldRewardBounds = new Rectangle(725, 487, 30, 35);             
        public Rectangle ADSBounds = new Rectangle(220, 770, 15, 30);
        public Rectangle AcBounds = new Rectangle(436, 257, 20, 20);  
        public string FullEventPath = "TestFullEvent";
        public string FullEventOriginal = "OriginalFullEvent";
        public string GoldRewardPath = "TestGoldReward";
        public string GoldRewardOriginal = "OriginalGoldReward";
        public string ADSPath = "TestADS";
        public string ADSOriginal = "OriginalADS";
        public string Dump1Path = "Dump\\1Unsorted";
        public string Dump2Path = "Dump\\2Unsorted";          
        public string AcOriginal = "OriginalAc";
        public string AcOriginal1 = "OriginalAc1";
        public string AcPath = "TestAc";   
    }

    public class SpecialEvents
    {
        Form1 f1 = new Form1();
        public void DragMap()
        {
            FastCheck fc = new FastCheck();
            fc.Bounty();
            f1.MoveMouse(750, 500);
            Thread.Sleep(100);
            f1.LMBdown(750, 500);
            Thread.Sleep(2000);
            for (int drag = 750; drag > 300; drag -= 8)
            {
                f1.MoveMouse(drag, 500);
                Thread.Sleep(60);
            }
            Thread.Sleep(1000);
            f1.MoveMouse(240, 500);
            Thread.Sleep(2000);
            f1.LMBup(240, 500);
            Thread.Sleep(1000);
        }

        public void UniversalErrorDefense()
        {
            FastCheck fc = new FastCheck();
            if (fc.ServerError())
            {
                f1.Clk(1230, 150);//close memu
                Thread.Sleep(1000);
                f1.Clk(670, 560);// accept memu close
                Thread.Sleep(1000);
                f1.Clk(20, 1000);
                Thread.Sleep(1000);
                f1.Clk(20, 960);
                Thread.Sleep(3000);
                f1.Clk(40, 910);
                Thread.Sleep(1000);
                f1.Clk(40, 910);//reloading
                Application.Exit();
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

        private void AdsKiller()//величины не исправлены с версии 0.04
        {
            //Отфотать рекламы

            /*MasterOfPictures.MakePicture(AdsWOWBounds, AdsWOWPath);
            if (MasterOfPictures.Verify(AdsWOWPath, AdsWOWOriginal))
            {
                Clk(1205, 200);  //close WOW
            }
            else
            {
                MasterOfPictures.MakePicture(AdsWMBounds, AdsWMPath);
                if (MasterOfPictures.Verify(AdsWMPath, AdsWMOriginal))
                {
                    Clk(1150, 245);  //close WM
                }
                else
                {
                    MasterOfPictures.MakePicture(AdsNutrilakBounds, AdsNutrilakPath);
                    if (MasterOfPictures.Verify(AdsNutrilakPath, AdsNutrilakOriginal))
                    {
                        Clk(1200, 200);  //close Nutrilak
                    }
                    else
                    {
                        MasterOfPictures.MakePicture(AdsREBounds, AdsREPath);
                        if (MasterOfPictures.Verify(AdsREPath, AdsREOriginal))
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
            */
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

        public string[,] TrackPackage(string[] a2, string[] b2, string[] c2)
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

        public string[] IdentifyGround(int[] b1)
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
                                b2[i] = "Трава";
                                break;
                            case 4:
                                b2[i] = "Гравий";
                                break;
                            case 5:
                                b2[i] = "Песок";
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
                                b2[i] = "Грунт";
                                break;
                            case 3:
                                b2[i] = "Трава";
                                break;
                            case 4:
                                b2[i] = "Гравий";
                                break;
                            case 5:
                                b2[i] = "Песок";
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
                                b2[i] = "Трава";
                                break;
                            case 3:
                                b2[i] = "Грунт";
                                break;
                            case 4:
                                b2[i] = "Гравий";
                                break;
                            case 5:
                                b2[i] = "Снег";
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
                                b2[i] = "Трава";
                                break;
                            case 3:
                                b2[i] = "Грунт";
                                break;
                            case 4:
                                b2[i] = "Снег";
                                break;
                            case 5:
                                b2[i] = "Песок";
                                break;
                            case 6:
                                b2[i] = "Смешанное";
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
                            default:
                                b2[i] = "неизвестное покрытие";
                                break;
                        }
                        break;
                }
            }
            return b2;
        }

        public string[] IdentifyWeather(int[] c1)
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
                                c2[i] = "Солнечно";
                                break;
                            case 2:
                                c2[i] = "Дождь";
                                break;
                            case 3:
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
                                c2[i] = "Солнечно";
                                break;
                            case 2:
                                c2[i] = "Дождь";
                                break;
                            case 3:
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
                                c2[i] = "Солнечно";
                                break;
                            case 2:
                                c2[i] = "Дождь";
                                break;
                            case 3:
                                c2[i] = "Солнечно";
                                break;
                            case 4:
                                c2[i] = "Солнечно";
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
                                c2[i] = "Солнечно";
                                break;
                            case 2:
                                c2[i] = "Дождь";
                                break;
                            case 3:
                                c2[i] = "Солнечно";
                                break;
                            case 4:
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
                                c2[i] = "Солнечно";
                                break;
                            case 2:
                                c2[i] = "Дождь";
                                break;
                            case 3:
                                c2[i] = "Солнечно";
                                break;
                            case 4:
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

        public string[] IdentifyTracks(int[] a1)//заполняем значения
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
                                a2[i] = "Улицы мал";
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
                                a2[i] = "Улицы мал";
                                break;
                            case 14:
                                a2[i] = "Парковка";
                                break;
                            case 15:
                                a2[i] = "Слалом";
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
                                a2[i] = "Улицы ср";
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
                                a2[i] = "Улицы мал";
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
                                a2[i] = "Улицы ср";
                                break;
                            case 9:
                                a2[i] = "Улицы мал";
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
                            default:
                                a2[i] = "Неизвестная трасса";
                                break;
                        }
                        break;
                }
            }
            return a2;
        }

        public int[] TrackRank(string[] a2)
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
                            "Токио петля",
                            "Замерзшее озеро",
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
                            "Лесная переправа",
                            "Ралли-кросс мал",
                            "Ралли кросс ср",
                            "Крутой холм",
                            "Лесная дорога",
                            "Монако узкие улицы",
                            "Монако тест на перегрузки",
                            "Токио тест на перегрузки ",
                            "Трасса для картинга",
                            "Парковка",
                            "Лесной слалом",
                            "Закрытый картинг",
                            "Слалом",
                            "Перегрузка",
                            "Неизвестная трасса"
        };//иерархия трасс
            for (int i = 0; i < 5; ++i)
            {
                int flag = 0;
                for (int j = 0; j < ar.Length; ++j)
                {                    
                    if(a2[i] == ar[j])
                    {
                        a3[i] = j + 1;
                        flag = 1;
                        break;
                    }                   
                }
                if (flag == 0)
                {
                    NotePad.DoLog("Исправить название " + a2[i]);
                    a3[i] = 100;
                }
            }
            return a3;
        }
    }

    public class IdentifyCar
    {
        public int Identify1Car(int a)//заполняем кейсы
        {
            int carid = 0;
            switch (a)
            {
                default:
                    break;
            }
            return carid;
        }

        public int Identify2Car(int a)//заполняем кейсы
        {
            int carid = 0;
            switch (a)
            {
                default:
                    break;
            }
            return carid;
        }

        public int Identify3Car(int a)//заполняем кейсы
        {
            int carid = 0;
            switch (a)
            {
                default:
                    break;
            }
            return carid;
        }

        public int Identify4Car(int a)//заполняем кейсы
        {
            int carid = 0;
            switch (a)
            {
                default:
                    break;
            }
            return carid;
        }

        public int Identify5Car(int a)//заполняем кейсы
        {
            int carid = 0;
            switch (a)
            {
                default:
                    break;
            }
            return carid;
        }
        
        public double[] CarStats(int carid)//заполнить новым списком
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
                default:
                    NotePad.DoLog("Неизвестная тачка");
                    clearance = 1;
                    tires = 2;
                    drive = 2;
                    acceleration = 30;
                    maxspeed = 100;
                    grip = 75;
                    weight = 1500;
                    break;
            }
            double[] stats = { clearance, tires, drive, acceleration, maxspeed, grip, weight };
            return stats;
        }
    }  

    public class Algorithms
    {
        public double CalculateCompatibility(string track, string coverage, string weather, double[] carstats)
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
            carsid[1] = idcar.Identify2Car(carsid[1]);
            carsid[2] = idcar.Identify3Car(carsid[2]);
            carsid[3] = idcar.Identify4Car(carsid[3]);
            carsid[4] = idcar.Identify5Car(carsid[4]);
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
                Thread.Sleep(3000);
                double empty = -5000;
                double x;
                int usingfinger = 0;
                for (int n = 0; n < 5; n++)
                {
                    if (carstats[n] == emptycar)
                    {
                        x = -10000;
                    }
                    else
                    {
                        x = al.CalculateCompatibility(d[0, j], d[1, j], d[2, j], carstats[n]);
                    }

                    if (x > empty)
                    {
                        usingfinger = n;//choose the best car for track
                        empty = x;
                    }
                }
                f.DragnDrop(a[usingfinger], b[j]);//set choosen car on track
                carstats[usingfinger] = emptycar;//set used finger as empty
            }
        }
    }

    public class HandMaking
    {
        private void ChooseTires(int eventN, string cls)
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

            Thread.Sleep(500);
            f1.Clk1(tires);
            switch (eventN)
            {
                case 1://twists n turns
                    f1.Clk1(dynamic);
                    f1.Clk1(standart);
                    break;
                case 2://off-road outlaws
                    switch (cls)
                    {
                        case "f":
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
                default:
                    break;
            }
        }

        public int[] ConditionHandling(int condition, int rq, int tires, int[,] hand)
        {
            int n;
            int[] finger = new int[5];
            Random r = new Random();
            int handrq;
            switch (condition)
            {
                case 7://Japan x5
                    finger[0] = 0;
                    finger[1] = 0;
                    finger[2] = 0;
                    finger[3] = 0;
                    finger[4] = 0;
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Нет выше эпиков");
                    break;

                case 6://необычные 5
                    finger[0] = 1;
                    finger[1] = 1;
                    finger[2] = 1;
                    finger[3] = 1;
                    finger[4] = 1;
                    NotePad.DoLog("партия необычных машин");
                    break;

                case 3://обычная х3
                    finger[0] = 0;
                    finger[1] = 0;
                    finger[2] = 0;
                    finger[3] = 0;
                    finger[4] = 0;
                    handrq = 0;
                    for (int x = 0; x < 4; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3)
                    {
                        do
                        {
                            n = r.Next(0, 2);
                        } while (finger[n] == 6);
                        finger[n]++;

                        handrq = 0;
                        for (int x = 0; x < 5; x++)
                        {
                            handrq += hand[x, finger[x]];
                        }
                    }
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
                    break;

                case 2://передний привод
                    finger[0] = 0;
                    finger[1] = 0;
                    finger[2] = 0;
                    finger[3] = 0;
                    finger[4] = 0;
                    handrq = 0;
                    for (int x = 0; x < 4; x++)
                    {
                        handrq += hand[x, finger[x]];
                    }
                    while ((rq - handrq) > 3 || rq == 110)
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
                    break;

                default:
                    finger[0] = 0;
                    finger[1] = 0;
                    finger[2] = 0;
                    finger[3] = 0;
                    finger[4] = 0;
                    handrq = 0;
                    for (int x = 0; x < 4; x++)
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

        public void MakingTryHandwith1Condition(int rq, int condition, int tires)
        {
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
            
            int[] ar = ConditionHandling(condition, rq, tires, hand);           

            int var; //недобор
            int usedhandslots = 0;

            Thread.Sleep(1000);
            if (condition != 0) f1.Clk(640, 265); //включить фильтр условия события
            Thread.Sleep(1000);

            if (ar[0] > 0)
            {
                Randomizer(condition, rq, tires);
                var = UseFilter("s", ar[0], usedhandslots, tires, condition);
                usedhandslots += ar[0] - var;
                ar[1] += var;
            }

            if (ar[1] > 0)
            {
                Randomizer(condition, rq, tires);
                var = UseFilter("a", ar[1], usedhandslots, tires, condition);
                usedhandslots += ar[1] - var;
                ar[2] += var;
            }

            if (ar[2] > 0)
            {
                Randomizer(condition, rq, tires);
                var = UseFilter("b", ar[2], usedhandslots, tires, condition);
                usedhandslots += ar[2] - var;
                ar[3] += var;
            }

            if (ar[3] > 0)
            {
                Randomizer(condition, rq, tires);
                var = UseFilter("c", ar[3], usedhandslots, tires, condition);
                usedhandslots += ar[3] - var;
                ar[4] += var;
            }

            if (ar[4] > 0)
            {
                Randomizer(condition, rq, tires);
                var = UseFilter("d", ar[4], usedhandslots, tires, condition);
                usedhandslots += ar[4] - var;
                ar[5] += var;
            }

            if (ar[5] > 0)
            {
                Randomizer(condition, rq, tires);
                var = UseFilter("e", ar[5], usedhandslots, tires, condition);
                usedhandslots += ar[5] - var;
                ar[6] += var;
            }

            if (ar[6] > 0)
            {
                Randomizer(condition, rq, tires);
                UseFilter("f", ar[6], usedhandslots, tires, condition);
            }

            if (VerifyHand())//проверка руки, чтобы не сохранял пустые картинки
            {
                int[] carsid = RememberHand();
                NotePad.Saves(rq, condition, tires, carsid);
            }
        }

        public bool CarFixed(int slot)//величины не исправлены с версии 0.04
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
            Thread.Sleep(1500);
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
            Thread.Sleep(1700); //1100 мало
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
            Point HandSlot1 = new Point(160, 775);
            Point HandSlot2 = new Point(355, 775);
            Point HandSlot3 = new Point(545, 775);
            Point HandSlot4 = new Point(740, 775);
            Point HandSlot5 = new Point(930, 775);
            Point[] a = { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };
            bool x = true;
            string emptyslot = "Color [A=255, R=200, G=200, B=200]";

            for (int i = 0; i < 5; i++)
            {
                if (MasterOfPictures.PixelIndicator(a[i]) == emptyslot)
                {                   
                    x = false;
                    break;
                }
            }

            return x;
        }

        private int[] RememberHand()
        {
            Rectangle HandSlot1 = new Rectangle(85, 725, 115, 65);
            Rectangle HandSlot2 = new Rectangle(280, 725, 115, 65);
            Rectangle HandSlot3 = new Rectangle(470, 725, 115, 65);
            Rectangle HandSlot4 = new Rectangle(660, 725, 115, 65);
            Rectangle HandSlot5 = new Rectangle(850, 725, 115, 65);
            string carsDB = "Finger";
            int lastcar = 700;
            int[] carsid = new int[5];

            int n;
            bool flag;
            Rectangle[] b = { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };
            for (int i = 0; i < 5; i++)
            {
                MasterOfPictures.MakePicture(b[i], (carsDB + (i + 1) + "\\test"));
                flag = true;
                n = 0;
                for (int i1 = 1; i1 < lastcar; i1++)
                {
                    if (File.Exists("C:\\Bot\\Finger" + (i + 1) + "\\" + i1 + ".jpg"))
                    {
                        n = i1;
                    }
                    else break;
                }

                for (int i2 = 1; i2 < (n + 1); i2++)
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

                if (flag == true)
                {
                    NotePad.DoLog("Добавляю новую тачку");
                    carsid[i] = n + 1;
                    File.Move("C:\\Bot\\Finger" + (i + 1) + "\\test.jpg", "C:\\Bot\\Finger" + (i + 1) + "\\" + (n + 1) + ".jpg");
                }
            }

            return carsid;
        }

        private int UseFilter(string cls, int n, int uhl, int tires, int condition)//убрана проверка "в гараже"
        {
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
            FastCheck fc = new FastCheck();
            f1.Clk1(filter);
            Thread.Sleep(2000);;
            f1.Clk1(clear);
            Thread.Sleep(2000);           
            f1.Clk1(rarity);
            Thread.Sleep(3000);
            switch (cls)
            {
                case "f":
                    f1.Clk1(f);//выбрать класс                    
                    break;

                case "e":
                    f1.Clk1(e);//выбрать класс                    
                    break;

                case "d":
                    f1.Clk1(d);//выбрать класс                    
                    break;

                case "c":
                    f1.Clk1(c);//выбрать класс                    
                    break;

                case "b":
                    f1.Clk1(b);//выбрать класс                    
                    break;

                case "a":
                    f1.Clk1(a);//выбрать класс                    
                    break;

                case "s":
                    f1.Clk1(s);//выбрать класс
                    break;
            }

            Thread.Sleep(500);
            //if () здесь прописывать исключение для марок авто с малым выбором покрышек, условия с конкретными покрышками
            ChooseTires(tires, cls); //исключить всесезонки, стандарты и иконы стиля 
            Thread.Sleep(1000);
            f1.Clk1(accept);
            Thread.Sleep(2500);           
            int emptycars = f1.DragnDpopHand(n, uhl);

            return emptycars;
        }

        private void Randomizer(int condition, int rq, int tires)
        {
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
            while (!fc.InGarage()) Thread.Sleep(2000);
            switch (condition)
            {
                case 6:
                    if (rq < 50)
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
                        Thread.Sleep(1000);
                        switch (tires)
                        {
                            default:
                                int r = rand.Next(10);
                                p = a[r];
                                switch (r + 1)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 5:
                                        f1.Clk(p.X, p.Y);//выбрать условие
                                        Thread.Sleep(200);
                                        f1.Clk(p.X, p.Y);//выбрать условие                                
                                        break;

                                    case 4:
                                    case 9:
                                    case 10:
                                        f1.Clk(p.X, p.Y);//выбрать условие                                
                                        break;

                                    default:
                                        if (rand.Next(2) == 1)
                                        {
                                            f1.Clk(p.X, p.Y);//выбрать условие
                                            Thread.Sleep(200);
                                        }
                                        f1.Clk(p.X, p.Y);//выбрать условие                                
                                        break;
                                }
                                break;
                        }
                    }
                    break;

                default:
                    if (rq < 30)
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
                        Thread.Sleep(1000);
                        switch (tires)
                        {
                            default:
                                int r = rand.Next(10);
                                p = a[r];
                                switch (r + 1)
                                {
                                    case 1:
                                    case 2:
                                    case 3:
                                    case 5:
                                        f1.Clk(p.X, p.Y);//выбрать условие
                                        Thread.Sleep(200);
                                        f1.Clk(p.X, p.Y);//выбрать условие                                
                                        break;

                                    case 4:
                                    case 9:
                                    case 10:
                                        f1.Clk(p.X, p.Y);//выбрать условие                                
                                        break;

                                    default:
                                        if (rand.Next(2) == 1)
                                        {
                                            f1.Clk(p.X, p.Y);//выбрать условие
                                            Thread.Sleep(200);
                                        }
                                        f1.Clk(p.X, p.Y);//выбрать условие                                
                                        break;
                                }
                                break;
                        }
                    }
                    break;
            }
            Thread.Sleep(500);
            f1.Clk(840, 790);//закрыть сортировку
            Thread.Sleep(4000);
        }
    }

    public class NotePad
    {
        public static void DoLog(string text)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Log.txt", true, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine(text + "  " + DateTime.Now.ToLongTimeString());
                sw.Close();
            }
        }

        public static void Saves(int rq, int condition, int tires, int[] carsid)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Saves.txt", false, System.Text.Encoding.Default))//true для дописывания 
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
            using (StreamReader sr = new StreamReader(@"C:\Bot\Saves.txt", System.Text.Encoding.Default))
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
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Log.txt", false, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine("Начинаю новую сессию");
                sw.Close();
            }
        }
    }   

    public class MasterOfPictures
    {
        private static Bitmap captured; //создаем объект Bitmap (растровое изображение), будет нужен как при самом получении изображения, так и при сохранении изображения

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
                captured.Save("C:\\Bot\\" + PATH + ".jpg", ImageFormat.Jpeg);
            }
            gdi.Dispose();
            captured.Dispose();
        }

        public static bool Verify(string PATH, string ORIGINALPATH)
        {
            Bitmap picturetest = new Bitmap("C:\\Bot\\" + PATH + ".jpg");
            Bitmap picture = new Bitmap("C:\\Bot\\" + ORIGINALPATH + ".jpg");
            bool flag1 = true;
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

            BW.Save("C:\\Bot\\" + PATH + ".jpg", ImageFormat.Jpeg); // Save the black and white image         

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

            BW.Save("C:\\Bot\\" + PATH + ".jpg", ImageFormat.Jpeg); // Save the black ad white image            

            gdi.Dispose();
            captured.Dispose();
            BW.Dispose();
        }

        public static bool VerifyBW(string PATH, string ORIGINALPATH, int maxdiffernces)
        {
            //Console.WriteLine("Начал проверку " + PATH);
            Bitmap picturetest = new Bitmap("C:\\Bot\\" + PATH + ".jpg");
            Bitmap picture = new Bitmap("C:\\Bot\\" + ORIGINALPATH + ".jpg");
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
            return flag1;
        }
    }

    public class FastCheck
    {
        Form1 f1 = new Form1();        

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
            Rectangle ClubBountyBounds = new Rectangle(520, 740, 240, 25);
            MasterOfPictures.MakePicture(ClubBountyBounds, ClubBounty);
            if (MasterOfPictures.Verify(ClubBountyOriginal, ClubBounty))
            {
                f1.Clk(635, 750);
                x = true;
            }
            return x;
        }

        public bool ActiveEvent()
        {
            bool x = false;
            string ButtonToEventTest = "HeadPictures\\TestButtonToEventBounds";
            string ButtonToEventOriginal = "HeadPictures\\OriginalButtonToEventBounds";
            Rectangle ButtonToEventBounds = new Rectangle(1055, 790, 20, 20);
            MasterOfPictures.MakePicture(ButtonToEventBounds, ButtonToEventTest);
            if (MasterOfPictures.Verify(ButtonToEventOriginal, ButtonToEventTest)) x = true;

            return x;
        }

        public bool EmptyGarageSlot(int n)//Исправить величины
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
            string ControlScreenOriginal1 = "HeadPictures\\OriginalControlScreen1";
            Rectangle ControlScreenBounds = new Rectangle(790, 790, 85, 25);
            bool x = false;
            MasterOfPictures.MakePicture(ControlScreenBounds, ControlScreenPath);
            if (MasterOfPictures.Verify(ControlScreenPath, ControlScreenOriginal) || MasterOfPictures.Verify(ControlScreenPath, ControlScreenOriginal1)) x = true;
            return x;
        }

        public bool ClubMap()
        {
            string ClubMapPath = "HeadPictures\\TestClubMap";
            string ClubMapOriginal = "HeadPictures\\OriginalClubMap";
            Rectangle ClubMapBounds = new Rectangle(800, 720, 30, 30);
            bool x = false;
            MasterOfPictures.MakePicture(ClubMapBounds, ClubMapPath);
            if (MasterOfPictures.Verify(ClubMapPath, ClubMapOriginal)) x = true;
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

        public bool InGarage()
        {
            bool x = false;
            string InGaragePath = "HeadPictures\\TestInGarage";
            string InGarageOriginal = "HeadPictures\\OriginalInGarage";
            Rectangle InGarageBounds = new Rectangle(200, 190, 90, 30);
            MasterOfPictures.MakePicture(InGarageBounds, InGaragePath);
            if (MasterOfPictures.Verify(InGaragePath, InGarageOriginal))
            {
                x = true;
                NotePad.DoLog("нахожусь в гараже");
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
        /*
             UniversalCapture(FullEventBounds, FullEventPath);//проверка сообщения "эвент заполнен"
                    if (Verify(FullEventPath, FullEventOriginal))            
            */
    }

    public class Waiting
    {
        SpecialEvents se = new SpecialEvents();
        FastCheck fc = new FastCheck();
        Form1 f1 = new Form1();
        public void StartIcon()
        {
            Rectangle IcBounds = new Rectangle(805, 350, 50, 40);
            string IcPath = "HeadPictures\\TestIcon";
            string IcOriginal = "HeadPictures\\OriginalIcon";
            do
            {
                MasterOfPictures.MakePicture(IcBounds, IcPath);
                Thread.Sleep(2000);
            } while (!MasterOfPictures.Verify(IcPath, IcOriginal));
        }

        public void StartButton()
        {
            string AlcPath = "HeadPictures\\TestStart";
            string AlcOriginal = "HeadPictures\\OriginalStart";
            Rectangle AlcBounds = new Rectangle(290, 625, 87, 23);
            do
            {
                MasterOfPictures.MakePicture(AlcBounds, AlcPath);
                Thread.Sleep(2000);
            } while (!MasterOfPictures.Verify(AlcPath, AlcOriginal));
        }

        public void HeadPage()
        {
            string HeadPath = "HeadPictures\\TestHead";
            string HeadOriginal = "HeadPictures\\OriginalHead";
            Rectangle HeadBounds = new Rectangle(196, 187, 124, 30);
            do
            {
                MasterOfPictures.MakePicture(HeadBounds, HeadPath);
                Thread.Sleep(2000);
            } while (!MasterOfPictures.Verify(HeadPath, HeadOriginal));
        }

        public void EventPage()
        {
            string EventPath = "HeadPictures\\TestEvent";
            string EventOriginal = "HeadPictures\\OriginalEvent";
            Rectangle EventBounds = new Rectangle(196, 187, 134, 30);
            do
            {
                fc.Bounty();
                MasterOfPictures.MakePicture(EventBounds, EventPath);
                Thread.Sleep(2000);
            } while (!MasterOfPictures.Verify(EventPath, EventOriginal));
        }

        public void ClubMap()
        {
            string ClubMapPath = "HeadPictures\\TestClubMap";
            string ClubMapOriginal = "HeadPictures\\OriginalClubMap";
            Rectangle ClubMapBounds = new Rectangle(800, 720, 30, 30);
            do
            {
                fc.Bounty();
                MasterOfPictures.MakePicture(ClubMapBounds, ClubMapPath);
                Thread.Sleep(2000);
            } while (!MasterOfPictures.Verify(ClubMapPath, ClubMapOriginal));
        }

        public void ReadytoRace()
        {
            string GarageRaceButtonPath = "HeadPictures\\TestGarageRaceButton";
            string GarageRaceButtonOriginal = "HeadPictures\\OriginalGarageRaceButton";
            Rectangle GarageRaceButtonBounds = new Rectangle(1075, 795, 95, 20);
            do
            {
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

        public void RaceOn()
        {
            string RacePath = "HeadPictures\\TestRace";
            string RaceOriginal = "HeadPictures\\OriginalRace";
            string RaceOriginal1 = "HeadPictures\\OriginalRace1";
            Rectangle RaceBounds = new Rectangle(60, 185, 40, 40);
            do
            {
                se.UniversalErrorDefense();
                MasterOfPictures.MakePicture(RaceBounds, RacePath);
                Thread.Sleep(500);
            } while (!MasterOfPictures.Verify(RacePath, RaceOriginal) && !MasterOfPictures.Verify(RacePath, RaceOriginal1));
        }

        public void RaceOff()
        {
            string RacePath = "HeadPictures\\TestRace";
            string RaceOriginal = "HeadPictures\\OriginalRace";
            string RaceOriginal1 = "HeadPictures\\OriginalRace1";
            Rectangle RaceBounds = new Rectangle(60, 185, 40, 40);
            do
            {
                MasterOfPictures.MakePicture(RaceBounds, RacePath);
                Thread.Sleep(500);
            } while (MasterOfPictures.Verify(RacePath, RaceOriginal) || MasterOfPictures.Verify(RacePath, RaceOriginal1));
        }

        public void ForEnemy()
        {
            string ChooseanEnemyPath = "HeadPictures\\TestChooseanEnemy";
            string ChooseanEnemyOriginal = "HeadPictures\\OriginalChooseanEnemy";
            Rectangle ChooseanEnemyBounds = new Rectangle(155, 620, 7, 7);
            do
            {
                se.UniversalErrorDefense();
                MasterOfPictures.BW2Capture(ChooseanEnemyBounds, ChooseanEnemyPath);
                Thread.Sleep(1500);
            } while (!MasterOfPictures.VerifyBW(ChooseanEnemyPath, ChooseanEnemyOriginal, 10));
        }

        public void Table()
        {
            FastCheck fc = new FastCheck();
            do
            {
                Thread.Sleep(2000);
            } while (!fc.Ending());
        }
    }

    public class ChooseEvent
    {
        FastCheck fc = new FastCheck();
        Form1 f1 = new Form1();
        public int c = 7;//known condition number

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
                }
                Thread.Sleep(2000);
            } while (flag == false);

            GotRQ();//времянка для сбора рк

            MasterOfPictures.MakePicture(Condition1Bounds, Condition1);
            MasterOfPictures.MakePicture(Condition2Bounds, Condition2);            
            if (MasterOfPictures.Verify(Condition2, "Condition2\\CC0"))
            {
                for (x = 1; x < (c + 1); x++)//добавить 0 когда найду эвент без условий
                {
                    if (MasterOfPictures.Verify(Condition1, ("Condition1\\C" + x)))
                    {
                        break;
                    }
                }
                NotePad.DoLog("номер условия " + x);
                if (x == (c + 1))
                {                    
                    NotePad.DoLog("Неизвестное условие");
                    for (x = 1; x < 100; x++)
                    {
                        if(File.Exists("C:\\Bot\\Condition1\\UnknownCondition" + x + ".jpg"))
                        {
                            if(MasterOfPictures.Verify(Condition1, ("Condition1\\UnknownCondition" + x)))
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

                if (x != 500) //Исключаю неизвестный
                {
                    int rq = GotRQ();
                    /*if (rq > 17)
                    {
                        NotePad.DoLog(eventN + " событие подходит");
                        NotePad.DoLog("1 условие = " + x);
                        if (x == 42 && rq < 38)
                        {
                            NotePad.DoLog("выпало исключение citroen");
                            x = 500;
                        }

                        if (x == 52 && rq < 33)
                        {
                            NotePad.DoLog("выпало исключение pontiac");
                            x = 500;
                        }

                        if (x == 51 && rq < 58)
                        {
                            NotePad.DoLog("выпало исключение opel");
                            x = 500;
                        }

                        if (x == 44 && rq < 53)
                        {
                            NotePad.DoLog("выпало исключение dodge");
                            x = 500;
                        }

                        if (x == 38 && rq < 53)
                        {
                            NotePad.DoLog("выпало исключение альфа");
                            x = 500;
                        }
                        if (x == 33 && rq < 58)
                        {
                            NotePad.DoLog("выпало исключение франция");
                            x = 500;
                        }
                        if (x == 34 && rq < 54)
                        {
                            NotePad.DoLog("выпало исключение кадил");
                            x = 500;
                        }
                    }
                    else*/

                    if (rq < 17)
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
                        if (MasterOfPictures.Verify(RQPath , ("RQ\\UnknownRQ" + x)))
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

}
//заготовки для обработки условий ConditionHandling
/*
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк понтиак 102");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк опель 110");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк шеви 130");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк бмв 140");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк додж 110");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк ситроен 76");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк alfa 108");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк cadillac 140");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк фр ренесанса 130");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк хонды 110");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";    у икон стиля только 4 экстрима и одна обычная");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   У субару 4 эпика");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq));
                    break;

                case 15://Uncommon x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 1;
                    }
                    NotePad.DoLog("собрал необычные");
                    break;

                case 8://Common x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 0;
                    }
                    NotePad.DoLog("собрал обычные");
                    break;

                case 48:
                case 2://Rare x5
                    for (int x = 0; x < 5; x++)
                    {
                        finger[x] = 2;
                    }
                    NotePad.DoLog("собрал редкостные");
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
                        NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк переднего привода 110");
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
                        NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Максимальное рк переднего привода 110");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";  только 2 эпика");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";  только 2 эпика");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";  только 1 эпик и 1 лега");
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
                    NotePad.DoLog("требуемое рк: " + rq + ";   рк руки: " + handrq + ";   разница в рк: " + (rq - handrq) + ";   Нет выше эпиков");
                    break;                
*/