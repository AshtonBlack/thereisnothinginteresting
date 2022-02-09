using System;
using System.Collections.Generic;
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

        List<Tuple<string,string>> picturetoname = new List<Tuple<string, string>>();        

        void PictureToNameTable()
        {
            string commonpath = @"C:\Bot\NewPL\";
            string path = "PictureToCar.txt";

            using (StreamReader sr = new StreamReader(commonpath + path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null && line != " " && line != "")
                {
                    picturetoname.Add(new Tuple<string, string>(Transform(line, 0), Transform(line, 1)));
                }
                sr.Close();
            }
        }

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
            PictureToNameTable();
            foreach(Tuple<string,string> pair in picturetoname)
            {
                if (carPicture == Convert.ToInt32(pair.Item1))
                {
                    carname = pair.Item2;
                    break;
                }
            }
            
            if(carname == "unknown" && carPicture != 10000)
            {
                NotePad.DoErrorLog(carPicture + " is unknown car");
            }
        }
        
        public Car(int carPicture)
        {
            IdentifyCar(carPicture);
            string [,] carsArray = CarsDB.fulltablearray;
            int lenght = CarsDB.linenumber;
            bool carIsFounded = false;

            for(int i = 0; i<lenght; i++)
            {
                string testcar = carsArray[i, 8] + " " + carsArray[i, 9] + " " + carsArray[i, 15];
                if(testcar == carname)
                {
                    NotePad.DoLog(carname);
                    carIsFounded = true;
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

            if(carname != "unknown")
            {
                if (!carIsFounded)
                {
                    NotePad.DoErrorLog("Не знаю статы для " + carname);
                }
            }
            else
            {
                NotePad.DoLog(carname);
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