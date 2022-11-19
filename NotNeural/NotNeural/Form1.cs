using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NotNeural
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string botPhotoName;
        string originalPhotoName;
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
        public void BestScaleDoubleZoom()
        {
            (int scalePercent, Point leftTopCorner, int difShades) bestResult = (0, new Point(0, 0), 5000000);
            Bitmap botPhoto1 = new Bitmap(botPhotoName);
            Bitmap botPhoto = new Bitmap(ZoomImage(botPhoto1, 20));
            Stopwatch myTimer = new Stopwatch();
            myTimer.Start();
            
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
            myTimer.Stop();
            Console.WriteLine(myTimer.ElapsedMilliseconds);
            label3.Text = myTimer.ElapsedMilliseconds.ToString();
            Console.WriteLine("лучший результат: "
                + bestResult.scalePercent + "% zoom, "
                + bestResult.leftTopCorner.X + " " + bestResult.leftTopCorner.Y + " начальная точка, отличие в "
                + bestResult.difShades + " оттенков");
            textBox2.Text = "лучший результат: "
                + bestResult.scalePercent + "% zoom, "
                + bestResult.leftTopCorner.X + " " + bestResult.leftTopCorner.Y + " начальная точка, отличие в "
                + bestResult.difShades + " оттенков";
            MapsofDifs(bestResult.scalePercent, bestResult.leftTopCorner);
        }
        public (Point leftTopCorner, int difShades) BestPiece(Bitmap scalableOriginalPhoto, Bitmap botPhoto)
        {           
            int bestposx = 0;
            int bestposy = 0;
            int minshadesdifs = 5000000;
            if(scalableOriginalPhoto.Width >= botPhoto.Width && scalableOriginalPhoto.Height >= botPhoto.Height)
            {
                for (int zeroposx = 0; zeroposx < scalableOriginalPhoto.Width - botPhoto.Width; zeroposx++)
                {
                    for (int zeroposy = 1; zeroposy < scalableOriginalPhoto.Height - botPhoto.Height; zeroposy++)//zeropos changed from 0 to 1 to avoid differences on edges
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
            Console.WriteLine("наиболее подходящий кусок " + bestposx + " " + bestposy + " с отличием в " + minshadesdifs + " оттенков");
            return (new Point(bestposx, bestposy), minshadesdifs);
        }

        public void MapsofDifs(int zoom, Point startPoint)
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
    }
}
