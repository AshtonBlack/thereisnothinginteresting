using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Caytlin_v1._1
{
    internal class GrandArrangement
    {
        public void Arrangement()
        {
            Algorithms al = new Algorithms();
            Point[] fingers = { PointsAndRectangles.Finger1, PointsAndRectangles.Finger2, PointsAndRectangles.Finger3, PointsAndRectangles.Finger4, PointsAndRectangles.Finger5 };
            Point[] tracks = { PointsAndRectangles.Track1position, PointsAndRectangles.Track2position, PointsAndRectangles.Track3position, PointsAndRectangles.Track4position, PointsAndRectangles.Track5position };
            int[] carpictures = NotePad.ReadCars();
            List<Car> cars = new List<Car>();
            foreach (int carpicture in carpictures)
            {
                cars.Add(new Car(carpicture));
            }
            TrackInfo[] tracksInfo = new TrackInfo[5];
            for(int i = 0; i < tracksInfo.Length; i++)
            {
                tracksInfo[i].BulidTrack(i + 1);
            }
            Condition.setPreviousTracks(tracksInfo);//сохраняем для дальнейшего составления руки
            int[] rightarranfement = new int[5];
            double arrangementPoints = -1000000;
            for (int i1 = 0; i1 < 5; i1++)
            {
                for (int i2 = 0; i2 < 5; i2++)
                {
                    if (i2 != i1)
                    {
                        for (int i3 = 0; i3 < 5; i3++)
                        {
                            if (i3 != i1 && i3 != i2)
                            {
                                for (int i4 = 0; i4 < 5; i4++)
                                {
                                    if (i4 != i1 && i4 != i2 && i4 != i3)
                                    {
                                        for (int i5 = 0; i5 < 5; i5++)
                                        {
                                            if (i5 != i1 && i5 != i2 && i5 != i3 && i5 != i4)
                                            {
                                                double point = al.CalculateCompatibility(tracksInfo[0].track, tracksInfo[0].ground, tracksInfo[0].weather, cars[i1]) +
                                                    al.CalculateCompatibility(tracksInfo[1].track, tracksInfo[1].ground, tracksInfo[1].weather, cars[i2]) +
                                                    al.CalculateCompatibility(tracksInfo[2].track, tracksInfo[2].ground, tracksInfo[2].weather, cars[i3]) +
                                                    al.CalculateCompatibility(tracksInfo[3].track, tracksInfo[3].ground, tracksInfo[3].weather, cars[i4]) +
                                                    al.CalculateCompatibility(tracksInfo[4].track, tracksInfo[4].ground, tracksInfo[4].weather, cars[i5]);
                                                if (point > arrangementPoints)
                                                {
                                                    rightarranfement = new int[] { i1, i2, i3, i4, i5 };
                                                    arrangementPoints = point;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            for (int j = 0; j < 5; j++)//logic for dragndrop
            {
                Thread.Sleep(1000);
                Rat.DragnDropFast(fingers[rightarranfement[j]], tracks[j]);//set choosen car on track
            }
        }
    }
}
