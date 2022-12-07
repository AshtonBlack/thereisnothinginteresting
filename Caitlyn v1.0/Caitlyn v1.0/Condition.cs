﻿using System.Collections.Generic;
using System.Threading;

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
        public static bool[] tires { get; set; }
        public static int minrq { get; set; }
        public static int maxrq { get; set; }
        public static int maxclass { get; set; }
        public static int actualRQ { get; set; }
        public static int eventrq { get; set; }//рк эвента
        //to be deleted
        public static string weather { get; set; }//погода эвента
        public static string coverage { get; set; }//покрытия эвента
        //to be deleted
        // Tyres [0f, 1e, 2d, 3c, 4b, 5a, 6s]
        public static string ConditionNumber1 { get; set; }
        public static string ConditionNumber2 { get; set; }
        static int[] slikTyres { get; set; }
        static int[] dynamicTyres { get; set; }
        static int[] standartTyres { get; set; }
        static int[] allseasonTyres { get; set; }
        static int[] offroadTyres { get; set; }
        static int[] lowestRqCars { get; set; } //записывать рк
        static int[] rqCost = { 19, 29, 39, 49, 64, 79, 100 };
        static Condition() { }
        public static int AvailableCars(int carClass)
        {
            int number = 0;

            int[] overNumber = { slikTyres[carClass],
                                 dynamicTyres[carClass],
                                 standartTyres[carClass],
                                 allseasonTyres[carClass],
                                 offroadTyres[carClass] };
            for (int i = 0; i < 5; i++)
            {
                if (tires[i])
                {
                    number += overNumber[i];
                }
            }

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
            actualRQ = eventrq;
            if (actualRQ > maxrq) actualRQ = maxrq;
            if (actualRQ > accountLVL) actualRQ = accountLVL;
        }
        public static int[] LowestClassCars()
        {
            int[] classes = { 0, 0, 0, 0, 0 }; //f f f f f           
            for (int i = 0; i < lowestRqCars.Length; i++)
            {
                if (lowestRqCars[i] > 19) classes[i] = 1;//e
                if (lowestRqCars[i] > 29) classes[i] = 2;//d
                if (lowestRqCars[i] > 39) classes[i] = 3;//c
                if (lowestRqCars[i] > 49) classes[i] = 4;//b
                if (lowestRqCars[i] > 64) classes[i] = 5;//a
                if (lowestRqCars[i] > 79) classes[i] = 6;//s
            }
            NotePad.DoLog("Стартовые классы для условия " + classes[0] + " " + classes[1] + " " + classes[2] + " " + classes[3] + " " + classes[4]);
            return classes;
        }
        public static void MaxRq()
        {
            maxclass = 0;
            maxrq = 0;
            int carnumber = 0;
            for (int i = 6; i > -1; i--)
            {
                int overcars = 0;
                int carnumberingrade = 0;
                for (int j = 0; j < 5; j++)
                {
                    switch (j)
                    {
                        case 0:
                            carnumberingrade += slikTyres[i];
                            break;
                        case 1:
                            carnumberingrade += dynamicTyres[i];
                            break;
                        case 2:
                            carnumberingrade += standartTyres[i];
                            break;
                        case 3:
                            carnumberingrade += allseasonTyres[i];
                            break;
                        case 4:
                            carnumberingrade += offroadTyres[i];
                            break;
                    }
                }
                carnumber += carnumberingrade;
                if (maxclass == 0 && carnumber > 0) maxclass = i;
                if (carnumber > 4) overcars = carnumber - 5;
                maxrq += (carnumberingrade - overcars) * (rqCost[i]);
                if (carnumber > 4) break;
            }
        }
        public static void ChooseTyres()
        {
            tires = new bool[] { false, false, false, false, false };
            switch (coverage)
            {
                case "Асфальт":
                    if (weather == "ясно") ChooseDryAsphaltTyres();
                    if (weather == "дождь") ChooseWetAsphaltTyres();
                    if (weather == "с прояснением") ChooseMixedAsphaltTyres();
                    break;
                case "Бездорожье":
                    ChooseOffroadTyres();
                    break;
                default: // "Смешанное"
                    ChooseMixedCoverageTyres();
                    break;
            }
            ChooseTyresMechanic();
        }
        static void ChooseDryAsphaltTyres()
        {
            int minrq = 0;
            int carnumber = 0;
            int overcars = 0;
            for (int i = 0; i < 7; i++)
            {
                carnumber += slikTyres[i] + dynamicTyres[i];
                if (carnumber > 4)
                {
                    overcars = carnumber - 5;
                }
                minrq += (slikTyres[i] + dynamicTyres[i] - overcars) * rqCost[i];
                if (carnumber > 4)
                {
                    break;
                }
            }

            if (minrq <= eventrq && carnumber > 4)
            {
                tires[0] = true;
                tires[1] = true;
            }
            else
            {
                minrq = 0;
                carnumber = 0;
                overcars = 0;
                for (int i = 0; i < 7; i++)
                {
                    carnumber += slikTyres[i] + dynamicTyres[i] + standartTyres[i];
                    if (carnumber > 4)
                    {
                        overcars = carnumber - 5;
                    }
                    minrq += (slikTyres[i] + dynamicTyres[i] + standartTyres[i] - overcars) * rqCost[i];
                    if (carnumber > 4)
                    {
                        break;
                    }
                }
                if (minrq <= eventrq && carnumber > 4)
                {
                    tires[0] = true;
                    tires[1] = true;
                    tires[2] = true;
                }
                else
                {
                    tires[0] = true;
                    tires[1] = true;
                    tires[2] = true;
                    tires[3] = true;
                    tires[4] = true;
                }
            }
        }
        static void ChooseWetAsphaltTyres()
        {
            int minrq = 0;
            int carnumber = 0;
            int overcars = 0;
            for (int i = 0; i < 7; i++)
            {
                carnumber += dynamicTyres[i] + standartTyres[i];
                if (carnumber > 4)
                {
                    overcars = carnumber - 5;
                }
                minrq += (standartTyres[i] + dynamicTyres[i] - overcars) * rqCost[i];
                if (carnumber > 4)
                {
                    break;
                }
            }
            if (minrq <= eventrq && carnumber > 4)
            {
                tires[1] = true;
                tires[2] = true;
            }
            else
            {
                tires[1] = true;
                tires[2] = true;
                tires[3] = true;
            }
        }
        static void ChooseMixedAsphaltTyres()
        {
            int minrq = 0;
            int carnumber = 0;
            int overcars = 0;
            for (int i = 0; i < 7; i++)
            {
                carnumber += slikTyres[i] + dynamicTyres[i] + standartTyres[i];
                if (carnumber > 4)
                {
                    overcars = carnumber - 5;
                }
                minrq += (slikTyres[i] + dynamicTyres[i] + standartTyres[i] - overcars) * rqCost[i];
                if (carnumber > 4)
                {
                    break;
                }
            }

            if (minrq <= eventrq && carnumber > 4)
            {
                tires[0] = true;
                tires[1] = true;
                tires[2] = true;
            }
            else
            {
                tires[0] = true;
                tires[1] = true;
                tires[2] = true;
                tires[3] = true;
                tires[4] = true;
            }
        }
        static void ChooseOffroadTyres()
        {
            int minrq = 0;
            int carnumber = 0;
            int overcars = 0;
            for (int i = 0; i < 7; i++)
            {
                carnumber += allseasonTyres[i] + offroadTyres[i];
                if (carnumber > 4)
                {
                    overcars = carnumber - 5;
                }
                minrq += (allseasonTyres[i] + offroadTyres[i] - overcars) * rqCost[i];
                if (carnumber > 4)
                {
                    break;
                }
            }

            if (minrq <= eventrq && carnumber > 4)
            {
                tires[3] = true;
                tires[4] = true;
            }
            else
            {
                minrq = 0;
                carnumber = 0;
                overcars = 0;
                for (int i = 0; i < 7; i++)
                {
                    carnumber += allseasonTyres[i] + offroadTyres[i] + standartTyres[i];
                    if (carnumber > 4)
                    {
                        overcars = carnumber - 5;
                    }
                    minrq += (allseasonTyres[i] + offroadTyres[i] + standartTyres[i] - overcars) * rqCost[i];
                    if (carnumber > 4)
                    {
                        break;
                    }
                }
                if (minrq <= eventrq && carnumber > 4)
                {
                    tires[2] = true;
                    tires[3] = true;
                    tires[4] = true;
                }
                else
                {
                    tires[1] = true;
                    tires[2] = true;
                    tires[3] = true;
                    tires[4] = true;
                }
            }
        }
        static void ChooseMixedCoverageTyres()
        {
            tires[1] = true;
            tires[2] = true;
            tires[3] = true;
            tires[4] = true;
        }
        static void ChooseTyresMechanic()
        {
            Rat.Clk(PointsAndRectangles.tiresMenu);

            for (int i = 0; i < tires.Length; i++)
            {
                if (tires[i])
                {
                    switch (i)
                    {
                        case 0:
                            Rat.Clk(PointsAndRectangles.slik);
                            Thread.Sleep(200);
                            break;
                        case 1:
                            Rat.Clk(PointsAndRectangles.dynamic);
                            Thread.Sleep(200);
                            break;
                        case 2:
                            Rat.Clk(PointsAndRectangles.standart);
                            Thread.Sleep(200);
                            break;
                        case 3:
                            Rat.Clk(PointsAndRectangles.allseason);
                            Thread.Sleep(200);
                            break;
                        case 4:
                            Rat.Clk(PointsAndRectangles.offroad);
                            Thread.Sleep(200);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public static void MakeCondition(string number1, string number2)
        {
            ConditionNumber1 = number1;
            ConditionNumber2 = number2;
            weather = "с прояснением";
            coverage = "Смешанное";
            CarsDB.MakeCondAuto(number1, number2);
            /*test
            lowestRqCars = CarsDB.lowestcars;
            slikTyres = CarsDB.slikTyres;
            dynamicTyres = CarsDB.dynamicTyres;
            standartTyres = CarsDB.standartTyres;
            allseasonTyres = CarsDB.allseasonTyres;
            offroadTyres = CarsDB.offroadTyres;
            minrq = 0;
            for (int i = 0; i < 5; i++)
            {
                minrq += lowestRqCars[i];
            }
            */
            MaxRq();
            NotePad.DoLog("Условия сформированы");
        }
    }
}
