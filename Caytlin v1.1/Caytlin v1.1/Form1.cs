using System;
using System.Windows.Forms;

namespace Caytlin_v1._1
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
            //ToDelete
            MyTest();
            Application.Exit();
            /*
            Navigation navigation = new Navigation();
            navigation.ToClubMap();
            navigation.InClubs();
            */                
        }
        void MyTest()
        {
            NotePad.ClearLog();
            Condition.eventRQ = 240;
            TrackInfo testTrack = new TrackInfo();
            testTrack.weather = "Дождь";
            testTrack.ground = "Асфальт";
            testTrack.track = "Подъем на холм";
            Condition.previousTracks = new TrackInfo[5];
            Condition.previousTracks[0] = testTrack;
            Condition.previousTracks[1] = testTrack;
            Condition.previousTracks[2] = testTrack;
            Condition.previousTracks[3] = testTrack;
            Condition.previousTracks[4] = testTrack;
            CarsDB.MakeCondAuto("автоспорт", "empty"); 
            HandMaking hm = new HandMaking();
            hm.ChooseCars();
        }
    }
}
