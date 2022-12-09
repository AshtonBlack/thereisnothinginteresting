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
        public static int actualRQ { get; set; }
        public static string ConditionNumber1 { get; set; }
        public static string ConditionNumber2 { get; set; }
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
            if (actualRQ > accountLVL) actualRQ = accountLVL;
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
