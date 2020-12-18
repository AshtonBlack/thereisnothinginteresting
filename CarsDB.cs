using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApp1
{
    static class CarsDB
    {
        static string commonpath = @"C:\Bot\NewRqPL12\";
        static string cashcarspath = @"C:\Bot\NewRqPL12\CashCarsPL12.txt";
        public static string[,] fulltablearray { get; set; }
        static int linenumber { get; set; }        

        public static int[] lowestcars;
        public static int[] slikTyres { get; set; }
        public static int[] dynamicTyres { get; set; }
        public static int[] standartTyres { get; set; }
        public static int[] allseasonTyres { get; set; }
        public static int[] offroadTyres { get; set; }

        static CarsDB()
        {
            Fulltable();
        }

        public static void Fulltable()//формирование таблицы из исходных файлов
        {            
            linenumber = 0;
            using (StreamReader sr = new StreamReader(commonpath + "manufacturer.txt", System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null && line != " " && line != "")
                {
                    linenumber++;
                }
                sr.Close();
            }
            fulltablearray = new string[linenumber, 18];

            string[] SR(string path)
            {
                string[] a = new string[linenumber];
                using (StreamReader sr = new StreamReader(commonpath + path + ".txt", System.Text.Encoding.Default))
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        a[i] = sr.ReadLine();
                    }
                    sr.Close();
                }
                return a;
            } //считывание статов из файлов
            string[] cashSR()
            {
                string[] a = new string[linenumber];
                if (File.Exists(cashcarspath))
                {
                    using (StreamReader sr = new StreamReader(cashcarspath, System.Text.Encoding.Default))
                    {
                        for (int i = 0; i < a.Length; i++)
                        {
                            a[i] = sr.ReadLine();
                        }
                        sr.Close();
                    }
                }
                else
                {
                    for (int i = 0; i < a.Length; i++)
                    {
                        a[i] = "0";
                    }
                }
                return a;
            } //удалить после обновы наличие автомобилей, переписать файл с нуля

            string[] acc = SR("acceleration");
            string[] body = SR("body");
            string[] grade = SR("class");
            string[] clearance = SR("clearance");
            string[] country = SR("country");
            string[] drive = SR("drive");
            string[] fuel = SR("fuel");
            string[] grip = SR("grip");
            string[] manufacturer = SR("manufacturer");
            string[] model = SR("model");
            string[] rq = SR("rq");
            string[] seats = SR("seats");
            string[] speed = SR("speed");
            string[] tires = SR("tires");
            string[] weight = SR("weight");
            string[] year = SR("year");
            string[] cash = cashSR();
            string[] tags = SR("tags");

            for (int i = 0; i < linenumber; i++)
            {
                fulltablearray[i, 0] = acc[i];
                fulltablearray[i, 1] = body[i];
                fulltablearray[i, 2] = grade[i];
                fulltablearray[i, 3] = clearance[i];
                fulltablearray[i, 4] = country[i];
                fulltablearray[i, 5] = drive[i];
                fulltablearray[i, 6] = fuel[i];
                fulltablearray[i, 7] = grip[i];
                fulltablearray[i, 8] = manufacturer[i];
                fulltablearray[i, 9] = model[i];
                fulltablearray[i, 10] = rq[i];
                fulltablearray[i, 11] = seats[i];
                fulltablearray[i, 12] = speed[i];
                fulltablearray[i, 13] = tires[i];
                fulltablearray[i, 14] = weight[i];
                fulltablearray[i, 15] = year[i];
                fulltablearray[i, 16] = cash[i];
                fulltablearray[i, 17] = tags[i];
            }
        }

        public static void MakeCondAuto(int i)
        {
            List<int> rq;            
            string grade;
            string t;
            int n;

            slikTyres = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            dynamicTyres = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            standartTyres = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            allseasonTyres = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            offroadTyres = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            lowestcars = new int[5];
            rq = new List<int>(0);
            for (int j = 1; j < linenumber; j++)
            {
                if (SatisfyTheCondition(i, j))
                {
                    grade = fulltablearray[j, 2];
                    t = fulltablearray[j, 13];
                    n = Convert.ToInt32(fulltablearray[j, 16]);
                    int y;
                    switch (grade)
                    {
                        case "e":
                            y = 1;
                            break;
                        case "d":
                            y = 2;
                            break;
                        case "c":
                            y = 3;
                            break;
                        case "b":
                            y = 4;
                            break;
                        case "a":
                            y = 5;
                            break;
                        case "s":
                            y = 6;
                            break;
                        default:
                            y = 0;
                            break;
                    }
                    switch (t)
                    {
                        case "per":
                            dynamicTyres[y] += n;
                            break;
                        case "std":
                            standartTyres[y] += n;
                            break;
                        case "all":
                            allseasonTyres[y] += n;
                            break;
                        case "off":
                            offroadTyres[y] += n;
                            break;
                        default:
                            slikTyres[y] += n;
                            break;
                    }
                    for (int k = 0; k < n; k++)
                    {
                        rq.Add(Convert.ToInt32(fulltablearray[j, 10]));
                    }
                }
            }
            if (rq.Count > 4)
            {
                rq.Sort();
                for (int k = 0; k < lowestcars.Length; k++)
                {
                    lowestcars[k] = rq[k];
                }
            }          
        }

        public static bool SatisfyTheCondition(int n, int car)
        {
            bool x = false;
            int year;
            string tag;
            string bodytype;
            switch (n)
            {
                case 0:
                    x = true;
                    break;
                case 1:
                    if (fulltablearray[car, 5] == "rwd")
                    {
                        x = true;
                    }
                    break;
                case 2:
                    if (fulltablearray[car, 5] == "fwd")
                    {
                        x = true;
                    }
                    break;
                case 3:
                    x = true;
                    break;
                case 4:
                    if (fulltablearray[car, 8] == "Audi")
                    {
                        x = true;
                    }
                    break;
                case 5:
                    if (fulltablearray[car, 6] == "petrol")
                    {
                        x = true;
                    }
                    break;
                case 6:
                    if (fulltablearray[car, 2] == "e")
                    {
                        x = true;
                    }
                    break;
                case 7:
                    if (fulltablearray[car, 4] == "Japan")
                    {
                        x = true;
                    }
                    break;
                case 8:
                    if (fulltablearray[car, 8] == "Jaguar")
                    {
                        x = true;
                    }
                    break;
                case 9:
                    if (fulltablearray[car, 4] == "United States")
                    {
                        x = true;
                    }
                    break;
                case 10:
                    if (fulltablearray[car, 2] == "d")
                    {
                        x = true;
                    }
                    break;
                case 11:
                    if (fulltablearray[car, 2] == "b")
                    {
                        x = true;
                    }
                    break;
                case 12:
                    if (fulltablearray[car, 13] == "std")
                    {
                        x = true;
                    }
                    break;
                case 13:
                    bodytype = "pickup";
                    x = SearchBody(car, bodytype);
                    break;
                case 14:
                    if (fulltablearray[car, 8] == "Mercedes-Benz")
                    {
                        x = true;
                    }
                    break;
                case 15:
                    if (fulltablearray[car, 8] == "Renault")
                    {
                        x = true;
                    }
                    break;
                case 16:
                    if (fulltablearray[car, 5] == "4wd")
                    {
                        x = true;
                    }
                    break;
                case 17:
                    if (fulltablearray[car, 4] == "United Kingdom")
                    {
                        x = true;
                    }
                    break;
                case 18:
                    if (fulltablearray[car, 8] == "Chrysler")
                    {
                        x = true;
                    }
                    break;
                case 19:
                    if (fulltablearray[car, 8] == "Peugeot")
                    {
                        x = true;
                    }
                    break;
                case 20:
                    if (fulltablearray[car, 8] == "Honda")
                    {
                        x = true;
                    }
                    break;
                case 21:
                    if (fulltablearray[car, 8] == "Alfa Romeo")
                    {
                        x = true;
                    }
                    break;
                case 22:
                    tag = "French Renaissance";
                    x = SearchTag(car, tag);
                    break;
                case 23:
                    if (fulltablearray[car, 4] == "France")
                    {
                        x = true;
                    }
                    break;
                case 24:
                    if (fulltablearray[car, 13] == "all")
                    {
                        x = true;
                    }
                    break;
                case 25:
                    if (fulltablearray[car, 8] == "Ford")
                    {
                        x = true;
                    }
                    break;
                case 26:
                    if (fulltablearray[car, 8] == "BMW")
                    {
                        x = true;
                    }
                    break;
                case 27:
                    if (fulltablearray[car, 4] == "Italy")
                    {
                        x = true;
                    }
                    break;
                case 28:
                    if (fulltablearray[car, 11] == "5")
                    {
                        x = true;
                    }
                    break;
                case 29:
                    if (fulltablearray[car, 8] == "Mazda")
                    {
                        x = true;
                    }
                    break;
                case 30:
                    if (fulltablearray[car, 4] == "United States")
                    {
                        x = true;
                    }
                    break;
                case 31:
                    if (fulltablearray[car, 11] == "5")
                    {
                        x = true;
                    }
                    break;
                case 32:
                    if (fulltablearray[car, 4] == "Germany")
                    {
                        x = true;
                    }
                    break;
                case 33:
                    tag = "American Dream";
                    x = SearchTag(car, tag);
                    break;
                case 34:
                    if (fulltablearray[car, 8] == "Dodge")
                    {
                        x = true;
                    }
                    break;
                case 35:
                    if (fulltablearray[car, 5] == "rwd")
                    {
                        x = true;
                    }
                    break;
                case 36:
                    x = true;
                    break;
                case 37:
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (year > 1979 && year < 1990)
                    {
                        x = true;
                    }
                    break;
                case 38:
                    if (fulltablearray[car, 8] == "Porsche")
                    {
                        x = true;
                    }
                    break;
                case 39:
                    if (fulltablearray[car, 8] == "Vauxhall")
                    {
                        x = true;
                    }
                    break;
                case 40:
                    if (fulltablearray[car, 2] == "c")
                    {
                        x = true;
                    }
                    break;
                case 41:
                    if (fulltablearray[car, 11] == "2")
                    {
                        x = true;
                    }
                    break;
                case 42:
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (fulltablearray[car, 5] == "4wd" && (year > 1999 && year < 2010))
                    {
                        x = true;
                    }
                    break;
                case 43:
                    bodytype = "saloon";
                    x = SearchBody(car, bodytype);
                    break;
                case 44:
                    bodytype = "hatchback";
                    x = SearchBody(car, bodytype);
                    break;
                case 45:
                    tag = "Eco Friendly";
                    x = SearchTag(car, tag);
                    break;
                case 46:
                    tag = "Italian Renaissance";
                    x = SearchTag(car, tag);
                    break;
                case 47:
                    if (fulltablearray[car, 8] == "Cadillac")
                    {
                        x = true;
                    }
                    break;
                case 48:
                    if (fulltablearray[car, 8] == "Citroen")
                    {
                        x = true;
                    }
                    break;
                case 49:
                    if (fulltablearray[car, 4] == "France")
                    {
                        x = true;
                    }
                    break;
                case 50:
                    if (fulltablearray[car, 5] == "fwd")
                    {
                        x = true;
                    }
                    break;
                case 51:
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (year < 1970)
                    {
                        x = true;
                    }
                    break;
                case 52:
                    if (fulltablearray[car, 8] == "Pontiac")
                    {
                        x = true;
                    }
                    break;
                case 53:
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (year > 1974 && year < 1985)
                    {
                        x = true;
                    }
                    break;
                case 54:
                    if (fulltablearray[car, 4] == "United Kingdom")
                    {
                        x = true;
                    }
                    break;
                case 55:
                    if (fulltablearray[car, 13] == "std")
                    {
                        x = true;
                    }
                    break;
                case 56:
                    bodytype = "pickup";
                    x = SearchBody(car, bodytype);
                    break;
                case 57:
                    tag = "German Renaissance";
                    x = (SearchTag(car, tag));
                    break;
                case 58:
                    if (fulltablearray[car, 8] == "Fiat")
                    {
                        x = true;
                    }
                    break;
                case 59:
                    if (fulltablearray[car, 8] == "Nissan")
                    {
                        x = true;
                    }
                    break;
                case 60:
                    if (fulltablearray[car, 8] == "Chevrolet")
                    {
                        x = true;
                    }
                    break;
                case 61:
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (year > 1999 && year < 2005)
                    {
                        x = true;
                    }
                    break;
                case 62:
                    if (fulltablearray[car, 5] == "4wd")
                    {
                        x = true;
                    }
                    break;
                case 63:
                    tag = "Style Icon";
                    x = SearchTag(car, tag);
                    break;
                case 64:
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (year > 2004 && year < 2010)
                    {
                        x = true;
                    }
                    break;
                case 65:
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (year > 1984 && year < 1995)
                    {
                        x = true;
                    }
                    break;
                case 66:
                    if (fulltablearray[car, 8] == "Porsche")
                    {
                        x = true;
                    }
                    break;
                case 67:
                    if (fulltablearray[car, 8] == "Subaru")
                    {
                        x = true;
                    }
                    break;
                case 68:
                    if (fulltablearray[car, 11] == "2")
                    {
                        x = true;
                    }
                    break;
                case 69:
                    tag = "Motorsport";
                    x = SearchTag(car, tag);
                    break;
                case 70:
                    bool x1;
                    bool x2;
                    bodytype = "roadster";
                    x1 = SearchBody(car, bodytype);
                    bodytype = "cabrio";
                    x2 = SearchBody(car, bodytype);
                    if (x1 || x2)
                    {
                        x = true;
                    }
                    break;
                default:
                    break;
            }
            return x;
        }

        public static bool SearchTag(int car, string tag)
        {
            bool x = false;
            string cartags = fulltablearray[car, 17];
            for (int i = 0; i < ((cartags.Length - tag.Length) + 1); i++)
            {
                bool isthesame = true;
                for (int j = 0; j < tag.Length; j++)
                {
                    if (cartags[j + i] != tag[j])
                    {
                        isthesame = false;
                        break;
                    }
                }
                if (isthesame)
                {
                    x = true;
                    break;
                }
            }

            return x;
        }

        public static bool SearchBody(int car, string bodytype)
        {
            bool x = false;
            string cartags = fulltablearray[car, 1];
            for (int i = 0; i < ((cartags.Length - bodytype.Length) + 1); i++)
            {
                bool isthesame = true;
                for (int j = 0; j < bodytype.Length; j++)
                {
                    if (cartags[j + i] != bodytype[j])
                    {
                        isthesame = false;
                        break;
                    }
                }
                if (isthesame)
                {
                    x = true;
                    break;
                }
            }

            return x;
        }
    }
}