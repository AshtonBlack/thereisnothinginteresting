using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Caitlyn_v1._0
{
    internal class CarPictureDataBase
    {
        public static Dictionary<int, byte[]> CarPictureDB = new Dictionary<int, byte[]>();
        byte[] ConvertImageToByteStream(Image image, int zeroposx, int zeroposy)
        {
            List<byte> byteStream = new List<byte>();
            Bitmap photo = new Bitmap(image);
            int botPhotoWidth = 23;
            int botPhotoHeight = 13;
            for (int x1 = 0; x1 < botPhotoWidth; x1++)
            {
                for (int y1 = 0; y1 < botPhotoHeight; y1++)
                {
                    var pixel = photo.GetPixel(x1 + zeroposx, y1 + zeroposy);
                    byteStream.Add(pixel.R);
                    byteStream.Add(pixel.G);
                    byteStream.Add(pixel.B);
                }
            }
            photo.Dispose();
            return byteStream.ToArray();
        }
        public void MakeDB()
        {
            string originalsDirectory = @"C:\Bot\NewPL\CarOriginals\";
            int lastCarInBase = new DirectoryInfo(@"C:\Bot\NewPL\CarOriginals").GetFiles().Length + 10;
            int percent = 7;
            int zeroposx = 3;
            int zeroposy = 1;
            for (int id = 1; id < lastCarInBase; id++)
            {
                string originalPhotoName = originalsDirectory + id + @".png";
                if (File.Exists(originalPhotoName))
                {
                    Bitmap originalPhoto = new Bitmap(originalPhotoName);
                    CarPictureDB.Add(id, ConvertImageToByteStream(ZoomImage(originalPhoto, percent), zeroposx, zeroposy));
                    originalPhoto.Dispose();
                }
            }
            NotePad.DoLog("picture DB is created");
        }
        public int FindThePictureInCollection(int finger)
        {
            int pictureId = 0;
            int bestShadesDif = 5000000;
            Bitmap botPhoto = new Bitmap(@"C:\Bot\CurrentHand\test" + finger + ".jpg");
            byte[] fingerPictureArray = ConvertImageToByteStream(ZoomImage(botPhoto, 20), 0, 0);
            foreach(var picture in CarPictureDB)
            {
                int currentShadesDif = CalculateDifs(fingerPictureArray, picture.Value);
                if (currentShadesDif < bestShadesDif)
                {
                    bestShadesDif = currentShadesDif;
                    pictureId = picture.Key;
                }
            }
            botPhoto.Dispose();
            return pictureId;
        }
        Image ZoomImage(Image orig, float percent)
        {
            Bitmap scaledImage;
            /// Ширина и высота результирующего изображения
            float w = orig.Width * percent / 100,
                h = orig.Height * percent / 100;
            scaledImage = new Bitmap((int)w, (int)h);
            /// DPI результирующего изображения
            scaledImage.SetResolution(orig.HorizontalResolution, orig.VerticalResolution);
            /// Часть исходного изображения, для которой меняем масштаб.
            /// В данном случае — всё изображение
            Rectangle src = new Rectangle(0, 0, orig.Width, orig.Height);
            /// Часть изображения, которую будем рисовать
            /// В данном случае — всё изображение
            RectangleF dest = new RectangleF(0, 0, w, h);
            /// Прорисовка с изменённым масштабом
            using (Graphics g = Graphics.FromImage(scaledImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(orig, dest, src, GraphicsUnit.Pixel);
            }
            return scaledImage;
        }
        int CalculateDifs(byte[] firstImage, byte[] secondImage)
        {
            int difShades = 0;
            if (firstImage.Length == secondImage.Length)
            {
                
                for(int cell = 0; cell < firstImage.Length; cell++)
                {
                    difShades += Math.Abs(firstImage[cell] - secondImage[cell]);
                }
            }
            else NotePad.DoLog("pictures are different: " + firstImage.Length + " and " + secondImage.Length);
            return difShades;
        }
    }
}