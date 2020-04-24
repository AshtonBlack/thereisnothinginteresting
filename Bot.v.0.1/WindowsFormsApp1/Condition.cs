using System.Drawing;
using System.Threading;

namespace WindowsFormsApp1
{
    static class Condition
    {
        static bool[] tires { get; set; }
        public static int minrq { get; set; }
        static int maxrq { get; set; }
        public static int maxclass { get; set; }

        public static int eventrq { get; set; }//рк эвента
        public static string weather { get; set; }//погода эвента
        public static string coverage { get; set; }//покрытия эвента

        // Tyres [0f, 1e, 2d, 3c, 4b, 5a, 6s]
        public static int conditionNumber { get; set; }
        static int[] slikTyres { get; set; }
        static int[] dynamicTyres { get; set; }
        static int[] standartTyres { get; set; }
        static int[] allseasonTyres { get; set; }
        static int[] offroadTyres { get; set; }
        static int[] lowestRqCars { get; set; } //записывать рк

        public static int ActualRQ()
        {
            int x = eventrq;
            if (x > maxrq) x = maxrq;
            return x;
        }

        public static int[] LowestClassCars()
        {
            int[] classes = { 0, 0, 0, 0, 0 }; //f f f f f           
            for(int i = 0; i < lowestRqCars.Length; i++)
            {
                if (lowestRqCars[i] > 6) classes[i] = 1;//e
                if (lowestRqCars[i] > 10) classes[i] = 2;//d
                if (lowestRqCars[i] > 14) classes[i] = 3;//c
                if (lowestRqCars[i] > 18) classes[i] = 4;//b
                if (lowestRqCars[i] > 22) classes[i] = 5;//a
                if (lowestRqCars[i] > 26) classes[i] = 6;//s
            }
            NotePad.DoLog("Стартовые классы для условия " + classes.ToString());
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
                maxrq += (carnumberingrade - overcars) * (6 + 4 * i);
                if (carnumber > 4) break;
            }   
        }

        public static void ChooseTyres()
        {
            tires = new bool[]{ false, false, false, false, false};
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
            for(int i = 0; i < 7; i++)
            {
                carnumber += slikTyres[i] + dynamicTyres[i];
                if (carnumber > 4)
                {
                    overcars = carnumber - 5;
                }
                minrq += (slikTyres[i] + dynamicTyres[i] - overcars) * (6 + 4 * i);
                if(carnumber > 4)
                {
                    break;
                }
            }
           
            if (minrq <= eventrq)
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
                    minrq += (slikTyres[i] + dynamicTyres[i] + standartTyres[i] - overcars) * (6 + 4 * i);
                    if (carnumber > 4)
                    {
                        break;
                    }
                }
                if (minrq <= eventrq)
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
                minrq += (standartTyres[i] + dynamicTyres[i] - overcars) * (6 + 4 * i);
                if (carnumber > 4)
                {
                    break;
                }
            }
            if (minrq <= eventrq)
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
                minrq += (slikTyres[i] + dynamicTyres[i] + standartTyres[i] - overcars) * (6 + 4 * i);
                if (carnumber > 4)
                {
                    break;
                }
            }

            if (minrq <= eventrq)
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
                minrq += (allseasonTyres[i] + offroadTyres[i] - overcars) * (6 + 4 * i);
                if (carnumber > 4)
                {
                    break;
                }
            }

            if (minrq <= eventrq)
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
                    minrq += (allseasonTyres[i] + offroadTyres[i] + standartTyres[i] - overcars) * (6 + 4 * i);
                    if (carnumber > 4)
                    {
                        break;
                    }
                }
                if (minrq <= eventrq)
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
            Point tiresMenu = new Point(200, 635);

            Point dynamic = new Point(490, 450);
            Point standart = new Point(700, 450);
            Point allseason = new Point(910, 450);
            Point offroad = new Point(1120, 450);
            Point slik = new Point(490, 600);

            Point fwd = new Point(700, 600);
            Point rwd = new Point(910, 600);
            Point awd = new Point(1120, 600);

            Rat.Clk(tiresMenu);

            for(int i = 0; i < tires.Length; i++)
            {
                if (tires[i])
                {
                    switch (i)
                    {
                        case 0:
                            Rat.Clk(slik);
                            Thread.Sleep(200);
                            break;
                        case 1:
                            Rat.Clk(dynamic);
                            Thread.Sleep(200);
                            break;
                        case 2:
                            Rat.Clk(standart);
                            Thread.Sleep(200);
                            break;
                        case 3:
                            Rat.Clk(allseason);
                            Thread.Sleep(200);
                            break;
                        case 4:
                            Rat.Clk(offroad);
                            Thread.Sleep(200);
                            break;
                        default:
                            break;
                    }
                }                
            }
        }

        public static void MakeCondition(int number)
        {
            int[] lrc;
            int[] slT;
            int[] dyT;
            int[] stT;
            int[] asT;
            int[] orT;
            conditionNumber = number;
            switch (number)
            {
                case 1://задний привод//
                    lrc = new int[] { 3, 3, 3, 3, 3 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 2, 0, 3, 1, 3, 4 };
                    slikTyres = slT;
                    dyT = new int[] { 24, 21, 52, 115, 130, 74, 19};
                    dynamicTyres = dyT;
                    stT = new int[] { 20, 12, 19, 29, 32, 5, 0};
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 2, 1, 1, 0, 0};
                    allseasonTyres = asT;
                    orT = new int[] { 0, 1, 3, 6, 11, 0, 0};
                    offroadTyres = orT;
                    break;

                case 2://передний привод
                    lrc = new int[] { 3, 3, 3, 4, 4 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 8, 2, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] {7,10,16,92,28,0,0};
                    dynamicTyres = dyT;
                    stT = new int[] { 19,16,22,16,0,0,0};
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 5, 2, 2, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 13, 1, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 3://обычная х3
                    lrc = new int[] { 3, 3, 3, 3, 3 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0,2,0,11,4,4,5 };
                    slikTyres = slT;
                    dyT = new int[] { 32,33,72,235,220,112,30 };
                    dynamicTyres = dyT;
                    stT = new int[] { 43,39,47,105,44,12,0};
                    standartTyres = stT;
                    asT = new int[] { 0, 4, 13, 130, 53, 16, 4 };
                    allseasonTyres = asT;
                    orT = new int[] { 2, 5, 9, 30, 18, 1, 1 };
                    offroadTyres = orT;
                    break;

                case 4://Audi
                    lrc = new int[] { 15, 17, 18, 21, 22 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0,0,0,3,4,12,0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 1 };
                    offroadTyres = orT;
                    break;

                case 5://бензиновые
                    lrc = new int[] { 3, 3, 3, 3, 3 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 11, 4, 3, 5 };
                    slikTyres = slT;
                    dyT = new int[] { 30,33,72,232,212,107,30 };
                    dynamicTyres = dyT;
                    stT = new int[] { 35,32,35,66,31,9,0 };
                    standartTyres = stT;
                    asT = new int[] { 0,1,7,48,38,13,4};
                    allseasonTyres = asT;
                    orT = new int[] { 2,3,8,30,18,1,1};
                    offroadTyres = orT;
                    break;

                case 6://необычная 5
                    lrc = new int[] { 7,7,7,7,7 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 2, 0,0,0,0,0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 33, 0, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 39, 0, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 4, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 5, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 7://япония
                    lrc = new int[] { 3, 3, 4, 4, 4 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0,0,0,0,0,1,0 };
                    slikTyres = slT;
                    dyT = new int[] { 4,1,5,39,20,11,0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 4,6,5,25,11,2,0};
                    standartTyres = stT;
                    asT = new int[] { 0,1,6,72,21,2,0 };
                    allseasonTyres = asT;
                    orT = new int[] {0,0,0,13,2,0,0};
                    offroadTyres = orT;
                    break;

                case 8://яга
                    lrc = new int[] { 7, 7, 7, 7, 7 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0,0,0,2,0,0,0 };
                    slikTyres = slT;
                    dyT = new int[] { 0,1,0,7,14,6,2 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0,9,2,1,4,0,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 2, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 9://Сша
                    lrc = new int[] { 3, 3, 4, 4, 4 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 5,8,20,23,29,19,5 };
                    dynamicTyres = dyT;
                    stT = new int[] { 6,7,7,21,5,3,0 };
                    standartTyres = stT;
                    asT = new int[] {0,0,3,13,13,5,0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0,2,1,5,6,1,0 };
                    offroadTyres = orT;
                    break;

                case 10://редкостная
                    lrc = new int[] { 11,11,11,11,11 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 72, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 47, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 13, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 9, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 11://экстремальная
                    lrc = new int[] { 19,19,19,19,19 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 4, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 0, 220, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 0, 44, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 53, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 18, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 12://стандартные шины
                    lrc = new int[] { 3, 3, 3, 3, 3 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] {43,39,47,105,44,12,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 13://пикапы
                    lrc = new int[] { 3,5,7,8,9 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 1,1,1,4,2,0,0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 1,2,0,4,1,2,0 };
                    standartTyres = stT;
                    asT = new int[] { 0,1,1,15,1,0,0 };
                    allseasonTyres = asT;
                    orT = new int[] {0,1,1,1,5,1,0};
                    offroadTyres = orT;
                    break;

                case 14://мерсы
                    lrc = new int[] { 6,7,7,7,13 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0,0,0,4,7,6,1 };
                    dynamicTyres = dyT;
                    stT = new int[] { 1,3,1,10,6,2,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 6, 1, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 2, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 15://рено
                    lrc = new int[] { 5, 6, 8, 9, 9 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0,2,0,8,0,1,0 };
                    slikTyres = slT;
                    dyT = new int[] { 1,0,3,20,12,2,0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 1, 3, 1, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 1, 7, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 5, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 16://4х4
                    lrc = new int[] { 4, 6, 6, 6, 6 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 1,1,3,9,41,34,11 };
                    dynamicTyres = dyT;
                    stT = new int[] { 2,2,6,48,14,8,0 };
                    standartTyres = stT;
                    asT = new int[] { 0,4,6,126,50,16,4 };
                    allseasonTyres = asT;
                    orT = new int[] { 2,4,6,11,6,1,1};
                    offroadTyres = orT;
                    break;

                case 17://англия
                    lrc = new int[] { 3, 4, 4, 4, 4 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 2, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 7,10,10,54,59,24,10 };
                    dynamicTyres = dyT;
                    stT = new int[] { 12,13,8,4,7,0,0 };
                    standartTyres = stT;
                    asT = new int[] {0,3,3,18,3,6,1 };
                    allseasonTyres = asT;
                    orT = new int[] {1,1,5,0,2,0,0 };
                    offroadTyres = orT;
                    break;

                case 18://крайслер
                    lrc = new int[] { 4, 5, 6, 7, 10 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 1,2,1,0,2,0,1};
                    dynamicTyres = dyT;
                    stT = new int[] { 2,1,0,4,0,0,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 2, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 19://пежо
                    lrc = new int[] { 9, 10, 11, 19, 19 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] {0,2,1,0,7,0,0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 1 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 20://хонда
                    lrc = new int[] { 4, 4, 4, 4, 6 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 4,0,1,13,5,0,0 };
                    dynamicTyres = dyT;
                    stT = new int[] {2,1,1,3,1,0,0};
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 1, 8, 2, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 21://альфа
                    lrc = new int[] { 4, 4, 4, 4, 5 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 5,2,1,8,7,1,0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 2, 3, 2, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 1, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 22://фр ренесанс
                    lrc = new int[] { 6,9,9,9,10 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 2, 0, 8, 0, 1, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 1,2,2,8,14,3,0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 4, 2, 3, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 7, 0, 0, 1 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 5, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 23://франция
                    lrc = new int[] { 4,4,5,5,6 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 2, 0, 8, 0, 1, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 3,2,5,27,19,4,2};
                    dynamicTyres = dyT;
                    stT = new int[] { 3,4,4,2,3,0,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 1, 8, 0, 0, 1 };
                    allseasonTyres = asT;
                    orT = new int[] { 1, 0, 0, 5, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 24://всесезон
                    lrc = new int[] { 9, 9, 9, 10, 11 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] {0,4,13,130,53,16,4 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 25://форд
                    lrc = new int[] { 5,5,5,6,7 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 2,1,0,12,14,2,2 };
                    dynamicTyres = dyT;
                    stT = new int[] { 2,2,1,4,0,0,0 };
                    standartTyres = stT;
                    asT = new int[] { 0,1,1,5,0,0,0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0,0,3,0,2,1,0};
                    offroadTyres = orT;
                    break;

                case 26://БМВ
                    lrc = new int[] { 4, 5, 6, 6, 8 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 2,1,3,9,23,12,0 };
                    dynamicTyres = dyT;
                    stT = new int[] {2,2,9,16,9,4,0};
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 6, 1, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 27://италия
                    lrc = new int[] { 3, 3, 3, 3, 4 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 1, 2, 1, 1 };
                    slikTyres = slT;
                    dyT = new int[] {10,6,18,28,33,5,6};
                    dynamicTyres = dyT;
                    stT = new int[] {2,2,8,4,2,0,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 1, 1, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 1, 1, 7, 4, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 28://5мест
                    lrc = new int[] { 3, 3, 4, 4, 4 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 5,10,21,87,87,31,1};
                    dynamicTyres = dyT;
                    stT = new int[] { 21,19,32,80,34,8,0 };
                    standartTyres = stT;
                    asT = new int[] { 0,4,11,110,45,16,3 };
                    allseasonTyres = asT;
                    orT = new int[] { 0,2,8,3,6,1,0};
                    offroadTyres = orT;
                    break;

                case 29://мазда
                    lrc = new int[] { 7,9,10,10,13 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 1, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0,1,3,10,5,0,0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0,3,1,0,3,0,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 30://Сша
                    lrc = new int[] { 3, 3, 4, 4, 4 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 5, 8, 20, 23, 29, 19, 5 };
                    dynamicTyres = dyT;
                    stT = new int[] { 6, 7, 7, 21, 5, 3, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 3, 13, 13, 5, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 2, 1, 5, 6, 1, 0 };
                    offroadTyres = orT;
                    break;

                case 31://5мест
                    lrc = new int[] { 3, 3, 4, 4, 4 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 5, 10, 21, 87, 87, 31, 1 };
                    dynamicTyres = dyT;
                    stT = new int[] { 21, 19, 32, 80, 34, 8, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 4, 11, 110, 45, 16, 3 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 2, 8, 3, 6, 1, 0 };
                    offroadTyres = orT;
                    break;

                case 32://германия
                    lrc = new int[] { 3, 3, 3, 3, 3 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 2, 1, 4 };
                    slikTyres = slT;
                    dyT = new int[] { 3,6,13,61,58, 46,7 };
                    dynamicTyres = dyT;
                    stT = new int[] { 15,7,15,43,16,7,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 18, 13, 3, 2 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 1, 2, 0, 4, 0, 1 };
                    offroadTyres = orT;
                    break;

                case 33://американская мечта
                    lrc = new int[] { 3, 3, 4, 4, 4 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 5,5,16,14,21,9,2};
                    dynamicTyres = dyT;
                    stT = new int[] { 5,4,5,13,0,2,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 1, 8, 5, 2, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 1, 3, 5, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 34://додж
                    lrc = new int[] { 4, 9, 12, 12, 13 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 3, 2, 9, 2, 1 };
                    dynamicTyres = dyT;
                    stT = new int[] { 1, 1, 2, 1, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 2, 1, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 35://задний привод
                    lrc = new int[] { 3, 3, 3, 3, 3 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 2, 0, 3, 1, 3, 4 };
                    slikTyres = slT;
                    dyT = new int[] { 24, 21, 52, 115, 130, 74, 19 };
                    dynamicTyres = dyT;
                    stT = new int[] { 20, 12, 19, 29, 32, 5, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 2, 1, 1, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 1, 3, 6, 11, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 36://суперская 3
                    lrc = new int[] { 3, 3, 3, 3, 3 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 2, 0, 11, 4, 4, 5 };
                    slikTyres = slT;
                    dyT = new int[] { 32, 33, 72, 235, 220, 112, 30 };
                    dynamicTyres = dyT;
                    stT = new int[] { 43, 39, 47, 105, 44, 12, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 4, 13, 130, 53, 16, 4 };
                    allseasonTyres = asT;
                    orT = new int[] { 2, 5, 9, 30, 18, 1, 1 };
                    offroadTyres = orT;
                    break;

                case 37://1980
                    lrc = new int[] { 3, 3, 3, 3, 4 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 3, 0, 0, 1 };
                    slikTyres = slT;
                    dyT = new int[] { 6,11,12,22,18,1,1 };
                    dynamicTyres = dyT;
                    stT = new int[] { 10,2,10,8,0,0,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 1, 1, 0, 0, 0, 1 };
                    allseasonTyres = asT;
                    orT = new int[] { 1, 1, 1, 2, 8, 0, 1 };
                    offroadTyres = orT;
                    break;

                case 38://порше
                    lrc = new int[] { 10,11,14,14,15 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 1, 4 };
                    slikTyres = slT;
                    dyT = new int[] { 0,0,3,10,16,11,4 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 1, 0, 5, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 1, 2 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 3, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 39://опель
                    lrc = new int[] { 5, 6, 8, 8, 10 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 1,2,5,11,6,1,0 };
                    dynamicTyres = dyT;
                    stT = new int[] {1,1,2,1,0,0,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 1, 0, 1, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 1, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 40://суперская
                    lrc = new int[] { 15,15,15,15,15 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 11, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 234, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 103, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 130, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 30, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 41://2места
                    lrc = new int[] { 3, 3, 3, 4, 4 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 2, 2, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 13,11,26,90,89,46,25 };
                    dynamicTyres = dyT;
                    stT = new int[] { 9,15,7,4,3,2,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 1, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 25, 12, 0, 1 };
                    offroadTyres = orT;
                    break;

                case 42://2000 4х4
                    lrc = new int[] { 9, 13, 14, 14, 15 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 1, 4, 14, 3 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 7, 5, 1, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0,1,3,26,21,1,0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 2, 1, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 43://седаны
                    lrc = new int[] { 3, 4, 4, 4, 4 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 3, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 2,3,8,26,42,19,2};
                    dynamicTyres = dyT;
                    stT = new int[] { 11,4,17,44,28,9,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 3, 2, 2, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 44://хэтчи
                    lrc = new int[] { 3, 3, 4, 4, 5 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 5, 2, 1, 0 };
                    slikTyres = slT;
                    dyT = new int[] {4,8,7,53,39,4,0};
                    dynamicTyres = dyT;
                    stT = new int[] { 10,9,8,6,0,0,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 18, 1, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 45://эко
                    lrc = new int[] { 5, 6, 9, 9, 9 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 2, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 0, 1, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 2,2,3,3,2, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 4, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 46://италия ренесанс
                    lrc = new int[] { 3, 3, 3, 3, 4 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 1, 2, 1, 1 };
                    slikTyres = slT;
                    dyT = new int[] { 10,4,17,15,24,4,5 };
                    dynamicTyres = dyT;
                    stT = new int[] { 1,0,3,2,2,0,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 1, 1, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 1, 1, 5, 4, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 47://кадиллак
                    lrc = new int[] { 5, 6, 11, 15, 15 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 1, 1, 3, 1 };
                    dynamicTyres = dyT;
                    stT = new int[] { 2,0,1,7,5,1,0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 4, 2, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 48://ситроен
                    lrc = new int[] { 4,4,5,6,6 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 2,0,1,3, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 2, 0, 2, 0, 2, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 1, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;
            }

            minrq = 0;
            for (int i = 0; i < 5; i++)
            {
                minrq += lowestRqCars[i];
            }
            MaxRq();
        }
    }
}