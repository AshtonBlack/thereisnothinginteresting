using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Caitlyn_v1._0
{
    public class MasterOfPictures
    {
        const int xCorrection = -3;//TEMPORARY
        const int yCorrection = 1;//TEMPORARY

        public static string PixelIndicator(Point p)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            Bitmap indicator = new Bitmap(1, 1, format);
            Graphics gdi = Graphics.FromImage(indicator);
            gdi.CopyFromScreen(p.X + xCorrection, p.Y + yCorrection, 0, 0, new Size(1, 1));
            string pix = indicator.GetPixel(0, 0).ToString();
            gdi.Dispose();
            indicator.Dispose();
            return pix;
        }
        public static void MakePicture(Rectangle bounds, string PATH)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            Bitmap captured = new Bitmap(bounds.Width, bounds.Height, format);
            Graphics gdi = Graphics.FromImage(captured);
            gdi.CopyFromScreen(bounds.Left + xCorrection, bounds.Top + yCorrection, 0, 0, bounds.Size);
            if (captured != null)
            {
                try
                {
                    captured.Save(@"C:\Bot\" + PATH + ".jpg", ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {
                    NotePad.DoErrorLog("Unknown error with save picture");
                }
            }
            gdi.Dispose();
            captured.Dispose();
        }
        public static bool Verify(string PATH, string ORIGINALPATH)
        {
            bool verificationResult = true;
            if (File.Exists(@"C:\Bot\" + ORIGINALPATH + ".jpg"))
            {
                Bitmap picturetest = new Bitmap(@"C:\Bot\" + PATH + ".jpg");
                Bitmap picture = new Bitmap(@"C:\Bot\" + ORIGINALPATH + ".jpg");
                for (int x = 0; x < picturetest.Width; x++)
                {
                    for (int y = 0; y < picturetest.Height; y++)
                    {
                        if (picturetest.GetPixel(x, y) != picture.GetPixel(x, y))
                        {
                            verificationResult = false;
                        }
                    }
                }
                picturetest.Dispose();
                picture.Dispose();
            }
            else
            {
                NotePad.DoErrorLog(@"Отсутствует C:\Bot\" + ORIGINALPATH + ".jpg");
                verificationResult = false;
            }
            return verificationResult;
        }
        public static void TrackCapture(Rectangle bounds, string PATH)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            Bitmap captured = new Bitmap(bounds.Width, bounds.Height, format);
            Bitmap BW = new Bitmap(bounds.Width, bounds.Height, format);
            Graphics gdi = Graphics.FromImage(captured);
            gdi.CopyFromScreen(bounds.Left + xCorrection, bounds.Top + yCorrection, 0, 0, bounds.Size);
            for (int row = 0; row < captured.Width; row++) // Indicates row number
            {
                for (int column = 0; column < captured.Height; column++) // Indicate column number
                {
                    var colorValue = captured.GetPixel(row, column); // Get the color pixel                    
                    var averageValue = (colorValue.R + colorValue.B + colorValue.G) / 3; // get the average for black and white
                    if (averageValue > 220) averageValue = 255;
                    else averageValue = 0;
                    BW.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel
                }
            }

            try
            {
                BW.Save(@"C:\Bot\" + PATH + ".jpg", ImageFormat.Jpeg); // Save the black and white image
            }
            catch (Exception ex)
            {
                NotePad.DoErrorLog("Unknown error with save picture");
            }

            gdi.Dispose();
            captured.Dispose();
            BW.Dispose();
        }
        public static void BW2Capture(Rectangle bounds, string PATH)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            Bitmap captured = new Bitmap(bounds.Width, bounds.Height, format);
            Bitmap BW = new Bitmap(bounds.Width, bounds.Height, format);
            Graphics gdi = Graphics.FromImage(captured);
            gdi.CopyFromScreen(bounds.Left + xCorrection, bounds.Top + yCorrection, 0, 0, bounds.Size);
            for (int row = 0; row < captured.Width; row++) // Indicates row number
            {
                for (int column = 0; column < captured.Height; column++) // Indicate column number
                {
                    var colorValue = captured.GetPixel(row, column); // Get the color pixel
                    var averageValue = (colorValue.R + colorValue.B + colorValue.G) / 3; // get the average for black and white
                    if (averageValue > 200) averageValue = 255;
                    else averageValue = 0;
                    BW.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel
                }
            }
            
            try
            {
                BW.Save(@"C:\Bot\" + PATH + ".jpg", ImageFormat.Jpeg); // Save the black and white image
            }
            catch (Exception ex)
            {
                NotePad.DoErrorLog("Unknown error with save picture");
            }

            gdi.Dispose();
            captured.Dispose();
            BW.Dispose();
        }
        public static void BW2CaptureWithBlackText(Rectangle bounds, string PATH)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            Bitmap captured = new Bitmap(bounds.Width, bounds.Height, format);
            Bitmap BW = new Bitmap(bounds.Width, bounds.Height, format);
            Graphics gdi = Graphics.FromImage(captured);
            gdi.CopyFromScreen(bounds.Left + xCorrection, bounds.Top + yCorrection, 0, 0, bounds.Size);
            for (int row = 0; row < captured.Width; row++) // Indicates row number
            {
                for (int column = 0; column < captured.Height; column++) // Indicate column number
                {
                    var colorValue = captured.GetPixel(row, column); // Get the color pixel
                    var averageValue = (colorValue.R + colorValue.B + colorValue.G) / 3; // get the average for black and white
                    if (averageValue > 75) averageValue = 255;
                    else averageValue = 0;
                    BW.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue)); // Set the value to new pixel
                }
            }

            try
            {
                BW.Save(@"C:\Bot\" + PATH + ".jpg", ImageFormat.Jpeg); // Save the black and white image
            }
            catch (Exception ex)
            {
                NotePad.DoErrorLog("Unknown error with save picture");
            }

            gdi.Dispose();
            captured.Dispose();
            BW.Dispose();
        }
        public static bool VerifyBW(string PATH, string ORIGINALPATH, int maxdiffernces)
        {
            bool verificationResult = true;
            if (File.Exists(@"C:\Bot\" + ORIGINALPATH + ".jpg"))
            {
                int differences = 0;
                Bitmap picturetest = new Bitmap(@"C:\Bot\" + PATH + ".jpg");
                Bitmap picture = new Bitmap(@"C:\Bot\" + ORIGINALPATH + ".jpg");
                for (int x = 0; x < picturetest.Width; x++)
                {
                    for (int y = 0; y < picturetest.Height; y++)
                    {
                        if (Math.Abs(picturetest.GetPixel(x, y).R - picture.GetPixel(x, y).R) >= 200)
                        {
                            differences++;
                            if (differences == maxdiffernces)
                            {
                                verificationResult = false;
                            }
                        }
                    }
                }
                picturetest.Dispose();
                picture.Dispose();
            }
            else 
            { 
                NotePad.DoErrorLog(@"Отсутствует C:\Bot\" + ORIGINALPATH + ".jpg");
                verificationResult = false;
            }
            return verificationResult;
        }
        public static void TransformPictureIntoBW(string pictureName, string resultedPictureName)
        {
            PixelFormat format = PixelFormat.Format24bppRgb;
            Bitmap picture = new Bitmap(pictureName);
            Bitmap resultedPicture = new Bitmap(picture.Width, picture.Height, format);
            for (int row = 0; row < picture.Width; row++)
            {
                for (int column = 0; column < picture.Height; column++)
                {
                    var colorValue = picture.GetPixel(row, column);
                    var averageValue = (colorValue.R + colorValue.B + colorValue.G) / 3;
                    if (averageValue > 200) averageValue = 255;
                    else averageValue = 0;
                    resultedPicture.SetPixel(row, column, Color.FromArgb(averageValue, averageValue, averageValue));
                }
            }
            resultedPicture.Save(resultedPictureName);
            picture.Dispose();
            resultedPicture.Dispose();
        }
    }
}