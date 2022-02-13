using System;
using System.IO;
using System.Text;

namespace WindowsFormsApp1 //universal
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

        string Transform(string line, int wordN)
        {
            char[] word = line.Trim().ToCharArray();
            StringBuilder firstWord = new StringBuilder();
            StringBuilder secondWord = new StringBuilder();

            bool firstWordComplete = false;
            foreach (char literal in word)
            {
                if (firstWordComplete)
                {
                    secondWord.Append(literal);
                }
                else
                {
                    if (literal == ' ')
                    {
                        firstWordComplete = true;
                    }
                    else firstWord.Append(literal);
                }
            } 

            if (wordN == 1)
            {
                return firstWord.ToString();
            }
            else
            {
                return secondWord.ToString();
            }
        }

        void IdentifyCar(int carPicture)
        {
            string path = @"C:\Bot\NewPL\PictureToCar.txt";
            /*
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null && line != " " && line != "")
                {
                    if (carPicture.ToString().Equals(Transform(line, 1)))
                    {
                        carname = Transform(line, 2);
                        NotePad.DoLog("машина определена: " + carname);
                        break;
                    }
                }
                sr.Close();
            }
            */

            int length = NotePad.GetInfoFileLength(path);
            string[,] picturetoname = new string[length, 2];

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                for (int i = 0; i < length; i++)
                {
                    string theline = sr.ReadLine();
                    picturetoname[i, 0] = Transform(theline, 1);
                    picturetoname[i, 1] = Transform(theline, 2);
                }
                sr.Close();
            }

            for (int i = 0; i < length; i++)
            {
                if (carPicture == Convert.ToInt32(picturetoname[i, 0]))
                {
                    carname = picturetoname[i, 1];
                    NotePad.DoLog("машина определена: " + carname);
                    break;
                }
            }

            if (carname == "unknown" && carPicture != 10000)
            {
                NotePad.DoErrorLog(carPicture + " is unknown car");
            }
        }
        
        public Car(int carPicture)
        {
            IdentifyCar(carPicture);
            string [,] carsArray = CarsDB.fulltablearray;
            int lenght = CarsDB.linenumber;

            for(int i = 0; i<lenght; i++)
            {
                string testcar = carsArray[i, 8] + " " + carsArray[i, 9] + " " + carsArray[i, 15];
                if(testcar == carname)
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