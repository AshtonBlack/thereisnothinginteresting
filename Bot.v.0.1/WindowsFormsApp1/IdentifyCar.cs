using System;
using System.IO;

namespace WindowsFormsApp1 //universal
{
    public class IdentifyCar
    {
        public string[,] picturetoname { get; set; }
        public int length { get; set; }

        public void PictureToNameTable()
        {
            string commonpath = @"C:\Bot\NewPL\";
            string path = "PictureToCar.txt";
            length = 0;
            using (StreamReader sr = new StreamReader(commonpath + path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null && line != " " && line != "")
                {
                    length++;
                }
                sr.Close();
            }
            picturetoname = new string[length, 2];

            using (StreamReader sr = new StreamReader(commonpath + path, System.Text.Encoding.Default))
            {
                for (int i = 0; i < length; i++)
                {
                    string theline = sr.ReadLine();
                    picturetoname[i, 0] = Transform3(theline, 1);
                    picturetoname[i, 1] = Transform3(theline, 2);
                }
                sr.Close();
            }
        }

        public string Transform3(string t, int wordN)
        {
            string forreturn;
            string a = t.Trim();
            char[] word = a.ToCharArray();

            int wordBlength = 0;
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != ' ')
                {
                    wordBlength++;
                }
                else break;
            }
            char[] wordB = new char[wordBlength];
            for (int i = 0; i < wordB.Length; i++)
            {
                wordB[i] = word[i];
            }

            char[] wordC = new char[word.Length - wordBlength - 1];
            for (int i = 0; i < wordC.Length; i++)
            {
                wordC[i] = word[i + wordBlength + 1];
            }

            if (wordN == 1)
            {
                forreturn = new string(wordB);
            }
            else
            {
                forreturn = new string(wordC);
            }
            return forreturn;
        }

        public string Identify1Car(int carPicture)
        {
            string carname = "unknown";

            PictureToNameTable();
            for(int i = 0; i < length; i++)
            {
                if(carPicture == Convert.ToInt32(picturetoname[i,0]))
                {
                    carname = picturetoname[i,1];
                    break;
                }
            }
            if(carname == "unknown" && carPicture != 10000)
            {
                NotePad.DoErrorLog(carPicture + " is unknown car");
            }
            
            return carname;
        }
        
        public double[] CarStats(string carname)
        {
            int clearance = 1;
            int tires = 2;
            int drive = 2;
            double acceleration = 36;
            int maxspeed = 100;
            int grip = 45;
            int weight = 2500;

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
                    maxspeed = Convert.ToInt32(carsArray[i, 12]);
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
                        
            double[] stats = { clearance, tires, drive, acceleration, maxspeed, grip, weight };
            return stats;
        }

        int clearanceConverter(string stat)
        {
            int clearance;
            switch (stat)
            {
                case "low":
                    clearance = 1;
                    break;
                case "mid":
                    clearance = 2;
                    break;
                default:
                    clearance = 3;
                    break;
            }

            return clearance;
        }

        int tiresConverter(string stat)
        {
            int tires;
            switch (stat)
            {
                case "slick":
                    tires = 1;
                    break;
                case "per":
                    tires = 2;
                    break;
                case "std":
                    tires = 3;
                    break;
                case "all":
                    tires = 4;
                    break;
                default:
                    tires = 5;
                    break;
            }

            return tires;
        }

        int driveConverter(string stat)
        {
            int drive;
            switch (stat)
            {
                case "fwd":
                    drive = 1;
                    break;
                case "rwd":
                    drive = 2;
                    break;
                default:
                    drive = 4;
                    break;
            }
           
            return drive;
        }
    }
}