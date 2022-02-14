using System;
using System.IO;

namespace Caitlyn_v1._0
{
    public class Car
    {
        public string carname = "unknown";
        public int clearance = 1;
        public int tires = 2;
        public int drive = 2;
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
                    if (carPicture.ToString().Equals(NotePad.Transform(line, 1)))
                    {
                        carname = NotePad.Transform(line, 2);
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
            string[,] carsArray = CarsDB.fulltablearray;
            int lenght = CarsDB.linenumber;

            for (int i = 0; i < lenght; i++)
            {
                string testcar = carsArray[i, 8] + " " + carsArray[i, 9] + " " + carsArray[i, 15];
                if (testcar == carname)
                {
                    NotePad.DoLog(carname);
                    clearance = clearanceConverter(carsArray[i, 3]);
                    tires = tiresConverter(carsArray[i, 13]);
                    drive = driveConverter(carsArray[i, 5]);
                    try
                    {
                        acceleration = Convert.ToDouble(carsArray[i, 0]);
                    }
                    catch
                    {
                        NotePad.DoErrorLog("can not convert " + carsArray[i, 0] + " to double");
                    }
                    maxSpeed = Convert.ToInt32(carsArray[i, 12]);
                    grip = Convert.ToInt32(carsArray[i, 7]);
                    weight = Convert.ToInt32(carsArray[i, 14]);
                    break;
                }
            }
        }

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
