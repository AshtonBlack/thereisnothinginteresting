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
                Thread.Sleep(1500); 
                if (fc.ClubMap()) nextstep = true;
                counter++;
            } while (!nextstep);
        }
        public void DragMap()
        {
            FastCheck fc = new FastCheck();
            CommonLists.SkipAllSkipables();
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
            Thread.Sleep(3000);
            if (fc.WrongParty())
            {
                NotePad.DoLog("Косячная рука");
                RestartBot();
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
                if (fc.ClubMap()) flag = true;
                Thread.Sleep(1500);
                waiter++;
            } while (!flag);

            if (needToDragMap) DragMap();
        }
    }
}