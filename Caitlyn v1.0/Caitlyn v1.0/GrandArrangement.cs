using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Caitlyn_v1._0
{
    public class GrandArrangement
    {
        public void Arrangement(int[] trackName, int[] coverage, int[] weather)
        {
            Algorithms al = new Algorithms();
            TrackInfo ti = new TrackInfo();

            Point[] a = { PointsAndRectangles.Finger1, PointsAndRectangles.Finger2, PointsAndRectangles.Finger3, PointsAndRectangles.Finger4, PointsAndRectangles.Finger5 };
            Point[] b = { PointsAndRectangles.Track1position, PointsAndRectangles.Track2position, PointsAndRectangles.Track3position, PointsAndRectangles.Track4position, PointsAndRectangles.Track5position };

            int[] carpictures = NotePad.ReadCars();
            List<Car> cars = new List<Car>();

            foreach (int carpicture in carpictures)
            {
                cars.Add(new Car(carpicture));
            }

            string[,] d = ti.TrackPackage(trackName, coverage, weather);//race full info

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
                                                double point = al.CalculateCompatibility(d[0, 0], d[1, 0], d[2, 0], cars[i1]) +
                                                    al.CalculateCompatibility(d[0, 1], d[1, 1], d[2, 1], cars[i2]) +
                                                    al.CalculateCompatibility(d[0, 2], d[1, 2], d[2, 2], cars[i3]) +
                                                    al.CalculateCompatibility(d[0, 3], d[1, 3], d[2, 3], cars[i4]) +
                                                    al.CalculateCompatibility(d[0, 4], d[1, 4], d[2, 4], cars[i5]);
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
                Rat.DragnDropFast(a[rightarranfement[j]], b[j]);//set choosen car on track
            }
        }
    }
}
