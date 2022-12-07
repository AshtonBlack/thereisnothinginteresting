using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NotNeural
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MakeDB();
            Console.WriteLine("DB is built");
        }
        public static Dictionary<int, byte[]> CarPictureDB = new Dictionary<int, byte[]>();
        string botPhotoName;
        string originalPhotoName;
        string originalsDirectory;
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                botPhotoName = openFileDialog.FileName;
            }

            label1.Text = botPhotoName;
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
        public void BestScale()
        {
            (int scalePercent, Point leftTopCorner, int difShades) bestResult = (0, new Point(0,0), 5000000);            
            Bitmap botPhoto = new Bitmap(botPhotoName);
            //for (int percent = 1; percent < 101; percent++)
            for (int percent = 34; percent < 36; percent++)
            {
                Console.WriteLine(percent + "% zoom");
                Bitmap originalPhoto = new Bitmap(originalPhotoName);
                Bitmap scalableOriginalPhoto = new Bitmap(ZoomImage(originalPhoto, percent));
                (Point leftTopCorner, int difShades) currentResult = BestPiece(scalableOriginalPhoto, botPhoto);
                if (bestResult.scalePercent == 0)
                {
                    bestResult = (percent, currentResult.leftTopCorner, currentResult.difShades);
                }
                else
                {
                    if (bestResult.difShades > currentResult.difShades)
                    {
                        bestResult = (percent, currentResult.leftTopCorner, currentResult.difShades);
                    }
                }
                originalPhoto.Dispose();
            }
            botPhoto.Dispose();
            Console.WriteLine("лучший результат: " 
                + bestResult.scalePercent + "% zoom, " 
                + bestResult.leftTopCorner.X + " " + bestResult.leftTopCorner.Y + " начальная точка, отличие в " 
                + bestResult.difShades + " оттенков");            
            textBox1.Text = "лучший результат: "
                + bestResult.scalePercent + "% zoom, "
                + bestResult.leftTopCorner.X + " " + bestResult.leftTopCorner.Y + " начальная точка, отличие в "
                + bestResult.difShades + " оттенков";
        }
        public (int, Point) BestScaleDoubleZoom()
        {
            (int scalePercent, Point leftTopCorner, int difShades) bestResult = (0, new Point(0, 0), 5000000);
            Bitmap botPhoto1 = new Bitmap(botPhotoName);
            Bitmap botPhoto = new Bitmap(ZoomImage(botPhoto1, 20));
            //Stopwatch myTimer = new Stopwatch();//debug
            //myTimer.Start();//debug

            /* relevant for research
            for (int percent = 6; percent < 9; percent++)
            {
                Console.WriteLine(percent + "% zoom");
                Bitmap originalPhoto = new Bitmap(originalPhotoName);
                Bitmap scalableOriginalPhoto = new Bitmap(ZoomImage(originalPhoto, percent));
                (Point leftTopCorner, int difShades) currentResult = BestPiece(scalableOriginalPhoto, botPhoto);
                if (bestResult.scalePercent == 0)
                {
                    bestResult = (percent, currentResult.leftTopCorner, currentResult.difShades);
                }
                else
                {
                    if (bestResult.difShades > currentResult.difShades)
                    {
                        bestResult = (percent, currentResult.leftTopCorner, currentResult.difShades);
                    }
                }
                originalPhoto.Dispose();
            }
            */
            int percent = 7;//explored value
            Bitmap originalPhoto = new Bitmap(originalPhotoName);
            Bitmap scalableOriginalPhoto = new Bitmap(ZoomImage(originalPhoto, percent));
            (Point leftTopCorner, int difShades) currentResult = BestPiece(scalableOriginalPhoto, botPhoto);
            if (bestResult.scalePercent == 0)
            {
                bestResult = (percent, currentResult.leftTopCorner, currentResult.difShades);
            }
            else
            {
                if (bestResult.difShades > currentResult.difShades)
                {
                    bestResult = (percent, currentResult.leftTopCorner, currentResult.difShades);
                }
            }
            originalPhoto.Dispose();
            botPhoto.Dispose();
            //myTimer.Stop();//debug
            //Console.WriteLine(myTimer.ElapsedMilliseconds);//debug
            //label3.Text = myTimer.ElapsedMilliseconds.ToString();//debug
            /*debug
            Console.WriteLine("лучший результат: "
                + bestResult.scalePercent + "% zoom, "
                + bestResult.leftTopCorner.X + " " + bestResult.leftTopCorner.Y + " начальная точка, отличие в "
                + bestResult.difShades + " оттенков");
            textBox2.Text = "лучший результат: "
                + bestResult.scalePercent + "% zoom, "
                + bestResult.leftTopCorner.X + " " + bestResult.leftTopCorner.Y + " начальная точка, отличие в "
                + bestResult.difShades + " оттенков";
            */
            //MapsofDifs(bestResult.scalePercent, bestResult.leftTopCorner);//debug

            return (bestResult.difShades, bestResult.leftTopCorner);
        }
        public (Point leftTopCorner, int difShades) BestPiece(Bitmap scalableOriginalPhoto, Bitmap botPhoto)
        {           
            int bestposx = 0;
            int bestposy = 0;
            int minshadesdifs = 5000000;
            if(scalableOriginalPhoto.Width >= botPhoto.Width && scalableOriginalPhoto.Height >= botPhoto.Height)
            {
                //for (int zeroposx = 0; zeroposx < scalableOriginalPhoto.Width - botPhoto.Width; zeroposx++)
                //for (int zeroposx = 0; zeroposx < 4; zeroposx++)//improved
                for (int zeroposx = 3; zeroposx < 4; zeroposx++)//maximproved
                {
                    //for (int zeroposy = 1; zeroposy < scalableOriginalPhoto.Height - botPhoto.Height; zeroposy++)//zeropos changed from 0 to 1 to avoid differences on edges
                    //for (int zeroposy = 1; zeroposy < 4; zeroposy++)//improved
                    for (int zeroposy = 1; zeroposy < 2; zeroposy++)//maximproved
                    {
                        int shadesdifs0 = 0;
                        for (int x1 = 0; x1 < botPhoto.Width; x1++)
                        {
                            for (int y1 = 0; y1 < botPhoto.Height; y1++)
                            {
                                var colorValue0 = botPhoto.GetPixel(x1, y1);
                                var colorValue1 = scalableOriginalPhoto.GetPixel(zeroposx + x1, zeroposy + y1);
                                int shadesdifs1 = (Math.Abs((int)colorValue0.R - (int)colorValue1.R) +
                                    Math.Abs((int)colorValue0.G - (int)colorValue1.G) +
                                    Math.Abs((int)colorValue0.B - (int)colorValue1.B));
                                shadesdifs0 += shadesdifs1;
                            }
                        }
                        //Console.WriteLine("стартовая позиция второй картинки " + zeroposx + " " + zeroposy + ", отличие " + shadesdifs0 + " оттенков");
                        if (minshadesdifs == -1 || minshadesdifs > shadesdifs0)
                        {
                            minshadesdifs = shadesdifs0;
                            bestposx = zeroposx;
                            bestposy = zeroposy;
                        }
                    }
                }
            }            
            //Console.WriteLine("наиболее подходящий кусок " + bestposx + " " + bestposy + " с отличием в " + minshadesdifs + " оттенков");
            return (new Point(bestposx, bestposy), minshadesdifs);
        }
        public void MapsofDifs(int zoom, Point startPoint)//debug
        {
            Bitmap botPhoto = new Bitmap(botPhotoName);
            Bitmap scalableBotPhoto = new Bitmap(ZoomImage(botPhoto, 20));
            Bitmap originalPhoto = new Bitmap(originalPhotoName);
            Bitmap scalableOriginalPhoto = new Bitmap(ZoomImage(originalPhoto, zoom));
            Bitmap mapOfDifference = new Bitmap(scalableBotPhoto.Width, scalableBotPhoto.Height);
            pictureBox1.Image = null;

            for (int x = 0; x < scalableBotPhoto.Width; x++)
            {
                for (int y = 0; y < scalableBotPhoto.Height; y++)
                {
                    var colorValue0 = scalableBotPhoto.GetPixel(x, y);
                    var colorValue1 = scalableOriginalPhoto.GetPixel(x+startPoint.X, y+startPoint.Y);
                    int shadesdif = (Math.Abs((int)colorValue0.R - (int)colorValue1.R) +
                                    Math.Abs((int)colorValue0.G - (int)colorValue1.G) +
                                    Math.Abs((int)colorValue0.B - (int)colorValue1.B));
                    Console.WriteLine("difference is " + shadesdif + " shades");
                    int percentageDif = 100 * shadesdif / 3 / 256;
                    Console.WriteLine("difference is " + percentageDif + " percents");
                    mapOfDifference.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    if (percentageDif > 5) mapOfDifference.SetPixel(x, y, Color.FromArgb(0, 255, 0));
                    if (percentageDif > 10) mapOfDifference.SetPixel(x, y, Color.FromArgb(255, 255, 0));
                    if (percentageDif > 15) mapOfDifference.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                    if (percentageDif > 20) mapOfDifference.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                }
            }

            mapOfDifference.Save(@"C:\Bot\RGBmap.jpg");
            mapOfDifference.Dispose();
            botPhoto.Dispose();
            scalableBotPhoto.Dispose();
            originalPhoto.Dispose();
            scalableOriginalPhoto.Dispose();
            pictureBox1.Image = ZoomImage(Image.FromFile(@"C:\Bot\RGBmap.jpg"), 1000);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalPhotoName = openFileDialog.FileName;
            }

            label2.Text = originalPhotoName;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            BestScale();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            BestScaleDoubleZoom();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                label4.Text = folderDlg.SelectedPath;
                originalsDirectory = folderDlg.SelectedPath;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(botPhotoName);
            string theClosestOriginal = "none";
            int bestShadesDif = 5000000;
            Point leftTopCorner = new Point();
            for (int originalPhoto = 0; originalPhoto<3100; originalPhoto++)
            {
                originalPhotoName = originalsDirectory + @"\" + originalPhoto + @".png";
                if (File.Exists(originalPhotoName))
                {
                    (int, Point) result = BestScaleDoubleZoom();
                    int currentShadesDif = result.Item1;
                    if (currentShadesDif < bestShadesDif)
                    {
                        bestShadesDif = currentShadesDif;
                        theClosestOriginal = originalPhotoName;
                        leftTopCorner = result.Item2;
                    }
                }                
            }
            pictureBox3.Image = ZoomImage(Image.FromFile(theClosestOriginal), 35);
            label5.Text = theClosestOriginal;
            label6.Text = bestShadesDif.ToString() + " difShades";
            label7.Text = "leftTopCorner " + leftTopCorner.X + " " + leftTopCorner.Y;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(botPhotoName);
            pictureBox3.Image = ZoomImage(Image.FromFile(@"C:\Bot\png_cards_archive\" + FindThePictureInCollection() + @".png"), 35);
        }        
        public static byte[] ConvertImageToByteStream(Image image, int zeroposx, int zeroposy)
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
        void MakeDB()
        {
            //string originalsDirectory = @"C:\Bot\NewPL\CarOriginals\";
            string originalsDirectory = @"C:\Bot\png_cards_archive\";
            int lastCarInBase = 3100;
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
        }
        int FindThePictureInCollection()
        {
            int pictureId = 0;
            int bestShadesDif = 5000000;
            //Bitmap botPhoto = new Bitmap(@"C:\Bot\CurrentHand\test" + finger + ".jpg");
            Bitmap botPhoto = new Bitmap(botPhotoName);
            byte[] fingerPictureArray = ConvertImageToByteStream(ZoomImage(botPhoto, 20), 0, 0);
            foreach (var picture in CarPictureDB)
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
        public int CalculateDifs(byte[] firstImage, byte[] secondImage)
        {
            int difShades = 0;
            if (firstImage.Length == secondImage.Length)
            {

                for (int cell = 0; cell < firstImage.Length; cell++)
                {
                    difShades += Math.Abs(firstImage[cell] - secondImage[cell]);
                }
            }
            //else NotePad.DoLog("pictures are different: " + firstImage.Length + " and " + secondImage.Length);
            return difShades;
        }
    }
}