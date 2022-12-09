using System;
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
            Navigation navigation = new Navigation();
            navigation.ToClubMap();
            navigation.InClubs();            
            //ToDelete
            /*
            MyTest();
            Application.Exit();
            */
        }
        void MyTest()
        {
            NotePad.ClearLog();
            CarPictureDataBase carPictureDataBase = new CarPictureDataBase();
            carPictureDataBase.MakeDB();
            Condition.eventRQ = 350;
            /*
            TrackInfo testTrack = new TrackInfo();
            testTrack.weather = "Дождь";
            testTrack.ground = "Грунт";
            testTrack.track = "Подъем на холм";
            Condition.previousTracks = new TrackInfo[5];
            Condition.previousTracks[0] = testTrack;
            Condition.previousTracks[1] = testTrack;
            Condition.previousTracks[2] = testTrack;
            Condition.previousTracks[3] = testTrack;
            Condition.previousTracks[4] = testTrack;
            */
            Condition.setDefaultTracks();
            CarsDB.MakeCondAuto("икона стиля", "empty");
            HandMaking hm = new HandMaking();
            //hm.ChooseCars();
            hm.MakingHand1();
        }
    }
}
