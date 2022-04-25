using System;
using System.IO;

namespace Caytlin_v1._1
{
    internal class Car
    {
        public string carname = "unknown";
        public string clearance = "low";
        public string tires = "per";
        public string drive = "rwd";
        public double acceleration = 36;
        public int maxSpeed = 100;
        public int grip = 45;
        public int weight = 2500;
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
        public Car(int carPicture)
        {
            IdentifyCar(carPicture);
            foreach (CarForExcel car in CarsDB.fulltablearray)
            {
                if (car.fullname() == carname)
                {
                    NotePad.DoLog(carname);
                    clearance = car.clearance;
                    tires = car.tires;
                    drive = car.drive;
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
    }
}
