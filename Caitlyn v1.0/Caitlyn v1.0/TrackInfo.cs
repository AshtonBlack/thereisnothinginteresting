using System;
using System.Drawing;
using System.IO;

namespace Caitlyn_v1._0
{
    public class TrackInfo
    {
        public string ground { get; set; }
        public string weather { get; set; }
        public string track { get; set; }
        public TrackInfo() { }
        public TrackInfo(int position)
        {
            IdentifyGround(position);
            IdentifyWeather(position);
            IdentifyTrack(position);
        }
        public TrackInfo(string ground, string weather, string track)
        {
            this.ground = ground;
            this.weather = weather;
            this.track = track;
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
            for (int i = 1; i < 100; i++)
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
        string trackDirectory = @"C:\Bot\Track";
        string groundDirectory = @"C:\Bot\Ground";
        string weatherDirectory = @"C:\Bot\Weather";        
    }
}
