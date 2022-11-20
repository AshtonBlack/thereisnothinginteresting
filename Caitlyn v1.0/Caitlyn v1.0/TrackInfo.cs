using System;
using System.Drawing;
using System.IO;

namespace Caitlyn_v1._0
{
    public class TrackInfo
    {
        //new
        public string ground { get; set; }
        public string weather { get; set; }
        public string track { get; set; }
        public void BuildTrack(int position)
        {
            IdentifyGround(position);
            IdentifyWeather(position);
            IdentifyTrack(position);
        }
        void IdentifyGround(int position)
        {
            ground = "Неизвестное покрытие";
            int length = NotePad.GetInfoFileLength(groundDirectory + position + "\\info.txt");
            string[,] theTable = NotePad.ReadInfoFromTXT(groundDirectory + position + "\\info.txt");
            int pictureNumber = FindGroundPicture(position);
            for (int l = 0; l < length; l++)
            {
                if (pictureNumber == Convert.ToInt32(theTable[l, 0]))
                {
                    ground = theTable[l, 1];
                    break;
                }
            }
            if (ground == "Неизвестное покрытие")
            {
                NotePad.DoErrorLog("Неизвестное покрытие позиция " + position);
            }
        }
        int FindGroundPicture(int position)
        {
            Rectangle[] b = { PointsAndRectangles.Ground1, PointsAndRectangles.Ground2, PointsAndRectangles.Ground3, PointsAndRectangles.Ground4, PointsAndRectangles.Ground5 };
            MasterOfPictures.BW2Capture(b[position - 1], ("Ground" + position + "\\test"));
            int pictureCounter = 0;
            for (int i = 1; i < 100; i++)
            {
                if (File.Exists(groundDirectory + position + "\\" + i + ".jpg"))
                {
                    pictureCounter = i;
                }
                else break;
            }
            for (int i = 1; i < pictureCounter + 1; i++)
            {
                if (MasterOfPictures.VerifyBW(("Ground" + position + "\\" + i), ("Ground" + position + "\\test"), 150))
                {
                    File.Delete(groundDirectory + position + "\\test.jpg");
                    return i;
                }
            }
            NotePad.DoLog("Добавляю новое покрытие");
            File.Move(groundDirectory + position + "\\test.jpg", groundDirectory + position + "\\" + (pictureCounter + 1) + ".jpg");
            return 0;
        }
        void IdentifyTrack(int position)
        {
            track = "Неизвестная трасса";
            int length = NotePad.GetInfoFileLength(trackDirectory + position + "\\info.txt");
            string[,] theTable = NotePad.ReadInfoFromTXT(trackDirectory + position + "\\info.txt");
            int pictureNumber = FindTrackPicture(position);
            for (int l = 0; l < length; l++)
            {
                if (pictureNumber == Convert.ToInt32(theTable[l, 0]))
                {
                    track = theTable[l, 1];
                    break;
                }
            }
            if (track == "Неизвестная трасса")
            {
                NotePad.DoErrorLog("Неизвестная трасса позиция " + position);
            }
        }
        int FindTrackPicture(int position)
        {
            Rectangle[] a = { PointsAndRectangles.Track1, PointsAndRectangles.Track2, PointsAndRectangles.Track3, PointsAndRectangles.Track4, PointsAndRectangles.Track5 };
            MasterOfPictures.TrackCapture(a[position - 1], ("Track" + position + "\\test"));
            int pictureCounter = 0;
            for (int i = 1; i < 100; i++)
            {
                if (File.Exists(trackDirectory + position + "\\" + i + ".jpg"))
                {
                    pictureCounter = i;
                }
                else break;
            }
            for (int i = 1; i < pictureCounter + 1; i++)
            {
                if (MasterOfPictures.VerifyBW(("Track" + position + "\\" + i), ("Track" + position + "\\test"), 120))
                {
                    File.Delete(trackDirectory + position + "\\test.jpg");
                    return i;
                }
            }
            NotePad.DoLog("Добавляю новый трэк");
            File.Move(trackDirectory + position + "\\test.jpg", trackDirectory + position + "\\" + (pictureCounter + 1) + ".jpg");
            return 0;
        }
        void IdentifyWeather(int position)
        {
            weather = "Неизвестная погода";
            int length = NotePad.GetInfoFileLength(weatherDirectory + position + "\\info.txt");
            string[,] theTable = NotePad.ReadInfoFromTXT(weatherDirectory + position + "\\info.txt");
            int pictureNumber = FindWeatherPicture(position);
            for (int l = 0; l < length; l++)
            {
                if (pictureNumber == Convert.ToInt32(theTable[l, 0]))
                {
                    weather = theTable[l, 1];
                    break;
                }
            }
            if (weather == "Неизвестная погода")
            {
                NotePad.DoErrorLog("Неизвестная погода позиция " + position);
            }
        }
        int FindWeatherPicture(int position)
        {
            Rectangle[] c = { PointsAndRectangles.Weather1, PointsAndRectangles.Weather2, PointsAndRectangles.Weather3, PointsAndRectangles.Weather4, PointsAndRectangles.Weather5 };
            MasterOfPictures.BW2Capture(c[position - 1], ("Weather" + position + "\\test"));
            int pictureCounter = 0;
            for (int i = 1; i < 10; i++)
            {
                if (File.Exists(weatherDirectory + position + "\\" + i + ".jpg"))
                {
                    pictureCounter = i;
                }
                else break;
            }

            for (int i = 1; i < pictureCounter + 1; i++)
            {
                if (MasterOfPictures.VerifyBW(("Weather" + position + "\\" + i), ("Weather" + position + "\\test"), 30))
                {
                    File.Delete(weatherDirectory + position + "\\test.jpg");
                    return i;
                }
            }

            NotePad.DoLog("Добавляю новую погоду");
            File.Move(weatherDirectory + position + "\\test.jpg", weatherDirectory + position + "\\" + (pictureCounter + 1) + ".jpg");
            return 0;
        }
        //new
        string trackDirectory = @"C:\Bot\Track";
        string groundDirectory = @"C:\Bot\Ground";
        string weatherDirectory = @"C:\Bot\Weather";
        /*
        //legacy
        public int[] Tracks()
        {
            int n;
            bool flag;
            Rectangle[] a = { PointsAndRectangles.Track1, PointsAndRectangles.Track2, PointsAndRectangles.Track3, PointsAndRectangles.Track4, PointsAndRectangles.Track5 };
            int[] a1 = new int[5];            

            for (int i = 0; i < 5; i++)
            {
                flag = true;
                MasterOfPictures.TrackCapture(a[i], ("Track" + (i + 1) + "\\test"));
                n = 0;
                for (int i1 = 1; i1 < 100; i1++)
                {
                    if (File.Exists(trackDirectory + (i + 1) + "\\" + i1 + ".jpg"))
                    {
                        n = i1;
                    }
                    else break;
                }

                for (int i2 = 1; i2 < (n + 1); i2++)
                {
                    if (MasterOfPictures.VerifyBW(("Track" + (i + 1) + "\\" + i2), ("Track" + (i + 1) + "\\test"), 120))
                    {
                        a1[i] = i2;
                        File.Delete(trackDirectory + (i + 1) + "\\test.jpg");
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    a1[i] = 0;
                    NotePad.DoLog("Добавляю новый трэк");
                    File.Move(trackDirectory + (i + 1) + "\\test.jpg", trackDirectory + (i + 1) + "\\" + (n + 1) + ".jpg");
                }
            }

            return a1;
        }
        public int[] Grounds()
        {
            Rectangle[] b = { PointsAndRectangles.Ground1, PointsAndRectangles.Ground2, PointsAndRectangles.Ground3, PointsAndRectangles.Ground4, PointsAndRectangles.Ground5 };
            int n;
            bool flag;
            int[] b1 = new int[5];
            for (int i = 0; i < 5; i++)
            {
                flag = true;
                MasterOfPictures.BW2Capture(b[i], ("Ground" + (i + 1) + "\\test"));
                n = 0;
                for (int i1 = 1; i1 < 100; i1++)
                {
                    if (File.Exists(groundDirectory + (i + 1) + "\\" + i1 + ".jpg"))
                    {
                        n = i1;
                    }
                    else break;
                }

                for (int i2 = 1; i2 < (n + 1); i2++)
                {
                    if (MasterOfPictures.VerifyBW(("Ground" + (i + 1) + "\\" + i2), ("Ground" + (i + 1) + "\\test"), 150))
                    {
                        b1[i] = i2;
                        File.Delete(groundDirectory + (i + 1) + "\\test.jpg");
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    b1[i] = 0;
                    NotePad.DoLog("Добавляю новое покрытие");
                    File.Move(groundDirectory + (i + 1) + "\\test.jpg", groundDirectory + (i + 1) + "\\" + (n + 1) + ".jpg");
                }
            }

            return b1;
        }
        public int[] Weathers()
        {
            Rectangle[] c = { PointsAndRectangles.Weather1, PointsAndRectangles.Weather2, PointsAndRectangles.Weather3, PointsAndRectangles.Weather4, PointsAndRectangles.Weather5 };
            int n;
            bool flag;
            int[] c1 = new int[5];

            for (int i = 0; i < 5; i++)
            {
                flag = true;
                MasterOfPictures.BW2Capture(c[i], ("Weather" + (i + 1) + "\\test"));
                n = 0;
                for (int i1 = 1; i1 < 10; i1++)
                {
                    if (File.Exists(weatherDirectory + (i + 1) + "\\" + i1 + ".jpg"))
                    {
                        n = i1;
                    }
                    else break;
                }

                for (int i2 = 1; i2 < (n + 1); i2++)
                {
                    if (MasterOfPictures.VerifyBW(("Weather" + (i + 1) + "\\" + i2), ("Weather" + (i + 1) + "\\test"), 30))
                    {
                        c1[i] = i2;
                        File.Delete(weatherDirectory + (i + 1) + "\\test.jpg");
                        flag = false;
                        break;
                    }
                }

                if (flag == true)
                {
                    c1[i] = 0;
                    NotePad.DoLog("Добавляю новую погоду");
                    try
                    {
                        File.Move(weatherDirectory + (i + 1) + "\\test.jpg", weatherDirectory + (i + 1) + "\\" + (n + 1) + ".jpg");
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            return c1;
        }
        public string[,] TrackPackage(int[] trackName, int[] coverage, int[] weather)
        {
            string[] a2 = IdentifyTracks(trackName);
            string[] b2 = IdentifyGround(coverage);
            string[] c2 = IdentifyWeather(weather);
            string[,] d = new string[3, 5];
            for (int i = 0; i < 5; i++)
            {
                d[0, i] = a2[i];
                d[1, i] = b2[i];
                d[2, i] = c2[i];

                NotePad.DoLog((i + 1) + " Трэк: " + d[0, i] + " " + d[1, i] + " " + d[2, i]);
            }

            return d;
        }
        public string[] IdentifyGround(int[] b1)
        {
            string[] grounds = new string[5];
            for (int i = 0; i < 5; i++)
            {
                string name = "unknown";
                int length = NotePad.GetInfoFileLength(groundDirectory + (i + 1) + "\\info.txt");
                string[,] theTable = NotePad.ReadInfoFromTXT(groundDirectory + (i + 1) + "\\info.txt");
                for (int l = 0; l < length; l++)
                {
                    if (b1[i] == Convert.ToInt32(theTable[l, 0]))
                    {
                        name = theTable[l, 1];
                        grounds[i] = name;
                        break;
                    }
                }
                if (name == "unknown")
                {
                    NotePad.DoErrorLog("Неизвестное покрытие позиция " + (i + 1));
                    grounds[i] = "Неизвестная покрытие";
                }
            }

            bool asphalt = false;
            bool mud = false;

            foreach (string x in grounds)
            {
                if (x == "Асфальт")
                {
                    asphalt = true;
                }
                else
                {
                    mud = true;
                }
            }

            if (asphalt)
            {
                Condition.coverage = "Асфальт";
                if (mud) Condition.coverage = "Смешанное";
            }
            else Condition.coverage = "Бездорожье";
            NotePad.LastCoverage(Condition.coverage);
            return grounds;
        }
        public string[] IdentifyWeather(int[] c1)
        {
            string[] weathers = new string[5];
            for (int i = 0; i < 5; i++)
            {
                string name = "unknown";
                int length = NotePad.GetInfoFileLength(weatherDirectory + (i + 1) + "\\info.txt");
                string[,] theTable = NotePad.ReadInfoFromTXT(weatherDirectory + (i + 1) + "\\info.txt");
                for (int l = 0; l < length; l++)
                {
                    if (c1[i] == Convert.ToInt32(theTable[l, 0]))
                    {
                        name = theTable[l, 1];
                        weathers[i] = name;
                        break;
                    }
                }
                if (name == "unknown")
                {
                    NotePad.DoErrorLog("Неизвестная погода позиция " + (i + 1));
                    weathers[i] = "Неизвестная погода";
                }
            }

            bool dry = false;
            bool wet = false;

            foreach (string x in weathers)
            {
                if (x == "Дождь")
                {
                    wet = true;
                }

                if (x == "Солнечно")
                {
                    dry = true;
                }
            }

            Condition.weather = "ясно";
            if (wet)
            {
                if (dry) Condition.weather = "с прояснением";
                else Condition.weather = "дождь";
            }
            NotePad.LastWeather(Condition.weather);

            return weathers;
        }
        public string[] IdentifyTracks(int[] a1)
        {
            string[] tracks = new string[5];

            for (int i = 0; i < 5; i++)
            {
                string name = "unknown";
                int length = NotePad.GetInfoFileLength(trackDirectory + (i + 1) + "\\info.txt");
                string[,] theTable = NotePad.ReadInfoFromTXT(trackDirectory + (i + 1) + "\\info.txt");
                for (int l = 0; l < length; l++)
                {
                    if (a1[i] == Convert.ToInt32(theTable[l, 0]))
                    {
                        name = theTable[l, 1];
                        tracks[i] = name;
                        break;
                    }
                }
                if (name == "unknown")
                {
                    NotePad.DoErrorLog("Неизвестная трасса позиция " + (i + 1));
                    tracks[i] = "Неизвестная трасса";
                }
            }
            return tracks;
        }
        //legacy
        */
    }
}
