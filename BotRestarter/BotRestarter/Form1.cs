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
            
            Thread.Sleep(15000);
            string[] names = { "Nox", "NoxVMHandle", "NoxVMSVC", "nox_adb", "EXCEL" };
            ClearNoxProcesses(names);
            TimingUnit tu = new TimingUnit();
            tu.WaitForAvailableTime();
            Process.Start(@"C:\Bot\Caitlyn v1.0\Caitlyn v1.0\bin\Debug\Caitlyn v1.0.exe");
            
            Application.Exit();
        }

        public void ClearNoxProcesses(string[] processnames)
        {
            foreach (string name in processnames)
            {
                Process[] processes = Process.GetProcessesByName(name);
                foreach (Process process in processes)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
    }
}