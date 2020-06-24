using System;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
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
            /*
            Rat.Clk(1165, 15);
            Thread.Sleep(2000);
            FastCheck fc = new FastCheck();
            fc.DrawSet();
            fc.DailyBounty();            
            fc.WonSet();
            fc.LostSet();
            fc.RaceEnd();
            fc.AcceptThrow();
            Application.Exit();
            */

            Navigation navigation = new Navigation();
            navigation.ToClubMap();
            navigation.InClubs();        
            
        }
    }
}