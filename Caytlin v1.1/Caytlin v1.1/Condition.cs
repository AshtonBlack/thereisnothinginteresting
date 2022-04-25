using System.Collections.Generic;

namespace Caytlin_v1._1
{
    internal class Condition
    {
        public static int accountLVL = 500;
        public static int eventRQ { get; set; }//рк эвента
        public static string ConditionNumber1 { get; set; }
        public static string ConditionNumber2 { get; set; }
        public static int minRQ { get; set; }
        public static List<CarForExcel> selectedCars { get; set; }
        public static TrackInfo[] previousTracks { get; set; }
        static Condition() { }
        public static void setDefaultTracks()
        {
            previousTracks = new TrackInfo[5];
            for (int i = 0; i < previousTracks.Length; i++)
            {
                previousTracks[i].ground = "Неизвестное покрытие";
                previousTracks[i].weather = "Неизвестная погода";
                previousTracks[i].track = "Неизвестная трасса";
            }
        }
        public static void setPreviousTracks(TrackInfo[] trackInfo)
        {
            previousTracks = trackInfo;
        }
        public static void setEventRQ(int RQ)
        {
            if (RQ > accountLVL) eventRQ = accountLVL;
            else eventRQ = RQ;
        }                
        public static void MakeCondition(string number1, string number2)
        {
            ConditionNumber1 = number1;
            ConditionNumber2 = number2;
            CarsDB.MakeCondAuto(number1, number2);
            NotePad.DoLog("Условия сформированы");
        }
    }
}
