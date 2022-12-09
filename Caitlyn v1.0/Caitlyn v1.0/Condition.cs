using System.Collections.Generic;

namespace Caitlyn_v1._0
{
    static class Condition
    {
        //new
        public static int eventRQ { get; set; }//рк эвента
        public static int minRQ { get; set; }
        public static List<CarForExcel> selectedCars { get; set; }
        public static TrackInfo[] previousTracks { get; set; }
        public static void setDefaultTracks()
        {
            previousTracks = new TrackInfo[5];
            for (int i = 0; i < previousTracks.Length; i++)
            {
                previousTracks[i] = new TrackInfo("Неизвестное покрытие", "Неизвестная погода", "Неизвестная трасса");
            }
        }
        public static void setPreviousTracks(TrackInfo[] trackInfo)
        {
            previousTracks = trackInfo;
        }
        //new
        public static int accountLVL = 500;
        public static int maxrq { get; set; }
        public static int actualRQ { get; set; }
        //to be deleted
        public static string weather { get; set; }//погода эвента
        public static string coverage { get; set; }//покрытия эвента
        //to be deleted
        // Tyres [0f, 1e, 2d, 3c, 4b, 5a, 6s]
        public static string ConditionNumber1 { get; set; }
        public static string ConditionNumber2 { get; set; }
        static int[] lowestRqCars { get; set; } //записывать рк
        static Condition() { }
        public static int AvailableCars(int carClass)
        {
            int number = 0;

            if (number > 4)
            {
                if (number % 2 == 0)
                {
                    number -= 2;
                    NotePad.DoLog("недостигаемы 2 машины");
                }
                else
                {
                    number -= 1;
                    NotePad.DoLog("недостигаема 1 машина");
                }
            } //исключаем сломаные места            
            return number;
        } //доступные машины
        public static void ActualRQ()
        {
            actualRQ = eventRQ;
            if (actualRQ > maxrq) actualRQ = maxrq;
            if (actualRQ > accountLVL) actualRQ = accountLVL;
        }
        public static void MakeCondition(string number1, string number2)
        {
            ConditionNumber1 = number1;
            ConditionNumber2 = number2;
            weather = "с прояснением";
            coverage = "Смешанное";
            CarsDB.MakeCondAuto(number1, number2);
            NotePad.DoLog("Условия сформированы");
        }
    }
}
