using System.Threading;

namespace WindowsFormsApp1 //universal
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

                if (fc.SeasonIsEnded())
                {
                    Thread.Sleep(500);
                    Rat.Clk(PointsAndRectangles.acceptSeasonEnd);
                    NotePad.DoLog("сезон окончен");
                }

                if (fc.SeasonEndsBounty())
                {
                    Thread.Sleep(500);
                    Rat.Clk(PointsAndRectangles.bountyForSeason);
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
                    Rat.Clk(PointsAndRectangles.eventIsEnd);//Accept Message                    
                    Thread.Sleep(3000);
                    positionflag = true;
                }

                if (fc.CarMenu())
                {
                    Thread.Sleep(500);
                    NotePad.DoLog("Закрываю меню автомобиля");
                    Rat.Clk(PointsAndRectangles.closeCarCard);
                    Thread.Sleep(1000);
                }

                if (fc.ControlScreen())
                {
                    Thread.Sleep(500);
                    NotePad.DoLog("Перехожу в гараж");
                    Rat.Clk(PointsAndRectangles.controlScreenToGarage);//Play
                    Thread.Sleep(1000);
                }

                if (fc.BugControlScreen())
                {
                    Thread.Sleep(500);
                    NotePad.DoLog("Bug with Control Screen");
                    Rat.Clk(PointsAndRectangles.bugwithControlScreen);//Back
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

                    Thread.Sleep(5000);

                    if (!hm.HandCarFixed() || !hm.VerifyHand())
                    {
                        se.ClearHand();
                        Thread.Sleep(500);
                        NotePad.DoLog("Меняю руку");
                        hm.MakingHand();
                    }
                }
            } while (!hm.VerifyHand());
        }

        public void TimeToRace()
        {
            FastCheck fc = new FastCheck();
            SpecialEvents se = new SpecialEvents();
            TrackInfo ti = new TrackInfo();
            GrandArrangement ga = new GrandArrangement();

            int[] a1 = ti.Tracks();//Track info
            int[] b1 = ti.Grounds();//Ground info
            int[] c1 = ti.Weathers();//Weather info            

            bool raceIsEnd = false;
            bool raceIsStart = false;
            int waiter = 0;
            do
            {
                if (waiter == 180) se.RestartBot();
                se.UniversalErrorDefense();
                if (fc.ClubMap())
                {
                    NotePad.DoLog("вылетел из заезда");
                    raceIsEnd = true;
                }
                if (fc.Bounty())
                {
                    NotePad.DoLog("вылетел из заезда");
                    raceIsEnd = true;
                }
                if (fc.EnemyIsReady())
                {
                    Thread.Sleep(1000);
                    Rat.Clk(PointsAndRectangles.ChooseAnEnemy);//ChooseanEnemy
                    NotePad.DoLog("противник выбран");
                }
                if (fc.ArrangementWindow())
                {
                    NotePad.DoLog("загрузился экран расстановки");
                    Thread.Sleep(1000);
                    ga.Arrangement(a1, b1, c1);
                    NotePad.DoLog("расстановка выполнена");
                }
                if (fc.RaceOn() && !raceIsStart)
                {
                    raceIsStart = true;
                    NotePad.DoLog("заезд начался");                    
                    Thread.Sleep(2000);
                    Rat.Clk(PointsAndRectangles.forceTheRace); //ускорить заезд, клик в пусой области
                }
                if (!fc.RaceOn() && raceIsStart)
                {
                    NotePad.DoLog("заезд окончен");
                    raceIsEnd = true;
                }                
                Thread.Sleep(1000);
                waiter++;
            } while (!raceIsEnd);
        }        
    }    
}