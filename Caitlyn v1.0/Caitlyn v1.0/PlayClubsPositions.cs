using System.Threading;

namespace Caitlyn_v1._0
{
    public class PlayClubsPositions
    {
        public bool PathToGarage()
        {
            FastCheck fc = new FastCheck();
            GameState.antiLoopCounter = 0;
            do
            {
                if (GameState.antiLoopCounter == 60) SpecialEvents.RestartBot();
                CommonLists.SkipAllSkipables();
                if (fc.ClubMap())
                {
                    Thread.Sleep(2000);
                    if (fc.ClubMap())
                    {
                        NotePad.DoLog("выкинуло на карту");
                        return false;
                    }
                }
                if (fc.ItsGarage())
                {
                    NotePad.DoLog("Нахожусь в гараже");    
                    return true;
                }                
                Thread.Sleep(1000);
                GameState.antiLoopCounter++;
            } while (true);
        }
        public bool PrepareToRace(int i)
        {
            FastCheck fc = new FastCheck();            
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
                    SpecialEvents.RestartBot();
                }
                else
                {
                    wronghandnumber++;
                    CommonLists.SkipAllSkipables();
                    if (fc.ClubMap())
                    {
                        NotePad.DoLog("вылетел на карту при сборе руки");
                        return false;
                    }
                    if (i == 1)
                    {
                        NotePad.DoLog("Собираю пробную руку");
                        MakeHand();
                    }
                    if (i == 2)//пересборка по покрытию
                    {
                        NotePad.DoLog("Меняю руку с учетом покрытия и погоды");
                        MakeHand();
                    }
                    Thread.Sleep(4000);
                    if (!hm.HandCarFixed() || !hm.VerifyHand())
                    {
                        NotePad.DoLog("Меняю руку");
                        MakeHand();
                    }
                }
            } while (!hm.VerifyHand());
            return true;
        }
        bool MakeHand()
        {
            HandMaking hm = new HandMaking();
            if (!SpecialEvents.ClearHand()) return false;
            Thread.Sleep(1000);
            return hm.MakingHand();
        }
        public bool TimeToRace()
        {
            FastCheck fc = new FastCheck();            
            bool raceIsStarted = false;
            GameState.antiLoopCounter = 0;            
            GrandArrangement ga = new GrandArrangement();
            do
            {
                if (GameState.antiLoopCounter == 120) SpecialEvents.RestartBot();
                CommonLists.SkipAllSkipables();                
                if (fc.ClubMap())
                {
                    NotePad.DoLog("вылетел из заезда");
                    return false;
                }                
                if (fc.ArrangementWindow())
                {
                    NotePad.DoLog("загрузился экран расстановки");
                    Thread.Sleep(1000);
                    ga.Arrangement();
                    NotePad.DoLog("расстановка выполнена");
                }
                if (fc.RaceOn() && !raceIsStarted)
                {
                    raceIsStarted = true;
                    NotePad.DoLog("заезд начался");
                    Thread.Sleep(2000);
                    //Rat.Clk(PointsAndRectangles.forceTheRace); //ускорить заезд, клик в пусой области
                    Rat.Clk(PointsAndRectangles.allpoints["forceTheRace"]);
                }
                if (!fc.RaceOn() && raceIsStarted)
                {
                    NotePad.DoLog("заезд окончен");
                    return true;
                }
                Thread.Sleep(1000);
                GameState.antiLoopCounter++;
            } while (true);
        }
    }
}
