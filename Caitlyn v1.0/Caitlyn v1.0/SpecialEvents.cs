using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace Caitlyn_v1._0
{
    public class SpecialEvents
    {
        public void EndRace()
        {
            FastCheck fc = new FastCheck();
            
            bool nextstep = false;
            int counter = 0;

            do
            {
                CommonLists.SkipAllSkipables();                
                if(counter > 30)
                {
                    NotePad.DoErrorLog("Вероятно, вылет из игры");
                    RestartBot();
                }
                if (fc.RaceEnd())
                {
                    Rat.Clk(PointsAndRectangles.endOfTheFirstRace); //кнопка "пропустить"
                }                
                if (fc.EventEnds())
                {
                    Rat.Clk(PointsAndRectangles.eventEndsAcceptance);//событие закончилось
                }           
                bool needToDragMap = false;
                if (fc.EventPage())
                {
                    if (fc.InCommonEvent())
                    {
                        Thread.Sleep(500);
                        Rat.Clk(PointsAndRectangles.buttonBack);//back
                    }
                    else
                    {
                        Thread.Sleep(500);
                        Rat.Clk(PointsAndRectangles.toClubs);//Clubs
                        needToDragMap = true;
                    }
                }
                Thread.Sleep(1500);
                if(fc.EventEnds()) nextstep = true;
                if (fc.Bounty()) nextstep = true;
                if (fc.ClubMap()) nextstep = true;
                UniversalErrorDefense();
                counter++;
                if (needToDragMap) DragMap();
            } while (!nextstep);
        }
        public void ActivateClubBooster()
        {
            Rat.Clk(PointsAndRectangles.clubBoosterActivation);
            Thread.Sleep(2000);
            Rat.Clk(PointsAndRectangles.clubBoosterAcceptance);
            Thread.Sleep(3000);
        }
        public void DragMap()
        {
            FastCheck fc = new FastCheck();
            fc.Bounty();
            if (fc.EventEnds())
            {
                Rat.Clk(PointsAndRectangles.eventEndsAcceptance);//событие закончилось
            }
            if (fc.ClubMap())
            {
                Rat.DragnDropSlow(PointsAndRectangles.dragMapS, PointsAndRectangles.dragMapE, 8);
            }            
        }
        public void RestartBot()
        {
            Rat.Clk(PointsAndRectangles.noxClosing);//close Nox
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.noxClosingAcceptance);//accept Nox close
            Thread.Sleep(1000);
            Process.Start(@"C:\Bot\BotRestarter\BotRestarter\bin\Debug\BotRestarter.exe");
            Process.GetCurrentProcess().Kill();
        }
        public void CarRepair()
        {
            FastCheck fc = new FastCheck();

            if (fc.CarRepair())
            {
                RestartBot();
            }
        }
        public void UniversalErrorDefense()
        {
            FastCheck fc = new FastCheck();
            CommonLists.SkipAllSkipables();
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
            FastCheck fc = new FastCheck();
            Point[] a = new Point[] { PointsAndRectangles.pHandSlot1,
                PointsAndRectangles.pHandSlot2,
                PointsAndRectangles.pHandSlot3,
                PointsAndRectangles.pHandSlot4,
                PointsAndRectangles.pHandSlot5 };
            for (int i = 0; i < 5; i++)
            {
                if (fc.ItsGarage())
                {
                    Point endPoint = new Point(a[i].X, a[i].Y - 270);
                    Rat.DragnDropSlow(a[i], endPoint, 10);
                }
                else
                {
                    break;
                }                
            }
        }
        public bool UnavailableEvent()
        {
            FastCheck fc = new FastCheck();
            bool x = true;
            UniversalErrorDefense();
            Thread.Sleep(3000);
            if (fc.WrongParty())
            {
                NotePad.DoLog("Косячная рука");
                RestartBot();
            }
            if (fc.EventEnds())
            {
                NotePad.DoLog("эвент окончен");
                Rat.Clk(PointsAndRectangles.eventEndsAcceptance);//Accept Message
                Thread.Sleep(3000);
            }
            CommonLists.SkipAllSkipables();
            if (fc.EventisFull())
            {
                NotePad.DoLog("эвент заполнен");
                Rat.Clk(PointsAndRectangles.eventIsFullAcceptance);//Accept Message

                if (fc.ItsGarage())
                {
                    Rat.Clk(PointsAndRectangles.buttonBack);//back
                    Thread.Sleep(2000);
                    Rat.Clk(PointsAndRectangles.buttonBack);//back to club map
                }
                Thread.Sleep(3000);
                x = false;
            }
            return x;
        }
        public void MissClick()
        {
            FastCheck fc = new FastCheck();
            if (fc.EventEnds())
            {
                Rat.Clk(PointsAndRectangles.eventEndsAcceptance);//событие закончилось
                Thread.Sleep(2000);
            }
            CommonLists.SkipAllSkipables();
        }
        public void AcceptDailyBounty()
        {
            FastCheck fc = new FastCheck();
            bool bountyisavailable = false;

            int clkcounter = 0;

            NotePad.DoLog("принимаю ежедневку");
            do
            {
                if (clkcounter > 25) RestartBot();
                if (fc.DailyBounty())
                {
                    Rat.Clk(PointsAndRectangles.dailyBountyStart);
                    bountyisavailable = true;
                    Thread.Sleep(15000);
                }
                else
                if (fc.DailyBountyEnd())
                {
                    Rat.Clk(PointsAndRectangles.confirmdailyBountyEnd);
                    bountyisavailable = false;
                    Thread.Sleep(15000);
                }
                else if (bountyisavailable)
                {
                    Rat.Clk(PointsAndRectangles.dailyBountyThrow);
                    clkcounter++;
                }
                Thread.Sleep(15000);
            } while (bountyisavailable);
            NotePad.DoLog("принял ежедневку");
            RestartBot();
        }
        public void ToClubs()
        {
            bool needToDragMap = false;
            FastCheck fc = new FastCheck();
            bool flag = false;

            int waiter = 0;
            do
            {
                if (waiter > 200) RestartBot();
                if (fc.NoxRestartMessage())
                {
                    Rat.Clk(PointsAndRectangles.noxRestartMessageAcceptance);
                    Thread.Sleep(1000);
                    Rat.Clk(PointsAndRectangles.edgeOfTheScreen);
                    Thread.Sleep(120000);
                    Process.Start(@"C:\Program Files (x86)\Nox\bin\Nox.exe", "-clone:Nox_1");
                }//nox restart message
                CommonLists.SkipAllSkipables();                
                if (fc.DailyBounty()) AcceptDailyBounty();
                fc.Bounty();                
                UniversalErrorDefense();
                if (fc.EventPage())
                {
                    if (fc.InCommonEvent())
                    {
                        Thread.Sleep(500);
                        Rat.Clk(PointsAndRectangles.buttonBack);//back
                    }
                    else
                    {
                        Thread.Sleep(500);
                        Rat.Clk(PointsAndRectangles.toClubs);//Clubs
                        needToDragMap = true;
                    }
                }
                if (fc.ClubMap()) flag = true;
                Thread.Sleep(1500);
                waiter++;
            } while (!flag);

            if (needToDragMap) DragMap();
        }
    }
}