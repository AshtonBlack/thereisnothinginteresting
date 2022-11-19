using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace @short
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string pictureFullpath;
        string picturePath;
        string finger1Path = @"C:\Bot\Finger1";

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureFullpath = openFileDialog.FileName;
                picturePath = Path.GetDirectoryName(pictureFullpath);
                File.Copy(pictureFullpath, picturePath + "\\test.jpg", true);
            }
            
            label1.Text = picturePath;
            
            if (File.Exists(picturePath + "\\test.jpg"))
            {
                pictureBox1.Image = Image.FromFile(picturePath + "\\test.jpg");
            }
            else
            {
                pictureBox1.Image = null;
            }            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int x0 = 0;
            int y0 = 0;
            int bestMatch = 50000000;
            string bestMatchPictureName = null;
            string[] picturesFromFinger1 = readFilesFromDirectory(finger1Path);
            Bitmap pictureFromFinger = new Bitmap(pictureFullpath);
            foreach (string pictureNameFromFinger1 in picturesFromFinger1)
            {
                if (pictureNameFromFinger1.Contains("jpg"))
                {
                    Bitmap pictureFromFinger1 = new Bitmap(pictureNameFromFinger1);
                    int shadesdifs = 0;
                    for (int x = 0; x < 115; x++)
                    {
                        for (int y = 0; y < 65; y++)
                        {
                            var colorValue0 = pictureFromFinger.GetPixel(x + x0, y + y0);
                            var colorValue1 = pictureFromFinger1.GetPixel(x + x0, y + y0);
                            shadesdifs += (Math.Abs((int)colorValue0.R - (int)colorValue1.R) +
                                Math.Abs((int)colorValue0.G - (int)colorValue1.G) +
                                Math.Abs((int)colorValue0.B - (int)colorValue1.B));
                        }
                    }
                    pictureFromFinger1.Dispose();
                    if (shadesdifs < bestMatch)
                    {
                        bestMatch = shadesdifs;
                        bestMatchPictureName = pictureNameFromFinger1;
                    }
                }
            }
            pictureFromFinger.Dispose();
            label2.Text = bestMatch.ToString();
            label3.Text = bestMatchPictureName;
            if (File.Exists(bestMatchPictureName))
            {
                pictureBox2.Image = Image.FromFile(bestMatchPictureName);
            }
            else
            {
                pictureBox2.Image = null;
            }
        }
        string[] readFilesFromDirectory(string PathToFolder)
        {
            return Directory.GetFiles(PathToFolder);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                finger1Path = folderBrowserDialog.SelectedPath;
            }
            label4.Text = finger1Path;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}
