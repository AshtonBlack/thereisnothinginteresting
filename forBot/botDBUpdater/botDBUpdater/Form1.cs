using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace botDBUpdater
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Car> fulltablearray { get; set; }        
        string excelFilePath = @"C:\projects\bot\cars.xlsx";
        string cashCarsPath = @"C:\projects\bot\thereisnothinginteresting\NewPL\CashCars.txt";
        string originalPicturesPath = @"C:\Bot\png_cards_archive\";
        string pictureForChange;
        void FullTable()
        {
            fulltablearray = ExcelParcer.Parse(excelFilePath);
            cashSR();
            label49.Text = CalculateKnownCar().ToString();
        }
        void cashSR()
        {
            if (File.Exists(cashCarsPath))
            {
                using (StreamReader sr = new StreamReader(cashCarsPath, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null && line != " " && line != "")
                    {
                        string carname = GetWordFromText(line, 2);
                        int amount = Convert.ToInt32(GetWordFromText(line, 1));

                        foreach(Car car in fulltablearray)
                        {
                            if(car.fullname() == carname)
                            {
                                fulltablearray.Find(thecar => thecar.fullname() == carname).amount = amount;
                                break;
                            }
                        }                    
                    }
                    sr.Close();
                }
            }
        }
        System.Object[] CollectCountries()
        {
            List<System.Object> Countries = new List<System.Object>();

            foreach (Car car in fulltablearray)
            {
                if(!Countries.Contains(car.country))
                {
                    Countries.Add(car.country);
                }
            }
            Countries.Sort();
            return Countries.ToArray();
        }
        System.Object[] CollectManufacturers(string country)
        {
            List<System.Object> Manufacturers = new List<System.Object>();

            foreach (Car car in fulltablearray)
            {
                if (country.Equals(car.country) && !Manufacturers.Contains(car.manufacturer))
                {
                    Manufacturers.Add(car.manufacturer);
                }
            }
            Manufacturers.Sort();
            return Manufacturers.ToArray();
        }
        System.Object[] CollectModels(string country, string manufacturer)
        {
            List<System.Object> Models = new List<System.Object>();

            foreach (Car car in fulltablearray)
            {
                if (car.country == country && car.manufacturer == manufacturer)
                {
                    Models.Add(car.model + " " + car.year);
                }
            }
            Models.Sort();
            return Models.ToArray();
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label52.Text = "default";
            comboBox2.Items.Clear();
            comboBox2.Text = null;
            comboBox3.Items.Clear();
            comboBox3.Text = null;
            comboBox2.Items.AddRange(CollectManufacturers(comboBox1.Text));
        }
        void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label52.Text = "default";
            comboBox3.Items.Clear();
            comboBox3.Text = null;
            comboBox3.Items.AddRange(CollectModels(comboBox1.Text, comboBox2.Text));
        }
        void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wantedcar = comboBox2.Text + " " + comboBox3.Text;
            foreach (Car car in fulltablearray)
            {
                string thecar = car.manufacturer + " " + car.model + " " + car.year;
                if (wantedcar == thecar)
                {
                    label52.Text = car.amount.ToString();
                    pictureBox1.Image = Image.FromFile(originalPicturesPath + car.pictureId + ".png");
                    break;
                }
            }
        }        
        void WriteCashCars()
        {
            using (StreamWriter sw = new StreamWriter(cashCarsPath, false, System.Text.Encoding.Default))
            {
                foreach(Car car in fulltablearray)
                {
                    sw.WriteLine(car.amount + " " + car.fullname());
                }
                sw.Close();
            }
        }
        void AddCashCar()
        {
            int number = Convert.ToInt32(textBox42.Text);
            string wantedcar = comboBox2.Text + " " + comboBox3.Text;
            fulltablearray.Find(car => car.fullname() == wantedcar).amount += number;
            WriteCashCars();
            label52.Text = fulltablearray.Find(car => car.fullname() == wantedcar).amount.ToString();
            label49.Text = CalculateKnownCar().ToString();
        }
        void SetCashCar()
        {
            int number = Convert.ToInt32(textBox42.Text);
            string wantedcar = comboBox2.Text + " " + comboBox3.Text;
            fulltablearray.Find(car => car.fullname() == wantedcar).amount = number;
            WriteCashCars();
            label52.Text = fulltablearray.Find(car => car.fullname() == wantedcar).amount.ToString();
            label49.Text = CalculateKnownCar().ToString();
        }
        void RemoveCashCar()
        {
            int number = Convert.ToInt32(textBox42.Text);
            string wantedcar = comboBox2.Text + " " + comboBox3.Text;
            fulltablearray.Find(car => car.fullname() == wantedcar).amount -= number;
            WriteCashCars();
            label52.Text = fulltablearray.Find(car => car.fullname() == wantedcar).amount.ToString();
            label49.Text = CalculateKnownCar().ToString();
        }
        int CalculateKnownCar()
        {
            int count = 0;
            foreach(Car car in fulltablearray)
            {
                count += car.amount;
            }

            return count;
        }
        void button3_Click(object sender, EventArgs e)
        {
            AddCashCar();
        }
        void button6_Click(object sender, EventArgs e)
        {
            SetCashCar();
        }
        void button4_Click(object sender, EventArgs e)
        {
            RemoveCashCar();
        }
        void Form1_Load(object sender, EventArgs e)
        {
            List<string> allPictures = new List<string> (Directory.GetFiles(@"C:\Bot\thereisnothinginteresting\Condition1"));
            Directory.CreateDirectory(@"C:\Bot\test");
            int counter = 0;
            foreach (string file in allPictures)
            {
                if (!file.Contains("txt"))
                {
                    MasterOfPictures.TransformPictureIntoBW(file, @"C:\Bot\test\" + counter.ToString() + ".jpg");
                    counter++;
                }                
            }            
        }   
        string GetWordFromText(string line, int wordN)
        {
            char[] word = line.Trim().ToCharArray();

            int firstwordlength = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != ' ')
                {
                    firstwordlength++;
                }
                else break;
            }
            char[] firstword = new char[firstwordlength];
            for (int i = 0; i < firstword.Length; i++)
            {
                firstword[i] = word[i];
            }

            char[] secondword = new char[word.Length - firstwordlength - 1];
            for (int i = 0; i < secondword.Length; i++)
            {
                secondword[i] = word[i + firstwordlength + 1];
            }

            if (wordN == 1)
            {
                return new string(firstword);
            }
            else
            {
                return new string(secondword);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                excelFilePath = openFileDialog.FileName;
            }                        
            label17.Text = excelFilePath;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                cashCarsPath = openFileDialog.FileName;
            }
            FullTable();
            comboBox1.Items.AddRange(CollectCountries());
            label18.Text = cashCarsPath;
        }

        //From bot.v.0.07 ====================================================
                
        void button8_Click(object sender, EventArgs e)
        {
            DevKit dk = new DevKit();
            label6.Text = dk.CalculateDifShades(textBox2.Text, textBox3.Text);
        }
        void button9_Click(object sender, EventArgs e)
        {
            int x0 = Convert.ToInt32(textBox4.Text);
            int y0 = Convert.ToInt32(textBox5.Text);
            int x1 = Convert.ToInt32(textBox6.Text);
            int y1 = Convert.ToInt32(textBox7.Text);
            int rectwidth = x1 - x0;
            int rectheight = y1 - y0;
            string commonpath = @"C:\projects\bot\thereisnothinginteresting\";
            string path = "test.jpg";
            this.WindowState = FormWindowState.Minimized;
            Thread.Sleep(2000);
            Rectangle rect = new Rectangle(x0, y0, rectwidth, rectheight);
            MasterOfPictures.MakePicture(rect, commonpath + path);
            this.WindowState = FormWindowState.Normal;
        }
        void button10_Click(object sender, EventArgs e)
        {
            DevKit dk = new DevKit();
            label6.Text = dk.CalculateDifs(textBox2.Text, textBox3.Text);
        }
        public class NotePad
        {
            public static void DoErrorLog(string text)
            {
                using (StreamWriter sw = new StreamWriter(@"C:\projects\bot\thereisnothinginteresting\Errors.txt", true, System.Text.Encoding.Default))//true для дописывания 
                {
                    sw.WriteLine(text);
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
                    captured.Save(PATH, ImageFormat.Jpeg);
                }
                gdi.Dispose();
                captured.Dispose();
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
                        var averageValue = (colorValue.R + colorValue.B + colorValue.G) / 3; // get the average for black and white
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
                Bitmap picturetest = new Bitmap("C:\\Bot\\" + PATH + ".jpg");
                Bitmap picture = new Bitmap("C:\\Bot\\" + ORIGINALPATH + ".jpg");
                bool flag1 = true;
                int differences = 0;
                for (int x = 0; x < picturetest.Width; x++)
                {
                    if (flag1 == true)
                    {
                        for (int y = 0; y < picturetest.Height; y++)
                        {
                            //Console.Write("сравниваю пиксель " + x + " " + y + " " + DateTime.Now.ToLongTimeString() + " ");
                            //Console.Write(picturetest.GetPixel(x, y) + " ");
                            //Console.Write(picture.GetPixel(x, y) + " ");
                            if (Math.Abs((int)picturetest.GetPixel(x, y).R - (int)picture.GetPixel(x, y).R) < 200)
                            {
                                //Console.WriteLine("совпали");
                            }
                            else
                            {
                                //Console.WriteLine("разные");
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
                Console.WriteLine("различие в " + differences + " пикселей");
                picturetest.Dispose();
                picture.Dispose();
                return flag1;
            }
            public static void TransformPictureIntoBW(string pictureName, string resultedPictureName)
            {
                Bitmap picture = new Bitmap(pictureName);
                Bitmap resultedPicture = new Bitmap(picture.Width, picture.Height);                
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
        public class DevKit
        {
            public Image ZoomImage(Image orig, float percent)
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
            public Image ZoomImage(Image orig)
            {
                Bitmap scaledImage;
                /// Ширина и высота результирующего изображения
                int w = 512;
                int h = 318;
                scaledImage = new Bitmap(w, h);
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
            public void ChangeColorDepth(Bitmap originalImage, string pathForResult, int depth)
            {
                ImageCodecInfo myImageCodecInfo;
                Encoder myEncoder;
                EncoderParameter myEncoderParameter;
                EncoderParameters myEncoderParameters;
                myImageCodecInfo = GetEncoderInfo("image/tiff");
                myEncoder = Encoder.ColorDepth;
                myEncoderParameters = new EncoderParameters(1);
                myEncoderParameter = new EncoderParameter(myEncoder, depth);
                myEncoderParameters.Param[0] = myEncoderParameter;
                originalImage.Save(pathForResult, myImageCodecInfo, myEncoderParameters);
            }
            public ImageCodecInfo GetEncoderInfo(string mimeType)
            {
                int j = 0;
                ImageCodecInfo[] encoders;
                encoders = ImageCodecInfo.GetImageEncoders();
                while (j < encoders.Length)
                {
                    if (encoders[j].MimeType == mimeType)
                    { return encoders[j]; }
                    j++;
                }
                return null;
            }
            public void BestPiece()
            {
                Bitmap picture = new Bitmap("C:\\Bot\\testcars1\\test1.jpg");
                Bitmap picturetest = new Bitmap("C:\\Bot\\testcars3\\test1.jpg");

                int x0 = 32;
                int y0 = 7;
                int bestposx = 0;
                int bestposy = 0;
                int minshadesdifs = -1;
                for (int zeroposx = 0; zeroposx < 114 - 50; zeroposx++)
                {
                    for (int zeroposy = 0; zeroposy < 64 - 50; zeroposy++)
                    {
                        int shadesdifs0 = 0;
                        for (int x1 = 0; x1 < 50; x1++)
                        {
                            for (int y1 = 0; y1 < 50; y1++)
                            {
                                var colorValue0 = picture.GetPixel(x0 + x1, y0 + y1);
                                var colorValue1 = picturetest.GetPixel(zeroposx + x1, zeroposy + y1);
                                int shadesdifs1 = (Math.Abs((int)colorValue0.R - (int)colorValue1.R) +
                                    Math.Abs((int)colorValue0.G - (int)colorValue1.G) +
                                    Math.Abs((int)colorValue0.B - (int)colorValue1.B));
                                shadesdifs0 += shadesdifs1;
                            }
                        }
                        NotePad.DoErrorLog("стартовая позиция второй картинки " + zeroposx + " " + zeroposy + ", отличие " + shadesdifs0 + " оттенков");
                        if (minshadesdifs == -1 || minshadesdifs > shadesdifs0)
                        {
                            minshadesdifs = shadesdifs0;
                            bestposx = zeroposx;
                            bestposy = zeroposy;
                        }
                    }
                }

                NotePad.DoErrorLog("наиболее подходящий кусок " + bestposx + " " + bestposy + " с отличием в " + minshadesdifs + " оттенков");

                picture.Dispose();
                picturetest.Dispose();
            } //pay attention
            public void MapsofDifs()
            {
                Bitmap picture = new Bitmap("C:\\Bot\\testcars1\\test.jpg");
                Bitmap picturetest = new Bitmap("C:\\Bot\\testcars5\\test.jpg");
                PixelFormat format = PixelFormat.Format24bppRgb;
                Bitmap Rmap = new Bitmap(picture.Width, picture.Height, format);
                Bitmap Gmap = new Bitmap(picture.Width, picture.Height, format);
                Bitmap Bmap = new Bitmap(picture.Width, picture.Height, format);
                Bitmap Noirmap = new Bitmap(picture.Width, picture.Height, format);

                int rMaxShadesDifs = 0;
                int gMaxShadesDifs = 0;
                int bMaxShadesDifs = 0;
                int noirMaxShadesDifs = 0;

                int rIdentical = 0;
                int gIdentical = 0;
                int bIdentical = 0;
                int noirIdentical = 0;

                for (int x = 0; x < picture.Width; x++)
                {
                    for (int y = 0; y < picture.Height; y++)
                    {
                        var colorValue0 = picture.GetPixel(x, y);
                        var colorValue1 = picturetest.GetPixel(x, y);
                        Rmap.SetPixel(x, y, (Color.FromArgb(Math.Abs((int)colorValue0.R - (int)colorValue1.R) * 10, 255, 255)));
                        if (rMaxShadesDifs < Math.Abs((int)colorValue0.R - (int)colorValue1.R)) rMaxShadesDifs = Math.Abs((int)colorValue0.R - (int)colorValue1.R);
                        if ((int)colorValue0.R - (int)colorValue1.R == 0) rIdentical++;

                        Gmap.SetPixel(x, y, (Color.FromArgb(255, Math.Abs((int)colorValue0.G - (int)colorValue1.G) * 10, 255)));
                        if (gMaxShadesDifs < Math.Abs((int)colorValue0.G - (int)colorValue1.G)) gMaxShadesDifs = Math.Abs((int)colorValue0.G - (int)colorValue1.G);
                        if ((int)colorValue0.G - (int)colorValue1.G == 0) gIdentical++;

                        Bmap.SetPixel(x, y, (Color.FromArgb(255, 255, Math.Abs((int)colorValue0.B - (int)colorValue1.B) * 10)));
                        if (bMaxShadesDifs < Math.Abs((int)colorValue0.B - (int)colorValue1.B)) bMaxShadesDifs = Math.Abs((int)colorValue0.B - (int)colorValue1.B);
                        if ((int)colorValue0.B - (int)colorValue1.B == 0) bIdentical++;

                        int noir = Math.Abs(((int)colorValue0.R + (int)colorValue0.G + (int)colorValue0.B) / 3 -
                            ((int)colorValue1.R + (int)colorValue1.G + (int)colorValue1.B) / 3);
                        Noirmap.SetPixel(x, y, (Color.FromArgb(noir, noir, noir)));
                        if (noirMaxShadesDifs < noir) noirMaxShadesDifs = noir;
                        if (noir == 0) noirIdentical++;
                    }
                }

                NotePad.DoErrorLog("Максимальное отклонение красный " + rMaxShadesDifs);
                NotePad.DoErrorLog("Максимальное отклонение зеленый " + gMaxShadesDifs);
                NotePad.DoErrorLog("Максимальное отклонение синий " + bMaxShadesDifs);
                NotePad.DoErrorLog("Максимальное отклонение нуар " + noirMaxShadesDifs);

                NotePad.DoErrorLog("красные совпали " + rIdentical);
                NotePad.DoErrorLog("зеленые совпали " + gIdentical);
                NotePad.DoErrorLog("синие совпали " + bIdentical);
                NotePad.DoErrorLog("нуар совпали " + noirIdentical);

                Rmap.Save("C:\\Bot\\Maps\\Rmap.jpg", ImageFormat.Jpeg);
                Gmap.Save("C:\\Bot\\Maps\\Gmap.jpg", ImageFormat.Jpeg);
                Bmap.Save("C:\\Bot\\Maps\\Bmap.jpg", ImageFormat.Jpeg);
                Noirmap.Save("C:\\Bot\\Maps\\Noirmap.jpg", ImageFormat.Jpeg);

                Rmap.Dispose();
                Gmap.Dispose();
                Bmap.Dispose();
                Noirmap.Dispose();
                picture.Dispose();
                picturetest.Dispose();
            } //for fun
            public void TestPictures()
            {
                Rectangle HandSlot1 = new Rectangle(85, 725, 115, 65);
                Rectangle HandSlot2 = new Rectangle(277, 725, 115, 65);
                Rectangle HandSlot3 = new Rectangle(469, 725, 115, 65);
                Rectangle HandSlot4 = new Rectangle(661, 725, 115, 65);
                Rectangle HandSlot5 = new Rectangle(853, 725, 115, 65);

                string carsDB = "testcars";
                Rectangle[] b = { HandSlot1, HandSlot2, HandSlot3, HandSlot4, HandSlot5 };
                for (int i = 0; i < 5; i++)
                {
                    MasterOfPictures.MakePicture(b[i], (carsDB + (i + 1) + "\\test1"));
                }
            } //fingers for test
            public string CalculateDifShades(string first, string second)
            {
                string result;
                Bitmap picture = new Bitmap(first);
                Bitmap picturetest = new Bitmap(second);
                int shadesdifs0 = 0;
                for (int x = 0; x < picture.Width; x++)
                {
                    for (int y = 0; y < picture.Height; y++)
                    {
                        var colorValue0 = picture.GetPixel(x, y);
                        var colorValue1 = picturetest.GetPixel(x, y);
                        int shadesdifs1 = (Math.Abs((int)colorValue0.R - (int)colorValue1.R) +
                            Math.Abs((int)colorValue0.G - (int)colorValue1.G) +
                            Math.Abs((int)colorValue0.B - (int)colorValue1.B));
                        shadesdifs0 += shadesdifs1;
                    }
                }
                result = shadesdifs0 + " diffs";
                picturetest.Dispose();
                picture.Dispose();
                return result;
            }
            public string CalculateDifs(string first, string second)
            {
                string result;
                Bitmap picture = new Bitmap(first);
                Bitmap picturetest = new Bitmap(second);
                int difs0 = 0;
                for (int x = 0; x < picture.Width; x++)
                {
                    for (int y = 0; y < picture.Height; y++)
                    {
                        var colorValue0 = picture.GetPixel(x, y);
                        var colorValue1 = picturetest.GetPixel(x, y);
                        if(colorValue0 != colorValue1)
                        {
                            difs0++;
                        }
                    }
                }
                result = difs0 + " diffs";
                picturetest.Dispose();
                picture.Dispose();
                return result;
            }            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureForChange = openFileDialog.FileName;
            }
            label1.Text = pictureForChange;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            DevKit dk = new DevKit();
            Bitmap originalPhoto = new Bitmap(pictureForChange);
            Bitmap scalableOriginalPhoto = new Bitmap(dk.ZoomImage(originalPhoto));
            originalPhoto.Dispose();
            string originalFileName = Path.GetFileNameWithoutExtension(pictureForChange);
            string originalFilePath = Path.GetDirectoryName(pictureForChange);
            string originalFileExtension = Path.GetExtension(pictureForChange);
            File.Move(pictureForChange, originalFilePath + "\\" + originalFileName + ".old" + originalFileExtension);
            dk.ChangeColorDepth(scalableOriginalPhoto, pictureForChange, 24);
            scalableOriginalPhoto.Dispose();
        }
    }
}