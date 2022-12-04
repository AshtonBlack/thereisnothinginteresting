using System;
using System.IO;

namespace Caitlyn_v1._0
{
    public class Car
    {
        public string carname;
        public int clearance;
        public int tires;
        public int drive;
        public double acceleration;
        public int maxSpeed;
        public int grip;
        public int weight;        
        //legacy
        void IdentifyCar(int carPicture)
        {
            string path = @"C:\Bot\NewPL\PictureToCar.txt";
            
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null && line != " " && line != "")
                {
                    if (carPicture.ToString().Equals(NotePad.GetWordFromString(line, 1)))
                    {
                        carname = NotePad.GetWordFromString(line, 2);
                        NotePad.DoLog("машина определена: " + carname);
                        break;
                    }
                }
                sr.Close();
            }

            if (carname == "unknown" && carPicture != 10000)
            {
                NotePad.DoErrorLog(carPicture + " is unknown car");
            }
        }
        /*
        public Car(int carPicture)
        {
            IdentifyCar(carPicture);

            foreach (CarForExcel car in CarsDB.fulltablearray)
            {
                if (car.fullname() == carname)
                {
                    NotePad.DoLog(carname);
                    clearance = clearanceConverter(car.clearance);
                    tires = tiresConverter(car.tires);
                    drive = driveConverter(car.drive);
                    try
                    {
                        acceleration = Convert.ToDouble(car.acceleration);
                    }
                    catch
                    {
                        NotePad.DoErrorLog("can not convert " + car.acceleration + " to double");
                    }
                    maxSpeed = Convert.ToInt32(car.speed);
                    grip = Convert.ToInt32(car.grip);
                    weight = Convert.ToInt32(car.weight);
                    break;
                }
            }
        }
        */
        //legacy
        //new
        public Car(int id)
        {
            foreach (CarForExcel car in CarsDB.fulltablearray)
            {
                if (car.pictureId == id.ToString())
                {
                    carname = car.fullname();
                    NotePad.DoLog(carname);
                    clearance = clearanceConverter(car.clearance);
                    tires = tiresConverter(car.tires);
                    drive = driveConverter(car.drive);
                    try
                    {
                        acceleration = Convert.ToDouble(car.acceleration);
                    }
                    catch
                    {
                        NotePad.DoErrorLog("can not convert " + car.acceleration + " to double");
                    }
                    maxSpeed = Convert.ToInt32(car.speed);
                    grip = Convert.ToInt32(car.grip);
                    weight = Convert.ToInt32(car.weight);
                    break;
                }
            }
        }
        //new
        int clearanceConverter(string stat)
        {
            switch (stat)
            {
                case "low":
                    return 1;
                case "mid":
                    return 2;
                default:
                    return 3;
            }
        }
        int tiresConverter(string stat)
        {
            switch (stat)
            {
                case "slick":
                    return 1;
                case "per":
                    return 2;
                case "std":
                    return 3;
                case "all":
                    return 4;
                default:
                    return 5;
            }
        }
        int driveConverter(string stat)
        {
            switch (stat)
            {
                case "fwd":
                    return 1;
                case "rwd":
                    return 2;
                default:
                    return 4;
            }
        }
    }
}
