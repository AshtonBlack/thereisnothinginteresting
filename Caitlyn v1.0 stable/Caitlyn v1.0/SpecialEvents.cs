using System.Diagnostics;
using System.Drawing;
using System.Threading;

namespace Caitlyn_v1._0
{
    public static class SpecialEvents
    {        
        public static void DragMap()
        {
            Rat.DragnDropSlow(PointsAndRectangles.allpoints["dragMapS"], PointsAndRectangles.allpoints["dragMapE"], 8);
            GameState.needToDragMap = false;
        }
        public static void RestartBot()
        {
            Rat.Clk(PointsAndRectangles.allpoints["noxClosing"]);//close Nox
            Thread.Sleep(1000);
            Rat.Clk(PointsAndRectangles.allpoints["noxClosingAcceptance"]);//accept Nox close
            Thread.Sleep(1000);
            Process.Start(@"C:\Bot\BotRestarter\BotRestarter\bin\Debug\BotRestarter.exe");
            Process.GetCurrentProcess().Kill();
        }             
        public static bool ClearHand()
        {
            FastCheck fc = new FastCheck();
            Point[] a = new Point[] { PointsAndRectangles.allpoints["pHandSlot1"],
                PointsAndRectangles.allpoints["pHandSlot2"],
                PointsAndRectangles.allpoints["pHandSlot3"],
                PointsAndRectangles.allpoints["pHandSlot4"],
                PointsAndRectangles.allpoints["pHandSlot5"] };
            for (int i = 0; i < 5; i++)
            {
                if (fc.ItsGarage())
                {
                    Point endPoint = new Point(a[i].X, a[i].Y - 270);
                    Rat.DragnDropSlow(a[i], endPoint, 10);
                }
                else return false;    
            }
            return true;
        }   
        public static void ToClubs()
        {
            FastCheck fc = new FastCheck();
            GameState.antiLoopCounter = 0;
            do
            {
                if (GameState.antiLoopCounter > 100) RestartBot();                
                CommonLists.SkipAllSkipables(); 
                if (fc.ClubMap())
                {
                    if (GameState.needToDragMap) DragMap();
                    break;
                }
                Thread.Sleep(100);
                GameState.antiLoopCounter++;
            } while (true);            
        }
    }
}