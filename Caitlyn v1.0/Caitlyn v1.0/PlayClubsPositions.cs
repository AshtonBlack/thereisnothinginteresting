using System.Threading;

namespace Caitlyn_v1._0
{
    public class PlayClubsPositions
    {
        public bool PathToGarage()
        {
            FastCheck fc = new FastCheck();
            bool positionflag = false;
            bool continuegame = false;
            SpecialEvents se = new SpecialEvents();
            int waiter = 0;
            do
            {
                if (waiter == 120) se.RestartBot();
                se.UniversalErrorDefense();
                se.MissClick();
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
                Thread.Sleep(1000);
                waiter++;
            } while (!positionflag);

            return continuegame;
        }
        public bool PrepareToRace(int i)
        {
            SpecialEvents se = new SpecialEvents();
            HandMaking hm = new HandMaking();
            NotePad.DoLog("Rq = " + Condition.eventRQ
                + ", условие 1: " + Condition.ConditionNumber1
                + ", условие 2: " + Condition.ConditionNumber2
                + " заезд: " + i);

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
                        NotePad.DoLog("Собираю пробную руку");
                        return MakeHand();
                    }
                    if (i == 2)//пересборка по покрытию
                    {
                        NotePad.DoLog("Меняю руку с учетом покрытия и погоды");
                        return MakeHand();
                    }
                    Thread.Sleep(4000);
                    if (!hm.HandCarFixed() || !hm.VerifyHand())
                    {
                        NotePad.DoLog("Меняю руку");
                        return MakeHand();
                    }
                }
            } while (!hm.VerifyHand());
            return true;
        }
        bool MakeHand()
        {
            SpecialEvents se = new SpecialEvents();
            HandMaking hm = new HandMaking();
            se.ClearHand();
            Thread.Sleep(1000);
            return hm.MakingHand();
        }
        public void TimeToRace()
        {
            FastCheck fc = new FastCheck(); 

            TrackInfo[] tracksInfo = new TrackInfo[5];
            for (int i = 0; i < tracksInfo.Length; i++)
            {
                tracksInfo[i]= new TrackInfo(i+1);
            }
            Condition.setPreviousTracks(tracksInfo);
            bool raceIsEnd = false;
            bool raceIsStart = false;
            int waiter = 0;
            SpecialEvents se = new SpecialEvents();
            GrandArrangement ga = new GrandArrangement();
            do
            {
                if (waiter == 180) se.RestartBot();
                se.UniversalErrorDefense();
                se.MissClick();
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
                    ga.Arrangement();
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
