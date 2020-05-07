using System;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApp1
{
    class Navigation
    {
        ChooseEvent ce = new ChooseEvent();
        FastCheck fc = new FastCheck();
        SpecialEvents se = new SpecialEvents();

        public void ToClubMap()
        {
            NotePad.ClearLog();
            Process.Start(@"C:\Program Files (x86)\Nox\bin\Nox.exe", "-clone:Nox_2");

            Thread.Sleep(10000);

            do
            {
                if (fc.StartIcon()) Rat.Clk(830, 375);//Icon
                Thread.Sleep(200);
                if (fc.StartButton()) Rat.Clk(340, 600);//Start game
                Thread.Sleep(200);
                if (fc.HeadPage()) Rat.Clk(630, 390);//Events
                Thread.Sleep(200);
                fc.Bounty();
                Thread.Sleep(200);
                se.UniversalErrorDefense();
                Thread.Sleep(200);
                if (fc.EventPage()) Rat.Clk(240, 500);//Clubs
                Thread.Sleep(200);
            } while (!fc.ClubMap());

            se.DragMap();
        }

        public void InClubs()
        {
            bool gotawayfromclub;
            while (true)
            {
                gotawayfromclub = false;
                do
                {                    
                    if (fc.HeadPage())
                    {
                        NotePad.DoLog("вылетел из клубов в главное меню");
                        Rat.Clk(630, 390);//Events
                    }                        
                    Thread.Sleep(200);
                    fc.Bounty();
                    Thread.Sleep(200);
                    se.UniversalErrorDefense();
                    Thread.Sleep(200);
                    if (fc.EventPage())
                    {
                        Rat.Clk(240, 500);//Clubs
                        gotawayfromclub = true;
                        NotePad.DoLog("вернулся в клубы");
                    }                        
                    Thread.Sleep(200);
                } while (!fc.ClubMap());

                if(gotawayfromclub) se.DragMap();

                Thread.Sleep(2000);
                int i = 0;
                if (fc.ActiveEvent())
                {
                    NotePad.DoLog("вхожу в активный эвент");
                    i = 1;
                    Rat.Clk(1060, 800);
                    int[] a = NotePad.ReadSaves();
                    int[] b = new int[5];
                    Condition.eventrq = a[0];
                    Condition.MakeCondition(a[1]);
                    Array.Copy(a, 3, b, 0, 5);
                    while (i < 100)
                    {
                        i++;
                        if (!PlayClubs(a[1], a[2], i)) break;
                    }
                }

                else
                {
                    NotePad.DoLog("Подбираю эвент с одним условием");
                    int condition = ce.ChooseNormalEvent();
                    int eventname = ce.WhichEvent();
                    NotePad.DoLog("Вхожу в эвент " + Condition.eventrq + " рк");
                    Rat.Clk(1060, 800);//ClubEventEnter   
                    while (i < 100)
                    {
                        i++;
                        if (!PlayClubs(condition, eventname, i)) break;
                    }
                }
            }
        }

        private bool PlayClubs(int condition, int eventname, int i)
        {
            SpecialEvents se = new SpecialEvents();
            Waiting wait = new Waiting();
            FastCheck fc = new FastCheck();
            PlayClubsPositions pcp = new PlayClubsPositions();

            bool eventisactive = pcp.PathToGarage();
            if (eventisactive)
            {
                pcp.PrepareToRace(condition, eventname, i);//набор/проверка руки
                wait.ReadytoRace();
                Rat.Clk(1120, 800);//GarageRaceButton
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
                    pcp.TimeToRace();//расстановка

                    Thread.Sleep(5000);
                    Rat.Clk(640, 215); //кнопка "пропустить"
                    Thread.Sleep(4000);
                    Rat.Clk(890, 625);//подтвержение "пропуска"
                    Thread.Sleep(5000);
                    Rat.Clk(635, 570);//звезды  

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
                            Rat.Clk(820, 730);//Table
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
}