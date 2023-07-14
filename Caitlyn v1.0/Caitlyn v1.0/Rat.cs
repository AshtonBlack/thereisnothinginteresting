using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace Caitlyn_v1._0
{
    class Rat
    {
        [DllImport("User32.dll")]
        public static extern void mouse_event(int dsFlag, int x, int y, int cButton, int dsExtraInfo);

        [DllImport("User32.dll")]
        public static extern long SetCursorPos(int x, int y);

        const int MOUSEEVENTF_LEFTDOWN = 0X02;
        const int MOUSEEVENTF_LEFTUP = 0X04;

        const int xCorrection = -3;//TEMPORARY
        const int yCorrection = 1;//TEMPORARY

        private static void DoMouseLeftClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x + xCorrection, y + yCorrection, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x + xCorrection, y + yCorrection, 0, 0);
        }
        public static void MoveMouse(int x, int y)
        {
            SetCursorPos(x + xCorrection, y + yCorrection);
        }
        private static void MoveMouse(Point xy)
        {
            int x = xy.X;
            int y = xy.Y;
            SetCursorPos(x + xCorrection, y + yCorrection);
        }       
        public static void Clk(Point p)
        {
            int dox = p.X;
            int doy = p.Y;
            MoveMouse(dox, doy);
            Thread.Sleep(200);
            DoMouseLeftClick(dox, doy);
            Thread.Sleep(100);
        }
        public static void LMBdown(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x + xCorrection, y + yCorrection, 0, 0);
        }
        private static void LMBdown(Point xy)
        {
            int x = xy.X;
            int y = xy.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN, x + xCorrection, y + yCorrection, 0, 0);
        }
        public static void LMBup(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTUP, x + xCorrection, y + yCorrection, 0, 0);
        }
        private static void LMBup(Point xy)
        {
            int x = xy.X;
            int y = xy.Y;
            mouse_event(MOUSEEVENTF_LEFTUP, x + xCorrection, y + yCorrection, 0, 0);
        }
        public static void DragnDropFast(Point xy1, Point xy2)
        {
            int error = 0;
            string x1;
            string x2;
            do
            {
                if (error == 3)
                {
                    SpecialEvents.RestartBot();
                }
                x1 = MasterOfPictures.PixelIndicator(xy1);//контрольный пиксель
                MoveMouse(xy1);
                Thread.Sleep(100);
                LMBdown(xy1);
                Thread.Sleep(1000);
                MoveMouse(xy2);
                Thread.Sleep(2500);
                LMBup(xy2);
                Thread.Sleep(500);
                x2 = MasterOfPictures.PixelIndicator(xy1);//контрольный пиксель фото 2
                error++;
            } while (x1 == x2);//переместил ли машину
        }
        public static void DragnDropSlow(Point xy1, Point xy2, int speed)
        {
            int dox1 = xy1.X;
            int doy1 = xy1.Y;
            int dox2 = xy2.X;
            int doy2 = xy2.Y;
            MoveMouse(dox1, doy1);
            Thread.Sleep(100);
            LMBdown(dox1, doy1);
            Thread.Sleep(1000);

            if (doy1 < doy2)
            {
                for (int i = doy1; i < doy2; i += speed)
                {
                    MoveMouse(dox1, i);
                    Thread.Sleep(60);
                }
            }

            if (doy1 > doy2)
            {
                for (int i = doy1; i > doy2; i -= speed)
                {
                    MoveMouse(dox1, i);
                    Thread.Sleep(60);
                }
            }

            if (dox1 < dox2)
            {
                for (int i = dox1; i < dox2; i += speed)
                {
                    MoveMouse(i, doy2);
                    Thread.Sleep(60);
                }
            }

            if (dox1 > dox2)
            {
                for (int i = dox1; i > dox2; i -= speed)
                {
                    MoveMouse(i, doy2);
                    Thread.Sleep(60);
                }
            }

            Thread.Sleep(100);
            MoveMouse(dox2, doy2);
            Thread.Sleep(100);
            LMBup(dox2, doy2);
            Thread.Sleep(1000);
        }
    }
}
