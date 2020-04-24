using System;
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
            Navigation navigation = new Navigation();
            navigation.ToClubMap();
            navigation.InClubs();
            /*
            Condition.MakeCondition(4);
            Condition.eventrq = 140;
            Condition.ActualRQ();
            textBox1.Text = Condition.minrq.ToString();
            textBox2.Text = Condition.maxrq.ToString();
            textBox3.Text = Condition.actualRQ.ToString();*/
        }
    }
}