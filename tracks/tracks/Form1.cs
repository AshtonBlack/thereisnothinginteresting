using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace tracks
{
    public partial class Form1 : Form
    {
        public string[,] trackpicturetoname { get; set; }
        public int tracklength { get; set; }
        string thereisnothinginterestingDirectory { get; set; } //or bot directory
        string trackList = @"C:\projects\bot\1.txt";
        string commonpath = @"C:\projects\bot\thereisnothinginteresting\Track";
        string path = @"\info.txt";
        string ending = ".jpg";
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            TrackPictureToNameTable();
        }

        public void TrackPictureToNameTable()
        {
            tracklength = 0;
            using (StreamReader sr = new StreamReader(commonpath + comboBox1.Text + path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null && line != " " && line != "")
                {
                    tracklength++;
                }
                sr.Close();
            }
            trackpicturetoname = new string[tracklength, 2];

            using (StreamReader sr = new StreamReader(commonpath + comboBox1.Text + path, System.Text.Encoding.Default))
            {
                for (int i = 0; i < tracklength; i++)
                {
                    string theline = sr.ReadLine();
                    trackpicturetoname[i, 0] = Transform3(theline, 1);
                    trackpicturetoname[i, 1] = Transform3(theline, 2);
                }
                sr.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(commonpath + comboBox1.Text + "\\" + textBox1.Text + ending))
            {
                pictureBox1.Image = Image.FromFile(commonpath + comboBox1.Text + "\\" + textBox1.Text + ending);
            }
            else
            {
                pictureBox1.Image = null;
            }

            label1.Text = commonpath + comboBox1.Text + "\\" + textBox1.Text + ending;
            comboBox2.Text = "unknown";

            for (int i = 0; i < tracklength; i++)
            {
                if (trackpicturetoname[i, 0] == textBox1.Text)
                {
                    comboBox2.Text = trackpicturetoname[i, 1];
                    break;
                }
            }
        }

        public string Transform3(string t, int wordN)
        {
            string forreturn;
            string a = t.Trim();
            char[] word = a.ToCharArray();

            int wordBlength = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != ' ')
                {
                    wordBlength++;
                }
                else break;
            }
            char[] wordB = new char[wordBlength];
            for (int i = 0; i < wordB.Length; i++)
            {
                wordB[i] = word[i];
            }

            char[] wordC = new char[word.Length - wordBlength - 1];
            for (int i = 0; i < wordC.Length; i++)
            {
                wordC[i] = word[i + wordBlength + 1];
            }

            if (wordN == 1)
            {
                forreturn = new string(wordB);
            }
            else
            {
                forreturn = new string(wordC);
            }
            return forreturn;
        }

        public void TrackPictureToNameTableAdd()
        {            
            string thetrack = comboBox2.Text;
            using (StreamWriter sw = new StreamWriter(commonpath + comboBox1.Text + path, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(textBox1.Text + " " + thetrack);
                sw.Close();
            }
            TrackPictureToNameTable();
            textBox1.Text = (Convert.ToInt32(textBox1.Text) + 1).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TrackPictureToNameTableAdd();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.Items.AddRange(ReadTracks().ToArray());
        }

        public List<String> ReadTracks()
        {
            List<String> tracks = new List<String>();
            using (StreamReader sr = new StreamReader(trackList, System.Text.Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null && line != " " && line != "")
                {
                    tracks.Add(line);
                }
                sr.Close();
            }
            tracks.Sort();
            return tracks;
        }

        public void SaveNewTrack(string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(trackList, true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(text);
                    sw.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SaveNewTrack(textBox2.Text);
            comboBox2.Items.AddRange(ReadTracks().ToArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                trackList = openFileDialog.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                thereisnothinginterestingDirectory = openFileDialog.FileName;
            }
        }
    }
}