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
            Thread.Sleep(20000);

            Process.Start(@"C:\Bot\Bot.v.0.07\bin\Debug\Bot.v.0.07.exe");

            Application.Exit();
        }        
    }
}