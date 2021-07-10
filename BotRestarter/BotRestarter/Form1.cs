﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace BotRestarter
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

            string[] names = { "notepad" };
            ClearNoxProcesses(names);
        
            Process.Start(@"C:\Bot\Bot.v.0.1\WindowsFormsApp1\bin\Debug\WindowsFormsApp1.exe");

            Application.Exit();
        }

        public void ClearNoxProcesses(string[] processnames)
        {
            foreach (string name in processnames)
            {
                Process[] processes = Process.GetProcessesByName(name);
                foreach (Process process in processes)
                {
                    process.Kill();
                }
            }
        }
    }
}
