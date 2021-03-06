﻿using System.Drawing;
using System.Threading;

namespace WindowsFormsApp1 //universal
{
    public class PlayClubsPositions
    {
        Point bountyForSeason = new Point(635, 660);
        Point eventIsEnd = new Point(640, 590);
        Point closeCarCard = new Point(685, 280);
        Point controlScreenToGarage = new Point(820, 790);
        Point bugwithControlScreen = new Point(70, 205);
        Point ChooseAnEnemy = new Point(640, 705);
        Point forceTheRace = new Point(180, 580);

        public bool PathToGarage()
        {
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

                if (fc.SeasonEndsBounty())
                {
                    Thread.Sleep(500);
                    Rat.Clk(bountyForSeason);
                    NotePad.DoLog("получил награду за сезон");
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
                    Rat.Clk(eventIsEnd);//Accept Message                    
                    Thread.Sleep(3000);
                    positionflag = true;
                }

                if (fc.CarMenu())
                {
                    Thread.Sleep(500);
                    NotePad.DoLog("Закрываю меню автомобиля");
                    Rat.Clk(closeCarCard);
                    Thread.Sleep(1000);
                }

                if (fc.ControlScreen())
                {
                    Thread.Sleep(500);
                    NotePad.DoLog("Перехожу в гараж");
                    Rat.Clk(controlScreenToGarage);//Play
                    Thread.Sleep(1000);
                }

                if (fc.BugControlScreen())
                {
                    Thread.Sleep(500);
                    NotePad.DoLog("Bug with Control Screen");
                    Rat.Clk(bugwithControlScreen);//Back
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

        public void PrepareToRace(int i)
        {
            SpecialEvents se = new SpecialEvents();
            HandMaking hm = new HandMaking();
            NotePad.DoLog("Rq = " + Condition.eventrq 
                + ", условие 1: " + Condition.ConditionNumber1
                + ", условие 2: " + Condition.ConditionNumber2
                +  " заезд: " + i);

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
                        hm.MakingHand();
                    }

                    if (i == 2)//пересборка по покрытию
                    {
                        se.ClearHand();
                        Thread.Sleep(500);
                        NotePad.DoLog("Меняю руку с учетом покрытия и погоды");
                        hm.MakingHand();
                    }

                    if (!hm.HandCarFixed() || !hm.VerifyHand())
                    {
                        se.ClearHand();
                        Thread.Sleep(500);
                        NotePad.DoLog("Меняю руку");
                        hm.MakingHand();
                    }
                }
            } while (!hm.VerifyHand() || !hm.VerifyHand());
        }

        public void TimeToRace()
        {
            FastCheck fc = new FastCheck();
            Waiting wait = new Waiting();
            TrackInfo ti = new TrackInfo();
            GrandArrangement ga = new GrandArrangement();

            int[] a1 = ti.Tracks();//Track info
            int[] b1 = ti.Grounds();//Ground info
            int[] c1 = ti.Weathers();//Weather info

            do
            {
                Rat.Clk(ChooseAnEnemy);//ChooseanEnemy
                Thread.Sleep(500);
            } while (fc.EnemyIsReady()); //100% ChooseanEnemy           
            NotePad.DoLog("противник выбран");
            wait.ArrangementWindow();
            NotePad.DoLog("загрузился экран расстановки");
            Thread.Sleep(1000);
            ga.Arrangement(a1, b1, c1);
            wait.RaceOn();
            Thread.Sleep(2000);
            Rat.Clk(forceTheRace); //ускорить заезд, клик в пусой области
            wait.RaceOff();
        }        
    }    
}