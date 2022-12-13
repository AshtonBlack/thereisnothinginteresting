using System;
using System.Collections.Generic;
using System.IO;

namespace Caitlyn_v1._0
{
    static class CarsDB
    {
        static string excelFilePath = @"C:\Bot\NewPL\cars.xlsx";
        static string cashCarsPath = @"C:\Bot\NewPL\CashCars.txt";
        public static List<CarForExcel> fulltablearray { get; set; }
        static CarsDB()
        {
            Fulltable();
        }        
        static void cashSR()
        {
            if (File.Exists(cashCarsPath))
            {
                using (StreamReader sr = new StreamReader(cashCarsPath, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null && line != " " && line != "")
                    {
                        string carname = NotePad.GetWordFromString(line, 2);
                        int amount = Convert.ToInt32(NotePad.GetWordFromString(line, 1));

                        foreach (CarForExcel car in fulltablearray)
                        {
                            if (car.fullname() == carname)
                            {
                                fulltablearray.Find(thecar => thecar.fullname() == carname).amount = amount;
                                break;
                            }
                        }
                    }
                    sr.Close();
                }
            }
        }
        public static void Fulltable()//формирование таблицы из исходных файлов
        {
            fulltablearray = ExcelParcer.Parse(excelFilePath);
            fulltablearray.RemoveAt(0);
            fulltablearray.Sort();
            fulltablearray.Reverse();
            cashSR();
        }
        public static void MakeCondAuto()
        {
            int carsAvailable = 0;
            Condition.selectedCars = new List<CarForExcel>();
            foreach (CarForExcel car in fulltablearray)
            {
                if (car.amount > 0 && SatisfyCondition(Condition.ConditionNumber1, car) && SatisfyCondition(Condition.ConditionNumber2, car))
                {
                    car.inUse = 0;
                    Condition.selectedCars.Add(car);
                    carsAvailable += car.amount;
                }
            }
            NotePad.DoLog("всего " + fulltablearray.Count + " машин");//debug
            NotePad.DoLog("всего " + Condition.selectedCars.Count + " подходящих машин");//debug
            NotePad.DoLog(carsAvailable + " подходящих машин в гараже");//debug
            DefineMinRQ();
        }//формирование списка машин под условие определенного события        
        static void DefineMinRQ()
        {
            Condition.minRQ = 0;
            if (Condition.selectedCars.Count < 5)
            {
                NotePad.DoLog("Слишком мало подходящих машин");
            }
            else
            {
                //NotePad.DoLog("Минимальные машины:");//debug
                int count = 0;
                for (int i = Condition.selectedCars.Count - 1; count < 5; i--)
                {
                    for (int j = Condition.selectedCars[i].amount; j > 0; j--)
                    {
                        //Condition.minRQ += Convert.ToInt32(Condition.selectedCars[i].rq);
                        Condition.minRQ += RoundRQAccordingToClass(Condition.selectedCars[i].rarity);
                        count++;
                        //NotePad.DoLog(Condition.selectedCars[i].fullname());//debug
                        if (count == 5)
                        {
                            break;
                        }                        
                    }
                }
                NotePad.DoLog("минимальное рк: " + Condition.minRQ);
            }            
        }
        public static int RoundRQAccordingToClass(string rarity)
        {
            switch (rarity)
            {
                case "s": return 100;
                case "a": return 79;
                case "b": return 64;
                case "c": return 49;
                case "d": return 39;
                case "e": return 29;
            }
            return 19;
        }
        public static List<CarForExcel> DefinePreferedCarPull(TrackInfo trackInfo)//формирование списка машин под условие определенного трэка
        {            
            List<(CarForExcel, int)> CarWithPoints = new List<(CarForExcel, int)>();
            NotePad.DoLogWithoutTime("подбираю машину для трэка: " + 
                trackInfo.track + " " + 
                trackInfo.ground + " " + 
                trackInfo.weather);
            Algorithms algorithm = new Algorithms();
            foreach (CarForExcel car in Condition.selectedCars)
            {
                int points = algorithm.CalculatePoints(car, trackInfo);
                CarWithPoints.Add((car, points));
            }

            int[] bestPointsForRQ = new int[101];
            for(int rq = 0; rq < bestPointsForRQ.Length; rq++)
            {
                bestPointsForRQ[rq] = -10000;
            }
            foreach ((CarForExcel car, int points) car in CarWithPoints)
            {
                if(car.points > bestPointsForRQ[Convert.ToInt16(car.car.rq)])
                {
                    bestPointsForRQ[Convert.ToInt16(car.car.rq)] = car.points;
                }
            }            

            int carCounter = 0;
            foreach ((CarForExcel car, int points) car in CarWithPoints)
            {
                if (bestPointsForRQ[Convert.ToInt16(car.car.rq)] == car.points)
                {
                    carCounter += car.car.amount;
                }
            }
            NotePad.DoLogWithoutTime("Prefered car amount: " + carCounter);//debug

            int deletedCars = 0;
            for (int rq = 100; rq > 0; rq--)
            {
                if (carCounter - deletedCars > 15)//минимальное количество машин
                {
                    if (bestPointsForRQ[rq] != -10000)//не учитывать отсутствующие
                    {
                        for(int lowerRQ = rq - 1; lowerRQ > 0; lowerRQ--)
                        {
                            if (bestPointsForRQ[rq] < bestPointsForRQ[lowerRQ])
                            {
                                bestPointsForRQ[rq] = -10000;
                                deletedCars++;
                                break;
                            }
                        }                        
                    }
                }
                else break;
            }

            int finalCarAmount = 0;
            //NotePad.DoLogWithoutTime("Prefered car list:");//debug
            List<CarForExcel> preferedCars = new List<CarForExcel>();
            foreach ((CarForExcel car, int points) car in CarWithPoints)
            {
                if (bestPointsForRQ[Convert.ToInt16(car.car.rq)] == car.points)
                {
                    preferedCars.Add(car.car);
                    finalCarAmount += car.car.amount;
                    //NotePad.DoLogWithoutTime(car.car.fullname() + " " + car.points);//debug
                }
            }
            NotePad.DoLogWithoutTime("The best cars amount: " + finalCarAmount);//debug

            return preferedCars;
        }        
        public static bool SatisfyCondition(string cond, CarForExcel car)
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
                    if (car.drive == "rwd")
                    {
                        x = true;
                    }
                    break;
                case "передний привод":
                    if (car.drive == "fwd")
                    {
                        x = true;
                    }
                    break;
                case "обычная х3":
                    x = true;
                    break;
                case "audi":
                    if (car.manufacturer == "Audi")
                    {
                        x = true;
                    }
                    break;
                case "audi x3":
                    if (car.manufacturer == "Audi")
                    {
                        x = true;
                    }
                    break;
                case "бензиновые машины":
                    if (car.fuel == "petrol")
                    {
                        x = true;
                    }
                    break;
                case "дизели":
                    if (car.fuel == "diesel")
                    {
                        x = true;
                    }
                    break;
                case "обычная":
                    if (car.rarity == "f")
                    {
                        x = true;
                    }
                    break;
                case "обычная х2":
                    if (car.rarity == "f")
                    {
                        x = true;
                    }
                    break;
                case "необычная":
                    if (car.rarity == "e")
                    {
                        x = true;
                    }
                    break;
                case "машины японии":
                    if (car.country == "Japan")
                    {
                        x = true;
                    }
                    break;
                case "машины японии х3":
                    if (car.country == "Japan")
                    {
                        x = true;
                    }
                    break;
                case "jaguar":
                    if (car.manufacturer == "Jaguar")
                    {
                        x = true;
                    }
                    break;
                case "jaguar x3":
                    if (car.manufacturer == "Jaguar")
                    {
                        x = true;
                    }
                    break;
                case "машины сша":
                    if (car.country == "United States")
                    {
                        x = true;
                    }
                    break;
                case "italian 60s-80s":
                    if (car.country == "Italy")
                    {
                        year = GetYear(car);
                        if (year > 1959 && year < 1990)
                        {
                            x = true;
                        }
                    }
                    break;
                case "редкостная":
                    if (car.rarity == "d")
                    {
                        x = true;
                    }
                    break;
                case "редкостная х2":
                    if (car.rarity == "d")
                    {
                        x = true;
                    }
                    break;
                case "экстремальная":
                    if (car.rarity == "b")
                    {
                        x = true;
                    }
                    break;
                case "standard tyres":
                case "standard tires":
                    if (car.tires == "std")
                    {
                        x = true;
                    }
                    break;
                case "пикапы":
                    bodytype = "pickup";
                    x = SearchBody(car, bodytype);
                    break;
                case "mercedes-benz":
                    if (car.manufacturer == "Mercedes-Benz")
                    {
                        x = true;
                    }
                    break;
                case "renault":
                    if (car.manufacturer == "Renault")
                    {
                        x = true;
                    }
                    break;
                case "renault x3":
                    if (car.manufacturer == "Renault")
                    {
                        x = true;
                    }
                    break;
                case "suzuki x3":
                    if (car.manufacturer == "Suzuki")
                    {
                        x = true;
                    }
                    break;
                case "nissan x3":
                    if (car.manufacturer == "Nissan")
                    {
                        x = true;
                    }
                    break;
                case "полный привод":
                    if (car.drive == "4wd")
                    {
                        x = true;
                    }
                    break;
                case "машины англии":
                    if (car.country == "United Kingdom")
                    {
                        x = true;
                    }
                    break;
                case "chrysler":
                    if (car.manufacturer == "Chrysler")
                    {
                        x = true;
                    }
                    break;
                case "chrysler x3":
                    if (car.manufacturer == "Chrysler")
                    {
                        x = true;
                    }
                    break;
                case "peugeot":
                    if (car.manufacturer == "Peugeot")
                    {
                        x = true;
                    }
                    break;
                case "peugeot x3":
                    if (car.manufacturer == "Peugeot")
                    {
                        x = true;
                    }
                    break;
                case "honda":
                    if (car.manufacturer == "Honda")
                    {
                        x = true;
                    }
                    break;
                case "honda x3":
                    if (car.manufacturer == "Honda")
                    {
                        x = true;
                    }
                    break;
                case "alfa romeo":
                    if (car.manufacturer == "Alfa Romeo")
                    {
                        x = true;
                    }
                    break;
                case "alfa romeo x3":
                    if (car.manufacturer == "Alfa Romeo")
                    {
                        x = true;
                    }
                    break;
                case "французский ренессанс":
                    tag = "French Renaissance";
                    x = SearchTag(car, tag);
                    break;
                case "машины франции":
                    if (car.country == "France")
                    {
                        x = true;
                    }
                    break;
                case "машины франции х2":
                    if (car.country == "France")
                    {
                        x = true;
                    }
                    break;
                case "all-surface tyres":
                    if (car.tires == "all")
                    {
                        x = true;
                    }
                    break;
                case "ford":
                    if (car.manufacturer == "Ford")
                    {
                        x = true;
                    }
                    break;
                case "bmw":
                    if (car.manufacturer == "BMW")
                    {
                        x = true;
                    }
                    break;
                case "bmw x3":
                    if (car.manufacturer == "BMW")
                    {
                        x = true;
                    }
                    break;
                case "машины италии":
                    if (car.country == "Italy")
                    {
                        x = true;
                    }
                    break;
                case "5-местные":
                    if (GetSeats(car) == 5)
                    {
                        x = true;
                    }
                    break;
                case "mazda":
                    if (car.manufacturer == "Mazda")
                    {
                        x = true;
                    }
                    break;
                case "машины германии":
                    if (car.country == "Germany")
                    {
                        x = true;
                    }
                    break;
                case "американская мечта":
                    tag = "American Dream";
                    x = (SearchTag(car, tag));
                    break;
                case "dodge":
                    if (car.manufacturer == "Dodge")
                    {
                        x = true;
                    }
                    break;
                case "dodge x3":
                    if (car.manufacturer == "Dodge")
                    {
                        x = true;
                    }
                    break;
                case "суперская":
                    if (car.rarity == "c")
                    {
                        x = true;
                    }
                    break;
                case "машины 1980":
                    year = GetYear(car);
                    if (year > 1979 && year < 1990)
                    {
                        x = true;
                    }
                    break;
                case "porsche x3":
                case "porsche":
                    if (car.manufacturer == "Porsche")
                    {
                        x = true;
                    }
                    break;
                case "mercedes-benz x3":
                    if (car.manufacturer == "Mercedes-Benz")
                    {
                        x = true;
                    }
                    break;
                case "opel":
                    if (car.manufacturer == "Vauxhall")
                    {
                        x = true;
                    }
                    break;
                case "2-местные":
                    if (GetSeats(car) == 2)
                    {
                        x = true;
                    }
                    break;
                case "2000s 4wd":
                    year = GetYear(car);
                    if (car.drive == "4wd" && (year > 1999 && year < 2010))
                    {
                        x = true;
                    }
                    break;
                case "седаны":
                    bodytype = "sedan";
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
                case "italian renaissance x3":
                    tag = "Italian Renaissance";
                    x = (SearchTag(car, tag));
                    break;
                case "cadillac":
                    if (car.manufacturer == "Cadillac")
                    {
                        x = true;
                    }
                    break;
                case "cadillac x3":
                    if (car.manufacturer == "Cadillac")
                    {
                        x = true;
                    }
                    break;
                case "citroen":
                    if (car.manufacturer == "Citroen")
                    {
                        x = true;
                    }
                    break;
                case "citroen x3":
                    if (car.manufacturer == "Citroen")
                    {
                        x = true;
                    }
                    break;
                case "pre-1970":
                    year = GetYear(car);
                    if (year < 1970)
                    {
                        x = true;
                    }
                    break;
                case "pontiac":
                    if (car.manufacturer == "Pontiac")
                    {
                        x = true;
                    }
                    break;
                case "pontiac x3":
                    if (car.manufacturer == "Pontiac")
                    {
                        x = true;
                    }
                    break;
                case "1975-1984":
                    year = GetYear(car);
                    if (year > 1974 && year < 1985)
                    {
                        x = true;
                    }
                    break;
                case "немецкое возрождение":
                    tag = "German Renaissance";
                    x = (SearchTag(car, tag));
                    break;
                case "немецкое возрождение х3":
                    tag = "German Renaissance";
                    x = (SearchTag(car, tag));
                    break;
                case "fiat":
                    if (car.manufacturer == "Fiat")
                    {
                        x = true;
                    }
                    break;
                case "fiat x3":
                    if (car.manufacturer == "Fiat")
                    {
                        x = true;
                    }
                    break;
                case "nissan":
                    if (car.manufacturer == "Nissan")
                    {
                        x = true;
                    }
                    break;
                case "chevrolet":
                    if (car.manufacturer == "Chevrolet")
                    {
                        x = true;
                    }
                    break;
                case "chevrolet x3":
                    if (car.manufacturer == "Chevrolet")
                    {
                        x = true;
                    }
                    break;
                case "2000-2004":
                    year = GetYear(car);
                    if (year > 1999 && year < 2005)
                    {
                        x = true;
                    }
                    break;
                case "икона стиля":
                    tag = "Style Icon";
                    x = SearchTag(car, tag);
                    break;
                case "2005-2009":
                    year = GetYear(car);
                    if (year > 2004 && year < 2010)
                    {
                        x = true;
                    }
                    break;
                case "1985-1994":
                    year = GetYear(car);
                    if (year > 1984 && year < 1995)
                    {
                        x = true;
                    }
                    break;
                case "subaru":
                    if (car.manufacturer == "Subaru")
                    {
                        x = true;
                    }
                    break;
                case "subaru x3":
                    if (car.manufacturer == "Subaru")
                    {
                        x = true;
                    }
                    break;
                case "автоспорт":
                    tag = "Motorsport";
                    x = (SearchTag(car, tag));
                    break;
                case "отк. верх":
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
                    year = GetYear(car);
                    if (year > 1989 && year < 2000)
                    {
                        x = true;
                    }
                    break;
                case "2000 rwd":
                    if (car.drive == "rwd")
                    {
                        year = GetYear(car);
                        if (year > 1999 && year < 2010)
                        {
                            x = true;
                        }
                    }
                    break;
                case "машины 1970":
                    year = GetYear(car);
                    if (year > 1969 && year < 1980)
                    {
                        x = true;
                    }
                    break;
                case "машины италии х3":
                    if (car.country == "Italy")
                    {
                        x = true;
                    }
                    break;
                case "машины италии х2":
                    if (car.country == "Italy")
                    {
                        x = true;
                    }
                    break;
                case "машины франции х3":
                    if (car.country == "France")
                    {
                        x = true;
                    }
                    break;
                case "машины англии х3":
                    if (car.country == "United Kingdom")
                    {
                        x = true;
                    }
                    break;
                case "машины англии х2":
                    if (car.country == "United Kingdom")
                    {
                        x = true;
                    }
                    break;
                case "машины японии х2":
                    if (car.country == "Japan")
                    {
                        x = true;
                    }
                    break;
                case "машины германии х2":
                    if (car.country == "Germany")
                    {
                        x = true;
                    }
                    break;
                case "машины германии х3":
                    if (car.country == "Germany")
                    {
                        x = true;
                    }
                    break;
                case "german 2015-2019 x3":
                    if (car.country == "Germany")
                    {
                        year = GetYear(car);
                        if (year > 2014 && year < 2020)
                        {
                            x = true;
                        }
                    }
                    break;
                case "машины сша х2":
                    if (car.country == "United States")
                    {
                        x = true;
                    }
                    break;
                case "машины сша х3":
                    if (car.country == "United States")
                    {
                        x = true;
                    }
                    break;
                case "ford x3":
                    if (car.manufacturer == "Ford")
                    {
                        x = true;
                    }
                    break;
                case "opel x3":
                    if (car.manufacturer == "Vauxhall")
                    {
                        x = true;
                    }
                    break;
                case "необычная х3":
                    if (car.rarity == "e")
                    {
                        x = true;
                    }
                    break;
                case "суперская х2":
                    if (car.rarity == "c")
                    {
                        x = true;
                    }
                    break;
                case "german 2010-2014 x3":
                    if (car.country == "German")
                    {
                        year = GetYear(car);
                        if (year > 2009 && year < 2015)
                        {
                            x = true;
                        }
                    }
                    break;
                case "italian 90s x3":
                    if (car.country == "Italy")
                    {
                        year = GetYear(car);
                        if (year > 1989 && year < 2000)
                        {
                            x = true;
                        }
                    }
                    break;
                default:
                    NotePad.DoErrorLog("don't know condition: " + cond);
                    x = false;
                    break;
            }
            return x;
        }
        public static int SatisfyConditionAndDescription(CarForExcel carDescription)
        {
            int carCounter = 0;
            foreach (CarForExcel car in fulltablearray)
            {
                if (SatisfyCondition(Condition.ConditionNumber1, car) && SatisfyCondition(Condition.ConditionNumber2, car))
                {
                    if (carDescription.rarity == car.rarity
                    && carDescription.drive == car.drive
                    && carDescription.clearance == car.clearance
                    //&& carsDescription[j].description.country == additionalDescription.country
                    && carDescription.tires == car.tires)
                    {
                        carCounter++;
                    }
                }
            }
            return AvailableCars(carCounter);
        }
        public static int AvailableCars(int number)
        {
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
        public static bool SearchTag(CarForExcel car, string tag)
        {
            if(car.tags != null)
            {
                return car.tags.Contains(tag);
            }
            return false;
        }
        public static bool SearchBody(CarForExcel car, string bodytype)
        {
            return car.body.Contains(bodytype);
        }
        public static int GetYear(CarForExcel car)
        {
            try
            {
                return Convert.ToInt32(car.year);
            }
            catch(Exception ex)
            {
                NotePad.DoErrorLog("can't convert to int " + car.year);
                return 2100;
            }
        }
        public static int GetSeats(CarForExcel car)
        {
            try
            {
                return Convert.ToInt32(car.seats);
            }
            catch (Exception ex)
            {
                NotePad.DoErrorLog("can't convert to int " + car.seats);
                return 0;
            }
        }
    }
}