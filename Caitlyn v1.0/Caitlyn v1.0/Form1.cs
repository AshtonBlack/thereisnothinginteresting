﻿using System;
using System.Windows.Forms;

namespace Caitlyn_v1._0
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
            CarPictureDataBase carPictureDataBase = new CarPictureDataBase();
            carPictureDataBase.MakeDB();
            Navigation navigation = new Navigation();
            navigation.ToClubMap();
            navigation.InClubs();
        }
    }
}
