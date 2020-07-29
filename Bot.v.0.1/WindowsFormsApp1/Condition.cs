using System.Drawing;
using System.Threading;

namespace WindowsFormsApp1
{
    static class Condition
    {
        public static int accountLVL = 360;
        public static bool[] tires { get; set; }
        public static int minrq { get; set; }
        public static int maxrq { get; set; }
        public static int maxclass { get; set; }
        public static int actualRQ { get; set; }

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
        
        static int[] rqCost = { 19, 29, 39, 49, 64, 79, 100 };

        static Condition() { }

        public static int AvailableCars(char litClass)
        {
            int carClass;
            switch (litClass)
            {
                case 'e':
                    carClass = 1;
                    break;
                case 'd':
                    carClass = 2;
                    break;
                case 'c':
                    carClass = 3;
                    break;
                case 'b':
                    carClass = 4;
                    break;
                case 'a':
                    carClass = 5;
                    break;
                case 's':
                    carClass = 6;
                    break;
                default:
                    carClass = 0;
                    break;
            }
            int number = 0;

            int[] overNumber = { slikTyres[carClass],
                                 dynamicTyres[carClass],
                                 standartTyres[carClass],
                                 allseasonTyres[carClass],
                                 offroadTyres[carClass] };
            for(int i = 0; i < 5; i++)
            {
                if (tires[i])
                {
                    number += overNumber[i];
                }
            }

            NotePad.DoLog("По условию доступны " + number + " машин " + litClass + " класса");

            if (number > 4)
            {   
                if(number % 2 == 0)
                {
                    number -= 2;
                    NotePad.DoLog("недостигаемы 2 машины");
                }
                else
                {
                    number -= 1;
                    NotePad.DoLog("недостигаема 1 машина");
                }
                NotePad.DoLog("Остается доступно " + number + " машин " + litClass + " класса");
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
            for(int i = 0; i < lowestRqCars.Length; i++)
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
                minrq += (slikTyres[i] + dynamicTyres[i] - overcars) * rqCost[i];
                if(carnumber > 4)
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
                case 3: //обычная х3
                case 0: // без условий
                    lrc = new int[] { 10, 13, 13, 14, 14 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 1, 0, 1, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 8, 9, 13, 32, 20, 5, 1 };
                    dynamicTyres = dyT;
                    stT = new int[] { 7, 11, 9, 14, 1, 1, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 1, 2, 6, 3, 1, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 2, 1, 5, 1, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 35://задний привод
                case 1: // задний привод
                    lrc = new int[] { 10, 13, 13, 14, 14 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 1, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 8, 4, 9, 17, 17, 4, 1 };
                    dynamicTyres = dyT;
                    stT = new int[] { 5, 6, 4, 2, 1, 1, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 1, 1, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 50://передний привод
                case 2: // передний привод
                    lrc = new int[] { 18, 19, 22, 23, 23 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 5, 3, 13, 1, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 2, 5, 4, 3, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 1, 1, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 2, 1, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 4: // Audi
                    lrc = new int[] { 100, 100, 100, 100, 100 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 5: // бензиновые
                    lrc = new int[] { 10, 13, 13, 14, 14 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 8, 9, 13, 32, 20, 5, 1 };
                    dynamicTyres = dyT;
                    stT = new int[] { 7, 9, 7, 7, 0, 1, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 3, 2, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 1, 1, 5, 1, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 6: // необычная 5
                    lrc = new int[] { 21, 21, 21, 22, 22 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 1, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 9, 0, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 11, 0, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 1, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 2, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 7: // япония
                    lrc = new int[] { 19, 21, 27, 29, 30 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 1, 4, 1, 1, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 1, 3, 3, 3, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 1, 1, 1, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 2, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 8: // яга
                    lrc = new int[] { 17, 17, 17, 17, 40 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 1, 1, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 4, 0, 0, 1, 1, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 30://Сша
                case 9: // Сша
                    lrc = new int[] { 21, 22, 28, 28, 29 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 1, 3, 4, 0, 1, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 3, 2, 2, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 1, 1, 1, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 1, 0, 2, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 10: // редкостная
                    lrc = new int[] { 30, 30, 30, 31, 34 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 13, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 9, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 2, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 1, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 11: // экстремальная
                    lrc = new int[] { 50, 50, 50, 50, 51 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 0, 20, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 0, 1, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 3, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 1, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 55://стандартные шины
                case 12: // стандартные шины
                    lrc = new int[] { 15, 17, 17, 17, 17 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 7, 11, 9, 14, 1, 1, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 56://пикапы
                case 13: // пикапы
                    lrc = new int[] { 100, 100, 100, 100, 100 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 14: // мерсы
                    lrc = new int[] { 21, 36, 50, 50, 57 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 0, 3, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 1, 0, 0, 0, 1, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 1, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 15: // рено
                    lrc = new int[] { 28, 29, 30, 40, 41 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 1, 0, 1, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 1, 2, 1, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 1, 0, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 16: // 4х4
                    lrc = new int[] { 22, 28, 29, 30, 35 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 1, 2, 2, 1, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 1, 9, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 1, 1, 4, 2, 1, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 2, 1, 2, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 54://англия
                case 17: // англия
                    lrc = new int[] { 13, 14, 14, 15, 16 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 5, 1, 3, 7, 5, 0, 1 };
                    dynamicTyres = dyT;
                    stT = new int[] { 6, 0, 0, 3, 1, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 1, 0, 2, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 1, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 18: // крайслер
                    lrc = new int[] { 100, 100, 100, 100, 100 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 1, 0, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 19: // пежо
                    lrc = new int[] { 100, 100, 100, 100, 100 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 2, 1, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 20: // хонда
                    lrc = new int[] { 34, 41, 44, 46, 46 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 3, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 1, 1, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 21: // альфа
                    lrc = new int[] { 100, 100, 100, 100, 100 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 2, 1, 0, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 1, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 22: // фр ренесанc
                    lrc = new int[] { 25, 28, 29, 30, 30 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 1, 0, 1, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 2, 2, 2, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 49://франция
                case 23: // франция
                    lrc = new int[] { 23, 25, 28, 28, 29 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 1, 0, 1, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 2, 2, 3, 1, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 2, 0, 1, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 24: // всесезон
                    lrc = new int[] { 28, 37, 37, 41, 45 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 1, 2, 6, 3, 1, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 25: // форд
                    lrc = new int[] { 19, 45, 48, 48, 54 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 1, 0, 0, 1, 1, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 26: // БМВ
                    lrc = new int[] { 16, 36, 39, 47, 48 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 1, 0, 0, 1, 4, 2, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 2, 1, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 1, 1, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 27: // италия
                    lrc = new int[] { 10, 13, 22, 23, 23 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 2, 4, 0, 6, 3, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 1, 2, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 31://5мест
                case 28: // 5мест
                    lrc = new int[] { 14, 19, 19, 22, 23 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 2, 4, 4, 9, 5, 1, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 1, 5, 6, 9, 1, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 1, 2, 3, 3, 1, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 2, 1, 2, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 29: // мазда
                    lrc = new int[] { 100, 100, 100, 100, 100 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 1, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 3, 0, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 32: // германия
                    lrc = new int[] { 16, 21, 28, 28, 31 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 1, 1, 4, 7, 10, 3, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 2, 2, 4, 0, 1, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 2, 1, 1, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 1, 0, 1, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 33: // американская мечта
                    lrc = new int[] { 21, 28, 36, 36, 38 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 2, 2, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 2, 1, 2, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 2, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 34: // додж
                    lrc = new int[] { 100, 100, 100, 100, 100 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 1, 1, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 36: // суперская 3
                    lrc = new int[] { 10, 13, 13, 14, 14 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 1, 0, 1, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 8, 9, 13, 32, 20, 5, 1 };
                    dynamicTyres = dyT;
                    stT = new int[] { 7, 11, 9, 14, 1, 1, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 1, 2, 6, 3, 1, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 2, 1, 5, 1, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 37: // 1980
                    lrc = new int[] { 22, 23, 25, 28, 28 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 3, 4, 7, 1, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 2, 2, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 1, 0, 1, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 38: // порше
                    lrc = new int[] { 28, 38, 41, 46, 53 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 1, 1, 3, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 1, 0, 1, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 39: // опель
                    lrc = new int[] { 31, 34, 38, 43, 44 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 3, 1, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 1, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 40: // суперская
                    lrc = new int[] { 40, 40, 40, 41, 41 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 32, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 14, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 6, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 5, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 41: // 2места
                    lrc = new int[] { 10, 13, 14, 15, 16 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 5, 3, 6, 15, 6, 0, 1 };
                    dynamicTyres = dyT;
                    stT = new int[] { 6, 4, 2, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 3, 1, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 42: // 2000 4х4
                    lrc = new int[] { 100, 100, 100, 100, 100 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 1, 1, 1, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 43: // седаны
                    lrc = new int[] { 14, 19, 28, 34, 34 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 2, 0, 0, 2, 2, 1, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 1, 4, 4, 1, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 44: // хэтчи
                    lrc = new int[] { 18, 19, 23, 23, 23 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 4, 3, 7, 2, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 2, 3, 2, 2, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 2, 1, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 45: // эко
                    lrc = new int[] { 29, 29, 34, 36, 45 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 1, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 1, 2, 1, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 1, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 46: // италия ренесанс
                    lrc = new int[] { 10, 13, 26, 28, 41 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 2, 2, 0, 4, 3, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 47: // кадиллак
                    lrc = new int[] { 100, 100, 100, 100, 100 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 1, 1, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 48: // ситроен
                    lrc = new int[] { 100, 100, 100, 100, 100 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 51: // pre 1970
                    lrc = new int[] { 10, 13, 13, 14, 14 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 7, 4, 2, 1, 1, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 5, 2, 1, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 52: // pontiac
                    lrc = new int[] { 100, 100, 100, 100, 100 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 1, 1, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 1, 0, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 53: // 75-84
                    lrc = new int[] { 22, 23, 23, 25, 27 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 3, 2, 3, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 3, 1, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 1, 0, 1, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 57: // немецкое возрождение
                    lrc = new int[] { 16, 28, 35, 36, 41 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 1, 1, 1, 2, 3, 3, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 0, 1, 3, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 2, 0, 1, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

                case 58: // Fiat
                    lrc = new int[] { 100, 100, 100, 100, 100 };
                    lowestRqCars = lrc;
                    slT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    slikTyres = slT;
                    dyT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    dynamicTyres = dyT;
                    stT = new int[] { 0, 1, 1, 0, 0, 0, 0 };
                    standartTyres = stT;
                    asT = new int[] { 0, 0, 0, 0, 0, 0, 0 };
                    allseasonTyres = asT;
                    orT = new int[] { 0, 0, 0, 1, 0, 0, 0 };
                    offroadTyres = orT;
                    break;

            }

            minrq = 0;
            for (int i = 0; i < 5; i++)
            {
                minrq += lowestRqCars[i];
            }
            MaxRq();
            NotePad.DoLog("Условия сформированы");
        }
    }
}