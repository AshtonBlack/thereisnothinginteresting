﻿using System;
using System.Collections.Generic;
using System.IO;

namespace WindowsFormsApp1 //universal
{
    static class CarsDB
    {
        static string commonpath = @"C:\Bot\NewPL\";
        static string cashcarspath = @"C:\Bot\NewPL\CashCars.txt";
        public static string[,] fulltablearray { get; set; }
        public static int linenumber { get; set; }        

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

        public static void MakeCondAuto(string firstCond, string secondCond)
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
                if (SatisfyCondition(firstCond, j))
                {
                    if (SatisfyCondition(secondCond, j))
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

        public static bool SatisfyCondition(string cond, int car)
        {
            bool x = false;
            int year;
            string tag;
            string bodytype;
            switch (cond)
            {
                case "empty":
                    x = true;
                    break;
                case "задний привод":
                    if (fulltablearray[car, 5] == "rwd")
                    {
                        x = true;
                    }
                    break;
                case "передний привод":
                    if (fulltablearray[car, 5] == "fwd")
                    {
                        x = true;
                    }
                    break;
                case "обычная х3":
                    x = true;
                    break;
                case "audi":
                    if (fulltablearray[car, 8] == "Audi")
                    {
                        x = true;
                    }
                    break;
                case "бензиновые машины":
                    if (fulltablearray[car, 6] == "petrol")
                    {
                        x = true;
                    }
                    break;
                case "необычная":
                    if (fulltablearray[car, 2] == "e")
                    {
                        x = true;
                    }
                    break;
                case "машины японии":
                    if (fulltablearray[car, 4] == "Japan")
                    {
                        x = true;
                    }
                    break;
                case "jaguar":
                    if (fulltablearray[car, 8] == "Jaguar")
                    {
                        x = true;
                    }
                    break;
                case "машины сша":
                    if (fulltablearray[car, 4] == "United States")
                    {
                        x = true;
                    }
                    break;
                case "редкостная":
                    if (fulltablearray[car, 2] == "d")
                    {
                        x = true;
                    }
                    break;
                case "экстремальная":
                    if (fulltablearray[car, 2] == "b")
                    {
                        x = true;
                    }
                    break;
                case "standard tires":
                    if (fulltablearray[car, 13] == "std")
                    {
                        x = true;
                    }
                    break;
                case "пикапы":
                    bodytype = "pickup";
                    x = SearchBody(car, bodytype);
                    break;
                case "mercedes-benz":
                    if (fulltablearray[car, 8] == "Mercedes-Benz")
                    {
                        x = true;
                    }
                    break;
                case "renault":
                    if (fulltablearray[car, 8] == "Renault")
                    {
                        x = true;
                    }
                    break;
                case "полный привод":
                    if (fulltablearray[car, 5] == "4wd")
                    {
                        x = true;
                    }
                    break;
                case "машины англии":
                    if (fulltablearray[car, 4] == "United Kingdom")
                    {
                        x = true;
                    }
                    break;
                case "chrysler":
                    if (fulltablearray[car, 8] == "Chrysler")
                    {
                        x = true;
                    }
                    break;
                case "chrysler x3":
                    if (fulltablearray[car, 8] == "Chrysler")
                    {
                        x = true;
                    }
                    break;
                case "peugeot":
                    if (fulltablearray[car, 8] == "Peugeot")
                    {
                        x = true;
                    }
                    break;
                case "honda":
                    if (fulltablearray[car, 8] == "Honda")
                    {
                        x = true;
                    }
                    break;
                case "alfa romeo":
                    if (fulltablearray[car, 8] == "Alfa Romeo")
                    {
                        x = true;
                    }
                    break;
                case "французский ренессанс":
                    tag = "French Renaissance";
                    x = SearchTag(car, tag);
                    break;
                case "машины франции":
                    if (fulltablearray[car, 4] == "France")
                    {
                        x = true;
                    }
                    break;
                case "all-surface tyres":
                    if (fulltablearray[car, 13] == "all")
                    {
                        x = true;
                    }
                    break;
                case "ford":
                    if (fulltablearray[car, 8] == "Ford")
                    {
                        x = true;
                    }
                    break;
                case "bmw":
                    if (fulltablearray[car, 8] == "BMW")
                    {
                        x = true;
                    }
                    break;
                case "машины италии":
                    if (fulltablearray[car, 4] == "Italy")
                    {
                        x = true;
                    }
                    break;
                case "5-местные":
                    if (fulltablearray[car, 11] == "5")
                    {
                        x = true;
                    }
                    break;
                case "mazda":
                    if (fulltablearray[car, 8] == "Mazda")
                    {
                        x = true;
                    }
                    break;
                case "машины германии":
                    if (fulltablearray[car, 4] == "Germany")
                    {
                        x = true;
                    }
                    break;
                case "американская мечта":
                    tag = "American Dream";
                    x = (SearchTag(car, tag));
                    break;
                case "dodge":
                    if (fulltablearray[car, 8] == "Dodge")
                    {
                        x = true;
                    }
                    break;
                case "суперская":
                    if (fulltablearray[car, 2] == "c")
                    {
                        x = true;
                    }
                    break;
                case "машины 1980":
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (year > 1979 && year < 1990)
                    {
                        x = true;
                    }
                    break;
                case "porsche":
                    if (fulltablearray[car, 8] == "Porsche")
                    {
                        x = true;
                    }
                    break;
                case "opel":
                    if (fulltablearray[car, 8] == "Vauxhall")
                    {
                        x = true;
                    }
                    break;
                case "2-местные":
                    if (fulltablearray[car, 11] == "2")
                    {
                        x = true;
                    }
                    break;
                case "2000s 4wd":
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (fulltablearray[car, 5] == "4wd" && (year > 1999 && year < 2010))
                    {
                        x = true;
                    }
                    break;
                case "седаны":
                    bodytype = "saloon";
                    x = SearchBody(car, bodytype);
                    break;
                case "горячий хэтчбек":
                    tag = "Hot Hatch";
                    x = SearchTag(car, tag); 
                    break;
                case "экологичная":
                    tag = "Eco Friendly";
                    x = (SearchTag(car, tag));
                    break;
                case "italian renaissance":
                    tag = "Italian Renaissance";
                    x = (SearchTag(car, tag));
                    break;
                case "cadillac":
                    if (fulltablearray[car, 8] == "Cadillac")
                    {
                        x = true;
                    }
                    break;
                case "citroen":
                    if (fulltablearray[car, 8] == "Citroen")
                    {
                        x = true;
                    }
                    break;
                case "pre-1970":
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (year < 1970)
                    {
                        x = true;
                    }
                    break;
                case "pontiac":
                    if (fulltablearray[car, 8] == "Pontiac")
                    {
                        x = true;
                    }
                    break;
                case "1975-1984":
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (year > 1974 && year < 1985)
                    {
                        x = true;
                    }
                    break;
                case "немецкое возрождение":
                    tag = "German Renaissance";
                    x = (SearchTag(car, tag));
                    break;
                case "fiat":
                    if (fulltablearray[car, 8] == "Fiat")
                    {
                        x = true;
                    }
                    break;
                case "nissan":
                    if (fulltablearray[car, 8] == "Nissan")
                    {
                        x = true;
                    }
                    break;
                case "chevrolet":
                    if (fulltablearray[car, 8] == "Chevrolet")
                    {
                        x = true;
                    }
                    break;
                case "2000-2004":
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (year > 1999 && year < 2005)
                    {
                        x = true;
                    }
                    break;
                case "икона стиля":
                    tag = "Style Icon";
                    x = (SearchTag(car, tag));
                    break;
                case "2005-2009":
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (year > 2004 && year < 2010)
                    {
                        x = true;
                    }
                    break;
                case "1985-1994":
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (year > 1984 && year < 1995)
                    {
                        x = true;
                    }
                    break;
                case "subaru":
                    if (fulltablearray[car, 8] == "Subaru")
                    {
                        x = true;
                    }
                    break;
                case "автоспорт":
                    tag = "Motorsport";
                    x = (SearchTag(car, tag));
                    break;
                case "отк.верх":
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
                case "машины 1990":
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (year > 1989 && year < 2000)
                    {
                        x = true;
                    }
                    break;
                case "2000 rwd":
                    if (fulltablearray[car, 5] == "rwd")
                    {
                        year = Convert.ToInt32(fulltablearray[car, 15]);
                        if (year > 1999 && year < 2010)
                        {
                            x = true;
                        }
                    }
                    break;
                case "машины 1970":
                    year = Convert.ToInt32(fulltablearray[car, 15]);
                    if (year > 1969 && year < 1980)
                    {
                        x = true;
                    }
                    break;
                case "машины италии х3":
                    if (fulltablearray[car, 4] == "Italy")
                    {
                        x = true;
                    }
                    break;
                case "машины италии х2":
                    if (fulltablearray[car, 4] == "Italy")
                    {
                        x = true;
                    }
                    break;
                case "машины франции х3":
                    if (fulltablearray[car, 4] == "France")
                    {
                        x = true;
                    }
                    break;
                case "машины англии х3":
                    if (fulltablearray[car, 4] == "United Kingdom")
                    {
                        x = true;
                    }
                    break;
                case "машины англии х2":
                    if (fulltablearray[car, 4] == "United Kingdom")
                    {
                        x = true;
                    }
                    break;
                case "машины японии х2":
                    if (fulltablearray[car, 4] == "Japan")
                    {
                        x = true;
                    }
                    break;
                case "машины германии х2":
                    if (fulltablearray[car, 4] == "Germany")
                    {
                        x = true;
                    }
                    break;
                case "машины сша х2":
                    if (fulltablearray[car, 4] == "United States")
                    {
                        x = true;
                    }
                    break;
                case "ford x3":
                    if (fulltablearray[car, 8] == "Ford")
                    {
                        x = true;
                    }
                    break;
                case "opel x3":
                    if (fulltablearray[car, 8] == "Vauxhall")
                    {
                        x = true;
                    }
                    break;
                default:
                    NotePad.DoErrorLog("don't know condition: " + cond);
                    x = false;
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