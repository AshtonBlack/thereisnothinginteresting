using System.Threading;

namespace WindowsFormsApp1
{
    public class PlayClubsPositions
    {
        /*
         * 635, 660 bounty for season
         * 640, 590 event is ended
         * 585, 280 close car card
         * 820, 790 control screen to garage
         * 640, 705 ChooseanEnemy
         * 180, 580 ускорить заезд, клик в пусой области
         */
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
                    Rat.Clk(635, 660);
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
                    Rat.Clk(640, 590);//Accept Message                    
                    Thread.Sleep(3000);
                    positionflag = true;
                }

                if (fc.CarMenu())
                {
                    Thread.Sleep(500);
                    NotePad.DoLog("Закрываю меню автомобиля");
                    Rat.Clk(585, 280);//Play
                    Thread.Sleep(1000);
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

        public void PrepareToRace(int i)
        {
            SpecialEvents se = new SpecialEvents();
            HandMaking hm = new HandMaking();
            NotePad.DoLog("Rq = " + Condition.eventrq + ", условие: " + Condition.conditionNumber +  " заезд: " + i);

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
                        if (Condition.weather != "с прояснением" && Condition.eventrq > 29)
                        {
                            se.ClearHand();
                            Thread.Sleep(500);
                            NotePad.DoLog("Меняю руку с учетом покрытия и погоды");
                            hm.MakingHand();
                        }
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
                Rat.Clk(640, 705);//ChooseanEnemy
                Thread.Sleep(500);
            } while (fc.EnemyIsReady()); //100% ChooseanEnemy           
            NotePad.DoLog("противник выбран");
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