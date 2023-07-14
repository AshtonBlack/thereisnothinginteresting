using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace Caitlyn_v1._0
{
    public static class SpecialEvents
    {
        public static void EndRace()
        {
            FastCheck fc = new FastCheck();
            
            bool nextstep = false;
            int counter = 0;

            do
            {
                CommonLists.SkipAllSkipables();                
                if(counter > 30)
                {
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
        public static void DragMap()
        {
            FastCheck fc = new FastCheck();
            CommonLists.SkipAllSkipables();
            if (fc.ClubMap())
            {
                Rat.DragnDropSlow(PointsAndRectangles.dragMapS, PointsAndRectangles.dragMapE, 8);
            }            
        }
        public static void RestartBot()
        {
            Rat.Clk(PointsAndRectangles.noxClosing);//close Nox
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.noxClosingAcceptance);//accept Nox close
            Thread.Sleep(1000);
            Process.Start(@"C:\Bot\BotRestarter\BotRestarter\bin\Debug\BotRestarter.exe");
            Process.GetCurrentProcess().Kill();
        }
        public static void CarRepair()
        {
            FastCheck fc = new FastCheck();

            if (fc.CarRepair())
            {
                RestartBot();
            }
        }        
        public static void ClearHand()
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
        public static void UnavailableEvent()
        {
            FastCheck fc = new FastCheck();
            Thread.Sleep(3000);
            CommonLists.SkipAllSkipables();
            if (fc.WrongParty())
            {
                NotePad.DoLog("Косячная рука");
                RestartBot();
            }
        }        
        public static void ToClubs()
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