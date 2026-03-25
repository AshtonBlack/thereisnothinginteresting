using System.Collections.Generic;

namespace Caitlyn_v1._0
{
    static class Condition
    {
        public static int eventRQ { get; set; }//рк эвента
        public static int minRQ { get; set; }
        public static List<CarForExcel> selectedCars { get; set; }
        public static TrackInfo[] tracks { get; set; }
        public static void setDefaultTracks()
        {
            tracks = new TrackInfo[5];
            for (int i = 0; i < tracks.Length; i++)
            {
                tracks[i] = new TrackInfo("Неизвестное покрытие", "Неизвестная погода", "Неизвестная трасса");
            }
        }
        public static void setTracks(TrackInfo[] trackInfo)
        {
            tracks = trackInfo;
        }
        public static string ConditionNumber1 { get; set; }
        public static string ConditionNumber2 { get; set; }
        static Condition() { }  
        public static void MakeCondition(string number1, string number2)
        {
            ConditionNumber1 = number1;
            ConditionNumber2 = number2;
            CarsDB.MakeCondAuto();
            NotePad.DoLog("Условия сформированы");
        }
    }
}
