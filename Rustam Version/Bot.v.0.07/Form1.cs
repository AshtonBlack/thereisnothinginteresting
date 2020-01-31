using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Bot.v._0._07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Opacity = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(0, 0); //локация формы(невидимая)
            Thread.Sleep(1000);
            Clk(1165, 20); //Свернуть VS
            Thread.Sleep(2000);

            Loading();

            Application.Exit();
        }

        [DllImport("User32.dll")]
        public static extern void mouse_event(int dsFlag, int x, int y, int cButton, int dsExtraInfo);

        [DllImport("User32.dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("User32.dll")]
        public static extern bool ClientToScreen(IntPtr hWnd, ref POINT point);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        public const int MOUSEEVENTF_LEFTDOWN = 0X02;
        public const int MOUSEEVENTF_LEFTUP = 0X04;

        static void DoMouseLeftClick(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        public void MoveMouse(int x, int y)
        {
            POINT p = new POINT();
            p.x = x;
            p.y = y;
            ClientToScreen(Handle, ref p);
            SetCursorPos(p.x, p.y);
        }

        public void Clk(int dox, int doy)
        {
            MoveMouse(dox, doy);
            Thread.Sleep(200);
            DoMouseLeftClick(dox, doy);
            Thread.Sleep(100);
        }

        public void Clk1(Point p)
        {
            int dox = p.X;
            int doy = p.Y;
            MoveMouse(dox, doy);
            Thread.Sleep(200);
            DoMouseLeftClick(dox, doy);
            Thread.Sleep(100);
        }

        public void LMBdown(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
        }

        public void LMBup(int x, int y)
        {
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        private void Loading()
        {
            NotePad.ClearLog();
            if(File.Exists(@"D:\Program Files\Nox\bin\Nox.exe"))
            {
                Process.Start(@"D:\Program Files\Nox\bin\Nox.exe", "-clone.Nox_2");
            }

            Thread.Sleep(120000);
            Rectangle monitorBounds = new Rectangle(0, 0, 1365, 767);
            string monitorPath = "monitor";
            MasterOfPictures.MakePicture(monitorBounds, monitorPath);
            Bitmap picturetest = new Bitmap("C:\\Bot\\icon.jpg");
            Bitmap picture = new Bitmap("C:\\Bot\\monitor.jpg");

            for(int i = 0; i < 1300; i++)
            {
                for(int j = 0; j < 700; j++)
                {
                    for(int k = 0; k < 49; k++)
                    {
                        for(int l = 0; l < 39; l++)
                        {
                            if (picturetest.GetPixel(x, y) != picture.GetPixel(x, y))
                               {
                                  flag1 = false;
                                  break;
                               }
                        }
                    }
                }
            }
            picturetest.Dispose();
        }

    public class NotePad
    {
        public static void DoLog(string text)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Log.txt", true, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine(text + "  " + DateTime.Now.ToLongTimeString());
                sw.Close();
            }
        }

        public static void ClearLog()
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Bot\Log.txt", false, System.Text.Encoding.Default))//true для дописывания 
            {
                sw.WriteLine("Начинаю новую сессию");
                sw.Close();
            }
        }
    }

    public class MasterOfPictures
    {
        private static Bitmap captured; //создаем объект Bitmap (растровое изображение), будет нужен как при самом получении изображения, так и при сохранении изображения

        public static void MakePicture(Rectangle bounds, string PATH)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            captured = new Bitmap(bounds.Width, bounds.Height, format);
            Graphics gdi = Graphics.FromImage(captured);
            gdi.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
            if (captured != null)
            {
                captured.Save("C:\\Bot\\" + PATH + ".jpg", ImageFormat.Jpeg);
            }
            gdi.Dispose();
            captured.Dispose();
        }

        public static bool Verify(string PATH, string ORIGINALPATH)
        {
            Bitmap picturetest = new Bitmap("C:\\Bot\\" + PATH + ".jpg");
            Bitmap picture = new Bitmap("C:\\Bot\\" + ORIGINALPATH + ".jpg");
            bool flag1 = true;
            for (int x = 0; x < picturetest.Width; x++)
            {
                if (flag1 == true)
                {
                    for (int y = 0; y < picturetest.Height; y++)
                    {
                        if (picturetest.GetPixel(x, y) != picture.GetPixel(x, y))
                        {
                            flag1 = false;
                            break;
                        }
                    }
                }
            }
            picturetest.Dispose();
            picture.Dispose();
            return flag1;
        }
    }
}