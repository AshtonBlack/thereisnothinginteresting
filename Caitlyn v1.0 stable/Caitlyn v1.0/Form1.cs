using System;
using System.Collections.Generic;
using System.Linq;
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
            navigation.InitialStart();
            navigation.InClubs();
            
            /*
            ConditionDB.GroupConditions();
            Application.Exit();
            */
            /*
            MyTest();
            Application.Exit();
            

            NotePad.DoLog("try to get Finger3");
            NotePad.DoLog(PointsAndRectangles.allpoints["Finger3"].ToString());
            NotePad.DoLog("try to get Finger3");
            NotePad.DoLog(PointsAndRectangles.allrectangles["Condition1Bounds"].ToString());
            */
        }
        //tests
        void MyTest()
        {
            NotePad.ClearLog();
            CarPictureDataBase carPictureDataBase = new CarPictureDataBase();
            carPictureDataBase.MakeDB();
            Condition.eventRQ = 145;
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
            
            /*
            TrackInfo[] tracksInfo = new TrackInfo[5];
            tracksInfo[0] = new TrackInfo("Асфальт", "Дождь", "Городские улицы у океана");
            tracksInfo[1] = new TrackInfo("Асфальт", "Дождь", "Короткая трасса у океана");
            tracksInfo[2] = new TrackInfo("Асфальт", "Дождь", "Быстрая трасса");
            tracksInfo[3] = new TrackInfo("Асфальт", "Дождь", "Слалом");
            tracksInfo[4] = new TrackInfo("Асфальт", "Дождь", "Магистраль у океана");            
            Condition.setPreviousTracks(tracksInfo);
            */
            //Condition.MakeCondition("икона стиля", "empty");
            Condition.MakeCondition("необычная", "empty");
            HandMaking hm = new HandMaking();
            hm.MakingHand1();
        }
        void FindAllCases(List<int> array)
        {            
            foreach (var item in array.Select((x, i) => new { x, i }))
            {
                List<int> result = new List<int>
                {
                    item.x
                };
                List<int> list = new List<int>(array);
                list.RemoveAt(item.i);
                stuff(list, result);
            }
        }
        void stuff(List<int> rest, List<int> result)
        {
            foreach (var item in rest.Select((x, i) => new { x, i }))
            {
                List<int> newresult = new List<int>(result)
                {
                    item.x
                };
                List<int> newrest = new List<int>(rest);
                newrest.RemoveAt(item.i);
                if (newrest.Count > 0)
                {
                    stuff(newrest, newresult);
                }
                else
                {
                    foreach(int number in newresult)
                    {
                        Console.Write(number);
                    }
                    Console.WriteLine();    
                }
            }
        }
    }
}
