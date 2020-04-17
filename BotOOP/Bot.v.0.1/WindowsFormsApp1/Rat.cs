using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace WindowsFormsApp1
{
    class Rat
    {
        [DllImport("User32.dll")]
        public static extern void MouseEvent(int dsFlag, int x, int y, int cButton, int dsExtraInfo);

        [DllImport("User32.dll")]
        public static extern long SetCursorPos(int x, int y);

        const int MOUSEEVENTF_LEFTDOWN = 0X02;
        const int MOUSEEVENTF_LEFTUP = 0X04;

        private static void DoMouseLeftClick(int x, int y)
        {
            MouseEvent(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            MouseEvent(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        public static void MoveMouse(int x, int y)
        {            
            SetCursorPos(x, y);
        }//используется в SpecialEvents

        private static void MoveMouse(Point xy)
        {
            int x = xy.X;
            int y = xy.Y;
            SetCursorPos(x, y);
        }

        public static void Clk(int dox, int doy)
        {
            MoveMouse(dox, doy);
            Thread.Sleep(200);
            DoMouseLeftClick(dox, doy);
            Thread.Sleep(100);
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
            MouseEvent(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
        }//используется в SpecialEvents

        private static void LMBdown(Point xy)
        {
            int x = xy.X;
            int y = xy.Y;
            MouseEvent(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
        }

        public static void LMBup(int x, int y)
        {
            MouseEvent(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }//используется в SpecialEvents

        private static void LMBup(Point xy)
        {
            int x = xy.X;
            int y = xy.Y;
            MouseEvent(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        private static void DragnDropGarage(Point xy1, Point xy2)
        {
            int dox1 = xy1.X;
            int doy1 = xy1.Y;
            int dox2 = xy2.X;
            int doy2 = xy2.Y;
            MoveMouse(dox1, doy1);
            Thread.Sleep(100);
            LMBdown(dox1, doy1);
            Thread.Sleep(2000);
            for (int i = doy1; i < doy2; i += 8)
            {
                MoveMouse(dox1, i);
                Thread.Sleep(60);
            }
            Thread.Sleep(1000);
            MoveMouse(dox2, doy2);
            Thread.Sleep(2000);
            LMBup(dox2, doy2);
            Thread.Sleep(1000);
        }

        public static int DragnDpopHand(int n, int uhl)//величины не исправлены с версии 0.04
        {
            FastCheck fc = new FastCheck();
            HandMaking hm = new HandMaking();
            Point GarageSlot1 = new Point(535, 400);
            Point GarageSlot2 = new Point(535, 590);
            Point GarageSlot3 = new Point(830, 400);
            Point GarageSlot4 = new Point(830, 590);
            //точки для сдвига 995/495 и 600/495
            Point GarageSlot5 = new Point(750, 400);
            Point GarageSlot6 = new Point(750, 590);
            //точки для сдвига 615/495 и 300/495
            Point GarageSlot7 = new Point(750, 400);
            Point GarageSlot8 = new Point(750, 590);
            //-------------
            Point GarageSlot9 = new Point(810, 400);
            Point GarageSlot10 = new Point(810, 590);

            Point HandSlot1 = new Point(170, 770);
            Point HandSlot2 = new Point(350, 770);
            Point HandSlot3 = new Point(540, 770);
            Point HandSlot4 = new Point(730, 770);
            Point HandSlot5 = new Point(910, 770);

            Point[] a = new Point[] { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };
            Point[] b = new Point[] { GarageSlot1, GarageSlot2, GarageSlot3, GarageSlot4, GarageSlot5, GarageSlot6, GarageSlot7, GarageSlot8, GarageSlot9, GarageSlot10 };
            int emptyCars = 0;//недостаток машин
            int newN; //кол-во машин для установки
            int drag = 0;
            int usefullcars = 0;
            for (int number = 0; number < 6; number++)//для начала научимся проверять первые 6 слотов
            {
                if (!fc.EmptyGarageSlot(number)) break;//не удается отладить проверку далее 6 слота
                else usefullcars = number + 1;
            }
            NotePad.DoLog("Подходят " + usefullcars + " авто");
            if (n > usefullcars)//требуемое кол-во тачек и наличие машин
            {
                newN = usefullcars;
                emptyCars = n - usefullcars;
            }
            else
            {
                newN = n;
            }

            int x = 0; //слот гаража
            int h = 0; //слот руки, uhl использованные слоты в предыдущем подборе
            while (x < newN) //x имеет значение и при нуле
            {
                if (x > 3 && drag == 0)
                {
                    MoveMouse(995, 495);
                    Thread.Sleep(100);
                    LMBdown(995, 495);
                    Thread.Sleep(2000);
                    for (int i = 995; i > 600; i -= 5)
                    {
                        MoveMouse(i, 495);
                        Thread.Sleep(70);
                    }
                    Thread.Sleep(1000);
                    MoveMouse(600, 495);
                    Thread.Sleep(2000);
                    LMBup(600, 495);
                    Thread.Sleep(1000);
                    drag = 1;
                }//сдвиг 

                if (x > 5 && drag == 1)
                {
                    MoveMouse(915, 495);
                    Thread.Sleep(100);
                    LMBdown(615, 495);
                    Thread.Sleep(2000);
                    for (int i = 615; i > 300; i -= 5)
                    {
                        MoveMouse(i, 495);
                        Thread.Sleep(70);
                    }
                    Thread.Sleep(1000);
                    MoveMouse(300, 495);
                    Thread.Sleep(2000);
                    LMBup(300, 495);
                    Thread.Sleep(1000);
                    drag = 2;
                }//сдвиг 

                if (hm.CarFixed(x))
                {
                    NotePad.DoLog("Тачка " + (x + 1) + " исправна");
                    while (!fc.ItsGarage()) Thread.Sleep(2000);
                    DragnDropGarage(b[x], a[h + uhl]);
                    x++;
                    h++;
                }
                else
                {
                    NotePad.DoLog("Тачка " + x + " не готова");
                    x++;
                    newN++;
                }
            }

            return emptyCars;
        }

        public static void DragnDrop(Point xy1, Point xy2)
        {
            SpecialEvents se = new SpecialEvents();
            int error = 0;
            string x1;
            string x2;
            do
            {
                if (error == 3)
                {
                    se.RestartBot();
                }
                x1 = MasterOfPictures.PixelIndicator(xy1);//контрольный пиксель
                Rat.MoveMouse(xy1);
                Thread.Sleep(100);
                Rat.LMBdown(xy1);
                Thread.Sleep(1000);
                Rat.MoveMouse(xy2);
                Thread.Sleep(2500);
                Rat.LMBup(xy2);
                Thread.Sleep(500);
                x2 = MasterOfPictures.PixelIndicator(xy1);//контрольный пиксель фото 2
                error++;
            } while (x1 == x2);//переместил ли машину
        }
    }
}