﻿using System.Diagnostics;
using System.Threading;

namespace Caitlyn_v1._0
{
    class Navigation
    {
        ChooseEvent ce = new ChooseEvent();
        FastCheck fc = new FastCheck();
        SpecialEvents se = new SpecialEvents();

        public void ToClubMap()
        {
            NotePad.ClearLog();
            Process.Start(@"C:\Program Files (x86)\Nox\bin\Nox.exe", "-clone:Nox_1");
            Thread.Sleep(10000);

            se.ToClubs();
        }

        public void InClubs()
        {
            while (true)
            {
                se.ToClubs();
                TimingUnit tu = new TimingUnit();
                tu.CheckTime();
                Thread.Sleep(2000);
                int i = 0;
                if (fc.ActiveEvent())
                {
                    NotePad.DoLog("вхожу в активный эвент");
                    i = 1;
                    Rat.Clk(PointsAndRectangles.clubEventEnter);//ClubEventEnter
                    string[] conds = NotePad.ReadConditions();
                    Condition.eventrq = NotePad.ReadRQ();
                    Condition.MakeCondition(conds[0], conds[1]);
                    while (i < 100)
                    {
                        i++;
                        if (!PlayClubs(i)) break;
                    }
                }
                else
                {
                    NotePad.DoLog("Подбираю эвент с одним условием");
                    ce.ChooseNormalEvent();
                    NotePad.DoLog("Вхожу в эвент " + Condition.eventrq + " рк");
                    Rat.Clk(PointsAndRectangles.clubEventEnter);//ClubEventEnter   
                    while (i < 100)
                    {
                        i++;
                        if (!PlayClubs(i)) break;
                    }
                }
            }
        }

        private bool PlayClubs(int i)
        {
            SpecialEvents se = new SpecialEvents();
            Waiting wait = new Waiting();
            FastCheck fc = new FastCheck();
            PlayClubsPositions pcp = new PlayClubsPositions();

            bool eventisactive = pcp.PathToGarage();
            if (eventisactive)
            {
                pcp.PrepareToRace(i);//набор/проверка руки
                wait.ReadytoRace();

                bool foundplace = false;
                do
                {
                    se.CarRepair();
                    se.UniversalErrorDefense();
                    se.UnavailableEvent();
                    //se.CardBug();
                    if (fc.ReadyToRace())
                    {
                        Rat.Clk(PointsAndRectangles.startTheRace);
                        Thread.Sleep(2000);
                    }
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
                } while (!foundplace);//ожидание противника

                if (eventisactive)
                {
                    pcp.TimeToRace();//расстановка

                    se.EndRace();//завершение заезда

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
                            Rat.Clk(PointsAndRectangles.passTheTableAfterRace);//Table
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

                        if (fc.BugControlScreen())
                        {
                            Thread.Sleep(500);
                            NotePad.DoLog("Bug with Control Screen");
                            Rat.Clk(PointsAndRectangles.backToClubMap);//Back
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
