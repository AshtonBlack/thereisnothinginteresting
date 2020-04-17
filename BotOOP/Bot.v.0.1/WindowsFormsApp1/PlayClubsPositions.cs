using System.Threading;

namespace WindowsFormsApp1
{
    public class PlayClubsPositions
    {
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
                    Rat.Clk(640, 590);//Accept Message                    
                    Thread.Sleep(3000);
                    positionflag = true;
                }

                if (fc.ControlScreen())
                {
                    Thread.Sleep(2000);
                    NotePad.DoLog("Перехожу в гараж");
                    Rat.Clk(820, 790);//Play
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

        public void PrepareToRace(int condition, int eventname, int i)
        {
            SpecialEvents se = new SpecialEvents();
            HandMaking hm = new HandMaking();
            NotePad.DoLog("Rq = " + Condition.eventrq + ", условие: " + condition + ", название эвента: " + eventname + " заезд: " + i);

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
                        hm.MakingHand(eventname);
                    }

                    if (i == 2)//пересборка по покрытию
                    {
                        if (Condition.weather != "с прояснением" && Condition.eventrq > 29)
                        {
                            se.ClearHand();
                            Thread.Sleep(500);
                            NotePad.DoLog("Меняю руку с учетом покрытия и погоды");
                            hm.MakingHand(eventname);
                        }
                    }

                    if (!hm.HandCarFixed() || !hm.VerifyHand())
                    {
                        se.ClearHand();
                        Thread.Sleep(500);
                        NotePad.DoLog("Меняю руку");
                        hm.MakingHand(eventname);
                    }
                }
            } while (!hm.VerifyHand() || !hm.VerifyHand());
        }

        public void TimeToRace()
        {
            Waiting wait = new Waiting();
            TrackInfo ti = new TrackInfo();
            GrandArrangement ga = new GrandArrangement();

            int[] a1 = ti.Tracks();//Track info
            int[] b1 = ti.Grounds();//Ground info
            int[] c1 = ti.Weathers();//Weather info

            Rat.Clk(640, 705);//ChooseanEnemy
            NotePad.DoLog("противник выбран");
            Thread.Sleep(1000);
            wait.ArrangementWindow();
            NotePad.DoLog("загрузился экран расстановки");
            Thread.Sleep(1000);
            ga.Arrangement(a1, b1, c1);
            wait.RaceOn();
            Thread.Sleep(2000);
            Rat.Clk(180, 580); //ускорить заезд, клик в пусой области
            wait.RaceOff();
        }        
    }    
}