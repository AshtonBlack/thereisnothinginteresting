using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace WindowsFormsApp1
{
    public class MasterOfPictures
    {
        private static Bitmap captured; //создаем объект Bitmap (растровое изображение), будет нужен как при самом получении изображения, так и при сохранении изображения

        public static string PixelIndicator(Point p)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            Bitmap indicator = new Bitmap(1, 1, format);
            Graphics gdi = Graphics.FromImage(indicator);
            gdi.CopyFromScreen(p.X, p.Y, 0, 0, new Size(1, 1));
            string pix = indicator.GetPixel(0, 0).ToString();
            gdi.Dispose();
            indicator.Dispose();
            return pix;
        }

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
            bool flag1 = false;
            if (File.Exists("C:\\Bot\\" + ORIGINALPATH + ".jpg"))
            {
                if (File.Exists("C:\\Bot\\" + PATH + ".jpg"))
                {
                    flag1 = true;
                    Bitmap picturetest = new Bitmap("C:\\Bot\\" + PATH + ".jpg");
                    Bitmap picture = new Bitmap("C:\\Bot\\" + ORIGINALPATH + ".jpg");
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
                }
                else NotePad.DoErrorLog("Отсутствует C:\\Bot\\" + PATH + ".jpg");
            }
            else NotePad.DoErrorLog("Отсутствует C:\\Bot\\" + ORIGINALPATH + ".jpg");            
            return flag1;
        }

        public static void TrackCapture(Rectangle bounds, string PATH)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            captured = new Bitmap(bounds.Width, bounds.Height, format);
            Bitmap BW = new Bitmap(bounds.Width, bounds.Height, format);
            Graphics gdi = Graphics.FromImage(captured);
            gdi.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
            for (int row = 0; row < captured.Width; row++) // Indicates row number
            {
                for (int column = 0; column < captured.Height; column++) // Indicate column number
                {
                    var colorValue = captured.GetPixel(row, column); // Get the color pixel                    
                    var averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G) / 3; // get the average for black and white
                    if (averageValue > 220) averageValue = 255;
                    else averageValue = 0;
                    BW.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel
                }
            }

            BW.Save("C:\\Bot\\" + PATH + ".jpg", ImageFormat.Jpeg); // Save the black and white image         

            gdi.Dispose();
            captured.Dispose();
            BW.Dispose();
        }

        public static void BW2Capture(Rectangle bounds, string PATH)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            captured = new Bitmap(bounds.Width, bounds.Height, format);
            Bitmap BW = new Bitmap(bounds.Width, bounds.Height, format);
            Graphics gdi = Graphics.FromImage(captured);
            gdi.CopyFromScreen(bounds.Left, bounds.Top, 0, 0, bounds.Size);
            for (int row = 0; row < captured.Width; row++) // Indicates row number
            {
                for (int column = 0; column < captured.Height; column++) // Indicate column number
                {
                    var colorValue = captured.GetPixel(row, column); // Get the color pixel
                    var averageValue = ((int)colorValue.R + (int)colorValue.B + (int)colorValue.G) / 3; // get the average for black and white
                    if (averageValue > 200) averageValue = 255;
                    else averageValue = 0;
                    BW.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel
                }
            }

            BW.Save("C:\\Bot\\" + PATH + ".jpg", ImageFormat.Jpeg); // Save the black ad white image            

            gdi.Dispose();
            captured.Dispose();
            BW.Dispose();
        }

        public static bool VerifyBW(string PATH, string ORIGINALPATH, int maxdiffernces)
        {            
            bool flag1 = false;            
            if (File.Exists("C:\\Bot\\" + ORIGINALPATH + ".jpg"))
            {
                flag1 = true;
                int differences = 0;
                Bitmap picturetest = new Bitmap("C:\\Bot\\" + PATH + ".jpg");
                Bitmap picture = new Bitmap("C:\\Bot\\" + ORIGINALPATH + ".jpg");
                for (int x = 0; x < picturetest.Width; x++)
                {
                    if (flag1 == true)
                    {
                        for (int y = 0; y < picturetest.Height; y++)
                        {
                            if (Math.Abs((int)picturetest.GetPixel(x, y).R - (int)picture.GetPixel(x, y).R) >= 200)
                            {
                                differences++;
                                if (differences == maxdiffernces)
                                {
                                    flag1 = false;
                                    break;
                                }
                            }
                        }
                    }
                }
                picturetest.Dispose();
                picture.Dispose();
            }
            else NotePad.DoErrorLog("Отсутствует C:\\Bot\\" + ORIGINALPATH + ".jpg");
            return flag1;
        }
    }
}