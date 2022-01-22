using System;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace MousePositionbyAshton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Timer t = new Timer();
            t.Interval = 20;
            t.Tick += new EventHandler(t_Tick);
            t.Start();            
        }

        void t_Tick(object sender, EventArgs e)
        {
            label1.Text = Cursor.Position.X.ToString();
            label2.Text = Cursor.Position.Y.ToString();
        }
    }
}
